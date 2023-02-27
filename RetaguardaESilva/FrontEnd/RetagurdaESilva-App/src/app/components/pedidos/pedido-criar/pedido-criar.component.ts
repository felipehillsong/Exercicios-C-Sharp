import {ChangeDetectorRef, Component, OnInit} from '@angular/core';
import {AbstractControl, FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { distinctUntilChanged, map, startWith } from 'rxjs/operators';
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
@Component({
  selector: 'app-pedido-criar',
  templateUrl: './pedido-criar.component.html',
  styleUrls: ['./pedido-criar.component.scss']
})
export class PedidoCriarComponent implements OnInit {
[x: string]: any;
  titulo =  Titulos.cadastroPedidos;
  form!: FormGroup;
  public loginUsuario!: Login;
  pedidoNome: Pedido[] = [];
  public clientes: Cliente[] = [];
  public transportadores: Transportador[] = [];
  gerarPedido = {} as Pedido;
  clienteControl = new FormControl('');
  transportadorControl = new FormControl('');
  nomes:string[] = [];
  filteredClientes!: Observable<Cliente[]>;
  filteredTransportadores!: Observable<Transportador[]>;
  clienteId!:number;
  transportadorId!:number;
  usuarioId!:number;

  constructor(private router: Router, public titu: TituloService, private fb: FormBuilder, private clienteService: ClienteService, private transportadorService: TransportadorService, private pedidoService: PedidoService, private toastr: ToastrService, private spinner: NgxSpinnerService, public nav: NavService, private _changeDetectorRef: ChangeDetectorRef, private authService: AuthService) { }

  ngOnInit() {
    this.permissoesDeTela();
    this.getClientes();
    this.getTransportadores();
    this.validation();
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
        console.log(this.filteredClientes);
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

  onOptionSelectedCliente(event: MatAutocompleteSelectedEvent) {
    if (event.source._keyManager.activeItem) {
      const selectedOptionId = (event.option as _MatOptionBase)._getHostElement().getAttribute('data-id');
      if(selectedOptionId !== null){
        const selectedCliente = this.clientes.find(cliente => cliente.id === parseInt(selectedOptionId, 10));
        if(selectedCliente != null){
          this.clienteId = selectedCliente?.id;
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
          this.transportadorId = selectedTransportador?.id;
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
      clienteNome: [null, Validators.required],
      transportadorNome: [null, Validators.required]
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


