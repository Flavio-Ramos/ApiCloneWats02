using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;

namespace LeituraTabelaFipe
{
    class AutomobilesModels
    {
        public string ModelId { get; set; }
        public string MakeId { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }

        public string[] PegarDadoBase(int modelo) 
        {
            //string modelo = "SMART";
            string caminho = @"C:\Users\luiz\Desktop\NovaBase\BaseUPark\" + modelo+".txt";
            string[] lines = File.ReadAllLines(caminho);
            return lines;
        }

        public void ExibirJson(List<AutomobilesModels> lista,string marcas)
        {
            if (marcas == null)
            {
                foreach (AutomobilesModels obj in lista)
                {
                    Console.WriteLine("ModelId: " + obj.ModelId
                        + "\nMakeId: " + obj.MakeId
                        + "\nMakeName: " + obj.MakeName
                        + "\nModelName: " + obj.ModelName
                        );
                    Console.WriteLine();
                }
            }
            else
            {
                foreach (AutomobilesModels obj in lista)
                {
                    Console.WriteLine("\nMakeId: " + obj.MakeId
                        + "\nMakeName: " + obj.MakeName
                        );
                    Console.WriteLine();
                }
            }
            
        }

        public void ExibirJsonOrdenadoPorMarca (List<AutomobilesModels> lista)
        {
            
            for(int i = 0; i< lista.Count;i++)
            {
                for (int y = i+1; y<lista.Count-1;y++)
                {
                    if((lista[y] != null) && (lista[i] !=null))
                    {
                        if (lista[i].MakeId == lista[y].MakeId)
                        {
                            lista[y] = null;

                        }
                    }
                }
            }

            List<AutomobilesModels> listaMarcas = new List<AutomobilesModels>();
            foreach (AutomobilesModels obj in lista)
            {
                if (obj != null)
                {
                    listaMarcas.Add(obj);
                }
            }

            ExibirJson(listaMarcas,"Marcas");
        }

        public List<AutomobilesModels> PegarAutomobilesModelsOriginal()
        {
            string arquivo = @"C:\aulasCSharp\WebService\ApiCloneWattsApp\ApiCloneWats02\LeituraTabelaFipe\BasesJson\VeiculosUPark.json";
            string str = File.ReadAllText(arquivo);
            List<AutomobilesModels> veiculosUpark = new JavaScriptSerializer().Deserialize<List<AutomobilesModels>>(str);
            return veiculosUpark;
        }

        public void PegarMaxIdMarca()
        {// 1 ao 181
            string arquivo = @"C:\aulasCSharp\WebService\ApiCloneWattsApp\ApiCloneWats02\LeituraTabelaFipe\BasesJson\VeiculosUPark.json";

            string str = File.ReadAllText(arquivo);
            List<VeiculosUPark> veiculosUpark = new JavaScriptSerializer().Deserialize<List<VeiculosUPark>>(str);

            int maxId = veiculosUpark[0].MakeId;
            int minId = maxId;
            foreach (VeiculosUPark obj in veiculosUpark)
            {
                if (obj.MakeId > maxId)
                {
                    maxId = obj.MakeId;
                }
                if (obj.MakeId < minId)
                {
                    minId = obj.MakeId;
                }
            }
            Console.WriteLine("Maximo id = " + maxId + "\nminimo id " + minId);
        }
    }
}
