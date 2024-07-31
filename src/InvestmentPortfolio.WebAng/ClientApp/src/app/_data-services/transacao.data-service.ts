import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from '../../environments/environment';

@Injectable()
export class TransacaoDataService {

  module: string = '/api/transacao';
  baseUrl = environment.baseUrl + '/api/transacao';
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

  authenticate(data) {
    return this.http.post(this.baseUrl + '/authenticate', data);
  }

}
