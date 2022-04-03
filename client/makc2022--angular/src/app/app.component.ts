import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import {
  I18NEXT_NAMESPACE,
  I18NEXT_SERVICE,
  ITranslationService,
} from 'angular-i18next';

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
export class AppComponent implements OnInit {
  title = '@@title';

  languages: { text: string; value: string; selected: boolean }[] = [];

  constructor(
    @Inject(I18NEXT_SERVICE) private i18NextService: ITranslationService,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) {
    const languages = i18NextService.options.supportedLngs as string[];

    for (const language of languages) {
      let text = '';

      switch (language) {
        case 'en':
          text = 'English';
          break;
        case 'ru':
          text = 'Русский';
          break;
      }

      this.languages.push({ text, value: language, selected: false });
    }
  }

  ngOnInit(): void {
    this.i18NextService.events.initialized.subscribe((e) => {
      if (e) {
        for (const language of this.languages) {
          language.selected = language.value === this.i18NextService.language;
        }
      }
    });
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
