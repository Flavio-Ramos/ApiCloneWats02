using System;
using System.Collections.Generic;
using System.IO;

namespace CancelamentoDeRPS
{
    class GerarSelectSql
    {
        private string NomeDoArquivo = "selectSql.csv";
        public void GerarQueryUpdate(string chamado, string startOuttime, string endOuttime, int parkinglot, string caminho, int tmpHoras, int tmpMinutos)
        {
            string arquivo = caminho + NomeDoArquivo;
            StreamReader sr2 = new StreamReader(arquivo);

            string line2;
            List<string[]> listv2 = new List<string[]>();
            while ((line2 = sr2.ReadLine()) != null)
            {
                string[] vt2 = line2.Split(';');
                listv2.Add(vt2);
            }
            int cont2 = 0;
            string txtSelect2 = "";
            var hora = tmpHoras;
            var minutos = tmpMinutos;
            var segundos = 00;
            var milesimos = 100;

            //var chamado = "3712 30/11/2020";
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
            string arquivotxt2 = caminho + "UpdateRps.txt";// @"C:\Users\luiz\Desktop\NovaBase\CancelaRPS\UpdateRps.txt";
            File.WriteAllText(arquivotxt2, txtSelect2);
            //Salvar arquivo de select

            Console.WriteLine(txtSelect2);
            Console.WriteLine("total " + cont2);




            Console.WriteLine("Fim da opeção!");
            Console.Read();
        }
    }
}
