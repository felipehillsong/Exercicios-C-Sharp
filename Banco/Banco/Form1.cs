using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Banco
{
    public partial class Form1 : Form
    {
        private Conta c1;
        private ContaPoupanca c2;
        private TotalizadorDeContas t;

        public Form1()
        {
            this.c1 = new Conta();
            this.c2 = new ContaPoupanca();
            this.t = new TotalizadorDeContas();
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           Conta c1 = new Conta();
           c1.Numero = 1;

           Cliente cliente = new Cliente("Felipe", 01583888608, 7883219);
           c1.Titular = cliente;

           textoTitular.Text = c1.Titular.Nome;
           textoCPF.Text = Convert.ToString(c1.Titular.CPF);
           textoRG.Text = Convert.ToString(c1.Titular.RG);
           textoNumero.Text = Convert.ToString(c1.Numero);
           textoSaldo.Text = Convert.ToString(c1.Saldo);          

        }

        private void textoNumero_TextChanged(object sender, EventArgs e)
        {

        }

        private void textoSaldo_TextChanged(object sender, EventArgs e)
        {

        }

        private void depositoOK_Click(object sender, EventArgs e)
        {
            string valorDigitado = textoValor.Text;
            double valorOperacao = Convert.ToDouble(valorDigitado);

            if (comboBox1.SelectedIndex == 0)
            {                
                c1.Deposita(valorOperacao);
                textoSaldo.Text = Convert.ToString(this.c1.Saldo);               
            }

            if(comboBox1.SelectedIndex == 1)
            {                
                c2.Deposita(valorOperacao);
                textoSaldo.Text = Convert.ToString(this.c2.Saldo);
                
            }
            MessageBox.Show("Deposito feito com sucesso!");

        }

        private void textoValor_TextChanged(object sender, EventArgs e)
        {

        }

        private void saqueOK_Click(object sender, EventArgs e)
        {
            string valorDigitado = textoValor.Text;
            double valorOperacao = Convert.ToDouble(valorDigitado);

            if (comboBox1.SelectedIndex == 0)
            {               
                c1.Saca(valorOperacao);
                textoSaldo.Text = Convert.ToString(this.c1.Saldo);               
            }
            if(comboBox1.SelectedIndex == 1)
            {                
                c2.Saca(valorOperacao);
                textoSaldo.Text = Convert.ToString(this.c2.Saldo);
                
            }
            MessageBox.Show("Saque feito com sucesso!");
        }

        private void ContaDoCliente_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void limparOK_Click(object sender, EventArgs e)
        {
            textoValor.Text = string.Empty;
            textoSaldo.Text = string.Empty;            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                     
        }

        private void Transacao_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                t.Soma(c1);
                textoTransacao.Text = Convert.ToString(t.valortotal);
            }
                
        }

        private void TextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
