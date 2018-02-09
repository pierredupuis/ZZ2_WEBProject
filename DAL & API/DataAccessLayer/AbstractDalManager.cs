using System;
using System.Collections.Generic;
using System.Text;
using EntitiesLayer;

namespace DataAccessLayer
{
    public abstract class AbstractDalManager : IDal
    {
        abstract public List<House> GetHouses();
        /*abstract public House GetHouseById(int h);
        /*abstract public List<Fight> GetFights();
        abstract public Fight GetFightById(int f);
        abstract public List<Territory> GetTerritories();
        abstract public Territory GetTerritoryById(int t);
        abstract public List<Character> GetCharacters();
        abstract public Character GetCharacterById(int c);*/
        abstract public void AddHouse(int id, string name, int nOfU);
        /*abstract public void AddCharacter(Character c);
        abstract public void AddTerritory(Territory t);
        abstract public void AddFight(Fight f);
        abstract public void DeleteHouse(House h);
        abstract public void DeleteCharacter(Character c);
        abstract public void DeleteTerritory(Territory t);
        abstract public void DeleteFight(Fight f);
        abstract public void UpdateHouse(House h);
        abstract public void UpdateCharacter(Character c);
        abstract public void UpdateTerritory(Territory t);
        abstract public void UpdateFight(Fight f);*/


    }
}
