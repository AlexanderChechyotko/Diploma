import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

import { SessionService } from '../session/session.service';
import { environment } from '../../../environments/environment';


@Injectable()
export class HttpClientService {
	private host = environment.apiSettings.baseUrl;

	constructor(private http: Http) {}

	public get(route: string) {
		return this.http.get(`${this.host}${route}`);
	}
}