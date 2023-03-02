import {ChangeDetectorRef, Component, OnInit} from '@angular/core';
import {AbstractControl, FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { map, Observable, startWith } from 'rxjs';
import { Titulos } from 'src/app/enums/titulos';
import { Login } from 'src/app/models/login';
import { Pedido } from 'src/app/models/pedido';
import { AuthService } from 'src/app/services/login/auth.service';
import { NavService } from 'src/app/services/nav/nav.service';
import { PedidoService } from 'src/app/services/pedido/pedido.service';
import { TituloService } from 'src/app/services/titulo/titulo.service';
import { _MatOptionBase } from '@angular/material/core';
import { MensagensAlerta } from 'src/app/enums/mensagensAlerta';
import { ClienteService } from 'src/app/services/cliente/cliente.service';
import { Cliente } from 'src/app/models/cliente';
import { TransportadorService } from 'src/app/services/transportador/transportador.service';
import { Transportador } from 'src/app/models/transportador';
import { ProdutoService } from 'src/app/services/produto/produto.service';
import { Produto } from 'src/app/models/produto';
@Component({
  selector: 'app-pedido-criar',
  templateUrl: './pedido-criar.component.html',
  styleUrls: ['./pedido-criar.component.scss']
})
export class PedidoCriarComponent implements OnInit {
[x: string]: any;
  titulo =  Titulos.cadastroPedidos;
  formCliente!: FormGroup;
  formProduto!: FormGroup;
  form!: FormGroup;
  public loginUsuario!: Login;
  pedidoNome: Pedido[] = [];
  public clientes: Cliente[] = [];
  public transportadores: Transportador[] = [];
  public produtos: Produto[] = [];
  public pedidoProdutos = {} as Produto;
  public produtosGrid: Produto[] = [];
  gerarPedido = {} as Pedido;
  produto = {} as Produto;
  clienteControl = new FormControl('');
  produtoControl = new FormControl('');
  transportadorControl = new FormControl('');
  filteredClientes!: Observable<Cliente[]>;
  filteredTransportadores!: Observable<Transportador[]>;
  filteredProdutos!: Observable<Produto[]>;
  clienteId!:number;
  transportadorId!:number;
  produtoId!:number;
  usuarioId!:number;
  mostrarProduto:boolean = false;
  mostrarGrid:boolean = false;
  indice:number = 0;

  constructor(private router: Router, public titu: TituloService, private fb: FormBuilder, private fbProduto: FormBuilder, private produtoService: ProdutoService, private clienteService: ClienteService, private transportadorService: TransportadorService, private pedidoService: PedidoService, private toastr: ToastrService, private spinner: NgxSpinnerService, public nav: NavService, private _changeDetectorRef: ChangeDetectorRef, private authService: AuthService) { }

  ngOnInit() {
    this.permissoesDeTela();
    this.getClientes();
    this.getTransportadores();
    this.getProdutos();
    this.validationCliente();
    this.validationProduto();
  }

  public getClientes(): void{
    this.clienteService.getClientes(this.authService.empresaId()).subscribe(
      (_clientes: Cliente[]) => {
        this.clientes = _clientes;
        this.filteredClientes = this.clienteControl.valueChanges.pipe(
          startWith(''),
          map(value => this._filterClientes(value || '')),
        );
        this._changeDetectorRef.markForCheck();
      },
      error => console.log(error)
    );
  }

  public getTransportadores(): void{
    this.transportadorService.getTransportadores(this.authService.empresaId()).subscribe(
      (_transportadores: Transportador[]) => {
        this.transportadores = _transportadores;
        this.filteredTransportadores = this.transportadorControl.valueChanges.pipe(
          startWith(''),
          map(value => this._filterTransportadores(value || '')),
        );
        this._changeDetectorRef.markForCheck();
      },
      error => console.log(error)
    );
  }

  public getProdutos(): void{
    this.produtoService.getProdutos(this.authService.empresaId()).subscribe(
      (_produtos: Produto[]) => {
        this.produtos = _produtos;
        this.filteredProdutos = this.produtoControl.valueChanges.pipe(
          startWith(''),
          map(value => this._filterProdutos(value || '')),
        );
        this._changeDetectorRef.markForCheck();
      },
      error => console.log(error)
    );
  }

  private _filterClientes(value: string): Cliente[] {
    const filterCliente = value.toLowerCase();
    var cliente = this.clientes.filter(cliente => cliente.nome.toLowerCase().includes(filterCliente));
    return cliente;
  }

  private _filterTransportadores(value: string): Transportador[] {
    const filterTransportador = value.toLowerCase();
    var transportador = this.transportadores.filter(transportador => transportador.nome.toLowerCase().includes(filterTransportador));
    return transportador;
  }

  private _filterProdutos(value: string): Produto[] {
    const filterProduto = value.toLowerCase();
    var produto = this.produtos.filter(produto => produto.nome.toLowerCase().includes(filterProduto));
    return produto;
  }

  public pegarClienteId(id:number){
    const selectedCliente = this.clientes.find(cliente => cliente.id === id);
    if(selectedCliente != null){
      this.clienteId = selectedCliente?.id;
    }
  }

  public pegarTransportadorId(id:number){
    const selectedTransportador = this.transportadores.find(transportador => transportador.id === id);
    if(selectedTransportador != null){
      this.transportadorId = selectedTransportador?.id;
    }
  }

  public pegarProdutoId(id:number){
    this.produtoId = id;
    const selectedProduto = this.produtos.find(produto => produto.id === id);
    if(selectedProduto != null){
      this.pedidoProdutos.id = selectedProduto.id;
      this.pedidoProdutos.nome = selectedProduto.nome;
      this.pedidoProdutos.quantidade = selectedProduto.quantidade;
      this.pedidoProdutos.ativo = selectedProduto.ativo;
      this.pedidoProdutos.precoCompra = selectedProduto.precoCompra;
      this.pedidoProdutos.precoVenda = selectedProduto.precoVenda;
      this.pedidoProdutos.precoCompraFormatado = selectedProduto.precoCompraFormatado;
      this.pedidoProdutos.precoVendaFormatado = selectedProduto.precoVendaFormatado;
      this.pedidoProdutos.codigo = selectedProduto.codigo;
      this.pedidoProdutos.dataCadastroProduto = selectedProduto.dataCadastroProduto;
      this.pedidoProdutos.empresaId = selectedProduto.empresaId;
      this.pedidoProdutos.fornecedorId = selectedProduto.fornecedorId;
    }
  }

  onOptionSelectedCliente(event: MatAutocompleteSelectedEvent) {
    if (event.source._keyManager.activeItem) {
      const selectedOptionId = (event.option as _MatOptionBase)._getHostElement().getAttribute('data-id');
      if(selectedOptionId !== null){
        const selectedCliente = this.clientes.find(cliente => cliente.id === parseInt(selectedOptionId, 10));
        if(selectedCliente != null){
          this.clienteId = selectedCliente.id;
        }
      }
    }
  }

  onOptionSelectedTransportador(event: MatAutocompleteSelectedEvent) {
    if (event.source._keyManager.activeItem) {
      const selectedOptionId = (event.option as _MatOptionBase)._getHostElement().getAttribute('data-id');
      if(selectedOptionId !== null){
        const selectedTransportador = this.transportadores.find(transportador => transportador.id === parseInt(selectedOptionId, 10));
        if(selectedTransportador != null){
          this.transportadorId = selectedTransportador.id;
        }
      }
    }
  }

  onOptionSelectedProduto(event: MatAutocompleteSelectedEvent) {
    if (event.source._keyManager.activeItem) {
      const selectedOptionId = (event.option as _MatOptionBase)._getHostElement().getAttribute('data-id');
      if(selectedOptionId !== null){
        const selectedProduto = this.produtos.find(produto => produto.id === parseInt(selectedOptionId, 10));
        if(selectedProduto != null){
          this.produtoId = selectedProduto.id;
          this.pedidoProdutos.id = selectedProduto.id;
          this.pedidoProdutos.nome = selectedProduto.nome;
          this.pedidoProdutos.quantidade = selectedProduto.quantidade;
          this.pedidoProdutos.ativo = selectedProduto.ativo;
          this.pedidoProdutos.precoCompra = selectedProduto.precoCompra;
          this.pedidoProdutos.precoVenda = selectedProduto.precoVenda;
          this.pedidoProdutos.precoCompraFormatado = selectedProduto.precoCompraFormatado;
          this.pedidoProdutos.precoVendaFormatado = selectedProduto.precoVendaFormatado;
          this.pedidoProdutos.codigo = selectedProduto.codigo;
          this.pedidoProdutos.dataCadastroProduto = selectedProduto.dataCadastroProduto;
          this.pedidoProdutos.empresaId = selectedProduto.empresaId;
          this.pedidoProdutos.fornecedorId = selectedProduto.fornecedorId;
        }
      }
    }
  }

  public VerificaIdCliente(id:number):boolean{
    let retorno:boolean = false;
    for (let i = 0; i < this.clientes.length; i++) {
      if (this.clientes[i].id === id) {
        retorno = true;
        break;
      }else{
        retorno = false;
      }
    }
    return retorno;
  }

  public VerificaIdTransportador(id:number):boolean{
    let retorno:boolean = false;
    for (let i = 0; i < this.transportadores.length; i++) {
      if (this.transportadores[i].id === id) {
        retorno = true;
        break;
      }else{
        retorno = false;
      }
    }
    return retorno;
  }

  public VerificaIdProduto(id:number):boolean{
    let retorno:boolean = false;
    for (let i = 0; i < this.produtos.length; i++) {
      if (this.produtos[i].id === id) {
        retorno = true;
        break;
      }else{
        retorno = false;
      }
    }
    return retorno;
  }

  public SelecionarCliente(){
    var clienteTransportadorNome = {...this.formCliente.value};
    for (let i = 0; i < this.clientes.length; i++) {
      if (this.clientes[i].nome === clienteTransportadorNome.clienteNome && this.clientes[i].id === this.clienteId) {
        this.mostrarProduto = true;
        break;
      }else{
        this.mostrarProduto = false;
      }
    }

    for (let i = 0; i < this.clientes.length; i++) {
      if (this.transportadores[i].nome === clienteTransportadorNome.transportadorNome && this.transportadores[i].id === this.transportadorId) {
        this.mostrarProduto = true;
        break;
      }else{
        this.mostrarProduto = false;
      }
    }

  }

  public SelecionarProduto(){
    for (let i = 0; i < this.produtos.length; i++) {
      if (this.produtos[i].nome === this.produto.nome && this.produtos[i].id === this.produtoId) {
        const produtoPedido = {
          id: this.pedidoProdutos.id,
          nome: this.pedidoProdutos.nome,
          quantidade: this.pedidoProdutos.quantidade,
          ativo: this.pedidoProdutos.ativo,
          precoCompra: this.pedidoProdutos.precoCompra,
          precoVenda: this.pedidoProdutos.precoVenda,
          precoCompraFormatado: this.pedidoProdutos.precoCompraFormatado,
          precoVendaFormatado: this.pedidoProdutos.precoVendaFormatado,
          codigo: this.pedidoProdutos.codigo,
          dataCadastroProduto: this.pedidoProdutos.dataCadastroProduto,
          empresaId: this.pedidoProdutos.empresaId,
          fornecedorId: this.pedidoProdutos.fornecedorId
        };
          this.produtosGrid.push(produtoPedido);
          this.mostrarProduto = true;
        break;
      }else{
        this.mostrarProduto = false;
      }
    }
    console.log(this.produtosGrid);
  }

  public Enviar(): void {
    this.spinner.show();
    if(this.form.valid){
      this.gerarPedido = {...this.form.value};
      var existeCliente = this.VerificaIdCliente(this.clienteId);
      var existeTransportador = this.VerificaIdTransportador(this.transportadorId);
      if(existeCliente && existeTransportador && this.authService.idDoUsuarioLogado()){
        this.pedidoService.addPedido(this.gerarPedido).subscribe(() => {
          this.router.navigate(['produtos/lista']);
        },
        (error: any) => {
          console.error(error);
          this.spinner.hide();
          this.toastr.error(error.error);
        },
        () => this.spinner.hide()
      );
      }else{
          this.spinner.hide();
          this.toastr.error(MensagensAlerta.ClienteTransportadorUsuarioInexistente);
      }
      () => this.spinner.hide()
  }
}

  get f(): any {
    return this.formCliente.controls;
  }

  get p(): any {
    return this.formProduto.controls;
  }

  public cssValidatorCliente(campoForm: FormControl | AbstractControl): any {
    return { 'is-invalid': campoForm.errors && campoForm.touched };
  }

  public cssValidatorProduto(campoForm: FormControl | AbstractControl): any {
    return { 'is-invalid': campoForm.errors && campoForm.touched };
  }

  public Voltar(){
    this.router.navigate(['pedidos/lista']);
  }

  public validationCliente(): void {
    this.formCliente = this.fb.group({
      clienteNome: [null, Validators.required],
      transportadorNome: [null, Validators.required]
    });
  }

  public validationProduto(): void {
    this.formProduto = this.fbProduto.group({
      nome: [null, Validators.required]
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


