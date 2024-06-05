using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Manager_with_framwork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString =
                "Data Source = srv2\\pupils; Initial Catalog = AdoNetUsers_326077351; Integrated Security = True";
  

            CategoryAccess ca = new CategoryAccess();
            ca.fillCategories(connectionString);
            ca.readCategory(connectionString);

            ProductAccess pa = new ProductAccess();
            pa.fillProducts(connectionString);
            pa.readProducts(connectionString);


        }
    }
}
