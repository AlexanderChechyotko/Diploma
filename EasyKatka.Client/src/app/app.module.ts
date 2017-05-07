import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule, Routes } from '@angular/router';

// Components
import { AppComponent } from './app.component';
import { AppHeaderComponent } from "./components/app-elements/header/app-header.component";
import { AppfooterComponent } from "./components/app-elements/footer/app-footer.component";
import { AccountInformationComponent } from "./components/account-information/account-information.component";
import { LoginComponent } from "./components/login/login.component";
import { HomeComponent } from "./components/home/home.component";
import { NotFoundComponent } from "./components/not-fount/not-found.component";
import { BuyBidsComponent } from "./components/bids/buy-bids.component";
import { AuctionsComponent } from "./components/auction/auctions/auctions.component";
import { EndedAuctionsComponent } from "./components/auction/ended-auctions/ended-auctions.component";
import { AddAuctionComponent } from "./components/auction/add-auction/add-auction.component";
import { LotInformationComponent } from "./components/lot-information/lot-information.component";

// Services
import { AuctionService } from "./services/auction/auction.service";
import { AuthenticationService } from "./services/authentication/authentication.service";
import { HttpClientService } from "./services/http-client/http-client.service";
import { SessionService } from "./services/session/session.service";

// Guards
import { AuthenticationGuard } from "./guards/authentication.guard";


const appRoutes: Routes =[
    { path: '', component: HomeComponent},
    { path: 'authentication', component: LoginComponent, canActivate: [AuthenticationGuard]},
	{ path: 'auctions', component: HomeComponent},
	{ path: 'addAuction', component: AddAuctionComponent, canActivate: [AuthenticationGuard]},
	{ path: 'endedAuctions', component: EndedAuctionsComponent, canActivate: [AuthenticationGuard]},
	{ path: 'buyBids', component: BuyBidsComponent, canActivate: [AuthenticationGuard]},
	{ path: 'lot', component: LotInformationComponent},
	{ path: '**', component: NotFoundComponent }
];

@NgModule({
	declarations: [
		AppComponent,
		AppHeaderComponent,
		AppfooterComponent,
		AccountInformationComponent,
		LoginComponent,
		HomeComponent,
		NotFoundComponent,
		EndedAuctionsComponent,
		AuctionsComponent,
		AddAuctionComponent,
		BuyBidsComponent,
		LotInformationComponent
	],
	imports: [
		BrowserModule,
		FormsModule,
		HttpModule,
		RouterModule.forRoot(appRoutes)
	],
	providers: [
		SessionService,
		HttpClientService,
		AuctionService,
		AuthenticationService,

		AuthenticationGuard
	],
	bootstrap: [AppComponent]
})
export class AppModule { }
