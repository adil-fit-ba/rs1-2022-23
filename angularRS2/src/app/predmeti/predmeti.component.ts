import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-config";

@Component({
  selector: 'app-predmeti',
  templateUrl: './predmeti.component.html',
  styleUrls: ['./predmeti.component.css']
})
export class PredmetiComponent implements OnInit {
  podaci: any;
  odabrani_predmet: any;

  getpodaci()
  {
    if (this.podaci==null)
      return [];
    return this.podaci;
  }

  constructor(private httpKlijent: HttpClient) {
  }

  ngOnInit(): void {
    this.httpKlijent.get(MojConfig.adresa_servera + "/Predmet/GetAll").subscribe(((x:any)=>{
        this.podaci = x;
    }));
  }

  snimi() {
    this.httpKlijent.post(MojConfig.adresa_servera + "/Predmet/Snimi", this.odabrani_predmet).subscribe(((x:any)=>{
      
    }));
  }
}
