using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using EntitiesLayer;

namespace DataAccessLayer
{
    class DalManager : AbstractDalManager
    {
        private static readonly Lazy<DalManager> lazy = new Lazy<DalManager>(() => new DalManager());
        private static readonly string _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\MADDXYZ\\Desktop\\temp_db.mdf;Integrated Security=True;Connect Timeout=30";
        public static DalManager Instance { get { return lazy.Value; } }
        DalManager() {}
            

        public List<Fight> GetFights()
        {
            List<Fight> fights = new List<Fight>();
            string sql = "SELECT * FROM Fights";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                using (SqlCommand sqlCmd = new SqlCommand(sql, sqlCon))
                {
                    sqlReader rdr = sqlCmd.ExecuteReader();
                    /*int id = rdr.GetInt32(0);*/
                    int chingId = rdr.GetInt32(1);
                    int chedId = rdr.GetInt32(2);
                    int winnId = rdr.GetInt32(3);
                    fights.Add(new Fight() { houseChallenged = chingId, houseChallenging = chedId, winningHouse = winnId });
                };
            } ;
            return fights;
        }

        public override List<House> GetHouses()
        {
            List<House> fights = new List<House>();
            string sql = "SELECT * FROM Houses";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                using (SqlCommand sqlCmd = new SqlCommand(sql, sqlCon))
                {
                    sqlReader rdr = sqlCmd.ExecuteReader();
                    int id = rdr.GetInt32(0);
                    string name = rdr.GetString(1);
                    int nOfU = rdr.GetInt32(2);
                    House h = new House();

                };
            };
            return fights;
        }
        public override House GetHouseById(int h)
        {
            return new House();
        }
    }
}
