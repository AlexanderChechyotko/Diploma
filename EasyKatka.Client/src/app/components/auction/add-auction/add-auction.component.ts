import { Component } from "@angular/core";

import { AuctionService } from "app/services/auction/auction.service";


@Component({
	selector: 'add-auction',
	templateUrl: 'add-auction.component.html',
	styleUrls: ['add-auction.component.scss']
})
export class AddAuctionComponent {
	lotForm;
	loading: boolean;

	constructor(private auctionService: AuctionService) {
		this.lotForm = {
			title: '',
			image: '',
			tradingStart: new Date(),
			startPrice: 0
		};

		this.loading = false;
	}

	public onAddLot() {
		this.auctionService.addLot(this.lotForm).subscribe();
	}
}