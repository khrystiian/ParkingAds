import { Component, OnInit } from '@angular/core';
import { AdService } from 'src/app/shared/services/ad.service';

import * as jspdf from 'jspdf';  
  
import html2canvas from 'html2canvas';  

@Component({
  selector: 'app-ad',
  templateUrl: './ad.component.html',
  styleUrls: ['./ad.component.css']
})
export class AdComponent implements OnInit {
  public ads: String[];

  constructor(private adService: AdService) { }

  ngOnInit() {
    //debugger;
    //this.adService.getAd().subscribe(data => this.ads = data);
   // debugger;
  }

  public captureScreen()  
  {  
    var data = document.getElementById('contentToConvert');  
    html2canvas(data).then(canvas => {  
      var imgWidth = 208;   
      var pageHeight = 295;    
      var imgHeight = canvas.height * imgWidth / canvas.width;  
      var heightLeft = imgHeight;  
  
      debugger;
      const contentDataURL = canvas.toDataURL()  
      //To save as pdf
      // let pdf = new jspdf('p', 'mm', 'a4'); // A4 size page of PDF  
      // var position = 0;  
      // pdf.addImage(contentDataURL, 'PNG', 0, position, imgWidth, imgHeight)  
      // pdf.save('MYPdf.pdf'); // Generated PDF   
    });  
  }  
}
