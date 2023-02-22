import {ChangeDetectorRef, Component, OnInit} from '@angular/core';
import {AbstractControl, FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import { Router } from '@angular/router';
import { BsModalRef } from 'ngx-bootstrap';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import {Observable} from 'rxjs';
import {map, startWith} from 'rxjs/operators';
import { Botoes } from 'src/app/enums/botoes';
import { FontAwesome } from 'src/app/enums/fontAwesome';
import { Titulos } from 'src/app/enums/titulos';
import { ClientePedido } from 'src/app/models/ClientePedido';
import { Login } from 'src/app/models/login';
import { Pedido } from 'src/app/models/pedido';
import { AuthService } from 'src/app/services/login/auth.service';
import { NavService } from 'src/app/services/nav/nav.service';
import { PedidoService } from 'src/app/services/pedido/pedido.service';
import { TituloService } from 'src/app/services/titulo/titulo.service';
@Component({
  selector: 'app-pedido-criar',
  templateUrl: './pedido-criar.component.html',
  styleUrls: ['./pedido-criar.component.scss']
})
export class PedidoCriarComponent implements OnInit {
  titulo =  Titulos.cadastroPedidos;
  form!: FormGroup;
  public loginUsuario!: Login;
  clientesPedidos!: ClientePedido[];
  clientePedido = {} as ClientePedido;
  control = new FormControl('');
  nomes:string[] = [];
  filteredNomes!: Observable<string[]>;

  constructor(private router: Router, public titu: TituloService, private fb: FormBuilder, private pedidoService: PedidoService, private toastr: ToastrService, private spinner: NgxSpinnerService, public nav: NavService, private _changeDetectorRef: ChangeDetectorRef, private authService: AuthService) { }

  ngOnInit() {
    this.permissoesDeTela();
    this.getClientesPedido();
    this.validation();
  }

  public getClientesPedido(): void{
    this.pedidoService.getPedidoClientes(this.authService.empresaId()).subscribe(
      (_clientesPedidos: ClientePedido[]) => {
        this.clientesPedidos = _clientesPedidos;
        console.log(this.clientesPedidos);
        for(let i = 0; i < this.clientesPedidos.length; i++){
          this.nomes[i] = this.clientesPedidos[i].nome;
        }
        this.filteredNomes = this.control.valueChanges.pipe(
          startWith(''),
          map(value => this._filter(value || '')),
        );
      },
      error => console.log(error)
    );
  }

  public Enviar(): void {
    /*this.spinner.show();
    if(this.form.valid){
      this.produto = {...this.form.value};
      this.produto.fornecedorId = this.form.value.fornecedor.id;
      this.produto.empresaId = this.authService.empresaId();
      this.produtoService.addProduto(this.produto).subscribe(() => {
        this.router.navigate(['produtos/lista']);
      },
      (error: any) => {
        console.error(error);
        this.spinner.hide();
        this.toastr.error(error.error);
      },
      () => this.spinner.hide()
    );
  }*/
}

  private _filter(value: string): string[] {
    const filterValue = this._normalizeValue(value);
    return this.nomes.filter(nomes => this._normalizeValue(nomes).includes(filterValue));
  }

  private _normalizeValue(value: string): string {
    return value.toLowerCase().replace(/\s/g, '');
  }

  get f(): any {
    return this.form.controls;
  }

  public cssValidator(campoForm: FormControl | AbstractControl): any {
    return { 'is-invalid': campoForm.errors && campoForm.touched };
  }

  public Voltar(){
    this.router.navigate(['pedidos/lista']);
  }

  public validation(): void {
    this.form = this.fb.group({
      nome: ['', Validators.required]
    });
  }

  permissoesDeTela(){
    this.authService.verificaAdministrador();
    this.authService.visualizarCliente();
    this.authService.visualizarFornecedor();
    this.authService.visualizarProduto();
    this.authService.visualizarEstoque();
    this.authService.visualizarEnderecoProduto();
    this.authService.visualizarFuncionario();
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


