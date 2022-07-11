/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Module } from '@nestjs/common';
import { TypegooseModule } from 'nestjs-typegoose';
import { MapperDummyMainEntityObject } from './entities/dummy-main/mapper-dummy-main-entity-object';

@Module({
  imports: [TypegooseModule.forFeature([MapperDummyMainEntityObject])],
})
export class MapperModule {}
