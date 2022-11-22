import { Component, OnInit } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {Router} from "@angular/router";
declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-studenti',
  templateUrl: './studenti.component.html',
  styleUrls: ['./studenti.component.css']
})
export class StudentiComponent implements OnInit {

  title:string = 'angularFIT2';
  ime_prezime:string = '';
  opstina: string = '';
  studentPodaci: any;
  filter_ime_prezime: boolean;
  filter_opstina: boolean;
  odabranistudent: any;
  opstinePodaci: any;


  constructor(private httpKlijent: HttpClient, private router: Router) {
  }

  fetchStudenti() :void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Student/GetAll", MojConfig.http_opcije()).subscribe(x=>{
      this.studentPodaci = x;
    });
  }

  fetchOpstine() :void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Opstina/GetByAll", MojConfig.http_opcije()).subscribe(x=>{
      this.opstinePodaci = x;
    });
  }

  ngOnInit(): void {
    this.fetchStudenti();
    this.fetchOpstine();
  }

  get_podaci_filtrirano() {
      if (this.studentPodaci == null)
        return [];

    return this.studentPodaci.filter((a:any)=>
      (!this.filter_ime_prezime ||

      (a.ime + " " +a.prezime).startsWith(this.ime_prezime)

      ||

      (a.prezime + " " +a.ime).startsWith(this.ime_prezime))

      &&
      (
        !this.filter_opstina ||
        (a.opstina_rodjenja != null && a.opstina_rodjenja.description).startsWith(this.opstina)
      )
    );
  }


  novi_student_dugme() {
    this.odabranistudent = {
      id:0,
      prezime:"",
      ime: this.ime_prezime
    };
  }

  otvori_maticnuknjigu(s: any) {
    //otvara komponentu student-maticnaknjiga te proslijeđuje id odabranog studenta
    this.router.navigate(['/student-maticnaknjiga', s.id]);
  }

}
