using System;
using System.Data.SqlClient;

namespace WorkShop
{
    public struct CurrentUser
    {
        public int id;
        public string login;
    }

    public class DBConecshen
    {
        public SqlConnection con { get; set; }
        public DBConecshen()
        {
            con = new SqlConnection();
            string prPath = AppDomain.CurrentDomain.BaseDirectory;
            prPath = prPath.Substring(0, prPath.Length - 1);
            prPath = System.IO.Directory.GetParent(prPath).FullName;
            prPath = System.IO.Directory.GetParent(prPath).FullName;
            prPath = System.IO.Directory.GetParent(prPath).FullName;
            con.ConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= {prPath}\WorkShop.mdf;Integrated Security=True";
            con.Open();
        }
    }
}
