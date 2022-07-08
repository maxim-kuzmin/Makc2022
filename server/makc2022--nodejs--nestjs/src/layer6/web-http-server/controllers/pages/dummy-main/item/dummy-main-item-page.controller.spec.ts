/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Test, TestingModule } from '@nestjs/testing';
import { DummyMainItemPageController } from './dummy-main-item-page.controller';

describe('DummyMainItemPageController', () => {
  let controller: DummyMainItemPageController;

  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      controllers: [DummyMainItemPageController],
    }).compile();

    controller = module.get<DummyMainItemPageController>(
      DummyMainItemPageController
    );
  });

  it('should be defined', () => {
    expect(controller).toBeDefined();
  });
});
