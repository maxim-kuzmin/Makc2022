/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Module as CommonModule } from '@nestjs/common';
import { ConvertingFactory } from './converting/converting.factory';
import { QueryFactory } from './query/query.factory';

@CommonModule({
  imports: [],
  providers: [ConvertingFactory, QueryFactory],
  exports: [ConvertingFactory, QueryFactory],
})
export class Module {}
