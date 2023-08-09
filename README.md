# PDF Conversion API
PDF Conversion API
This API illustrates how to converting various file formats like HTML file to PDF, Word file to PDF, Excel file to PDF, Presentation file to PDF and Image to PDf your Web application.

## Demo illustration

## Choose a File

1. Click the "Choose File" button to select the file you want to convert.

## Conversion Options
The following code snippet is used to convert various files to PDF in Angular framework.

### Convert to PDF
- Select any file (e.g., xls, xlsx, docx, html, jpg).
- Choose the "Convert to PDF" option.
- This help to convert Any file format to PDF.
```c#
response = await fetch("https://localhost:7019/api/PdfConversion/ConvertToPdf", {
          method: 'POST',
          body: formData
        })

```

### Excel to PDF

- Select the Excel file (e.g., xls, xlsx).
- Choose the "Convert Excel to PDF" option.
```c#
response = await fetch("https://localhost:7019/api/PdfConversion/ExcelToPdf", {
          method: 'POST',
          body: formData
        })

```

### Word to PDF

- Select the Word document.
- Choose the "Convert Word to PDF" option.
```c#
response = await fetch("https://localhost:7019/api/PdfConversion/WordToPdf", {
          method: 'POST',
          body: formData
        })

```

### Presentation to PDF

- Select the presentation file (e.g., pptx).
- Choose the "Convert Pptx to PDF" option.
```c#
response = await fetch("https://localhost:7019/api/PdfConversion/PptxToPdf", {
          method: 'POST',
          body: formData
        })

```

### HTML to PDF

- Select the HTML file.
- Choose the "Convert HtML to PDF" option.
```c#
response = await fetch("https://localhost:7019/api/PdfConversion/HtmlToPdf", {
          method: 'POST',
          body: formData
        })

```

### Image to PDF

- Select the image file (e.g., JPEG, PNG,JPG).
- Choose the "Convert Image to PDF" option.
```c#
response = await fetch("https://localhost:7019/api/PdfConversion/ImageToPdf", {
          method: 'POST',
          body: formData
        })

```

## Conclusion

By following these conversation-based options, you can easily convert various file formats to PDF in various platforms. Remember to review and save the converted PDF files in your desired location.




