using System;
using System.Collections.Generic;
using System.IO;

namespace CancelamentoDeRPS
{
    class GerarSelecionarRegistros
    {

        private string NomeDoArquivoOrigin = "rps.csv";
        private string NomeDpArquivoFinal = "selecionarRegistros.txt";


        public void GerarTxt(string startOuttime, string endOuttime, int parkinglot, string caminho)
        {

            string arquivo = caminho + NomeDoArquivoOrigin;
            StreamReader sr = new StreamReader(arquivo);
            string line;
            List<string[]> listv = new List<string[]>();
            while ((line = sr.ReadLine()) != null)
            {
                string[] vt = line.Split(';');
                listv.Add(vt);
            }
            int cont = 0;
            string txtSelect = "";
            foreach (string[] obj in listv)
            {
                Console.WriteLine(obj[5] + "  " + obj[6]);
                Console.Write("select Id, Payment, InTime, OutTime, AmountPaid, InvoiceSeries, RpsNumber, UpdateReason from Logs where InvoiceSeries = '" + obj[5] + "' and RpsNumber = " + obj[6] + " and ParkingLotId = " + parkinglot);
                Console.WriteLine();
                cont++;

                txtSelect += "select Id, Payment, InTime, OutTime, AmountPaid, InvoiceSeries, RpsNumber, UpdateReason from Logs where InvoiceSeries = '" + obj[5] + "' and RpsNumber = " + obj[6] + " and ParkingLotId = " + parkinglot
                    + " and OutTime between '" + startOuttime + "' and '" + endOuttime + "' union all \n";
            }

            //Console.WriteLine(txtSelect);
            Console.WriteLine("total " + cont);
            //Salvar arquivo de select
            string arquivotxt = caminho + NomeDpArquivoFinal;
            File.WriteAllText(arquivotxt, txtSelect);
            //Salvar arquivo de select
        }
    }
}
