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
            string startOuttime = "2020-12-10 12:33:00.000";
            string endOuttime = "2020-12-31 11:10:00.000";
            string chamado = "Chamado jeff05012021";
            string caminho = @"C:\ProjectVisualStudio\ApiCloneWats02\CancelamentoDeRPS\ArquivoGerados\";

            //GerarSelecionarRegistros gerarSelecionarRegistros = new GerarSelecionarRegistros();
            //gerarSelecionarRegistros.GerarTxt(startOuttime, endOuttime, parkinglot, caminho);

            GerarSelectSql gerarSelectSql = new GerarSelectSql();
            gerarSelectSql.GerarQueryUpdate(chamado, startOuttime, endOuttime, parkinglot, caminho,16,50);
        }
    }
}
