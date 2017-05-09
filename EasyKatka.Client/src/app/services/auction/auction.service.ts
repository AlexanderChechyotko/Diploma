import { Injectable } from "@angular/core";

import { environment } from '../../../environments/environment'; 

import { HttpClientService } from "../http-client/http-client.service";


@Injectable()
export class AuctionService {
    constructor(private httpClientService: HttpClientService) {
    }

    public getAuctions() {
        let route = environment.apiSettings.methods.getLots;

        return this.httpClientService.get(route);
    }

    public addLot(lotForm) {
        let url = environment.apiSettings.methods.addLot;
        let body = {};
        debugger;
        return this.httpClientService.post(url, body).map((response) => {
            debugger;
        });
    }
}