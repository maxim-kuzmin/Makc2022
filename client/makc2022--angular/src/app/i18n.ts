import { APP_INITIALIZER, LOCALE_ID } from '@angular/core';
import {
  defaultInterpolationFormat,
  I18NextModule,
  I18NEXT_SERVICE,
  ITranslationService,
} from 'angular-i18next';
import Backend from 'i18next-http-backend';
import LanguageDetector from 'i18next-browser-languagedetector';

export function appInit(i18next: ITranslationService) {
  return () =>
    i18next
      .use(Backend)
      .use(LanguageDetector)
      .init({
        supportedLngs: ['en', 'ru'],
        fallbackLng: 'en',
        debug: process.env['NODE_ENV'] === 'development',
        returnEmptyString: false,
        interpolation: {
          escapeValue: false,
          format: I18NextModule.interpolationFormat(defaultInterpolationFormat),
        },
        backend: {
          loadPath: '/assets/i18n/{{ns}}/{{lng}}.json',
        },
        ns: ['app', 'views/not-found'],
      });
}

export function localeIdFactory(i18next: ITranslationService): string {
  return i18next.language;
}

export const I18N_PROVIDERS = [
  {
    provide: APP_INITIALIZER,
    useFactory: appInit,
    deps: [I18NEXT_SERVICE],
    multi: true,
  },
  {
    provide: LOCALE_ID,
    deps: [I18NEXT_SERVICE],
    useFactory: localeIdFactory,
  },
];
