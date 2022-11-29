import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/login/auth.service';
import { NavService } from 'src/app/services/nav/nav.service';

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
    this.authService.visualizarFornecedor();
    this.authService.visualizarFuncionario();
    this.authService.visualizarTransportador();
    this.authService.visualizarRelatorio();
    this.authService.visualizarUsuario();
    this.authService.visualizarVenda();
    this.nav.show();
  }

}
