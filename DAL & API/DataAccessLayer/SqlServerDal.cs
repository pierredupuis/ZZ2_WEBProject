using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EntitiesLayer;

namespace DataAccessLayer
{
    class SqlServerDal : IDal
    {
        //private static readonly string _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\MADDXYZ\\Desktop\\temp_db.mdf;Integrated Security=True;Connect Timeout=30";
        private static readonly string _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\karroum\\Documents\\Projets\\ZZ2_WEBProject\\DAL & API\\temp_db.mdf\";Integrated Security=True;Connect Timeout=30";
        //private static readonly string _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\andumont7\\Source\\Repos\\ZZ2_WEBProject\\DAL & API\\temp_db.mdf\";Integrated Security=True;Connect Timeout=30";
        //private static readonly string _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Jarvis\\Repositories\\ZZ2_WebProject\\DAL & API\\temp_db.mdf\";Integrated Security=True;Connect Timeout=30";

        public List<House> GetHouses()
        {
            List<House> houses = new List<House>();
            string sql = "SELECT * FROM Houses";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                using (SqlCommand sqlCmd = new SqlCommand(sql, sqlCon))
                {
                    SqlDataReader rdr = sqlCmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        int id = rdr.GetInt32(0);
                        string name = rdr.GetString(1);
                        int nOfU = rdr.GetInt32(2);
                        houses.Add(new House(id, name, nOfU));
                    }
                };
                sqlCon.Close();
            };
            return houses;
        }
    }
}
