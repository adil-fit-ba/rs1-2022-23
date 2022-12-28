import { Component, OnInit } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {Router} from "@angular/router";
import {StudentGetallVM} from "./student-getall-vm";
import {SignalRProba2Servis} from "../_servisi/signal-r-proba2-servis.service";
declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-studenti',
  templateUrl: './studenti.component.html',
  styleUrls: ['./studenti.component.css']
})
export class StudentiComponent implements OnInit {

  title:string = 'angularFIT2';

  opstina: string = '';
  studentPodaci: StudentGetallVM[] = [];
  filter_ime_prezime: boolean=false;
  filter_opstina: boolean=false;
  odabranistudent?: StudentGetallVM | null;
  opstinePodaci: any;
  predmetPodaci: any;


  constructor(private httpKlijent: HttpClient, private router: Router, public proba2Servis : SignalRProba2Servis) {
    proba2Servis.otvoriKanalWebSocket();
  }

  fetchStudenti() :void
  {
    this.httpKlijent.get<StudentGetallVM>(MojConfig.adresa_servera+ "/Student/GetAll", MojConfig.http_opcije()).subscribe((x:any)=>{
      this.studentPodaci = x;
    });
  }

  fetchOpstine() :void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Opstina/GetByAll", MojConfig.http_opcije()).subscribe(x=>{
      this.opstinePodaci = x;
    });
  }

  fetchPredmeti() :void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Predmet/GetAll", MojConfig.http_opcije()).subscribe(x=>{
      this.predmetPodaci = x;
    });
  }


  ngOnInit(): void {
    this.fetchStudenti();
    this.fetchOpstine();
    this.fetchPredmeti();
  }

  get_podaci_filtrirano() {
      if (this.studentPodaci == null)
        return [];

    return this.studentPodaci.filter((a:any)=>
      (!this.filter_ime_prezime ||

      (a.ime + " " +a.prezime).startsWith(this.proba2Servis.ime_prezime)

      ||

      (a.prezime + " " +a.ime).startsWith(this.proba2Servis.ime_prezime))

      &&
      (
        !this.filter_opstina ||
        (a.opstina_rodjenja != null && a.opstina_rodjenja.description).startsWith(this.opstina)
      )
    );
  }

  obrisibutton1(s: any) {
    //kompletan objekat "s" se salje kroz body... post ima 3 parametra
    this.httpKlijent.post(`${MojConfig.adresa_servera}/Student/Obrisi1`, s, MojConfig.http_opcije()).subscribe(x=>{
      this.fetchStudenti();
    });
  }

  obrisibutton2(s: any) {
    //int student id se salje kroz url
    this.httpKlijent.post(`${MojConfig.adresa_servera}/Student/Obrisi2/${s.id}`, MojConfig.http_opcije()).subscribe(x=>{
      this.fetchStudenti();
    });
  }

  novi_student_dugme() {
    this.odabranistudent = {
      id: 0,
      prezime: "",
      ime: this.proba2Servis.ime_prezime,
      opstina_rodjenja_opis: "",
      broj_indeksa: "",
      vrijeme_dodavanja: "",
      drzava_rodjenja_opis: "",
      opstina_rodjenja_id: 5,
      slika_korisnika_nova_base64: "",
      slika_korisnika_postojeca_base64_FS: "",
      slika_korisnika_postojeca_base64_DB: "",
      omiljenipredmeti: []
    }
    ;
  }

  otvori_maticnuknjigu(s: StudentGetallVM) {
    //
    this.router.navigate(['/student-maticnaknjiga', s.id]);
  }

  snimi_dugme() {

    this.odabranistudent!.omiljenipredmeti = this.predmetPodaci.filter((a:any)=>a.jel_selektovan).map((p:any)=>p.id);
    this.httpKlijent.post(`${MojConfig.adresa_servera}/Student/Snimi`, this.odabranistudent, MojConfig.http_opcije()).subscribe(x=>{
      this.fetchStudenti();
      this.odabranistudent=null;
    });
  }

  randomIntFromInterval(min:number, max:number) { // min and max included
    return Math.floor(Math.random() * (max - min + 1) + min)
  }

  get_slika_novi_request_FS(s: StudentGetallVM) {
     return `${MojConfig.adresa_servera}/Student/GetSlikaFS/${s.id}`;
  }

  get_slika_novi_request_DB(s: StudentGetallVM) {
    return `${MojConfig.adresa_servera}/Student/GetSlikaDB/${s.id}`;
  }

  get_slika_base64_FS(s: StudentGetallVM) {
    return "data:image/png;base64,"+ s.slika_korisnika_postojeca_base64_FS;
  }

  get_slika_base64_DB(s: StudentGetallVM) {
    return "data:image/png;base64,"+ s.slika_korisnika_postojeca_base64_DB;
  }

  generisi_preview() {
    // @ts-ignore
    var file = document.getElementById("slika-input").files[0];
    if (file) {
      var reader = new FileReader();
      let this2=this;
      reader.onload = function () {
        this2.odabranistudent!.slika_korisnika_nova_base64 = reader.result?.toString();
      }

      reader.readAsDataURL(file);
    }
  }

}
