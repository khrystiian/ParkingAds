import { Component, OnInit } from '@angular/core';
import { AdService } from 'src/app/shared/services/ad.service';

@Component({
  selector: 'app-ad',
  templateUrl: './ad.component.html',
  styleUrls: ['./ad.component.css']
})
export class AdComponent implements OnInit {
  public ads: String[];

  constructor(private adService: AdService) { }

  ngOnInit() {
    debugger;
    this.adService.getAd().subscribe(data => this.ads = data);
    debugger;
  }

}
