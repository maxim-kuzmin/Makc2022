import { Component, OnInit, OnDestroy } from '@angular/core';
import { Store } from '@ngrx/store';
import { clear, getHeroes, selectHeroes } from './dashboard.slice';
import { I18NEXT_NAMESPACE } from 'angular-i18next';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
  providers: [
    {
      provide: I18NEXT_NAMESPACE,
      useValue: 'views/dashboard',
    },
  ],
})
export class DashboardComponent implements OnDestroy, OnInit {
  heroes$ = this.store.select(selectHeroes);

  constructor(private store: Store) {}

  ngOnDestroy(): void {
    this.store.dispatch(clear());
  }

  ngOnInit(): void {
    this.getHeroes();
  }

  getHeroes(): void {
    this.store.dispatch(getHeroes());
  }
}
