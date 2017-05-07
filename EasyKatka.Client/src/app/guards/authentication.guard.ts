import { Injectable } from "@angular/core";
import {Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot} from "@angular/router";
import {Observable} from "rxjs/Rx";

import { AuthenticationService } from "../services/authentication/authentication.service";


@Injectable()
export class AuthenticationGuard implements CanActivate {
    constructor(private authenticationService: AuthenticationService, private router: Router) {}

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) : Observable<boolean> | boolean {
        if (this.authenticationService.isAuthenticated.getValue() && state.url !== '/authentication') {
            return true;
        }
        
        if (state.url === '/authentication') {
            if (this.authenticationService.isAuthenticated.getValue()) {
                this.router.navigate(['/']);
                return false;
            }

            return true;
        }

        this.router.navigate(['/not-found']);
        return false;
    }
}