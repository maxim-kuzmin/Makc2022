import { Component, Inject, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import {
  I18NEXT_NAMESPACE,
  I18NEXT_SERVICE,
  ITranslationService,
} from 'angular-i18next';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [
    {
      provide: I18NEXT_NAMESPACE,
      useValue: 'app',
    },
  ],
})
export class AppComponent implements OnDestroy {
  title = '@@title';

  languages: { text: string; value: string; selected: boolean }[] = [];

  private languageEventSubscription: Subscription;

  constructor(
    @Inject(I18NEXT_SERVICE) private i18NextService: ITranslationService,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) {
    const supportedLngs = i18NextService.options.supportedLngs as string[];

    supportedLngs.forEach((lng) => {
      let text = '';

      switch (lng) {
        case 'en':
          text = 'English';
          break;
        case 'ru':
          text = 'Русский';
          break;
        default:
          return;
      }

      this.languages.push({ text, value: lng, selected: false });
    });

    this.languageEventSubscription =
      this.i18NextService.events.initialized.subscribe((e) => {
        if (e) {
          this.languages.forEach((language) => {
            language.selected = language.value === this.i18NextService.language;
          });
        }
      });
  }

  ngOnDestroy(): void {
    this.languageEventSubscription.unsubscribe();
  }

  onLanguageChange(event: Event): void {
    const lang = (event.target as HTMLSelectElement).value;

    if (lang !== this.i18NextService.language) {
      this.i18NextService.changeLanguage(lang).then(() => {
        const queryParams: Params = { lng: lang };

        this.router
          .navigate([], {
            relativeTo: this.activatedRoute,
            queryParams: queryParams,
            queryParamsHandling: 'merge', // remove to replace all query params by provided
          })
          .then(() => {
            document.location.reload();
          });
      });
    }
  }
}
