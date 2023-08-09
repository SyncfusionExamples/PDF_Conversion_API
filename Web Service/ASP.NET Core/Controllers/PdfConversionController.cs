using HarfBuzzSharp;
using SkiaSharp;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIORenderer;
using Syncfusion.Drawing;
using Syncfusion.EJ2.PdfViewer;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Presentation;
using Syncfusion.PresentationRenderer;
using Syncfusion.OCRProcessor;
using Syncfusion.XlsIO;
using Syncfusion.XlsIORenderer;
using System.IO;
using System.Drawing;
using Microsoft.AspNetCore.Html;
using System.IO.Pipes;
using Syncfusion.Pdf.Graphics.Images.Decoder;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace PDF_Conversion_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PdfConversionController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PdfConversionController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public string filePath;
        //[HttpPost("FileUpload")]

        private string FileUpload(IFormFile file)
        {

            string fileName = file.FileName;
            string directoryPath = Path.Combine(_webHostEnvironment.ContentRootPath, "uploadedFiles");
            filePath = Path.Combine(directoryPath, fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return filePath;
        }
        private IActionResult HtmlToPdf(IFormFile file)
        {
            string filePath = FileUpload(file);
            //Instantiation of BlinkConverterSettings for HTML to PDF conversion
            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
            BlinkConverterSettings blinkConverterSettings = new BlinkConverterSettings();
            htmlConverter.ConverterSettings = blinkConverterSettings;
            //Loads HTML  document
            PdfDocument pdfDocument = htmlConverter.Convert(filePath);
            //Save the converted PDF document to MemoryStream.
            MemoryStream stream = new MemoryStream();
            pdfDocument.Save(stream);
            stream.Position = 0;
            //Download PDF document in the browser.
            return File(stream, "application/pdf", "OutputFile.pdf");
        }
        private IActionResult PptxToPdf(IFormFile file)
        {
            string filePath = FileUpload(file);
            //Loads Pptx document
            IPresentation presentation = Presentation.Open(filePath);
            //Convert the PowerPoint document to PDF document.
            PdfDocument pdfDocument = PresentationToPdfConverter.Convert(presentation);
            //Save the converted PDF document to MemoryStream.
            MemoryStream stream = new MemoryStream();
            pdfDocument.Save(stream);
            stream.Position = 0;
            //Download PDF document in the browser.
            return File(stream, "application/pdf", "OutputFile.pdf");
        }
        private IActionResult WordToPdf(IFormFile file)
        {
            string filePath = FileUpload(file);
            //Loads file stream into Word document
            FileStream docStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            //Instantiation of DocIORenderer for Word to PDF conversion
            WordDocument wordDocument = new WordDocument(docStream, Syncfusion.DocIO.FormatType.Automatic);
            DocIORenderer render = new DocIORenderer();
            render.Settings.ChartRenderingOptions.ImageFormat = Syncfusion.OfficeChart.ExportImageFormat.Jpeg;
            //Converts Word document into PDF document
            PdfDocument pdfDocument = render.ConvertToPDF(wordDocument);
            render.Dispose();
            wordDocument.Dispose();
            //Saves the PDF document to MemoryStream.
            MemoryStream stream = new MemoryStream();
            pdfDocument.Save(stream);
            stream.Position = 0;
            //Download PDF document in the browser.
            return File(stream, "application/pdf", "OutputFile.pdf");
        }
        private IActionResult ExcelToPdf(IFormFile file)
        {
            string filePath = FileUpload(file);
            //Initialize ExcelEngine.
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Xlsx;
            //Loads file stream into Excel document
            FileStream excelStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            IWorkbook workbook = application.Workbooks.Open(excelStream);
            //Initialize XlsIO renderer.
            XlsIORenderer renderer = new XlsIORenderer();
            //Convert Excel document into PDF document 
            PdfDocument pdfDocument = renderer.ConvertToPDF(workbook);
            //Saves the PDF document to MemoryStream.
            MemoryStream stream = new MemoryStream();
            pdfDocument.Save(stream);
            stream.Position = 0;
            //Download PDF document in the browser.
            return File(stream, "application/pdf", "OutputFile.pdf");
        }
        private IActionResult ImageToPdf(IFormFile file)
        {
            string filePath = FileUpload(file);
            //Creating the new PDF document
            PdfDocument document = new PdfDocument();
            //Loading the image
            PdfPage page = document.Pages.Add();
            PdfGraphics graphics = page.Graphics;
            //Loading the image
            FileStream imageStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            PdfBitmap image = new PdfBitmap(imageStream);
            //Drawing image to the PDF page
            graphics.DrawImage(image, 0, 0, page.GetClientSize().Width, page.GetClientSize().Height);
            //Saves the PDF document to MemoryStream.
            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            document.Close(true);
            OCRProcessor processor = new OCRProcessor();
            //Load a PDF document stream.
            PdfLoadedDocument lDoc = new PdfLoadedDocument(stream);
            //Set OCR language to process.
            processor.Settings.Language = Languages.English;
            //Process OCR by providing the PDF document.
            processor.PerformOCR(lDoc);
            //Saves the PDF document to MemoryStream.
            lDoc.Save(stream);
            stream.Position = 0;
            //Download PDF document in the browser.
            return File(stream, "application/pdf", "OutputFile.pdf");
        }


        //Convert To PDF 
        [HttpPost("ConvertToPdf")]
        public async Task<IActionResult> ConvertToPdf(IFormFile file)
        {
            string filePath = FileUpload(file);
            IActionResult pdfDocument= null;
            //MemoryStream stream = new MemoryStream();
            string fileName = file.FileName;
            string[] fileFormat = fileName.Split(".");
            string fileFormatType = fileFormat[1];
            
            switch (fileFormatType)
            {
                case "docx":
                    pdfDocument = WordToPdf(file);
                    break;
                case "pptx":
                    pdfDocument = PptxToPdf(file);
                    break;
                case "jpg":
                case "jpeg":
                case "png":
                    pdfDocument = ImageToPdf(file);
                    break;
                case "xls":
                case "xlsx":
                    pdfDocument = ExcelToPdf(file);
                    break;
                case "html":
                    pdfDocument = HtmlToPdf(file);
                    break;
            }
            return pdfDocument;
        }

        // Convert HTML to PDF
        [HttpPost("HtmlToPdf")]
        public  IActionResult HtmlToPdfConverstion(IFormFile file)
        {
            return HtmlToPdf(file);
        }
        // Convert Pptx to PDF
        [HttpPost("PptxToPdf")]
        public IActionResult PptxToPdfConversation(IFormFile file)
        {
            return PptxToPdf(file); 
        }
        // Convert Word to PDF
        [HttpPost("WordToPdf")]
        public IActionResult WordToPdfConverstion(IFormFile file)
        {
            return WordToPdf(file);
        }
        // Convert Excel to PDF
        [HttpPost("ExcelToPdf")]
        public IActionResult ExcelToPdfConverstion(IFormFile file)
        {
            return ExcelToPdf(file);
        }
        // Convert Image to PDF
        [HttpPost("ImageToPdf")]
        public IActionResult ImageToPdfConverstion(IFormFile file)
        {
            return ImageToPdf(file);
        }
    }
}
