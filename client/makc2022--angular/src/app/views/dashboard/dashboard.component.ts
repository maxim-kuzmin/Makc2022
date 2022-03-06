import { Component, OnInit, OnDestroy } from '@angular/core';
import { Store } from '@ngrx/store';
import { clear, getHeroes, selectHeroes } from './dashboard.slice';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
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
