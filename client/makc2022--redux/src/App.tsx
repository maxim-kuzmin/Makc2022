import React from 'react';
import { Link, Outlet } from 'react-router-dom';
import { useTranslation } from 'react-i18next';
import { ModuleContext, defaultModule } from './contexts';
import styles from './App.module.css';
import { Messages } from './components/Messages';
import './i18n';

function App(): React.ReactElement {
  const { t } = useTranslation(['App']);

  return (
    <ModuleContext.Provider value={defaultModule}>
      <div className={styles.app}>
        <h1>{t('title')}</h1>
        <nav>
          <Link to='dashboard'>Dashboard</Link>
          <Link to='heroes'>Heroes</Link>
        </nav>
        <Outlet />
        <Messages />
      </div>
    </ModuleContext.Provider>
  );
}

export default App;
