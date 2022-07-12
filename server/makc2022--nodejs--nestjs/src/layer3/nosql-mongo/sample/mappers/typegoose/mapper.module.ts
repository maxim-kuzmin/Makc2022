/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Module } from '@nestjs/common';
import { TypegooseModule } from 'nestjs-typegoose';
import { MapperDummyMainEntityObject } from './entities/dummy-main/mapper-dummy-main-entity.object';
import { MapperDummyMainEntityRepository } from './entities/dummy-main/mapper-dummy-main-entity.repository';
import { MapperDummyOneToManyEntityObject } from './entities/dummy-one-to-many/mapper-dummy-one-to-many-entity.object';
import { MapperDummyOneToManyEntityRepository } from './entities/dummy-one-to-many/mapper-dummy-one-to-many-entity.repository';

@Module({
  imports: [
    TypegooseModule.forFeature([MapperDummyMainEntityObject, MapperDummyOneToManyEntityObject]),
  ],
  providers: [MapperDummyMainEntityRepository, MapperDummyOneToManyEntityRepository],
  exports: [MapperDummyMainEntityRepository, MapperDummyOneToManyEntityRepository],
})
export class MapperModule {}
