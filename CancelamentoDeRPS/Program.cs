using System;
using System.Collections.Generic;
using System.IO;

namespace CancelamentoDeRPS
{
    class Program
    {
        static void Main(string[] args)
        {
            int parkinglot = 1052;
            string startOuttime = "2020-11-10 13:31:00.000";
            string endOuttime = "2020-11-28 12:45:00.000";


            //string arquivo = @"C:\Users\luiz\Desktop\NovaBase\CancelaRPS\rps.csv";
            //StreamReader sr = new StreamReader(arquivo);

            //string line;
            //List<string[]> listv = new List<string[]>();
            //while ((line = sr.ReadLine()) != null)
            //{
            //    string[] vt = line.Split(';');
            //    listv.Add(vt);
            //}
            //int cont = 0;
            //string txtSelect = "";
            //foreach (string[] obj in listv)
            //{
            //    Console.WriteLine(obj[5] + "  " + obj[6]);
            //    Console.Write("select Id, Payment, InTime, OutTime, AmountPaid, InvoiceSeries, RpsNumber, UpdateReason from Logs where InvoiceSeries = '" + obj[5] + "' and RpsNumber = " + obj[6] + " and ParkingLotId = " + parkinglot);
            //    Console.WriteLine();
            //    cont++;

            //    txtSelect += "select Id, Payment, InTime, OutTime, AmountPaid, InvoiceSeries, RpsNumber, UpdateReason from Logs where InvoiceSeries = '" + obj[5] + "' and RpsNumber = " + obj[6] + " and ParkingLotId = " + parkinglot
            //        + " and OutTime between '" + startOuttime + "' and '" + endOuttime + "' union all \n";
            //}

            ////Console.WriteLine(txtSelect);
            //Console.WriteLine("total " + cont);
            ////Salvar arquivo de select
            //string arquivotxt = @"C:\Users\luiz\Desktop\NovaBase\CancelaRPS\selecionarRegistros.txt";
            //File.WriteAllText(arquivotxt, txtSelect);
            ////Salvar arquivo de select



            //----------------Cria query para update--------------------------//
            string arquivoSelcCsv = @"C:\Users\luiz\Desktop\NovaBase\CancelaRPS\selectSql.csv";
            StreamReader sr2 = new StreamReader(arquivoSelcCsv);

            string line2;
            List<string[]> listv2 = new List<string[]>();
            while ((line2 = sr2.ReadLine()) != null)
            {
                string[] vt2 = line2.Split(';');
                listv2.Add(vt2);
            }
            int cont2 = 0;
            string txtSelect2 = "";
            var hora = 8;
            var minutos = 00;
            var segundos = 00;
            var milesimos = 100;

            var chamado = "3712 30/11/2020";
            foreach (string[] obj in listv2)
            {
                milesimos += milesimos < 650 ? 321 : -500;
                segundos += 17;
                if (segundos > 59)
                {
                    segundos = 13;
                    minutos++;
                    if (minutos == 59)
                    {
                        minutos = 11;
                        hora++;
                        if (hora == 19)
                        {
                            hora = 12;
                        }
                    }
                }
                string texHora = hora < 10 ? "0" + hora : "" + hora;
                string texMinutos = minutos < 10 ? "0" + minutos : "" + minutos;
                string texSegundo = segundos < 10 ? "0" + segundos : "" + segundos;
                //Console.WriteLine(obj[0]);
                cont2++;
                //txtSelect2 += "UPDATE Logs SET Payment = REPLACE(Payment ,',\"AmountPaid\":'+ convert(varchar(5),AmountPaid),',\"AmountPaid\":0.00'), AmountPaid = 0.00 ,UpdateReason = ' Chamado: 3518 2020-09-03 12:58:48.000' where Id = '" + obj[0] + "'\n";
                txtSelect2 += "UPDATE Logs SET Payment = REPLACE(Payment ,',\"AmountPaid\":'+ convert(varchar(5),AmountPaid),',\"AmountPaid\":0.00'), AmountPaid = 0.00 ,UpdateReason = ' Chamado: " + chamado + " " + texHora + ":" + texMinutos + ":" + texSegundo + "." + milesimos + "' where Id = '" + obj[0] + "'\n";

            }

            txtSelect2 += "\n\n UPDATE Logs SET  Payment = REPLACE(Payment, ',\"AmountPaid\"', '\"AmountPaid\"')  "
                       + " where Payment like '%,\"AmountPaid\"%' and ParkingLotId = " + parkinglot + " and OutTime between ' " + startOuttime + "' "
                       + "and '" + endOuttime + "'  \n";

            txtSelect2 += "\n UPDATE Logs SET  Payment = REPLACE(Payment, 'AmountPaid\":0.000,\"', 'AmountPaid\":0.00,\"') "
                          + " where Payment like '%AmountPaid\":0.000,\"%' and ParkingLotId = " + parkinglot
                          + " and OutTime between '" + startOuttime + "' and '" + endOuttime + "'";


            //Console.WriteLine(txtSelect2);
            //Console.WriteLine("total " + cont2);


            //Salvar arquivo de select
            string arquivotxt2 = @"C:\Users\luiz\Desktop\NovaBase\CancelaRPS\UpdateRps.txt";
            File.WriteAllText(arquivotxt2, txtSelect2);
            //Salvar arquivo de select

            Console.WriteLine(txtSelect2);
            Console.WriteLine("total " + cont2);




            Console.WriteLine("Fim da opeção!");
            Console.Read();
        }
    }
}
