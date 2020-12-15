namespace TesteConexaoDbSql
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

        protected virtual void ExecutarEvento(EventosDiversos e)
        {
            ThresholdReachedEventHandler handler = EventThresholdReached;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event ThresholdReachedEventHandler EventThresholdReached;
    }
}
