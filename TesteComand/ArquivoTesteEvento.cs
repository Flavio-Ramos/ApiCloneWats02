//using System;

//namespace TesteComand
//{
//    public class TesteEvento
//    {
//        public void MainTeste()
//        {
//            int valor = new Random().Next(10);
//            Counter c = new Counter(valor);
//            c.ThresholdReached += c_ThresholdReached;

//            Console.WriteLine("press 'a' key to increase total "+ valor);
//            while (Console.ReadKey(true).KeyChar == 'a')
//            {
//                Console.WriteLine("adding one");
//                c.Add(1);
//            }
//            Console.WriteLine("Fim do evento");
//            Console.Read();
//        }

//        static void c_ThresholdReached(object sender, ThresholdReachedEventArgs e)
//        {
//            Console.WriteLine("The threshold of {0} was reached at {1}.", e.Threshold, e.TimeReached);
//            //Environment.Exit(0);
//        }
//    }

//    public class Counter
//    {
//        public event EventHandler<ThresholdReachedEventArgs> ThresholdReached;
//        public int threshold;
//        private int total;
//        public Counter(int passedThreshold)
//        {
//            threshold = passedThreshold;
//        }

//        public void Add(int x)
//        {
//            total += x;
//            if (total >= threshold)
//            {
//                ThresholdReachedEventArgs args = new ThresholdReachedEventArgs();
//                args.Threshold = threshold;
//                args.TimeReached = DateTime.Now;
//                OnThresholdReached(args);
//            }
//        }

//        protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
//        {
//            EventHandler<ThresholdReachedEventArgs> handler = ThresholdReached;
//            if (handler != null)
//            {
//                handler(this, e);
//            }
//        }


//    }

//    //public class ThresholdReachedEventArgs : EventArgs
//    //{
//    //    public int Threshold { get; set; }
//    //    public DateTime TimeReached { get; set; }
//    //}

//    public class TesteUnico
//    {
//        public string Texto;
//        public event EventHandler Texto1;
//        //public event EventHandler ThresholdReached;
//        public int threshold;
//        public void Main()
//        {
//            Texto1.Invoke.OnThresholdReached;
//            Texto1 += c_ThresholdReached;

//            Console.WriteLine("press 'a' key to increase total " + 5);
//            while (Console.ReadKey(true).KeyChar == 'a')
//            {
//                //Texto1 args = new ThresholdReachedEventArgs();
//                //args.Threshold = threshold;
//                //args.TimeReached = DateTime.Now;
//                //OnThresholdReached(args);
//                Console.WriteLine("adding one");
//            }
//            Console.WriteLine("Fim do evento");
//            Console.Read();
//        }
        
//        protected virtual void OnThresholdReached(EventArgs e)
//        {
//            EventHandler<EventHandler> handler = Texto1;
//            if (handler != null)
//            {
//                handler(this, e);
//            }
//        }

//        static void c_ThresholdReached(object sender, EventHandler e)
//        {
//            Console.WriteLine("The threshold of was reached at .");
//        }
//    }
//}