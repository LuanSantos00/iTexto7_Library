using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestesPdf
{
    public partial class Form1 : Form
    {
        //versão do itext7 7.1.13
         public const string PATH_FILE = @"caminhoNaMaquina\alunos.pdf";
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            PdfReader pdfReader = new PdfReader(PATH_FILE);
            PdfDocument pdfDoc = new PdfDocument(pdfReader);

            string pageContent = string.Empty;

            for (int page = 1; page <= pdfDoc.GetNumberOfPages(); page++)
            {
                ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                pageContent = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(page), strategy);
               
            }
            var teste = pageContent.Replace("\n", Environment.NewLine);
            string[] arr = teste.Split('\n');
            pdfDoc.Close();
            pdfReader.Close();
            txtResult.Text = teste;
            
            
        }

        public Task<string> LerPDF(string filePath)
        {
            txtResult.Text = "";
            return  Task.Run(() => LerDadosDoPDF(filePath));
        }
        private static string LerDadosDoPDF(string filePath)
        {   
            PdfReader pdfReader = new PdfReader(filePath);
            PdfDocument pdfDoc = new PdfDocument(pdfReader);

            string pageContent = string.Empty;

            for (int page = 1; page <= pdfDoc.GetNumberOfPages(); page++)
            {
                ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                 pageContent = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(page), strategy);
            }
            pdfDoc.Close();
            pdfReader.Close();
            

            return pageContent;
        }

    }
}
