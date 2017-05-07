import { Component, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';

@Component({
	selector: 'lot',
	templateUrl: 'lot-information.component.html',
	styleUrls: ['lot-information.component.scss']
})
export class LotInformationComponent implements OnDestroy {
    id: number;
    private subscription: Subscription;

    constructor(private activateRoute: ActivatedRoute) {
        this.subscription = activateRoute.params.subscribe((params) => this.id = params['id']);
    }

    ngOnDestroy(){
        this.subscription.unsubscribe();
    }
}