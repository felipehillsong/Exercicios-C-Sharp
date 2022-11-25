import { Component, Input, OnInit, Output } from '@angular/core';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { Permissoes } from 'src/app/enums/permissoes';
import { AuthService } from 'src/app/services/auth.service';
import { TituloService } from 'src/app/services/titulo.service';

@Component({
  selector: 'app-titulo',
  templateUrl: './titulo.component.html',
  styleUrls: ['./titulo.component.scss']
})
export class TituloComponent implements OnInit {
  @Input() titulo!: string;
  @Input() iconClass!: string;
  @Input() novo!: string;
  visualizarCadastros!: boolean;

  constructor(public titu: TituloService, private authService: AuthService) { }

  ngOnInit() {
    this.ValidacaoCadastros();
  }

  public ValidacaoCadastros():boolean{
    switch(window.location.pathname){
      case Permissoes.CadastroCliente:
        this.visualizarCadastros = this.authService.visualizarClienteCadastro();
        break;
      case Permissoes.CadastroFornecedor:
        this.visualizarCadastros = this.authService.visualizarFornecedorCadastro();
        break;
      case Permissoes.CadastroFuncionario:
        this.visualizarCadastros = this.authService.visualizarFuncionarioCadastro();
        break;
      case Permissoes.CadastroTransportador:
        this.visualizarCadastros = this.authService.visualizarTransportadorCadastro();
        break;
      case Permissoes.CadastroEmpresa:
        this.visualizarCadastros = this.authService.visualizarEmpresaCadastro();
        break;
      case Permissoes.CadastroUsuario:
        this.visualizarCadastros = this.authService.visualizarUsuarioCadastro();
        break;
      case Permissoes.CadastroVenda:
        this.visualizarCadastros = this.authService.visualizarVendaCadastro();
        break;
      case Permissoes.CadastroRelatorios:
        this.visualizarCadastros = this.authService.visualizarRelatorioCadastro();
        break;
    }
    return this.visualizarCadastros;
  }

}
