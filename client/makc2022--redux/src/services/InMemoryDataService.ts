import { AxiosInstance, AxiosRequestConfig } from 'axios';
import MockAdapter from 'axios-mock-adapter';

export class InMemoryDataService {
  private paths = {
    heroes: 'api/heroes',
  };

  private data = {
    [this.paths.heroes]: [
      { id: 11, name: 'Dr Nice' },
      { id: 12, name: 'Narco' },
      { id: 13, name: 'Bombasto' },
      { id: 14, name: 'Celeritas' },
      { id: 15, name: 'Magneta' },
      { id: 16, name: 'RubberMan' },
      { id: 17, name: 'Dynama' },
      { id: 18, name: 'Dr IQ' },
      { id: 19, name: 'Magma' },
      { id: 20, name: 'Tornado' },
    ] as any[],
  };

  init(axiosInstance: AxiosInstance): void {
    const mock = new MockAdapter(axiosInstance);
    this.setup(mock, this.paths.heroes, 'name');
  }

  private setup(
    mock: MockAdapter,
    path: string,
    termParameterName: string
  ): void {
    mock
      .onGet(InMemoryDataService.getListUrl(path))
      .reply(() => this.getList(path))
      .onGet(InMemoryDataService.getSearchUrl(path, termParameterName))
      .reply((config) =>
        this.getSearchedItems(
          path,
          (item) => item.name,
          termParameterName,
          config
        )
      )
      .onGet(InMemoryDataService.getItemUrl(path))
      .reply((config) => this.getItem(path, config))
      .onPost(InMemoryDataService.getListUrl(path))
      .reply((config) => this.addItem(path, config))
      .onPut(InMemoryDataService.getListUrl(path))
      .reply((config) => this.updateItem(path, config))
      .onDelete(InMemoryDataService.getItemUrl(path))
      .reply((config) => this.deleteItem(path, config));
  }

  private static getItemUrl(path: string): RegExp {
    return new RegExp(`\\/${path}\\/\\d+`);
  }

  private static getListUrl(path: string): string {
    return `/${path}`;
  }

  private static getSearchUrl(path: string, termParameterName: string): RegExp {
    return new RegExp(`\\/${path}\\/\\?${termParameterName}=.+`);
  }

  private static getIdFromUrl(config: AxiosRequestConfig<any>): number {
    return config.url ? Number(config.url.split('/').pop()) : 0;
  }

  private static getTermFromUrl(
    config: AxiosRequestConfig<any>,
    termParameterName: string
  ): string | undefined {
    return config.url ? config.url.split(`?${termParameterName}=`).pop() : '';
  }

  /**
   * If the heroes array is empty,
   * the method below returns the initial number (11).
   * if the heroes array is not empty, the method below returns the highest
   * hero id + 1.
   */
  private static genId(list: any[]): number {
    return list.length > 0
      ? Math.max(...list.map((x) => Number(x.id))) + 1
      : 11;
  }

  private getList(path: string): any {
    return [200, this.data[path]];
  }

  private getItem(path: string, config: AxiosRequestConfig<any>): any {
    const list = this.data[path];
    const id = InMemoryDataService.getIdFromUrl(config);
    const item = list.find((x) => x.id === id);
    return [200, item];
  }

  private getSearchedItems(
    path: string,
    functionToGetTerm: (item: any) => string,
    termParameterName: string,
    config: AxiosRequestConfig<any>
  ): any {
    const list = this.data[path];
    const term = InMemoryDataService.getTermFromUrl(config, termParameterName);
    const items = term
      ? list.filter((x) =>
          functionToGetTerm(x).toLowerCase().includes(term.toLowerCase())
        )
      : [];
    return [200, items];
  }

  private addItem(path: string, config: AxiosRequestConfig<any>): any {
    const list = this.data[path];
    const item = JSON.parse(config.data);
    item.id = InMemoryDataService.genId(list);
    list.push(item);
    return [200, item];
  }

  private updateItem(path: string, config: AxiosRequestConfig<any>): any {
    const list = this.data[path];
    const item = JSON.parse(config.data);
    const itemIndex = list.findIndex((x) => x.id === item.id);
    list[itemIndex] = item;
    return [200, item];
  }

  private deleteItem(path: string, config: AxiosRequestConfig<any>): any {
    const list = this.data[path];
    const id = InMemoryDataService.getIdFromUrl(config);
    this.data[path] = list.filter((x) => x.id !== id);
    return [204, null];
  }
}
