using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;

namespace LeituraTabelaFipe
{
    class Program
    {
        static void Main(string[] args)
        {
            //VeiculosTabelaFipe veiculosTabelaFipe = new VeiculosTabelaFipe();
            //veiculosTabelaFipe.LerArquivoVeiculosTabelaFipe();

            //VeiculosUPark vp = new VeiculosUPark();
            //vp.PegarMaxIdMarca();
            //vp.OrdernarTodosPorMarca();
            //vp.OrdernarMarca("AUDI");
            //vp.OrdenarTodasMarcas();//3161

            //VeiculosAudioTabelaFipe vatf = new VeiculosAudioTabelaFipe();
            //vatf.LerArquivo();

            //GerarNovoJson nj = new GerarNovoJson();
            //nj.LerArquivo();

            //VerificarUparkNaTabelaFipe verificarSeExiste = new VerificarUparkNaTabelaFipe();
            //verificarSeExiste.FiltrarDadosEntreUParkApiFipe();


            //ModeloFIPE mf = new ModeloFIPE();
            //mf.LerModelo();
            //AutomobilesModels am = new AutomobilesModels();
            //List<AutomobilesModels> dados =  am.PegarAutomobilesModelsOriginal();
            //List<AutomobilesModels> dados =  am.PegarAutomobilesModelsOriginal();
            //am.ExibirJson(dados,null);
            //am.ExibirJsonOrdenadoPorMarca(dados);

            //FiltrarModelos fm = new FiltrarModelos();
            //fm.IniciarVerificacao();
            //fm.PegarMaxIdMarca();
            //fm.PegarMaxIdModelo();

            FiltrarMarcas fm = new FiltrarMarcas();
            //fm.ListarModelosOrdenadosPorId();
            //fm.VerificarArquivosUParksFiltrados();
            //fm.VeirificarInternamente();
            //var b = fm.PegarTestarArquivo();
            //fm.PegarArquivoUParkPOS();

            fm.GravarArquivoPOS();


            //fm.GravarArquivo2(b);
            //var c = fm.ColocarId(b,2157);
            //fm.GravarArquivo2(c);

            //fm.AlterarModelosParaMiusculo();
            //fm.PegarMaxIdMarca();
            //var a = fm.PegarArquivoUPark();
            //fm.PegarMaxIdMarca(a);
            //fm.GravarArquivo2(a);
            //fm.VerificarArquivosUParks(a);
            //var b = fm.PegarMarcasAtualizadasFipe();
            //fm.OrdenarModelos(b);
            //fm.VerificarTamanhoString(b);
            //fm.VerSoMarcas();

            Console.WriteLine("Fim operação");
            Console.Read();
        }

    }

    class GerarNovoJson
    {
        public void LerArquivo()
        {
            string arquivo = @"C:\aulasCSharp\WebService\ApiCloneWattsApp\ApiCloneWats02\LeituraTabelaFipe\BasesJson\VeiculoAudioTabelaFipe.json";

            string str = File.ReadAllText(arquivo);

            List<VeiculosAudioTabelaFipe> veiculosAudioTabelaFipe = new JavaScriptSerializer().Deserialize<List<VeiculosAudioTabelaFipe>>(str);
            EscreverNoJson(veiculosAudioTabelaFipe);

        }

        public void EscreverNoJson(List<VeiculosAudioTabelaFipe> listaMarca)
        {
            //var caminhoArquivo2 = HostingEnvironment.MapPath(@"C:\aulasCSharp\WebService\ApiCloneWattsApp\ApiCloneWats02\LeituraTabelaFipe\BasesJson\novos\Teste.json");
            string caminhoOrigem = @"C:\aulasCSharp\WebService\ApiCloneWattsApp\ApiCloneWats02\LeituraTabelaFipe\BasesJson\novos\NovosModelos.json";
            List<VeiculosUPark> veiculosUParks = new List<VeiculosUPark>();
            int id = 3407;
            foreach (VeiculosAudioTabelaFipe obj in listaMarca)
            {
                VeiculosUPark novoVeiculo = new VeiculosUPark();
                novoVeiculo.ModelId = id;
                novoVeiculo.MakeId = 10;
                novoVeiculo.MakeName = "AUDI";
                novoVeiculo.ModelName = obj.fipe_name;

                veiculosUParks.Add(novoVeiculo);
                id++;
            }

            var json = JsonConvert.SerializeObject(veiculosUParks, Formatting.Indented);
            File.WriteAllText(caminhoOrigem, json);

        }
        public void EscreverNoJson2(List<VeiculosAudioTabelaFipe> listaMarca, int marcaid, string nomeMarca, int sequenciaIdMarca)
        {
            //var caminhoArquivo2 = HostingEnvironment.MapPath(@"C:\aulasCSharp\WebService\ApiCloneWattsApp\ApiCloneWats02\LeituraTabelaFipe\BasesJson\novos\Teste.json");
            string caminhoOrigem = @"C:\aulasCSharp\WebService\ApiCloneWattsApp\ApiCloneWats02\LeituraTabelaFipe\BasesJson\novos\NovosModelos.json";
            List<VeiculosUPark> veiculosUParks = new List<VeiculosUPark>();

            foreach (VeiculosAudioTabelaFipe obj in listaMarca)
            {
                VeiculosUPark novoVeiculo = new VeiculosUPark();
                novoVeiculo.ModelId = sequenciaIdMarca;
                novoVeiculo.MakeId = marcaid;
                novoVeiculo.MakeName = nomeMarca;
                novoVeiculo.ModelName = obj.fipe_name;

                veiculosUParks.Add(novoVeiculo);
                sequenciaIdMarca++;
            }

            var json = JsonConvert.SerializeObject(veiculosUParks, Formatting.Indented);
            File.WriteAllText(caminhoOrigem, json);

        }
    }

    class VeiculosTabelaFipe
    {
        public string name { get; set; }
        public string fipe_name { get; set; }
        public int order { get; set; }
        public string Key { get; set; }
        public int Id { get; set; }

        public void LerArquivoVeiculosTabelaFipe()
        {
            string arquivo = @"C:\aulasCSharp\WebService\ApiCloneWattsApp\ApiCloneWats02\LeituraTabelaFipe\BasesJson\VeiculoTabelaFipe.json";
            string str = File.ReadAllText(arquivo);

            List<VeiculosTabelaFipe> veiculosTabelaFipes = new JavaScriptSerializer().Deserialize<List<VeiculosTabelaFipe>>(str);

            foreach (VeiculosTabelaFipe obj in veiculosTabelaFipes)
            {
                if (obj.fipe_name == "Volvo")
                {
                    Console.WriteLine("Name: " + obj.name
                    + "\nFipe Name: " + obj.fipe_name
                    + "\nOrder: " + obj.order
                    + "\nKey: " + obj.Key
                    + "\nId: " + obj.Id
                    + "\n");
                }

            }
        }
    }

    class VeiculosUPark
    {
        public int ModelId { get; set; }
        public int MakeId { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }

        public void LerArquivo()
        {
            string arquivo = @"C:\aulasCSharp\WebService\ApiCloneWattsApp\ApiCloneWats02\LeituraTabelaFipe\BasesJson\VeiculosUPark.json";

            StreamReader sr = new StreamReader(arquivo);
            string str = File.ReadAllText(arquivo);
            List<VeiculosUPark> veiculosUpark = new JavaScriptSerializer().Deserialize<List<VeiculosUPark>>(str);

            foreach (VeiculosUPark obj in veiculosUpark)
            {
                if (obj.MakeId == 1)
                {
                    Console.WriteLine("Model: " + obj.ModelId
                    + "\nFipe MakeId: " + obj.MakeId
                    + "\nMakeName: " + obj.MakeName
                    + "\nModelName: " + obj.ModelName
                    + "\n");
                }
            }
        }
        public void PegarMaxIdMarca()
        {// 1 ao 181
            string arquivo = @"C:\aulasCSharp\WebService\ApiCloneWattsApp\ApiCloneWats02\LeituraTabelaFipe\BasesJson\VeiculosUPark.json";

            StreamReader sr = new StreamReader(arquivo);
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
        public void OrdernarTodosPorMarca()
        {// 1 ao 181
            string arquivo = @"C:\aulasCSharp\WebService\ApiCloneWattsApp\ApiCloneWats02\LeituraTabelaFipe\BasesJson\VeiculosUPark.json";
            string str = File.ReadAllText(arquivo);
            List<VeiculosUPark> veiculosUpark = new JavaScriptSerializer().Deserialize<List<VeiculosUPark>>(str);
            List<VeiculosUPark> veiculosParaOrdenar;
            for (int i = 1; i <= 181; i++)
            {
                veiculosParaOrdenar = new List<VeiculosUPark>();
                foreach (VeiculosUPark obj in veiculosUpark)
                {
                    if (obj.MakeId == i)
                    {
                        veiculosParaOrdenar.Add(obj);
                    }
                }

                if (veiculosParaOrdenar.Any())
                {
                    OrdernaMarcas(veiculosParaOrdenar, null);
                }
            }
        }

        public void OrdenarTodasMarcas()
        {
            string arquivo = @"C:\aulasCSharp\WebService\ApiCloneWattsApp\ApiCloneWats02\LeituraTabelaFipe\BasesJson\VeiculosUPark.json";
            string str = File.ReadAllText(arquivo);
            List<VeiculosUPark> veiculosUpark = new JavaScriptSerializer().Deserialize<List<VeiculosUPark>>(str);
            OrdernaMarcas(veiculosUpark, null);
        }

        private void OrdernaMarcas(List<VeiculosUPark> veiculosParaOrdenar, string marca)
        {
            if (marca != null)
            {
                List<VeiculosUPark> novaLista = new List<VeiculosUPark>();
                foreach (VeiculosUPark obj in veiculosParaOrdenar)
                {
                    if (obj.MakeName == marca)
                    {
                        novaLista.Add(obj);
                    }
                }
                veiculosParaOrdenar = novaLista;
            }
            for (int i = 0; i < veiculosParaOrdenar.Count; i++)
            {
                for (int y = 0; y < veiculosParaOrdenar.Count; y++)
                {
                    if (veiculosParaOrdenar[i].ModelId < veiculosParaOrdenar[y].ModelId)
                    {
                        VeiculosUPark obj = veiculosParaOrdenar[i];
                        veiculosParaOrdenar[i] = veiculosParaOrdenar[y];
                        veiculosParaOrdenar[y] = obj;
                    }
                }
            }
            Console.WriteLine("Total: " + veiculosParaOrdenar.Count + " veiculos\n");
            foreach (VeiculosUPark obj in veiculosParaOrdenar)
            {
                Console.WriteLine("Model: " + obj.ModelId
                  + "\nFipe MakeId: " + obj.MakeId
                  + "\nMakeName: " + obj.MakeName
                  + "\nModelName: " + obj.ModelName
                  + "\n");
            }
            Console.WriteLine("-----------------------------");
        }

        internal void OrdernarMarca(string marca)
        {
            string arquivo = @"C:\aulasCSharp\WebService\ApiCloneWattsApp\ApiCloneWats02\LeituraTabelaFipe\BasesJson\VeiculosUPark.json";
            string str = File.ReadAllText(arquivo);
            List<VeiculosUPark> veiculosUpark = new JavaScriptSerializer().Deserialize<List<VeiculosUPark>>(str);
            OrdernaMarcas(veiculosUpark, marca);
        }
    }

    class VeiculosAudioTabelaFipe
    {
        public string fipe_marca { get; set; }
        public string name { get; set; }
        public string Marca { get; set; }
        public string Key { get; set; }
        public int Id { get; set; }
        public string fipe_name { get; set; }

        public void LerArquivo()
        {
            string arquivo = @"C:\aulasCSharp\WebService\ApiCloneWattsApp\ApiCloneWats02\LeituraTabelaFipe\BasesJson\VeiculoAudioTabelaFipe.json";

            string str = File.ReadAllText(arquivo);

            List<VeiculosAudioTabelaFipe> veiculosAudioTabelaFipe = new JavaScriptSerializer().Deserialize<List<VeiculosAudioTabelaFipe>>(str);

            Console.WriteLine("Total de " + veiculosAudioTabelaFipe.Count + " veiculos\n");
            foreach (VeiculosAudioTabelaFipe obj in veiculosAudioTabelaFipe)
            {
                Console.WriteLine("FipeMarca: " + obj.fipe_marca
                    + "\nNome: " + obj.name
                    + "\nMarca: " + obj.Marca
                    + "\nKey: " + obj.Key
                    + "\nId: " + obj.Id
                    + "\nFipeName:" + obj.fipe_name
                    + "\n");
            }
        }
    }

    class VerificarUparkNaTabelaFipe
    {
        public string[] PegarDadoTxt()
        {
            string caminho = @"C:\aulasCSharp\WebService\ApiCloneWattsApp\ApiCloneWats02\LeituraTabelaFipe\BasesJson\ModelosUpark\ModelosUPark.txt";
            string[] lines = File.ReadAllLines(caminho);
            return lines;
        }

        public List<VeiculosAudioTabelaFipe> PegarDadosMarcasFipeJson()
        {
            string arquivo = @"C:\aulasCSharp\WebService\ApiCloneWattsApp\ApiCloneWats02\LeituraTabelaFipe\BasesJson\VeiculoAudioTabelaFipe.json";
            string str = File.ReadAllText(arquivo);
            List<VeiculosAudioTabelaFipe> veiculosAudioTabelaFipe = new JavaScriptSerializer().Deserialize<List<VeiculosAudioTabelaFipe>>(str);
            return veiculosAudioTabelaFipe;
        }

        public void FiltrarDadosEntreUParkApiFipe()
        {
            string[] strTxt = PegarDadoTxt();
            List<VeiculosAudioTabelaFipe> veiculosMarcaFipe = PegarDadosMarcasFipeJson();
            List<VeiculosAudioTabelaFipe> jaExisteNoUpark = new List<VeiculosAudioTabelaFipe>();

            for (int i = 0; i < strTxt.Length; i++)
            {
                if (strTxt[i] != null)
                {
                    for (int y = i; y < veiculosMarcaFipe.Count; y++)
                    {
                        if (veiculosMarcaFipe[y] != null)
                        {
                            if (strTxt[i] == veiculosMarcaFipe[y].fipe_name)
                            {
                                jaExisteNoUpark.Add(veiculosMarcaFipe[y]);
                                veiculosMarcaFipe[y] = null;
                                strTxt[i] = null;
                            }
                        }
                    }
                }

            }

            List<VeiculosAudioTabelaFipe> novalista = new List<VeiculosAudioTabelaFipe>();
            foreach (VeiculosAudioTabelaFipe obj in veiculosMarcaFipe)
            {
                if (obj != null)
                {
                    novalista.Add(obj);
                }
            }

            GerarNovoJson gerarNovoJson = new GerarNovoJson();
            gerarNovoJson.EscreverNoJson2(novalista, 164, "TROLLER", 8935);
            //Console.WriteLine("--Já existem no UPark--\n");
            //foreach (VeiculosAudioTabelaFipe obj in jaExisteNoUpark)
            //{
            //    Console.WriteLine("FipeMarca: " + obj.fipe_marca
            //        + "\nNome: " + obj.name
            //        + "\nMarca: " + obj.Marca
            //        + "\nKey: " + obj.Key
            //        + "\nId: " + obj.Id
            //        + "\nFipeName:" + obj.fipe_name
            //        + "\n");
            //}

            //int total = 0;
            //Console.WriteLine("\n--Não existem no UPark--\n");
            //foreach (VeiculosAudioTabelaFipe obj in viculosMarcaFipe)
            //{
            //    if(obj != null)
            //    {
            //        Console.WriteLine("FipeMarca: " + obj.fipe_marca
            //        + "\nNome: " + obj.name
            //        + "\nMarca: " + obj.Marca
            //        + "\nKey: " + obj.Key
            //        + "\nId: " + obj.Id
            //        + "\nFipeName:" + obj.fipe_name
            //        + "\n");
            //        total++;
            //    }
            //}

            //total = 0;
            //Console.WriteLine("\n--Veiculos do UPark Não encontrados--\n");
            //foreach (string obj in strTxt)
            //{
            //    if (obj != null)
            //    {
            //        Console.WriteLine(obj);
            //        total++;
            //    }
            //}

            //Console.WriteLine("Total veirificado Tabela Fipe" + viculosMarcaFipe.Count);
            //Console.WriteLine("Já existem "+ jaExisteNoUpark.Count);
            //Console.WriteLine("Não existem " +total);

        }
    }

}
