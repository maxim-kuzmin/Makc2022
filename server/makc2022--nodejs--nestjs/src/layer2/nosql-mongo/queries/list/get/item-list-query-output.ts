/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

/** Входные данные запроса на получение списка.
 * @template TItem Тип элемента.
 */
export class ListGetQueryOutput<TItem> {
  /** Элементы. */
  items: TItem[];

  /** Общее число элементов. */
  totalCount: number;
}
