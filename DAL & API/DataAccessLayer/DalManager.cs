using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using EntitiesLayer;
using ApiGOT.Models;

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
            
        public List<HouseDTO> GetHouses()
        {
            return bddInterf.GetHouses();
        }
        public HouseDTO GetHouseById(int p_id)
        {
            return bddInterf.GetHouseById(p_id);
        }
        public void AddHouse(HouseDTO house)
        {
            bddInterf.AddHouse(house);
        }
        public void EditHouse(HouseDTO house)
        {
            bddInterf.EditHouse(house);
        }
        public void DeleteHouse(int id)
        {
            bddInterf.DeleteHouse(id);
        }

        public List<CharacterDTO> GetCharacters()
        {
            return bddInterf.GetCharacters();
        }
        public CharacterDTO GetCharacterById(int p_id)
        {
            return bddInterf.GetCharacterById(p_id);
        }
        public void AddCharacter(CharacterDTO Character)
        {
            bddInterf.AddCharacter(Character);
        }
        public void EditCharacter(CharacterDTO Character)
        {
            bddInterf.EditCharacter(Character);
        }
        public void DeleteCharacter(int id)
        {
            bddInterf.DeleteCharacter(id);
        }

        public List<FightDTO> GetFights()
        {
            return bddInterf.GetFights();
        }
        public FightDTO GetFightById(int p_id)
        {
            return bddInterf.GetFightById(p_id);
        }
        public void AddFight(FightDTO Fight)
        {
            bddInterf.AddFight(Fight);
        }
        public void EditFight(FightDTO Fight)
        {
            bddInterf.EditFight(Fight);
        }
        public void DeleteFight(int id)
        {
            bddInterf.DeleteFight(id);
        }
    }
}
