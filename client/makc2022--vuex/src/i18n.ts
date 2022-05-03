import { createI18n, LocaleMessages, VueMessageType } from 'vue-i18n';
import { parse } from 'query-string';

export const loacaleLocalStorageKey = 'i18nLng';
export const loacaleQueryParamName = 'lng';

const availableLocales = ['en', 'ru'];

/**
 * Load locale messages
 *
 * The loaded `JSON` locale messages is pre-compiled by `@intlify/vue-i18n-loader`, which is integrated into `vue-cli-plugin-i18n`.
 * See: https://github.com/intlify/vue-i18n-loader#rocket-i18n-resource-pre-compilation
 */
function loadLocaleMessages(): LocaleMessages<VueMessageType> {
  const locales = require.context(
    './locales',
    true,
    /[A-Za-z0-9-_,\s]+\.json$/i
  );
  const messages: LocaleMessages<VueMessageType> = {};
  locales.keys().forEach((key) => {
    const matched = key.match(/([A-Za-z0-9-_]+)\./i);
    if (matched && matched.length > 1) {
      const locale = matched[1];
      messages[locale] = locales(key).default;
    }
  });
  return messages;
}

function getLocale() {
  const search = parse(window.location.search);
  const loacaleQueryParamValue = search[loacaleQueryParamName];
  let locale = '';

  if (loacaleQueryParamValue != null) {
    locale = loacaleQueryParamValue as string;

    if (availableLocales.includes(locale)) {
      return locale;
    }
  }

  const loacaleLocalStorageValue = localStorage.getItem(loacaleLocalStorageKey);

  if (loacaleLocalStorageValue != null) {
    locale = loacaleLocalStorageValue as string;

    if (availableLocales.includes(locale)) {
      return locale;
    }
  }

  const environmentValue = process.env.VUE_APP_I18N_LOCALE;

  if (environmentValue) {
    locale = environmentValue as string;

    if (availableLocales.includes(locale)) {
      return locale;
    }
  }

  return availableLocales[0];
}

function getFallbackLocale() {
  let locale = '';

  const environmentValue = process.env.VUE_APP_I18N_FALLBACK_LOCALE;

  if (environmentValue) {
    locale = environmentValue as string;

    if (availableLocales.includes(locale)) {
      return locale;
    }
  }

  return availableLocales[0];
}

export default createI18n({
  legacy: false,
  globalInjection: true,
  locale: getLocale(),
  fallbackLocale: getFallbackLocale(),
  messages: loadLocaleMessages(),
});
