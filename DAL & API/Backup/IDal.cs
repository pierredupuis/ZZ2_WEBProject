using System;
using System.Collections.Generic;
using System.Text;
using EntitiesLayer;

namespace DataAccessLayer
{
    interface IDal
    {
        List<House> GetHouses();
        House GetHouseById(int h);
        /*List<Fight> GetFights();
        Fight GetFightById(int f);
        List<Territory> GetTerritories();
        Territory GetTerritoryById(int t);
        List<Character> GetCharacters();
        Character GetCharacterById(int c);
        void AddHouse(House h);
        void AddCharacter(Character c);
        void AddTerritory(Territory t);
        void AddFight(Fight f);
        void DeleteHouse(House h);
        void DeleteCharacter(Character c);
        void DeleteTerritory(Territory t);
        void DeleteFight(Fight f);
        void UpdateHouse(House h);
        void UpdateCharacter(Character c);
        void UpdateTerritory(Territory t);
        void UpdateFight(Fight f);*/
    }
}
