/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Module } from '@nestjs/common';
import { Module as Layer1Module } from '../../../layer1/module';
import { MapperModule } from '../../../layer3/nosql-mongo/sample/mappers/typegoose/mapper.module';
import { DomainFactory } from './domain.factory';
import { DomainService } from './domain.service';

@Module({
  imports: [Layer1Module, MapperModule],
  providers: [DomainFactory, DomainService],
  exports: [DomainFactory, DomainService, Layer1Module],
})
export class DomainModule {}
