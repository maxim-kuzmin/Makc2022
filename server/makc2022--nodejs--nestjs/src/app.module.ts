/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Module } from '@nestjs/common';
import { ConfigModule, ConfigService } from '@nestjs/config';
import { AcceptLanguageResolver, I18nModule, QueryResolver } from 'nestjs-i18n';
import { TypegooseModule } from 'nestjs-typegoose';
import * as path from 'path';
import { AppController } from './app.controller';
import { AppService } from './app.service';
import { WebHttpServerModule } from './layer6/web-http-server/web-http-server.module';
import { getMongoConfig } from './configs/mongo.config';
import { DomainModule as DummyMainDomainModule } from './layer4/domains/dummy-main/domain.module';
import { DomainModule as DummyOneToManyDomainModule } from './layer4/domains/dummy-one-to-many/domain.module';

@Module({
  imports: [
    DummyMainDomainModule,
    DummyOneToManyDomainModule,
    I18nModule.forRoot({
      fallbackLanguage: 'en',
      loaderOptions: {
        path: path.join(__dirname, '/i18n/'),
        watch: true,
      },
      resolvers: [{ use: QueryResolver, options: ['lang'] }, AcceptLanguageResolver],
    }),
    ConfigModule.forRoot(),
    WebHttpServerModule,
    TypegooseModule.forRootAsync({
      imports: [ConfigModule],
      inject: [ConfigService],
      useFactory: getMongoConfig,
    }),
  ],
  controllers: [AppController],
  providers: [AppService],
})
export class AppModule {}
