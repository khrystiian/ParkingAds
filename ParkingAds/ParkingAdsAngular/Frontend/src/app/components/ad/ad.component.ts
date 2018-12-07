import { Component, OnInit } from '@angular/core';
import { AdService } from 'src/app/shared/services/ad.service';

import * as jspdf from 'jspdf';  
import html2canvas from 'html2canvas';  
import { Payment } from 'src/app/shared/models/Payment';


@Component({
  selector: 'app-ad',
  templateUrl: './ad.component.html',
  styleUrls: ['./ad.component.css']
})
export class AdComponent implements OnInit {
  
  public ads: String[];
  payment: Payment;
  payments: Payment[];
  base64StringReceipt: string
  

  constructor(private adService: AdService) { }

  ngOnInit() {
    //debugger;
    //this.adService.getAd().subscribe(data => this.ads = data);
   // debugger;
  }

  public captureScreen(base64StringReceipt: string)  
  {  
    var data = document.getElementById('contentToConvert');  
    html2canvas(data).then(canvas => {  
      var imgWidth = 208;   
      var pageHeight = 295;    
      var imgHeight = canvas.height * imgWidth / canvas.width;  
      var heightLeft = imgHeight;  
  
      debugger;
      
      base64StringReceipt = canvas.toDataURL();
      const newHero: Payment = { base64StringReceipt } as Payment;
      this.adService.captureScreen(newHero).subscribe(paymentObj=> this.payments.push(newHero));

      //To save as pdf
      // let pdf = new jspdf('p', 'mm', 'a4');
      // var position = 0;  
      // pdf.addImage(base64String, 'PNG', 0, position, imgWidth, imgHeight)  
      // pdf.save('Receipt.pdf');  
    });  
  }  
}
