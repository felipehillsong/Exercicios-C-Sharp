import { Component, OnInit } from '@angular/core';
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

@Component({
  selector: 'app-notaFiscal-pdf',
  templateUrl: './notaFiscal-pdf.component.html',
  styleUrls: ['./notaFiscal-pdf.component.scss']
})
export class NotaFiscalPdfComponent implements OnInit {
  notaFiscal = {} as NotaFiscal;
  empresa = {} as Empresa;
  cliente = {} as Cliente;
  transportador = {} as Transportador;
  produtos: Produto[] = [];
  notaFiscalId!: number;
  constructor(private notaFiscalService: NotaFiscalService, private route: ActivatedRoute, private router: Router, private authService: AuthService, public nav: NavService,public titu: TituloService,) { }

  ngOnInit() {
    this.permissoesDeTela();
    this.gerarPDF();
  }

  public gerarPDF(): void{
    this.notaFiscalId = this.route.snapshot.params['id'];
    //this.printPDF();
    this.notaFiscalService.GerarPdf(this.notaFiscalId).subscribe(
      (_notaFiscal: NotaFiscal) => {
        this.notaFiscal = _notaFiscal;
        this.empresa = this.notaFiscal.empresa;
        this.cliente = this.notaFiscal.cliente;
        this.transportador = this.notaFiscal.transportador;
        this.produtos = this.notaFiscal.produto;
        console.log(this.notaFiscal);
      },
      error => console.log(error)
    );
    //this.router.navigate([`notasFiscais/lista`]);
  }

  printPDF(){
    const doc = new jsPDF();
    doc.text("Hello World!", 10, 10);
    doc.save("a4.pdf");
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
