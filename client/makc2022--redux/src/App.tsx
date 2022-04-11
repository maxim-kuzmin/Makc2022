import React from 'react';
import { Link, Outlet, useSearchParams } from 'react-router-dom';
import { useTranslation } from 'react-i18next';
import { ModuleContext, defaultModule } from './contexts';
import styles from './App.module.css';
import { Messages } from './components/Messages';
import './i18n';

function App(): React.ReactElement {
  const { t, i18n } = useTranslation(['App']);

  const [searchParams, setSearchParams] = useSearchParams();

  const languages: { text: string; value: string }[] = [];

  const supportedLngs = i18n.options.supportedLngs as string[];

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

    languages.push({ text, value: lng });
  });

  function handleLanguageChange(
    event: React.ChangeEvent<HTMLSelectElement>
  ): void {
    const lang = event.target.value;

    if (lang !== i18n.language) {
      i18n.changeLanguage(lang).then(() => {
        searchParams.set('lng', lang);

        setSearchParams(searchParams);
      });
    }
  }

  return (
    <ModuleContext.Provider value={defaultModule}>
      <div className={styles.app}>
        <h1>{t('@@title')}</h1>
        <div className={styles['top-menu']}>
          <nav>
            <Link to='dashboard'>Dashboard</Link>
            <Link to='heroes'>Heroes</Link>
          </nav>
          <select onChange={handleLanguageChange} defaultValue={i18n.language}>
            {languages.map((language) => (
              <option key={language.value} value={language.value}>
                {language.text}
              </option>
            ))}
          </select>
        </div>
        <Outlet />
        <Messages />
      </div>
    </ModuleContext.Provider>
  );
}

export default App;
