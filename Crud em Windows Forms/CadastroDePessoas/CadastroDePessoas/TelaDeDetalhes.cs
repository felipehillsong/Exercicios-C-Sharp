using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroDePessoas
{
    public partial class TelaDeDetalhes : Form
    {
        public TelaDeDetalhes(int id)
        {
            InitializeComponent();            
            ReceberDados(id);
        }
        public void ReceberDados(int id)
        {
            using (DBCadastroPessoa db = new DBCadastroPessoa())
            {
                var result = db.Pessoa.Find(id);

                nome.Text = result.Nome;
                cpf.Text = result.Cpf;
                endereco.Text = result.Endereco;
                bairro.Text = result.Bairro;
                comboEstados.Text = result.Estado;
                cidade.Text = result.Cidade;
            }
        }
        private void btn_voltar_Click(object sender, EventArgs e)
        {
            this.Hide();            
        }
    }
}
