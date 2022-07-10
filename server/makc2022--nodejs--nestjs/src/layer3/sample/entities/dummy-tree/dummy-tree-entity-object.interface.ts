/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

/** Интерфейс объекта сущности "DummyTree".
 * @template TID Тип идентификатора.
 */
export interface IDummyTreeEntityObject<TID> {
  /** Идентификатор. */
  id: TID;

  /** Имя. */
  name: string;

  /** Идентификатор родителя. */
  parentId?: TID;

  /** Число детей в дереве. */
  treeChildCount: number;

  /** Число потомков в дереве. */
  treeDescendantCount: number;

  /** Уровень в дереве. */
  treeLevel: number;

  /** Путь в дереве. */
  treePath: string;

  /** Позиция в дереве. */
  treePosition: number;

  /** Сортировка в дереве. */
  treeSort: string;
}
