using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritimoMediaHomem
{
    public class Usuario
    {
        private string Nome { get; set; }

        private float Altura { get; set; }

        private string Sexo { get; set; }


        public void Dados(string nome, float altura, int sexo)
        {         
            if(sexo == 1)
            {
                this.Nome = nome;
                this.Sexo = "Masculino";
                this.Altura = altura;
            }
            else if(sexo == 2)
            {
                this.Nome = nome;
                this.Sexo = "Feminino";
                this.Altura = altura;
            }

            Console.WriteLine("O nome do usuario é: "+Nome+", a sua altura é: "+Altura+" e seu sexo é: "+Sexo);
        }
    }
}
