import {Component, OnInit} from '@angular/core';
import {MojConfig} from "./moj-config";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'angularRS4';

  ime = "Adil";
  brojac=0;

  odabrani_student:any;

  constructor(private httpKlijent: HttpClient) {
  }

  niz:string[]=['jedan', 'dva', 'tri', 'četiri'];
  student_podaci: any;
  filter_ime: any="";

  f1()
  {
    setInterval(()=>{
      this.brojac++;
    }, 1000);
  }

  jel_vidljivo() {
    return this.ime.length>3;
  }

  stil_za_ime() {
    if (this.ime.startsWith('A'))
      return {color:'blue', border:'2px solid'};
    else
      return {color:'red', border:'2px solid yellow'};
  }

  preuzmi_podatke()
  {
    this.httpKlijent.get(MojConfig.adresa_servera + "/Student/GetAll").subscribe(x=>{
      this.student_podaci = x;
    });

  }

  ngOnInit(): void {
    this.preuzmi_podatke();
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
