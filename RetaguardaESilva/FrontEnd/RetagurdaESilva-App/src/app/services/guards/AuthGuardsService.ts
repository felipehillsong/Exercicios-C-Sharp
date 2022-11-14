import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../auth.service';
import { NavService } from '../nav.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardsService implements CanActivate {

constructor(private router: Router, private authService: AuthService, public nav: NavService) { }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    if(sessionStorage.getItem('loginRetorno') != null){
      return true;
    }
    else{
      this.router.navigate(['login']);
      sessionStorage.clear();
      return false;
    }
  }

  clearStorage(){
    this.nav.hide();
    sessionStorage.clear();
    this.router.navigate(['login']);
  }

  canActivateEmpresa(): boolean {
    if(this.authService.empresaId() == 1){
      return true;
    }else{
      return false;
    }
  }
  
  }

