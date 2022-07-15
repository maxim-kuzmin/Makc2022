/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

/** Ресурс домена. */
export interface DomainResource {
  /** Получить имя запроса на получение элемента.
   * @returns Имя запроса.
   */
  getItemGetQueryName(): string;

  /** Получить имя запроса на получение списка.
   * @returns Имя запроса.
   */
  getListGetQueryName(): string;
}
