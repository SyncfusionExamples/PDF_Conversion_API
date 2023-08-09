<script>
export default{
  data(){
    return {
      file :null
    };
  },
  methods:{
    
    uploadFile(event){
      debugger;
      const formData = new FormData();
      this.file = event.target.files[0];
      formData.append('file', this.file);
    },

    async ConvertToPdf(){
      debugger;
      const formData = new FormData();
      formData.append('file', this.file);
      let response = await fetch("https://localhost:7019/api/PdfConversion/ConvertToPdf", {
        method: 'POST',
        body: formData
      })
      this.downloadFile(response, this.file);
    },

    async ConvertHtmlToPdf(){
      debugger;
      const formData = new FormData();
      formData.append('file', this.file);
      let response = await fetch("https://localhost:7019/api/PdfConversion/HtmlToPdf", {
        method: 'POST',
        body: formData
      })
      this.downloadFile(response, this.file);
    },

    async ConvertWordToPdf(){
      debugger;
      const formData = new FormData();
      formData.append('file', this.file);
      let response = await fetch("https://localhost:7019/api/PdfConversion/WordToPdf", {
        method: 'POST',
        body: formData
      })
      this.downloadFile(response, this.file);
    },

    async ConvertImageToPdf(){
      debugger;
      const formData = new FormData();
      formData.append('file', this.file);
      let response = await fetch("https://localhost:7019/api/PdfConversion/ImageToPdf", {
        method: 'POST',
        body: formData
      })
      this.downloadFile(response, this.file);
    },

    async ConvertPptxToPdf(){
      debugger;
      const formData = new FormData();
      formData.append('file', this.file);
      let response = await fetch("https://localhost:7019/api/PdfConversion/PptxToPdf", {
        method: 'POST',
        body: formData
      })
      this.downloadFile(response, this.file);
      debugger;
    },

    async ConvertExcelToPdf(){
      debugger;
      const formData = new FormData();
      formData.append('file', this.file);
      let response = await fetch("https://localhost:7019/api/PdfConversion/ExcelToPdf", {
        method: 'POST',
        body: formData
      })
      this.downloadFile(response, this.file);
      debugger;
    },

    async downloadFile(response, file) {
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
  }
};

  
 

</script>

<template>
  <div class="greetings">
    <input type="file" @change="uploadFile" /><br><br>
    <button @click="ConvertToPdf">Convert to PDF</button><br><br>
    <button @click="ConvertHtmlToPdf">Convert HtML to PDF</button><br><br>
    <button @click="ConvertWordToPdf">Convert Word to PDF</button><br><br>
    <button @click="ConvertPptxToPdf">Convert Pptx to PDF</button><br><br>
    <button @click="ConvertExcelToPdf">Convert Excel to PDF</button><br><br>
    <button @click="ConvertImageToPdf">Convert Image to PDF</button><br><br>
    
    
  </div>
</template>

<style scoped>

</style>
