namespace Banco
{
    public class Cliente
    {
        public string Nome { get; set; }
        public int CPF { get; set; }
        public int RG { get; set; }

        public Cliente(string nome, int cpf, int rg)
        {
            this.Nome = nome;
            this.CPF = cpf;
            this.RG = rg;
        }

    }
}