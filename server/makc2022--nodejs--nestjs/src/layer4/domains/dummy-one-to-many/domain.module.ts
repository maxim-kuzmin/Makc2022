/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Module } from '@nestjs/common';
import { MapperModule } from 'src/layer3/nosql-mongo/sample/mappers/typegoose/mapper.module';
import { DomainService } from './domain.service';

@Module({
  imports: [MapperModule],
  providers: [DomainService],
  exports: [DomainService],
})
export class DomainModule {}
