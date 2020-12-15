namespace App.Domain.Enums
{
    public enum Status : int
    {
        Sincronizar = 0,
        Ok = 1,
        NaoSincronizado = 2,
        Perguntando = 3,
        Solicitando = 4,
        Enviando = 5
    }

    public class ClassEnumSatus
    {
        public int parseStringToInt(string status)
        {
            int value;
            switch (status)
            {
                case "Sincronizar":
                    value = 0;
                    break;
                case "Ok":
                    value = 1;
                    break;
                case "NaoSincronizado":
                    value = 2;
                    break;
                case "Perguntando":
                    value = 3;
                    break;
                case "Solicitando":
                    value = 4;
                    break;
                case "Enviando":
                    value = 5;
                    break;
                default:
                    value = 0;
                    break;
            }
            return value;
        }
    }
    
}
