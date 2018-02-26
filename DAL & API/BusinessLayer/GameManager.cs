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

        private Army GetArmyByID(int ID)
        {
            if (ID > 0)
                return new House(GetHouseById(ID));
            else if (ID < 0)
                return new WhiteWalker(GetWhiteWalkerById(ID));
            else
                return null;
        }
        private void EditArmy(Army a)
        {
            if (a.Id > 0)
                EditHouse(new HouseDTO((House)a));
            else if (a.Id < 0)
                EditWhiteWalker(new WhiteWalkerDTO((WhiteWalker)a));
        }
        public Boolean StartFight(FightDTO f)
        {
            if (f.WinningArmy == 0) // If not already fought
            {
                Random rand = new Random();
                House hAtt = new House(this.GetHouseById(f.AttArmy));
                Army hDef = GetArmyByID(f.DefArmy);

                int nbAtt = hAtt.NumberOfUnits;
                int nbDef = hDef.NumberOfUnits;

                Boolean battle = true;

                while (battle) // Go
                {
                    switch(rand.Next(0, 3))
                    {
                        case 0:
                            hAtt.UnitWins(rand);        // 1/3 Win
                            hDef.UnitLoses(rand);
                            break;
                        case 1:
                            hAtt.UnitDraw(rand);        // 1/3 Draw
                            hDef.UnitDraw(rand);
                            break;
                        case 2:
                            hAtt.UnitLoses(rand);       // 1/3 Lose
                            hDef.UnitWins(rand);
                            break;
                    }
                    if (hAtt.NumberOfUnits <= 5) // Attacking House loses
                    {
                        hAtt.LoseBattle(nbAtt - hAtt.NumberOfUnits, nbDef - hDef.NumberOfUnits);
                        hDef.WinBattle(nbDef - hDef.NumberOfUnits, nbAtt - hAtt.NumberOfUnits);
                        f.WinningArmy = f.DefArmy;
                        battle = false;
                    }
                    else if (hDef.NumberOfUnits <= 5) // Defending House loses
                    {
                        hDef.LoseBattle(nbDef - hDef.NumberOfUnits, nbAtt - hAtt.NumberOfUnits);
                        hAtt.WinBattle(nbAtt - hAtt.NumberOfUnits, nbDef - hDef.NumberOfUnits);
                        f.WinningArmy = f.AttArmy;
                        battle = false;
                    }

                }

                EditHouse(new HouseDTO(hAtt)); // Save the changes
                EditArmy(hDef);
                EditFight(f);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}