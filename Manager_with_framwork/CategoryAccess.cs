using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Manager_with_framwork
{
    internal class CategoryAccess
    {

        public int insertCategory(string connectionString)
        {
            String name;
            Console.WriteLine("insert category name");
            name = Console.ReadLine();

            String query = "INSERT INTO Categories(CATEGORY_NAME)" + "VALUES(@name)";


            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd=new SqlCommand(query,cn))
            {
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 20).Value = name;

                cn.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                cn.Close();

                return rowAffected;

            }
        }

        internal void readCategory(String connectionString)
        {


            String queryString = "select * from Categories";

            using(SqlConnection connection =new SqlConnection(connectionString))
            {
                using(SqlCommand command= new SqlCommand(queryString,connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while(reader.Read())
                        {
                            Console.WriteLine("\t{0}\t{1}",
                                reader[0], reader[1]);
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
         public void fillCategories(String connectionString)
         {
            String flag = "y";

            while(flag=="y")
            {
                insertCategory(connectionString);
                Console.WriteLine("Would you like to continue? y/n");
                flag = Console.ReadLine();
            }
         }      
    }
}
