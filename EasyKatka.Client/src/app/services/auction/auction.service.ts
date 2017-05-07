import { Injectable } from "@angular/core";

import { environment } from '../../../environments/environment'; 

import { HttpClientService } from "../http-client/http-client.service";

import { Http } from '@angular/http';

@Injectable()
export class AuctionService {
    constructor(private httpClientService: HttpClientService, private http: Http) {
    }

    public getAuctions() {
        let route = environment.apiSettings.methods.getLots;

        return this.httpClientService.get(route);
    }
}