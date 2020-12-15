using System;
using System.Windows.Forms;

namespace WatssDesktop
{
    public partial class Login : Form
    {
        //private Mensagens FormMensagens;
        //private MeusDados FormMeusDados;
        private TelaPrincipal FormTelaPrincipal;
        public Login()
        {
            InitializeComponent();
        }

        private  void Entrar_Click(object sender, EventArgs e)
        {
            if(FormTelaPrincipal == null)
            {
                FormTelaPrincipal = new TelaPrincipal();
                FormTelaPrincipal.Show();
                FormTelaPrincipal.PegaFormLogin(this);
            }
            else
            {
                FormTelaPrincipal.Visible = true;
            }
            this.Visible = false;
        }

    }
}
