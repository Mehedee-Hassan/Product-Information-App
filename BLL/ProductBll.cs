using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product_Information_App.DLL.DAO;
using Product_Information_App.DLL.GATEWAY;

namespace Product_Information_App.BLL
{
    class ProductBll
    {

        private ProductGateWay aProductGateWay;
        private Product aProduct;
        public ProductBll()
        {
            
        }



       


        public string Save(Product aProduct1)
        {

            string msg  = "";

            aProductGateWay = new ProductGateWay();
            

            string productName = aProduct1.Name;
            string productCode = aProduct1.Code;
            bool isDone = true;

            if (productName.Length < 5 || productName.Length > 10)
            {
                msg+= "Sorry !! \nProduct Name Must Be \n In 5 To 10 Character Range.\n";
                isDone = false;
            }

            if (productCode.Length != 3)
            {
                msg += "Sorry !! \nCode Must Be 3 Character Long.";
                isDone = false;
            }


            if (isDone == false)
            {
                return msg;
            }



            bool isDone1 = true;
            
            if (aProductGateWay.ProductCodeExists(aProduct1.Code) > 0)
            {
                msg += "Sorry !!\n Product Code Exists.\n";
                isDone1 = false;
            }

            if (aProductGateWay.ProductNameExists(aProduct1.Name) > 0)
            {
                msg += "Sorry !!\n Product Name Exists.";
                isDone1 = false;
            }




            if (isDone1 == false)
            {
                return msg;
            }





            int affected  = aProductGateWay.Save(aProduct1);


            if (affected > 0)
            {
                msg += "Saved !!.";
            }
            else
            {
                msg += "Could Not Saved.";
            
            }


            return msg;
        }




        public List<Product> ShowInListView()
        {
            string msg = "";
            List<Product> products = new List<Product>();
            aProductGateWay = new ProductGateWay();

            products = aProductGateWay.GetAllProductFromDB();

            

            return products;
        }

        public double CalculateTotalQuantity(double totalQuantity, double newQuantity)
        {
            totalQuantity += newQuantity;

            return totalQuantity;
        }
    }
}
