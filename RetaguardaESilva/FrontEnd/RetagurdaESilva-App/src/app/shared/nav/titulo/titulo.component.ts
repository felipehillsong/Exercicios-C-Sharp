import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Permissoes } from 'src/app/enums/permissoes';
import { AuthService } from 'src/app/services/login/auth.service';
import { TituloService } from 'src/app/services/titulo/titulo.service';

@Component({
  selector: 'app-titulo',
  templateUrl: './titulo.component.html',
  styleUrls: ['./titulo.component.scss']
})
export class TituloComponent implements OnInit {
  @Input() titulo!: string;
  @Input() iconClass!: string;
  @Input() novo!: string;
  @Output() validarCrud = new EventEmitter<boolean[]>();
  visualizarCadastros!: boolean;

  constructor(public titu: TituloService, private authService: AuthService) { }

  ngOnInit() {
    this.ValidacaoCadastros();
  }

  public ValidacaoCadastros():boolean{
    switch(window.location.pathname){
      case Permissoes.CadastroCliente:
        this.visualizarCadastros = this.authService.visualizarClienteCadastro();
        this.validarCrud.emit([this.authService.visualizarClienteEditar(), this.authService.visualizarClienteDetalhe(), this.authService.visualizarClienteExcluir()]);
        break;
      case Permissoes.CadastroFornecedor:
        this.visualizarCadastros = this.authService.visualizarFornecedorCadastro();
        this.validarCrud.emit([this.authService.visualizarFornecedorEditar(), this.authService.visualizarFornecedorDetalhe(), this.authService.visualizarFornecedorExcluir()]);
        break;
      case Permissoes.CadastroFuncionario:
        this.visualizarCadastros = this.authService.visualizarFuncionarioCadastro();
        this.validarCrud.emit([this.authService.visualizarFuncionarioEditar(), this.authService.visualizarFuncionarioDetalhe(), this.authService.visualizarFuncionarioExcluir()]);
        break;
        case Permissoes.CadastroEstoque:
        this.validarCrud.emit([this.authService.visualizarEstoqueEditar(), this.authService.visualizarEstoqueDetalhe(), this.authService.visualizarEstoqueExcluir()]);
        break;
      case Permissoes.CadastroTransportador:
        this.visualizarCadastros = this.authService.visualizarTransportadorCadastro();
        this.validarCrud.emit([this.authService.visualizarTransportadorEditar(), this.authService.visualizarTransportadorDetalhe(), this.authService.visualizarTransportadorExcluir()]);
        break;
      case Permissoes.CadastroProduto:
        this.visualizarCadastros = this.authService.visualizarProdutoCadastro();
        this.validarCrud.emit([this.authService.visualizarProdutoEditar(), this.authService.visualizarProdutoDetalhe(), this.authService.visualizarProdutoExcluir()]);
        break;
      case Permissoes.CadastroEmpresa:
        this.visualizarCadastros = this.authService.visualizarEmpresaCadastro();
        this.validarCrud.emit([this.authService.visualizarEmpresaEditar(), this.authService.visualizarEmpresaDetalhe(), this.authService.visualizarEmpresaExcluir()]);
        break;
      case Permissoes.CadastroUsuario:
        this.visualizarCadastros = this.authService.visualizarUsuarioCadastro();
        this.validarCrud.emit([this.authService.visualizarUsuarioEditar(), this.authService.visualizarUsuarioPermissoes(), this.authService.visualizarUsuarioExcluir()]);
        break;
      case Permissoes.CadastroVenda:
        this.visualizarCadastros = this.authService.visualizarVendaCadastro();
        this.validarCrud.emit([this.authService.visualizarVendaEditar(), this.authService.visualizarVendaDetalhe(), this.authService.visualizarVendaExcluir()]);
        break;
      case Permissoes.CadastroRelatorios:
        this.visualizarCadastros = this.authService.visualizarRelatorioCadastro();
        this.validarCrud.emit([this.authService.visualizarRelatorioEditar(), this.authService.visualizarRelatorioDetalhe(), this.authService.visualizarRelatorioExcluir()]);
        break;
    }
    return this.visualizarCadastros;
  }

}
