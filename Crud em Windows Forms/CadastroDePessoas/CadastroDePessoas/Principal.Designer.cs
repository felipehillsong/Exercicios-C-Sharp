
namespace CadastroDePessoas
{
    partial class Principal
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
            this.lb_cadastro = new System.Windows.Forms.Label();
            this.btn_entrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_cadastro
            // 
            this.lb_cadastro.AutoSize = true;
            this.lb_cadastro.Location = new System.Drawing.Point(119, 53);
            this.lb_cadastro.Name = "lb_cadastro";
            this.lb_cadastro.Size = new System.Drawing.Size(114, 13);
            this.lb_cadastro.TabIndex = 0;
            this.lb_cadastro.Text = "TELA DE CADASTRO";
            // 
            // btn_entrar
            // 
            this.btn_entrar.Location = new System.Drawing.Point(122, 231);
            this.btn_entrar.Name = "btn_entrar";
            this.btn_entrar.Size = new System.Drawing.Size(111, 23);
            this.btn_entrar.TabIndex = 1;
            this.btn_entrar.Text = "Clique Para Entrar";
            this.btn_entrar.UseVisualStyleBackColor = true;
            this.btn_entrar.Click += new System.EventHandler(this.btn_entrar_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 450);
            this.Controls.Add(this.btn_entrar);
            this.Controls.Add(this.lb_cadastro);
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_cadastro;
        private System.Windows.Forms.Button btn_entrar;
    }
}