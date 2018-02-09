using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using EntitiesLayer;

namespace DataAccessLayer
{
    public class DalManager : AbstractDalManager
    {
        private static readonly Lazy<DalManager> lazy = new Lazy<DalManager>(() => new DalManager());
        private static readonly string _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\MADDXYZ\\Desktop\\temp_db.mdf;Integrated Security=True;Connect Timeout=30";
        public static DalManager Instance { get { return lazy.Value; } }
        DalManager() {}
            

/*        public List<Fight> GetFights()
        {
            List<Fight> fights = new List<Fight>();
            string sql = "SELECT * FROM Fights";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                using (SqlCommand sqlCmd = new SqlCommand(sql, sqlCon))
                {
                    SqlDataReader rdr = sqlCmd.ExecuteReader();
                    int id = rdr.GetInt32(0);
                    int chingId = rdr.GetInt32(1);
                    int chedId = rdr.GetInt32(2);
                    int winnId = rdr.GetInt32(3);
                    fights.Add(new Fight(id, chingId, chedId, winnId));
                };
            } ;
            return fights;
        }
        */
        public override List<House> GetHouses()
        {
            List<House> houses = new List<House>();
            string sql = "SELECT * FROM Houses";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                using (SqlCommand sqlCmd = new SqlCommand(sql, sqlCon))
                {
                    SqlDataReader rdr = sqlCmd.ExecuteReader();
                    int id = rdr.GetInt32(0);
                    string name = rdr.GetString(1);
                    int nOfU = rdr.GetInt32(2);
                    houses.Add(new House(id, name, nOfU));
                };
            };
            return houses;
        }
        /*public override House GetHouseById(int h)
        {
            return new House();
        }*/

        public void AddHouse(int id, string name, int nOfU)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand(
                        "INSERT INTO Houses VALUES(@Id, @Name, @NOfU)", con))
                    {
                        command.Parameters.Add(new SqlParameter("Id", id));
                        command.Parameters.Add(new SqlParameter("Name", name));
                        command.Parameters.Add(new SqlParameter("NOfU", nOfU));
                        command.ExecuteNonQuery();
                    }
                }
                catch
                {
                    Console.WriteLine("Count not insert.");
                }
            }
        }
    }
}
