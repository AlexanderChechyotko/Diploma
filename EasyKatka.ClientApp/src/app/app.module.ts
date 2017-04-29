import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { RouteConfig } from './route-config';

// Components
import { AppComponent } from './app.component';
import { AppHeaderComponent } from './components/app-elements/header/app-header.component';
import { AppfooterComponent } from './components/app-elements/footer/app-footer.component';
import { HomeComponent } from './components/home/home.component';
import { AuthorizationComponent } from './components/authorization/authorization.component';
import { LoginComponent } from './components/authorization/login/login.component';

// Services
import { SessionService } from './services/session/session.service';
import { AuthenticationService } from './services/authentication/authentication.service';

@NgModule({
    imports:[BrowserModule, FormsModule,  RouterModule.forRoot(RouteConfig.registeredRoutes())],
    declarations: [
        AppComponent,
        AppHeaderComponent,
        AppfooterComponent,
        AuthorizationComponent,
        LoginComponent,
        HomeComponent
    ],
    providers: [
        SessionService,
        AuthenticationService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
