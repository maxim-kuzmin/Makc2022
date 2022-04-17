import { Component, OnDestroy, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { I18NEXT_NAMESPACE } from 'angular-i18next';
import { Hero } from '../../models/hero';
import { HeroService } from '../../services/hero.service';
import {
  addHero,
  addHeroSuccess,
  clear,
  deleteHero,
  deleteHeroSuccess,
  getHeroes,
  getHeroesSuccess,
  selectAddedHero,
  selectDeletedHero,
  selectHeroes,
} from './heroes.slice';

@Component({
  selector: 'app-heroes',
  templateUrl: './heroes.component.html',
  styleUrls: ['./heroes.component.css'],
  providers: [
    {
      provide: I18NEXT_NAMESPACE,
      useValue: 'views/heroes',
    },
  ],
})
export class HeroesComponent implements OnDestroy, OnInit {
  addeedHero$ = this.store.select(selectAddedHero);
  deletedHero$ = this.store.select(selectDeletedHero);
  heroes$ = this.store.select(selectHeroes);

  inputs = {
    newHeroName: {
      id: 'new-hero',
    },
  };

  constructor(private store: Store) {}

  getHeroes(): void {
    this.store.dispatch(getHeroes());
  }

  ngOnDestroy(): void {
    this.store.dispatch(clear());
  }

  ngOnInit(): void {
    this.getHeroes();
  }

  add(name: string): void {
    name = name.trim();
    if (!name) {
      return;
    }
    this.store.dispatch(addHero({ addedHero: { name } as Hero }));
    this.getHeroes();
  }

  delete(hero: Hero): void {
    this.store.dispatch(deleteHero({ id: hero.id }));
    this.getHeroes();
  }
}
