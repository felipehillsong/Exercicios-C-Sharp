import { Injectable } from '@angular/core';
import { Permissao } from '../../models/permissao';
import { AuthService } from './../login/auth.service';

@Injectable({
  providedIn: 'root'
})
export class NavService {
  visible: boolean;
  visibleEmpresa: boolean;
  visibleCliente: boolean;
  visibleFornecedor: boolean;
  visibleFuncionario: boolean;
  visibleEstoque: boolean;
  visibleProduto: boolean;
  visibleTransportador: boolean;
  visibleUsuario: boolean;
  visibleVenda: boolean;
  visibleRelatorio: boolean;
  constructor() {this.visible = false; this.visibleEmpresa = false; this.visibleCliente = false; this.visibleFornecedor = false;
  this.visibleFuncionario = false; this.visibleTransportador = false; this.visibleProduto = false; this.visibleUsuario = false;
   this.visibleVenda = false; this.visibleRelatorio = false; this.visibleEstoque = false;}
  hide() { return this.visible = false; }

  show() { return this.visible = true; }

  toggle() { return this.visible = !this.visible; }

  visualizarCliente() { return this.visibleCliente = true; }

  naoVisualizarCliente() { return this.visibleCliente = false; }

  visualizarEstoque() { return this.visibleEstoque = true; }

  naoVisualizarEstoque() { return this.visibleEstoque = false; }

  visualizarFornecedor() { return this.visibleFornecedor = true; }

  naoVisualizarFornecedor() { return this.visibleFornecedor = false; }

  visualizarFuncionario() { return this.visibleFuncionario = true; }

  naoVisualizarFuncionario() { return this.visibleFuncionario = false; }

  visualizarProduto() { return this.visibleProduto = true; }

  naoVisualizarProduto() { return this.visibleProduto = false; }

  visualizarTransportador() { return this.visibleTransportador = true; }

  naoVisualizarTransportador() { return this.visibleTransportador = false; }

  visualizarUsuario() { return this.visibleUsuario = true; }

  naoVisualizarUsuario() { return this.visibleUsuario = false; }

  visualizarVenda() { return this.visibleVenda = true; }

  naoVisualizarVenda() { return this.visibleVenda = false; }

  visualizarRelatorio() { return this.visibleRelatorio = true; }

  naoVisualizarRelatorio() { return this.visibleRelatorio = false; }

  hideEmpresa() { this.visibleEmpresa = false; }

  showEmpresa() { this.visibleEmpresa = true; }

  toggleEmpresa() { this.visibleEmpresa = !this.visibleEmpresa; }
}
