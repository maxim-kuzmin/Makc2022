/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Module } from '@nestjs/common';
import { DummyMainListPageController } from './controllers/pages/dummy-main/list/dummy-main-list-page.controller';
import { DummyMainItemPageController } from './controllers/pages/dummy-main/item/dummy-main-item-page.controller';
import { ServerModule } from '../../layer5/server/server.module';

@Module({
  imports: [ServerModule],
  controllers: [DummyMainListPageController, DummyMainItemPageController],
})
export class WebHttpServerModule {}
