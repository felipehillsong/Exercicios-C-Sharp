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
        private Conta[] contas;        

        public Form1()
        {            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            contas = new Conta[3];
            this.contas[0] = new Conta();
            this.contas[0].Titular = new Cliente("Felipe", 01583888608, 7883219);
            this.contas[0].Numero = 1;

            this.contas[1] = new ContaPoupanca();
            this.contas[1].Titular = new Cliente("Polyana", 55454854, 5646847);
            this.contas[1].Numero = 2;

            this.contas[2] = new ContaCorrente();
            this.contas[2].Titular = new Cliente("Rogerio", 125354, 24564514);
            this.contas[2].Numero = 3;

            foreach (Conta conta in contas)
            {
                comboContas.Items.Add(conta.Titular.Nome);
            }
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
            double valorDeposito = Convert.ToDouble(valorDigitado);

            if (comboContas.SelectedIndex == 0)
            {                
                contas[0].Deposita(valorDeposito);
                textoSaldo.Text = Convert.ToString(this.contas[0].Saldo);               
            }

            if(comboContas.SelectedIndex == 1)
            {
                contas[1].Deposita(valorDeposito);
                textoSaldo.Text = Convert.ToString(this.contas[1].Saldo);                
            }
            if (comboContas.SelectedIndex == 2)
            {
                contas[2].Deposita(valorDeposito);
                textoSaldo.Text = Convert.ToString(this.contas[2].Saldo);
            }
            MessageBox.Show("Deposito feito com sucesso!");

        }

        private void textoValor_TextChanged(object sender, EventArgs e)
        {

        }

        private void saqueOK_Click(object sender, EventArgs e)
        {
            string valorDigitado = textoValor.Text;
            double valorSaque = Convert.ToDouble(valorDigitado);

            if (comboContas.SelectedIndex == 0)
            {
                contas[0].Saca(valorSaque);
                textoSaldo.Text = Convert.ToString(this.contas[0].Saldo);               
            }
            if(comboContas.SelectedIndex == 1)
            {
                contas[1].Saca(valorSaque);
                textoSaldo.Text = Convert.ToString(this.contas[1].Saldo);                
            }
            if (comboContas.SelectedIndex == 2)
            {
                contas[2].Saca(valorSaque);
                textoSaldo.Text = Convert.ToString(this.contas[2].Saldo);
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

        private void Transacao_Click(object sender, EventArgs e)
        {
            /*if (comboBox1.SelectedIndex == 0)
            {
                t.Soma(contas[0]);
                textoTransacao.Text = Convert.ToString(t.valortotal);
            }*/
                
        }

        private void TextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void ComboContas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = comboContas.SelectedIndex;
            Conta selecionada = contas[indice];
            textoTitular.Text = selecionada.Titular.Nome;
            textoCPF.Text = Convert.ToString(selecionada.Titular.CPF);
            textoRG.Text = Convert.ToString(selecionada.Titular.RG);
            textoSaldo.Text = Convert.ToString(selecionada.Saldo);
            textoNumero.Text = Convert.ToString(selecionada.Numero);
            
        }
    }
}
