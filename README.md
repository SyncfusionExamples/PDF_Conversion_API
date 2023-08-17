# PDF Conversion API
The PDF Conversion API seamlessly transforms diverse file formats into PDFs within your web application. It covers HTML, Word, Excel, Presentation, and image files, enhancing compatibility and simplifying document management.

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

By incorporating the PDF Conversion API into your web application, you empower your platform with the capability to effortlessly bridge the gap between different file formats, ensuring seamless compatibility and accessibility for your users. This versatile API acts as a catalyst, streamlining the process of converting content from HTML, Word, Excel, Presentation, and image files into the standardized PDF format.




