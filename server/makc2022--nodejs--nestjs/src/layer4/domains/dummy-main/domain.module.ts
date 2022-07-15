/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Module } from '@nestjs/common';
import { MapperModule } from 'src/layer3/nosql-mongo/sample/mappers/typegoose/mapper.module';
import { DomainFactory } from './domain.factory';
import { DomainService } from './domain.service';
import { Module as Layer1Module } from 'src/layer1/module';

@Module({
  imports: [Layer1Module, MapperModule],
  providers: [DomainFactory, DomainService],
  exports: [DomainFactory, DomainService, Layer1Module],
})
export class DomainModule {}
