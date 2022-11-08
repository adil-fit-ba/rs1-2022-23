import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-config";

@Component({
  selector: 'app-studenti',
  templateUrl: './studenti.component.html',
  styleUrls: ['./studenti.component.css']
})
export class StudentiComponent implements OnInit {

  constructor(private httpKlijent: HttpClient) {

  }
   odabrani_student:any;
  student_podaci: any;
  filter_ime: any="";

  ngOnInit(): void {
    this.preuzmi_podatke();
  }

  preuzmi_podatke()
  {
    this.httpKlijent.get(MojConfig.adresa_servera + "/Student/GetAll").subscribe(x=>{
      this.student_podaci = x;
    });
  }

  getpodaci() {
    if (this.student_podaci==null)
      return [];
    return this.student_podaci.filter((x:any)=>x.ime.toLowerCase().startsWith(this.filter_ime.toLowerCase()));
  }

  snimi() {
    this.httpKlijent.post(MojConfig.adresa_servera + "/Student/Snimi/", this.odabrani_student).subscribe(x=>{

    });
  }
}
