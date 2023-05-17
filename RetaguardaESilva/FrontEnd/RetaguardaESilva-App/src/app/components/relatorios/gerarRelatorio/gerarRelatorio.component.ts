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
  dataInicio!:string;
  dataFinal!:string;
  valorRelatorio: string = '';
  codigoRelatorio!:number;
  relatorios: string[] = [
    Relatorio.TodosClientes,
    Relatorio.ClientesCadastradosAtivos,
    Relatorio.ClientesCadastradosInativos,
    Relatorio.ClientesExcluidos
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
    }else{
      this.inputData = true;
    }
  }

  public Gerar(){
    switch (this.valorRelatorio) {
      case Relatorio.TodosClientes:
          this.codigoRelatorio = 1;
          this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
          break;
      case Relatorio.ClientesCadastradosAtivos:
        this.codigoRelatorio = 2;
        this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
          break;
      case Relatorio.ClientesCadastradosInativos:
        this.codigoRelatorio = 3;
        this.router.navigate([`relatorios/detalhe/${this.codigoRelatorio}/${this.dataInicio}/${this.dataFinal}`]);
          break;
      case    Relatorio.ClientesExcluidos:
        this.codigoRelatorio = 4;
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
