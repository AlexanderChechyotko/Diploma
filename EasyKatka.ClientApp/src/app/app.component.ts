import { Component, ViewEncapsulation } from '@angular/core';

import { AuthenticationService } from './services/authentication/authentication.service';
 
@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    encapsulation: ViewEncapsulation.None
})
export class AppComponent {
    isAuthenticated: boolean;
    
    constructor(private authenticationService: AuthenticationService) {
        this.isAuthenticated = true;
    }
 }
