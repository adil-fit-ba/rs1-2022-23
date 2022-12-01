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
  novi_upis_godine: any;
  akademskegodine: any;
  maticnaknjigapodaci: any;

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

      this.fetchAkademskeGodine();
      this.fetchMaticnaKnjigaDetalji();

      //fetch detalji o studentu
        //-- upisani semestri
        //-- ocjene, uplate itd.
      //class UpisAkademskaGodina
      //studentid, akademskaGodinaid, godina_studija, cijena_skolarine, bool obnova, datum_upisazimski
    });
  }

  fetchMaticnaKnjigaDetalji() {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/MaticnaKnjiga/GetByID?studentid="+this.studentid, MojConfig.http_opcije()).subscribe(x=>{
      this.maticnaknjigapodaci = x;
    });
  }

  fetchAkademskeGodine() {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/AkademskeGodine/GetAll_ForCmb", MojConfig.http_opcije()).subscribe(x=>{
      this.akademskegodine = x;
    });
  }

  novi_zimski() {

    porukaSuccess("aaa");

    this.novi_upis_godine = {
      ocjene :0,
      godina_studija: 1,
      datum_upisa: new Date(),
      akademska_godina_id:1,
      student_id:this.studentid,
      obnova: false,
    };
  }
}
