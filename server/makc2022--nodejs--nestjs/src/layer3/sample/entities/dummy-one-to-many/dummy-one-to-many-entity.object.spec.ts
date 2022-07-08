/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { DummyOneToManyEntityObject } from './dummy-one-to-many-entity.object';

describe('DummyOneToManyEntityObject', () => {
  it('should be defined', () => {
    expect(new DummyOneToManyEntityObject()).toBeDefined();
  });
});
