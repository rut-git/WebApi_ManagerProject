using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager_with_framwork
{
    internal class ProductAccess
    {
        public int insertProduct(String connectionString)
        {
            String name, price, categoryId, description, imageUrl;

            Console.WriteLine("Insert product name");
            name = Console.ReadLine();
            Console.WriteLine("Insert product price");
            price = Console.ReadLine();
            Console.WriteLine("Insert category id");
            categoryId = Console.ReadLine();
            Console.WriteLine("Insert product description");
            description = Console.ReadLine();
            Console.WriteLine("Insert product imageUrl");
            imageUrl = Console.ReadLine();

            String query = "INSERT INTO Products(PRODUCT_NAME,PRICE,CATEGORY_ID,DESCRIPTION,IMAGE_URL)" + "VALUES(@name,@price,@categoryId,@description,@imageUrl)";

            using(SqlConnection cn=new SqlConnection(connectionString))
            using(SqlCommand cmd=new SqlCommand(query,cn))
            {
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 20).Value = name;
                cmd.Parameters.Add("@price", SqlDbType.Int).Value = price;
                cmd.Parameters.Add("@categoryId", SqlDbType.Int).Value = categoryId;
                cmd.Parameters.Add("@description", SqlDbType.VarChar, 50).Value = description;
                cmd.Parameters.Add("@imageUrl", SqlDbType.VarChar, 50).Value = imageUrl;


                cn.Open();
                int rowEffected = cmd.ExecuteNonQuery();
                cn.Close();

                return rowEffected;
            }
        }


        internal void readProducts(String connectionString)
        {
            String queryString = "select * from Products";
            
            using(SqlConnection connection= new SqlConnection(connectionString))
            {
                using(SqlCommand command= new SqlCommand(queryString,connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while(reader.Read())
                        {
                            Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
                                reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                        }
                        reader.Close();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.ReadLine();
                }
            }

        }


        public void fillProducts(String connectionString)
        {
            String flag = "y";

            while(flag=="y")
            {
                insertProduct(connectionString);
                Console.WriteLine("Would you like to continue? y/n");
                flag = Console.ReadLine();
            }
        }


    }
}
