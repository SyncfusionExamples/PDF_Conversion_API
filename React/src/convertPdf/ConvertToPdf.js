import axios from "axios";
import { useEffect, useState } from "react";

function ConvertToPdf() {

  const [file, setFile] = useState('')

  async function FileUpload(e) {
    debugger;
    console.log(e.target.files);
    setFile(e.target.files[0]);
    const formData = new FormData();
    formData.append('file', e.target.files[0]);
  }
 //Convert To PDF 
  async function ConvertToPdf() {
    debugger;
    try {
      const formData = new FormData();
      formData.append('file', file);
      let response = await fetch("https://localhost:7019/api/Product/ConvertToPdf", {
        method: 'POST',
        body: formData
      })
      downloadFile(response, file);
      debugger;
    } catch (error) {
      console.error(error);
    }
  }

 // Convert HTML to PDF
  async function ConvertHtmlToPdf() {
    debugger;
    try {
      const formData = new FormData();
      formData.append('file', file);
      let response = await fetch("https://localhost:7019/api/Product/HtmlToPdf", {
        method: 'POST',
        body: formData
      })
      downloadFile(response, file);
      debugger;
    } catch (error) {
      console.error(error);
    }
  }

 // Convert Word to PDF
  async function ConvertWordToPdf() {
    debugger;
    try {
      const formData = new FormData();
      formData.append('file', file);
      let response = await fetch("https://localhost:7019/api/Product/WordToPdf", {
        method: 'POST',
        body: formData
      })
      downloadFile(response, file);
      debugger;
    } catch (error) {
      console.error(error);
    }
  }

  // Convert Image to PDF
  async function ConvertImageToPdf() {
    debugger;
    try {
      const formData = new FormData();
      formData.append('file', file);
      let response = await fetch("https://localhost:7019/api/Product/ImageToPdf", {
        method: 'POST',
        body: formData
      })
      downloadFile(response, file);
      debugger;
    } catch (error) {
      console.error(error);
    }
  }

  // Convert Pptx to PDF
  async function ConvertPptxToPdf() {
    debugger;
    try {
      const formData = new FormData();
      formData.append('file', file);
      let response = await fetch("https://localhost:7019/api/Product/PptxToPdf", {
        method: 'POST',
        body: formData
      })
      downloadFile(response, file);
      debugger;
    } catch (error) {
      console.error(error);
    }
  }
 // Convert Excel to PDF
  async function ConvertExcelToPdf() {
    debugger;
    try {
      const formData = new FormData();
      formData.append('file', file);
      let response = await fetch("https://localhost:7019/api/Product/ExcelToPdf", {
        method: 'POST',
        body: formData
      })
      downloadFile(response, file);
      debugger;
    } catch (error) {
      console.error(error);
    }
  }

  async function downloadFile(response, file) {
    const fileName = file.name.split(".");
    const fileSaveName = fileName[0];
    const arrayBuffer = await response.arrayBuffer();
    const byteArray = new Uint8Array(arrayBuffer);
    const blob = new Blob([byteArray], { type: 'application/pdf' });
    const url = URL.createObjectURL(blob);
    const link = document.createElement('a');
    link.href = url;
    link.download = fileSaveName+'.pdf';
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
  }

  return (
    <div >

      <input type="file" name="file" onChange={FileUpload}></input><br></br><br></br>
      <button onClick={ConvertToPdf}>Convert to PDF</button><br></br><br></br>
      <button onClick={ConvertHtmlToPdf}>Convert HtML to PDF</button><br></br><br></br>
      <button onClick={ConvertWordToPdf}>Convert Word to PDF</button><br></br><br></br>
      <button onClick={ConvertPptxToPdf}>Convert Pptx to PDF</button><br></br><br></br>
      <button onClick={ConvertExcelToPdf}>Convert Excel to PDF</button><br></br><br></br>
      <button onClick={ConvertImageToPdf}>Convert Image to PDF</button><br></br><br></br>
      
      
    </div>
  );
}

export default ConvertToPdf;