import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Permissoes } from '../enums/permissoes';
import { Permissao } from '../models/permissao';
import { Usuario } from '../models/usuario';
import { NavService } from './nav.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseURL = environment.apiURL + 'api/Login';
  usuarioLogado: boolean = false;
  token!: void;
  user = new BehaviorSubject<any>(null);
  usuario = {} as Usuario;

constructor(private http: HttpClient, public nav: NavService) { }

public fazerLogin(login: Usuario): Observable<Usuario> {
  return this.http.post<Usuario>(this.baseURL, login);
}

public alterarLogin(usuarioAlteracao: any): Observable<Usuario> {
  return this.http.post<Usuario>(`${this.baseURL}/${usuarioAlteracao.funcionarioId}`, usuarioAlteracao);
}

public verificaAdministrador(){
  if(this.empresaId() == Permissoes.Administrador){
    this.nav.showEmpresa();
  }else{
    this.nav.hideEmpresa();
  }
}

public empresaId():number{
  let usuario = JSON.parse(sessionStorage.getItem('loginRetorno') || '{}');
  return usuario.empresaId;
}

public idDoUsuarioLogado():number{
  let usuario = JSON.parse(sessionStorage.getItem('loginRetorno') || '{}');
  return usuario.id;
}

public nomeEmpresa():string{
  let usuario = JSON.parse(sessionStorage.getItem('loginRetorno') || '{}');
  return usuario.nomeEmpresa;
}

public nomeUsuario():string{
  let usuario = JSON.parse(sessionStorage.getItem('loginRetorno') || '{}');
  return usuario.nome;
}

public dadosDoUsuario(){
  let usuario = JSON.parse(sessionStorage.getItem('loginRetorno') || '{}');
  return usuario;
}

public permissoesDoUsuario():Permissao[]{
  let permissoesUsuario = JSON.parse(sessionStorage.getItem('loginRetorno') || '{}');
  this.usuario = permissoesUsuario;
  return this.usuario.permissoes;
}

public visualizarCliente():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].visualizarCliente;
  if(vizualizar){
    this.nav.vizualizarCliente();
    return vizualizar;
  }else{
    this.nav.naoVizualizarCliente();
    return vizualizar;
  }
}

}
