import { Module } from '@nestjs/common';
import { AppController } from './app.controller';
import { AppService } from './app.service';
import { DummyMainListPageController } from './layer6/web-http-server/controllers/pages/dummy-main/list/dummy-main-list-page.controller';
import { DummyMainItemPageController } from './layer6/web-http-server/controllers/pages/dummy-main/item/dummy-main-item-page.controller';

@Module({
  imports: [],
  controllers: [AppController, DummyMainListPageController, DummyMainItemPageController],
  providers: [AppService],
})
export class AppModule {}
