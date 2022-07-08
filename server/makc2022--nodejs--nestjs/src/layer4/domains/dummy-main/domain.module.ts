/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Module } from '@nestjs/common';
import { DomainService } from './domain.service';

@Module({
  providers: [DomainService],
})
export class DomainModule {}
