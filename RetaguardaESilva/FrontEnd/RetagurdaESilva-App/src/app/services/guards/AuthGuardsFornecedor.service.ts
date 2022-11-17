import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot } from '@angular/router';
import { AuthService } from '../auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardsFornecedorService implements CanActivate {

constructor(private authService: AuthService) { }
canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
  var vizualizarFornecedor = this.authService.permissoesDoUsuario()[0].visualizarFornecedor;
  return vizualizarFornecedor;
}

}
