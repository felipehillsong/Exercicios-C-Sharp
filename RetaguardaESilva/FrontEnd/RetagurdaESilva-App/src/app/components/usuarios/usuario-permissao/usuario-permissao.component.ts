import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Titulos } from 'src/app/enums/titulos';
import { Permissao } from 'src/app/models/permissao';
import { Usuario } from 'src/app/models/usuario';
import { AuthService } from 'src/app/services/auth.service';
import { NavService } from 'src/app/services/nav.service';
import { TituloService } from 'src/app/services/titulo.service';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-usuario-permissao',
  templateUrl: './usuario-permissao.component.html',
  styleUrls: ['./usuario-permissao.component.scss']
})
export class UsuarioPermissaoComponent implements OnInit {
  titulo =  Titulos.permissaoUsuario;
  form!: FormGroup;
  usuario = {} as Usuario;
  usuarioRetornoEdit = {} as Usuario;
  permissoes = {} as Permissao;
  usuarioId!: number;
  nome!: string;
  permissaoId!:number;
  toastr: any;

  constructor(private router: Router, private fb: FormBuilder, public titu: TituloService, private spinner: NgxSpinnerService, public nav: NavService, private authService: AuthService, private route: ActivatedRoute, private usuarioService: UsuarioService, private _changeDetectorRef: ChangeDetectorRef) { }

  ngOnInit() {
    this.authService.verificaAdministrador();
    this.nav.hide();
    this.titu.hide();
    this.titu.showTitulo();
    this.getUsuarioById();
    this.validation();
  }

  public getUsuarioById(): void{
    this.usuarioId = this.route.snapshot.params['id'];
    this.usuarioService.getUsuarioById(this.usuarioId).subscribe(
      (_usuario: Usuario) => {
        this.usuario = _usuario;
        this.nome = this.usuario.nome;
        this.permissaoId = this.usuario.permissoes[0].id;
        this.permissoes = this.usuario.permissoes[0];
        this._changeDetectorRef.markForCheck();
      },
      error => console.log(error)
    );
  }

 public preencherChecks(permissao:Permissao):void{
    this.usuario.permissoes[0] = permissao;
    this.usuario.permissoes[0].id = this.permissaoId;
    this.usuario.permissoes[0].empresaId = this.authService.empresaId();
    this.usuario.permissoes[0].usuarioId = this.usuarioId;
 }

  public Salvar(){
    this.spinner.show();
    if(this.form.valid){
      this.permissoes = {...this.form.value};
      this.preencherChecks(this.permissoes);
      this.usuarioService.editUsuario(this.usuario).subscribe(
        (_usuario: Usuario) => {
          this.usuarioRetornoEdit = _usuario;
          if(this.usuarioRetornoEdit.id == this.authService.idDoUsuarioLogado()){
          sessionStorage.clear();
          sessionStorage.setItem('loginRetorno', JSON.stringify(this.usuarioRetornoEdit));
          console.log(this.usuarioRetornoEdit);
          this._changeDetectorRef.markForCheck();
        this.router.navigate(['usuarios/lista']);
          }
      },
      (error: any) => {
        console.error(error);
        this.spinner.hide();
        this.toastr.error(error.error);
      },
      () => this.spinner.hide()
    );
  }
}

public validation(): void {
  this.form = this.fb.group({
    clienteCadastro: [null],
    clienteEditar: [null],
    clienteDetalhe: [null],
    clienteExcluir: [null],
    empresaCadastro: [null],
    empresaEditar: [null],
    empresaDetalhe: [null],
    empresaExcluir: [null],
    estoqueCadastro: [null],
    estoqueEditar: [null],
    estoqueDetalhe: [null],
    estoqueExcluir: [null],
    fornecedorCadastro: [null],
    fornecedorEditar: [null],
    fornecedorDetalhe: [null],
    fornecedorExcluir: [null],
    funcionarioCadastro: [null],
    funcionarioEditar: [null],
    funcionarioDetalhe: [null],
    funcionarioExcluir: [null],
    produtoCadastro: [null],
    produtoEditar: [null],
    produtoDetalhe: [null],
    produtoExcluir: [null],
    relatorioCadastro: [null],
    relatorioEditar: [null],
    relatorioDetalhe: [null],
    relatorioExcluir: [null],
    transportadorCadastro: [null],
    transportadorEditar: [null],
    transportadorDetalhe: [null],
    transportadorExcluir: [null],
    usuarioCadastro: [null],
    usuarioEditar: [null],
    usuarioPermissoes: [null],
    usuarioExcluir: [null],
    vendaCadastro: [null],
    vendaEditar: [null],
    vendaDetalhe: [null],
    vendaExcluir: [null],
    visualizarCliente: [null],
    visualizarEstoque: [null],
    visualizarFornecedor: [null],
    visualizarFuncionario: [null],
    visualizarProduto: [null],
    visualizarTransportador: [null],
    visualizarEmpresa: [null],
    visualizarUsuario: [null],
    visualizarVenda: [null],
    visualizarRelatorio: [null],
    empresaId: [null],
    usuarioId: [null]
  });
}

  public Voltar(){
    this.router.navigate(['usuarios/lista']);
  }

}
