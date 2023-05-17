import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import * as moment from 'moment';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Cliente } from 'src/app/models/cliente';
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
    this.dataInicio = moment(this.dataInicio).format('DD/MM/YYYY');
    this.dataFinal = moment(this.dataFinal).format('DD/MM/YYYY');
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
          break;
      case 3:
        this.relatorioService.getRelatorioCliente(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_clientes: Cliente[]) => {
            this.clientes = _clientes;
          },
          error => console.log(error)
        );
          break;
          break;
      case 4:
        this.relatorioService.getRelatorioCliente(this.codigoRelatorio, this.dataInicio, this.dataFinal).subscribe(
          (_clientes: Cliente[]) => {
            this.clientes = _clientes;
          },
          error => console.log(error)
        );
          break;
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
