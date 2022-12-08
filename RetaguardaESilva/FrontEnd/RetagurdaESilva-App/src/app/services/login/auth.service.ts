import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Permissoes } from '../../enums/permissoes';
import { Permissao } from '../../models/permissao';
import { Usuario } from '../../models/usuario';
import { NavService } from './../nav/nav.service';

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

public visualizarFornecedorEditar():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].fornecedorEditar;
  return vizualizar;
}

public visualizarFornecedorDetalhe():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].fornecedorDetalhe;
  return vizualizar;
}

public visualizarFornecedorExcluir():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].fornecedorExcluir;
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

public visualizarFuncionarioEditar():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].funcionarioEditar;
  return vizualizar;
}

public visualizarFuncionarioDetalhe():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].funcionarioDetalhe;
  return vizualizar;
}

public visualizarFuncionarioExcluir():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].funcionarioExcluir;
  return vizualizar;
}

public visualizarProduto():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].visualizarProduto;
  if(vizualizar){
    this.nav.visualizarProduto();
    return vizualizar;
  }else{
    this.nav.naoVisualizarProduto();
    return vizualizar;
  }
}

public visualizarProdutoCadastro():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].produtoCadastro;
  return vizualizar;
}

public visualizarProdutoEditar():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].produtoEditar;
  return vizualizar;
}

public visualizarProdutoDetalhe():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].produtoDetalhe;
  return vizualizar;
}

public visualizarProdutoExcluir():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].produtoExcluir;
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

public visualizarTransportadorEditar():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].transportadorEditar;
  return vizualizar;
}

public visualizarTransportadorDetalhe():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].transportadorDetalhe;
  return vizualizar;
}

public visualizarTransportadorExcluir():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].transportadorExcluir;
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

public visualizarUsuarioEditar():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].usuarioEditar;
  return vizualizar;
}

public visualizarUsuarioPermissoes():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].usuarioPermissoes;
  return vizualizar;
}

public visualizarUsuarioExcluir():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].usuarioExcluir;
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

public visualizarVendaEditar():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].vendaEditar;
  return vizualizar;
}

public visualizarVendaDetalhe():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].vendaDetalhe;
  return vizualizar;
}

public visualizarVendaExcluir():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].vendaExcluir;
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

public visualizarRelatorioEditar():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].relatorioEditar;
  return vizualizar;
}

public visualizarRelatorioDetalhe():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].relatorioDetalhe;
  return vizualizar;
}

public visualizarRelatorioExcluir():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].relatorioExcluir;
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

public visualizarEmpresaEditar():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].empresaEditar;
  return vizualizar;
}

public visualizarEmpresaDetalhe():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].empresaDetalhe;
  return vizualizar;
}

public visualizarEmpresaExcluir():boolean{
  var vizualizar = this.permissoesDoUsuario()[0].empresaExcluir;
  return vizualizar;
}

}