﻿using System.Text;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace AISmarteasy.Core;

public static class WordprocessingDocumentEx
{
    public static void Initialize(this WordprocessingDocument wordprocessingDocument)
    {
        MainDocumentPart mainPart = wordprocessingDocument.AddMainDocumentPart();
        mainPart.Document = new Document();
        mainPart.Document.AppendChild(new Body());
    }

    public static string ReadText(this WordprocessingDocument wordprocessingDocument)
    {
        StringBuilder sb = new();

        var mainPart = wordprocessingDocument.MainDocumentPart;
        if (mainPart is null)
        {
            throw new InvalidOperationException("The main document part is missing.");
        }

        var body = mainPart.Document.Body;
        if (body is null)
        {
            throw new InvalidOperationException("The document body is missing.");
        }

        var paras = body.Descendants<Paragraph>();
        foreach (Paragraph para in paras)
        {
            sb.AppendLine(para.InnerText);
        }

        return sb.ToString();
    }

    public static void AppendText(this WordprocessingDocument wordprocessingDocument, string text)
    {
        if (text is null)
        {
            throw new ArgumentNullException(nameof(text));
        }

        MainDocumentPart? mainPart = wordprocessingDocument.MainDocumentPart;
        if (mainPart is null)
        {
            throw new InvalidOperationException("The main document part is missing.");
        }

        Body? body = mainPart.Document.Body;
        if (body is null)
        {
            throw new InvalidOperationException("The document body is missing.");
        }

        Paragraph para = body.AppendChild(new Paragraph());
        Run run = para.AppendChild(new Run());
        run.AppendChild(new Text(text));
    }
}
