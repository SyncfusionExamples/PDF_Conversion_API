import { Component } from '@angular/core';
import{HttpClient,HttpHeaders} from '@angular/common/http';
@Component({
  selector: 'app-demo-api',
  templateUrl: './demo-api.component.html',
  styleUrls: ['./demo-api.component.css']
})
export class DemoApiComponent {

  ngOnInit(): void {
  }
  private file : any;

  async FileUpload(event :any){
   debugger;
    
      this.file = event.target.files[0];
      const type = this.file.type;
      
      const formData = new FormData();
      formData.append('file', this.file);
  }
  
//Convert To PDF 
  async ConvertToPdf(buttonType: string) {
    debugger;
    let fileName:any = this.file.name.split(".");
    let saveFileName:string = fileName[0];
    const formData = new FormData();
    formData.append('file', this.file);
    let response:any;
    switch (buttonType) {
      case 'ConvertToPdf':
        
        response = await fetch("https://localhost:7019/api/Product/ConvertToPdf", {
          method: 'POST',
          body: formData
        })
        
        break;
      case 'ConvertHtmlToPdf':
        
        response = await fetch("https://localhost:7019/api/Product/HtmlToPdf", {
          method: 'POST',
          body: formData
        })
        
        break;
        case 'ConvertWordToPdf':
        response = await fetch("https://localhost:7019/api/Product/WordToPdf", {
          method: 'POST',
          body: formData
        })
  
        break;
        case 'ConvertExcelToPdf':
        response = await fetch("https://localhost:7019/api/Product/ExcelToPdf", {
          method: 'POST',
          body: formData
        })
        
        break;
        case 'ConvertPptxToPdf':
        response = await fetch("https://localhost:7019/api/Product/PptxToPdf", {
          method: 'POST',
          body: formData
        })
       
        break;
        case 'ConvertImageToPdf':
        response = await fetch("https://localhost:7019/api/Product/ImageToPdf", {
          method: 'POST',
          body: formData
        })
        
        break;
        
    }
    
 
    const arrayBuffer = await response.arrayBuffer();
    const byteArray = new Uint8Array(arrayBuffer);

    const blob = new Blob([byteArray],{type: 'application/pdf'});
    const url = URL.createObjectURL(blob);
    const link = document.createElement('a');
    link.href = url;
    link.download = saveFileName + '.pdf';
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
    debugger;
  }
}
