import React from 'react';
import { Link, Outlet } from 'react-router-dom';
import { ModuleContext, defaultModule } from './contexts';
import styles from './App.module.css';
import { Messages } from './components/Messages';

function App(): React.ReactElement {
  const title = 'Tour of Heroes';

  return (
    <ModuleContext.Provider value={defaultModule}>
      <div className={styles.app}>
        <h1>{title}</h1>
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
