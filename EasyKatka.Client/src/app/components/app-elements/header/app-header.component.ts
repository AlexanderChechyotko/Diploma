import { Component, Input } from '@angular/core';

import { SessionService } from "../../../services/session/session.service";
import { AuthenticationService } from "../../../services/authentication/authentication.service";


@Component({
    selector: 'app-header',
    templateUrl: 'app-header.component.html',
    styleUrls: ['app-header.component.scss']
})
export class AppHeaderComponent {
    @Input() isAuthenticated: boolean;

    constructor(private sessionService: SessionService, private authenticationService: AuthenticationService) {}

    public logoutHandler(): void {
        this.authenticationService.logOut();
    }
}