import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, take } from 'rxjs';
import { Produto } from 'src/app/models/produto';
import { environment } from 'src/environments/environment';
import { AuthService } from '../login/auth.service';

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {
  baseURL = environment.apiURL + 'api/Produto?';
  baseURLGetUpdateDelete = environment.apiURL + 'api/Produto';
  baseCepURL = environment.apiURL + 'api/Cep?';

  constructor(private http: HttpClient, private authService: AuthService) { }

  public addProduto(produto: Produto): Observable<Produto> {
    return this.http.post<Produto>(this.baseURL, produto).pipe(take(1));
  }

  public editProduto(produto: Produto): Observable<Produto> {
    return this.http.put<Produto>(`${this.baseURLGetUpdateDelete}/${produto.id}?empresaId=${produto.empresaId}`, produto).pipe(take(1));
  }

  public getProdutos(empresaId: number) : Observable<Produto[]>{
    return this.http.get<Produto[]>(`${this.baseURL}empresaId=${empresaId}`).pipe(take(1));
  }

  public getProdutosById(id : number) : Observable<Produto>{
    return this.http.get<Produto>(`${this.baseURLGetUpdateDelete}/${id}?empresaId=${this.authService.empresaId()}`).pipe(take(1));
  }

  public delete(id : number) : Observable<any>{
    return this.http.delete<string>(`${this.baseURLGetUpdateDelete}/${id}?empresaId=${this.authService.empresaId()}`).pipe(take(1));
  }

  public getCep(cep: string){
    return this.http.get(`${this.baseCepURL}cep=${cep}`).pipe(take(1));
  }

}
