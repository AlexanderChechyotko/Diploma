import { Injectable } from '@angular/core';

import { BehaviorSubject } from 'rxjs/BehaviorSubject';

import { SessionService } from "../session/session.service";
import { HttpClientService } from "../http-client/http-client.service";

import { environment } from "../../../environments/environment";


@Injectable()
export class AuthenticationService {
    public isAuthenticated: BehaviorSubject<boolean>;
    public loading: BehaviorSubject<boolean>;

    private username: string;
    private sessionKey: string;

    constructor(private sessionService: SessionService, private httpClientService: HttpClientService) {
        this.isAuthenticated = new BehaviorSubject(false);
        this.loading = new BehaviorSubject(false);
    }

    public logIn(username?: string, password?: string) {
        this.username = username;
    
        let params = new URLSearchParams();
        params.set('username', username);
        params.set('password', password);
    
        let url = environment.apiSettings.methods.logIn;

        this.loading.next(true);

        return this.httpClientService.get(url).subscribe((response) => this.handleLoginResponse(response));
    }

    public logOut() {

    }

    public signUp() {

    }

    public forgetPassword() {

    }

    private handleLoginResponse(response: any) { 
        this.isAuthenticated.next(true);
        this.loading.next(false);
    }
}