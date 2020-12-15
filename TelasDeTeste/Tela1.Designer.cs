namespace TelasDeTeste
{
    partial class Tela1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Tela2 = new System.Windows.Forms.Button();
            this.Tela3 = new System.Windows.Forms.Button();
            this.Form1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(785, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Tela2
            // 
            this.Tela2.Location = new System.Drawing.Point(106, 1);
            this.Tela2.Name = "Tela2";
            this.Tela2.Size = new System.Drawing.Size(75, 23);
            this.Tela2.TabIndex = 5;
            this.Tela2.Text = "Tela2";
            this.Tela2.UseVisualStyleBackColor = true;
            this.Tela2.Click += new System.EventHandler(this.Tela2_Click);
            // 
            // Tela3
            // 
            this.Tela3.Location = new System.Drawing.Point(214, 0);
            this.Tela3.Name = "Tela3";
            this.Tela3.Size = new System.Drawing.Size(75, 23);
            this.Tela3.TabIndex = 6;
            this.Tela3.Text = "Tela3";
            this.Tela3.UseVisualStyleBackColor = true;
            this.Tela3.Click += new System.EventHandler(this.Tela3_Click);
            // 
            // Form1
            // 
            this.Form1.Location = new System.Drawing.Point(0, 1);
            this.Form1.Name = "Form1";
            this.Form1.Size = new System.Drawing.Size(75, 23);
            this.Form1.TabIndex = 7;
            this.Form1.Text = "Form1";
            this.Form1.UseVisualStyleBackColor = true;
            this.Form1.Click += new System.EventHandler(this.Form1_Click);
            // 
            // Tela1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 453);
            this.Controls.Add(this.Form1);
            this.Controls.Add(this.Tela3);
            this.Controls.Add(this.Tela2);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Tela1";
            this.Text = "Tela1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Tela1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button Tela2;
        private System.Windows.Forms.Button Tela3;
        private System.Windows.Forms.Button Form1;
    }
}



