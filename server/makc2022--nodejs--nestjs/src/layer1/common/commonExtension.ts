/** Получить имя свойства с гарантией его существования в типе.
 * @template T Тип.
 * @param name Имя свойства.
 */
export function nameof<T>(name: keyof T) {
  return name;
}
