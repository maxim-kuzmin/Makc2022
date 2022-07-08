/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Controller, Get } from '@nestjs/common';

/** Контроллер страницы сущностей "DummyMain". */
@Controller('pages/dummy-main/list')
export class DummyMainListPageController {
  @Get()
  async get() {
    return [];
  }
}
