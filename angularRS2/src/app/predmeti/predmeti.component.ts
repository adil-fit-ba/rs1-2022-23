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
  filter_ime="";

  getpodaci()
  {
    if (this.podaci==null)
      return [];
    return this.podaci.filter((x:any)=>x.naziv.toLowerCase().startsWith(this.filter_ime.toLowerCase()));
  }

  constructor(private httpKlijent: HttpClient) {
  }

  ngOnInit(): void {
 this.preuzmiPodatke();
  }

  snimi() {
    this.httpKlijent.post(MojConfig.adresa_servera + "/Predmet/Snimi", this.odabrani_predmet).subscribe(((x:any)=>{
      this.preuzmiPodatke();
      this.noviPredmet();
    }));
  }

  noviPredmet() {
    this.odabrani_predmet = {
       id:0,
       naziv:'',
      ects:5,
      skracenica:''
    }
  }

  private preuzmiPodatke() {
    this.httpKlijent.get(MojConfig.adresa_servera + "/Predmet/GetAll").subscribe(((x:any)=>{
      this.podaci = x;
    }));
  }
}
