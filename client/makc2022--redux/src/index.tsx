import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import { Provider } from 'react-redux';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { Dashboard } from './views/Dashboard';
import { Heroes } from './views/Heroes';
import { HeroDetail } from './views/HeroDetail';
import { NotFound } from './views/NotFound';
import { store } from './app/store';

ReactDOM.render(
  <React.StrictMode>
    <React.Suspense fallback={<h1>Loading...</h1>}>
      <Provider store={store}>
        <BrowserRouter>
          <Routes>
            <Route path='/' element={<App />}>
              <Route index element={<Dashboard />} />
              <Route path='dashboard' element={<Dashboard />} />
              <Route path='heroes' element={<Heroes />} />
              <Route path='detail/:id' element={<HeroDetail />} />
              <Route path='*' element={<NotFound />} />
            </Route>
          </Routes>
        </BrowserRouter>
      </Provider>
    </React.Suspense>
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
