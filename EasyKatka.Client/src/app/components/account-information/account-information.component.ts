import { Component } from '@angular/core';

import { SessionService } from "../../services/session/session.service";


@Component({
    selector: 'account-information',
    templateUrl: 'account-information.component.html',
    styleUrls: ['account-information.component.css']
})
export class AccountInformationComponent {
    username: string;

    constructor(private sessionService: SessionService) {}
}