/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Test, TestingModule } from '@nestjs/testing';
import { DummyMainItemPageService } from './dummy-main-item-page.service';

describe('DummyMainItemPageService', () => {
  let service: DummyMainItemPageService;

  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      providers: [DummyMainItemPageService],
    }).compile();

    service = module.get<DummyMainItemPageService>(DummyMainItemPageService);
  });

  it('should be defined', () => {
    expect(service).toBeDefined();
  });
});
