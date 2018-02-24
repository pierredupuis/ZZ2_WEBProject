using System;
using System.Collections.Generic;
using System.Text;
using EntitiesLayer;
using ApiGOT.Models;

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
    }
}
