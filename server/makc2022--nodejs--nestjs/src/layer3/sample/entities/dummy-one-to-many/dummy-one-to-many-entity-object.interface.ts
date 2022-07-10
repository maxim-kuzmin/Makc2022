/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

/** Интерфейс объекта сущности "DummyOneToMany".
 * @template TID Тип идентификатора.
 */
export interface IDummyOneToManyEntityObject<TID> {
  /** Идентификатор. */
  id: TID;

  /** Имя. */
  name: string;
}
