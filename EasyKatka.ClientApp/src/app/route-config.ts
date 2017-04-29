import { Routes } from '@angular/router';

import { AuthorizationComponent } from './components/authorization/authorization.component';


export class RouteConfig {
    public static registeredRoutes(): Routes {
        let routes: Routes =[
            { path: 'authorization', component: AuthorizationComponent},
        ];

        return routes;
    }
}