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
    var vizualizar = this.permissoesDoUsuario()[0].visualizarEmpresa;
  if(vizualizar){
    this.nav.showEmpresa();
  }else{
    this.nav.hideEmpresa();
  }
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
    this.nav.visualizarCliente();
    return vizualizar;
  }else{
    this.nav.naoVisualizarCliente();
    return vizualizar;
  }
}

public visualizarClienteCadastro():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].clienteCadastro;
  return vizualizar;
}

public visualizarClienteEditar():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].clienteEditar;
  return vizualizar;
}

public visualizarClienteDetalhe():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].clienteDetalhe;
  return vizualizar;
}

public visualizarClienteExcluir():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].clienteExcluir;
  return vizualizar;
}

public visualizarFornecedor():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].visualizarFornecedor;
  if(vizualizar){
    this.nav.visualizarFornecedor();
    return vizualizar;
  }else{
    this.nav.naoVisualizarFornecedor();
    return vizualizar;
  }
}

public visualizarFornecedorCadastro():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].fornecedorCadastro;
  return vizualizar;
}

public visualizarFuncionario():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].visualizarFuncionario;
  if(vizualizar){
    this.nav.visualizarFuncionario();
    return vizualizar;
  }else{
    this.nav.naoVisualizarFuncionario();
    return vizualizar;
  }
}

public visualizarFuncionarioCadastro():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].funcionarioCadastro;
  return vizualizar;
}

public visualizarTransportador():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].visualizarTransportador;
  if(vizualizar){
    this.nav.visualizarTransportador();
    return vizualizar;
  }else{
    this.nav.naoVisualizarTransportador();
    return vizualizar;
  }
}

public visualizarTransportadorCadastro():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].transportadorCadastro;
  return vizualizar;
}

public visualizarUsuario():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].visualizarUsuario;
  if(vizualizar){
    this.nav.visualizarUsuario();
    return vizualizar;
  }else{
    this.nav.naoVisualizarUsuario();
    return vizualizar;
  }
}

public visualizarUsuarioCadastro():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].usuarioCadastro;
  return vizualizar;
}

public visualizarVenda():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].visualizarVenda;
  if(vizualizar){
    this.nav.visualizarVenda();
    return vizualizar;
  }else{
    this.nav.naoVisualizarVenda();
    return vizualizar;
  }
}

public visualizarVendaCadastro():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].vendaCadastro;
  return vizualizar;
}

public visualizarRelatorio():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].visualizarRelatorio;
  if(vizualizar){
    this.nav.visualizarRelatorio();
    return vizualizar;
  }else{
    this.nav.naoVisualizarRelatorio();
    return vizualizar;
  }
}

public visualizarRelatorioCadastro():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].relatorioCadastro;
  return vizualizar;
}

public verificaPermissaoEmpresas():boolean{
  var validaAdministrador = this.empresaId();
  if(validaAdministrador == Permissoes.Administrador){
    return true;
  }else{
    return false;
  }
}

public visualizarEmpresaCadastro():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].empresaCadastro;
  return vizualizar;
}

}
