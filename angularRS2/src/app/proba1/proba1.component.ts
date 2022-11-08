import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-config";

@Component({
  selector: 'app-proba1',
  templateUrl: './proba1.component.html',
  styleUrls: ['./proba1.component.css']
})
export class Proba1Component {

  title = 'angularRS4';

  ime = "Adil";
  brojac=0;



  niz:string[]=['jedan', 'dva', 'tri', 'četiri'];

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



}
