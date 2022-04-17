import i18n from 'i18next';
import { initReactI18next } from 'react-i18next';
import Backend from 'i18next-http-backend';
import LanguageDetector from 'i18next-browser-languagedetector';

i18n
  .use(Backend)
  .use(LanguageDetector)
  .use(initReactI18next) // passes i18n down to react-i18next
  .init({
    supportedLngs: ['en', 'ru'],
    fallbackLng: 'en',
    debug: process.env.NODE_ENV === 'development',
    returnEmptyString: false,
    interpolation: {
      // eslint-disable-next-line max-len
      escapeValue: false, // react already safes from xss => https://www.i18next.com/translation-function/interpolation#unescape
    },
    backend: {
      loadPath: '/i18n/{{ns}}/{{lng}}.json',
    },
    ns: [
      'App',
      'components/HeroSearch',
      'components/Messages',
      'views/NotFound',
      'views/Dashboard',
      'views/HeroDetail',
      'views/Heroes',
    ],
  });
