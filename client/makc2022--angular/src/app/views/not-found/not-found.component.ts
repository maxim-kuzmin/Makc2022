import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-not-found',
  templateUrl: './not-found.component.html',
  styleUrls: ['./not-found.component.css'],
})
export class NotFoundComponent {
  title = '';

  constructor(translate: TranslateService) {
    translate.setDefaultLang('views/not-found/en');
    translate.use('views/not-found/en');

    translate.get('@@title').subscribe((res: string) => (this.title = res));
  }
}
