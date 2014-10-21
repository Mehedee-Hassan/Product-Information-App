using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product_Information_App.DLL.DAO;

namespace Product_Information_App.DLL.GATEWAY
{
    class ProductGateWay
    {
        private SqlConnection connection;
        private Product aProduct;
        public ProductGateWay()
        {
            connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        }



        public int Save(Product aProduct1)
        {
            int affected = 0;

            connection.Open();


            string query = string.Format("INSERT INTO t_Products VALUES('{0}' , '{1}' , '{2}')", 
                aProduct1.Code , aProduct1.Name , aProduct1.Quantity
                );

            SqlCommand command = new SqlCommand(query, connection);
            affected = command.ExecuteNonQuery();



            connection.Close();

            return affected;
        }

        public List<Product> GetAllProductFromDB()
        {



            connection.Open();
            
            List<Product> products = new List<Product>();
            string query = string.Format("SELECT * FROM t_Products");

            SqlCommand command = new SqlCommand(query, connection);


            SqlDataReader aReader = command.ExecuteReader();


            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    aProduct = new Product();
                    aProduct.Code = aReader.GetValue(1).ToString();
                    aProduct.Name = aReader.GetValue(2).ToString();
                    aProduct.Quantity = Convert.ToDouble(aReader.GetValue(3));


                    products.Add(aProduct);

                }
            }


            connection.Close();

            return products;
        }

        public int ProductCodeExists(string code)
        {

            int affected = 0;
            connection.Open();

             string query = string.Format("SELECT * FROM t_Products WHERE Code = '{0}'",code);

            SqlCommand command = new SqlCommand(query, connection);





            SqlDataReader aReader = command.ExecuteReader();
            if (aReader.HasRows)
            {
                affected = 1;
            }

            connection.Close();
            return affected;
            
        }

        public int ProductNameExists(string name)
        {
            int affected = 0;
            connection.Open();
            string query = string.Format("SELECT * FROM t_Products WHERE Name = '{0}'", name);

            SqlCommand command = new SqlCommand(query, connection);

            affected = command.ExecuteNonQuery();
            SqlDataReader aReader = command.ExecuteReader();
            
            if (aReader.HasRows)
            {
                affected = 1;
            }

            connection.Close();
            return affected;
        }
    }
}
