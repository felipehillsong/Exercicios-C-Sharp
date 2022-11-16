import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { NavService } from 'src/app/services/nav.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  nomeDaEmpresa!:string;
  constructor(private authService: AuthService, public nav: NavService) { }

  ngOnInit() {
    this.permissoesDeTela();
    this.nomeDaEmpresa = this.authService.nomeEmpresa();
  }

  permissoesDeTela(){
    this.authService.verificaAdministrador();
    this.authService.visualizarCliente();
    this.nav.show();
  }

}
