
namespace CadastroDePessoas
{
    partial class TelaDeCadastro
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
            this.lbNome = new System.Windows.Forms.Label();
            this.nome = new System.Windows.Forms.TextBox();
            this.lbCpf = new System.Windows.Forms.Label();
            this.cpf = new System.Windows.Forms.TextBox();
            this.lbEndereco = new System.Windows.Forms.Label();
            this.endereco = new System.Windows.Forms.TextBox();
            this.lbBairro = new System.Windows.Forms.Label();
            this.bairro = new System.Windows.Forms.TextBox();
            this.lbEstado = new System.Windows.Forms.Label();
            this.comboEstados = new System.Windows.Forms.ComboBox();
            this.lbCidade = new System.Windows.Forms.Label();
            this.cidade = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbNome
            // 
            this.lbNome.AutoSize = true;
            this.lbNome.Location = new System.Drawing.Point(66, 58);
            this.lbNome.Name = "lbNome";
            this.lbNome.Size = new System.Drawing.Size(35, 13);
            this.lbNome.TabIndex = 0;
            this.lbNome.Text = "Nome";
            // 
            // nome
            // 
            this.nome.Location = new System.Drawing.Point(69, 74);
            this.nome.Name = "nome";
            this.nome.Size = new System.Drawing.Size(254, 20);
            this.nome.TabIndex = 1;
            // 
            // lbCpf
            // 
            this.lbCpf.AutoSize = true;
            this.lbCpf.Location = new System.Drawing.Point(66, 97);
            this.lbCpf.Name = "lbCpf";
            this.lbCpf.Size = new System.Drawing.Size(27, 13);
            this.lbCpf.TabIndex = 6;
            this.lbCpf.Text = "CPF";
            // 
            // cpf
            // 
            this.cpf.Location = new System.Drawing.Point(69, 113);
            this.cpf.Name = "cpf";
            this.cpf.Size = new System.Drawing.Size(254, 20);
            this.cpf.TabIndex = 2;
            // 
            // lbEndereco
            // 
            this.lbEndereco.AutoSize = true;
            this.lbEndereco.Location = new System.Drawing.Point(66, 140);
            this.lbEndereco.Name = "lbEndereco";
            this.lbEndereco.Size = new System.Drawing.Size(53, 13);
            this.lbEndereco.TabIndex = 4;
            this.lbEndereco.Text = "Endereço";
            // 
            // endereco
            // 
            this.endereco.Location = new System.Drawing.Point(69, 156);
            this.endereco.Name = "endereco";
            this.endereco.Size = new System.Drawing.Size(254, 20);
            this.endereco.TabIndex = 3;
            // 
            // lbBairro
            // 
            this.lbBairro.AutoSize = true;
            this.lbBairro.Location = new System.Drawing.Point(66, 179);
            this.lbBairro.Name = "lbBairro";
            this.lbBairro.Size = new System.Drawing.Size(34, 13);
            this.lbBairro.TabIndex = 2;
            this.lbBairro.Text = "Bairro";
            // 
            // bairro
            // 
            this.bairro.Location = new System.Drawing.Point(69, 200);
            this.bairro.Name = "bairro";
            this.bairro.Size = new System.Drawing.Size(254, 20);
            this.bairro.TabIndex = 4;
            // 
            // lbEstado
            // 
            this.lbEstado.AutoSize = true;
            this.lbEstado.Location = new System.Drawing.Point(69, 227);
            this.lbEstado.Name = "lbEstado";
            this.lbEstado.Size = new System.Drawing.Size(40, 13);
            this.lbEstado.TabIndex = 8;
            this.lbEstado.Text = "Estado";
            // 
            // comboEstados
            // 
            this.comboEstados.FormattingEnabled = true;
            this.comboEstados.Location = new System.Drawing.Point(69, 243);
            this.comboEstados.Name = "comboEstados";
            this.comboEstados.Size = new System.Drawing.Size(254, 21);
            this.comboEstados.TabIndex = 5;
            // 
            // lbCidade
            // 
            this.lbCidade.AutoSize = true;
            this.lbCidade.Location = new System.Drawing.Point(69, 274);
            this.lbCidade.Name = "lbCidade";
            this.lbCidade.Size = new System.Drawing.Size(40, 13);
            this.lbCidade.TabIndex = 12;
            this.lbCidade.Text = "Cidade";
            // 
            // cidade
            // 
            this.cidade.Location = new System.Drawing.Point(69, 290);
            this.cidade.Name = "cidade";
            this.cidade.Size = new System.Drawing.Size(254, 20);
            this.cidade.TabIndex = 6;
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnEnviar.Location = new System.Drawing.Point(158, 316);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 7;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // TelaDeCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 450);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.cidade);
            this.Controls.Add(this.lbCidade);
            this.Controls.Add(this.comboEstados);
            this.Controls.Add(this.lbEstado);
            this.Controls.Add(this.bairro);
            this.Controls.Add(this.lbBairro);
            this.Controls.Add(this.endereco);
            this.Controls.Add(this.lbEndereco);
            this.Controls.Add(this.cpf);
            this.Controls.Add(this.lbCpf);
            this.Controls.Add(this.nome);
            this.Controls.Add(this.lbNome);
            this.Location = new System.Drawing.Point(930, 85);
            this.Name = "TelaDeCadastro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "TelaDeCadastro";
            this.Load += new System.EventHandler(this.TelaCadastro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNome;
        private System.Windows.Forms.TextBox nome;
        private System.Windows.Forms.Label lbCpf;
        private System.Windows.Forms.TextBox cpf;
        private System.Windows.Forms.Label lbEndereco;
        private System.Windows.Forms.TextBox endereco;
        private System.Windows.Forms.Label lbBairro;
        private System.Windows.Forms.TextBox bairro;
        private System.Windows.Forms.Label lbEstado;
        private System.Windows.Forms.ComboBox comboEstados;
        private System.Windows.Forms.Label lbCidade;
        private System.Windows.Forms.TextBox cidade;
        private System.Windows.Forms.Button btnEnviar;
    }
}

