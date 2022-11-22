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
import { AuthGuardsClienteService } from './services/guards/AuthGuardsCliente.service';
import { AuthGuardsEmpresaService } from './services/guards/AuthGuardsEmpresa.service';
import { AuthGuardsFornecedorService } from './services/guards/AuthGuardsFornecedor.service';
import { AuthGuardsFuncionarioService } from './services/guards/AuthGuardsFuncionario.service';
import { AuthGuardsService } from './services/guards/AuthGuardsService';
import { AuthGuardsTransportadorService } from './services/guards/AuthGuardsTransportador.service';
import { AuthGuardsUsuarioService } from './services/guards/AuthGuardsUsuario.service';

const routes: Routes = [
  { path: '', redirectTo: 'login', title: 'Login' },
  { path: 'clientes', canActivate:[AuthGuardsService, AuthGuardsClienteService],
  component: ClienteComponent,
  children:[
    {path: 'lista', title: 'Clientes', component: ClienteListaComponent },
    {path: 'criar', title: 'Cadastro', component: ClienteCriarComponent },
    {path: 'editar/:id', title: 'Editar', component: ClienteEditarComponent },
    {path: 'detalhe/:id', title: 'Detalhe', component: ClienteDetalheComponent}
  ]},
  { path: 'empresas', canActivate:[AuthGuardsService, AuthGuardsEmpresaService],
  component: EmpresaComponent,
  children:[
    {path: 'lista', title: 'Empresas', component: EmpresaListaComponent },
    {path: 'criar', title: 'Cadastro', component: EmpresaCriarComponent },
    {path: 'editar/:id', title: 'Editar', component: EmpresaEditarComponent },
    {path: 'detalhe/:id', title: 'Detalhe', component: EmpresaDetalheComponent}
  ]},
  { path: 'fornecedores', canActivate:[AuthGuardsService, AuthGuardsFornecedorService],
  component: FornecedorComponent,
  children:[
    {path: 'lista', title: 'Fornecedores', component: FornecedorListaComponent },
    {path: 'criar', title: 'Cadastro', component: FornecedorCriarComponent },
    {path: 'editar/:id', title: 'Editar', component: FornecedorEditarComponent },
    {path: 'detalhe/:id', title: 'Detalhe', component: FornecedorDetalheComponent}
  ]},
  { path: 'funcionarios', canActivate:[AuthGuardsService, AuthGuardsFuncionarioService],
  component: FuncionarioComponent,
  children:[
    {path: 'lista', title: 'Funcionarios', component: FuncionarioListaComponent },
    {path: 'criar', title: 'Cadastro', component: FuncionarioCriarComponent },
    {path: 'editar/:id', title: 'Editar', component: FuncionarioEditarComponent },
    {path: 'detalhe/:id', title: 'Detalhe', component: FuncionarioDetalheComponent}
  ]},
  { path: 'login', component: LoginComponent, title: 'Login' },
  { path: 'home', component: HomeComponent, title: 'Home', canActivate:[AuthGuardsService] },
  { path: 'transportadores',
  component: TransportadorComponent, canActivate:[AuthGuardsService, AuthGuardsTransportadorService],
  children:[
    {path: 'lista', title: 'Transportadores', component: TransportadorListaComponent },
    {path: 'criar', title: 'Cadastro', component: TransportadorCriarComponent },
    {path: 'editar/:id', title: 'Editar', component: TransportadorEditarComponent },
    {path: 'detalhe/:id', title: 'Detalhe', component: TransportadorDetalheComponent}
  ]},
  { path: 'usuarios',
  component: UsuarioComponent, canActivate:[AuthGuardsService, AuthGuardsUsuarioService],
  children:[
    {path: 'lista', title: 'Usuarios', component: UsuarioListaComponent },
    {path: 'criar/:id', title: 'Cadastro', component: UsuarioCriarComponent },
    {path: 'editar/:id', title: 'Editar', component: UsuarioEditarComponent },
    {path: 'permissao/:id', title: 'Permissões', component: UsuarioPermissaoComponent},
    {path: 'selecionar-funcionario', title: 'Seleção de Funcionario', component: UsuarioSelecionarFuncionarioComponent},
  ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
