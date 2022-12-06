import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClienteCriarComponent } from './components/clientes/cliente-criar/cliente-criar.component';
import { ClienteDetalheComponent } from './components/clientes/cliente-detalhe/cliente-detalhe.component';
import { ClienteEditarComponent } from './components/clientes/cliente-editar/cliente-editar.component';
import { ClienteListaComponent } from './components/clientes/cliente-lista/cliente-lista.component';
import { ClienteComponent } from './components/clientes/cliente.component';
import { EmpresaCriarComponent } from './components/empresas/empresa-criar/empresa-criar.component';
import { EmpresaDetalheComponent } from './components/empresas/empresa-detalhe/empresa-detalhe.component';
import { EmpresaEditarComponent } from './components/empresas/empresa-editar/empresa-editar.component';
import { EmpresaListaComponent } from './components/empresas/empresa-lista/empresa-lista.component';
import { EmpresaComponent } from './components/empresas/empresa.component';
import { FornecedorCriarComponent } from './components/fornecedores/fornecedor-criar/fornecedor-criar.component';
import { FornecedorDetalheComponent } from './components/fornecedores/fornecedor-detalhe/fornecedor-detalhe.component';
import { FornecedorEditarComponent } from './components/fornecedores/fornecedor-editar/fornecedor-editar.component';
import { FornecedorListaComponent } from './components/fornecedores/fornecedor-lista/fornecedor-lista.component';
import { FornecedorComponent } from './components/fornecedores/fornecedor.component';
import { FuncionarioCriarComponent } from './components/funcionarios/funcionario-criar/funcionario-criar.component';
import { FuncionarioDetalheComponent } from './components/funcionarios/funcionario-detalhe/funcionario-detalhe.component';
import { FuncionarioEditarComponent } from './components/funcionarios/funcionario-editar/funcionario-editar.component';
import { FuncionarioListaComponent } from './components/funcionarios/funcionario-lista/funcionario-lista.component';
import { FuncionarioComponent } from './components/funcionarios/funcionario.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { TransportadorCriarComponent } from './components/transportadores/transportador-criar/transportador-criar.component';
import { TransportadorDetalheComponent } from './components/transportadores/transportador-detalhe/transportador-detalhe.component';
import { TransportadorEditarComponent } from './components/transportadores/transportador-editar/transportador-editar.component';
import { TransportadorListaComponent } from './components/transportadores/transportador-lista/transportador-lista.component';
import { TransportadorComponent } from './components/transportadores/transportador.component';
import { UsuarioCriarComponent } from './components/usuarios/usuario-criar/usuario-criar.component';
import { UsuarioEditarComponent } from './components/usuarios/usuario-editar/usuario-editar.component';
import { UsuarioListaComponent } from './components/usuarios/usuario-lista/usuario-lista.component';
import { UsuarioPermissaoComponent } from './components/usuarios/usuario-permissao/usuario-permissao.component';
import { UsuarioSelecionarFuncionarioComponent } from './components/usuarios/usuario-selecionar-funcionario/usuario-selecionar-funcionario.component';
import { UsuarioComponent } from './components/usuarios/usuario.component';
import { AuthGuardsEmpresaEditarService } from './guards/Empresa/AuthGuardsEmpresaEditar.service';
import { AuthGuardsClienteService } from './guards/Cliente/AuthGuardsCliente.service';
import { AuthGuardsClienteCadastroService } from './guards/Cliente/AuthGuardsClienteCadastro.service';
import { AuthGuardsClienteDetalheService } from './guards/Cliente/AuthGuardsClienteDetalhe.service';
import { AuthGuardsClienteEditarService } from './guards/Cliente/AuthGuardsClienteEditar.service';
import { AuthGuardsEmpresaService } from './guards/Empresa/AuthGuardsEmpresa.service';
import { AuthGuardsEmpresaCadastroService } from './guards/Empresa/AuthGuardsEmpresaCadastro.service';
import { AuthGuardsEmpresaDetalheService } from './guards/Empresa/AuthGuardsEmpresaDetalhe.service';
import { AuthGuardsFornecedorService } from './guards/Fornecedor/AuthGuardsFornecedor.service';
import { AuthGuardsFornecedorCadastroService } from './guards/Fornecedor/AuthGuardsFornecedorCadastro.service';
import { AuthGuardsFornecedorDetalheService } from './guards/Fornecedor/AuthGuardsFornecedorDetalhe.service';
import { AuthGuardsFornecedorEditarService } from './guards/Fornecedor/AuthGuardsFornecedorEditar.service';
import { AuthGuardsFuncionarioCadastroService } from './guards/funcionario/AuthGuardsFuncionarioCadastro.service';
import { AuthGuardsFuncionarioDetalheService } from './guards/funcionario/AuthGuardsFuncionarioDetalhe.service';
import { AuthGuardsFuncionarioEditarService } from './guards/funcionario/AuthGuardsFuncionarioEditar.service';
import { AuthGuardsService } from './guards/login/AuthGuardsService';
import { AuthGuardsTransportadorService } from './guards/transportador/AuthGuardsTransportador.service';
import { AuthGuardsUsuarioService } from './guards/usuario/AuthGuardsUsuario.service';
import { AuthGuardsFuncionarioService } from './guards/funcionario/AuthGuardsFuncionario.service';
import { AuthGuardsTransportadorCadastroService } from './guards/transportador/AuthGuardsTransportadorCadastro.service';
import { AuthGuardsTransportadorDetalheService } from './guards/transportador/AuthGuardsTransportadorDetalhe.service';
import { AuthGuardsTransportadorEditarService } from './guards/transportador/AuthGuardsTransportadorEditar.service';
import { AuthGuardsUsuarioCadastroService } from './guards/usuario/AuthGuardsUsuarioCadastro.service';
import { AuthGuardsUsuarioEditarService } from './guards/usuario/AuthGuardsUsuarioEditar.service';
import { AuthGuardsUsuarioPermissaoService } from './guards/usuario/AuthGuardsUsuarioPermissao.service';
import { ProdutoComponent } from './components/produtos/produto.component';
import { ProdutoCriarComponent } from './components/produtos/produto-criar/produto-criar.component';
import { ProdutoDetalheComponent } from './components/produtos/produto-detalhe/produto-detalhe.component';
import { ProdutoEditarComponent } from './components/produtos/produto-editar/produto-editar.component';
import { ProdutoListaComponent } from './components/produtos/produto-lista/produto-lista.component';
import { AuthGuardsProdutoService } from './guards/produto/AuthGuardsProduto.service';
import { AuthGuardsProdutoCadastroService } from './guards/produto/AuthGuardsProdutoCadastro.service';
import { AuthGuardsProdutoDetalheService } from './guards/produto/AuthGuardsProdutoDetalhe.service';
import { AuthGuardsProdutoEditarService } from './guards/produto/AuthGuardsProdutoEditar.service';

const routes: Routes = [
  { path: '', redirectTo: 'login', title: 'Login' },
  { path: 'clientes', canActivate:[AuthGuardsService, AuthGuardsClienteService],
  component: ClienteComponent,
  children:[
    {path: 'lista', title: 'Clientes', component: ClienteListaComponent },
    {path: 'criar', title: 'Cadastro', component: ClienteCriarComponent, canActivate: [AuthGuardsClienteCadastroService] },
    {path: 'editar/:id', title: 'Editar', component: ClienteEditarComponent, canActivate: [AuthGuardsClienteEditarService] },
    {path: 'detalhe/:id', title: 'Detalhe', component: ClienteDetalheComponent, canActivate: [AuthGuardsClienteDetalheService]}
  ]},
  { path: 'empresas', canActivate:[AuthGuardsService, AuthGuardsEmpresaService],
  component: EmpresaComponent,
  children:[
    {path: 'lista', title: 'Empresas', component: EmpresaListaComponent },
    {path: 'criar', title: 'Cadastro', component: EmpresaCriarComponent, canActivate: [AuthGuardsEmpresaCadastroService] },
    {path: 'editar/:id', title: 'Editar', component: EmpresaEditarComponent, canActivate: [AuthGuardsEmpresaEditarService] },
    {path: 'detalhe/:id', title: 'Detalhe', component: EmpresaDetalheComponent, canActivate: [AuthGuardsEmpresaDetalheService] }
  ]},
  { path: 'fornecedores', canActivate:[AuthGuardsService, AuthGuardsFornecedorService],
  component: FornecedorComponent,
  children:[
    {path: 'lista', title: 'Fornecedores', component: FornecedorListaComponent },
    {path: 'criar', title: 'Cadastro', component: FornecedorCriarComponent, canActivate: [AuthGuardsFornecedorCadastroService]},
    {path: 'editar/:id', title: 'Editar', component: FornecedorEditarComponent, canActivate: [AuthGuardsFornecedorEditarService] },
    {path: 'detalhe/:id', title: 'Detalhe', component: FornecedorDetalheComponent, canActivate: [AuthGuardsFornecedorDetalheService] }
  ]},
  { path: 'funcionarios', canActivate:[AuthGuardsService, AuthGuardsFuncionarioService],
  component: FuncionarioComponent,
  children:[
    {path: 'lista', title: 'Funcionarios', component: FuncionarioListaComponent },
    {path: 'criar', title: 'Cadastro', component: FuncionarioCriarComponent, canActivate: [AuthGuardsFuncionarioCadastroService]},
    {path: 'editar/:id', title: 'Editar', component: FuncionarioEditarComponent, canActivate: [AuthGuardsFuncionarioEditarService] },
    {path: 'detalhe/:id', title: 'Detalhe', component: FuncionarioDetalheComponent, canActivate: [AuthGuardsFuncionarioDetalheService] }
  ]},
  { path: 'login', component: LoginComponent, title: 'Login' },
  { path: 'home', component: HomeComponent, title: 'Home', canActivate:[AuthGuardsService] },
  { path: 'produtos',
  component: ProdutoComponent, canActivate:[AuthGuardsService, AuthGuardsProdutoService],
  children:[
    {path: 'lista', title: 'Produtos', component: ProdutoListaComponent },
    {path: 'criar', title: 'Cadastro', component: ProdutoCriarComponent, canActivate: [AuthGuardsProdutoCadastroService]},
    {path: 'editar/:id', title: 'Editar', component: ProdutoEditarComponent, canActivate: [AuthGuardsProdutoEditarService]},
    {path: 'detalhe/:id', title: 'Detalhe', component: ProdutoDetalheComponent, canActivate: [AuthGuardsProdutoDetalheService]}
  ]},
  { path: 'transportadores',
  component: TransportadorComponent, canActivate:[AuthGuardsService, AuthGuardsTransportadorService],
  children:[
    {path: 'lista', title: 'Transportadores', component: TransportadorListaComponent },
    {path: 'criar', title: 'Cadastro', component: TransportadorCriarComponent, canActivate: [AuthGuardsTransportadorCadastroService]},
    {path: 'editar/:id', title: 'Editar', component: TransportadorEditarComponent, canActivate: [AuthGuardsTransportadorEditarService]},
    {path: 'detalhe/:id', title: 'Detalhe', component: TransportadorDetalheComponent, canActivate: [AuthGuardsTransportadorDetalheService]}
  ]},
  { path: 'usuarios',
  component: UsuarioComponent, canActivate:[AuthGuardsService, AuthGuardsUsuarioService],
  children:[
    {path: 'lista', title: 'Usuarios', component: UsuarioListaComponent },
    {path: 'criar/:id', title: 'Cadastro', component: UsuarioCriarComponent, canActivate: [AuthGuardsUsuarioCadastroService] },
    {path: 'editar/:id', title: 'Editar', component: UsuarioEditarComponent, canActivate: [AuthGuardsUsuarioEditarService]},
    {path: 'permissao/:id', title: 'Permissões', component: UsuarioPermissaoComponent, canActivate: [AuthGuardsUsuarioPermissaoService]},
    {path: 'selecionar-funcionario', title: 'Seleção de Funcionario', component: UsuarioSelecionarFuncionarioComponent, canActivate: [AuthGuardsUsuarioCadastroService] }
  ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
