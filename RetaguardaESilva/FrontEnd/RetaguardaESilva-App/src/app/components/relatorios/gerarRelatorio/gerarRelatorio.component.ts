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
  codigoRelatorio!:number;
  dataInicio!:string;
  dataFinal!:string;
  inputDatas!:boolean;
  todosClientesAtivosInativosExcluidos:boolean = false;
  todosClientesAtivos:boolean = false;
  todosClientesInativos:boolean = false;
  todosClientesExcluidos:boolean = false;
  todosFornecedoresAtivosInativosExcluidos:boolean = false;
  todosFornecedoresAtivos:boolean = false;
  todosFornecedoresInativos:boolean = false;
  todosFornecedoresExcluidos:boolean = false;
  todosFornecedoresAtivosProdutosAtivoInativoExcluidos:boolean = false;
  todosFornecedoresAtivosProdutosAtivos:boolean = false;
  todosFornecedoresAtivosProdutosInativos:boolean = false;
  todosFornecedoresAtivosProdutosExcluidos:boolean = false;
  todosFornecedoresInativosProdutosAtivoInativoExcluidos:boolean = false;
  todosFornecedoresInativosProdutosAtivos:boolean = false;
  todosFornecedoresInativosProdutosInativos:boolean = false;
  todosFornecedoresInativosProdutosExcluidos:boolean = false;
  todosFornecedoresExcluidosProdutosAtivoInativoExcluidos:boolean = false;
  todosFornecedoresExcluidosProdutosAtivos:boolean = false;
  todosFornecedoresExcluidosProdutosInativos:boolean = false;
  todosFornecedoresExcluidosProdutosExcluidos:boolean = false;
  todosFuncionariosAtivosInativosExcluidos:boolean = false;
  todosFuncionariosAtivos:boolean = false;
  todosFuncionariosInativos:boolean = false;
  todosFuncionariosExcluidos:boolean = false;
  todosTransportadoresAtivosInativosExcluidos:boolean = false;
  todosTransportadoresAtivos:boolean = false;
  todosTransportadoresInativos:boolean = false;
  todosTransportadoresExcluidos:boolean = false;
  todosUsuarios:boolean = false;
  todosEmpresasAtivosInativosExcluidos:boolean = false;
  todosEmpresasAtivos:boolean = false;
  todosEmpresasInativos:boolean = false;
  todosEmpresasExcluidos:boolean = false;
  todosProdutosAtivosInativosExcluidos:boolean = false;
  todosProdutosAtivos:boolean = false;
  todosProdutosInativos:boolean = false;
  todosProdutosExcluidos:boolean = false;
  inputData:boolean = false;
  botaoGerar:boolean = false;
  botaoResetar:boolean = false;
  valorRelatorio: string = '';
  relatorios!: string[]


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
      this.inputData = false;
      this.dataInicio = 'null';
      this.dataFinal = 'null';
      this.botaoGerar = false;
      this.botaoResetar = false;
    }
    else if(value == Relatorio.TodosFornecedoresAtivosProdutosAtivoInativoExcluidos || value == Relatorio.TodosFornecedoresAtivosProdutosAtivos || value == Relatorio.TodosFornecedoresAtivosProdutosInativos || value == Relatorio.TodosFornecedoresAtivosProdutosExcluidos || value == Relatorio.TodosFornecedoresInativosProdutosAtivoInativoExcluidos || value == Relatorio.TodosFornecedoresInativosProdutosAtivos || value == Relatorio.TodosFornecedoresInativosProdutosInativos || value == Relatorio.TodosFornecedoresInativosProdutosExcluidos || value == Relatorio.TodosFornecedoresExcluidosProdutosAtivoInativoExcluidos || value == Relatorio.TodosFornecedoresExcluidosProdutosAtivos || value == Relatorio.TodosFornecedoresExcluidosProdutosInativos || value == Relatorio.TodosFornecedoresExcluidosProdutosExcluidos){
      this.inputData = false;
      this.dataInicio = 'null';
      this.dataFinal = 'null';
      this.botaoGerar = true;
      this.botaoResetar = false;
    }
    else{
      this.dataInicio = new Date().toISOString().split('T')[0];
      this.dataFinal = new Date().toISOString().split('T')[0];
      this.inputData = true;
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
              this.todosClientesAtivosInativosExcluidos = true;
              this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this.inputDatas = true;
              this.botaoGerar = false;
              this.botaoResetar = true;
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
              this.todosClientesAtivosInativosExcluidos = true;
              this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this.inputDatas = true;
              this.botaoGerar = false;
              this.botaoResetar = true;
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
            this.todosClientesAtivosInativosExcluidos = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputDatas = true;
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
            this.todosClientesAtivosInativosExcluidos = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputDatas = true;
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
              this.todosFornecedoresAtivosInativosExcluidos = true;
              this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this.inputDatas = true;
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
            this.todosFornecedoresAtivosInativosExcluidos = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputDatas = true;
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
            this.todosFornecedoresAtivosInativosExcluidos = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputDatas = true;
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
            this.todosFornecedoresAtivosInativosExcluidos = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputDatas = true;
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
            this.todosFornecedoresAtivosInativosExcluidos = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
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
      case Relatorio.TodosFornecedoresAtivosProdutosAtivos:
          this.codigoRelatorio = 10;
          this.relatorioService.getRelatorioFornecedoresProdutos(this.codigoRelatorio).subscribe(
            (_fornecedores: Fornecedor[]) => {
              this.fornecedores = _fornecedores;
              this.todosFornecedoresAtivosInativosExcluidos = true;
              this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
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
      case Relatorio.TodosFornecedoresAtivosProdutosInativos:
        this.codigoRelatorio = 11;
        this.relatorioService.getRelatorioFornecedoresProdutos(this.codigoRelatorio).subscribe(
          (_fornecedores: Fornecedor[]) => {
            this.fornecedores = _fornecedores;
            this.todosFornecedoresAtivosInativosExcluidos = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
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
      case Relatorio.TodosFornecedoresAtivosProdutosExcluidos:
        this.codigoRelatorio = 12;
        this.relatorioService.getRelatorioFornecedoresProdutos(this.codigoRelatorio).subscribe(
          (_fornecedores: Fornecedor[]) => {
            this.fornecedores = _fornecedores;
            this.todosFornecedoresAtivosInativosExcluidos = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
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
      case Relatorio.TodosFornecedoresInativosProdutosAtivoInativoExcluidos:
        this.codigoRelatorio = 13;
        this.relatorioService.getRelatorioFornecedoresProdutos(this.codigoRelatorio).subscribe(
          (_fornecedores: Fornecedor[]) => {
            this.fornecedores = _fornecedores;
            this.todosFornecedoresAtivosInativosExcluidos = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
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
      case Relatorio.TodosFornecedoresInativosProdutosAtivos:
          this.codigoRelatorio = 14;
          this.relatorioService.getRelatorioFornecedoresProdutos(this.codigoRelatorio).subscribe(
            (_fornecedores: Fornecedor[]) => {
              this.fornecedores = _fornecedores;
              this.todosFornecedoresAtivosInativosExcluidos = true;
              this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
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
      case Relatorio.TodosFornecedoresInativosProdutosInativos:
        this.codigoRelatorio = 15;
        this.relatorioService.getRelatorioFornecedoresProdutos(this.codigoRelatorio).subscribe(
          (_fornecedores: Fornecedor[]) => {
            this.fornecedores = _fornecedores;
            this.todosFornecedoresAtivosInativosExcluidos = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
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
      case Relatorio.TodosFornecedoresInativosProdutosExcluidos:
        this.codigoRelatorio = 16;
        if(this.dataInicio != "null" && this.dataFinal != "null"){
          this.dataInicio = moment(this.dataInicio).format('DD/MM/YYYY');
          this.dataFinal = moment(this.dataFinal).format('DD/MM/YYYY');
        }
        this.relatorioService.getRelatorioFornecedores(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_fornecedores: Fornecedor[]) => {
            this.fornecedores = _fornecedores;
            this.todosFornecedoresAtivosInativosExcluidos = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
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
      case Relatorio.TodosFornecedoresExcluidosProdutosAtivoInativoExcluidos:
        this.codigoRelatorio = 17;
        this.relatorioService.getRelatorioFornecedoresProdutos(this.codigoRelatorio).subscribe(
          (_fornecedores: Fornecedor[]) => {
            this.fornecedores = _fornecedores;
            this.todosFornecedoresAtivosInativosExcluidos = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
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
      case Relatorio.TodosFornecedoresExcluidosProdutosAtivos:
          this.codigoRelatorio = 18;
          this.relatorioService.getRelatorioFornecedoresProdutos(this.codigoRelatorio).subscribe(
            (_fornecedores: Fornecedor[]) => {
              this.fornecedores = _fornecedores;
              this.todosFornecedoresAtivosInativosExcluidos = true;
              this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
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
      case Relatorio.TodosFornecedoresExcluidosProdutosInativos:
        this.codigoRelatorio = 19;
        this.relatorioService.getRelatorioFornecedoresProdutos(this.codigoRelatorio).subscribe(
          (_fornecedores: Fornecedor[]) => {
            this.fornecedores = _fornecedores;
            this.todosFornecedoresAtivosInativosExcluidos = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
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
      case Relatorio.TodosFornecedoresExcluidosProdutosExcluidos:
        this.codigoRelatorio = 20;
        this.relatorioService.getRelatorioFornecedoresProdutos(this.codigoRelatorio).subscribe(
          (_fornecedores: Fornecedor[]) => {
            this.fornecedores = _fornecedores;
            this.todosFornecedoresAtivosInativosExcluidos = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
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
      case Relatorio.TodosFuncionariosAtivosInativosExcluidos:
        this.codigoRelatorio = 21;
        if(this.dataInicio != "null" && this.dataFinal != "null"){
          this.dataInicio = moment(this.dataInicio).format('DD/MM/YYYY');
          this.dataFinal = moment(this.dataFinal).format('DD/MM/YYYY');
        }
        this.relatorioService.getRelatorioFuncionarios(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_funcionarios: Funcionario[]) => {
            this.funcionarios = _funcionarios;
            this.todosFornecedoresAtivosInativosExcluidos = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputDatas = true;
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
              this.todosFornecedoresAtivosInativosExcluidos = true;
              this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this.inputDatas = true;
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
            this.todosFornecedoresAtivosInativosExcluidos = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputDatas = true;
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
            this.todosFornecedoresAtivosInativosExcluidos = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputDatas = true;
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
            this.todosFornecedoresAtivosInativosExcluidos = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputDatas = true;
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
            this.todosFornecedoresAtivosInativosExcluidos = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputDatas = true;
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
            this.todosFornecedoresAtivosInativosExcluidos = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputDatas = true;
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
            this.todosFornecedoresAtivosInativosExcluidos = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputDatas = true;
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
            this.todosFornecedoresAtivosInativosExcluidos = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputDatas = true;
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
              this.todosFornecedoresAtivosInativosExcluidos = true;
              this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this.inputDatas = true;
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
            this.todosFornecedoresAtivosInativosExcluidos = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputDatas = true;
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
            this.todosFornecedoresAtivosInativosExcluidos = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputDatas = true;
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
            this.todosFornecedoresAtivosInativosExcluidos = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputDatas = true;
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
              this.todosFornecedoresAtivosInativosExcluidos = true;
              this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
              this.inputDatas = true;
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
            this.todosFornecedoresAtivosInativosExcluidos = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputDatas = true;
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
            this.todosFornecedoresAtivosInativosExcluidos = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputDatas = true;
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
            this.todosFornecedoresAtivosInativosExcluidos = true;
            this.dataInicio = moment(this.dataInicio, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.dataFinal = moment(this.dataFinal, 'DD/MM/YYYY').format('YYYY-MM-DD');
            this.inputDatas = true;
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

  public Resetar(){
    this.dataInicio = new Date().toISOString().split('T')[0];
    this.dataFinal = new Date().toISOString().split('T')[0];
    this.valorRelatorio = Relatorio.Selecione;
    this._changeDetectorRef.markForCheck();
    this.inputData = false;
    this.inputDatas = false;
    this.botaoResetar = false;
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
