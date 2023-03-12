import { Component, OnInit } from '@angular/core';
import {LoginInformacije} from "../_helpers/login-informacije";
import {AutentifikacijaHelper} from "../_helpers/autentifikacija-helper";
import {Router} from "@angular/router";

@Component({
  selector: 'app-user-not-active',
  templateUrl: './user-not-active.component.html',
  styleUrls: ['./user-not-active.component.css']
})
export class UserNotActiveComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
    let isAktiviran = AutentifikacijaHelper.getLoginInfo().autentifikacijaToken?.korisnickiNalog?.isAktiviran;

    if (isAktiviran)
    {
        this.router.navigate(['/']);
    }
  }

  loginInfo():LoginInformacije {
    return AutentifikacijaHelper.getLoginInfo();
  }
}
