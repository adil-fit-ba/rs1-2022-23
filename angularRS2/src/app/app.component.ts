import {Component, OnInit} from '@angular/core';
import {MojConfig} from "./moj-config";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  proba1: boolean=false;
  studenti: boolean=false;
  ngOnInit(): void {
    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);

    const putanja = urlParams.get('putanja')

    if (putanja == "studenti")
      this.studenti=true;

    if (putanja == "proba1")
      this.proba1=true;
  }


  buttonProba1() {
    this.proba1 = true;
    this.studenti = false;
    history.replaceState( {} , 'proba1', '/?putanja=proba1' );
  }

  buttonStudenti() {
    this.proba1 = false;
    this.studenti = true;
    history.replaceState( {} , 'studenti', '/?putanja=studenti' );
  }
}
