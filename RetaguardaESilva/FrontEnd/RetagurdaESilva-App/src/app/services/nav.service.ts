import { Injectable } from '@angular/core';
import { Permissao } from '../models/permissao';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class NavService {
  visible: boolean;
  visibleEmpresa: boolean;
  visibleCliente: boolean;
  visibleFornecedor: boolean;
  visibleFuncionario: boolean;
  visibleTransportador: boolean;
  visibleUsuario: boolean;
  visibleVenda: boolean;
  visibleRelatorio: boolean;
  constructor() {this.visible = false; this.visibleEmpresa = false; this.visibleCliente = false; this.visibleFornecedor = false;
  this.visibleFuncionario = false; this.visibleTransportador = false; this.visibleUsuario = false; this.visibleVenda = false;
  this.visibleRelatorio = false;}
  hide() { return this.visible = false; }

  show() { return this.visible = true; }

  toggle() { return this.visible = !this.visible; }

  visualizarCliente() { return this.visibleCliente = true; }

  naoVisualizarCliente() { return this.visibleCliente = false; }

  visualizarFornecedor() { return this.visibleFornecedor = true; }

  naoVisualizarFornecedor() { return this.visibleFornecedor = false; }

  visualizarFuncionario() { return this.visibleFuncionario = true; }

  naoVisualizarFuncionario() { return this.visibleFuncionario = false; }

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
