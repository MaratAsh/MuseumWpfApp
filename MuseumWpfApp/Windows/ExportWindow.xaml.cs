using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Office.Interop.Word;

namespace MuseumWpfApp.Windows
{
    /// <summary>
    /// Interaction logic for ExportWindow.xaml
    /// </summary>
    public partial class ExportWindow : System.Windows.Window
    {
        museumEntities _context;
        public ExportWindow()
        {
            InitializeComponent();
            _context = new museumEntities();
        }

        private void ExportBtn_Click(object sender, RoutedEventArgs e)
        {
            if (sender.GetType().Name != "Button")
                return;
            Button button = (Button)sender;
            var app = new Microsoft.Office.Interop.Word.Application();
            Document document = app.Documents.Add();
            Paragraph header = document.Paragraphs.Add();
            header.Range.Text = button.Content.ToString();
            header.Range.InsertParagraphAfter();

            if (button.Content.ToString() == "Items")
            {
                List<Item> items = _context.Items.ToList().OrderBy(i => i.ID).ToList();
                
                Paragraph paragraph = document.Paragraphs.Add();
                Range range = paragraph.Range;
                range.InsertParagraphAfter();
                
                Table table = document.Tables.Add(range, items.Count + 1, 5);
                table.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
                table.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;
                Row row = table.Rows[1];
                row.Cells[1].Range.Text = "ID";
                row.Cells[2].Range.Text = "Title";
                row.Cells[3].Range.Text = "Creation Date";
                row.Cells[4].Range.Text = "Date Accuracy";
                row.Cells[5].Range.Text = "Author";
                row.Alignment = WdRowAlignment.wdAlignRowCenter;
                for (int i = 0; i < items.Count(); i++)
                {
                    Item item = items[i];
                    row = table.Rows[i + 2];
                    row.Cells[1].Range.Text = item.ID.ToString();
                    row.Cells[2].Range.Text = item.title.ToString();
                    row.Cells[3].Range.Text = item.creation_date.ToString();
                    row.Cells[4].Range.Text = (item.creation_date_accuracy ? "Yes" : "No");
                    row.Cells[5].Range.Text = String.Format("{0} {1}", item.Author.lastname, item.Author.firstname);
                }
            }
            app.Visible = true;
            String path = FileName.Text;
            if (!path.Contains(":\\"))
                path = System.IO.Directory.GetCurrentDirectory() + "\\" + path;
            document.SaveAs2(path, WdExportFormat.wdExportFormatPDF);
        }

        private void FileNameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FileName == null || FileNameTB == null)
                return;
            FileName.Text = String.Format("{0}.pdf", FileNameTB.Text);
        }
    }
}
