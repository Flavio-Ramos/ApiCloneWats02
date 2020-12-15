namespace WatssDesktop
{
    partial class TelaPrincipal
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
            this.btnMeusDados = new System.Windows.Forms.Button();
            this.btnMensagens = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Fechar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMeusDados
            // 
            this.btnMeusDados.Location = new System.Drawing.Point(92, 0);
            this.btnMeusDados.Name = "btnMeusDados";
            this.btnMeusDados.Size = new System.Drawing.Size(94, 23);
            this.btnMeusDados.TabIndex = 4;
            this.btnMeusDados.Text = "Meus Dados";
            this.btnMeusDados.UseVisualStyleBackColor = true;
            this.btnMeusDados.Click += new System.EventHandler(this.btnMeusDados_Click);
            // 
            // btnMensagens
            // 
            this.btnMensagens.Location = new System.Drawing.Point(0, 0);
            this.btnMensagens.Name = "btnMensagens";
            this.btnMensagens.Size = new System.Drawing.Size(86, 23);
            this.btnMensagens.TabIndex = 5;
            this.btnMensagens.Text = "Mensagens";
            this.btnMensagens.UseVisualStyleBackColor = true;
            this.btnMensagens.Click += new System.EventHandler(this.btnMensagens_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(632, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Fechar
            // 
            this.Fechar.Location = new System.Drawing.Point(192, 0);
            this.Fechar.Name = "Fechar";
            this.Fechar.Size = new System.Drawing.Size(75, 23);
            this.Fechar.TabIndex = 8;
            this.Fechar.Text = "Fechar";
            this.Fechar.UseVisualStyleBackColor = true;
            this.Fechar.Click += new System.EventHandler(this.Fechar_Click);
            // 
            // TelaPrincipal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.ControlBox = false;
            this.Controls.Add(this.Fechar);
            this.Controls.Add(this.btnMensagens);
            this.Controls.Add(this.btnMeusDados);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Name = "TelaPrincipal";
            this.Text = "Wats";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Button btnMeusDados;
        private System.Windows.Forms.Button btnMensagens;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button Fechar;
    }
}



