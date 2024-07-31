import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from '../../environments/environment';

@Injectable()
export class AtivoDataService {

  module: string = '/api/ativo';
  baseUrl = environment.baseUrl + '/api/ativo';
  constructor(private http: HttpClient) { }

  get() {
    return this.http.get(this.baseUrl);
  }

  post(data) {
    return this.http.post(this.baseUrl, data);
  }

  put(data) {
    return this.http.put(this.baseUrl, data);
  }

  delete() {
    return this.http.delete(this.baseUrl);
  }

}

