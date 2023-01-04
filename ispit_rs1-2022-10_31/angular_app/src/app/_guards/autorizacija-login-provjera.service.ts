import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AutentifikacijaHelper} from "../_helpers/autentifikacija-helper";


@Injectable()
export class AutorizacijaLoginProvjera implements CanActivate {

    constructor(private router: Router) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {




        try {
          //nedovrseno privremeno rjesenje
          if (AutentifikacijaHelper.getLoginInfo().isLogiran) {

            let isAktiviran = AutentifikacijaHelper.getLoginInfo().autentifikacijaToken?.korisnickiNalog?.isAktiviran;

            if (!isAktiviran)
            {
              this.router.navigate(['/user-not-active']);
              return false;
            }

            return true;
          }
        }catch (e) {
        }

        // not logged in so redirect to login page with the return url
        this.router.navigate(['login'], { queryParams: { returnUrl: state.url }});
        return false;
    }
}
