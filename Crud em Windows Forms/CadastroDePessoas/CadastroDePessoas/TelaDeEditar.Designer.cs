
namespace CadastroDePessoas
{
    partial class TelaDeEditar
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
            this.btnEnviar = new System.Windows.Forms.Button();
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
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnEnviar.Location = new System.Drawing.Point(243, 321);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 23;
            this.btnEnviar.Text = "Alterar";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // cidade
            // 
            this.cidade.Location = new System.Drawing.Point(64, 279);
            this.cidade.Name = "cidade";
            this.cidade.Size = new System.Drawing.Size(254, 20);
            this.cidade.TabIndex = 21;
            // 
            // lbCidade
            // 
            this.lbCidade.AutoSize = true;
            this.lbCidade.Location = new System.Drawing.Point(64, 263);
            this.lbCidade.Name = "lbCidade";
            this.lbCidade.Size = new System.Drawing.Size(40, 13);
            this.lbCidade.TabIndex = 25;
            this.lbCidade.Text = "Cidade";
            // 
            // comboEstados
            // 
            this.comboEstados.FormattingEnabled = true;
            this.comboEstados.Location = new System.Drawing.Point(64, 232);
            this.comboEstados.Name = "comboEstados";
            this.comboEstados.Size = new System.Drawing.Size(254, 21);
            this.comboEstados.TabIndex = 20;
            // 
            // lbEstado
            // 
            this.lbEstado.AutoSize = true;
            this.lbEstado.Location = new System.Drawing.Point(64, 216);
            this.lbEstado.Name = "lbEstado";
            this.lbEstado.Size = new System.Drawing.Size(40, 13);
            this.lbEstado.TabIndex = 24;
            this.lbEstado.Text = "Estado";
            // 
            // bairro
            // 
            this.bairro.Location = new System.Drawing.Point(64, 189);
            this.bairro.Name = "bairro";
            this.bairro.Size = new System.Drawing.Size(254, 20);
            this.bairro.TabIndex = 18;
            // 
            // lbBairro
            // 
            this.lbBairro.AutoSize = true;
            this.lbBairro.Location = new System.Drawing.Point(61, 168);
            this.lbBairro.Name = "lbBairro";
            this.lbBairro.Size = new System.Drawing.Size(34, 13);
            this.lbBairro.TabIndex = 15;
            this.lbBairro.Text = "Bairro";
            // 
            // endereco
            // 
            this.endereco.Location = new System.Drawing.Point(64, 145);
            this.endereco.Name = "endereco";
            this.endereco.Size = new System.Drawing.Size(254, 20);
            this.endereco.TabIndex = 17;
            // 
            // lbEndereco
            // 
            this.lbEndereco.AutoSize = true;
            this.lbEndereco.Location = new System.Drawing.Point(61, 129);
            this.lbEndereco.Name = "lbEndereco";
            this.lbEndereco.Size = new System.Drawing.Size(53, 13);
            this.lbEndereco.TabIndex = 19;
            this.lbEndereco.Text = "Endereço";
            // 
            // cpf
            // 
            this.cpf.Location = new System.Drawing.Point(64, 102);
            this.cpf.Name = "cpf";
            this.cpf.Size = new System.Drawing.Size(254, 20);
            this.cpf.TabIndex = 16;
            // 
            // lbCpf
            // 
            this.lbCpf.AutoSize = true;
            this.lbCpf.Location = new System.Drawing.Point(61, 86);
            this.lbCpf.Name = "lbCpf";
            this.lbCpf.Size = new System.Drawing.Size(27, 13);
            this.lbCpf.TabIndex = 22;
            this.lbCpf.Text = "CPF";
            // 
            // nome
            // 
            this.nome.Location = new System.Drawing.Point(64, 63);
            this.nome.Name = "nome";
            this.nome.Size = new System.Drawing.Size(254, 20);
            this.nome.TabIndex = 14;
            // 
            // lbNome
            // 
            this.lbNome.AutoSize = true;
            this.lbNome.Location = new System.Drawing.Point(61, 47);
            this.lbNome.Name = "lbNome";
            this.lbNome.Size = new System.Drawing.Size(35, 13);
            this.lbNome.TabIndex = 13;
            this.lbNome.Text = "Nome";
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Location = new System.Drawing.Point(64, 321);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(75, 23);
            this.btn_cancelar.TabIndex = 26;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // TelaDeEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 450);
            this.Controls.Add(this.btn_cancelar);
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
            this.Name = "TelaDeEditar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "TelaDeEditar";
            this.Load += new System.EventHandler(this.TelaDeEditar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnviar;
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
        private System.Windows.Forms.Button btn_cancelar;
    }
}