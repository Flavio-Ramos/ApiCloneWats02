namespace WatssDesktop
{
    partial class Mensagens
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
            this.btnSalvar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textSenha = new System.Windows.Forms.TextBox();
            this.textUsuario = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnEnviarMensagem = new System.Windows.Forms.Button();
            this.lblMensagem = new System.Windows.Forms.Label();
            this.textEnviarMensagem = new System.Windows.Forms.TextBox();
            this.btnReceberMensagem = new System.Windows.Forms.Button();
            this.panelDeMensagens = new System.Windows.Forms.Panel();
            this.lalbeSincronia = new System.Windows.Forms.Label();
            this.TesteReceberDB = new System.Windows.Forms.Button();
            this.LimarPanel = new System.Windows.Forms.Button();
            this.btnSincronizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelDeMensagens.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(85, 80);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.Text = "Entrar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Senha";
            // 
            // textSenha
            // 
            this.textSenha.Location = new System.Drawing.Point(72, 54);
            this.textSenha.Name = "textSenha";
            this.textSenha.Size = new System.Drawing.Size(100, 20);
            this.textSenha.TabIndex = 3;
            this.textSenha.TextChanged += new System.EventHandler(this.textSenha_TextChanged);
            // 
            // textUsuario
            // 
            this.textUsuario.Location = new System.Drawing.Point(72, 24);
            this.textUsuario.Name = "textUsuario";
            this.textUsuario.Size = new System.Drawing.Size(100, 20);
            this.textUsuario.TabIndex = 4;
            this.textUsuario.TextChanged += new System.EventHandler(this.textUsuario_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1, 176);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(310, 187);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnEnviarMensagem
            // 
            this.btnEnviarMensagem.Location = new System.Drawing.Point(474, 279);
            this.btnEnviarMensagem.Name = "btnEnviarMensagem";
            this.btnEnviarMensagem.Size = new System.Drawing.Size(75, 23);
            this.btnEnviarMensagem.TabIndex = 6;
            this.btnEnviarMensagem.Text = "Enviar";
            this.btnEnviarMensagem.UseVisualStyleBackColor = true;
            this.btnEnviarMensagem.Click += new System.EventHandler(this.btnEnviarMensagem_Click);
            // 
            // lblMensagem
            // 
            this.lblMensagem.AutoSize = true;
            this.lblMensagem.Location = new System.Drawing.Point(152, 0);
            this.lblMensagem.Name = "lblMensagem";
            this.lblMensagem.Size = new System.Drawing.Size(59, 13);
            this.lblMensagem.TabIndex = 8;
            this.lblMensagem.Text = "Mensagem";
            this.lblMensagem.Click += new System.EventHandler(this.label3_Click);
            // 
            // textEnviarMensagem
            // 
            this.textEnviarMensagem.Location = new System.Drawing.Point(362, 210);
            this.textEnviarMensagem.Multiline = true;
            this.textEnviarMensagem.Name = "textEnviarMensagem";
            this.textEnviarMensagem.Size = new System.Drawing.Size(319, 63);
            this.textEnviarMensagem.TabIndex = 9;
            this.textEnviarMensagem.TextChanged += new System.EventHandler(this.textEnviarMensagem_TextChanged);
            // 
            // btnReceberMensagem
            // 
            this.btnReceberMensagem.Location = new System.Drawing.Point(201, 17);
            this.btnReceberMensagem.Name = "btnReceberMensagem";
            this.btnReceberMensagem.Size = new System.Drawing.Size(110, 23);
            this.btnReceberMensagem.TabIndex = 10;
            this.btnReceberMensagem.Text = "TesteReceberWeb";
            this.btnReceberMensagem.UseVisualStyleBackColor = true;
            this.btnReceberMensagem.Click += new System.EventHandler(this.btnReceberMensagem_Click);
            // 
            // panelDeMensagens
            // 
            this.panelDeMensagens.AutoScroll = true;
            this.panelDeMensagens.AutoScrollMinSize = new System.Drawing.Size(0, 100);
            this.panelDeMensagens.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDeMensagens.Controls.Add(this.lblMensagem);
            this.panelDeMensagens.Location = new System.Drawing.Point(337, 12);
            this.panelDeMensagens.Name = "panelDeMensagens";
            this.panelDeMensagens.Size = new System.Drawing.Size(368, 192);
            this.panelDeMensagens.TabIndex = 12;
            this.panelDeMensagens.TabStop = true;
            this.panelDeMensagens.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDeMensagens_Paint);
            // 
            // lalbeSincronia
            // 
            this.lalbeSincronia.AutoSize = true;
            this.lalbeSincronia.Location = new System.Drawing.Point(663, 350);
            this.lalbeSincronia.Name = "lalbeSincronia";
            this.lalbeSincronia.Size = new System.Drawing.Size(74, 13);
            this.lalbeSincronia.TabIndex = 13;
            this.lalbeSincronia.Text = "Sincronizando";
            this.lalbeSincronia.Click += new System.EventHandler(this.lalbeSincronia_Click);
            // 
            // TesteReceberDB
            // 
            this.TesteReceberDB.Location = new System.Drawing.Point(201, 46);
            this.TesteReceberDB.Name = "TesteReceberDB";
            this.TesteReceberDB.Size = new System.Drawing.Size(110, 23);
            this.TesteReceberDB.TabIndex = 14;
            this.TesteReceberDB.Text = "TesteReceberDB";
            this.TesteReceberDB.UseVisualStyleBackColor = true;
            this.TesteReceberDB.Click += new System.EventHandler(this.TesteReceberDB_Click);
            // 
            // LimarPanel
            // 
            this.LimarPanel.Location = new System.Drawing.Point(201, 80);
            this.LimarPanel.Name = "LimarPanel";
            this.LimarPanel.Size = new System.Drawing.Size(110, 23);
            this.LimarPanel.TabIndex = 15;
            this.LimarPanel.Text = "LimarPanel";
            this.LimarPanel.UseVisualStyleBackColor = true;
            this.LimarPanel.Click += new System.EventHandler(this.LimarPanel_Click);
            // 
            // btnSincronizar
            // 
            this.btnSincronizar.Location = new System.Drawing.Point(791, 27);
            this.btnSincronizar.Name = "btnSincronizar";
            this.btnSincronizar.Size = new System.Drawing.Size(75, 23);
            this.btnSincronizar.TabIndex = 16;
            this.btnSincronizar.Text = "Sincronizar";
            this.btnSincronizar.UseVisualStyleBackColor = true;
            this.btnSincronizar.Click += new System.EventHandler(this.btnSincronizar_Click);
            // 
            // Mensagens
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(882, 450);
            this.ControlBox = false;
            this.Controls.Add(this.btnSincronizar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.LimarPanel);
            this.Controls.Add(this.TesteReceberDB);
            this.Controls.Add(this.lalbeSincronia);
            this.Controls.Add(this.panelDeMensagens);
            this.Controls.Add(this.btnReceberMensagem);
            this.Controls.Add(this.textEnviarMensagem);
            this.Controls.Add(this.btnEnviarMensagem);
            this.Controls.Add(this.textUsuario);
            this.Controls.Add(this.textSenha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalvar);
            this.Name = "Mensagens";
            this.Text = "Mensagens";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelDeMensagens.ResumeLayout(false);
            this.panelDeMensagens.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textSenha;
        private System.Windows.Forms.TextBox textUsuario;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnEnviarMensagem;
        private System.Windows.Forms.Label lblMensagem;
        private System.Windows.Forms.TextBox textEnviarMensagem;
        private System.Windows.Forms.Button btnReceberMensagem;
        private System.Windows.Forms.Panel panelDeMensagens;
        private System.Windows.Forms.Button TesteReceberDB;
        private System.Windows.Forms.Button LimarPanel;
        private System.Windows.Forms.Button btnSincronizar;
        public System.Windows.Forms.Label lalbeSincronia;
    }
}

