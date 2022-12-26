import { Component } from '@angular/core';
import {MojConfig} from "./moj-config";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {AutentifikacijaHelper} from "./_helpers/autentifikacija-helper";
import {LoginInformacije} from "./_helpers/login-informacije";
import {SignalRProba2Servis} from "./_servisi/signal-r-proba2-servis.service";
import {SignalRProba1Servis} from "./_servisi/signal-r-proba1-servis.service";

declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  constructor(private httpKlijent: HttpClient, private router: Router,
              public  probaServis: SignalRProba1Servis) {
    probaServis.otvoriKanalWebSocket();
  }

  logoutButton() {

    let token = MojConfig.http_opcije();
    AutentifikacijaHelper.setLoginInfo(null);

    this.httpKlijent.post(MojConfig.adresa_servera + "/Autentifikacija/Logout/", null, token)
      .subscribe((x: any) => {

        porukaSuccess("Logout uspješan");
      });

    this.router.navigateByUrl("/login");
  }

  loginInfo():LoginInformacije {
    return AutentifikacijaHelper.getLoginInfo();
  }
}
