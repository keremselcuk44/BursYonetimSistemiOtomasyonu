-- Email sütununu Ogrenciler tablosuna ekle
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[Ogrenciler]') AND name = 'Email')
BEGIN
    ALTER TABLE [dbo].[Ogrenciler]
    ADD [Email] nvarchar(200) NOT NULL DEFAULT '';
END
GO

