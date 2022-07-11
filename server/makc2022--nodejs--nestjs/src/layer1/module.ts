/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Module as CommonModule } from '@nestjs/common';
import { QueryFactory } from './query/query-factory';

@CommonModule({
  imports: [],
  providers: [QueryFactory],
  exports: [QueryFactory],
})
export class Module {}
