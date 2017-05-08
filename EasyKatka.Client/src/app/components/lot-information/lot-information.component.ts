import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';
import {Observable} from 'rxjs/Rx';

@Component({
	selector: 'lot',
	templateUrl: 'lot-information.component.html',
	styleUrls: ['lot-information.component.scss']
})
export class LotInformationComponent implements OnInit, OnDestroy {
    id: number;
    ticks: number = 0;

    private subscription: Subscription;

    constructor(private activateRoute: ActivatedRoute) {
        this.subscription = activateRoute.params.subscribe((params) => this.id = params['id']);
    }

    ngOnInit(){
        let timer = Observable.timer(0, 1000);
        timer.subscribe(
            (t) => this.ticks = t,
            (error) => console.log(error),
            () => console.log('completed')
        );
    }

    ngOnDestroy(){
        this.subscription.unsubscribe();
    }
}