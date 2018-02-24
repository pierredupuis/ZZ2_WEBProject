using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;
using EntitiesLayer;
using ApiGOT.Models;

namespace BusinessLayer
{
    public class GameManager
    {
        private static readonly Lazy<GameManager> lazy = new Lazy<GameManager>(() => new GameManager());

        public static GameManager Instance { get { return lazy.Value; } }
        GameManager()
        {
            
        }


        /*public static List<Fight> GetFights()
        {
            return DalManager.Instance.GetFights();
        }*/
        public List<HouseDTO> GetHouses()
        {
            return DalManager.Instance.GetHouses();
        }
        public HouseDTO GetHouseById(int p_id)
        {
            return DalManager.Instance.GetHouseById(p_id);
        }
        public void AddHouse(HouseDTO house)
        {
            DalManager.Instance.AddHouse(house);
        }
        public void EditHouse(HouseDTO house)
        {
            DalManager.Instance.EditHouse(house);
        }
        public void DeleteHouse(int id)
        {
            DalManager.Instance.DeleteHouse(id);
        }

        public List<CharacterDTO> GetCharacters()
        {
            return DalManager.Instance.GetCharacters();
        }
        public CharacterDTO GetCharacterById(int p_id)
        {
            return DalManager.Instance.GetCharacterById(p_id);
        }
        public void AddCharacter(CharacterDTO Character)
        {
            DalManager.Instance.AddCharacter(Character);
        }
        public void EditCharacter(CharacterDTO Character)
        {
            DalManager.Instance.EditCharacter(Character);
        }
        public void DeleteCharacter(int id)
        {
            DalManager.Instance.DeleteCharacter(id);
        }

        public List<FightDTO> GetFights()
        {
            return DalManager.Instance.GetFights();
        }
        public FightDTO GetFightById(int p_id)
        {
            return DalManager.Instance.GetFightById(p_id);
        }
        public void AddFight(FightDTO Fight)
        {
            DalManager.Instance.AddFight(Fight);
        }
        public void EditFight(FightDTO Fight)
        {
            DalManager.Instance.EditFight(Fight);
        }
        public void DeleteFight(int id)
        {
            DalManager.Instance.DeleteFight(id);
        }
    }
}
