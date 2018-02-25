using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;
using EntitiesLayer;
using EntitiesLayer.DTOs;

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

        public List<WhiteWalkerDTO> GetWhiteWalkers()
        {
            return DalManager.Instance.GetWhiteWalkers();
        }
        public WhiteWalkerDTO GetWhiteWalkerById(int p_id)
        {
            return DalManager.Instance.GetWhiteWalkerById(p_id);
        }
        public void AddWhiteWalker(WhiteWalkerDTO ww)
        {
            DalManager.Instance.AddWhiteWalker(ww);
        }
        public void EditWhiteWalker(WhiteWalkerDTO ww)
        {
            DalManager.Instance.EditWhiteWalker(ww);
        }
        public void DeleteWhiteWalker(int id)
        {
            DalManager.Instance.DeleteWhiteWalker(id);
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

        public List<TerritoryDTO> GetTerritorys()
        {
            return DalManager.Instance.GetTerritorys();
        }
        public TerritoryDTO GetTerritoryById(int p_id)
        {
            return DalManager.Instance.GetTerritoryById(p_id);
        }
        public void AddTerritory(TerritoryDTO Territory)
        {
            DalManager.Instance.AddTerritory(Territory);
        }
        public void EditTerritory(TerritoryDTO Territory)
        {
            DalManager.Instance.EditTerritory(Territory);
        }
        public void DeleteTerritory(int id)
        {
            DalManager.Instance.DeleteTerritory(id);
        }

        public List<WarDTO> GetWars()
        {
            return DalManager.Instance.GetWars();
        }
        public WarDTO GetWarById(int p_id)
        {
            return DalManager.Instance.GetWarById(p_id);
        }
        public void AddWar(WarDTO War)
        {
            DalManager.Instance.AddWar(War);
        }
        /*public void EditWar(WarDTO War)
        {
            DalManager.Instance.EditWar(War);
        }*/
        public void DeleteWar(int id)
        {
            DalManager.Instance.DeleteWar(id);
        }

        public Boolean StartFight(FightDTO f)
        {
            Random rand = new Random();
            House hAtt = new House(this.GetHouseById(f.Army1));
            House hDef = new House(this.GetHouseById(f.Army2));
            int nbAtt = hAtt.NumberOfUnits;
            int nbDef = hAtt.NumberOfUnits;
            int res;
            Boolean battle = true;

            while (battle) // Fight
            {
                for (int i = 0; i < nbAtt && i < nbDef; i++)
                {
                    res = rand.Next(0, 2) * 2 - 1; // res = 1 or -1 (0or1 * 2 = 0or2 - 1 = -1or1)
                    nbAtt += res;
                    nbDef += res;
                }

                if ((nbAtt <= 0) || (nbAtt < hAtt.NumberOfUnits / 5 && nbAtt * 1.5 < nbDef)) // House 1 loses
                {
                    hAtt.WinBattle(hAtt.NumberOfUnits - nbAtt, hDef.NumberOfUnits - nbDef);
                    hDef.LoseBattle(hDef.NumberOfUnits - nbDef, hAtt.NumberOfUnits - nbAtt);
                    battle = false;
                }
                else if ((nbDef <= 0) || (nbDef < hDef.NumberOfUnits / 5 && nbDef * 1.5 < nbAtt)) // House 2 loses
                {
                    hDef.WinBattle(hDef.NumberOfUnits - nbDef, hAtt.NumberOfUnits - nbAtt);
                    hAtt.LoseBattle(hAtt.NumberOfUnits - nbAtt, hDef.NumberOfUnits - nbDef);
                    battle = false;
                }
            }
            return false;
        }
        private void EndBattle(HouseDTO Winner, HouseDTO Looser, int wUnits, int lUnits)
        {
            /*if (Winner.WhiteWalker)
            {
                Winner.NumberOfUnits += Looser.NumberOfUnits - lUnits; // Raise the Dead ! But no reputation bonus. No one volunteers for joining the army of the dead...
            }
            else
            {
                Winner.NumberOfUnits = wUnits + 10; // Reputation Bonus. Great victories means more people willing to enroll !
            }

            Looser.NumberOfUnits = lUnits - 10; // Reputation Malus. Dude, you're losing, it's sad, but nobody wants to be with you at the end.*/

        }

    }
}