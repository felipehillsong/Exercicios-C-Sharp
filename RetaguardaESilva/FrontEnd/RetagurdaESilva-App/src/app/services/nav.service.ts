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
  constructor() {this.visible = false; this.visibleEmpresa = false; this.visibleCliente = false; this.visibleFornecedor = false;}
  hide() { return this.visible = false; }

  show() { return this.visible = true; }

  toggle() { return this.visible = !this.visible; }

  visualizarCliente() { return this.visibleCliente = true; }

  naoVisualizarCliente() { return this.visibleCliente = false; }

  visualizarFornecedor() { return this.visibleFornecedor = true; }

  naoVisualizarFornecedor() { return this.visibleFornecedor = false; }

  hideEmpresa() { this.visibleEmpresa = false; }

  showEmpresa() { this.visibleEmpresa = true; }

  toggleEmpresa() { this.visibleEmpresa = !this.visibleEmpresa; }
}
