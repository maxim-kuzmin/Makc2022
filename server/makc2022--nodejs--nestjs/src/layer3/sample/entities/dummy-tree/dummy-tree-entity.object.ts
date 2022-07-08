/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

/** Объект сущности "DummyTree". */
export class DummyTreeEntityObject {
  /** Идентификатор. */
  id: number;

  /** Имя. */
  name: string;

  /** Идентификатор родителя. */
  parentId?: number;

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
