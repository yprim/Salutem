using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salutem.Views.Report
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // server folder path which is stored your PDF documents
            string pdfFileName = Request.PhysicalApplicationPath + "\\files\\" + "GenerateHTMLTOPDF.pdf";

            string imagepath = Server.MapPath("Images");

            //Create new PDF document 
            Document document = new Document(PageSize.A4, 20f, 20f, 20f, 20f);

            document.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());

            PdfWriter.GetInstance(document, new FileStream(pdfFileName, FileMode.Create));
            document.Open();

            //Se carga la imagen
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imagepath + "/r.jpg");
            image.Alignment = Element.ALIGN_CENTER;
            document.Add(image);

            //Caracteristicas de la letra
            Font arial = FontFactory.GetFont("Arial", 28, Font.BOLDITALIC, new BaseColor(50, 205, 50));
            Paragraph paragraph = new Paragraph("Events more cost one hundred dollars", arial);
            paragraph.Alignment = Element.ALIGN_CENTER;

            document.Add(paragraph);

            //Generate table
            PdfPTable tableTitles = new PdfPTable(13);
            tableTitles.HorizontalAlignment = Element.ALIGN_LEFT;
            //actual width of table in points
            tableTitles.TotalWidth = 800f;
            //fix the absolute width of the table
            tableTitles.LockedWidth = true;

            //ancho de cada cuadro en puntos
            float[] values = new float[] { 20f, 20f, 20f, 20f, 20f, 20f, 20f, 20f, 20f, 20f, 20f, 20f, 35f };
            tableTitles.SetWidths(values);
            tableTitles.SpacingBefore = 20f;

            PdfPCell cellTitles = new PdfPCell();
            cellTitles.Colspan = 2;
            cellTitles.Border = 0;
            cellTitles.HorizontalAlignment = -1;
            tableTitles.AddCell(cellTitles);

            //Nombre de las columnas
            tableTitles.AddCell(new Paragraph("Code", FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, new BaseColor(255, 140, 0))));
            tableTitles.AddCell(new Paragraph("Name", FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, new BaseColor(255, 140, 0))));
            tableTitles.AddCell(new Paragraph("Type", FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, new BaseColor(255, 140, 0))));
            tableTitles.AddCell(new Paragraph("Place", FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, new BaseColor(255, 140, 0))));
            tableTitles.AddCell(new Paragraph("Date", FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, new BaseColor(255, 140, 0))));
            tableTitles.AddCell(new Paragraph("Max persons", FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, new BaseColor(255, 140, 0))));
            tableTitles.AddCell(new Paragraph("Cost", FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, new BaseColor(255, 140, 0))));
            tableTitles.AddCell(new Paragraph("Start Time", FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, new BaseColor(255, 140, 0))));
            tableTitles.AddCell(new Paragraph("Ending Time", FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, new BaseColor(255, 140, 0))));
            tableTitles.AddCell(new Paragraph("Lucrative", FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, new BaseColor(255, 140, 0))));
            tableTitles.AddCell(new Paragraph("Description", FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, new BaseColor(255, 140, 0))));

            document.Add(tableTitles);

        
            PdfPTable table = new PdfPTable(13);
            table.HorizontalAlignment = Element.ALIGN_LEFT;
            //actual width of table in points
            table.TotalWidth = 800f;
            //fix the absolute width of the table
            table.LockedWidth = true;

            //ancho de cada cuadro en puntos
            float[] widths = new float[] { 20f, 20f, 20f, 20f, 20f, 20f, 20f, 20f, 20f, 20f, 20f, 20f, 35f };
            table.SetWidths(widths);

            //Query in database


            PdfPCell cell = new PdfPCell();
            cell.Colspan = 2;
            cell.Border = 0;
            cell.HorizontalAlignment = -1;
            table.AddCell(cell);

            table.AddCell("Code");
            table.AddCell("Name");
            table.AddCell("Type_Event");
            table.AddCell("Place_Event");
            table.AddCell("getDate");
            table.AddCell("Quantity_Persons");

            table.AddCell("Total_Cost");
            table.AddCell("Start_Time");
            table.AddCell("Ending_Time");
            table.AddCell("Lucrative");
            table.AddCell("Descriptionn");

            document.Add(table);
            //n += 1;

            document.Close();

            ShowPdf(pdfFileName);
            //}
        }

        public void ShowPdf(string filename)
        {
            //Clears all content output from Buffer Stream
            Response.ClearContent();
            //Clears all headers from Buffer Stream
            Response.ClearHeaders();
            //Gets or Sets the HTTP MIME type of the output stream
            Response.ContentType = "application/pdf";
            //Writes the content of the specified file directory to an HTTP response output stream as a file block
            Response.WriteFile(filename);
            //sends all currently buffered output to the client
            Response.Flush();
            //Clears all content output from Buffer Stream
            Response.Clear();
        }
    }
}