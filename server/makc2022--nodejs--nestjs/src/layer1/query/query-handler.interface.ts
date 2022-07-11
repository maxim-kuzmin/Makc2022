/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

/** Интрефейс обработчика запроса. */
export interface IQueryHandler {
  /** Обработать ошибку запроса.
   * @param Ошибка.
   */
  onError(error: Error): void;
}
