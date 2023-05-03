import { Component, Input, OnInit } from '@angular/core';
import { FontAwesome } from 'src/app/enums/fontAwesome';
import { Titulos } from 'src/app/enums/titulos';
import { AuthService } from 'src/app/services/login/auth.service';
import { NavService } from 'src/app/services/nav/nav.service';
import { TituloService } from 'src/app/services/titulo/titulo.service';

@Component({
  selector: 'app-gerarRelatorio',
  templateUrl: './gerarRelatorio.component.html',
  styleUrls: ['./gerarRelatorio.component.scss']
})
export class GerarRelatorioComponent implements OnInit {
  titulo =  Titulos.gerarRelatorio;
  iconClass = FontAwesome.listaUsuario;
  constructor(private authService: AuthService, public titu: TituloService, public nav: NavService) { }

  ngOnInit() {
    this.permissoesDeTela();
  }

  permissoesDeTela(){
    this.authService.verificaAdministrador();
    this.authService.visualizarCliente();
    this.authService.visualizarEstoque();
    this.authService.visualizarEnderecoProduto();
    this.authService.visualizarFornecedor();
    this.authService.visualizarFuncionario();
    this.authService.visualizarProduto();
    this.authService.visualizarTransportador();
    this.authService.visualizarRelatorio();
    this.authService.visualizarUsuario();
    this.authService.visualizarPedido();
    this.authService.visualizarNotaFiscal();
    this.authService.visualizarRelatorio();
    this.nav.show();
    this.titu.show();
    this.titu.hideTitulo();
  }

}
