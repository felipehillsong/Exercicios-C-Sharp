import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { AuthService } from '../login/auth.service';
import { Observable, take } from 'rxjs';
import { Cliente } from 'src/app/models/cliente';

@Injectable({
  providedIn: 'root'
})
export class RelatorioService {
  baseURL = environment.apiURL + 'api/Relatorio?';

constructor(private http: HttpClient, private authService: AuthService) { }

public getRelatorioCliente(codigoRelatorio: number, dataInicio: string, dataFinal: string) : Observable<Cliente[]>{
  return this.http.get<Cliente[]>(`${this.baseURL}empresaId=${this.authService.empresaId()}&codigoRelatorio=${codigoRelatorio}&dataInicio=${dataInicio}&dataFinal=${dataFinal}`).pipe(take(1));
}

}
