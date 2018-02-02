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
        public string Bravoury { get; set; }
        public string Crazyness { get; set; }
        public string Pv { get; set; }

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