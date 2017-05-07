import { Component } from '@angular/core';

import { AuctionService } from "../../services/auction/auction.service";


@Component({
	selector: 'home',
	templateUrl: 'home.component.html',
	styleUrls: ['home.component.css']
})
export class HomeComponent {
	private lots: any; 

	constructor(private auctionService: AuctionService) {
	}

	public ngOnInit() {
		this.auctionService.getAuctions().subscribe((response) => {
			return undefined;
		});
	}
}