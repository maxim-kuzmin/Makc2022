/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

/** Общая ошибка.
 * Сообщение, передаваемое в эту ошибку, должно быть переведено на текущий язык приложения.
 */
export class CommonError extends Error {
  /** Конструктор.
   * @param message Сообщение.
   */
  constructor(message?: string) {
    super(message);
  }
}
