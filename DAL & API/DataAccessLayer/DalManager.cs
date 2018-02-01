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
        private static readonly Lazy<DalManager> lazy =
        new Lazy<DalManager>(() => new DalManager());
        private static readonly string _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\MADDXYZ\\Desktop\\temp_db.mdf;Integrated Security=True;Connect Timeout=30";
        public static DalManager Instance { get { return lazy.Value; } }
        DalManager() {}

        public void Connect()
        {
            SqlConnection sqlCon = new SqlConnection(_connectionString);

        }

        public override List<House> GetHouses()
        {
            return new List<House>();
        }
        public override House GetHouseById(int h)
        {
            return new House();
        }
    }
}
