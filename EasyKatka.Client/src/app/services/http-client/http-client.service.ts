import { Injectable } from '@angular/core';
import { Http, XHRBackend, RequestOptions, Request, RequestOptionsArgs, Response } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

import { SessionService } from '../session/session.service';
import { environment } from '../../../environments/environment';

@Injectable()
export class HttpClientService extends Http {
  constructor(backend: XHRBackend,
              options: RequestOptions,
              private sessionService: SessionService) {
    super(backend, options);
  }

  request(request: Request, options?: RequestOptionsArgs): Observable<Response> {
    request.url = environment.apiSettings.baseUrl + request.url;
    let sessionRequestOptions = null;
    request.headers = sessionRequestOptions ? sessionRequestOptions.headers : null;

    return super.request(request, options).map(this.handleSucces).catch(this.handleError);
  }

  private handleSucces(response: Response) {
    return response.json();
  }

  private handleError(error: any) {
    return Observable.throw(error);
  }
}
