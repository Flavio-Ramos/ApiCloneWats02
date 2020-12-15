namespace WatssDesktop.SevircoSincronia
{
    public class MetodosDosEventos
    {
        public MetodosDosEventos()
        {

        }

        public void EventMudarCorLabelSincronia()
        {
            EventosDiversos args = new EventosDiversos();
            ExecutarEvento(args);
        }
        public void EventAtualizaTesteMensagemDB()
        {
            EventosDiversos args = new EventosDiversos();
            ExecutarEvento2(args);
        }

        protected virtual void ExecutarEvento(EventosDiversos e)
        {
            ThresholdReachedEventHandler handler = EventThresholdReached;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        protected virtual void ExecutarEvento2(EventosDiversos e)
        {
            ThresholdReachedEventHandler handler2 = EventThresholdReachedChamaMensagemDB;
            if(handler2 != null)
            {
                handler2(this, e);
            }
        }
        public event ThresholdReachedEventHandler EventThresholdReached;
        public event ThresholdReachedEventHandler EventThresholdReachedChamaMensagemDB;
    }
}
