/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Module } from '@nestjs/common';
import { DummyMainItemPageService } from './pages/dummy-main/item/dummy-main-item-page.service';
import { DomainModule as DummyMainDomainModule } from '../../layer4/domains/dummy-main/domain.module';

@Module({
  imports: [DummyMainDomainModule],
  providers: [DummyMainItemPageService],
})
export class ServerModule {}
