using App.Domain.Desctop;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using WatssDesktop.Controllers;
using WatssDesktop.Models;
using WatssDesktop.SevircoSincronia;

namespace WatssDesktop
{
    public delegate void ThresholdReachedEventHandler(Object sender, EventosDiversos e);
    public partial class Mensagens : Form
    {
        public static int NumeroDeLinhasMsnDoDB = 0;
        public static int mudaCor = 0;
        public static System.Timers.Timer _timer;
        private static bool Sincronizando = false;
        private static bool AtualizarBarra = false;
        private static int UlitmoId = 0;


        public Mensagens()
        {
            InitializeComponent();
            SincronizarAutomaticamente();
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://myfirstprogram.gearhostpreview.com/api/Usuario");

                //leitura de dados, buscar os dados(Get)
                var resposta = await client.GetAsync("");
                string dados = await resposta.Content.ReadAsStringAsync();
                List<UsuarioDTO> usuarios = new JavaScriptSerializer().Deserialize<List<UsuarioDTO>>(dados);

                dataGridView1.DataSource = usuarios;
            }
        }

        private void textUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void textSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEnviarMensagem_Click(object sender, EventArgs e)
        {
            MensagemCTRL mensagemCTRL = new MensagemCTRL();
            var mensagem = textEnviarMensagem.Text;
            if (!mensagem.Any())
            {
                return;
            }
            mensagemCTRL.EnviarMensagem(mensagem);
            textEnviarMensagem.Text = "";
            MensagenModel mensagenModel = new MensagenModel();
            var mensagens = mensagenModel.ListarMensagens(NumeroDeLinhasMsnDoDB);
            FormataTexBoxReceberMensagens2(mensagens);
            textEnviarMensagem.Text = "";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textMensagem_TextChanged(object sender, EventArgs e)
        {

        }

        private void textEnviarMensagem_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnReceberMensagem_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://myfirstprogram.gearhostpreview.com/api/Mensagens");

                var resposta = await client.GetAsync("");
                string dados = await resposta.Content.ReadAsStringAsync();
                List<MensagemDTO> mensagens = new JavaScriptSerializer().Deserialize<List<MensagemDTO>>(dados);

                FormataTexBoxReceberMensagens2(mensagens);
            }
        }

        public void FormataTexBoxReceberMensagens2(List<MensagemDTO> mensagens)
        {
            try
            {
                if (!PodeRefreshTextMensagem(mensagens))
                {
                    return;
                }

                panelDeMensagens.Controls.Clear();
                int espaco = 20;
                int posicao = 25;
                int tamanhoLista = mensagens.Count;
                for (int i = tamanhoLista - 1; i >= 0; i--)
                {
                    if (!this.Visible)
                    {
                        return;
                    }
                    MensagemDTO obj = mensagens[i];
                    if (obj.Id > UlitmoId)
                    {
                        UlitmoId = obj.Id;
                    }
                    if (obj.PaiMensagem == 1)
                    {
                        posicao = FormatacaoTamanhoLabel(obj.Mensagem, posicao, true, espaco, false);
                    }
                    else
                    {
                        posicao = FormatacaoTamanhoLabel(obj.Mensagem, posicao, false, espaco, true);
                    }
                }

                if (AtualizarBarra)
                {
                    panelDeMensagens.AutoScrollPosition = new Point(0, 189);
                    if (panelDeMensagens.VerticalScroll.Visible)
                    {
                        panelDeMensagens.VerticalScroll.Value = 189;
                    }
                }
                else
                {
                    panelDeMensagens.AutoScrollPosition = new Point(0, panelDeMensagens.VerticalScroll.Maximum);
                }
            }
            catch (Exception)
            {

                throw;
            }
            AtualizarBarra = false;
        }
        private int FormatacaoTamanhoLabel(string valor, int parPosicao, bool point, int parEspaco, bool parAutoSize)
        {
            int limite = 20;
            if (valor.Length < limite)
            {
                CriarNovaLabel(valor, parPosicao, parEspaco, point, parAutoSize);
                parPosicao += parEspaco;
                return parPosicao;
            }
            else
            {
                string[] list = valor.Split(' ');
                string linha1 = "";
                string linhaanterior = "";
                for (int i = 0; i < list.Length; i++)
                {
                    linhaanterior = linha1;
                    linha1 += list[i];
                    if ((linha1.Length >= limite) && (linhaanterior == ""))
                    {
                        linha1 = list[i].Substring(0, limite-1);
                        list[i] = list[i].Substring(limite);
                        i--;
                        CriarNovaLabel(linha1, parPosicao, parEspaco, point, parAutoSize);
                        linha1 = "";
                        parPosicao += parEspaco;
                    }
                    else
                    {
                        if ((linha1.Length <= limite) && (linhaanterior == "") && (i == (list.Length - 1)))
                        {
                            linha1 = list[i];
                            CriarNovaLabel(linha1, parPosicao, parEspaco, point, parAutoSize);
                            parPosicao += parEspaco;
                            linha1 = "";
                            return parPosicao;
                        }
                        else
                        {
                            if ((linha1.Length <= limite) && (i < (list.Length - 1)))
                            {
                                linha1 += " ";
                                linhaanterior = linha1;
                            }
                            else
                            {
                                if ((i == (list.Length - 1)) && (linha1.Length <= limite))
                                {
                                    CriarNovaLabel(list[i], parPosicao, parEspaco, point, parAutoSize);
                                    parPosicao += parEspaco;
                                    return parPosicao;
                                }
                                else
                                {
                                    if(linha1.Length > limite)
                                    {
                                        linha1 = linhaanterior;
                                        linhaanterior = "";
                                        i--;
                                        CriarNovaLabel(linha1, parPosicao, parEspaco, point, parAutoSize);
                                        parPosicao += parEspaco;
                                        linha1 = "";
                                    }
                                    else
                                    {
                                        linha1 += " ";
                                    }   
                                }
                            }
                        }
                    }
                }
                return parPosicao;
            }
        }
        private void CriarNovaLabel(string valor,int parPosicao, int parEspaco,bool parLocation,bool parAutoSize)
        {
            try
            {
                Label label = new Label();
                label.Text = valor;
                label.Top = parPosicao;

                if (parLocation)
                {
                    label.Location = new Point(130, parPosicao);
                }
                else
                {
                    label.Location = new Point(0, parPosicao);
                }
                label.AutoSize = true;
                this.Controls.Add(label);
                panelDeMensagens.Controls.Add(label);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void AlterarNumeroDeLinhasMsnDoDB()
        {
            try
            {
                if (panelDeMensagens.VerticalScroll.Value == 0)
                {
                    NumeroDeLinhasMsnDoDB += 8;
                    AtualizarBarra = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private bool PodeRefreshTextMensagem(List<MensagemDTO> mensagem)
        {
            try
            {
                if (!this.Visible)
                {
                    return false;
                }
                int maxId = 0;
                if (mensagem.Any())
                {
                    foreach (MensagemDTO obj in mensagem)
                    {
                        if (obj.Id > UlitmoId)
                        {
                            maxId = obj.Id;
                            return true;
                        }
                    }
                }
                Panel panel = panelDeMensagens;
                int p1 = panel.VerticalScroll.Value + 189;
                int p2 = panel.VerticalScroll.Maximum;
                int r1 = panel.Controls.Count;
                if (((p1 == p2) && (maxId > UlitmoId)) || (p2 == 100) || (r1 == 0) || (AtualizarBarra))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }
        private void dataGridViewRecebeMensagens_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelDeMensagens_Paint(object sender, PaintEventArgs e)
        {

        }

        public void lalbeSincronia_Click(object sender, EventArgs e)
        {

        }

        public async void DefineSincronizando()
        {
            Sincronizando = true;
            MetodosDosEventos c = new MetodosDosEventos();
            c.EventThresholdReached += EventVerificarSincronizandoLabel;
            c.EventMudarCorLabelSincronia();
        }

        public async void EventChamaMensagemTesteReceberMensasgem(Object sender2, EventosDiversos e2)
        {
            _timer.Enabled = false;
            await TesteReceberMensagemDB();
            _timer.Enabled = true;
        }

        private void mudarlabel()
        {

            this.Invoke((MethodInvoker)delegate ()
            {
                try
                {
                    if (Sincronizando == true)
                    {
                        lalbeSincronia.Text = "Sincronizando";
                        lalbeSincronia.ForeColor = Color.Red;
                        //lalbeSincronia.Refresh();
                    }
                    else
                    {
                        lalbeSincronia.Text = "Sincronia";
                        lalbeSincronia.ForeColor = Color.Black;
                        //lalbeSincronia.Refresh();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            });
        }
        public void EventVerificarSincronizandoLabel(Object sender, EventosDiversos e)
        {
            mudarlabel();
        }
        public async void DefineNaoSincronizando()
        {
            Sincronizando = false;
            MetodosDosEventos c = new MetodosDosEventos();
            c.EventThresholdReached += EventVerificarSincronizandoLabel;
            c.EventMudarCorLabelSincronia();
        }
        private void TesteReceberDB_Click(object sender, EventArgs e)
        {
            TesteReceberMensagemDB();
        }
        public async void ChamaTesteReceberMensagemDB()
        {
            MetodosDosEventos c2 = new MetodosDosEventos();
            c2.EventThresholdReachedChamaMensagemDB += EventChamaMensagemTesteReceberMensasgem;
            c2.EventAtualizaTesteMensagemDB();
        }
        private async Task TesteReceberMensagemDB()
        {
            AlterarNumeroDeLinhasMsnDoDB();
            MensagenModel mensagenModel = new MensagenModel();
            var mensagens = mensagenModel.ListarMensagens(NumeroDeLinhasMsnDoDB);
            FormataTexBoxReceberMensagens2(mensagens);
        }

        private void LimarPanel_Click(object sender, EventArgs e)
        {
            panelDeMensagens.Controls.Clear();
        }

        private async void btnSincronizar_Click(object sender, EventArgs e)
        {
            try
            {
                DefineSincronizando();
                TesteReceberMensagemDB();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                DefineNaoSincronizando();
            }
        }

        public void SincronizarAutomaticamente()
        {
            _timer = new System.Timers.Timer();
            _timer.AutoReset = false;
            _timer.Interval = valorDoTempo();
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(ExecutarSincroniaAutomaticamente);
            _timer.Enabled = true;
        }
        private int valorDoTempo()
        {
            _timer.Enabled = false;
            Random novo = new Random();
            return novo.Next(1000, 10000);
        }
        private async void ExecutarSincroniaAutomaticamente(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                DefineSincronizando();

                SincronizadorCTRL sincronizador = new SincronizadorCTRL();
                await sincronizador.BotaoSincronizar();

                this.Invoke((MethodInvoker)delegate ()
                {
                    ChamaTesteReceberMensagemDB();

                });
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                DefineNaoSincronizando();
                _timer.Interval = valorDoTempo();
                _timer.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

}
