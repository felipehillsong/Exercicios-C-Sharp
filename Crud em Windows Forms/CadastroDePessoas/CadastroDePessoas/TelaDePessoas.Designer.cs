
namespace CadastroDePessoas
{
    partial class TelaDePessoas
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
            this.btn_incluir = new System.Windows.Forms.Button();
            this.dataGridPessoas = new System.Windows.Forms.DataGridView();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_alterar = new System.Windows.Forms.Button();
            this.btn_detalhes = new System.Windows.Forms.Button();
            this.btn_deletar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPessoas)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_incluir
            // 
            this.btn_incluir.Location = new System.Drawing.Point(367, 49);
            this.btn_incluir.Name = "btn_incluir";
            this.btn_incluir.Size = new System.Drawing.Size(98, 23);
            this.btn_incluir.TabIndex = 27;
            this.btn_incluir.Text = "Novo Cadastro";
            this.btn_incluir.UseVisualStyleBackColor = true;
            this.btn_incluir.Click += new System.EventHandler(this.btn_incluir_click);
            // 
            // dataGridPessoas
            // 
            this.dataGridPessoas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridPessoas.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridPessoas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPessoas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nome});
            this.dataGridPessoas.Location = new System.Drawing.Point(367, 108);
            this.dataGridPessoas.Name = "dataGridPessoas";
            this.dataGridPessoas.ReadOnly = true;
            this.dataGridPessoas.Size = new System.Drawing.Size(511, 150);
            this.dataGridPessoas.TabIndex = 28;
            // 
            // Nome
            // 
            this.Nome.DataPropertyName = "Nome";
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            // 
            // btn_alterar
            // 
            this.btn_alterar.Location = new System.Drawing.Point(411, 295);
            this.btn_alterar.Name = "btn_alterar";
            this.btn_alterar.Size = new System.Drawing.Size(75, 23);
            this.btn_alterar.TabIndex = 29;
            this.btn_alterar.Text = "Alterar";
            this.btn_alterar.UseVisualStyleBackColor = true;
            this.btn_alterar.Click += new System.EventHandler(this.btn_alterar_Click);
            // 
            // btn_detalhes
            // 
            this.btn_detalhes.Location = new System.Drawing.Point(590, 295);
            this.btn_detalhes.Name = "btn_detalhes";
            this.btn_detalhes.Size = new System.Drawing.Size(75, 23);
            this.btn_detalhes.TabIndex = 30;
            this.btn_detalhes.Text = "Detalhes";
            this.btn_detalhes.UseVisualStyleBackColor = true;
            this.btn_detalhes.Click += new System.EventHandler(this.btn_detalhes_Click);
            // 
            // btn_deletar
            // 
            this.btn_deletar.Location = new System.Drawing.Point(756, 295);
            this.btn_deletar.Name = "btn_deletar";
            this.btn_deletar.Size = new System.Drawing.Size(75, 23);
            this.btn_deletar.TabIndex = 31;
            this.btn_deletar.Text = "Deletar";
            this.btn_deletar.UseVisualStyleBackColor = true;
            this.btn_deletar.Click += new System.EventHandler(this.btn_deletar_Click);
            // 
            // TelaDePessoas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 499);
            this.Controls.Add(this.btn_deletar);
            this.Controls.Add(this.btn_detalhes);
            this.Controls.Add(this.btn_alterar);
            this.Controls.Add(this.dataGridPessoas);
            this.Controls.Add(this.btn_incluir);
            this.IsMdiContainer = true;
            this.Name = "TelaDePessoas";
            this.Text = "TelaDePessoas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TelaDePessoas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPessoas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_incluir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.Button btn_alterar;
        private System.Windows.Forms.Button btn_detalhes;
        private System.Windows.Forms.Button btn_deletar;
        public System.Windows.Forms.DataGridView dataGridPessoas;
    }
}