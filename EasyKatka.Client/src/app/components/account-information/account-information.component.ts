import { Component } from '@angular/core';
import { ActivatedRoute } from "@angular/router";

import { SessionService } from "../../services/session/session.service";


@Component({
    selector: 'account-information',
    templateUrl: 'account-information.component.html',
    styleUrls: ['account-information.component.css']
})
export class AccountInformationComponent {
    id: number;
    username: string;

    constructor(private activateRoute: ActivatedRoute, private sessionService: SessionService) {
        this.id = activateRoute.snapshot.params['id'];
        this.username = 'Alexander';
    }
}