using Markdig;
using System.Text;

namespace ReportExporter;

public static class Program
{
    private static string HtmlTemplate(string title, string bodyHtml)
    {
        // Simple, print-friendly HTML template.
        return $@"<!doctype html>
<html lang=""tr"">
<head>
  <meta charset=""utf-8"">
  <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
  <title>{System.Net.WebUtility.HtmlEncode(title)}</title>
  <style>
    :root {{
      --fg: #111;
      --muted: #555;
      --bg: #fff;
      --border: #ddd;
      --codebg: #f6f8fa;
    }}
    html, body {{ background: var(--bg); color: var(--fg); }}
    body {{
      font-family: -apple-system, BlinkMacSystemFont, ""Segoe UI"", Roboto, Arial, ""Noto Sans"", ""Helvetica Neue"", sans-serif;
      line-height: 1.45;
      margin: 0;
    }}
    .page {{
      max-width: 900px;
      margin: 0 auto;
      padding: 32px 22px;
    }}
    h1, h2, h3, h4 {{ line-height: 1.2; }}
    h1 {{ font-size: 26px; margin: 0 0 18px; }}
    h2 {{ font-size: 20px; margin-top: 26px; border-bottom: 1px solid var(--border); padding-bottom: 6px; }}
    h3 {{ font-size: 16px; margin-top: 18px; }}
    h4 {{ font-size: 14px; margin-top: 14px; }}
    p {{ margin: 10px 0; }}
    ul, ol {{ margin: 8px 0 8px 22px; }}
    blockquote {{
      margin: 12px 0;
      padding: 10px 12px;
      border-left: 4px solid var(--border);
      color: var(--muted);
      background: #fafafa;
    }}
    code {{
      font-family: ui-monospace, SFMono-Regular, Menlo, Consolas, ""Liberation Mono"", monospace;
      background: var(--codebg);
      padding: 0 4px;
      border-radius: 4px;
    }}
    pre code {{
      display: block;
      padding: 12px;
      overflow-x: auto;
    }}
    table {{
      border-collapse: collapse;
      width: 100%;
      margin: 12px 0;
      font-size: 13px;
    }}
    th, td {{
      border: 1px solid var(--border);
      padding: 8px;
      vertical-align: top;
    }}
    th {{ background: #f3f3f3; }}
    hr {{ border: 0; border-top: 1px solid var(--border); margin: 18px 0; }}
    @media print {{
      .page {{ max-width: none; padding: 18mm 14mm; }}
      a {{ color: inherit; text-decoration: none; }}
    }}
  </style>
</head>
<body>
  <div class=""page"">
    {bodyHtml}
  </div>
</body>
</html>";
    }

    private static string WordHtmlWrapper(string title, string html)
    {
        // Word opens HTML reliably when saved as .doc (HTML-in-doc).
        // Add minimal Office namespaces.
        return $@"<html xmlns:o=""urn:schemas-microsoft-com:office:office""
xmlns:w=""urn:schemas-microsoft-com:office:word""
xmlns=""http://www.w3.org/TR/REC-html40"">
<head>
  <meta charset=""utf-8"">
  <title>{System.Net.WebUtility.HtmlEncode(title)}</title>
  <!--[if gte mso 9]><xml>
    <w:WordDocument>
      <w:View>Print</w:View>
      <w:Zoom>100</w:Zoom>
      <w:DoNotOptimizeForBrowser/>
    </w:WordDocument>
  </xml><![endif]-->
</head>
<body>
{html}
</body>
</html>";
    }

    public static int Main(string[] args)
    {
        // Usage:
        //   ReportExporter <input.md> <out.html> <out.doc>
        if (args.Length < 3)
        {
            Console.Error.WriteLine("Usage: ReportExporter <input.md> <out.html> <out.doc>");
            return 2;
        }

        var inputMd = args[0];
        var outHtml = args[1];
        var outDoc = args[2];

        var md = File.ReadAllText(inputMd, Encoding.UTF8);

        var pipeline = new MarkdownPipelineBuilder()
            .UseAdvancedExtensions()
            .Build();

        // Mermaid blocks are kept as code in HTML/Word.
        var body = Markdown.ToHtml(md, pipeline);
        var title = Path.GetFileNameWithoutExtension(inputMd);

        var html = HtmlTemplate(title, body);
        File.WriteAllText(outHtml, html, new UTF8Encoding(encoderShouldEmitUTF8Identifier: true));

        var docHtml = WordHtmlWrapper(title, html);
        File.WriteAllText(outDoc, docHtml, new UTF8Encoding(encoderShouldEmitUTF8Identifier: true));

        Console.WriteLine($"Wrote: {outHtml}");
        Console.WriteLine($"Wrote: {outDoc}");
        return 0;
    }
}


