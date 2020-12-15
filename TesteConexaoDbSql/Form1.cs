using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace TesteConexaoDbSql
{
    public delegate void ThresholdReachedEventHandler(Object sender, EventosDiversos e);

public partial class Form1 : Form
    {
        private bool Sincronizando = false;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void TestarConexao_Click(object sender, EventArgs e)
        {
            IDbConnection conexao;
            StringConexao stringConexao = new StringConexao();
            //string stringConexao = @"Data Source = (localdb)\MSSQLLocalDB; Database = Teste; User ID = sa; Password = senha; TrustServerCertificate = True; Trusted_Connection = False; Connection Timeout = 300; Integrated Security = False; Persist Security Info = False; Encrypt = false; MultipleActiveResultSets = True;";
            conexao = new SqlConnection(stringConexao.getStringConexao());
            conexao.Open();
            var listaTeste = new List<Teste>();

            try
            {
                IDbCommand selectCmd = conexao.CreateCommand();
                selectCmd.CommandText = "Select * from Teste";

                IDataReader resultado = selectCmd.ExecuteReader();
                while (resultado.Read())
                {
                    var conexaoTeste = new Teste()
                    {
                        Texto = Convert.ToString(resultado["Texto"]),

                    };
                    listaTeste.Add(conexaoTeste);
                }

                ExibirMensagem.Controls.Clear();
                int espaco = 25;
                int posicao = 20;
                List<Label> ListaMensagens = new List<Label>();
                foreach (Teste obj in listaTeste)
                {
                    Label label = new Label();
                    label.Text = obj.Texto;
                    label.Top = posicao;
                    this.Controls.Add(label);
                    posicao += espaco;
                    ExibirMensagem.Controls.Add(label);
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void ExibirMensagem_TextChanged(object sender, EventArgs e)
        {

        }

        private void InserirTeste_Click(object sender, EventArgs e)
        {
            IDbConnection conexao;
            StringConexao stringConexao = new StringConexao();
            //string stringConexao = @"Data Source = (localdb)\MSSQLLocalDB; Database = Teste; User ID = sa; Password = senha; TrustServerCertificate = True; Trusted_Connection = False; Connection Timeout = 300; Integrated Security = False; Persist Security Info = False; Encrypt = false; MultipleActiveResultSets = True;";
            conexao = new SqlConnection(stringConexao.getStringConexao());
            conexao.Open();
            var listaTeste = new List<Teste>();

            try
            {
                IDbCommand insertCmd = conexao.CreateCommand();
                insertCmd.CommandText = "insert into Teste values('Teste - '+ CONVERT(varchar, getdate(), 121))";
                IDataReader resultado = insertCmd.ExecuteReader();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }
        public void mudarCor()
        {
            labelConexao.ForeColor = Color.DarkGreen;
            labelConexao.Text = "Cor alterada";
        }
        private void btnMudarCor_Click(object sender, EventArgs e)
        {
            mudarCor();
            //Sincronizando = false;
            //MetodosDosEventos c = new MetodosDosEventos();
            //c.EventThresholdReached += EventVerificarSincronizandoLabel;
            //c.EventMudarCorLabelSincronia();
        }
        public void EventVerificarSincronizandoLabel(Object sender, EventosDiversos e)
        {
            if (Sincronizando == true)
            {
                labelConexao.ForeColor = Color.Red;
                labelConexao.Text = "Sincronizando";
            }
            else
            {
                labelConexao.ForeColor = Color.Black;
                labelConexao.Text = "Sincronia";
            }
        }

        private void btnVermelho_Click(object sender, EventArgs e)
        {
            Sincronizando = true;
            MetodosDosEventos c = new MetodosDosEventos();
            c.EventThresholdReached += EventVerificarSincronizandoLabel;
            c.EventMudarCorLabelSincronia();
        }

        public void labelConexao_Click(object sender, EventArgs e)
        {
            
        }
    }
    public class Teste
    {
        public string Texto { get; set; }
    }
    public class StringConexao
    {
        //public string Texto { get; set; } = @"Data Source =  192.168.1.101\(localdb)\MSSQLLocalDB; Database = Teste; User ID = sa; Password = senha; TrustServerCertificate = True; Trusted_Connection = False; Connection Timeout = 300; Integrated Security = False; Persist Security Info = False; Encrypt = false; MultipleActiveResultSets = True;";
        //public string Texto { get; set; } = @"Data Source = (localdb)\MSSQLLocalDB; Database = Teste; User ID = sa; Password = senha;";// providerName=System.Data.SqlClient;";
        //public string Texto { get; set; } = @"Network Library=dbmssocn;Data Source=192.168.0.3,1433\DESKTOP-CA6P0JT\SQLEXPRESS; Database = Teste; User ID = sa; Password = uv123!@#";// providerName=System.Data.SqlClient;";
        //public string Texto { get; set; } = @"Driver=DB2OLEDB;Network Transport Library=TCPIP;Network Address=192.168.0.3; Package Collection=CollectionName;Initial Catalog=Teste;User id=sa;Password=uv123!@#;"; 
        //public string Texto { get; set; } = @"Data Source = 192.168.0.3\DESKTOP-CA6P0JT\SQLEXPRESS; Database = Teste; User ID = sa; Password = uv123!@#; TrustServerCertificate = True; Trusted_Connection = False; Connection Timeout = 300; Integrated Security = False; Persist Security Info = False; Encrypt = false; MultipleActiveResultSets = True;";
        public string Texto { get; set; } = @"Data Source=192.168.1.100; Network Library=DBMSSOCN; Initial Catalog=Teste; User ID=sa;Password=uv123!@#";
        public string getStringConexao()
        {
            return Texto;
        }
    }

}
