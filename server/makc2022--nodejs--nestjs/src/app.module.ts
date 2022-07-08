import { Module } from '@nestjs/common';
import { AppController } from './app.controller';
import { AppService } from './app.service';
import { WebHttpServerModule } from './layer6/web-http-server/web-http-server.module';
import { ServerModule } from './layer5/server/server.module';

@Module({
  imports: [WebHttpServerModule, ServerModule],
  controllers: [AppController],
  providers: [AppService],
})
export class AppModule {}
