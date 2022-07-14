/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

/** Обработчик запроса. */
export interface QueryHandler {
  /** Обработать ошибку запроса.
   * @param Ошибка.
   */
  onError(error: Error): void;
}
