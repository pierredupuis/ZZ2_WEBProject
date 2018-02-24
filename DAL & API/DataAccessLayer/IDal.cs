using System;
using System.Collections.Generic;
using System.Text;
using EntitiesLayer;

namespace DataAccessLayer
{
    interface IDal
    {
        /* Houses */
        List<House> GetHouses();
        House GetHouseById(int p_id);
        void AddHouse(string name, int nbOfUnits);
        void DeleteHouse(int id);


        /*List<Fight> GetFights();
        Fight GetFightById(int f);
        List<Territory> GetTerritories();
        Territory GetTerritoryById(int t);
        List<Character> GetCharacters();
        Character GetCharacterById(int c);*/

        /*void AddCharacter(Character c);
        void AddTerritory(Territory t);
        void AddFight(Fight f);
        
        void DeleteCharacter(Character c);
        void DeleteTerritory(Territory t);
        void DeleteFight(Fight f);
        void UpdateHouse(House h);
        void UpdateCharacter(Character c);
        void UpdateTerritory(Territory t);
        void UpdateFight(Fight f);*/
    }
}
