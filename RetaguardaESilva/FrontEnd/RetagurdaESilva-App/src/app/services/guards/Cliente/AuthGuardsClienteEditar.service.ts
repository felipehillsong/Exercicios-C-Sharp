import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthService } from '../../login/auth.service';

@Injectable()
export class AuthGuardsClienteEditarService implements CanActivate {

  constructor(private authService: AuthService) { }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    var visualizarCliente = this.authService.permissoesDoUsuario()[0].clienteEditar;
    return visualizarCliente;
  }

}
