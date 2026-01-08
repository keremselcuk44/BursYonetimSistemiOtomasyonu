using SkiaSharp;

namespace DiagramRenderer;

public static class Program
{
    private sealed record Box(string Id, string Text, float X, float Y, float W, float H);

    public static int Main(string[] args)
    {
        // Usage:
        //   dotnet run --project tools/DiagramRenderer -c Release -- <diagramType> <outPngPath>
        // diagramType: system | erd
        var diagramType = args.Length >= 1 ? args[0].Trim().ToLowerInvariant() : "system";
        var outPng = args.Length >= 2
            ? args[1]
            : (diagramType == "erd" ? "exports/tablo_iliski_semasi.png" : "exports/system_mimarisi.png");

        const int width = 1400;
        const int height = 900;

        using var surface = SKSurface.Create(new SKImageInfo(width, height, SKColorType.Rgba8888, SKAlphaType.Premul));
        var canvas = surface.Canvas;
        canvas.Clear(SKColors.White);

        using var boxFill = new SKPaint { Color = SKColor.Parse("#F8FAFC"), IsAntialias = true, Style = SKPaintStyle.Fill };
        using var boxStroke = new SKPaint { Color = SKColor.Parse("#0F172A"), IsAntialias = true, Style = SKPaintStyle.Stroke, StrokeWidth = 2 };
        using var textPaint = new SKPaint { Color = SKColor.Parse("#0F172A"), IsAntialias = true, TextSize = 22, Typeface = SKTypeface.FromFamilyName("Segoe UI") };
        using var titlePaint = new SKPaint { Color = SKColor.Parse("#0F172A"), IsAntialias = true, TextSize = 28, Typeface = SKTypeface.FromFamilyName("Segoe UI", SKFontStyle.Bold) };
        using var subtitlePaint = new SKPaint { Color = SKColor.Parse("#334155"), IsAntialias = true, TextSize = 18, Typeface = SKTypeface.FromFamilyName("Segoe UI") };
        using var arrowPaint = new SKPaint { Color = SKColor.Parse("#0F172A"), IsAntialias = true, Style = SKPaintStyle.Stroke, StrokeWidth = 2.5f };

        if (diagramType == "erd")
        {
            DrawErd(canvas, titlePaint, subtitlePaint, textPaint, boxFill, boxStroke, arrowPaint);
        }
        else
        {
            DrawSystemArchitecture(canvas, titlePaint, subtitlePaint, textPaint, boxFill, boxStroke, arrowPaint);
        }

        // Save PNG
        using var image = surface.Snapshot();
        using var data = image.Encode(SKEncodedImageFormat.Png, 100);
        Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(outPng))!);
        using var fs = File.Open(outPng, FileMode.Create, FileAccess.Write);
        data.SaveTo(fs);

        Console.WriteLine($"Wrote: {outPng}");
        return 0;
    }

    private static Box Find(Box[] boxes, string id) => boxes.First(b => b.Id == id);

    private static SKPoint LeftMid(Box b) => new(b.X, b.Y + b.H / 2);
    private static SKPoint RightMid(Box b) => new(b.X + b.W, b.Y + b.H / 2);

    private static void DrawRoundedBox(SKCanvas canvas, Box b, SKPaint fill, SKPaint stroke)
    {
        var rect = new SKRoundRect(new SKRect(b.X, b.Y, b.X + b.W, b.Y + b.H), 14, 14);
        canvas.DrawRoundRect(rect, fill);
        canvas.DrawRoundRect(rect, stroke);
    }

    private static void DrawCenteredMultiline(SKCanvas canvas, Box b, SKPaint paint)
    {
        var lines = b.Text.Split('\n');
        var lineHeight = paint.TextSize * 1.2f;
        var totalHeight = lines.Length * lineHeight;
        var startY = b.Y + (b.H - totalHeight) / 2 + paint.TextSize; // baseline

        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            var w = paint.MeasureText(line);
            var x = b.X + (b.W - w) / 2;
            var y = startY + i * lineHeight;
            canvas.DrawText(line, x, y, paint);
        }
    }

    private static void DrawArrow(SKCanvas canvas, SKPoint from, SKPoint to, SKPaint paint)
    {
        // Straight line
        canvas.DrawLine(from, to, paint);

        // Arrow head
        var dx = to.X - from.X;
        var dy = to.Y - from.Y;
        var len = MathF.Sqrt(dx * dx + dy * dy);
        if (len < 1) return;

        var ux = dx / len;
        var uy = dy / len;

        var headLen = 12f;
        var headWidth = 7f;

        var bx = to.X - ux * headLen;
        var by = to.Y - uy * headLen;

        // perpendicular
        var px = -uy;
        var py = ux;

        var p1 = new SKPoint(bx + px * headWidth, by + py * headWidth);
        var p2 = new SKPoint(bx - px * headWidth, by - py * headWidth);

        using var fill = new SKPaint { Color = paint.Color, IsAntialias = true, Style = SKPaintStyle.Fill };
        using var path = new SKPath();
        path.MoveTo(to);
        path.LineTo(p1);
        path.LineTo(p2);
        path.Close();
        canvas.DrawPath(path, fill);
    }

    private static void DrawSystemArchitecture(
        SKCanvas canvas,
        SKPaint titlePaint,
        SKPaint subtitlePaint,
        SKPaint textPaint,
        SKPaint boxFill,
        SKPaint boxStroke,
        SKPaint arrowPaint)
    {
        canvas.DrawText("4.1.3 Sistem Mimarisi", 40, 55, titlePaint);
        canvas.DrawText("Öğrenci (Web) → wwwroot HTML/JS → Web API → Veritabanı / Gemini / E‑posta", 40, 85, subtitlePaint);

        var boxes = new[]
        {
            new Box("U", "Öğrenci (Web)",                 70,  200, 260, 90),
            new Box("W", "wwwroot HTML/JS",              400, 200, 300, 90),
            new Box("M", "Komisyon/Finans\n(Desktop)",    70,  380, 260, 110),
            new Box("D", "WinForms",                     400, 390, 300, 90),
            new Box("API","Web API",                     800, 280, 240, 110),
            new Box("DB", "Veritabanı",                 1120, 200, 240, 90),
            new Box("AI", "Gemini Puanlama",            1120, 340, 240, 90),
            new Box("MAIL","E-posta Servisi",           1120, 480, 240, 90),
        };

        foreach (var b in boxes)
        {
            DrawRoundedBox(canvas, b, boxFill, boxStroke);
            DrawCenteredMultiline(canvas, b, textPaint);
        }

        var U = Find(boxes, "U");
        var W = Find(boxes, "W");
        var M = Find(boxes, "M");
        var D = Find(boxes, "D");
        var API = Find(boxes, "API");
        var DB = Find(boxes, "DB");
        var AI = Find(boxes, "AI");
        var MAIL = Find(boxes, "MAIL");

        DrawArrow(canvas, RightMid(U), LeftMid(W), arrowPaint);
        DrawArrow(canvas, RightMid(W), LeftMid(API), arrowPaint);
        DrawArrow(canvas, RightMid(M), LeftMid(D), arrowPaint);
        DrawArrow(canvas, RightMid(D), LeftMid(API), arrowPaint);

        DrawArrow(canvas, RightMid(API), LeftMid(DB), arrowPaint);
        DrawArrow(canvas, RightMid(API), LeftMid(AI), arrowPaint);
        DrawArrow(canvas, RightMid(API), LeftMid(MAIL), arrowPaint);
    }

    private static void DrawErd(
        SKCanvas canvas,
        SKPaint titlePaint,
        SKPaint subtitlePaint,
        SKPaint textPaint,
        SKPaint boxFill,
        SKPaint boxStroke,
        SKPaint arrowPaint)
    {
        canvas.DrawText("4.2.2 Tablo–İlişki Şeması (ERD)", 40, 55, titlePaint);
        canvas.DrawText("PK/FK ilişkileri: Ogrenci ↔ OgrenciBurs ↔ Burs ve OgrenciBurs ↔ BursOdemeTakip", 40, 85, subtitlePaint);

        using var smallText = new SKPaint
        {
            Color = textPaint.Color,
            IsAntialias = true,
            TextSize = 17,
            Typeface = textPaint.Typeface
        };
        using var labelPaint = new SKPaint { Color = SKColor.Parse("#0F172A"), IsAntialias = true, TextSize = 18, Typeface = SKTypeface.FromFamilyName("Segoe UI", SKFontStyle.Bold) };

        var boxes = new[]
        {
            new Box("Ogrenci",
                "Ogrenci\n—\nPK: Id\nTcKimlikNo\nAd, Soyad\nUniversite, Bolum, Sinif\nAgno, KardesSayisi, HaneGeliri, Yas\nPuan, AiRaporu\nEmail, Telefon, Iban, ResimYolu",
                70,  140, 430, 340),

            new Box("Burs",
                "Burs\n—\nPK: Id\nBursAdi, BursTipi\nMinimumPuan, Kontenjan\nAylikTutar, OdemePeriyodu\nBaslangicTarihi, BitisTarihi\nAktifMi, Kosullar",
                900, 140, 430, 300),

            new Box("OgrenciBurs",
                "OgrenciBurs\n—\nPK: Id\nFK: OgrenciId → Ogrenci.Id\nFK: BursId → Burs.Id\nOnaylandi",
                560, 530, 320, 170),

            new Box("BursOdemeTakip",
                "BursOdemeTakip\n—\nPK: Id\nFK: OgrenciBursId → OgrenciBurs.Id\nAy, Yil\nOdendiMi\nOdemeTarihi",
                950, 520, 380, 200),

            new Box("Kullanici",
                "Kullanici\n—\nPK: Id\nKullaniciAdi\nSifreHash\nAktif\nOlusturmaTarihi",
                70,  530, 360, 170),
        };

        foreach (var b in boxes)
        {
            DrawRoundedBox(canvas, b, boxFill, boxStroke);
            DrawCenteredMultiline(canvas, b, smallText);
        }

        var ogr = Find(boxes, "Ogrenci");
        var burs = Find(boxes, "Burs");
        var ob = Find(boxes, "OgrenciBurs");
        var od = Find(boxes, "BursOdemeTakip");

        // Relationships (arrows) + 1/N labels
        var ogrToObFrom = new SKPoint(ogr.X + ogr.W, ogr.Y + ogr.H * 0.55f);
        var ogrToObTo = new SKPoint(ob.X, ob.Y + ob.H * 0.35f);
        DrawArrow(canvas, ogrToObFrom, ogrToObTo, arrowPaint);
        canvas.DrawText("1", ogrToObFrom.X - 18, ogrToObFrom.Y - 10, labelPaint);
        canvas.DrawText("N", ogrToObTo.X + 8, ogrToObTo.Y - 10, labelPaint);

        var bursToObFrom = new SKPoint(burs.X, burs.Y + burs.H * 0.65f);
        var bursToObTo = new SKPoint(ob.X + ob.W, ob.Y + ob.H * 0.55f);
        DrawArrow(canvas, bursToObFrom, bursToObTo, arrowPaint);
        canvas.DrawText("1", bursToObFrom.X + 8, bursToObFrom.Y - 10, labelPaint);
        canvas.DrawText("N", bursToObTo.X - 18, bursToObTo.Y - 10, labelPaint);

        var obToOdFrom = new SKPoint(ob.X + ob.W, ob.Y + ob.H * 0.65f);
        var obToOdTo = new SKPoint(od.X, od.Y + od.H * 0.45f);
        DrawArrow(canvas, obToOdFrom, obToOdTo, arrowPaint);
        canvas.DrawText("1", obToOdFrom.X - 18, obToOdFrom.Y - 10, labelPaint);
        canvas.DrawText("N", obToOdTo.X + 8, obToOdTo.Y - 10, labelPaint);
    }
}


