using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Information_App.DLL.DAO
{
    class Product
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double Quantity  { get; set; }


        public Product(){}

        public Product(string name,string code,double quantity)
        {
            Name = name;
            Code = code;
            Quantity = quantity;
        }

    }
}
