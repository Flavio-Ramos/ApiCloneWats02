
namespace JogoDaVelha
{
    public class JogoBotoes
    {
        private bool Ativo = false;
        private Cores Cor = Cores.Vazio;
        private bool FezPar = false;


        public bool GetAtivo()
        {
            return this.Ativo;
        }

        public void SetAtivo(bool value)
        {
            this.Ativo = value;
        }

        public Cores GetCor()
        {
            return this.Cor;
        }

        public void SetCor(Cores value)
        {
            this.Cor = value;
        }

        public bool GetFezPar()
        {
            return this.FezPar;
        }

        public void SetFezPar(bool value)
        {
            this.FezPar = value;
        }
    }

    
}
