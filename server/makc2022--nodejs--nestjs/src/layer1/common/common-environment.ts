/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Injectable } from '@nestjs/common';

/** Общее окружение. */
@Injectable()
export class CommonEnvironment {
  /** Базовый путь: абсолютный путь к папке, относительно которой указываются пути к файлам. */
  basePath = __dirname;

  /** Имя. */
  name = process.env.NODE_ENV ?? 'development';

  /** Получить признак окружения для разработки.
   * @returns Признак окружения для разработки.
   */
  isDevelopment(): boolean {
    return this.name === 'development';
  }

  /** Получить признак продуктового окружения.
   * @returns Признак продуктового окружения.
   */
  isProduction(): boolean {
    return this.name === 'production';
  }

  /** Получить признак окружения для тестирования.
   * @returns Признак окружения для тестирования.
   */
  isTest(): boolean {
    return this.name === 'test';
  }
}
