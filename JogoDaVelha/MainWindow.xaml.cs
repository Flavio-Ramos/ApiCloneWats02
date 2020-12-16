using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace JogoDaVelha
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int NumeroDeBotoes = 16;
        private JogoBotoes[] VetorCores = new JogoBotoes[NumeroDeBotoes];
        private int botoesAbertos = 0;
        private int[] duasCores = new int[2];
        public MainWindow()
        {
            InitializeComponent();
            geraCoresAleatorias();
            duasCores[0] = -1;
            duasCores[1] = -1;
        }

        private SolidColorBrush pegaCor(Cores valor)
        {
            ClassEnumCores Cec = new ClassEnumCores();
            int valorInt = Cec.ParseStringToInt(valor);
            SolidColorBrush cor;
            switch (valorInt)
            {
                case 1:
                    cor = Brushes.Red;
                    break;
                case 2:
                    cor = Brushes.Blue;
                    break;
                case 3:
                    cor = Brushes.Green;
                    break;
                case 4:
                    cor = Brushes.Yellow;
                    break;
                case 5:
                    cor = Brushes.White;
                    break;
                case 6:
                    cor = Brushes.Black;
                    break;
                case 7:
                    cor = Brushes.Brown;
                    break;
                case 8:
                    cor = Brushes.Magenta;
                    break;
                default:
                    cor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"));
                    break;
            }
            return cor;
        }

        private bool VerificaBotóesAtivos()
        {
            botoesAbertos++;
            if ((duasCores[0] != -1 && duasCores[1] != -1) || botoesAbertos > 2)
            {
                return true;
            }
            return false;
        }
        private void Button_Click_0(object sender, RoutedEventArgs e)
        {
            if (VetorCores[0].GetAtivo())
            {
                return;
            }

            if (VerificaBotóesAtivos())
            {
                CleanCor(false);
                botoesAbertos++;
            }

            var buttonCor = 0;
            SolidColorBrush cor = pegaCor(VetorCores[buttonCor].GetCor());
            Button btn0 = sender as Button;
            btn0.Background = btn0.Background == cor ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD")) : cor;
            testeTime(buttonCor);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (VetorCores[1].GetAtivo())
            {
                return;
            }

            if (VerificaBotóesAtivos())
            {
                CleanCor(false);
            }

            var buttonCor = 1;
            SolidColorBrush cor = pegaCor(VetorCores[buttonCor].GetCor());
            Button btn1 = sender as Button;
            btn1.Background = btn1.Background == cor ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD")) : cor;
            testeTime(buttonCor);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (VetorCores[2].GetAtivo())
            {
                return;
            }

            if (VerificaBotóesAtivos())
            {
                CleanCor(false);
            }

            var buttonCor = 2;
            SolidColorBrush cor = pegaCor(VetorCores[buttonCor].GetCor());
            Button btn2 = sender as Button;
            btn2.Background = btn2.Background == cor ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD")) : cor;
            testeTime(buttonCor);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (VetorCores[3].GetAtivo())
            {
                return;
            }

            if (VerificaBotóesAtivos())
            {
                CleanCor(false);
            }

            var buttonCor = 3;
            SolidColorBrush cor = pegaCor(VetorCores[buttonCor].GetCor());
            Button btn3 = sender as Button;
            btn3.Background = btn3.Background == cor ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD")) : cor;
            testeTime(buttonCor);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (VetorCores[5].GetAtivo())
            {
                return;
            }

            if (VerificaBotóesAtivos())
            {
                CleanCor(false);
            }

            var buttonCor = 5;
            SolidColorBrush cor = pegaCor(VetorCores[buttonCor].GetCor());
            Button btn5 = sender as Button;
            btn5.Background = btn5.Background == cor ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD")) : cor;
            testeTime(buttonCor);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (VetorCores[4].GetAtivo())
            {
                return;
            }

            if (VerificaBotóesAtivos())
            {
                CleanCor(false);
            }

            var buttonCor = 4;
            SolidColorBrush cor = pegaCor(VetorCores[buttonCor].GetCor());
            Button btn4 = sender as Button;
            btn4.Background = btn4.Background == cor ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD")) : cor;
            testeTime(buttonCor);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (VetorCores[6].GetAtivo())
            {
                return;
            }

            if (VerificaBotóesAtivos())
            {
                CleanCor(false);
            }

            var buttonCor = 6;
            SolidColorBrush cor = pegaCor(VetorCores[buttonCor].GetCor());
            Button btn6 = sender as Button;
            btn6.Background = btn6.Background == cor ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD")) : cor;
            testeTime(buttonCor);
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            if (VetorCores[7].GetAtivo())
            {
                return;
            }

            if (VerificaBotóesAtivos())
            {
                CleanCor(false);
            }

            var buttonCor = 7;
            SolidColorBrush cor = pegaCor(VetorCores[buttonCor].GetCor());
            Button btn7 = sender as Button;
            btn7.Background = btn7.Background == cor ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD")) : cor;
            testeTime(buttonCor);
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            if (VetorCores[8].GetAtivo())
            {
                return;
            }

            if (VerificaBotóesAtivos())
            {
                CleanCor(false);
            }

            var buttonCor = 8;
            SolidColorBrush cor = pegaCor(VetorCores[buttonCor].GetCor());
            Button btn8 = sender as Button;
            btn8.Background = btn8.Background == cor ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD")) : cor;
            testeTime(buttonCor);
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            if (VetorCores[9].GetAtivo())
            {
                return;
            }

            if (VerificaBotóesAtivos())
            {
                CleanCor(false);
            }

            var buttonCor = 9;
            SolidColorBrush cor = pegaCor(VetorCores[buttonCor].GetCor());
            Button btn9 = sender as Button;
            btn9.Background = btn9.Background == cor ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD")) : cor;
            testeTime(buttonCor);
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            if (VetorCores[10].GetAtivo())
            {
                return;
            }

            if (VerificaBotóesAtivos())
            {
                CleanCor(false);
            }

            var buttonCor = 10;
            SolidColorBrush cor = pegaCor(VetorCores[buttonCor].GetCor());
            Button btn10 = sender as Button;
            btn10.Background = btn10.Background == cor ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD")) : cor;
            testeTime(buttonCor);
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            if (VetorCores[11].GetAtivo())
            {
                return;
            }

            if (VerificaBotóesAtivos())
            {
                CleanCor(false);
            }

            var buttonCor = 11;
            SolidColorBrush cor = pegaCor(VetorCores[buttonCor].GetCor());
            Button btn11 = sender as Button;
            btn11.Background = btn11.Background == cor ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD")) : cor;
            testeTime(buttonCor);
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            if (VetorCores[12].GetAtivo())
            {
                return;
            }

            if (VerificaBotóesAtivos())
            {
                CleanCor(false);
            }

            var buttonCor = 12;
            SolidColorBrush cor = pegaCor(VetorCores[buttonCor].GetCor());
            Button btn12 = sender as Button;
            btn12.Background = btn12.Background == cor ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD")) : cor;
            testeTime(buttonCor);
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            if (VetorCores[13].GetAtivo())
            {
                return;
            }

            if (VerificaBotóesAtivos())
            {
                CleanCor(false);
            }

            var buttonCor = 13;
            SolidColorBrush cor = pegaCor(VetorCores[buttonCor].GetCor());
            Button btn13 = sender as Button;
            btn13.Background = btn13.Background == cor ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD")) : cor;
            testeTime(buttonCor);
        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            if (VetorCores[14].GetAtivo())
            {
                return;
            }

            if (VerificaBotóesAtivos())
            {
                CleanCor(false);
            }

            var buttonCor = 14;
            SolidColorBrush cor = pegaCor(VetorCores[buttonCor].GetCor());
            Button btn14= sender as Button;
            btn14.Background = btn14.Background == cor ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD")) : cor;
            testeTime(buttonCor);
        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            if (VetorCores[15].GetAtivo())
            {
                return;
            }

            if (VerificaBotóesAtivos())
            {
                CleanCor(false);
            }

            var buttonCor = 15;
            SolidColorBrush cor = pegaCor(VetorCores[buttonCor].GetCor());
            Button btn15 = sender as Button;
            btn15.Background = btn15.Background == cor ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD")) : cor;
            testeTime(buttonCor);
        }

        private void geraCoresAleatorias()
        {
            for (int i = 0; i < NumeroDeBotoes; i++)
            {
                VetorCores[i] = new JogoBotoes();
            }

            ClassEnumCores Conver = new ClassEnumCores();

            int quantidadeDeCores = (NumeroDeBotoes / 2) + 1;
            for (int i = 1; i < quantidadeDeCores; i++)
            {
                Random rndPosicao = new Random();
                int posicaoEsolhida = 0;

                while (posicaoEsolhida < 2)
                {
                    int novaPosicao = rndPosicao.Next(0, NumeroDeBotoes);
                    if (VetorCores[novaPosicao].GetCor() == Cores.Vazio)
                    {
                        VetorCores[novaPosicao].SetCor(Conver.ParseIntToString(i));
                        posicaoEsolhida++;
                    }
                }
            }
        }

        public void Button_Click_Embaralhar(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            btn.Background = Brushes.Black;
            Button_0.Background = Brushes.Black;
            geraCoresAleatorias();
            CleanCor(false);
            btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"));
        }

        private async Task CleanCor(bool automatic)
        {
            if (automatic)
            {
                await Task.Delay(500);
            }

            duasCores[0] = -1;
            duasCores[1] = -1;

            var cor2 = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"));
            ClassEnumCores cec = new ClassEnumCores();
            Button_0.Background = VetorCores[0].GetFezPar() == true ? pegaCor(VetorCores[0].GetCor()) : cor2;
            Button_1.Background = VetorCores[1].GetFezPar() == true ? pegaCor(VetorCores[1].GetCor()) : cor2;
            Button_2.Background = VetorCores[2].GetFezPar() == true ? pegaCor(VetorCores[2].GetCor()) : cor2;
            Button_3.Background = VetorCores[3].GetFezPar() == true ? pegaCor(VetorCores[3].GetCor()) : cor2;
            Button_4.Background = VetorCores[4].GetFezPar() == true ? pegaCor(VetorCores[4].GetCor()) : cor2;
            Button_5.Background = VetorCores[5].GetFezPar() == true ? pegaCor(VetorCores[5].GetCor()) : cor2;
            Button_6.Background = VetorCores[6].GetFezPar() == true ? pegaCor(VetorCores[6].GetCor()) : cor2;
            Button_7.Background = VetorCores[7].GetFezPar() == true ? pegaCor(VetorCores[7].GetCor()) : cor2;

            Button_8.Background = VetorCores[8].GetFezPar() == true ? pegaCor(VetorCores[8].GetCor()) : cor2;
            Button_9.Background = VetorCores[9].GetFezPar() == true ? pegaCor(VetorCores[9].GetCor()) : cor2;
            Button_10.Background = VetorCores[10].GetFezPar() == true ? pegaCor(VetorCores[10].GetCor()) : cor2;
            Button_11.Background = VetorCores[11].GetFezPar() == true ? pegaCor(VetorCores[11].GetCor()) : cor2;
            Button_12.Background = VetorCores[12].GetFezPar() == true ? pegaCor(VetorCores[12].GetCor()) : cor2;
            Button_13.Background = VetorCores[13].GetFezPar() == true ? pegaCor(VetorCores[13].GetCor()) : cor2;
            Button_14.Background = VetorCores[14].GetFezPar() == true ? pegaCor(VetorCores[14].GetCor()) : cor2;
            Button_15.Background = VetorCores[15].GetFezPar() == true ? pegaCor(VetorCores[15].GetCor()) : cor2;

            botoesAbertos = 0;
        }

        private async void testeTime(int numCor)
        {
            if(duasCores[0] == -1)
            {
                duasCores[0] = numCor;
                VetorCores[duasCores[0]].SetAtivo(true);
                return;
            }
            if(VetorCores[duasCores[0]].GetCor() == VetorCores[numCor].GetCor())
            {
                VetorCores[numCor].SetAtivo(true);
                VetorCores[duasCores[0]].SetFezPar(true);
                VetorCores[numCor].SetFezPar(true);
            }
            else
            {
                VetorCores[duasCores[0]].SetAtivo(false);
                VetorCores[numCor].SetAtivo(false);
            }

            await CleanCor(true);

        }
    }
}
