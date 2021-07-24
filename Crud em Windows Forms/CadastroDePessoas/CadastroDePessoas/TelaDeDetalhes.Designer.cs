
namespace CadastroDePessoas
{
    partial class TelaDeDetalhes
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
            this.btn_voltar = new System.Windows.Forms.Button();
            this.cidade = new System.Windows.Forms.TextBox();
            this.lbCidade = new System.Windows.Forms.Label();
            this.comboEstados = new System.Windows.Forms.ComboBox();
            this.lbEstado = new System.Windows.Forms.Label();
            this.bairro = new System.Windows.Forms.TextBox();
            this.lbBairro = new System.Windows.Forms.Label();
            this.endereco = new System.Windows.Forms.TextBox();
            this.lbEndereco = new System.Windows.Forms.Label();
            this.cpf = new System.Windows.Forms.TextBox();
            this.lbCpf = new System.Windows.Forms.Label();
            this.nome = new System.Windows.Forms.TextBox();
            this.lbNome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_voltar
            // 
            this.btn_voltar.Location = new System.Drawing.Point(151, 327);
            this.btn_voltar.Name = "btn_voltar";
            this.btn_voltar.Size = new System.Drawing.Size(75, 23);
            this.btn_voltar.TabIndex = 39;
            this.btn_voltar.Text = "Voltar";
            this.btn_voltar.UseVisualStyleBackColor = true;
            this.btn_voltar.Click += new System.EventHandler(this.btn_voltar_Click);
            // 
            // cidade
            // 
            this.cidade.Enabled = false;
            this.cidade.Location = new System.Drawing.Point(61, 287);
            this.cidade.Name = "cidade";
            this.cidade.Size = new System.Drawing.Size(254, 20);
            this.cidade.TabIndex = 35;
            // 
            // lbCidade
            // 
            this.lbCidade.AutoSize = true;
            this.lbCidade.Location = new System.Drawing.Point(61, 271);
            this.lbCidade.Name = "lbCidade";
            this.lbCidade.Size = new System.Drawing.Size(40, 13);
            this.lbCidade.TabIndex = 38;
            this.lbCidade.Text = "Cidade";
            // 
            // comboEstados
            // 
            this.comboEstados.Enabled = false;
            this.comboEstados.FormattingEnabled = true;
            this.comboEstados.Location = new System.Drawing.Point(61, 240);
            this.comboEstados.Name = "comboEstados";
            this.comboEstados.Size = new System.Drawing.Size(254, 21);
            this.comboEstados.TabIndex = 34;
            // 
            // lbEstado
            // 
            this.lbEstado.AutoSize = true;
            this.lbEstado.Location = new System.Drawing.Point(61, 224);
            this.lbEstado.Name = "lbEstado";
            this.lbEstado.Size = new System.Drawing.Size(40, 13);
            this.lbEstado.TabIndex = 37;
            this.lbEstado.Text = "Estado";
            // 
            // bairro
            // 
            this.bairro.Enabled = false;
            this.bairro.Location = new System.Drawing.Point(61, 197);
            this.bairro.Name = "bairro";
            this.bairro.Size = new System.Drawing.Size(254, 20);
            this.bairro.TabIndex = 32;
            // 
            // lbBairro
            // 
            this.lbBairro.AutoSize = true;
            this.lbBairro.Location = new System.Drawing.Point(58, 176);
            this.lbBairro.Name = "lbBairro";
            this.lbBairro.Size = new System.Drawing.Size(34, 13);
            this.lbBairro.TabIndex = 29;
            this.lbBairro.Text = "Bairro";
            // 
            // endereco
            // 
            this.endereco.Enabled = false;
            this.endereco.Location = new System.Drawing.Point(61, 153);
            this.endereco.Name = "endereco";
            this.endereco.Size = new System.Drawing.Size(254, 20);
            this.endereco.TabIndex = 31;
            // 
            // lbEndereco
            // 
            this.lbEndereco.AutoSize = true;
            this.lbEndereco.Location = new System.Drawing.Point(58, 137);
            this.lbEndereco.Name = "lbEndereco";
            this.lbEndereco.Size = new System.Drawing.Size(53, 13);
            this.lbEndereco.TabIndex = 33;
            this.lbEndereco.Text = "Endereço";
            // 
            // cpf
            // 
            this.cpf.Enabled = false;
            this.cpf.Location = new System.Drawing.Point(61, 110);
            this.cpf.Name = "cpf";
            this.cpf.Size = new System.Drawing.Size(254, 20);
            this.cpf.TabIndex = 30;
            // 
            // lbCpf
            // 
            this.lbCpf.AutoSize = true;
            this.lbCpf.Location = new System.Drawing.Point(58, 94);
            this.lbCpf.Name = "lbCpf";
            this.lbCpf.Size = new System.Drawing.Size(27, 13);
            this.lbCpf.TabIndex = 36;
            this.lbCpf.Text = "CPF";
            // 
            // nome
            // 
            this.nome.Enabled = false;
            this.nome.Location = new System.Drawing.Point(61, 71);
            this.nome.Name = "nome";
            this.nome.Size = new System.Drawing.Size(254, 20);
            this.nome.TabIndex = 28;
            // 
            // lbNome
            // 
            this.lbNome.AutoSize = true;
            this.lbNome.Location = new System.Drawing.Point(58, 55);
            this.lbNome.Name = "lbNome";
            this.lbNome.Size = new System.Drawing.Size(35, 13);
            this.lbNome.TabIndex = 27;
            this.lbNome.Text = "Nome";
            // 
            // TelaDeDetalhes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 450);
            this.Controls.Add(this.btn_voltar);
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
            this.Name = "TelaDeDetalhes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "TelaDeDetalhes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_voltar;
        private System.Windows.Forms.TextBox cidade;
        private System.Windows.Forms.Label lbCidade;
        private System.Windows.Forms.ComboBox comboEstados;
        private System.Windows.Forms.Label lbEstado;
        private System.Windows.Forms.TextBox bairro;
        private System.Windows.Forms.Label lbBairro;
        private System.Windows.Forms.TextBox endereco;
        private System.Windows.Forms.Label lbEndereco;
        private System.Windows.Forms.TextBox cpf;
        private System.Windows.Forms.Label lbCpf;
        private System.Windows.Forms.TextBox nome;
        private System.Windows.Forms.Label lbNome;
    }
}