import { ChangeDetectorRef, Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import * as moment from 'moment';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { FontAwesome } from 'src/app/enums/fontAwesome';
import { Relatorio } from 'src/app/enums/relatorio.enum';
import { Titulos } from 'src/app/enums/titulos';
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
import * as XLSX from 'xlsx';

@Component({
  selector: 'app-gerarRelatorio',
  templateUrl: './gerarRelatorio.component.html',
  styleUrls: ['./gerarRelatorio.component.scss']
})
export class GerarRelatorioComponent implements OnInit {
  titulo =  Titulos.gerarRelatorio;
  iconClass = FontAwesome.listaUsuario;
  form!: FormGroup;
  public clientes: Cliente[] = [];
  public fornecedores: Fornecedor[] = [];
  public funcionarios: Funcionario[] = [];
  public transportadores: Transportador[] = [];
  public usuarios: Usuario[] = [];
  public empresas: Empresa[] = [];
  public produtos: Produto[] = [];
  todosClientes:boolean = false;
  todosFornecedores:boolean = false;
  todosFornecedoresProdutos:boolean = false;
  todosFuncionarios:boolean = false;
  todosTransportadores:boolean = false;
  todosUsuarios:boolean = false;
  todosEmpresas:boolean = false;
  todosProdutos:boolean = false;
  codigoRelatorio!:number;
  dataInicio!:string;
  dataFinal!:string;
  inputData!:boolean;
  dropRelatorio!:boolean;
  divData:boolean = false;
  botaoGerar:boolean = false;
  botaoResetar:boolean = false;
  botaoGerarExcel:boolean = false;
  valorRelatorio: string = '';
  relatorios!: string[]
  fileName= '';


  constructor(private router: Router, private _changeDetectorRef: ChangeDetectorRef, private toastr: ToastrService, private spinner: NgxSpinnerService, private authService: AuthService, private relatorioService: RelatorioService, public titu: TituloService, public nav: NavService, private fb: FormBuilder) { }

  ngOnInit() {
    this.dataInicio = new Date().toISOString().split('T')[0];
    this.dataFinal = new Date().toISOString().split('T')[0];
    this.CarregarDropdown();
    this.permissoesDeTela();
  }

  public CarregarDropdown():string[]{
    return this.relatorios = [
      Relatorio.TodosClientesAtivosInativosExcluidos,
      Relatorio.TodosClientesAtivos,
      Relatorio.TodosClientesInativos,
      Relatorio.TodosClientesExcluidos,
      Relatorio.TodosFornecedoresAtivosInativosExcluidos,
      Relatorio.TodosFornecedoresAtivos,
      Relatorio.TodosFornecedoresInativos,
      Relatorio.TodosFornecedoresExcluidos,
      Relatorio.TodosFornecedoresAtivosProdutosAtivoInativoExcluidos,
      Relatorio.TodosFornecedoresAtivosProdutosAtivos,
      Relatorio.TodosFornecedoresAtivosProdutosInativos,
      Relatorio.TodosFornecedoresAtivosProdutosExcluidos,
      Relatorio.TodosFornecedoresInativosProdutosAtivoInativoExcluidos,
      Relatorio.TodosFornecedoresInativosProdutosAtivos,
      Relatorio.TodosFornecedoresInativosProdutosInativos,
      Relatorio.TodosFornecedoresInativosProdutosExcluidos,
      Relatorio.TodosFornecedoresExcluidosProdutosAtivoInativoExcluidos,
      Relatorio.TodosFornecedoresExcluidosProdutosAtivos,
      Relatorio.TodosFornecedoresExcluidosProdutosInativos,
      Relatorio.TodosFornecedoresExcluidosProdutosExcluidos,
      Relatorio.TodosFuncionariosAtivosInativosExcluidos,
      Relatorio.TodosFuncionariosAtivos,
      Relatorio.TodosFuncionariosInativos,
      Relatorio.TodosFuncionariosExcluidos,
      Relatorio.TodosTransportadoresAtivosInativosExcluidos,
      Relatorio.TodosTransportadoresAtivos,
      Relatorio.TodosTransportadoresInativos,
      Relatorio.TodosTransportadoresExcluidos,
      Relatorio.TodosUsuarios,
      Relatorio.TodosEmpresasAtivosInativosExcluidos,
      Relatorio.TodosEmpresasAtivos,
      Relatorio.TodosEmpresasInativos,
      Relatorio.TodosEmpresasExcluidos,
      Relatorio.TodosProdutosAtivosInativosExcluidos,
      Relatorio.TodosProdutosAtivos,
      Relatorio.TodosProdutosInativos,
      Relatorio.TodosProdutosExcluidos
    ];
  }

  onDropdownChange(value: string) {
    if(value == undefined){
      this.Resetar();
    }
    else if(value == Relatorio.TodosFornecedoresAtivosProdutosAtivoInativoExcluidos || value == Relatorio.TodosFornecedoresAtivosProdutosAtivos || value == Relatorio.TodosFornecedoresAtivosProdutosInativos || value == Relatorio.TodosFornecedoresAtivosProdutosExcluidos || value == Relatorio.TodosFornecedoresInativosProdutosAtivoInativoExcluidos || value == Relatorio.TodosFornecedoresInativosProdutosAtivos || value == Relatorio.TodosFornecedoresInativosProdutosInativos || value == Relatorio.TodosFornecedoresInativosProdutosExcluidos || value == Relatorio.TodosFornecedoresExcluidosProdutosAtivoInativoExcluidos || value == Relatorio.TodosFornecedoresExcluidosProdutosAtivos || value == Relatorio.TodosFornecedoresExcluidosProdutosInativos || value == Relatorio.TodosFornecedoresExcluidosProdutosExcluidos){
      this.divData = false;
      this.dataInicio = 'null';
      this.dataFinal = 'null';
      this.botaoGerar = true;
      this.botaoResetar = false;
    }
    else{
      this.dataInicio = new Date().toISOString().split('T')[0];
      this.dataFinal = new Date().toISOString().split('T')[0];
      this.divData = true;
      this.botaoGerar = true;
      this.botaoResetar = false;
    }
  }

  public Gerar(){
    switch (this.valorRelatorio) {
      case Relatorio.TodosClientesAtivosInativosExcluidos:
          this.codigoRelatorio = 1;
          if(this.dataInicio != "null" && this.dataFinal != "null"){
            this.dataInicio = moment(this.dataInicio).format('DD/MM/YYYY');
            this.dataFinal = moment(this.dataFinal).format('DD/MM/YYYY');
          }
          this.relatorioService.getRelatorioCliente(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
            (_clientes: Cliente[]) => {
              this.clientes = _clientes;
              this.todosClientes = true;
              this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this.inputData = true;
              this.dropRelatorio = true;
              this.botaoGerar = false;
              this.botaoResetar = true;
              this.botaoGerarExcel = true;
              this.fileName = Relatorio.TodosClientesAtivosInativosExcluidos + '.xlsx';
              this._changeDetectorRef.markForCheck();
            },
            error => {
              this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this._changeDetectorRef.markForCheck();
              alert(error.error)
            }
          );
            break;
      case Relatorio.TodosClientesAtivos:
        this.codigoRelatorio = 2;
          if(this.dataInicio != "null" && this.dataFinal != "null"){
            this.dataInicio = moment(this.dataInicio).format('DD/MM/YYYY');
            this.dataFinal = moment(this.dataFinal).format('DD/MM/YYYY');
          }
          this.relatorioService.getRelatorioCliente(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
            (_clientes: Cliente[]) => {
              this.clientes = _clientes;
              this.todosClientes = true;
              this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this.inputData = true;
              this.dropRelatorio = true;
              this.botaoGerar = false;
              this.botaoResetar = true;
              this.botaoGerarExcel = true;
              this.fileName = Relatorio.TodosClientesAtivos + '.xlsx';
              this._changeDetectorRef.markForCheck();
            },
            error => {
              this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this._changeDetectorRef.markForCheck();
              alert(error.error)
            }
          );
            break;
      case Relatorio.TodosClientesInativos:
        this.codigoRelatorio = 3;
        if(this.dataInicio != "null" && this.dataFinal != "null"){
          this.dataInicio = moment(this.dataInicio).format('DD/MM/YYYY');
          this.dataFinal = moment(this.dataFinal).format('DD/MM/YYYY');
        }
        this.relatorioService.getRelatorioCliente(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_clientes: Cliente[]) => {
            this.clientes = _clientes;
            this.todosClientes = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputData = true;
            this.dropRelatorio = true;
            this.botaoGerar = false;
            this.botaoResetar = true;
            this.botaoGerarExcel = true;
            this.fileName = Relatorio.TodosClientesInativos + '.xlsx';
            this._changeDetectorRef.markForCheck();
          },
          error => {
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this._changeDetectorRef.markForCheck();
            alert(error.error)
          }
        );
          break;
      case Relatorio.TodosClientesExcluidos:
        this.codigoRelatorio = 4;
        if(this.dataInicio != "null" && this.dataFinal != "null"){
          this.dataInicio = moment(this.dataInicio).format('DD/MM/YYYY');
          this.dataFinal = moment(this.dataFinal).format('DD/MM/YYYY');
        }
        this.relatorioService.getRelatorioCliente(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_clientes: Cliente[]) => {
            this.clientes = _clientes;
            this.todosClientes = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputData = true;
            this.dropRelatorio = true;
            this.botaoGerar = false;
            this.botaoResetar = true;
            this.botaoGerarExcel = true;
            this.fileName = Relatorio.TodosClientesExcluidos + '.xlsx';
            this._changeDetectorRef.markForCheck();
          },
          error => {
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this._changeDetectorRef.markForCheck();
            alert(error.error)
          }
        );
          break;
      case Relatorio.TodosFornecedoresAtivosInativosExcluidos:
          this.codigoRelatorio = 5;
          if(this.dataInicio != "null" && this.dataFinal != "null"){
            this.dataInicio = moment(this.dataInicio).format('DD/MM/YYYY');
            this.dataFinal = moment(this.dataFinal).format('DD/MM/YYYY');
          }
          this.relatorioService.getRelatorioFornecedores(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
            (_fornecedores: Fornecedor[]) => {
              this.fornecedores = _fornecedores;
              this.todosFornecedores = true;
              this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this.inputData = true;
              this.dropRelatorio = true;
              this.botaoGerar = false;
              this.botaoResetar = true;
              this.botaoGerarExcel = true;
              this.fileName = Relatorio.TodosFornecedoresAtivosInativosExcluidos + '.xlsx';
              this._changeDetectorRef.markForCheck();
            },
            error => {
              this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this._changeDetectorRef.markForCheck();
              alert(error.error)
            }
          );
            break;
      case Relatorio.TodosFornecedoresAtivos:
        this.codigoRelatorio = 6;
        if(this.dataInicio != "null" && this.dataFinal != "null"){
          this.dataInicio = moment(this.dataInicio).format('DD/MM/YYYY');
          this.dataFinal = moment(this.dataFinal).format('DD/MM/YYYY');
        }
        this.relatorioService.getRelatorioFornecedores(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_fornecedores: Fornecedor[]) => {
            this.fornecedores = _fornecedores;
            this.todosFornecedores = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputData = true;
            this.dropRelatorio = true;
            this.botaoGerar = false;
            this.botaoResetar = true;
            this.botaoGerarExcel = true;
            this.fileName = Relatorio.TodosFornecedoresAtivos + '.xlsx';
            this._changeDetectorRef.markForCheck();
          },
          error => {
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this._changeDetectorRef.markForCheck();
            alert(error.error)
          }
        );
          break;
      case Relatorio.TodosFornecedoresInativos:
        this.codigoRelatorio = 7;
        if(this.dataInicio != "null" && this.dataFinal != "null"){
          this.dataInicio = moment(this.dataInicio).format('DD/MM/YYYY');
          this.dataFinal = moment(this.dataFinal).format('DD/MM/YYYY');
        }
        this.relatorioService.getRelatorioFornecedores(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_fornecedores: Fornecedor[]) => {
            this.fornecedores = _fornecedores;
            this.todosFornecedores = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputData = true;
            this.dropRelatorio = true;
            this.botaoGerar = false;
            this.botaoResetar = true;
            this.botaoGerarExcel = true;
            this.fileName = Relatorio.TodosFornecedoresInativos + '.xlsx';
            this._changeDetectorRef.markForCheck();
          },
          error => {
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this._changeDetectorRef.markForCheck();
            alert(error.error)
          }
        );
          break;
      case Relatorio.TodosFornecedoresExcluidos:
        this.codigoRelatorio = 8;
        if(this.dataInicio != "null" && this.dataFinal != "null"){
          this.dataInicio = moment(this.dataInicio).format('DD/MM/YYYY');
          this.dataFinal = moment(this.dataFinal).format('DD/MM/YYYY');
        }
        this.relatorioService.getRelatorioFornecedores(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_fornecedores: Fornecedor[]) => {
            this.fornecedores = _fornecedores;
            this.todosFornecedores = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputData = true;
            this.dropRelatorio = true;
            this.botaoGerar = false;
            this.botaoResetar = true;
            this.botaoGerarExcel = true;
            this.fileName = Relatorio.TodosFornecedoresExcluidos + '.xlsx';
            this._changeDetectorRef.markForCheck();
          },
          error => {
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this._changeDetectorRef.markForCheck();
            alert(error.error)
          }
        );
          break;
      case Relatorio.TodosFornecedoresAtivosProdutosAtivoInativoExcluidos:
        this.codigoRelatorio = 9;
        this.relatorioService.getRelatorioFornecedoresProdutos(this.codigoRelatorio).subscribe(
          (_fornecedores: Fornecedor[]) => {
            this.fornecedores = _fornecedores;
            this.todosFornecedoresProdutos = true;
            this.dropRelatorio = true;
            this.botaoGerar = false;
            this.botaoResetar = true;
            this.botaoGerarExcel = true;
            this.fileName = Relatorio.TodosFornecedoresAtivosProdutosAtivoInativoExcluidos + '.xlsx';
            this._changeDetectorRef.markForCheck();
          },
          error => alert(error.error)
        );
          break;
      case Relatorio.TodosFornecedoresAtivosProdutosAtivos:
          this.codigoRelatorio = 10;
          this.relatorioService.getRelatorioFornecedoresProdutos(this.codigoRelatorio).subscribe(
            (_fornecedores: Fornecedor[]) => {
              this.fornecedores = _fornecedores;
              this.todosFornecedoresProdutos = true;
              this.dropRelatorio = true;
              this.botaoGerar = false;
              this.botaoResetar = true;
              this.botaoGerarExcel = true;
              this.fileName = Relatorio.TodosFornecedoresAtivosProdutosAtivos + '.xlsx';
              this._changeDetectorRef.markForCheck();
            },
            error => alert(error.error)
          );
            break;
      case Relatorio.TodosFornecedoresAtivosProdutosInativos:
        this.codigoRelatorio = 11;
        this.relatorioService.getRelatorioFornecedoresProdutos(this.codigoRelatorio).subscribe(
          (_fornecedores: Fornecedor[]) => {
            this.fornecedores = _fornecedores;
            this.todosFornecedoresProdutos = true;
            this.dropRelatorio = true;
            this.botaoGerar = false;
            this.botaoResetar = true;
            this.botaoGerarExcel = true;
            this.fileName = Relatorio.TodosFornecedoresAtivosProdutosInativos + '.xlsx';
            this._changeDetectorRef.markForCheck();
          },
          error => alert(error.error)
        );
          break;
      case Relatorio.TodosFornecedoresAtivosProdutosExcluidos:
        this.codigoRelatorio = 12;
        this.relatorioService.getRelatorioFornecedoresProdutos(this.codigoRelatorio).subscribe(
          (_fornecedores: Fornecedor[]) => {
            this.fornecedores = _fornecedores;
            this.todosFornecedoresProdutos = true;
            this.dropRelatorio = true;
            this.botaoGerar = false;
            this.botaoResetar = true;
            this.botaoGerarExcel = true;
            this.fileName = Relatorio.TodosFornecedoresAtivosProdutosExcluidos + '.xlsx';
            this._changeDetectorRef.markForCheck();
          },
          error => alert(error.error)
        );
          break;
      case Relatorio.TodosFornecedoresInativosProdutosAtivoInativoExcluidos:
        this.codigoRelatorio = 13;
        this.relatorioService.getRelatorioFornecedoresProdutos(this.codigoRelatorio).subscribe(
          (_fornecedores: Fornecedor[]) => {
            this.fornecedores = _fornecedores;
            this.todosFornecedoresProdutos = true;
            this.dropRelatorio = true;
            this.botaoGerar = false;
            this.botaoResetar = true;
            this.botaoGerarExcel = true;
            this.fileName = Relatorio.TodosFornecedoresInativosProdutosAtivoInativoExcluidos + '.xlsx';
            this._changeDetectorRef.markForCheck();
          },
          error => alert(error.error)
        );
          break;
      case Relatorio.TodosFornecedoresInativosProdutosAtivos:
          this.codigoRelatorio = 14;
          this.relatorioService.getRelatorioFornecedoresProdutos(this.codigoRelatorio).subscribe(
            (_fornecedores: Fornecedor[]) => {
              this.fornecedores = _fornecedores;
              this.todosFornecedoresProdutos = true;
              this.dropRelatorio = true;
              this.botaoGerar = false;
              this.botaoResetar = true;
              this.botaoGerarExcel = true;
              this.fileName = Relatorio.TodosFornecedoresInativosProdutosAtivos + '.xlsx';
              this._changeDetectorRef.markForCheck();
            },
            error => alert(error.error)
          );
            break;
      case Relatorio.TodosFornecedoresInativosProdutosInativos:
        this.codigoRelatorio = 15;
        this.relatorioService.getRelatorioFornecedoresProdutos(this.codigoRelatorio).subscribe(
          (_fornecedores: Fornecedor[]) => {
            this.fornecedores = _fornecedores;
            this.todosFornecedoresProdutos = true;
            this.dropRelatorio = true;
            this.botaoGerar = false;
            this.botaoResetar = true;
            this.botaoGerarExcel = true;
            this.fileName = Relatorio.TodosFornecedoresInativosProdutosInativos + '.xlsx';
            this._changeDetectorRef.markForCheck();
          },
          error => alert(error.error)
        );
          break;
      case Relatorio.TodosFornecedoresInativosProdutosExcluidos:
        this.codigoRelatorio = 16;
        this.relatorioService.getRelatorioFornecedoresProdutos(this.codigoRelatorio).subscribe(
          (_fornecedores: Fornecedor[]) => {
            this.fornecedores = _fornecedores;
            this.todosFornecedoresProdutos = true;
            this.dropRelatorio = true;
            this.botaoGerar = false;
            this.botaoResetar = true;
            this.botaoGerarExcel = true;
            this.fileName = Relatorio.TodosFornecedoresInativosProdutosExcluidos + '.xlsx';
            this._changeDetectorRef.markForCheck();
          },
          error => alert(error.error)
        );
          break;
      case Relatorio.TodosFornecedoresExcluidosProdutosAtivoInativoExcluidos:
        this.codigoRelatorio = 17;
        this.relatorioService.getRelatorioFornecedoresProdutos(this.codigoRelatorio).subscribe(
          (_fornecedores: Fornecedor[]) => {
            this.fornecedores = _fornecedores;
            this.todosFornecedoresProdutos = true;
            this.dropRelatorio = true;
            this.botaoGerar = false;
            this.botaoResetar = true;
            this.botaoGerarExcel = true;
            this.fileName = Relatorio.TodosFornecedoresExcluidosProdutosAtivoInativoExcluidos + '.xlsx';
            this._changeDetectorRef.markForCheck();
          },
          error => alert(error.error)
        );
          break;
      case Relatorio.TodosFornecedoresExcluidosProdutosAtivos:
          this.codigoRelatorio = 18;
          this.relatorioService.getRelatorioFornecedoresProdutos(this.codigoRelatorio).subscribe(
            (_fornecedores: Fornecedor[]) => {
              this.fornecedores = _fornecedores;
              this.todosFornecedoresProdutos = true;
              this.dropRelatorio = true;
              this.botaoGerar = false;
              this.botaoResetar = true;
              this.botaoGerarExcel = true;
              this.fileName = Relatorio.TodosFornecedoresExcluidosProdutosAtivos + '.xlsx';
              this._changeDetectorRef.markForCheck();
            },
            error => alert(error.error)
          );
            break;
      case Relatorio.TodosFornecedoresExcluidosProdutosInativos:
        this.codigoRelatorio = 19;
        this.relatorioService.getRelatorioFornecedoresProdutos(this.codigoRelatorio).subscribe(
          (_fornecedores: Fornecedor[]) => {
            this.fornecedores = _fornecedores;
            this.todosFornecedoresProdutos = true;
            this.dropRelatorio = true;
            this.botaoGerar = false;
            this.botaoResetar = true;
            this.botaoGerarExcel = true;
            this.fileName = Relatorio.TodosFornecedoresExcluidosProdutosInativos + '.xlsx';
            this._changeDetectorRef.markForCheck();
          },
          error => alert(error.error)
        );
          break;
      case Relatorio.TodosFornecedoresExcluidosProdutosExcluidos:
        this.relatorioService.getRelatorioFornecedoresProdutos(this.codigoRelatorio).subscribe(
          (_fornecedores: Fornecedor[]) => {
            this.fornecedores = _fornecedores;
            this.todosFornecedoresProdutos = true;
            this.dropRelatorio = true;
            this.botaoGerar = false;
            this.botaoResetar = true;
            this.botaoGerarExcel = true;
            this.fileName = Relatorio.TodosFornecedoresExcluidosProdutosExcluidos + '.xlsx';
            this._changeDetectorRef.markForCheck();
          },
          error => alert(error.error)
        );
          break;
      case Relatorio.TodosFuncionariosAtivosInativosExcluidos:
        this.codigoRelatorio = 21;
        if(this.dataInicio != "null" && this.dataFinal != "null"){
          this.dataInicio = moment(this.dataInicio).format('DD/MM/YYYY');
          this.dataFinal = moment(this.dataFinal).format('DD/MM/YYYY');
        }
        this.relatorioService.getRelatorioFuncionarios(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_funcionarios: Funcionario[]) => {
            this.funcionarios = _funcionarios;
            this.todosFuncionarios = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputData = true;
            this.dropRelatorio = true;
            this.botaoGerar = false;
            this.botaoResetar = true;
            this.botaoGerarExcel = true;
            this.fileName = Relatorio.TodosFuncionariosAtivosInativosExcluidos + '.xlsx';
            this._changeDetectorRef.markForCheck();
          },
          error => {
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this._changeDetectorRef.markForCheck();
            alert(error.error)
          }
        );
          break;
      case Relatorio.TodosFuncionariosAtivos:
          this.codigoRelatorio = 22;
          if(this.dataInicio != "null" && this.dataFinal != "null"){
            this.dataInicio = moment(this.dataInicio).format('DD/MM/YYYY');
            this.dataFinal = moment(this.dataFinal).format('DD/MM/YYYY');
          }
          this.relatorioService.getRelatorioFuncionarios(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
            (_funcionarios: Funcionario[]) => {
              this.funcionarios = _funcionarios;
              this.todosFuncionarios = true;
              this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this.inputData = true;
              this.dropRelatorio = true;
              this.botaoGerar = false;
              this.botaoResetar = true;
              this.botaoGerarExcel = true;
              this.fileName = Relatorio.TodosFuncionariosAtivos + '.xlsx';
              this._changeDetectorRef.markForCheck();
            },
            error => {
              this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this._changeDetectorRef.markForCheck();
              alert(error.error)
            }
          );
            break;
      case Relatorio.TodosFuncionariosInativos:
        this.codigoRelatorio = 23;
        if(this.dataInicio != "null" && this.dataFinal != "null"){
          this.dataInicio = moment(this.dataInicio).format('DD/MM/YYYY');
          this.dataFinal = moment(this.dataFinal).format('DD/MM/YYYY');
        }
        this.relatorioService.getRelatorioFuncionarios(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_funcionarios: Funcionario[]) => {
            this.funcionarios = _funcionarios;
            this.todosFuncionarios = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputData = true;
            this.dropRelatorio = true;
            this.botaoGerar = false;
            this.botaoResetar = true;
            this.botaoGerarExcel = true;
            this.fileName = Relatorio.TodosFuncionariosInativos + '.xlsx';
            this._changeDetectorRef.markForCheck();
          },
          error => {
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this._changeDetectorRef.markForCheck();
            alert(error.error)
          }
        );
          break;
      case Relatorio.TodosFuncionariosExcluidos:
        this.codigoRelatorio = 24;
        if(this.dataInicio != "null" && this.dataFinal != "null"){
          this.dataInicio = moment(this.dataInicio).format('DD/MM/YYYY');
          this.dataFinal = moment(this.dataFinal).format('DD/MM/YYYY');
        }
        this.relatorioService.getRelatorioFuncionarios(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_funcionarios: Funcionario[]) => {
            this.funcionarios = _funcionarios;
            this.todosFuncionarios = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputData = true;
            this.dropRelatorio = true;
            this.botaoGerar = false;
            this.botaoResetar = true;
            this.botaoGerarExcel = true;
            this.fileName = Relatorio.TodosFuncionariosExcluidos + '.xlsx';
            this._changeDetectorRef.markForCheck();
          },
          error => {
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this._changeDetectorRef.markForCheck();
            alert(error.error)
          }
        );
          break;
      case Relatorio.TodosTransportadoresAtivosInativosExcluidos:
        this.codigoRelatorio = 25;
        if(this.dataInicio != "null" && this.dataFinal != "null"){
          this.dataInicio = moment(this.dataInicio).format('DD/MM/YYYY');
          this.dataFinal = moment(this.dataFinal).format('DD/MM/YYYY');
        }
        this.relatorioService.getRelatorioTransportadores(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_transportadores: Transportador[]) => {
            this.transportadores = _transportadores;
            this.todosTransportadores = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputData = true;
            this.dropRelatorio = true;
            this.botaoGerar = false;
            this.botaoResetar = true;
            this.botaoGerarExcel = true;
            this.fileName = Relatorio.TodosTransportadoresAtivosInativosExcluidos + '.xlsx';
            this._changeDetectorRef.markForCheck();
          },
          error => {
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this._changeDetectorRef.markForCheck();
            alert(error.error)
          }
        );
          break;
      case Relatorio.TodosTransportadoresAtivos:
          this.codigoRelatorio = 26;
          if(this.dataInicio != "null" && this.dataFinal != "null"){
          this.dataInicio = moment(this.dataInicio).format('DD/MM/YYYY');
          this.dataFinal = moment(this.dataFinal).format('DD/MM/YYYY');
        }
        this.relatorioService.getRelatorioTransportadores(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_transportadores: Transportador[]) => {
            this.transportadores = _transportadores;
            this.todosTransportadores = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputData = true;
            this.dropRelatorio = true;
            this.botaoGerar = false;
            this.botaoResetar = true;
            this.botaoGerarExcel = true;
            this.fileName = Relatorio.TodosTransportadoresAtivos + '.xlsx';
            this._changeDetectorRef.markForCheck();
          },
          error => {
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this._changeDetectorRef.markForCheck();
            alert(error.error)
          }
        );
          break;
      case Relatorio.TodosTransportadoresInativos:
        this.codigoRelatorio = 27;
        if(this.dataInicio != "null" && this.dataFinal != "null"){
          this.dataInicio = moment(this.dataInicio).format('DD/MM/YYYY');
          this.dataFinal = moment(this.dataFinal).format('DD/MM/YYYY');
        }
        this.relatorioService.getRelatorioTransportadores(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_transportadores: Transportador[]) => {
            this.transportadores = _transportadores;
            this.todosTransportadores = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputData = true;
            this.dropRelatorio = true;
            this.botaoGerar = false;
            this.botaoResetar = true;
            this.botaoGerarExcel = true;
            this.fileName = Relatorio.TodosTransportadoresInativos + '.xlsx';
            this._changeDetectorRef.markForCheck();
          },
          error => {
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this._changeDetectorRef.markForCheck();
            alert(error.error)
          }
        );
          break;
      case Relatorio.TodosTransportadoresExcluidos:
        this.codigoRelatorio = 28;
        if(this.dataInicio != "null" && this.dataFinal != "null"){
          this.dataInicio = moment(this.dataInicio).format('DD/MM/YYYY');
          this.dataFinal = moment(this.dataFinal).format('DD/MM/YYYY');
        }
        this.relatorioService.getRelatorioTransportadores(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_transportadores: Transportador[]) => {
            this.transportadores = _transportadores;
            this.todosTransportadores = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputData = true;
            this.dropRelatorio = true;
            this.botaoGerar = false;
            this.botaoResetar = true;
            this.botaoGerarExcel = true;
            this.fileName = Relatorio.TodosTransportadoresExcluidos + '.xlsx';
            this._changeDetectorRef.markForCheck();
          },
          error => {
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this._changeDetectorRef.markForCheck();
            alert(error.error)
          }
        );
          break;
      case Relatorio.TodosUsuarios:
        this.codigoRelatorio = 29;
        if(this.dataInicio != "null" && this.dataFinal != "null"){
          this.dataInicio = moment(this.dataInicio).format('DD/MM/YYYY');
          this.dataFinal = moment(this.dataFinal).format('DD/MM/YYYY');
        }
        this.relatorioService.getRelatorioUsuarios(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_usuarios: Usuario[]) => {
            this.usuarios = _usuarios;
            this.todosUsuarios = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputData = true;
            this.dropRelatorio = true;
            this.botaoGerar = false;
            this.botaoResetar = true;
            this.botaoGerarExcel = true;
            this.fileName = Relatorio.TodosUsuarios + '.xlsx';
            this._changeDetectorRef.markForCheck();
          },
          error => {
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this._changeDetectorRef.markForCheck();
            alert(error.error)
          }
        );
          break;
      case Relatorio.TodosEmpresasAtivosInativosExcluidos:
          this.codigoRelatorio = 30;
          if(this.dataInicio != "null" && this.dataFinal != "null"){
            this.dataInicio = moment(this.dataInicio).format('DD/MM/YYYY');
            this.dataFinal = moment(this.dataFinal).format('DD/MM/YYYY');
          }
          this.relatorioService.getRelatorioEmpresas(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
            (_empresas: Empresa[]) => {
              this.empresas = _empresas;
              this.todosEmpresas = true;
              this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this.inputData = true;
              this.dropRelatorio = true;
              this.botaoGerar = false;
              this.botaoResetar = true;
              this.botaoGerarExcel = true;
              this.fileName = Relatorio.TodosEmpresasAtivosInativosExcluidos + '.xlsx';
              this._changeDetectorRef.markForCheck();
            },
            error => {
              this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this._changeDetectorRef.markForCheck();
              alert(error.error)
            }
          );
            break;
      case Relatorio.TodosEmpresasAtivos:
        this.codigoRelatorio = 31;
        if(this.dataInicio != "null" && this.dataFinal != "null"){
          this.dataInicio = moment(this.dataInicio).format('DD/MM/YYYY');
          this.dataFinal = moment(this.dataFinal).format('DD/MM/YYYY');
        }
        this.relatorioService.getRelatorioEmpresas(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_empresas: Empresa[]) => {
            this.empresas = _empresas;
            this.todosEmpresas = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputData = true;
            this.dropRelatorio = true;
            this.botaoGerar = false;
            this.botaoResetar = true;
            this.botaoGerarExcel = true;
            this.fileName = Relatorio.TodosEmpresasAtivos + '.xlsx';
            this._changeDetectorRef.markForCheck();
          },
          error => {
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this._changeDetectorRef.markForCheck();
            alert(error.error)
          }
        );
          break;
      case Relatorio.TodosEmpresasInativos:
        this.codigoRelatorio = 32;
        if(this.dataInicio != "null" && this.dataFinal != "null"){
          this.dataInicio = moment(this.dataInicio).format('DD/MM/YYYY');
          this.dataFinal = moment(this.dataFinal).format('DD/MM/YYYY');
        }
        this.relatorioService.getRelatorioEmpresas(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_empresas: Empresa[]) => {
            this.empresas = _empresas;
            this.todosEmpresas = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputData = true;
            this.dropRelatorio = true;
            this.botaoGerar = false;
            this.botaoResetar = true;
            this.botaoGerarExcel = true;
            this.fileName = Relatorio.TodosEmpresasInativos + '.xlsx';
            this._changeDetectorRef.markForCheck();
          },
          error => {
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this._changeDetectorRef.markForCheck();
            alert(error.error)
          }
        );
          break;
      case Relatorio.TodosEmpresasExcluidos:
        this.codigoRelatorio = 33;
        if(this.dataInicio != "null" && this.dataFinal != "null"){
          this.dataInicio = moment(this.dataInicio).format('DD/MM/YYYY');
          this.dataFinal = moment(this.dataFinal).format('DD/MM/YYYY');
        }
        this.relatorioService.getRelatorioEmpresas(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_empresas: Empresa[]) => {
            this.empresas = _empresas;
            this.todosEmpresas = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputData = true;
            this.dropRelatorio = true;
            this.botaoGerar = false;
            this.botaoResetar = true;
              this.botaoGerarExcel = true;
              this.fileName = Relatorio.TodosEmpresasExcluidos + '.xlsx';
            this._changeDetectorRef.markForCheck();
          },
          error => {
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this._changeDetectorRef.markForCheck();
            alert(error.error)
          }
        );
          break;
      case Relatorio.TodosProdutosAtivosInativosExcluidos:
          this.codigoRelatorio = 34;
          if(this.dataInicio != "null" && this.dataFinal != "null"){
            this.dataInicio = moment(this.dataInicio).format('DD/MM/YYYY');
            this.dataFinal = moment(this.dataFinal).format('DD/MM/YYYY');
          }
          this.relatorioService.getRelatorioProdutos(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
            (_produtos: Produto[]) => {
              this.produtos = _produtos;
              this.todosProdutos = true;
              this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this.inputData = true;
              this.dropRelatorio = true;
              this.botaoGerar = false;
              this.botaoResetar = true;
              this.botaoGerarExcel = true;
              this.fileName = Relatorio.TodosProdutosAtivosInativosExcluidos + '.xlsx';
              this._changeDetectorRef.markForCheck();
            },
            error => {
              this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this._changeDetectorRef.markForCheck();
              alert(error.error)
            }
          );
            break;
      case Relatorio.TodosProdutosAtivos:
        this.codigoRelatorio = 35;
        if(this.dataInicio != "null" && this.dataFinal != "null"){
          this.dataInicio = moment(this.dataInicio).format('DD/MM/YYYY');
          this.dataFinal = moment(this.dataFinal).format('DD/MM/YYYY');
        }
        this.relatorioService.getRelatorioProdutos(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_produtos: Produto[]) => {
            this.produtos = _produtos;
            this.todosProdutos = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputData = true;
            this.dropRelatorio = true;
            this.botaoGerar = false;
            this.botaoResetar = true;
            this.botaoGerarExcel = true;
            this.fileName = Relatorio.TodosProdutosAtivos + '.xlsx';
            this._changeDetectorRef.markForCheck();
          },
          error => {
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this._changeDetectorRef.markForCheck();
            alert(error.error)
          }
        );
          break;
      case Relatorio.TodosProdutosInativos:
        this.codigoRelatorio = 36;
        if(this.dataInicio != "null" && this.dataFinal != "null"){
          this.dataInicio = moment(this.dataInicio).format('DD/MM/YYYY');
          this.dataFinal = moment(this.dataFinal).format('DD/MM/YYYY');
        }
        this.relatorioService.getRelatorioProdutos(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_produtos: Produto[]) => {
            this.produtos = _produtos;
            this.todosProdutos = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputData = true;
            this.dropRelatorio = true;
            this.botaoGerar = false;
            this.botaoResetar = true;
            this.botaoGerarExcel = true;
            this.fileName = Relatorio.TodosProdutosInativos + '.xlsx';
            this._changeDetectorRef.markForCheck();
          },
          error => {
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this._changeDetectorRef.markForCheck();
            alert(error.error)
          }
        );
          break;
      case Relatorio.TodosProdutosExcluidos:
        this.codigoRelatorio = 37;
        if(this.dataInicio != "null" && this.dataFinal != "null"){
          this.dataInicio = moment(this.dataInicio).format('DD/MM/YYYY');
          this.dataFinal = moment(this.dataFinal).format('DD/MM/YYYY');
        }
        this.relatorioService.getRelatorioProdutos(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_produtos: Produto[]) => {
            this.produtos = _produtos;
            this.todosProdutos = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputData = true;
            this.dropRelatorio = true;
            this.botaoGerar = false;
            this.botaoResetar = true;
            this.botaoGerarExcel = true;
            this.fileName = Relatorio.TodosProdutosExcluidos + '.xlsx';
            this._changeDetectorRef.markForCheck();
          },
          error => {
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this._changeDetectorRef.markForCheck();
            alert(error.error)
          }
        );
          break;
      default:
          alert("Erro ao gerar Relatorio");
          break;
    }
  }

  public GerarExcel(){
    let clientes = document.getElementById('excel-clientes');
    let fornecedores = document.getElementById('excel-fornecedores');
    let fornecedoresProdutos = document.getElementById('excel-fornecedoresProdutos');
    let funcionarios = document.getElementById('excel-funcionarios');
    let transportadores = document.getElementById('excel-transportadores');
    let usuarios = document.getElementById('excel-usuarios');
    let empresas = document.getElementById('excel-empresas');
    let produtos = document.getElementById('excel-produtos');
    if(clientes){
      const ws: XLSX.WorkSheet =XLSX.utils.table_to_sheet(clientes);
      const wb: XLSX.WorkBook = XLSX.utils.book_new();
      XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');
      XLSX.writeFile(wb, this.fileName);
    }else if(fornecedores){
      const ws: XLSX.WorkSheet =XLSX.utils.table_to_sheet(fornecedores);
      const wb: XLSX.WorkBook = XLSX.utils.book_new();
      XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');
      XLSX.writeFile(wb, this.fileName);
    }else if(fornecedoresProdutos){
      const ws: XLSX.WorkSheet =XLSX.utils.table_to_sheet(fornecedoresProdutos);
      const wb: XLSX.WorkBook = XLSX.utils.book_new();
      XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');
      XLSX.writeFile(wb, this.fileName);
    }else if(funcionarios){
      const ws: XLSX.WorkSheet =XLSX.utils.table_to_sheet(funcionarios);
      const wb: XLSX.WorkBook = XLSX.utils.book_new();
      XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');
      XLSX.writeFile(wb, this.fileName);
    }else if(transportadores){
      const ws: XLSX.WorkSheet =XLSX.utils.table_to_sheet(transportadores);
      const wb: XLSX.WorkBook = XLSX.utils.book_new();
      XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');
      XLSX.writeFile(wb, this.fileName);
    }else if(usuarios){
      const ws: XLSX.WorkSheet =XLSX.utils.table_to_sheet(usuarios);
      const wb: XLSX.WorkBook = XLSX.utils.book_new();
      XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');
      XLSX.writeFile(wb, this.fileName);
    }else if(empresas){
      const ws: XLSX.WorkSheet =XLSX.utils.table_to_sheet(empresas);
      const wb: XLSX.WorkBook = XLSX.utils.book_new();
      XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');
      XLSX.writeFile(wb, this.fileName);
    }else if(produtos){
      const ws: XLSX.WorkSheet =XLSX.utils.table_to_sheet(produtos);
      const wb: XLSX.WorkBook = XLSX.utils.book_new();
      XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');
      XLSX.writeFile(wb, this.fileName);
    }
    else{
      alert('Erro ao gerar o relatório em excel');
    }

  }

  public Resetar(){
    this.dataInicio = new Date().toISOString().split('T')[0];
    this.dataFinal = new Date().toISOString().split('T')[0];
    this.valorRelatorio = Relatorio.Selecione;
    this._changeDetectorRef.markForCheck();
    this.divData = false;
    this.inputData = false;
    this.botaoResetar = false;
    this.inputData = false;
    this.dropRelatorio = false;
    this.botaoGerar = false;
    this.todosClientes = false;
    this.todosFornecedores = false;
    this.todosFornecedoresProdutos = false;
    this.todosFuncionarios = false;
    this.todosTransportadores = false;
    this.todosUsuarios = false;
    this.todosEmpresas = false;
    this.todosProdutos = false;
    this.botaoGerarExcel = false;
    this.fileName = '';
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
