using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using EntitiesLayer;

namespace DataAccessLayer
{
    public class DalManager
    {
        private static readonly Lazy<DalManager> lazy = new Lazy<DalManager>(() => new DalManager());
        private IDal bddInterf;

        public static DalManager Instance { get { return lazy.Value; } }
        DalManager()
        {
            // Pour changer l'implémentation il suffit de modifier cette ligne
            bddInterf = new SqlServerDal();
        }
            

        /*public List<Fight> GetFights()
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
        public List<House> GetHouses()
        {
            return bddInterf.GetHouses();
        }
        /*public override House GetHouseById(int h)
        {
            return new House();
        }*/

        //public override void AddHouse(int id, string name, int nOfU)
        //{
        //    using (SqlConnection con = new SqlConnection(_connectionString))
        //    {
        //        con.Open();
        //        try
        //        {
        //            using (SqlCommand command = new SqlCommand(
        //                "INSERT INTO Houses VALUES(@Id, @Name, @NOfU)", con))
        //            {
        //                command.Parameters.Add(new SqlParameter("Id", id));
        //                command.Parameters.Add(new SqlParameter("Name", name));
        //                command.Parameters.Add(new SqlParameter("NOfU", nOfU));
        //                command.ExecuteNonQuery();
        //            }
        //        }
        //        catch
        //        {
        //            Console.WriteLine("Count not insert.");
        //        }
        //    }
        //}
    }
}
