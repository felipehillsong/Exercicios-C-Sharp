import { DatePipe } from '@angular/common';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import * as moment from 'moment';
import { ToastrService } from 'ngx-toastr';
import { Titulos } from 'src/app/enums/titulos';
import { Cep } from 'src/app/models/cep';
import { Fornecedor } from 'src/app/models/fornecedor';
import { AuthService } from 'src/app/services/login/auth.service';
import { FornecedorService } from 'src/app/services/fornecedor/fornecedor.service';
import { NavService } from 'src/app/services/nav/nav.service';
import { TituloService } from 'src/app/services/titulo/titulo.service';

@Component({
  selector: 'app-fornecedor-detalhe',
  templateUrl: './fornecedor-detalhe.component.html',
  styleUrls: ['./fornecedor-detalhe.component.scss'],
  providers: [DatePipe],
})
export class FornecedorDetalheComponent implements OnInit {
  titulo =  Titulos.detalheFornecedor;
  form!: FormGroup;
  fornecedor = {} as Fornecedor;
  dataHoje!:string;
  cep!:string;
  cepBD = {} as Cep;
  keyError!:string;
  valueError!:string;
  ativo!:string;
  fornecedorId!: number;

  constructor(private router: Router, public titu: TituloService, private authService: AuthService, private fornecedorService: FornecedorService, private toastr: ToastrService, public nav: NavService, private _changeDetectorRef: ChangeDetectorRef, private route: ActivatedRoute) { }

  ngOnInit() {
    this.permissoesDeTela();
    this.getFornecedorById();
  }

  public getFornecedorById(): void{
    this.fornecedorId = this.route.snapshot.params['id'];
    this.fornecedorService.getFornecedorById(this.fornecedorId).subscribe(
      (_fornecedor: Fornecedor) => {
        this.fornecedor = _fornecedor;
        this.preencherSelect();
        var dataBD = moment(this.fornecedor.dataCadastroFornecedor).format('YYYY-MM-DD');
        this.fornecedor.dataCadastroFornecedor = dataBD;
        this._changeDetectorRef.markForCheck();
        console.log(this.fornecedor);
      },
      error => console.log(error)
    );
  }

  public preencherSelect(){
    if(this.fornecedor.ativo == true){
      this.ativo = 'Ativo';
      return [
        { id: '0', name: 'Inativo' },
        { id: '1', name: this.ativo }
      ];
    }else if(this.fornecedor.ativo == false){
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

  public Voltar(){
    this.router.navigate(['fornecedores/lista']);
  }

  isTelefone(): boolean{
    return this.fornecedor.telefone == null ? true : this.fornecedor.telefone.length < 12 ? true : false;
  }

 getTelefoneMask(): string{
    return this.isTelefone() ? '99 9999-99999' : '(99) 99999-9999';
  }

  somenteNumeros(e: any):boolean {
    let charCode = e.charCode ? e.charCode : e.keyCode;
    // charCode 8 = backspace
    // charCode 9 = tab

    if (charCode != 8 && charCode != 9) {
      // charCode 48 equivale a 0
      // charCode 57 equivale a 9
      let max = 10;

      if ((charCode < 48 || charCode > 57)||(e.target.value.length >= max)) return false;
    }
    return true;
  }

  permissoesDeTela(){
    this.authService.verificaAdministrador();
    this.authService.visualizarCliente();
    this.authService.visualizarFornecedor();
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
