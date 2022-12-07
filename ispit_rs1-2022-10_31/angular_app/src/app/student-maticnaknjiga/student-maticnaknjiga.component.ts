import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";

declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-student-maticnaknjiga',
  templateUrl: './student-maticnaknjiga.component.html',
  styleUrls: ['./student-maticnaknjiga.component.css']
})
export class StudentMaticnaknjigaComponent implements OnInit {
   studentid: number;

  constructor(private httpKlijent: HttpClient, private route: ActivatedRoute) {}

  ovjeriLjetni(s:any) {

  }

  upisLjetni(s:any) {

  }

  ovjeriZimski(s:any) {

  }

  ngOnInit(): void {
    //preuzima ID studenta iz URL query parametra
    this.route.params.subscribe(params => {
      this.studentid = +params['studentidbroj']; // (+) converts string 'id' to a number

      //fetch detalji o studentu
        //-- upisani semestri
        //-- ocjene, uplate itd.
      //class UpisAkademskaGodina
      //studentid, akademskaGodinaid, godina_studija, cijena_skolarine, bool obnova, datum_upisazimski
    });
  }



}
