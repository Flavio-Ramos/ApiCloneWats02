using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace LeituraTabelaFipe
{
    public class ModeloFIPE
    {

        public string fipe_marca { get; set; }//"fipe_marca": "SSANGYONG",
        public string name { get; set; }//"name": "ACTYON 2.3 16V 150cv Aut.",
        public string marca { get; set; }//"marca": "SSANGYONG",
        public string key { get; set; }//"key": "actyon-4963",
        public int id { get; set; }//"id": "4963",
        public string fipe_name { get; set; }//"fipe_name": "ACTYON 2.3 16V 150cv Aut."

        public List<ModeloFIPE> PegarDados(int modelo)
        {
            //string modelo = "SMART";
            string arquivo = @"C:\Users\luiz\Desktop\NovaBase\BaseFipe\" + modelo + ".txt";
            string str1 = File.ReadAllText(arquivo);

            Console.WriteLine(modelo);
            List<ModeloFIPE> veiculosTabelaFipes1 = new JavaScriptSerializer().Deserialize<List<ModeloFIPE>>(str1);
            return veiculosTabelaFipes1;
        }
        public void LerModelo(List<ModeloFIPE> lista)
        {
            foreach (ModeloFIPE obj in lista)
            {
                Console.WriteLine("fipe_marca: " + obj.fipe_marca
                + "\nname: " + obj.name
                + "\nmarca: " + obj.marca
                + "\nKey: " + obj.key
                + "\nid: " + obj.id
                + "\nfipe_name" + obj.fipe_name);
                Console.WriteLine();

            }
        }
    }
}
