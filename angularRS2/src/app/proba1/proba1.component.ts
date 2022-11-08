import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-config";

@Component({
  selector: 'app-proba1',
  templateUrl: './proba1.component.html',
  styleUrls: ['./proba1.component.css']
})
export class Proba1Component {
   drzava_podaci: any;
  odabrana_drzava: any;


  constructor(private httpKlijent: HttpClient) {

  }
  ngOnInit(): void {
    this.preuzmi_podatke();
  }

  preuzmi_podatke()
  {
    this.httpKlijent.get(MojConfig.adresa_servera + "/Drzava/GetAll").subscribe(x=>{
      this.drzava_podaci = x;
    });
  }

  getpodaci() {
    if (this.drzava_podaci == null)
      return [];
    return this.drzava_podaci;
  }

  snimi() {
    this.httpKlijent.post(MojConfig.adresa_servera + "/Drzava/Snimi/", this.odabrana_drzava).subscribe(x=>{

    });
  }
}
