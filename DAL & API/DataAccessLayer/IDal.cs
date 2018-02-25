using System;
using System.Collections.Generic;
using System.Text;
using EntitiesLayer;
using EntitiesLayer.DTOs;

namespace DataAccessLayer
{
    interface IDal
    {
        /* Houses */
        List<HouseDTO> GetHouses();
        HouseDTO GetHouseById(int p_id);
        void AddHouse(HouseDTO house);
        void EditHouse(HouseDTO house);
        void DeleteHouse(int id);

        /* WhiteWalkers */
        List<WhiteWalkerDTO> GetWhiteWalkers();
        WhiteWalkerDTO GetWhiteWalkerById(int p_id);
        void AddWhiteWalker(WhiteWalkerDTO house);
        void EditWhiteWalker(WhiteWalkerDTO house);
        void DeleteWhiteWalker(int id);

        /* Characters */
        List<CharacterDTO> GetCharacters();
        CharacterDTO GetCharacterById(int id);
        void AddCharacter(CharacterDTO c);
        void EditCharacter(CharacterDTO c);
        void DeleteCharacter(int id);

        /* Fights */

        List<FightDTO> GetFights();
        FightDTO GetFightById(int id);
        void AddFight(FightDTO f);
        void EditFight(FightDTO f);
        void DeleteFight(int id);

        /* Territory */
        List<TerritoryDTO> GetTerritorys();
        TerritoryDTO GetTerritoryById(int id);
        void AddTerritory(TerritoryDTO f);
        void EditTerritory(TerritoryDTO f);
        void DeleteTerritory(int id);

        /* Wars */
        List<WarDTO> GetWars();
        WarDTO GetWarById(int id);
        void AddWar(WarDTO f);
        /*void EditWar(WarDTO f);*/
        void DeleteWar(int id);
    }
}
