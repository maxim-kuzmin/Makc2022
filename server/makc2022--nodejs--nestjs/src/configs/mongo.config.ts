/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { ConfigService } from '@nestjs/config';
import { TypegooseModuleOptions } from 'nestjs-typegoose';

/**
 * Получить конфигурацию Mongo.
 * @param configService Сервис конфигурации.
 * @returns Настройки модуля Typegoose.
 */
export async function getMongoConfig(
  configService: ConfigService
): Promise<TypegooseModuleOptions> {
  const login = configService.get('MONGO_LOGIN');
  const password = configService.get('MONGO_PASSWORD');
  const host = configService.get('MONGO_HOST');
  const port = configService.get('MONGO_PORT');
  const defaultauthdb = configService.get('MONGO_DEFAULTAUTHDB');

  const uri = `mongodb://${login}:${password}@${host}:${port}/${defaultauthdb}`;

  return {
    uri,
  };
}
