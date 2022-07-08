/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Test, TestingModule } from '@nestjs/testing';
import { DummyMainListPageController } from './dummy-main-list-page.controller';

describe('DummyMainListPageController', () => {
  let controller: DummyMainListPageController;

  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      controllers: [DummyMainListPageController],
    }).compile();

    controller = module.get<DummyMainListPageController>(
      DummyMainListPageController
    );
  });

  it('should be defined', () => {
    expect(controller).toBeDefined();
  });
});
