import { HttpClient } from './clients/HttpClient';
import { MessageService } from './services/MessageService';
import { InMemoryDataService } from './services/InMemoryDataService';
import { HeroService } from './services/HeroService';

export class Module {
  heroService!: HeroService;

  httpClient!: HttpClient;

  inMemoryDataService!: InMemoryDataService;

  messageService!: MessageService;

  constructor() {
    this.inMemoryDataService = new InMemoryDataService();
    this.httpClient = new HttpClient(this.inMemoryDataService);
    this.messageService = new MessageService();
    this.heroService = new HeroService(this.httpClient, this.messageService);
  }
}
