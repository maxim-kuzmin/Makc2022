import { Component, OnInit, OnDestroy } from '@angular/core';
import { Store } from '@ngrx/store';
import { I18NEXT_NAMESPACE } from 'angular-i18next';
import { Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { HeroService } from '../../services/hero.service';
import { clear, getHeroes, selectHeroes } from './hero-search.slice';

@Component({
  selector: 'app-hero-search',
  templateUrl: './hero-search.component.html',
  styleUrls: ['./hero-search.component.css'],
  providers: [
    {
      provide: I18NEXT_NAMESPACE,
      useValue: 'components/hero-search',
    },
  ],
})
export class HeroSearchComponent implements OnDestroy {
  private searchTerms$ = new Subject<string>();

  heroes$ = this.store.select(selectHeroes);

  inputs = {
    term: {
      id: 'search-box',
    },
  };

  constructor(private heroService: HeroService, private store: Store) {
    this.searchTerms$
      .pipe(
        // wait 300ms after each keystroke before considering the term
        debounceTime(300),

        // ignore new term if same as previous term
        distinctUntilChanged()
      )
      .subscribe((term) => {
        this.store.dispatch(getHeroes({ term }));
      });
  }

  ngOnDestroy(): void {
    this.store.dispatch(clear());
  }

  // Push a search term into the observable stream.
  search(term: string): void {
    this.searchTerms$.next(term);
  }
}
