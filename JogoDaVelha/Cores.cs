namespace JogoDaVelha
{
    public enum Cores : int
    {
        Vazio = 0,
        Amarelo = 1,
        Verde = 2,
        Vermelho = 3,
        Azul = 4,
        Branco = 5,
        Preto = 6,
        Marrom = 7,
        Rosa = 8
    }

    public class ClassEnumCores
    {
        public int ParseStringToInt(Cores cor)
        {
            int value;
            switch (cor)
            {
                case Cores.Amarelo:
                    value = 1;
                    break;
                case Cores.Verde:
                    value = 2;
                    break;
                case Cores.Vermelho:
                    value = 3;
                    break;
                case Cores.Azul:
                    value = 4;
                    break;
                case Cores.Branco:
                    value = 5;
                    break;
                case Cores.Preto:
                    value = 6;
                    break;
                case Cores.Marrom:
                    value = 7;
                    break;
                case Cores.Rosa:
                    value = 8;
                    break;
                default:
                    value = 0;
                    break;
            }
            return value;
        }

        public Cores ParseIntToString(int cor)
        {
            Cores value;
            switch (cor)
            {
                case 1:
                    value = Cores.Amarelo;
                    break;
                case 2:
                    value = Cores.Verde;
                    break;
                case 3:
                    value = Cores.Vermelho;
                    break;
                case 4:
                    value = Cores.Azul;
                    break;
                case 5:
                    value = Cores.Branco;
                    break;
                case 6:
                    value = Cores.Preto;
                    break;
                case 7:
                    value = Cores.Marrom;
                    break;
                case 8:
                    value = Cores.Rosa;
                    break;
                default:
                    value = Cores.Vazio;
                    break;
            }
            return value;
        }
    }
}
