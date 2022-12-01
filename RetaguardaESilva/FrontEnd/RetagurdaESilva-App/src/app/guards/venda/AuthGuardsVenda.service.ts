import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthService } from '../../services/login/auth.service';



@Injectable({
  providedIn: 'root'
})
export class AuthGuardsVendaService implements CanActivate {

  constructor(private authService: AuthService) { }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    var visualizarVenda = this.authService.permissoesDoUsuario()[0].visualizarVenda;
    return visualizarVenda;
  }

}
