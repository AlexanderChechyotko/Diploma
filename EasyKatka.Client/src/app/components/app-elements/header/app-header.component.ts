import { Component, Input } from '@angular/core';

import { SessionService } from "../../../services/session/session.service";


@Component({
    selector: 'app-header',
    templateUrl: 'app-header.component.html',
    styleUrls: ['app-header.component.css']
})
export class AppHeaderComponent {
    @Input() isAuthenticated: boolean;

    constructor(private sessionService: SessionService) {}
}