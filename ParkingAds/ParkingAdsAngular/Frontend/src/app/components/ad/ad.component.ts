import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { AdService } from 'src/app/shared/services/ad.service';
import { DatePipe } from '@angular/common';

import * as jspdf from 'jspdf';  
import html2canvas from 'html2canvas';  
import { Payment } from 'src/app/shared/models/Payment';


@Component({
  selector: 'app-ad',
  templateUrl: './ad.component.html',
  styleUrls: ['./ad.component.css'],
  providers: [DatePipe]
})
export class AdComponent implements OnInit {  
  public ads: String[];
  payment: Payment;
  payments: Payment[];
  base64StringReceipt: string;
  myDate = new Date();
  
  mail: string;
  fullname: string; 
  Address: string; 
  Plocation: string; 
  Ptime: string; 
  _nrplate: string;
  datePipe: any;

  constructor(private adService: AdService) {
    
   }

  ngOnInit() {
    //debugger;
    //this.adService.getAd().subscribe(data => this.ads = data);
   // debugger;
  }
  public paymentData(fname: string, lname: string, mail: string, addr: string, ploc: string, ptid: string, nrpla: string): void{
    this.mail = mail;
    this.fullname =fname + " "+lname;
    this.Address = addr;
    this.Plocation = ploc;
    this.Ptime = ptid;
    this._nrplate = nrpla;
    this.myDate = this.datePipe.transform(this.myDate, 'yyyy-MM-dd');
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
      const newPay: Payment = { base64StringReceipt } as Payment;
      this.adService.captureScreen(newPay).subscribe(paymentObj=> this.payments.push(newPay));
    });  
  }  

}
