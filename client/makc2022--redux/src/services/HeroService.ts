import { AxiosInstance, AxiosRequestConfig, AxiosResponse } from 'axios';
import { Hero } from '../models/Hero';
import { HttpClient } from '../clients/HttpClient';
import { MessageService } from './MessageService';

export class HeroService {
  private heroesUrl = 'api/heroes'; // URL to web api

  private httpOptions: AxiosRequestConfig = {
    headers: {
      'Content-type': 'application/json',
    },
  };

  constructor(
    private httpClient: HttpClient,
    private messageService: MessageService
  ) {}

  private get http(): AxiosInstance {
    return this.httpClient.axiosInstance;
  }

  /** GET heroes from the server */
  getHeroes(): Promise<Hero[]> {
    return this.http
      .get<Hero[]>(this.heroesUrl)
      .then((response: AxiosResponse<Hero[], any>) => {
        const result = response.data;
        this.log('fetched heroes');
        return result;
      })
      .catch(this.handleError<Hero[]>('getHeroes', []));
  }

  /** GET hero by id. Will 404 if id not found */
  getHero(id: number): Promise<Hero> {
    const url = `${this.heroesUrl}/${id}`;
    return this.http
      .get<Hero>(url)
      .then((response: AxiosResponse<Hero, any>) => {
        const result = response.data;
        this.log(`fetched hero id=${id}`);
        return result;
      })
      .catch(this.handleError<Hero>(`getHero id=${id}`));
  }

  /** PUT: update the hero on the server */
  updateHero(hero: Hero): Promise<any> {
    return this.http
      .put(this.heroesUrl, hero, this.httpOptions)
      .then(() => this.log(`updated hero id=${hero.id}`))
      .catch(this.handleError<any>('updateHero'));
  }

  /** POST: add a new hero to the server */
  addHero(hero: Hero): Promise<Hero> {
    return this.http
      .post<Hero>(this.heroesUrl, hero, this.httpOptions)
      .then((response: AxiosResponse<Hero, any>) => {
        const result = response.data;
        this.log(`added hero w/ id=${result.id}`);
        return result;
      })
      .catch(this.handleError<Hero>('addHero'));
  }

  /** DELETE: delete the hero from the server */
  deleteHero(id: number): Promise<Hero> {
    const url = `${this.heroesUrl}/${id}`;

    return this.http
      .delete<Hero>(url, this.httpOptions)
      .then(() => this.log(`deleted hero id=${id}`))
      .catch(this.handleError<any>('deleteHero'));
  }

  /* GET heroes whose name contains search term */
  searchHeroes(term: string): Promise<Hero[]> {
    if (!term.trim()) {
      // if not search term, return empty hero array.
      return Promise.resolve<Hero[]>([]);
    }
    return this.http
      .get<Hero[]>(`${this.heroesUrl}/?name=${term}`)
      .then((response: AxiosResponse<Hero[], any>) => {
        const result = response.data;
        if (result.length) {
          this.log(`found heroes matching "${term}"`);
        } else {
          this.log(`no heroes matching "${term}"`);
        }
        return result;
      })
      .catch(this.handleError<Hero[]>('searchHeroes', []));
  }

  /** Log a HeroService message with the MessageService */
  private log(message: string): void {
    this.messageService.add(`HeroService: ${message}`);
  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Promise<T> => {
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return Promise.resolve(result as T);
    };
  }
}
