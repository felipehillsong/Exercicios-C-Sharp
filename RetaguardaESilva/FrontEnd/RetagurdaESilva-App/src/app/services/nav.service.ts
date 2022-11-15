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
  constructor() {this.visible = false; this.visibleEmpresa = false; this.visibleCliente = false;}
  hide() { return this.visible = false; }

  show() { return this.visible = true; }

  toggle() { return this.visible = !this.visible; }

  vizualizarCliente() { return this.visibleCliente = true; }

  naoVizualizarCliente() { return this.visibleCliente = false; }

  hideEmpresa() { this.visibleEmpresa = false; }

  showEmpresa() { this.visibleEmpresa = true; }

  toggleEmpresa() { this.visibleEmpresa = !this.visibleEmpresa; }
}
