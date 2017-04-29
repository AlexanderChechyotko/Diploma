import { Injectable } from '@angular/core'


@Injectable()
export class AuthenticationService {
    public isAuthenticated: boolean;

    constructor() {
        this.isAuthenticated = false;
    }
}