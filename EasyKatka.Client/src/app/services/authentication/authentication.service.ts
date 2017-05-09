import { Injectable } from '@angular/core';
import { Router } from "@angular/router";

import { BehaviorSubject } from 'rxjs/BehaviorSubject';

import { SessionService } from "../session/session.service";
import { HttpClientService } from "../http-client/http-client.service";

import { environment } from "../../../environments/environment";
import { Http } from "@angular/http";


@Injectable()
export class AuthenticationService {
    public isAuthenticated: BehaviorSubject<boolean>;
    public loading: BehaviorSubject<boolean>;

    private username: string;
    private sessionKey: string;

    constructor(
        private sessionService: SessionService,
        private httpClientService: HttpClientService,
        private router: Router,
        private http: Http
    ) {
        if (localStorage.getItem('currentUser')) {
            this.isAuthenticated = new BehaviorSubject(true);
        } else {
            this.isAuthenticated = new BehaviorSubject(false);
        }

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
        localStorage.removeItem('currentUser');
        this.isAuthenticated.next(false);
    }

    public register(form) {
        let body = JSON.stringify({model: 'sahsa'});

        let url = environment.apiSettings.methods.register;

        return this.httpClientService.post(url, JSON.stringify({id: 12}));
    }

    public forgetPassword() {

    }

    private handleLoginResponse(response: any) { 
        localStorage.setItem('currentUser', 'Alexander');

        this.isAuthenticated.next(true);
        this.loading.next(false);
        this.router.navigate(['/']);
    }
}