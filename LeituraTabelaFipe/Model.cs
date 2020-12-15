using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeituraTabelaFipe
{
    public class Model
    {
        public int VCode { get; set; }//"VCode":9,
        public int VehickeType { get; set; }//"VehicleType":2,
        public string ModelName { get; set; }//"ModelName":"EL",
        public string BrandName { get; set; }//"BrandName":"ACURA"


        public string ExibirModelo()
        {
            string x = "VCode " + VCode
                + "\nVehickeType: " + VehickeType
                + "\nModelName: " + ModelName
                + "\nBrandName: " + BrandName
                +"\n";

            return x;
        }
    }
}
