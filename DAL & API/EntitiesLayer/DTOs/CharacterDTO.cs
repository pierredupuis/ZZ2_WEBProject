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
        public int Pf { get; set; }
        public int HouseId { get; set; }

        public CharacterDTO()
        {
            Id = -1;
        }

        public CharacterDTO(int id, int bravoury, int crazyness, string firstName, string lastName, int pv, int pf, int houseId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Bravoury = bravoury;
            Crazyness = crazyness;
            Pv = pv;
            Pf = pf;
            HouseId = houseId;
        }
    }
}