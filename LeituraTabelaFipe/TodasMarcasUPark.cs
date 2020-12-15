using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeituraTabelaFipe
{
    public class TodasMarcasUPark
    {
        public string BrandName { get; set; }//"BrandName":"ACURA",
        public List<Model> Models { get; set; }//"Models":[

        public string ExibirTodasMarcasNovas(List<TodasMarcasUPark> lista)
        {
            string marcas = "";
            foreach (TodasMarcasUPark obj in lista)
            {
                marcas += "BrandName: " + obj.BrandName + "{";
                foreach (Model obj2 in obj.Models)
                {
                    if (obj2.VCode > 2156)
                    {
                        marcas += obj2.ExibirModelo() + "\n";
                        
                    }
                }
                marcas += "}\n";
            }
            return marcas;
        }
    }
}
