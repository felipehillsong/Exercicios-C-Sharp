import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalService } from 'ngx-bootstrap';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/services/login/auth.service';
import { NavService } from 'src/app/services/nav/nav.service';
import { TituloService } from 'src/app/services/titulo/titulo.service';
import { Select2Option, Select2UpdateEvent } from 'ng-select2-component';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PedidoService } from 'src/app/services/pedido/pedido.service';
import { Pedido } from 'src/app/models/pedido';
import 'select2';
import * as $ from 'jquery';
@Component({
  selector: 'app-pedido-criar',
  templateUrl: './pedido-criar.component.html',
  styleUrls: ['./pedido-criar.component.scss']
})
export class PedidoCriarComponent implements OnInit {
  form!: FormGroup;
  public clientesNome: Pedido[] = [];
  clientesFiltrados: Pedido[] = [];
  public clientesNomes!: any;
  nomes!: string[];
  overlay = false;
  public exampleData: any;

  constructor(private router: Router, private fb: FormBuilder, private pedidoService: PedidoService, public titu: TituloService, public nav: NavService, private authService: AuthService, private modalService: BsModalService, private spinner: NgxSpinnerService, private toastr: ToastrService, private _changeDetectorRef: ChangeDetectorRef) { }

  ngOnInit() {
    this.permissoesDeTela();
    this.getClientes();
  }
  public getClientes(): void{
    this.pedidoService.getPedidoClientes(this.authService.empresaId()).subscribe(
      (_clientesNome: Pedido[]) => {
        this.clientesNome = _clientesNome;
        this.clientesNomes = [
          {
            label: 'A',
            options: [
                { value: this.clientesNome[0].id, label: this.clientesNome[0].clienteNome },
                { value: 'HI', label: 'Hawaii', disabled: true },
            ],
        }
        ]
        console.log(this.clientesNome);
        console.log(this.clientesNomes);
      },
      error => console.log(error)
    );
  }

  /*public getClientes(): void{
    this.pedidoService.getPedidoClientes(this.authService.empresaId()).subscribe((names) => {
      this.clientesNomes = names;
      this.nomes = this.clientesNomes;
      $('#select2').select2({
        data: this.nomes.map((nome: any) => ({ id: nome, text: nome })),
        placeholder: 'Selecione um nome',
      });
        console.log(this.clientesNomes);
      },
      error => console.log(error)
    );
  }*/

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
    this.nav.show();
    this.titu.show();
    this.titu.hideTitulo();
  }

change(key: string, event: Event) {
  console.log(key, event);
}
search(text: string) {
  this.clientesNomes = text
      ? (JSON.parse(JSON.stringify(this.clientesNomes)) as Select2Option[]).filter(
            option => option.label.toLowerCase().indexOf(text.toLowerCase()) > -1,
        )
      : JSON.parse(JSON.stringify(this.clientesNomes));
}
update(key: string, event: Select2UpdateEvent<any>) {
  console.log(event.value);
}
}


