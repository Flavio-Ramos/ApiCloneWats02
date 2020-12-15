namespace TesteConexaoDbSql
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
            this.TestarConexao = new System.Windows.Forms.Button();
            this.EscreveNoBanco = new System.Windows.Forms.Button();
            this.ExibirMensagem = new System.Windows.Forms.TextBox();
            this.InserirTeste = new System.Windows.Forms.Button();
            this.labelConexao = new System.Windows.Forms.Label();
            this.btnMudarCor = new System.Windows.Forms.Button();
            this.btnVermelho = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TestarConexao
            // 
            this.TestarConexao.Location = new System.Drawing.Point(124, 32);
            this.TestarConexao.Name = "TestarConexao";
            this.TestarConexao.Size = new System.Drawing.Size(181, 23);
            this.TestarConexao.TabIndex = 0;
            this.TestarConexao.Text = "Testar Conexao";
            this.TestarConexao.UseVisualStyleBackColor = true;
            this.TestarConexao.Click += new System.EventHandler(this.TestarConexao_Click);
            // 
            // EscreveNoBanco
            // 
            this.EscreveNoBanco.Location = new System.Drawing.Point(124, 87);
            this.EscreveNoBanco.Name = "EscreveNoBanco";
            this.EscreveNoBanco.Size = new System.Drawing.Size(181, 23);
            this.EscreveNoBanco.TabIndex = 1;
            this.EscreveNoBanco.Text = "Escreve No Banco";
            this.EscreveNoBanco.UseVisualStyleBackColor = true;
            // 
            // ExibirMensagem
            // 
            this.ExibirMensagem.Location = new System.Drawing.Point(330, 32);
            this.ExibirMensagem.Multiline = true;
            this.ExibirMensagem.Name = "ExibirMensagem";
            this.ExibirMensagem.Size = new System.Drawing.Size(213, 250);
            this.ExibirMensagem.TabIndex = 2;
            this.ExibirMensagem.TextChanged += new System.EventHandler(this.ExibirMensagem_TextChanged);
            // 
            // InserirTeste
            // 
            this.InserirTeste.Location = new System.Drawing.Point(124, 141);
            this.InserirTeste.Name = "InserirTeste";
            this.InserirTeste.Size = new System.Drawing.Size(181, 23);
            this.InserirTeste.TabIndex = 3;
            this.InserirTeste.Text = "Inserir Teste";
            this.InserirTeste.UseVisualStyleBackColor = true;
            this.InserirTeste.Click += new System.EventHandler(this.InserirTeste_Click);
            // 
            // labelConexao
            // 
            this.labelConexao.AutoSize = true;
            this.labelConexao.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelConexao.Location = new System.Drawing.Point(124, 248);
            this.labelConexao.Name = "labelConexao";
            this.labelConexao.Size = new System.Drawing.Size(49, 13);
            this.labelConexao.TabIndex = 4;
            this.labelConexao.Text = "Conexao";
            this.labelConexao.Click += new System.EventHandler(this.labelConexao_Click);
            // 
            // btnMudarCor
            // 
            this.btnMudarCor.Location = new System.Drawing.Point(169, 201);
            this.btnMudarCor.Name = "btnMudarCor";
            this.btnMudarCor.Size = new System.Drawing.Size(75, 23);
            this.btnMudarCor.TabIndex = 5;
            this.btnMudarCor.Text = "Mudar Cor";
            this.btnMudarCor.UseVisualStyleBackColor = true;
            this.btnMudarCor.Click += new System.EventHandler(this.btnMudarCor_Click);
            // 
            // btnVermelho
            // 
            this.btnVermelho.Location = new System.Drawing.Point(68, 201);
            this.btnVermelho.Name = "btnVermelho";
            this.btnVermelho.Size = new System.Drawing.Size(75, 23);
            this.btnVermelho.TabIndex = 6;
            this.btnVermelho.Text = "Cor Vermelha";
            this.btnVermelho.UseVisualStyleBackColor = true;
            this.btnVermelho.Click += new System.EventHandler(this.btnVermelho_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 450);
            this.Controls.Add(this.btnVermelho);
            this.Controls.Add(this.btnMudarCor);
            this.Controls.Add(this.labelConexao);
            this.Controls.Add(this.InserirTeste);
            this.Controls.Add(this.ExibirMensagem);
            this.Controls.Add(this.EscreveNoBanco);
            this.Controls.Add(this.TestarConexao);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button TestarConexao;
        private System.Windows.Forms.Button EscreveNoBanco;
        private System.Windows.Forms.TextBox ExibirMensagem;
        private System.Windows.Forms.Button InserirTeste;
        private System.Windows.Forms.Button btnMudarCor;
        private System.Windows.Forms.Button btnVermelho;
        public System.Windows.Forms.Label labelConexao;
    }
}

