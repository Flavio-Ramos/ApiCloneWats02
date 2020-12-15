using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace LeituraTabelaFipe
{
    public class FiltrarMarcas
    {

        public List<TodasMarcasUPark> PegarMarcasAtualizadasFipe()
        {
            string arquivo = @"C:\Users\luiz\Desktop\NovaBase\NovoJson\MarcasAtualizadasFipe.txt";
            string str1 = File.ReadAllText(arquivo);

            List<TodasMarcasUPark> veiculos = new JavaScriptSerializer().Deserialize<List<TodasMarcasUPark>>(str1);
            return veiculos;
        }

        public List<TodasMarcasUPark> PegarArquivoUPark()
        {
            string arquivo = @"C:\Users\luiz\Desktop\NovaBase\BaseUPark\TodasMarcas.txt";
            string str1 = File.ReadAllText(arquivo);

            List<TodasMarcasUPark> veiculos = new JavaScriptSerializer().Deserialize<List<TodasMarcasUPark>>(str1);
            return veiculos;
        }
        public List<string[]> PegarArquivoUParkPOS()
        {
            string arquivo = @"C:\Users\luiz\Desktop\NovaBase\BaseUPark\VCODE_MASTER.txt";
            //string str1 = File.ReadAllText(arquivo);
            //string[] vetor = str1.Split(',');
            StreamReader sr = new StreamReader(arquivo);

            string line;
            List<string[]> listv = new List<string[]>();
            while ((line = sr.ReadLine()) != null)
            {
                string[] vt = line.Split(',');
                listv.Add(vt);
            }
            //foreach(string[] obj in listv)
            //{
            //    Console.WriteLine("Id Modelo " + obj[0]);
            //    Console.WriteLine("Id Tipo " + obj[1]);
            //    Console.WriteLine("Id Marca " + obj[2]);
            //    Console.WriteLine("Nome Modelo " + obj[3]);
            //    Console.WriteLine();
            //}
            return listv;
        }
        public List<TodasMarcasUPark> PegarTestarArquivo()
        {
            string arquivo = @"C:\Users\luiz\Desktop\NovaBase\NovoJson\TestarArquivo.txt";
            string str1 = File.ReadAllText(arquivo);

            List<TodasMarcasUPark> veiculos = new JavaScriptSerializer().Deserialize<List<TodasMarcasUPark>>(str1);
            return veiculos;
        }


        public List<TodasMarcasUPark> PegarNovoArquivoUPark()
        {
            string arquivo = @"C:\Users\luiz\Desktop\NovaBase\NovoJson\NovoResource.txt";
            string str1 = File.ReadAllText(arquivo);

            List<TodasMarcasUPark> veiculos = new JavaScriptSerializer().Deserialize<List<TodasMarcasUPark>>(str1);
            return veiculos;
        }
        public List<TodasMarcasUPark> PegarNovoArquivoUParkFiltrado()
        {
            string arquivo = @"C:\Users\luiz\Desktop\NovaBase\NovoJson\MarcasAtualizadasFipe.txt";
            string str1 = File.ReadAllText(arquivo);

            List<TodasMarcasUPark> veiculos = new JavaScriptSerializer().Deserialize<List<TodasMarcasUPark>>(str1);
            return veiculos;
        }

        public List<ModeloFIPE> PegarArquivoFipe(string marca)
        {
            try
            {
                string arquivo2 = @"C:\Users\luiz\Desktop\NovaBase\BaseFipe\FipePorNomeMarcas\" + marca + ".txt";
                string str2 = File.ReadAllText(arquivo2);

                List<ModeloFIPE> veiculos2 = new JavaScriptSerializer().Deserialize<List<ModeloFIPE>>(str2);
                return veiculos2;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public void VerificarArquivosUParks(List<TodasMarcasUPark> lista)
        {
            foreach (TodasMarcasUPark obj in lista)
            {
                string marca = obj.BrandName;
                var fipe = PegarArquivoFipe(marca);
                if (fipe != null)
                {
                    int vehicleType = obj.Models[0].VehickeType;

                    foreach (ModeloFIPE obj2 in fipe)
                    {
                        foreach (Model obj3 in obj.Models)
                        {
                            if (obj3.ModelName == obj2.fipe_name)
                            {
                                obj2.fipe_name = null;
                                break;
                            }
                        }
                        if (obj2.fipe_name != null)
                        {
                            Model novo = ConvertEmUPark(obj2, vehicleType);
                            obj.Models.Add(novo);
                        }
                    }
                }
            }

            int maxId = this.PegarMaxIdMarca(lista) + 1;
            this.ColocarId(lista, maxId);
            //GravarArquivo(lista);//não organiza visualmente o json - NovoResource.txt
            GravarArquivo2(lista);//organiza como json - TestarArquivo.txt
        }

        public void VerificarArquivosUParksFiltrados()
        {
            var uparkOrig = PegarArquivoUPark();
            var uparkFilter = PegarNovoArquivoUParkFiltrado();
            foreach (TodasMarcasUPark objOrig in uparkOrig)
            {
                foreach (TodasMarcasUPark objFilter in uparkFilter)
                {
                    if ((objFilter.Models != null) && (objOrig.BrandName == objFilter.BrandName))
                    {
                        foreach (Model objModelFilter in objFilter.Models)
                        {
                            if (objModelFilter.ModelName != null)
                            {
                                foreach (Model objModelOrig in objOrig.Models)
                                {
                                    string orig = objModelOrig.ModelName.ToUpper();
                                    string fil = objModelFilter.ModelName.ToUpper();
                                    //if(orig==fil)
                                    if (VerificaSeIgual(orig, fil))
                                    {
                                        Console.WriteLine("--------------------------------\n"
                                            + objModelFilter.ExibirModelo());
                                        Console.WriteLine(objModelOrig.ExibirModelo()
                                            + "\n--------------------------------------\n");
                                        objModelFilter.ModelName = null;
                                        break;
                                    }
                                }

                                if (objModelFilter.ModelName != null)
                                {
                                    objModelFilter.VCode = 0;
                                    objOrig.Models.Add(objModelFilter);
                                }
                            }
                        }
                    }
                }
            }

            int maxId = this.PegarMaxIdMarca(uparkOrig) + 1;
            //this.ColocarId(uparkOrig, maxId);
            var listOder = OrdenarModelos(uparkOrig);
            //GravarArquivo(lista);//não organiza visualmente o json - NovoResource.txt
            GravarArquivo2(listOder);//organiza como json - TestarArquivo.txt
        }

        public void VeirificarInternamente()
        {
            var lista = PegarTestarArquivo();
            foreach (TodasMarcasUPark obj in lista)
            {
                for (int i = 0; i < obj.Models.Count; i++)
                {
                    for (int y = i + 1; y < obj.Models.Count - 1; y++)
                    {
                        if (obj.Models[y].ModelName != null)
                        {
                            string orig = obj.Models[i].ModelName.ToUpper();
                            string fil = obj.Models[y].ModelName.ToUpper();
                            //if(orig==fil)
                            if (VerificaSeIgual(orig, fil))
                            {
                                Console.WriteLine("--------------------------------\n"
                                    + obj.Models[i].ExibirModelo());
                                Console.WriteLine(obj.Models[y].ExibirModelo()
                                    + "\n--------------------------------------\n");
                                obj.Models[y].ModelName = null;
                            }
                        }

                    }
                    List<Model> models = new List<Model>();
                    foreach (Model obj3 in obj.Models)
                    {
                        if (obj3.ModelName != null)
                        {
                            models.Add(obj3);
                        }
                    }
                    obj.Models = models;
                }
            }

            GravarArquivo2(lista);//organiza como j
        }
        private bool VerificaSeIgual(string orig, string filt)
        {
            if (orig == filt)
            {
                return true;
            }

            orig = orig.Replace("-", "");
            orig = orig.Replace(" ", "");

            filt = filt.Replace("-", "");
            filt = filt.Replace(" ", "");

            orig = RemoverAcentuacao(orig);
            filt = RemoverAcentuacao(filt);
            if (filt == orig)
            {
                return true;
            }

            return false;
        }
        public string RemoverAcentuacao(string text)
        {
            return
                System.Web.HttpUtility.UrlDecode(
                    System.Web.HttpUtility.UrlEncode(
                        text, Encoding.GetEncoding("iso-8859-7")));
        }
        private Model ConvertEmUPark(ModeloFIPE obj2, int vType)
        {
            Model model = new Model();
            model.VCode = 0;
            model.VehickeType = vType;
            model.ModelName = obj2.fipe_name;
            model.BrandName = obj2.marca;

            return model;
        }


        public void GravarArquivo(List<TodasMarcasUPark> listaUpark)
        {
            string arquivo = @"C:\Users\luiz\Desktop\NovaBase\NovoJson\NovoResource.txt";
            var json = JsonConvert.SerializeObject(listaUpark);
            File.WriteAllText(arquivo, json);
        }

        public void GravarArquivo2(List<TodasMarcasUPark> listaUpark)
        {
            string arquivo = @"C:\Users\luiz\Desktop\NovaBase\NovoJson\TestarArquivo.txt";
            //var json = JsonConvert.SerializeObject(listaUpark, Formatting.Indented);
            var json = JsonConvert.SerializeObject(listaUpark);
            File.WriteAllText(arquivo, json);
        }
        public void GravarSoModelos(List<Model> listaUpark)
        {
            string arquivo = @"C:\Users\luiz\Desktop\NovaBase\NovoJson\TestarArquivo.txt";
            var json = JsonConvert.SerializeObject(listaUpark, Formatting.Indented);
            File.WriteAllText(arquivo, json);
        }
        
        public void GravarArquivoPOS()
        {
            List<string[]> listPos = PegarArquivoUParkPOS();
            List<TodasMarcasUPark> listaUpark = PegarTestarArquivo();
            string arquivo = @"C:\Users\luiz\Desktop\NovaBase\NovoJson\VCODEPOS.txt";
            List<string> newListPOS = new List<string>();
            
            int maxIdPos = PegaMaxIdMarcaPOS(listPos);
            
            foreach (TodasMarcasUPark obj in listaUpark)
            {
                string codPOS = PegaCodPOS(listPos,obj.BrandName);
                if(codPOS == "NãotemCodMarca")
                {
                    maxIdPos++;
                    codPOS = Convert.ToString(maxIdPos);
                }
                foreach(Model obj2 in obj.Models)
                {
                    string linha = obj2.VCode + "," + obj2.VehickeType + "," + codPOS + "," + obj.BrandName + " " + obj2.ModelName;
                    newListPOS.Add(linha);
                }
            }

            List<string[]> a = new List<string[]>();
            foreach(string obj in newListPOS)
            {
                string[] v = obj.Split(',');
                a.Add(v);
            }

            
            var lisPOSordenada = ordenarModelosPOS(a);

            foreach (string[] obj in lisPOSordenada)
            {
                string b = obj[3].ToUpper();
                obj[3] = RemoverAcentuacao(b);
            }

            string texto = "";

            foreach (string[] obj in lisPOSordenada)
            {
                texto += obj[0] + "," + obj[1] + "," + obj[2] + "," + obj[3] + "\n";
                //Console.WriteLine(obj[0] + "," + obj[1] + "," + obj[2] + "," + obj[3]);
            }
            File.WriteAllText(arquivo, texto);
        }

        public List<string[]> ordenarModelosPOS(List<string[]> lista)
        {
            var sorte = lista.OrderBy(x => x[3]).ToList();
            return sorte;
        }

        public int PegaMaxIdMarcaPOS(List<string[]> listPos)
        {
            int max = 0;
            foreach(string[] obj in listPos)
            {
                int id = int.Parse(obj[2]);
                if (max < id)
                {
                    max = id;
                }
            }
            return max;
        }

        private string PegaCodPOS(List<string[]> lista, string marcaUpark)
        {
            foreach (string[] pos in lista)
            {
                if (marcaUpark == pos[3])
                {
                    return pos[2];
                }
            }
            return "NãotemCodMarca";
        }

        public void GravarMarcasAtualizadasFipe(List<TodasMarcasUPark> listaUpark)
        {
            string arquivo = @"C:\Users\luiz\Desktop\NovaBase\NovoJson\MarcasAtualizadasFipe.txt";
            var json = JsonConvert.SerializeObject(listaUpark, Formatting.Indented);
            File.WriteAllText(arquivo, json);
        }
        public List<TodasMarcasUPark> ColocarId(List<TodasMarcasUPark> listaUpark, int novoId)
        {
            foreach (TodasMarcasUPark obj in listaUpark)
            {
                foreach (Model obj2 in obj.Models)
                {
                    if (obj2.VCode > 2156)
                    {
                        obj2.VCode = novoId;
                        novoId++;
                    }
                }
            }
            return listaUpark;
        }

        public int PegarMaxIdMarca(List<TodasMarcasUPark> veiculosUpark)
        {// 1 ao 181

            //List<TodasMarcasUPark> veiculosUpark = PegarArquivoUPark();

            int maxId = 0;
            int minId = 1000;
            foreach (TodasMarcasUPark obj in veiculosUpark)
            {
                foreach (Model obj2 in obj.Models)
                {
                    if (obj2.VCode >= maxId)
                    {
                        maxId = obj2.VCode;
                    }
                    if (obj2.VCode <= minId)
                    {
                        minId = obj2.VCode;
                    }
                }

            }

            Console.WriteLine("Marcas");
            Console.WriteLine("Maximo id = " + maxId + "\nminimo id " + minId);
            return maxId;
        }
        public void AlterarModelosParaMiusculo()
        {
            var lista = PegarNovoArquivoUPark();
            foreach (TodasMarcasUPark obj in lista)
            {
                List<Model> novosModelos = new List<Model>();
                foreach (Model obj2 in obj.Models)
                {
                    if (obj2.VCode > 2156)
                    {
                        string s = obj2.ModelName.ToUpper();
                        obj2.ModelName = s;
                        Console.WriteLine(obj2.ExibirModelo());
                        Console.WriteLine();
                        novosModelos.Add(obj2);
                    }
                    else
                    {
                        obj2.ModelName = null;
                    }
                }
                obj.Models = novosModelos;
            }
            GravarMarcasAtualizadasFipe(lista);
        }

        public List<TodasMarcasUPark> OrdenarModelos(List<TodasMarcasUPark> lista)
        {
            foreach (TodasMarcasUPark obj in lista)
            {
                IEnumerable<Model> modelosOdernados = ordenarModelos1(obj.Models);
                obj.Models = modelosOdernados.ToList<Model>();
            }
            //GravarMarcasAtualizadasFipe(lista);
            //GravarArquivo2(lista);

            //TodasMarcasUPark upark = new TodasMarcasUPark();
            //Console.WriteLine(upark.ExibirTodasMarcasNovas(lista));
            return lista;
        }

        public IEnumerable<Model> ordenarModelos1(List<Model> modelos)
        {
            //IEnumerable<Pet> query = pets.OrderBy(pet => pet.Name);
            IEnumerable<Model> query = modelos.OrderBy(modelo => modelo.ModelName);

            return query;
        }


        public void VerificarTamanhoString(List<TodasMarcasUPark> lista)
        {
            bool naotem = false;
            foreach (TodasMarcasUPark obj in lista)
            {
                foreach (Model obj2 in obj.Models)
                {
                    if (obj2.ModelName.Length > 35)
                    {
                        Console.WriteLine("Tamanho: " + obj2.ModelName.Length);
                        Console.WriteLine(obj2.ExibirModelo());
                        naotem = true;
                    }
                }
            }

            if (!naotem)
            {
                Console.WriteLine("Todas as strings são menore\ndo que o tamanho de 35");
            }
        }

        public void ListarModelosOrdenadosPorId()
        {
            var lista = PegarTestarArquivo();
            List<Model> models = new List<Model>();
            foreach (TodasMarcasUPark obj in lista)
            {
                foreach (Model obj2 in obj.Models)
                {
                    models.Add(obj2);
                }
            }

            for (int i = 0; i < models.Count; i++)
            {
                for (int y = i + 1; y <= models.Count - 1; y++)
                {
                    if (models[y].VCode < models[i].VCode)
                    {
                        Model aux = models[i];
                        models[i] = models[y];
                        models[y] = aux;
                    }
                }
            }
            GravarSoModelos(models);
            //int cont = 1;
            //foreach(Model obj in models)
            //{
            //    Console.WriteLine(cont +"   -   "+obj.VCode
            //        +"\n" + obj.ModelName + "\n");
            //    cont++;
            //}
        }

        public void VerSoMarcas()
        {
            var lista = PegarTestarArquivo();
            List<SoMarcas> ListasoMarcas = new List<SoMarcas>();
            foreach (TodasMarcasUPark obj in lista)
            {
                SoMarcas soMarcas = new SoMarcas();
                soMarcas.BrandName = obj.BrandName;
                foreach (Model obj2 in obj.Models)
                {
                    soMarcas.ModelName.Add(obj2.ModelName);
                }
                Console.WriteLine(soMarcas.Exibir());
                ListasoMarcas.Add(soMarcas);
            }
        }
    }
    class SoMarcas
    {
        public string BrandName { get; set; }//"BrandName": "ACURA",
        public List<string> ModelName { get; set; } = new List<string>();

        public string Exibir()
        {
            string s = "BrandName: " + BrandName;
            foreach (string obj in ModelName)
            {
                s += "\nModelName: " + obj;
            }
            s += "\n";

            return s;
        }

    }
}
