import { DatePipe } from '@angular/common';
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import * as moment from 'moment';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Titulos } from 'src/app/enums/titulos';
import { Fornecedor } from 'src/app/models/fornecedor';
import { Produto } from 'src/app/models/produto';
import { AuthService } from 'src/app/services/login/auth.service';
import { NavService } from 'src/app/services/nav/nav.service';
import { ProdutoService } from 'src/app/services/produto/produto.service';
import { TituloService } from 'src/app/services/titulo/titulo.service';

@Component({
  selector: 'app-produto-editar',
  templateUrl: './produto-editar.component.html',
  styleUrls: ['./produto-editar.component.scss'],
  providers: [DatePipe],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProdutoEditarComponent implements OnInit {
  titulo =  Titulos.editarProduto;
  form!: FormGroup;
  produto = {} as Produto;
  public fornecedores: Fornecedor[] = [];
  fornecedorId!:number;
  fornecedorNome!:string;
  produtoId!:number;
  dataHoje!:string;
  keyError!:string;
  valueError!:string;
  ativo!:string;

  constructor(private router: Router, private route: ActivatedRoute,  public titu: TituloService, private fb: FormBuilder, private produtoService: ProdutoService, private toastr: ToastrService, private spinner: NgxSpinnerService, public nav: NavService, private _changeDetectorRef: ChangeDetectorRef, private authService: AuthService) { }

  ngOnInit() {
    this.getProdutoById();
    this.permissoesDeTela();
    this.validation();
  }

  public getProdutoById(): void{
    this.produtoId = this.route.snapshot.params['id'];
    this.produtoService.getProdutosById(this.produtoId).subscribe(
      (_produto: Produto) => {
        this.produto = _produto;
        this.preencherSelect();
        var dataBD = moment(this.produto.dataCadastroProduto).format('YYYY-MM-DD');
        this.produto.dataCadastroProduto = dataBD;
        this.getFornecedores();
        this._changeDetectorRef.markForCheck();
      },
      error => console.log(error)
    );
  }

  public getFornecedores(): void{
    this.produtoService.getFornecedores(this.authService.empresaId()).subscribe(
      (_fornecedores: Fornecedor[]) => {
        this.fornecedores = _fornecedores;
        var fornecedor = this.fornecedores.filter(f => f.id == this.produto.fornecedorId);
        this.fornecedorNome = fornecedor[0].nome;
        this._changeDetectorRef.markForCheck();
      },
      error => console.log(error)
    );
  }

  public Editar(): void {
    this.spinner.show();
    if(this.form.valid){
      this.produto = {...this.form.value};
      this.fornecedorId = this.preencherFornecedorId(this.form.value);
      this.preencherAtivo(this.form.value);
      this.produto.id = this.produtoId;
      this.produto.fornecedorId = this.fornecedorId;
      this.produto.empresaId = this.authService.empresaId();
      this.produtoService.editProduto(this.produto).subscribe(() => {
        this.router.navigate(['produtos/lista']);
      },
      (error: any) => {
        console.error(error);
        this.spinner.hide();
        this.titu.hide();
        this.toastr.error(error.error);
      },
      () => this.spinner.hide()
    );
  }
}

public preencherFornecedorId(forms:any):number{
  var fornecedor = this.fornecedores.filter(f => f.nome == forms.fornecedor);
  return fornecedor[0].id;
}

public preencherSelect(){
  if(this.produto.ativo == true){
    this.ativo = 'Ativo';
    return [
      { id: '0', name: 'Inativo' },
      { id: '1', name: this.ativo }
    ];
  }else if(this.produto.ativo == false){
    this.ativo = 'Inativo';
    return [
      { id: '0', name: this.ativo },
      { id: '1', name: 'Ativo' },
    ];
  }else{
    return [
      { id: '0', name: 'Error' },
      { id: '1', name: 'Error' },
    ];
  }
}

public preencherAtivo(forms:any){
  if(forms.ativo == "Ativo"){
    this.produto.ativo = true;
  }
  else{
    this.produto.ativo = false;
  }
}

  public validation(): void {
    this.form = this.fb.group({
      nome: [
        null,
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(50),
        ],
      ],
      quantidade: [null, Validators.required],
      precoCompra: [null, Validators.required],
      precoVenda: [null, Validators.required],
      codigo: [null, Validators.required],
      dataCadastroProduto: [null, Validators.required],
      fornecedor: [null, Validators.required],
      ativo: [null, Validators.required]
    });
  }

  somenteNumeros(e: any):boolean {
    let charCode = e.charCode ? e.charCode : e.keyCode;
    // charCode 8 = backspace
    // charCode 9 = tab

    if (charCode != 8 && charCode != 9) {
      // charCode 48 equivale a 0
      // charCode 57 equivale a 9
      let max = 100;

      if ((charCode < 48 || charCode > 57)||(e.target.value.length >= max)) return false;
    }
    return true;
  }

  get f(): any {
    return this.form.controls;
  }

  public cssValidator(campoForm: FormControl | AbstractControl): any {
    return { 'is-invalid': campoForm.errors && campoForm.touched };
  }

  public Voltar(){
    this.router.navigate(['produtos/lista']);
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
