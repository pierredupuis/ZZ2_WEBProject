using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EntitiesLayer;
using EntitiesLayer.DTOs;

namespace DataAccessLayer
{
    class SqlServerDal : IDal
    {
        //private static readonly string _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\MADDXYZ\\Desktop\\temp_db.mdf;Integrated Security=True;Connect Timeout=30";
        //private static readonly string _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\karroum\\Documents\\Projets\\ZZ2_WEBProject\\DAL & API\\temp_db.mdf\";Integrated Security=True;Connect Timeout=30";
        //private static readonly string _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\andumont7\\Source\\Repos\\ZZ2_WEBProject\\DAL & API\\temp_db.mdf\";Integrated Security=True;Connect Timeout=30";
        private static readonly string _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Jarvis\\Repositories\\ZZ2_WebProject\\DAL & API\\temp_db.mdf\";Integrated Security=True;Connect Timeout=30";

        public List<HouseDTO> GetHouses()
        {
            List<HouseDTO> houses = new List<HouseDTO>();
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
                        houses.Add(new HouseDTO(id, name, nOfU));
                    }
                };
                sqlCon.Close();
            };
            return houses;
        }
        public HouseDTO GetHouseById(int p_id)
        {
            HouseDTO house;

            string sql = "SELECT * FROM Houses WHERE HouseId = @id";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                using (SqlCommand sqlCmd = new SqlCommand(sql, sqlCon))
                {
                    sqlCmd.Parameters.Add("@id", SqlDbType.Int).Value = p_id;
                    SqlDataReader rdr = sqlCmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        int id = rdr.GetInt32(0);
                        string name = rdr.GetString(1);
                        int nOfU = rdr.GetInt32(2);
                        house = new HouseDTO(id, name, nOfU);
                    }
                    else
                    {
                        house = new HouseDTO();
                    }
                };
                sqlCon.Close();
            };
            return house;
        }

        public void AddHouse(HouseDTO house)
        {
            string sql = "INSERT INTO Houses(Name, NumberOfUnits) Values(@name, @nbOfUnits)";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                using (SqlCommand sqlCmd = new SqlCommand(sql, sqlCon))
                {
                    sqlCmd.Parameters.Add("@name", SqlDbType.VarChar).Value = house.Name;
                    sqlCmd.Parameters.Add("@nbOfUnits", SqlDbType.Int).Value = house.NumberOfUnits;

                    sqlCmd.ExecuteNonQuery();
                };
                sqlCon.Close();
            };
        }

        public void EditHouse(HouseDTO house)
        {
            string sql = "UPDATE Houses SET Name = @name, NumberOfUnits = @nbOfUnits WHERE HouseId = @id";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                using (SqlCommand sqlCmd = new SqlCommand(sql, sqlCon))
                {
                    sqlCmd.Parameters.Add("@name", SqlDbType.VarChar).Value = house.Name;
                    sqlCmd.Parameters.Add("@nbOfUnits", SqlDbType.Int).Value = house.NumberOfUnits;
                    sqlCmd.Parameters.Add("@id", SqlDbType.Int).Value = house.Id;

                    sqlCmd.ExecuteNonQuery();
                };
                sqlCon.Close();
            };
        }
        public void DeleteHouse(int id)
        {
            string sql = "DELETE FROM Houses WHERE HouseId = @id";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                using (SqlCommand sqlCmd = new SqlCommand(sql, sqlCon))
                {
                    sqlCmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;

                    sqlCmd.ExecuteNonQuery();
                };
                sqlCon.Close();
            };
        }


        public List<WhiteWalkerDTO> GetWhiteWalkers()
        {
            List<WhiteWalkerDTO> wws = new List<WhiteWalkerDTO>();
            string sql = "SELECT * FROM WhiteWalkers";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                using (SqlCommand sqlCmd = new SqlCommand(sql, sqlCon))
                {
                    SqlDataReader rdr = sqlCmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        int id = rdr.GetInt32(0);
                        int nOfU = rdr.GetInt32(1);
                        wws.Add(new WhiteWalkerDTO(id, nOfU));
                    }
                };
                sqlCon.Close();
            };
            return wws;
        }
        public WhiteWalkerDTO GetWhiteWalkerById(int p_id)
        {
            WhiteWalkerDTO ww;

            string sql = "SELECT * FROM WhiteWalkers WHERE WhiteWalkerId = @id";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                using (SqlCommand sqlCmd = new SqlCommand(sql, sqlCon))
                {
                    sqlCmd.Parameters.Add("@id", SqlDbType.Int).Value = p_id;
                    SqlDataReader rdr = sqlCmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        int id = rdr.GetInt32(0);
                        int nOfU = rdr.GetInt32(1);
                        ww = new WhiteWalkerDTO(id, nOfU);
                    }
                    else
                    {
                        ww = new WhiteWalkerDTO(-1);
                    }
                };
                sqlCon.Close();
            };
            return ww;
        }

        public void AddWhiteWalker(WhiteWalkerDTO ww)
        {
            string sql = "INSERT INTO WhiteWalkers(NumberOfUnits) Values(@nbOfUnits)";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                using (SqlCommand sqlCmd = new SqlCommand(sql, sqlCon))
                {
                    sqlCmd.Parameters.Add("@nbOfUnits", SqlDbType.Int).Value = ww.NumberOfUnits;

                    sqlCmd.ExecuteNonQuery();
                };
                sqlCon.Close();
            };
        }

        public void EditWhiteWalker(WhiteWalkerDTO ww)
        {
            string sql = "UPDATE WhiteWalkers SET NumberOfUnits = @nbOfUnits WHERE WhiteWalkerId = @id";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                using (SqlCommand sqlCmd = new SqlCommand(sql, sqlCon))
                {
                    sqlCmd.Parameters.Add("@nbOfUnits", SqlDbType.Int).Value = ww.NumberOfUnits;
                    sqlCmd.Parameters.Add("@id", SqlDbType.Int).Value = ww.Id;

                    sqlCmd.ExecuteNonQuery();
                };
                sqlCon.Close();
            };
        }
        public void DeleteWhiteWalker(int id)
        {
            string sql = "DELETE FROM WhiteWalkers WHERE WhiteWalkerId = @id";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                using (SqlCommand sqlCmd = new SqlCommand(sql, sqlCon))
                {
                    sqlCmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;

                    sqlCmd.ExecuteNonQuery();
                };
                sqlCon.Close();
            };
        }


        public List<CharacterDTO> GetCharacters()
        {
            List<CharacterDTO> characters = new List<CharacterDTO>();
            string sql = "SELECT * FROM Characters";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                using (SqlCommand sqlCmd = new SqlCommand(sql, sqlCon))
                {
                    SqlDataReader rdr = sqlCmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        int id = rdr.GetInt32(0);
                        int bravoury = rdr.GetInt32(1);
                        int crazyness = rdr.GetInt32(2);
                        string lastName = rdr.GetString(3);
                        string firstName = rdr.GetString(4);
                        int pv = rdr.GetInt32(5);
                        int pf = rdr.GetInt32(6);
                        int houseId = rdr.GetInt32(7);
                        characters.Add(new CharacterDTO(id, bravoury, crazyness, firstName, lastName, pv, pf, houseId));
                    }
                };
                sqlCon.Close();
            };
            return characters;
        }
        public CharacterDTO GetCharacterById(int p_id)
        {
            CharacterDTO character;

            string sql = "SELECT * FROM Characters WHERE CharacterId = @id";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                using (SqlCommand sqlCmd = new SqlCommand(sql, sqlCon))
                {
                    sqlCmd.Parameters.Add("@id", SqlDbType.Int).Value = p_id;
                    SqlDataReader rdr = sqlCmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        int id = rdr.GetInt32(0);
                        int bravoury = rdr.GetInt32(1);
                        int crazyness = rdr.GetInt32(2);
                        string lastName = rdr.GetString(3);
                        string firstName = rdr.GetString(4);
                        int pv = rdr.GetInt32(5);
                        int pf = rdr.GetInt32(6);
                        int houseId = rdr.GetInt32(7);
                        character = new CharacterDTO(id, bravoury, crazyness, firstName, lastName, pv, pf, houseId);
                    }
                    else
                    {
                        character = new CharacterDTO();
                    }
                };
                sqlCon.Close();
            };
            return character;
        }

        public void AddCharacter(CharacterDTO c)
        {
            string sql = "INSERT INTO Characters(Bravoury, Crazyness, LastName, FirstName, Pv, Pf, HouseId) Values(@Bravoury, @Crazyness, @LastName, @FirstName, @Pv, @Pf, @HouseId)";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                using (SqlCommand sqlCmd = new SqlCommand(sql, sqlCon))
                {
                    sqlCmd.Parameters.Add("@Bravoury", SqlDbType.Int).Value = c.Bravoury;
                    sqlCmd.Parameters.Add("@Crazyness", SqlDbType.Int).Value = c.Crazyness;
                    sqlCmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = c.LastName;
                    sqlCmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = c.FirstName;
                    sqlCmd.Parameters.Add("@Pv", SqlDbType.Int).Value = c.Pv;
                    sqlCmd.Parameters.Add("@Pf", SqlDbType.Int).Value = c.Pf;
                    sqlCmd.Parameters.Add("@HouseId", SqlDbType.Int).Value = c.HouseId;

                    sqlCmd.ExecuteNonQuery();
                };
                sqlCon.Close();
            };
        }

        public void EditCharacter(CharacterDTO c)
        {
            string sql = "UPDATE Characters SET Bravoury = @Bravoury, Crazyness = @Crazyness, LastName = @LastName, FirstName = @FirstName, Pv = @Pv, Pf = @Pf, HouseId = @HouseId WHERE CharacterId = @id";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                using (SqlCommand sqlCmd = new SqlCommand(sql, sqlCon))
                {
                    sqlCmd.Parameters.Add("@Bravoury", SqlDbType.VarChar).Value = c.Bravoury;
                    sqlCmd.Parameters.Add("@Crazyness", SqlDbType.Int).Value = c.Crazyness;
                    sqlCmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = c.LastName;
                    sqlCmd.Parameters.Add("@FirstName", SqlDbType.Int).Value = c.FirstName;
                    sqlCmd.Parameters.Add("@Pv", SqlDbType.VarChar).Value = c.Pv;
                    sqlCmd.Parameters.Add("@Pf", SqlDbType.Int).Value = c.Pf;
                    sqlCmd.Parameters.Add("@HouseId", SqlDbType.VarChar).Value = c.HouseId;

                    sqlCmd.ExecuteNonQuery();
                };
                sqlCon.Close();
            };
        }
        public void DeleteCharacter(int id)
        {
            string sql = "DELETE FROM Characters WHERE CharacterId = @id";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                using (SqlCommand sqlCmd = new SqlCommand(sql, sqlCon))
                {
                    sqlCmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;

                    sqlCmd.ExecuteNonQuery();
                };
                sqlCon.Close();
            };
        }

        public List<FightDTO> GetFights()
        {
            List<FightDTO> fights = new List<FightDTO>();
            string sql = "SELECT * FROM Fights";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                using (SqlCommand sqlCmd = new SqlCommand(sql, sqlCon))
                {
                    SqlDataReader rdr = sqlCmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        int id = rdr.GetInt32(0);
                        int challenging = rdr.GetInt32(1);
                        int challenged = rdr.GetInt32(2);
                        int winning = rdr.GetInt32(3);
                        fights.Add(new FightDTO(id, challenging, challenged, winning));
                    }
                };
                sqlCon.Close();
            };
            return fights;
        }
        public FightDTO GetFightById(int p_id)
        {
            FightDTO fight;

            string sql = "SELECT * FROM Fights WHERE FightId = @id";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                using (SqlCommand sqlCmd = new SqlCommand(sql, sqlCon))
                {
                    sqlCmd.Parameters.Add("@id", SqlDbType.Int).Value = p_id;
                    SqlDataReader rdr = sqlCmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        int id = rdr.GetInt32(0);
                        int challenging = rdr.GetInt32(1);
                        int challenged = rdr.GetInt32(2);
                        int winning = rdr.GetInt32(3);
                        fight = new FightDTO(id, challenging, challenged, winning);
                    }
                    else
                    {
                        fight = new FightDTO();
                    }
                };
                sqlCon.Close();
            };
            return fight;
        }

        public void AddFight(FightDTO f)
        {
            string sql = "INSERT INTO Fights(ChallengingHouseId, ChallengedHouseId, WinningHouseId) Values(@ChallengingHouseId, @ChallengedHouseId, @WinningHouseId)";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                using (SqlCommand sqlCmd = new SqlCommand(sql, sqlCon))
                {
                    sqlCmd.Parameters.Add("@ChallengingHouseId", SqlDbType.VarChar).Value = f.HouseChallenging;
                    sqlCmd.Parameters.Add("@ChallengedHouseId", SqlDbType.Int).Value = f.HouseChallenged;
                    sqlCmd.Parameters.Add("@WinningHouseId", SqlDbType.VarChar).Value = f.WinningHouse;

                    sqlCmd.ExecuteNonQuery();
                };
                sqlCon.Close();
            };
        }

        public void EditFight(FightDTO f)
        {
            string sql = "UPDATE Fights SET ChallengingHouseId = @ChallengingHouseId, ChallengedHouseId = @ChallengedHouseId, WinningHouseId = @WinningHouseId WHERE FightId = @id";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                using (SqlCommand sqlCmd = new SqlCommand(sql, sqlCon))
                {
                    sqlCmd.Parameters.Add("@ChallengingHouseId", SqlDbType.VarChar).Value = f.HouseChallenging;
                    sqlCmd.Parameters.Add("@ChallengedHouseId", SqlDbType.Int).Value = f.HouseChallenged;
                    sqlCmd.Parameters.Add("@WinningHouseId", SqlDbType.VarChar).Value = f.WinningHouse;
                    sqlCmd.Parameters.Add("@id", SqlDbType.VarChar).Value = f.Id;


                    sqlCmd.ExecuteNonQuery();
                };
                sqlCon.Close();
            };
        }
        public void DeleteFight(int id)
        {
            string sql = "DELETE FROM Fights WHERE FightId = @id";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                using (SqlCommand sqlCmd = new SqlCommand(sql, sqlCon))
                {
                    sqlCmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;

                    sqlCmd.ExecuteNonQuery();
                };
                sqlCon.Close();
            };
        }
    }
}
