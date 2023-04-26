import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import jsPDF from 'jspdf';
import { Cliente } from 'src/app/models/cliente';
import { Empresa } from 'src/app/models/empresa';
import { NotaFiscal } from 'src/app/models/notaFiscal';
import { Produto } from 'src/app/models/produto';
import { Transportador } from 'src/app/models/transportador';
import { AuthService } from 'src/app/services/login/auth.service';
import { NavService } from 'src/app/services/nav/nav.service';
import { NotaFiscalService } from 'src/app/services/notaFiscal/notaFiscal.service';
import { TituloService } from 'src/app/services/titulo/titulo.service';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-notaFiscal-pdf',
  templateUrl: './notaFiscal-pdf.component.html',
  styleUrls: ['./notaFiscal-pdf.component.scss']
})
export class NotaFiscalPdfComponent implements OnInit {
  @ViewChild('content', {static: false}) el!: ElementRef;
  notaFiscal = {} as NotaFiscal;
  empresa = {} as Empresa;
  cliente = {} as Cliente;
  transportador = {} as Transportador;
  produtos: Produto[] = [];
  notaFiscalId!: number;
  botaoVolta: boolean = false;
  botaoImprimir: boolean = false;
  constructor(private titleService: Title, private notaFiscalService: NotaFiscalService, private route: ActivatedRoute, private router: Router, private authService: AuthService, public nav: NavService,public titu: TituloService) { }

  ngOnInit() {
    this.permissoesDeTela();
    this.gerarPDF();
  }

  public gerarPDF(): void{
    this.notaFiscalId = this.route.snapshot.params['id'];
    this.notaFiscalService.GerarPdf(this.notaFiscalId).subscribe(
      (_notaFiscal: NotaFiscal) => {
        this.notaFiscal = _notaFiscal;
        this.empresa = this.notaFiscal.empresa;
        this.cliente = this.notaFiscal.cliente;
        this.transportador = this.notaFiscal.transportador;
        this.produtos = this.notaFiscal.produto;
        this.botaoVolta = true;
        this.botaoImprimir = true;
      },
      error => console.log(error)
    );
  }

  printPDF() {
    this.botaoVolta = false;
    this.botaoImprimir = false;
    this.titleService.setTitle('Nota Fiscal ' + this.notaFiscalId);
    let pdf = new jsPDF('p', 'pt', 'a4');
    let container = this.el.nativeElement;
    container.setAttribute('style', 'text-align: left');
    container.style.fontSize = '12pt';
    container.style.transform = 'scale(0.75)'; // Ajusta a escala para caber na página
    pdf.html(container, {
      callback: (pdf) => {
        window.print();
        this.botaoVolta = true;
        this.botaoImprimir = true;
        container.style.transform = 'scale(1)'; // Ajusta a escala para caber na página
      }
    });
  }

  public Voltar(){
    this.router.navigate(['notasFiscais/lista']);
  }

  permissoesDeTela(){
    this.authService.verificaAdministrador();
    this.authService.visualizarCliente();
    this.authService.visualizarFornecedor();
    this.authService.visualizarFuncionario();
    this.authService.visualizarProduto();
    this.authService.visualizarEstoque();
    this.authService.visualizarEnderecoProduto();
    this.authService.visualizarTransportador();
    this.authService.visualizarRelatorio();
    this.authService.visualizarUsuario();
    this.authService.visualizarPedido();
    this.authService.visualizarNotaFiscal();
    this.nav.hide();
    this.titu.hide();
    this.titu.showTitulo();
  }

}
