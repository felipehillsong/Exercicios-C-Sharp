using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcular_Salario1
{
    public class Funcionario
    {
        public string Nome { get; set; }       

        public int ClasseFuncional { get; set; }

        public void MostrarNome(string nome)
        {
            this.Nome = nome;
        }        

        public int MostrarClasse(int classe)
        {
            return this.ClasseFuncional = classe;
        }
    }
}
