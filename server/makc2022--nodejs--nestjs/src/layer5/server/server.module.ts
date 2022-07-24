/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Module } from '@nestjs/common';
import { DomainModule as DummyMainDomainModule } from '../../layer4/domains/dummy-main/domain.module';
import { CommonEnvironment } from '../../layer1/common/common-environment';
import { DummyMainItemPageService } from './pages/dummy-main/item/dummy-main-item-page.service';

@Module({
  imports: [DummyMainDomainModule],
  providers: [CommonEnvironment, DummyMainItemPageService],
  exports: [DummyMainItemPageService],
})
export class ServerModule {}
