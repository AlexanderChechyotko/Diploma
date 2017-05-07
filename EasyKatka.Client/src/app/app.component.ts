import { Component, ViewEncapsulation } from '@angular/core';

import { AuthenticationService } from "./services/authentication/authentication.service";


@Component({
	selector: 'app',
	templateUrl: './app.component.html',
	styleUrls: ['./app.component.scss']
})
export class AppComponent {
    isAuthenticated: boolean;
    
    constructor(private authenticationService: AuthenticationService) {
        this.authenticationService.isAuthenticated.subscribe((status: boolean) => this.isAuthenticated = status);
    }
}
