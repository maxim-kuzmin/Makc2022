/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Controller, Get, Param } from '@nestjs/common';

/** Контроллер страницы сущности "DummyMain". */
@Controller('pages/dummy-main/item')
export class DummyMainItemPageController {
  @Get(':id')
  async get(@Param('id') id: number) {
    return { id };
  }
}
