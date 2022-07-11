/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Module } from '@nestjs/common';
import { CommonEnvironment } from 'src/layer1/common/common-environment';
import { DomainModule as DummyMainDomainModule } from 'src/layer4/domains/dummy-main/domain.module';
import { DummyMainItemPageService } from './pages/dummy-main/item/dummy-main-item-page.service';

@Module({
  imports: [DummyMainDomainModule],
  providers: [CommonEnvironment, DummyMainItemPageService],
})
export class ServerModule {}
