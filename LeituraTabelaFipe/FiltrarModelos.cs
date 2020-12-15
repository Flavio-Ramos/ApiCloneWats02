using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;

namespace LeituraTabelaFipe
{
    class FiltrarModelos
    {
        public string NovosModelos { get; set; } = @"C:\Users\luiz\Desktop\NovaBase\NovoJson\NovosModelos.txt";
        public string VerificarNoUpark { get; set; } = @"C:\Users\luiz\Desktop\NovaBase\NovoJson\VerificarNoUPark.txt";
        public string BaseUParkOrignial { get; set; } = @"C:\aulasCSharp\WebService\ApiCloneWattsApp\ApiCloneWats02\LeituraTabelaFipe\BasesJson\VeiculosUPark.json";

        public void IniciarVerificacao()
        {
            for(int i = 0; i <= 85; i++)
            {
                var listaFiltrada = CompararArquivos(i);
                var jason = ConvertParJsonUpark(listaFiltrada);
                ColocarMarcaId(jason);
            }
            ColocarIdModeloApartirDe(3162, NovosModelos);
            ColocarIdModeloApartirDe(1, VerificarNoUpark);
            
        }

        public List<ModeloFIPE> CompararArquivos(int valor)
        {
            ModeloFIPE fipe = new ModeloFIPE();
            var listaFipe = fipe.PegarDados(valor);

            AutomobilesModels upark = new AutomobilesModels();
            var listaPortal = upark.PegarDadoBase(valor);

            List<ModeloFIPE> jaExisteNoUpark = new List<ModeloFIPE>();

            for (int i = 0; i < listaPortal.Length; i++)
            {
                if (listaPortal[i] != null)
                {
                    for (int y = i; y < listaFipe.Count; y++)
                    {
                        if (listaFipe[y] != null)
                        {
                            if (listaPortal[i] == listaFipe[y].fipe_name)
                            {
                                jaExisteNoUpark.Add(listaFipe[y]);
                                listaFipe[y] = null;
                                listaPortal[i] = null;
                            }
                        }
                    }
                }

            }

            List<ModeloFIPE> novalista = new List<ModeloFIPE>();
            foreach (ModeloFIPE obj in listaFipe)
            {
                if (obj != null)
                {
                    novalista.Add(obj);
                }
            }
            return novalista;
        }

        public List<AutomobilesModels> ConvertParJsonUpark(List<ModeloFIPE> listaFipe)
        {
            List<AutomobilesModels> ListaUpark = new List<AutomobilesModels>();
            foreach (ModeloFIPE obj in listaFipe)
            {
                AutomobilesModels novoVeiculo = new AutomobilesModels();
                novoVeiculo.ModelId = "";
                novoVeiculo.MakeId = "";
                novoVeiculo.MakeName = obj.marca;
                novoVeiculo.ModelName = obj.fipe_name;

                ListaUpark.Add(novoVeiculo);
            }

            return ListaUpark;
        }

        public void ColocarMarcaId(List<AutomobilesModels> lista)
        {
            string id = "";
            AutomobilesModels upark = new AutomobilesModels();
            var baseOginal = upark.PegarAutomobilesModelsOriginal();

            foreach(AutomobilesModels obj in baseOginal)
            {
                if( lista[0].MakeName == obj.MakeName)
                {
                    id = obj.MakeId;
                    break;
                }
            }

            if(id == "")
            {
                SavarVeiculosSemCodigos(lista);
            }
            else
            {
                SavarVeiculosComCodigos(lista, id);
            }

        }


        public void SavarVeiculosComCodigos(List<AutomobilesModels> lista,string id)
        {
            foreach(AutomobilesModels obj in lista)
            {
                obj.MakeId = id;
            }


            List<AutomobilesModels> veiculosTabelaFipes1;
            string str1 = File.ReadAllText(NovosModelos);
            if (str1 == "")
            {
                veiculosTabelaFipes1 = new List<AutomobilesModels>();
            }
            else
            {
                veiculosTabelaFipes1 = new JavaScriptSerializer().Deserialize<List<AutomobilesModels>>(str1);
            }
            
            foreach (AutomobilesModels obj in lista)
            {
                veiculosTabelaFipes1.Add(obj);
            }

            var json = JsonConvert.SerializeObject(veiculosTabelaFipes1, Formatting.Indented);
            File.WriteAllText(NovosModelos, json);
        }

        public void SavarVeiculosSemCodigos(List<AutomobilesModels> lista)
        {
            //List<AutomobilesModels> veiculosUParks = new List<AutomobilesModels>();
            List<AutomobilesModels> veiculosUParks;
            string str1 = File.ReadAllText(VerificarNoUpark);
            if (str1 == "")
            {
                veiculosUParks = new List<AutomobilesModels>();
            }
            else
            {
                veiculosUParks = new JavaScriptSerializer().Deserialize<List<AutomobilesModels>>(str1);
            }

            foreach (AutomobilesModels obj in lista)
            {
                obj.MakeId = "FaltaCod" + obj.MakeName;
                veiculosUParks.Add(obj);
            }

            var json = JsonConvert.SerializeObject(veiculosUParks, Formatting.Indented);
            File.WriteAllText(VerificarNoUpark, json);
        }

        public void ColocarIdModeloApartirDe(int id,string arquivo)
        {
            string str2 = File.ReadAllText(arquivo);
            List<AutomobilesModels> lista = new JavaScriptSerializer().Deserialize<List<AutomobilesModels>>(str2);

            foreach(AutomobilesModels obj in lista)
            {
                string idStr = Convert.ToString(id);
                obj.ModelId = idStr;
                id++;
            }

            var json = JsonConvert.SerializeObject(lista, Formatting.Indented);
            File.WriteAllText(arquivo, json);
        }

        public void PegarMaxIdMarca()
        {// 1 ao 181
            
            string str = File.ReadAllText(BaseUParkOrignial);
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
            Console.WriteLine("Marcas");
            Console.WriteLine("Maximo id = " + maxId + "\nminimo id " + minId);
        }

        public void PegarMaxIdModelo()
        {// 1 ao 181

            string str = File.ReadAllText(BaseUParkOrignial);
            List<VeiculosUPark> veiculosUpark = new JavaScriptSerializer().Deserialize<List<VeiculosUPark>>(str);

            int maxId = veiculosUpark[0].ModelId;
            int minId = maxId;
            foreach (VeiculosUPark obj in veiculosUpark)
            {
                if (obj.ModelId > maxId)
                {
                    maxId = obj.ModelId;
                }
                if (obj.ModelId < minId)
                {
                    minId = obj.ModelId;
                }
            }
            Console.WriteLine("Modelos");
            Console.WriteLine("Maximo id = " + maxId + "\nminimo id " + minId);
        }
    }
}
