using System;
using System.Collections;
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
    public partial class TelaDePessoas : Form
    {        
        public TelaDePessoas()
        {
            InitializeComponent();
        }

        private void btn_incluir_click(object sender, EventArgs e)
        {            
            TelaDeCadastro telaDeCadastro = new TelaDeCadastro(this);            
            telaDeCadastro.ShowDialog();
        }

        public void PreencherGridPessoas()
        {            
            using (DBCadastroPessoa db = new DBCadastroPessoa())
            {
                dataGridPessoas.DataSource = db.Pessoa.ToList<Pessoa>();
                dataGridPessoas.Columns["Id"].Visible = false;
                dataGridPessoas.Columns["Cpf"].Visible = false;
                dataGridPessoas.Columns["Endereco"].Visible = false;
                dataGridPessoas.Columns["Bairro"].Visible = false;
                dataGridPessoas.Columns["Estado"].Visible = false;
                dataGridPessoas.Columns["Cidade"].Visible = false;                            
            }            
        }
        
        private void TelaDePessoas_Load(object sender, EventArgs e)
        {
            PreencherGridPessoas();
        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {            
            var campo = int.Parse(dataGridPessoas.CurrentRow.Cells[0].Value.ToString());
            var telaDeEditar = new TelaDeEditar(campo, this);            
            telaDeEditar.ShowDialog();
        }

        private void btn_detalhes_Click(object sender, EventArgs e)
        {            
            var campo = int.Parse(dataGridPessoas.CurrentRow.Cells[0].Value.ToString());
            var telaDeDetalhes = new TelaDeDetalhes(campo);
            telaDeDetalhes.ShowDialog();
        }

        private void btn_deletar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja deletar essa pessoa?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var id = int.Parse(dataGridPessoas.CurrentRow.Cells[0].Value.ToString());
                using (DBCadastroPessoa db = new DBCadastroPessoa())
                {
                    var result = db.Pessoa.Find(id);
                    db.Pessoa.Remove(result);
                    db.SaveChanges();
                    PreencherGridPessoas();
                }
            }            
        }        
    }
}
