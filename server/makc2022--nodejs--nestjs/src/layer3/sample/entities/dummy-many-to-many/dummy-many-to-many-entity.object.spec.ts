/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { DummyManyToManyEntityObject } from './dummy-many-to-many-entity.object';

describe('DummyManyToManyEntityObject', () => {
  it('should be defined', () => {
    expect(new DummyManyToManyEntityObject()).toBeDefined();
  });
});
