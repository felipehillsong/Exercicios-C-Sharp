import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class NavService {
  visible: boolean;
  visibleEmpresa: boolean;

constructor() {this.visible = false; this.visibleEmpresa = false; }
  hide() { return this.visible = false; }

  show() { return this.visible = true; }

  toggle() { return this.visible = !this.visible; }

  hideEmpresa() { this.visibleEmpresa = false; }

  showEmpresa() { this.visibleEmpresa = true; }

  toggleEmpresa() { this.visibleEmpresa = !this.visibleEmpresa; }
}
