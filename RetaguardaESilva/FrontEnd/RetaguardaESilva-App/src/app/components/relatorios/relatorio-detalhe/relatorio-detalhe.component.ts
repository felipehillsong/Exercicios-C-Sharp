import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import * as moment from 'moment';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Cliente } from 'src/app/models/cliente';
import { Empresa } from 'src/app/models/empresa';
import { Fornecedor } from 'src/app/models/fornecedor';
import { Funcionario } from 'src/app/models/funcionario';
import { Produto } from 'src/app/models/produto';
import { Transportador } from 'src/app/models/transportador';
import { Usuario } from 'src/app/models/usuario';
import { AuthService } from 'src/app/services/login/auth.service';
import { NavService } from 'src/app/services/nav/nav.service';
import { RelatorioService } from 'src/app/services/relatorio/relatorio.service';
import { TituloService } from 'src/app/services/titulo/titulo.service';

@Component({
  selector: 'app-relatorio-detalhe',
  templateUrl: './relatorio-detalhe.component.html',
  styleUrls: ['./relatorio-detalhe.component.scss']
})
export class RelatorioDetalheComponent implements OnInit {
  public clientes: Cliente[] = [];
  public fornecedores: Fornecedor[] = [];
  public funcionarios: Funcionario[] = [];
  public transportadores: Transportador[] = [];
  public usuarios: Usuario[] = [];
  public empresas: Empresa[] = [];
  public produtos: Produto[] = [];
  codigoRelatorio!:number;
  dataInicio!:string;
  dataFinal!:string;
  constructor(private router: Router, private route: ActivatedRoute, private toastr: ToastrService, private spinner: NgxSpinnerService, private authService: AuthService, private relatorioService: RelatorioService, public titu: TituloService, public nav: NavService, private fb: FormBuilder) { }

  ngOnInit() {
    this.permissoesDeTela();
    this.Relatorio();
  }

  public Relatorio():void{
    this.codigoRelatorio = parseInt(this.route.snapshot.params['codigoRelatorio']);
    this.dataInicio = this.route.snapshot.params['dataInicio'];
    this.dataFinal = this.route.snapshot.params['dataFinal'];
    if(this.dataInicio != "null" && this.dataFinal != "null"){
      this.dataInicio = moment(this.dataInicio).format('DD/MM/YYYY');
      this.dataFinal = moment(this.dataFinal).format('DD/MM/YYYY');
    }
    switch (this.codigoRelatorio) {
      case 1:
        this.relatorioService.getRelatorioCliente(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_clientes: Cliente[]) => {
            this.clientes = _clientes;
          },
          error => console.log(error)
        );
          break;
      case 2:
        this.relatorioService.getRelatorioCliente(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_clientes: Cliente[]) => {
            this.clientes = _clientes;
          },
          error => console.log(error)
        );
          break;
      case 3:
        this.relatorioService.getRelatorioCliente(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_clientes: Cliente[]) => {
            this.clientes = _clientes;
          },
          error => console.log(error)
        );
          break;
      case 4:
        this.relatorioService.getRelatorioCliente(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_clientes: Cliente[]) => {
            this.clientes = _clientes;
          },
          error => console.log(error)
        );
          break;
      case 5:
        this.relatorioService.getRelatorioFornecedores(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_fornecedores: Fornecedor[]) => {
            this.fornecedores = _fornecedores;
          },
          error => console.log(error)
        );
          break;
      case 6:
        this.relatorioService.getRelatorioFornecedores(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_fornecedores: Fornecedor[]) => {
            this.fornecedores = _fornecedores;
          },
          error => console.log(error)
        );
          break;
      case 7:
        this.relatorioService.getRelatorioFornecedores(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_fornecedores: Fornecedor[]) => {
            this.fornecedores = _fornecedores;
          },
          error => console.log(error)
        );
          break;
      case 8:
        this.relatorioService.getRelatorioFornecedores(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_fornecedores: Fornecedor[]) => {
            this.fornecedores = _fornecedores;
          },
          error => console.log(error)
        );
          break;
      case 9:
            this.relatorioService.getRelatorioFornecedoresProdutos(this.codigoRelatorio).subscribe(
              (_fornecedores: Fornecedor[]) => {
                this.fornecedores = _fornecedores;
              },
              error => console.log(error)
            );
              break;
      case 10:
            this.relatorioService.getRelatorioFornecedoresProdutos(this.codigoRelatorio).subscribe(
              (_fornecedores: Fornecedor[]) => {
                this.fornecedores = _fornecedores;
              },
              error => console.log(error)
            );
              break;
      case 11:
            this.relatorioService.getRelatorioFornecedoresProdutos(this.codigoRelatorio).subscribe(
              (_fornecedores: Fornecedor[]) => {
                this.fornecedores = _fornecedores;
              },
              error => console.log(error)
            );
              break;
      case 12:
            this.relatorioService.getRelatorioFornecedoresProdutos(this.codigoRelatorio).subscribe(
              (_fornecedores: Fornecedor[]) => {
                this.fornecedores = _fornecedores;
              },
              error => console.log(error)
            );
              break;
      case 13:
            this.relatorioService.getRelatorioFornecedoresProdutos(this.codigoRelatorio).subscribe(
              (_fornecedores: Fornecedor[]) => {
                this.fornecedores = _fornecedores;
              },
              error => console.log(error)
            );
              break;
      case 14:
            this.relatorioService.getRelatorioFornecedoresProdutos(this.codigoRelatorio).subscribe(
              (_fornecedores: Fornecedor[]) => {
                this.fornecedores = _fornecedores;
              },
              error => console.log(error)
            );
              break;
    case 15:
            this.relatorioService.getRelatorioFornecedoresProdutos(this.codigoRelatorio).subscribe(
              (_fornecedores: Fornecedor[]) => {
                this.fornecedores = _fornecedores;
              },
              error => console.log(error)
            );
              break;
    case 16:
            this.relatorioService.getRelatorioFornecedoresProdutos(this.codigoRelatorio).subscribe(
              (_fornecedores: Fornecedor[]) => {
                this.fornecedores = _fornecedores;
              },
              error => console.log(error)
            );
              break;
    case 17:
            this.relatorioService.getRelatorioFornecedoresProdutos(this.codigoRelatorio).subscribe(
              (_fornecedores: Fornecedor[]) => {
                this.fornecedores = _fornecedores;
              },
              error => console.log(error)
            );
              break;
      case 18:
            this.relatorioService.getRelatorioFornecedoresProdutos(this.codigoRelatorio).subscribe(
              (_fornecedores: Fornecedor[]) => {
                this.fornecedores = _fornecedores;
              },
              error => console.log(error)
            );
              break;
    case 19:
            this.relatorioService.getRelatorioFornecedoresProdutos(this.codigoRelatorio).subscribe(
              (_fornecedores: Fornecedor[]) => {
                this.fornecedores = _fornecedores;
              },
              error => console.log(error)
            );
              break;
    case 20:
            this.relatorioService.getRelatorioFornecedoresProdutos(this.codigoRelatorio).subscribe(
              (_fornecedores: Fornecedor[]) => {
                this.fornecedores = _fornecedores;
              },
              error => console.log(error)
            );
              break;
    case 21:
        this.relatorioService.getRelatorioFuncionarios(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_funcionarios: Funcionario[]) => {
            this.funcionarios = _funcionarios;
          },
          error => console.log(error)
        );
          break;
      case 22:
        this.relatorioService.getRelatorioFuncionarios(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_funcionarios: Funcionario[]) => {
            this.funcionarios = _funcionarios;
          },
          error => console.log(error)
        );
          break;
      case 23:
        this.relatorioService.getRelatorioFuncionarios(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_funcionarios: Funcionario[]) => {
            this.funcionarios = _funcionarios;
          },
          error => console.log(error)
        );
          break;
      case 24:
        this.relatorioService.getRelatorioFuncionarios(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_funcionarios: Funcionario[]) => {
            this.funcionarios = _funcionarios;
          },
          error => console.log(error)
        );
          break;
      case 25:
        this.relatorioService.getRelatorioTransportadores(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_transportadores: Transportador[]) => {
            this.transportadores = _transportadores;
          },
          error => console.log(error)
        );
          break;
      case 26:
        this.relatorioService.getRelatorioTransportadores(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_transportadores: Transportador[]) => {
            this.transportadores = _transportadores;
          },
          error => console.log(error)
        );
          break;
      case 27:
        this.relatorioService.getRelatorioTransportadores(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_transportadores: Transportador[]) => {
            this.transportadores = _transportadores;
          },
          error => console.log(error)
        );
          break;
      case 28:
        this.relatorioService.getRelatorioTransportadores(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_transportadores: Transportador[]) => {
            this.transportadores = _transportadores;
          },
          error => console.log(error)
        );
          break;
      case 29:
        this.relatorioService.getRelatorioUsuarios(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_usuarios: Usuario[]) => {
            this.usuarios = _usuarios;
            console.log(this.usuarios);
          },
          error => console.log(error)
        );
          break;
      case 30:
        this.relatorioService.getRelatorioEmpresas(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_empresas: Empresa[]) => {
            this.empresas = _empresas;
          },
          error => console.log(error)
        );
          break;
      case 31:
        this.relatorioService.getRelatorioEmpresas(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_empresas: Empresa[]) => {
            this.empresas = _empresas;
          },
          error => console.log(error)
        );
          break;
      case 32:
        this.relatorioService.getRelatorioEmpresas(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_empresas: Empresa[]) => {
            this.empresas = _empresas;
          },
          error => console.log(error)
        );
          break;
      case 33:
        this.relatorioService.getRelatorioEmpresas(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_empresas: Empresa[]) => {
            this.empresas = _empresas;
          },
          error => console.log(error)
        );
          break;
      case 34:
        this.relatorioService.getRelatorioProdutos(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_produtos: Produto[]) => {
            this.produtos = _produtos;
          },
          error => console.log(error)
        );
          break;
      case 35:
        this.relatorioService.getRelatorioProdutos(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_produtos: Produto[]) => {
            this.produtos = _produtos;
          },
          error => console.log(error)
        );
          break;
      case 36:
        this.relatorioService.getRelatorioProdutos(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_produtos: Produto[]) => {
            this.produtos = _produtos;
          },
          error => console.log(error)
        );
          break;
      case 37:
        this.relatorioService.getRelatorioProdutos(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_produtos: Produto[]) => {
            this.produtos = _produtos;
          },
          error => console.log(error)
        );
          break;
      default:
          alert("Erro ao gerar Relatorio");
          break;
    }

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
