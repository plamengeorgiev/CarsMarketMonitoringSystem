namespace CarsMarketMonitoringSystem.Data.PdfReporter
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;

    using iTextSharp.text;
    using iTextSharp.text.pdf;

    using CarsMarketMonitoringSystem.Models;

    public class PdfReporter
    {
        private CarsMarketDbContext database;
        private PdfPCell mainTitleCell;
        private PdfPCell headerCell;
        private PdfPCell normalCell;
        private iTextSharp.text.Font titleFont;
        private iTextSharp.text.Font tableTitleFont;
        private iTextSharp.text.Font headFont;
        private iTextSharp.text.Font normalFont;

        public PdfReporter(CarsMarketDbContext database)
        {
            this.database = database;
            this.FormatCells();
            this.SetFonts();
        }

        private void SetFonts()
        {
            this.titleFont = FontFactory.GetFont("Arial", 20, iTextSharp.text.Font.BOLD);
            this.tableTitleFont = FontFactory.GetFont("Verdana", 16, iTextSharp.text.Font.BOLDITALIC);
            this.headFont = FontFactory.GetFont("Verdana", 14, iTextSharp.text.Font.BOLD);
            this.normalFont = FontFactory.GetFont("Verdana", 12);
        }

        private void FormatCells()
        {
            this.mainTitleCell = new PdfPCell();
            this.mainTitleCell.BorderWidth = 2;
            this.mainTitleCell.Colspan = 4;
            this.mainTitleCell.Padding = 5;
            this.mainTitleCell.HorizontalAlignment = 1;
            this.mainTitleCell.BackgroundColor = new BaseColor(Color.LightGray);

            this.headerCell = new PdfPCell();
            this.headerCell.Padding = 5;
            this.headerCell.HorizontalAlignment = 1;

            this.normalCell = new PdfPCell();
            this.normalCell.HorizontalAlignment = 1;
        }

        public void GenerateReportsForMonth(int year, int month)
        {
            var salesForMonth = this.database.Sales
                .Where(s => s.Date.Year == year && s.Date.Month == month)
                .GroupBy(s => s.SellerId).ToList();

            FileStream fs = new FileStream(
                string.Format("../../Generated-reports/Sales-Reports_{0}-{1}.pdf", month, year),
                FileMode.Create, FileAccess.Write, FileShare.None);
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();

            var titleParagraph = new Paragraph(
                string.Format("Sales Reports {0}/{1}", month, year), this.titleFont);
            titleParagraph.Alignment = 1;
            doc.Add(titleParagraph);
            doc.Add(new Paragraph(" "));
            foreach (var sellerSales in salesForMonth)
            {
                CreatePdf(year, month, sellerSales, doc);
            }

            doc.Close();
        }

        private void CreatePdf(int year, int month, IGrouping<int, Sale> sellerSales, Document doc)
        {
            string saleReportName = string.Format(
                "Report by {0}.", sellerSales.First().Seller.Name);

            PdfPTable table = new PdfPTable(4);
            AddHeaderCells(saleReportName, table);
            List<string> saleReportLines = new List<string>();
            decimal totalSum = 0;
            foreach (var sale in sellerSales)
            {
                this.normalCell.Phrase = new Phrase(sale.Car.Manufacturer.Name, this.normalFont);
                table.AddCell(this.normalCell);
                this.normalCell.Phrase = new Phrase(sale.Car.Model, this.normalFont);
                table.AddCell(this.normalCell);
                this.normalCell.Phrase = new Phrase(sale.Date.ToShortDateString(), this.normalFont);
                table.AddCell(this.normalCell);
                this.normalCell.Phrase = new Phrase(sale.Price.ToString(), this.normalFont);
                table.AddCell(this.normalCell);
                totalSum += sale.Price;
            }

            doc.Add(table);
            doc.Add(new Paragraph(" "));
        }

        private void AddHeaderCells(string saleReportName, PdfPTable table)
        {
            this.mainTitleCell.Phrase = new Phrase(saleReportName, this.tableTitleFont);
            table.AddCell(mainTitleCell);

            this.headerCell.Phrase = new Phrase("Manufacturer", this.headFont);
            table.AddCell(this.headerCell);
            this.headerCell.Phrase = new Phrase("Model", this.headFont);
            table.AddCell(this.headerCell);
            this.headerCell.Phrase = new Phrase("Date", this.headFont);
            table.AddCell(this.headerCell);
            this.headerCell.Phrase = new Phrase("Price", this.headFont);
            table.AddCell(this.headerCell);
        }

    }
}
