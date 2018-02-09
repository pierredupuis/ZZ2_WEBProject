using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

using EntitiesLayer;

namespace ApiGOT.Models
{
    public class CharacterDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Bravoury { get; set; }
        public int Crazyness { get; set; }
        public int Pv { get; set; }

        public CharacterDTO(Character character)
        {
            Id = character.Id;
            FirstName = character.FirstName;
            LastName = character.LastName;
            Bravoury = character.Bravoury;
            Crazyness = character.Crazyness;
            Pv = Pv;
        }

    }
}