/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

/** Загрузчик сущности.
 * @template TEntityObject Тип объекта сущности.
 */
export abstract class EntityLoader<TEntityObject> {
  /** Конструктор.
   * @param entityObject Объект сущности.
   */
  constructor(public entityObject: TEntityObject) {}

  /** Загрузить.
   * @param entityObject Объект сущности.
   * @param loadableProperties Загружаемые свойства.
   * @returns Загруженные свойства.
   */
  load(entityObject: TEntityObject, loadableProperties?: Set<string>): Set<string> {
    return loadableProperties ?? this.createAllPropertiesToLoad();
  }

  /** Создать все свойства для загрузки.
   * @returns Все свойства для загрузки.
   */
  protected abstract createAllPropertiesToLoad(): Set<string>;
}
