import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpModule }   from '@angular/http';

import { RouteConfig } from './route-config';

// Components
import { AppComponent } from './app.component';
import { AppHeaderComponent } from './components/app-elements/header/app-header.component';
import { AppfooterComponent } from './components/app-elements/footer/app-footer.component';
import { HomeComponent } from './components/home/home.component';
import { AuthorizationComponent } from './components/authorization/authorization.component';
import { LoginComponent } from './components/authorization/login/login.component';

// Services
import { HttpClientService } from "./services/http-client/http-client.service";
import { SessionService } from './services/session/session.service';
import { AuthenticationService } from './services/authentication/authentication.service';
import { AuctionService } from "./services/auction/auction.service";


@NgModule({
    imports:[
        BrowserModule,
        FormsModule,
        HttpModule,
        //RouterModule.forRoot(RouteConfig.registeredRoutes())
    ],
    declarations: [
        AppComponent,
        AppHeaderComponent,
        AppfooterComponent,
        AuthorizationComponent,
        LoginComponent,
        HomeComponent
    ],
    providers: [
        HttpClientService,
        SessionService,
        AuthenticationService,
        AuctionService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
