/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

/** Интерфейс объекта сущности "DummyTreeLink".
 * @template TID Тип идентификатора.
 */
export interface IDummyTreeLinkEntityObject<TID> {
  /** Идентификатор. */
  id: TID;

  /** Идентификатор родителя. */
  parentId: TID;
}
