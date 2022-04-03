import { Component, OnInit } from '@angular/core';
import { I18NEXT_NAMESPACE } from 'angular-i18next';

@Component({
  selector: 'app-not-found',
  templateUrl: './not-found.component.html',
  styleUrls: ['./not-found.component.css'],
  providers: [
    {
      provide: I18NEXT_NAMESPACE,
      useValue: 'views/not-found',
    },
  ],
})
export class NotFoundComponent {
  title = '@@title';
}
