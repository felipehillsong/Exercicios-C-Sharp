import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()

export class EventoService {
  baseUrl = 'https://localhost:44308/api/Eventos';

constructor(private http: HttpClient) { }
 getEventos(){
  return this.http.get(this.baseUrl);
}

}
