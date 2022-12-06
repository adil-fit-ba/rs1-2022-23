import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title:string = 'angularRS1';

  ime:string="Razvoj";

  dugme1() {
    this.ime += " a"
  }

  podaci=[];

  odabraniPredmet:any;


  preuzmi() {

    let url = "https://localhost:7174/Predmet/GetAll?f=" + this.ime;

    fetch(url)
      .then(
        r => {
          if (r.status !== 200) {
            alert("Server javlja grešku: " + r.status);
            return;
          }

          r.json().then(t => {

            this.podaci = t;
          });
        }
      )
      .catch(
        err => {
          alert("Greška u komunikaciji sa serverom: " + err);
        }
      );
  }
}
