import { Component, ViewEncapsulation } from '@angular/core';

import { AuthenticationService } from './services/authentication/authentication.service';
 
@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    encapsulation: ViewEncapsulation.None
})
export class AppComponent {
    title = 'EasyKatka';
    componentSelectorActive: boolean;
    isAuthenticated: boolean;
    uiIsBlocked = false;
    
    constructor(private authenticationService: AuthenticationService) {
        this.componentSelectorActive = false;
        this.isAuthenticated = true;
    }
 }
