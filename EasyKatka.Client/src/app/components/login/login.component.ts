import { Component } from '@angular/core';

import { AuthenticationService } from "../../services/authentication/authentication.service";


@Component({
	selector: 'login',
	templateUrl: 'login.component.html',
	styleUrls: ['login.component.scss']
})
export class LoginComponent {
	loginForm;
	loading: boolean;

	constructor(private authenticationService: AuthenticationService) {
		this.loginForm = {
    		username: '',
    		password: ''
    	};

		this.authenticationService.loading.subscribe((status: boolean) => this.loading = status);
	}

	public onLogin() {
		this.authenticationService.logIn(this.loginForm.username, this.loginForm.password);
	}
}