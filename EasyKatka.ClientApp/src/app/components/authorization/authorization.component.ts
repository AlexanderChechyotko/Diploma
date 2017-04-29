import { Component } from '@angular/core';

import { SessionService } from '../../services/session/session.service'


@Component({
    selector: 'authorization',
    templateUrl: 'authorization.component.html',
    styleUrls: ['authorization.component.css']
})
export class AuthorizationComponent {
    constructor(private sessionService: SessionService) {

    }
}