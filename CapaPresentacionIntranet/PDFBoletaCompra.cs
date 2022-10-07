using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text.pdf;
using iTextSharp.text;
using io = System.IO;
using System.IO;
using CapaEntidad;
using CapaNegocios;
namespace CapaPresentacionIntranet
{
    public class PDFBoletaCompra
    {
        public static byte[] Generar(List<DetalleCarritosCE> listaCarritos)
        {
            byte[] fileBytes = null;
            /*string fechaSolicitud = DataDevolucion[0];
            string motivo = DataDevolucion[1];
            string montoDevolucion = DataDevolucion[2];
            string razonSocial = DataDevolucion[3];
            string numeroDocumento = DataDevolucion[4];
            string numeroCuentaBancaria = DataDevolucion[5];
            string Banco = DataDevolucion[6];*/
            string txtpath = System.Web.HttpContext.Current.Server.MapPath("~/img/logo.png");
            byte[] ImageData = File.ReadAllBytes(txtpath);
            try
            {
                using (io.MemoryStream stream = new io.MemoryStream())
                {
                    #region PDF
                    Document document = new Document(PageSize.A4);
                    PdfWriter writer = PdfWriter.GetInstance(document, stream);

                    // Add meta information to the document
                    document.AddAuthor("Perutec");
                    document.AddCreator("Comprobante Electrónico");
                    document.AddKeywords("Comprobante Electrónico");
                    document.AddTitle("Boleta");

                    // Open the document to enable you to write to the document
                    document.Open();

                    document.NewPage();

                    GenerarPDFCPE01 headerFooter = new GenerarPDFCPE01();
                    //headerFooter.FechaInicial = FechaInicial;
                    //headerFooter.FechaFinal = FechaFinal;
                    headerFooter.Logo = ImageData;
                    //headerFooter.Ruc = Ruc;
                    //headerFooter.RazonSocial = RazonSocial;
                    //headerFooter.ListCuentaDet = ListCuentaDet;
                    writer.PageEvent = headerFooter;

                    PdfContentByte cb = writer.DirectContent;
                    PdfPCell RowData = null;

                    PdfPTable table2;
                    table2 = new PdfPTable(3);
                    table2.HeaderRows = 1;
                    //table3.HeaderRows = 1;
                    table2.TotalWidth = 520f;
                    float[] widthsTable = new float[] { 8f, 10f, 10f };
                    table2.SetWidths(widthsTable);
                    table2.SpacingBefore = 60f;
                    table2.SpacingAfter = 60f;

                    iTextSharp.text.Font FontDetails = FontFactory.GetFont("Arial", 9, BaseColor.BLACK);
                    iTextSharp.text.Font FontDetailsBold = FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK);
                    //iTextSharp.text.Font FontDetailsBold = FontFactory.GetFont("Arial", 7, Font.BOLD,BaseColor.BLACK);


                    RowData = new PdfPCell(new Phrase(new Chunk("FECHA DE LA SOLICITUD", FontDetails)));

                    RowData.Border = Rectangle.NO_BORDER;
                    RowData.HorizontalAlignment = Element.ALIGN_LEFT;
                    RowData.VerticalAlignment = Element.ALIGN_MIDDLE;
                    RowData.FixedHeight = 20;
                    //RowData.Width = 20;
                    table2.AddCell(RowData);


   

                    table2.WriteSelectedRows(0, table2.Rows.Count, 30, 680, cb);
                    // Close the document, the writer and the filestream!
                    document.Close();
                    writer.Close();
                    //fs.Close();

                    fileBytes = stream.ToArray();
                    #endregion PDF
                }
            }
            catch (Exception ex)
            {
                //Functions.SaveException(ex, "GenerarPDFDocumento");
            }

            return fileBytes;
        }
        class GenerarPDFCPE01 : PdfPageEventHelper
        {
            public byte[] Logo { get; set; }
            public string[] ListCuentaDet { get; set; }

            public override void OnEndPage(PdfWriter writer, Document document)
            {
                //BaseFont f_cb = BaseFont.CreateFont(FontFactory.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                PdfContentByte cb = writer.DirectContent;
                #region Header
                PdfPCell RowData = null;

                PdfPTable table = new PdfPTable(3);
                table.HeaderRows = 1;

                table.TotalWidth = 420f;

                //relative col widths in proportions - 1/3 and 2/3
                float[] widths = new float[] { 55f, 150f,50f };//, 55f, 68f, 80f };
                table.SetWidths(widths);
                table.DefaultCell.Border = Rectangle.NO_BORDER;

                ////leave a gap before and after the table
                table.SpacingBefore = 20f;
                table.SpacingAfter = 20f;

                iTextSharp.text.Font FontDetailsHeader = FontFactory.GetFont("Arial", 6, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                iTextSharp.text.Font FontDetailTittle = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

                iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(Logo);
                jpg.ScaleAbsolute(120, 80);
                RowData = new PdfPCell(jpg);
                RowData.Border = Rectangle.NO_BORDER;
                RowData.HorizontalAlignment = Element.ALIGN_LEFT;
                RowData.VerticalAlignment = Element.ALIGN_MIDDLE;
                RowData.FixedHeight = 40;
                table.AddCell(RowData);

                RowData = new PdfPCell(new Phrase(new Chunk("BOLETA DE COMPRA", FontDetailTittle)));

                RowData.Border = Rectangle.NO_BORDER;
                RowData.HorizontalAlignment = Element.ALIGN_CENTER;
                RowData.VerticalAlignment = Element.ALIGN_MIDDLE;
                RowData.FixedHeight = 20;
                table.AddCell(RowData);

                RowData = new PdfPCell(new Phrase(new Chunk(DateTime.Now.ToString("dd/MM/yyyy"), FontDetailTittle)));

                RowData.Border = Rectangle.NO_BORDER;
                RowData.HorizontalAlignment = Element.ALIGN_CENTER;
                RowData.VerticalAlignment = Element.ALIGN_MIDDLE;
                RowData.FixedHeight = 20;
                table.AddCell(RowData);


                table.WriteSelectedRows(0, table.Rows.Count, 30, 805, cb);
                #endregion Header

            }
        }
    }
}
