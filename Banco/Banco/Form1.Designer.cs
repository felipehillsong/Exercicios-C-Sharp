namespace Banco
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textoTitular = new System.Windows.Forms.TextBox();
            this.textoNumero = new System.Windows.Forms.TextBox();
            this.textoSaldo = new System.Windows.Forms.TextBox();
            this.textoCPF = new System.Windows.Forms.TextBox();
            this.textoRG = new System.Windows.Forms.TextBox();
            this.Nome = new System.Windows.Forms.Label();
            this.CPF = new System.Windows.Forms.Label();
            this.RG = new System.Windows.Forms.Label();
            this.ContaDoClienteTitular = new System.Windows.Forms.Label();
            this.NumeroDaConta = new System.Windows.Forms.Label();
            this.Saldo = new System.Windows.Forms.Label();
            this.textoValor = new System.Windows.Forms.TextBox();
            this.Deposito = new System.Windows.Forms.Label();
            this.depositoOK = new System.Windows.Forms.Button();
            this.saqueOK = new System.Windows.Forms.Button();
            this.limparOK = new System.Windows.Forms.Button();
            this.transacao = new System.Windows.Forms.Button();
            this.nomesConta = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.comboContas = new System.Windows.Forms.ComboBox();
            this.textoTransacao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textoTitular
            // 
            this.textoTitular.Location = new System.Drawing.Point(138, 62);
            this.textoTitular.Name = "textoTitular";
            this.textoTitular.Size = new System.Drawing.Size(100, 20);
            this.textoTitular.TabIndex = 0;
            // 
            // textoNumero
            // 
            this.textoNumero.Location = new System.Drawing.Point(138, 189);
            this.textoNumero.Name = "textoNumero";
            this.textoNumero.Size = new System.Drawing.Size(100, 20);
            this.textoNumero.TabIndex = 1;
            this.textoNumero.TextChanged += new System.EventHandler(this.textoNumero_TextChanged);
            // 
            // textoSaldo
            // 
            this.textoSaldo.Location = new System.Drawing.Point(432, 145);
            this.textoSaldo.Name = "textoSaldo";
            this.textoSaldo.Size = new System.Drawing.Size(100, 20);
            this.textoSaldo.TabIndex = 2;
            this.textoSaldo.TextChanged += new System.EventHandler(this.textoSaldo_TextChanged);
            // 
            // textoCPF
            // 
            this.textoCPF.Location = new System.Drawing.Point(138, 105);
            this.textoCPF.Name = "textoCPF";
            this.textoCPF.Size = new System.Drawing.Size(100, 20);
            this.textoCPF.TabIndex = 3;
            // 
            // textoRG
            // 
            this.textoRG.Location = new System.Drawing.Point(138, 145);
            this.textoRG.Name = "textoRG";
            this.textoRG.Size = new System.Drawing.Size(100, 20);
            this.textoRG.TabIndex = 4;
            // 
            // Nome
            // 
            this.Nome.AutoSize = true;
            this.Nome.Location = new System.Drawing.Point(94, 65);
            this.Nome.Name = "Nome";
            this.Nome.Size = new System.Drawing.Size(38, 13);
            this.Nome.TabIndex = 5;
            this.Nome.Text = "Nome:";
            // 
            // CPF
            // 
            this.CPF.AutoSize = true;
            this.CPF.Location = new System.Drawing.Point(102, 105);
            this.CPF.Name = "CPF";
            this.CPF.Size = new System.Drawing.Size(30, 13);
            this.CPF.TabIndex = 6;
            this.CPF.Text = "CPF:";
            // 
            // RG
            // 
            this.RG.AutoSize = true;
            this.RG.Location = new System.Drawing.Point(106, 148);
            this.RG.Name = "RG";
            this.RG.Size = new System.Drawing.Size(26, 13);
            this.RG.TabIndex = 7;
            this.RG.Text = "RG:";
            // 
            // ContaDoClienteTitular
            // 
            this.ContaDoClienteTitular.AutoSize = true;
            this.ContaDoClienteTitular.Location = new System.Drawing.Point(250, 9);
            this.ContaDoClienteTitular.Name = "ContaDoClienteTitular";
            this.ContaDoClienteTitular.Size = new System.Drawing.Size(116, 13);
            this.ContaDoClienteTitular.TabIndex = 8;
            this.ContaDoClienteTitular.Text = "Conta do cliente Titular";
            this.ContaDoClienteTitular.Click += new System.EventHandler(this.ContaDoCliente_Click);
            // 
            // NumeroDaConta
            // 
            this.NumeroDaConta.AutoSize = true;
            this.NumeroDaConta.Location = new System.Drawing.Point(42, 192);
            this.NumeroDaConta.Name = "NumeroDaConta";
            this.NumeroDaConta.Size = new System.Drawing.Size(93, 13);
            this.NumeroDaConta.TabIndex = 9;
            this.NumeroDaConta.Text = "Numero da Conta:";
            // 
            // Saldo
            // 
            this.Saldo.AutoSize = true;
            this.Saldo.Location = new System.Drawing.Point(392, 148);
            this.Saldo.Name = "Saldo";
            this.Saldo.Size = new System.Drawing.Size(37, 13);
            this.Saldo.TabIndex = 10;
            this.Saldo.Text = "Saldo:";
            // 
            // textoValor
            // 
            this.textoValor.Location = new System.Drawing.Point(432, 98);
            this.textoValor.Name = "textoValor";
            this.textoValor.Size = new System.Drawing.Size(100, 20);
            this.textoValor.TabIndex = 11;
            this.textoValor.TextChanged += new System.EventHandler(this.textoValor_TextChanged);
            // 
            // Deposito
            // 
            this.Deposito.AutoSize = true;
            this.Deposito.Location = new System.Drawing.Point(395, 98);
            this.Deposito.Name = "Deposito";
            this.Deposito.Size = new System.Drawing.Size(34, 13);
            this.Deposito.TabIndex = 12;
            this.Deposito.Text = "Valor:";
            // 
            // depositoOK
            // 
            this.depositoOK.Location = new System.Drawing.Point(45, 248);
            this.depositoOK.Name = "depositoOK";
            this.depositoOK.Size = new System.Drawing.Size(75, 23);
            this.depositoOK.TabIndex = 13;
            this.depositoOK.Text = "Deposito";
            this.depositoOK.UseVisualStyleBackColor = true;
            this.depositoOK.Click += new System.EventHandler(this.depositoOK_Click);
            // 
            // saqueOK
            // 
            this.saqueOK.Location = new System.Drawing.Point(190, 248);
            this.saqueOK.Name = "saqueOK";
            this.saqueOK.Size = new System.Drawing.Size(75, 23);
            this.saqueOK.TabIndex = 14;
            this.saqueOK.Text = "Saque";
            this.saqueOK.UseVisualStyleBackColor = true;
            this.saqueOK.Click += new System.EventHandler(this.saqueOK_Click);
            // 
            // limparOK
            // 
            this.limparOK.Location = new System.Drawing.Point(477, 248);
            this.limparOK.Name = "limparOK";
            this.limparOK.Size = new System.Drawing.Size(75, 23);
            this.limparOK.TabIndex = 15;
            this.limparOK.Text = "Limpar";
            this.limparOK.UseVisualStyleBackColor = true;
            this.limparOK.Click += new System.EventHandler(this.limparOK_Click);
            // 
            // transacao
            // 
            this.transacao.Location = new System.Drawing.Point(335, 248);
            this.transacao.Name = "transacao";
            this.transacao.Size = new System.Drawing.Size(75, 23);
            this.transacao.TabIndex = 18;
            this.transacao.Text = "Transações";
            this.transacao.UseVisualStyleBackColor = true;
            this.transacao.Click += new System.EventHandler(this.Transacao_Click);
            // 
            // nomesConta
            // 
            this.nomesConta.AutoSize = true;
            this.nomesConta.Location = new System.Drawing.Point(383, 51);
            this.nomesConta.Name = "nomesConta";
            this.nomesConta.Size = new System.Drawing.Size(43, 13);
            this.nomesConta.TabIndex = 21;
            this.nomesConta.Text = "Contas:";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // comboContas
            // 
            this.comboContas.FormattingEnabled = true;
            this.comboContas.Location = new System.Drawing.Point(432, 48);
            this.comboContas.Name = "comboContas";
            this.comboContas.Size = new System.Drawing.Size(121, 21);
            this.comboContas.TabIndex = 22;
            this.comboContas.Text = "Escolha a Conta";
            this.comboContas.SelectedIndexChanged += new System.EventHandler(this.ComboContas_SelectedIndexChanged);
            // 
            // textoTransacao
            // 
            this.textoTransacao.Location = new System.Drawing.Point(432, 189);
            this.textoTransacao.Name = "textoTransacao";
            this.textoTransacao.Size = new System.Drawing.Size(100, 20);
            this.textoTransacao.TabIndex = 19;
            this.textoTransacao.TextChanged += new System.EventHandler(this.TextBox1_TextChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(360, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Transações:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 358);
            this.Controls.Add(this.comboContas);
            this.Controls.Add(this.nomesConta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textoTransacao);
            this.Controls.Add(this.transacao);
            this.Controls.Add(this.limparOK);
            this.Controls.Add(this.saqueOK);
            this.Controls.Add(this.depositoOK);
            this.Controls.Add(this.Deposito);
            this.Controls.Add(this.textoValor);
            this.Controls.Add(this.Saldo);
            this.Controls.Add(this.NumeroDaConta);
            this.Controls.Add(this.ContaDoClienteTitular);
            this.Controls.Add(this.RG);
            this.Controls.Add(this.CPF);
            this.Controls.Add(this.Nome);
            this.Controls.Add(this.textoRG);
            this.Controls.Add(this.textoCPF);
            this.Controls.Add(this.textoSaldo);
            this.Controls.Add(this.textoNumero);
            this.Controls.Add(this.textoTitular);
            this.Name = "Form1";
            this.Text = "CONTA";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textoTitular;
        private System.Windows.Forms.TextBox textoNumero;
        private System.Windows.Forms.TextBox textoSaldo;
        private System.Windows.Forms.TextBox textoCPF;
        private System.Windows.Forms.TextBox textoRG;
        private System.Windows.Forms.Label Nome;
        private System.Windows.Forms.Label CPF;
        private System.Windows.Forms.Label RG;
        private System.Windows.Forms.Label ContaDoClienteTitular;
        private System.Windows.Forms.Label NumeroDaConta;
        private System.Windows.Forms.Label Saldo;
        private System.Windows.Forms.TextBox textoValor;
        private System.Windows.Forms.Label Deposito;
        private System.Windows.Forms.Button depositoOK;
        private System.Windows.Forms.Button saqueOK;
        private System.Windows.Forms.Button limparOK;
        private System.Windows.Forms.Button transacao;
        private System.Windows.Forms.Label nomesConta;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ComboBox comboContas;
        private System.Windows.Forms.TextBox textoTransacao;
        private System.Windows.Forms.Label label1;
    }
}

