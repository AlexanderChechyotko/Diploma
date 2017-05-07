import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

// Components
import { AppComponent } from './app.component';
import { AppHeaderComponent } from "./components/app-elements/header/app-header.component";
import { AppfooterComponent } from "./components/app-elements/footer/app-footer.component";
import { AccountInformationComponent } from "./components/account-information/account-information.component";
import { LoginComponent } from "./components/login/login.component";
import { HomeComponent } from "./components/home/home.component";

// Services
import { AuctionService } from "./services/auction/auction.service";
import { AuthenticationService } from "./services/authentication/authentication.service";
import { HttpClientService } from "./services/http-client/http-client.service";
import { SessionService } from "./services/session/session.service";


@NgModule({
	declarations: [
		AppComponent,
		AppHeaderComponent,
		AppfooterComponent,
		AccountInformationComponent,
		LoginComponent,
		HomeComponent
	],
	imports: [
		BrowserModule,
		FormsModule,
		HttpModule,
		RouterModule.forRoot([])
	],
	providers: [
		SessionService,
		HttpClientService,
		AuctionService,
		AuthenticationService
	],
	bootstrap: [AppComponent]
})
export class AppModule { }
