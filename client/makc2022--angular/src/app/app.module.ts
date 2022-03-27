import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeroesComponent } from './views/heroes/heroes.component';
import { HeroDetailComponent } from './views/hero-detail/hero-detail.component';
import { MessagesComponent } from './components/messages/messages.component';
import { DashboardComponent } from './views/dashboard/dashboard.component';
import { InMemoryDataService } from './services/in-memory-data.service';
import { HeroSearchComponent } from './components/hero-search/hero-search.component';
import { NotFoundComponent } from './views/not-found/not-found.component';
import { StoreModule } from '@ngrx/store';
import reducers from './app.reducers';
import { EffectsModule } from '@ngrx/effects';
import { HeroesEffects } from './views/heroes/heroes.slice';
import { HeroDetailEffects } from './views/hero-detail/hero-detail.slice';
import { DasboardEffects } from './views/dashboard/dashboard.slice';
import { HeroSearchEffects } from './components/hero-search/hero-search.slice';
import { I18NextModule } from 'angular-i18next';
import { I18N_PROVIDERS } from './i18n';

@NgModule({
  declarations: [
    AppComponent,
    HeroesComponent,
    HeroDetailComponent,
    MessagesComponent,
    DashboardComponent,
    HeroSearchComponent,
    NotFoundComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    // The HttpClientInMemoryWebApiModule module intercepts HTTP requests
    // and returns simulated server responses.
    // Remove it when a real server is ready to receive requests.
    HttpClientInMemoryWebApiModule.forRoot(InMemoryDataService, {
      dataEncapsulation: false,
      passThruUnknownUrl: true,
    }),
    AppRoutingModule,
    StoreModule.forRoot(reducers),
    EffectsModule.forRoot([
      DasboardEffects,
      HeroDetailEffects,
      HeroesEffects,
      HeroSearchEffects,
    ]),
    I18NextModule.forRoot(),
  ],
  providers: [I18N_PROVIDERS],
  bootstrap: [AppComponent],
})
export class AppModule {}
