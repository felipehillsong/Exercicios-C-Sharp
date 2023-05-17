import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import * as moment from 'moment';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { FontAwesome } from 'src/app/enums/fontAwesome';
import { Relatorio } from 'src/app/enums/relatorio.enum';
import { Titulos } from 'src/app/enums/titulos';
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
  inputData:boolean = false;
  botaoGerar:boolean = false;
  dataInicio!:string;
  dataFinal!:string;
  valorRelatorio: string = '';
  codigoRelatorio!:number;
  relatorios: string[] = [
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

  constructor(private router: Router, private toastr: ToastrService, private spinner: NgxSpinnerService, private authService: AuthService, private relatorioService: RelatorioService, public titu: TituloService, public nav: NavService, private fb: FormBuilder) { }

  ngOnInit() {
    this.dataInicio = new Date().toISOString().split('T')[0];
    this.dataFinal = new Date().toISOString().split('T')[0];
    this.permissoesDeTela();
  }

  onDropdownChange(value: string) {
    if(value == undefined){
      this.inputData = false;
      this.dataInicio = 'null';
      this.dataFinal = 'null';
      this.botaoGerar = false;
    }
    else if(value == Relatorio.TodosFornecedoresAtivosProdutosAtivoInativoExcluidos || value == Relatorio.TodosFornecedoresAtivosProdutosAtivos || value == Relatorio.TodosFornecedoresAtivosProdutosInativos || value == Relatorio.TodosFornecedoresAtivosProdutosExcluidos || value == Relatorio.TodosFornecedoresInativosProdutosAtivoInativoExcluidos || value == Relatorio.TodosFornecedoresInativosProdutosAtivos || value == Relatorio.TodosFornecedoresInativosProdutosInativos || value == Relatorio.TodosFornecedoresInativosProdutosExcluidos || value == Relatorio.TodosFornecedoresExcluidosProdutosAtivoInativoExcluidos || value == Relatorio.TodosFornecedoresExcluidosProdutosAtivos || value == Relatorio.TodosFornecedoresExcluidosProdutosInativos || value == Relatorio.TodosFornecedoresExcluidosProdutosExcluidos){
      this.inputData = false;
      this.dataInicio = 'null';
      this.dataFinal = 'null';
      this.botaoGerar = true;
    }
    else{
      this.dataInicio = new Date().toISOString().split('T')[0];
      this.dataFinal = new Date().toISOString().split('T')[0];
      this.inputData = true;
      this.botaoGerar = true;
    }
  }

  public Gerar(){
    switch (this.valorRelatorio) {
      case Relatorio.TodosClientesAtivosInativosExcluidos:
          this.codigoRelatorio = 1;
          this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
          break;
      case Relatorio.TodosClientesAtivos:
        this.codigoRelatorio = 2;
        this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
          break;
      case Relatorio.TodosClientesInativos:
        this.codigoRelatorio = 3;
        this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
          break;
      case Relatorio.TodosClientesExcluidos:
        this.codigoRelatorio = 4;
        this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
        break;
      case Relatorio.TodosFornecedoresAtivosInativosExcluidos:
          this.codigoRelatorio = 5;
          this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
          break;
      case Relatorio.TodosFornecedoresAtivos:
        this.codigoRelatorio = 6;
        this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
          break;
      case Relatorio.TodosFornecedoresInativos:
        this.codigoRelatorio = 7;
        this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
          break;
      case Relatorio.TodosFornecedoresExcluidos:
        this.codigoRelatorio = 8;
        this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
        break;
      case Relatorio.TodosFornecedoresAtivosProdutosAtivoInativoExcluidos:
        this.codigoRelatorio = 9;
        this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
        break;
      case Relatorio.TodosFornecedoresAtivosProdutosAtivos:
          this.codigoRelatorio = 10;
          this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
          break;
      case Relatorio.TodosFornecedoresAtivosProdutosInativos:
        this.codigoRelatorio = 11;
        this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
          break;
      case Relatorio.TodosFornecedoresAtivosProdutosExcluidos:
        this.codigoRelatorio = 12;
        this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
          break;
      case Relatorio.TodosFornecedoresInativosProdutosAtivoInativoExcluidos:
        this.codigoRelatorio = 13;
        this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
        break;
      case Relatorio.TodosFornecedoresInativosProdutosAtivos:
          this.codigoRelatorio = 14;
          this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
          break;
      case Relatorio.TodosFornecedoresInativosProdutosInativos:
        this.codigoRelatorio = 15;
        this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
          break;
      case Relatorio.TodosFornecedoresInativosProdutosExcluidos:
        this.codigoRelatorio = 16;
        this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
          break;
      case Relatorio.TodosFornecedoresExcluidosProdutosAtivoInativoExcluidos:
        this.codigoRelatorio = 17;
        this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
        break;
      case Relatorio.TodosFornecedoresExcluidosProdutosAtivos:
          this.codigoRelatorio = 18;
          this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
          break;
      case Relatorio.TodosFornecedoresExcluidosProdutosInativos:
        this.codigoRelatorio = 19;
        this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
          break;
      case Relatorio.TodosFornecedoresExcluidosProdutosExcluidos:
        this.codigoRelatorio = 20;
        this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
          break;
      case Relatorio.TodosFuncionariosAtivosInativosExcluidos:
        this.codigoRelatorio = 21;
        this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
        break;
      case Relatorio.TodosFuncionariosAtivos:
          this.codigoRelatorio = 22;
          this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
          break;
      case Relatorio.TodosFuncionariosInativos:
        this.codigoRelatorio = 23;
        this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
          break;
      case Relatorio.TodosFuncionariosExcluidos:
        this.codigoRelatorio = 24;
        this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
          break;
      case Relatorio.TodosTransportadoresAtivosInativosExcluidos:
        this.codigoRelatorio = 25;
        this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
        break;
      case Relatorio.TodosTransportadoresAtivos:
          this.codigoRelatorio = 26;
          this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
          break;
      case Relatorio.TodosTransportadoresInativos:
        this.codigoRelatorio = 27;
        this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
          break;
      case Relatorio.TodosTransportadoresExcluidos:
        this.codigoRelatorio = 28;
        this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
          break;
      case Relatorio.TodosUsuarios:
        this.codigoRelatorio = 29;
        this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
        break;
      case Relatorio.TodosEmpresasAtivosInativosExcluidos:
          this.codigoRelatorio = 30;
          this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
          break;
      case Relatorio.TodosEmpresasAtivos:
        this.codigoRelatorio = 31;
        this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
          break;
      case Relatorio.TodosEmpresasInativos:
        this.codigoRelatorio = 32;
        this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
          break;
      case Relatorio.TodosEmpresasExcluidos:
        this.codigoRelatorio = 33;
        this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
        break;
      case Relatorio.TodosProdutosAtivosInativosExcluidos:
          this.codigoRelatorio = 34;
          this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
          break;
      case Relatorio.TodosProdutosAtivos:
        this.codigoRelatorio = 35;
        this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
          break;
      case Relatorio.TodosProdutosInativos:
        this.codigoRelatorio = 36;
        this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
          break;
      case Relatorio.TodosProdutosExcluidos:
        this.codigoRelatorio = 37;
        this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
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
