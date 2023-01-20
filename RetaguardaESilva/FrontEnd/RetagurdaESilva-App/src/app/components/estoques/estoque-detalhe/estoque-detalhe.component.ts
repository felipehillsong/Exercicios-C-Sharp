import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Titulos } from 'src/app/enums/titulos';
import { Estoque } from 'src/app/models/estoque';
import { EstoqueService } from 'src/app/services/estoque/estoque.service';
import { AuthService } from 'src/app/services/login/auth.service';
import { NavService } from 'src/app/services/nav/nav.service';
import { TituloService } from 'src/app/services/titulo/titulo.service';

@Component({
  selector: 'app-estoque-detalhe',
  templateUrl: './estoque-detalhe.component.html',
  styleUrls: ['./estoque-detalhe.component.scss']
})
export class EstoqueDetalheComponent implements OnInit {
  titulo =  Titulos.detalheEstoque;
  form!: FormGroup;
  estoque = {} as Estoque;
  estoqueId!:number;

  constructor(private router: Router, private route: ActivatedRoute,  public titu: TituloService, private fb: FormBuilder, private estoqueService: EstoqueService, private toastr: ToastrService, private spinner: NgxSpinnerService, public nav: NavService, private _changeDetectorRef: ChangeDetectorRef, private authService: AuthService) { }

  ngOnInit() {
    this.getEstoqueById();
    this.permissoesDeTela();
  }

  public getEstoqueById(): void{
    this.estoqueId = this.route.snapshot.params['id'];
    this.estoqueService.getEstoquesById(this.estoqueId).subscribe(
      (_estoque: Estoque) => {
        this.estoque = _estoque;
        this._changeDetectorRef.markForCheck();
      },
      error => console.log(error)
    );
  }

  public Voltar(){
    this.router.navigate(['estoques/lista']);
  }

  permissoesDeTela(){
    this.authService.verificaAdministrador();
    this.authService.visualizarCliente();
    this.authService.visualizarFornecedor();
    this.authService.visualizarProduto();
    this.authService.visualizarEstoque();
    this.authService.visualizarFuncionario();
    this.authService.visualizarTransportador();
    this.authService.visualizarRelatorio();
    this.authService.visualizarUsuario();
    this.authService.visualizarVenda();
    this.nav.hide();
    this.titu.hide();
    this.titu.showTitulo();
  }


}
