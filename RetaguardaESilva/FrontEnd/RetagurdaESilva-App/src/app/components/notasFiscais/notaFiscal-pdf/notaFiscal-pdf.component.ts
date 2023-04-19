import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import jsPDF from 'jspdf';
import { NotaFiscal } from 'src/app/models/notaFiscal';
import { NotaFiscalService } from 'src/app/services/notaFiscal/notaFiscal.service';

@Component({
  selector: 'app-notaFiscal-pdf',
  templateUrl: './notaFiscal-pdf.component.html',
  styleUrls: ['./notaFiscal-pdf.component.scss']
})
export class NotaFiscalPdfComponent implements OnInit {
  notaFiscal = {} as NotaFiscal;
  notaFiscalId!: number;
  constructor(private notaFiscalService: NotaFiscalService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.gerarPDF();
  }

  public gerarPDF(): void{
    this.notaFiscalId = this.route.snapshot.params['id'];
    //this.printPDF();
    this.notaFiscalService.GerarPdf(this.notaFiscalId).subscribe(
      (_notaFiscal: NotaFiscal) => {
        this.notaFiscal = _notaFiscal;
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

}
