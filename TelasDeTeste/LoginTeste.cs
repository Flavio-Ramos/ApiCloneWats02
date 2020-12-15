using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelasDeTeste
{
    public partial class LoginTeste : Form
    {
        public LoginTeste()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Tela1 tela1 = new Tela1();
            tela1.Show();
            tela1.pegaTelaLogin(this);
            this.Visible = false;
        }
    }
}
