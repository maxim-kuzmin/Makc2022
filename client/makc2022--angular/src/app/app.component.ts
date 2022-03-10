import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = '';

  constructor(translate: TranslateService) {
    translate.setDefaultLang('app/en');
    translate.use('app/en');

    translate.get('@@title').subscribe((res: string) => (this.title = res));
  }
}
