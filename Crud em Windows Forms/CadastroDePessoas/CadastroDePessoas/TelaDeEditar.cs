using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroDePessoas
{
    public partial class TelaDeEditar : Form
    {
        public int Id { get; set; }
        TelaDePessoas _grid;
        public TelaDeEditar(int id, TelaDePessoas grid)
        {
            InitializeComponent();
            this.Id = id;
            ReceberDados(Id);
            _grid = grid;
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
        public List<Estado> preencherComboEstados()
        {
            List<Estado> estados;
            using (CRUDPessoasEstado db = new CRUDPessoasEstado())
            {
                estados = db.Estados.ToList();
            }

            return estados;
        }

        private void TelaDeEditar_Load(object sender, EventArgs e)
        {
            var comboEstado = preencherComboEstados();
            foreach (var item in comboEstado)
            {
                comboEstados.Items.Add(item.Nome);
            }
        }
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            var pessoa = new Pessoa();
            pessoa.Id = Id;
            pessoa.Nome = nome.Text;
            pessoa.Cpf = cpf.Text;
            pessoa.Endereco = endereco.Text;
            pessoa.Bairro = bairro.Text;
            pessoa.Estado = comboEstados.Text;
            pessoa.Cidade = cidade.Text;           
            using (DBCadastroPessoa db = new DBCadastroPessoa())
            {
                db.Entry(pessoa).State = EntityState.Modified;                
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

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();            
        }
    }
}
