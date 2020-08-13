import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TrickingService {

  private baseUrl = 'http://localhost:5000/api/home';

  constructor(private http: HttpClient) {
  }

  getHomeApi() {
    return this.http.get(`${this.baseUrl}/index`, {responseType: 'text'});
  }
}
