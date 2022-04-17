import { createHero } from 'src/app/models/hero';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { Store } from '@ngrx/store';
import { clear, getHero, selectHero, updateHero } from './hero-detail.slice';
import { Subject, takeUntil } from 'rxjs';
import { I18NEXT_NAMESPACE } from 'angular-i18next';

@Component({
  selector: 'app-hero-detail',
  templateUrl: './hero-detail.component.html',
  styleUrls: ['./hero-detail.component.css'],
  providers: [
    {
      provide: I18NEXT_NAMESPACE,
      useValue: 'views/hero-detail',
    },
  ],
})
export class HeroDetailComponent implements OnDestroy, OnInit {
  private hero$ = this.store.select(selectHero);
  private unsubscribe$ = new Subject<boolean>();

  hero = createHero();

  inputs = {
    heroName: {
      id: 'hero-name',
    },
  };

  constructor(
    private route: ActivatedRoute,
    private location: Location,
    private store: Store
  ) {
    this.hero$.pipe(takeUntil(this.unsubscribe$)).subscribe((hero) => {
      this.hero = { ...hero };
    });
  }

  ngOnDestroy(): void {
    this.unsubscribe$.next(true);
    this.unsubscribe$.complete();
    this.store.dispatch(clear());
  }

  ngOnInit(): void {
    this.getHero();
  }

  getHero(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.store.dispatch(getHero({ id }));
  }

  goBack(): void {
    this.location.back();
  }

  save(): void {
    this.store.dispatch(updateHero({ hero: this.hero }));
    this.goBack();
  }
}
