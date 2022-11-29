import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthService } from '../../login/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardsFornecedorDetalheService implements CanActivate {

  constructor(private authService: AuthService) { }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    var fornecedorDetalhe = this.authService.permissoesDoUsuario()[0].fornecedorDetalhe;
    return fornecedorDetalhe;
  }

}
