import {ChangeDetectorRef, Component, OnInit} from '@angular/core';
import {AbstractControl, FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { MatSelectChange } from '@angular/material/select';
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
import { _MatOptionBase } from '@angular/material/core';
import { MensagensAlerta } from 'src/app/enums/mensagensAlerta';
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
  gerarPedido = {} as Pedido;
  control = new FormControl('');
  nomes:string[] = [];
  filteredNomes!: Observable<Pedido[]>;
  nomeFiltrado!:Pedido[];

  constructor(private router: Router, public titu: TituloService, private fb: FormBuilder, private pedidoService: PedidoService, private toastr: ToastrService, private spinner: NgxSpinnerService, public nav: NavService, private _changeDetectorRef: ChangeDetectorRef, private authService: AuthService) { }

  ngOnInit() {
    this.permissoesDeTela();
    this.getClientesPedido();
    this.validation();
  }

  public getClientesPedido(): void{
    this.pedidoService.getPedidoClientes(this.authService.empresaId()).subscribe(
      (_clientesPedidos: Pedido[]) => {
        this.pedidoNome = _clientesPedidos;
        this.filteredNomes = this.control.valueChanges.pipe(
          startWith(''),
          map(value => this._filter(value || '')),
        );
      },
      error => console.log(error)
    );
  }

  public Enviar(): void {
    this.spinner.show();
    if(this.form.valid){
      this.gerarPedido = {...this.form.value};
      if(this.VerificaNomeCliente(this.gerarPedido.clienteNome)){
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
          this.toastr.error(MensagensAlerta.ClienteInexistente);
      }
      () => this.spinner.hide()
  }
}

  private _filter(value: string): Pedido[] {
    const filterValue = value.toLowerCase();
    var cliente = this.pedidoNome.filter(nome => nome.clienteNome.toLowerCase().includes(filterValue));
    return cliente;
  }

  public pegarClienteId(id:number){
    const selectedCliente = this.pedidoNome.find(cliente => cliente.clienteId === id);
    console.log(selectedCliente);
  }

  onOptionSelected(event: MatAutocompleteSelectedEvent) {
    if (event.source._keyManager.activeItem) {
      const selectedOptionId = (event.option as _MatOptionBase)._getHostElement().getAttribute('data-id');
      if(selectedOptionId !== null){
        const selectedCliente = this.pedidoNome.find(cliente => cliente.clienteId === parseInt(selectedOptionId, 10));
        console.log('ENTROU AQUI', selectedCliente);
      }
    }
  }

  public VerificaNomeCliente(nome:string):boolean{
    let retorno:boolean = false;
    for (let i = 0; i < this.pedidoNome.length; i++) {
      if (this.pedidoNome[i].clienteNome === nome) {
        retorno = true;
        break;
      }else{
        retorno = false;
      }
    }
    return retorno;
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
      clienteNome: ['', Validators.required]
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


