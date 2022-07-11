/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Module } from '@nestjs/common';
import { Module as Layer1Module } from 'src/layer1/module';
import { ServerModule } from 'src/layer5/server/server.module';
import { DummyMainListPageController } from './controllers/pages/dummy-main/list/dummy-main-list-page.controller';
import { DummyMainItemPageController } from './controllers/pages/dummy-main/item/dummy-main-item-page.controller';

@Module({
  imports: [ServerModule, Layer1Module],
  controllers: [DummyMainListPageController, DummyMainItemPageController],
})
export class WebHttpServerModule {}
