/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

/** Получить имя свойства с гарантией его существования в типе.
 * @template T Тип.
 * @param name Имя свойства.
 * @returns Ключ типа.
 */
export function nameof<T>(name: keyof T): keyof T {
  return name;
}
