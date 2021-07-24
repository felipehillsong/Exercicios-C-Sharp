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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void btn_entrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaDePessoas telaDepessoas = new TelaDePessoas();
            telaDepessoas.Closed += (s, args) => this.Close();
            telaDepessoas.Show();            
        }
        
    }
}
