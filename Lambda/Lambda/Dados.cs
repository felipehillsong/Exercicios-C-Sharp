using System;
using System.Collections.Generic;
using System.Text;

namespace Lambda
{
    public class Dados
    {
        public int[] Id { get; set; }
        public string[] Nome { get; set; }
        public string[] Sobrenome { get; set; }
        public int[] Idade { get; set; }
        public string[] Pais { get; set; }

        public List<Dados>PreencherDados(int[] id, string[] nome, string[] sobrenome, int[] idade, string[] pais)
        {
            List<Dados> list = new List<Dados>() {
                new Dados(){
            Id = id,
            Nome = nome,
            Sobrenome = sobrenome,
            Idade = idade,
            Pais = pais,
            }
        };

            return list;
        }      
    }
}
