﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaguardaESilva.Application.DTO
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public bool Ativo { get; set; }
        public decimal Preco { get; set; }
        public double Codigo { get; set; }
        public DateTime? DataCadastroProduto { get; set; }
        public int EmpresaId { get; set; }
        public int FornecedorId { get; set; }
    }

    public class ProdutoCreateDTO
    {        
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public bool Ativo { get; set; }
        public decimal Preco { get; set; }
        public double Codigo { get; set; }
        public DateTime? DataCadastroProduto { get; set; }
        public int EmpresaId { get; set; }
        public int FornecedorId { get; set; }
    }

    public class ProdutoUpdateDTO
    {        
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public bool Ativo { get; set; }
        public decimal Preco { get; set; }
        public double Codigo { get; set; }
        public DateTime? DataCadastroProduto { get; set; }    
    }
}