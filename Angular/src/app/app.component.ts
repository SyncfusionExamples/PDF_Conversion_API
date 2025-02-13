import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { DemoApiComponent } from "./demo-api/demo-api.component";

@Component({
  selector: 'app-root',
  imports: [DemoApiComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'my-web-api';
}
