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
    public partial class TelaDeCadastro : Form
    {        
        TelaDePessoas _grid;
        public TelaDeCadastro(TelaDePessoas grid)
        {
            InitializeComponent();
            _grid = grid;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            var pessoa = new Pessoa();
            pessoa.Nome = nome.Text;
            pessoa.Cpf = cpf.Text;
            pessoa.Endereco = endereco.Text;
            pessoa.Bairro = bairro.Text;            
            pessoa.Estado = comboEstados.Text;
            pessoa.Cidade = cidade.Text;

            using (DBCadastroPessoa db = new DBCadastroPessoa())
            {
                db.Pessoa.Add(pessoa);
                db.SaveChanges();
            }

            MessageBox.Show($"Os dados inseridos foram:\n{pessoa.Nome}\n{pessoa.Cpf}\n{pessoa.Endereco}\n{pessoa.Bairro}\n{pessoa.Estado}\n{pessoa.Cidade}");
            nome.Clear();
            cpf.Clear();
            endereco.Clear();
            bairro.Clear();
            cidade.Clear();
            comboEstados.SelectedIndex = -1;
            _grid.PreencherGridPessoas();
            this.Hide();
        }

        public List<Estado> preencherComboEstados()
        {
            List<Estado> estados; 
            using (CRUDPessoasEstado db = new CRUDPessoasEstado())
            {
                estados = db.Estados.ToList();
            }

            return estados;
        }

        private void TelaCadastro_Load(object sender, EventArgs e)
        {
            var comboEstado = preencherComboEstados();
            foreach (var item in comboEstado)
            {
                comboEstados.Items.Add(item.Nome);
            }            
        }        
    }
}
