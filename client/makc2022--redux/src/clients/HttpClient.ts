import axios, { AxiosInstance } from 'axios';
import { InMemoryDataService } from '../services/InMemoryDataService';

export class HttpClient {
  axiosInstance!: AxiosInstance;

  constructor(inMemoryDataService: InMemoryDataService) {
    const baseURL = 'http://localhost:5000';

    this.axiosInstance = axios.create({
      baseURL,
    });

    inMemoryDataService.init(this.axiosInstance);
  }
}
