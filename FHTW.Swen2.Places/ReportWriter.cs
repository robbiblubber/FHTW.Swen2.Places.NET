using System;

using FHTW.Swen2.Places.Model;

using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;



namespace FHTW.Swen2.Places
{
    public static class ReportWriter
    {
        public static void GeneratePlaceReport(Place place, string file)
        {
            using PdfWriter wr = new(file);
            using PdfDocument pdf = new(wr);
            using Document doc = new(pdf);

            doc.Add(new Paragraph(place.Name).SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD)).SetFontSize(14));
            doc.Add(new Paragraph(place.Description).SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA)).SetFontSize(10));

            foreach(Story i in place.Stories)
            {
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph(i.Text).SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA)).SetFontSize(10));

                foreach(string k in i.Pictures)
                {
                    try
                    {
                        doc.Add(new Image(ImageDataFactory.Create(Configuration.Instance.ImagePath.TrimEnd('\\') + '\\' + k)).ScaleToFit(300, 200));
                    }
                    catch(Exception) {}
                }
            }
        }
    }
}
