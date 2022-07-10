/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

/** Интерфейс объекта сущности "DummyManyToMany".
 * @template TID Тип идентификатора.
 */
export interface IDummyManyToManyEntityObject<TID> {
  /** Идентификатор. */
  id: TID;

  /** Имя. */
  name: string;
}
