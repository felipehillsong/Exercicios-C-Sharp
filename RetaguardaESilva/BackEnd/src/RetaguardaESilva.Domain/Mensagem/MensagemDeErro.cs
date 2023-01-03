using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaguardaESilva.Domain.Mensagem
{
    public class MensagemDeErro
    {
        public const string CadastrarEmpresa = "Id inválido para esse tipo de operação, apenas o administrador pode fazer a inserção de uma empresa!";
        public const string EmpresaJaCadastrada = "Você esta tentando cadastrar uma empresa existente. Reveja o CPF, CNPJ, Inscrição Municipal e Inscrição Estadual";
        public const string EmpresaJaCadastradaUpdate = "Você esta tentando alterar para uma empresa existente. Reveja o CPF, CNPJ, Inscrição Municipal e Inscrição Estadual";
        public const string EmpresaClienteInexistente = "Você esta tentando cadastrar um cliente em uma empresa inexistente!";
        public const string ErroValidarEmpresa = "Algum erro ao validar a empresa";
        public const string ErroSalvarEmpresa = "Erro ao salvar Empresa";
        public const string ErroAtualizarEmpresa = "Erro ao atualizar Empresa";
        public const string EmpresaNaoEncontradaParaDelete = "Empresa não encontrado para delete";
        public const string EmpresaNaoEncontrada = "Nenhuma empresa encontrada!";
        public const string EmpresaFornecedorInexistente = "Você esta tentando cadastrar ou atualizar um fornecedor em uma empresa inexistente!";
        public const string EmpresaFuncionarioInexistente = "Você esta tentando cadastrar um funcionario em uma empresa inexistente!";
        public const string EmpresaTransportadorInexistente = "Você esta tentando cadastrar ou atualizar um transportador em uma empresa inexistente!";
        public const string ClienteSemId = "Algum erro ocorreu, possivelmente cliente sem Id";
        public const string ClienteJaCadastrado = "Você esta tentando cadastrar um cliente já cadastrado, reveja o CPF, CNPJ, Inscrição Municipal ou Inscrição Estadual";
        public const string ClienteNaoEncontrado = "Nenhum cliente encontrado";
        public const string ClienteNaoEncontradoEmpresa = "Não existem clientes cadastrados nessa empresa";
        public const string ClienteNaoEncontradoUpdate = "Cliente não encontrado para ser atualizado, verificar Id da empresa e Id do cliente";
        public const string ClienteNaoEncontradoDelete = "Cliente não encontrado para delete, verifique o Id da empresa e o Id do cliente";
        public const string FornecedorJaCadastrado = "Você esta tentando cadastrar ou atualizar para um fornecedor já cadastrado, reveja o CPF, CNPJ, Inscrição Municipal e Inscrição Estadual";
        public const string FornecedorNaoEcontradoUpdate = "Fornecedor não encontrado para ser atualizado, verificar Id da empresa e Id do fornecedor";
        public const string FornecedorNaoEncontradoDelete = "Fornecedor não encontrado para delete";
        public const string FornecedorNaoEncontrado = "Nenhum fornecedor encontrado";
        public const string FornecedorProdutoNaoEncontrado = "Nenhum produto para esse fornecedor foi encontrado";
        public const string FornecedorNaoEncontradoEmpresa = "Não existem fornecedores cadastrados nessa empresa";
        public const string TransportadorJaCadastrado = "Você esta tentando cadastrar ou atualizar para um transportador já cadastrado, reveja o CPF, CNPJ, Inscrição Municipal e Inscrição Estadual";
        public const string TransportadorNaoEcontradoUpdate = "Transportador não encontrado para ser atualizado, verificar Id da empresa e Id do fornecedor";
        public const string TransportadorNaoEncontradoDelete = "Transportador não encontrado para delete";
        public const string TransportadorNaoEncontrado = "Nenhum transportador encontrado";
        public const string TransportadorNaoEncontradoEmpresa = "Não existem transportadores cadastrados nessa empresa";
        public const string FuncionarioJaCadastrado = "Você esta tentando cadastrar ou atualizar para um funcionario já cadastrado, reveja o CPF";
        public const string FuncionarioNaoEncontradoUpdate = "Funcionario não encontrado para ser atualizado, verificar Id da empresa e Id do funcionario";
        public const string FuncionarioNaoEncontradoDelete = "Funcionario não encontrado para delete, verifique o Id da empresa e o Id do funcionario";
        public const string FuncionarioNaoEncontrado = "Nenhum funcionario encontrado";
        public const string FuncionarioNaoEncontradoEmpresa = "Não existem funcionarios cadastrados nessa empresa";
        public const string EmpresaUsuarioInexistente = "Você esta tentando cadastrar um usuario em uma empresa inexistente!";
        public const string UsuarioSemId = "Algum erro ocorreu, possivelmente usuario sem Id";
        public const string UsuarioJaCadastrado = "Você esta tentando cadastrar ou atualizar um usuario para outro usuario já cadastrado, reveja o CPF";
        public const string UsuarioNaoEncontradoUpdate = "Usuario não encontrado para ser atualizado, verificar Id da empresa e Id do usuario";
        public const string UsuarioNaoEncontradoDelete = "Usuario não encontrado para delete, verifique o Id da empresa e o Id do usuario";
        public const string UsuarioErroDelete = "Erro ao deletar usuario";
        public const string UsuarioNaoEncontrado = "Nenhum usuario encontrado";
        public const string UsuariosNaoEncontradoEmpresa = "Não existem usuarios cadastrados nessa empresa";
        public const string EmpresaSemId = "Algum erro ocorreu, possivelmente empresa esta sem Id";
        public const string FornecedorSemId = "Algum erro ocorreu, possivelmente fornecedor sem Id";
        public const string FuncionarioSemId = "Algum erro ocorreu, possivelmente funcionario sem Id";
        public const string TransportadorSemId = "Algum erro ocorreu, possivelmente transportadora sem Id";
        public const string IdInvalidoDeleteEmpresa = "Id inválido para deletar a empresa, apenas o administrador pode deletar uma empresa";
        public const string IdInvalidoBuscarEmpresas = "Id inválido, apenas o administrador pode ver todas as empresas cadastrada!";
        public const string ExisteProduto = "Produto já cadastrado, sua quantidade irá ser somada no estoque";
        public const string ErroAoCadastrarProduto = "Erro ao cadastrar produto";
        public const string ErroAoAtualizarQuantidadeProduto = "Erro ao atualizar a quantidade do produto";
        public const string ErroAoAtualizarQuantidadeProdutoEstoque = "Erro ao atualizar a quantidade do produto no estoque";
        public const string ErroAoDeletarEstoqueProduto = "Erro ao deletar produto do estoque após a atualização da quantidade";
        public const string ProdutoNaoEncontradoUpdate = "Produto não encontrado para ser atualizado, verificar Id da empresa e Id do produto";
        public const string EmpresaProdutoInexistente = "Você esta tentando cadastrar um produto em uma empresa inexistente!";
        public const string ProdutoJaCadastrado = "Você esta tentando atualizar um produto para um produto existente!";
        public const string ProdutoErroAtualizar = "Ocorreu algum erro ao atualizar o produto, verifique o nome, Id da empresa e Id do produto!";
        public const string ProdutoNaoEncontradoDelete = "Produto não encontrado para delete, verifique o Id da empresa, Id do produto ou se o produto tem estoque";
        public const string ProdutoNaoEncontrado = "Nenhum produto encontrado";
        public const string ProdutoNaoEncontradoEmpresa = "Não existem produtos cadastrados nessa empresa";
        public const string ProdutoErroAoConsultar = "Erro ao consultar produto";
        public const string VisualizarEmpresa = "Pode visualizar apenas sua propria empresa";
        public const string ErroAoAtualizar = "Erro ao atualizar";
        public const string ErroAoAtualizarCriar = "Erro ao atualizar ou criar";
        public const string ErroCEP = "Algum erro ocorreu, possivelmente CEP invalido, ou vazio, ou erro na API dos correios";
        public const string ErroSenha = "Senhas não conferem";
        public const string LoginErro = "Email ou senha errado";
    }
}
