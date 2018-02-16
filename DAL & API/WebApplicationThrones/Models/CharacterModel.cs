using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace WebApplicationThrones.Models
{

    public class CharacterModel
    {

        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Display(Name = "Bravoury")]
        public int Bravoury { get; set; }

        [Display(Name = "Crazyness")]
        public int Crazyness { get; set; }

        [Display(Name = "Strength")]
        public int Strength { get; set; }

        [Display(Name = "Health Points")]
        public int HP { get; set; }

        [Display(Name = "Maximum Health Points")]
        public int HPMax { get; set; }

		[Display(Name = "Relations with other Characters")]
        List<RelationshipModel> Relationships;

        public CharacterModel()
        { }
        /*public CharacterModel(Character c)
        {
            Bravoury = c.Bravoury;
            Crazyness = c.Crazyness;
            Strength = c.Strength;
            FirstName = c.FirstName;
            LastName = c.LastName;
            HP = c.HP;
            HPMax = c.HPMax;
            Relationships = c.Relationships;
        }*/
		
		public String toJSON()
		{
			return JsonConvert.SerializeObject(this);
		}
		
		public static CharacterModel fromJSON(String json)
		{
			return JsonConvert.DeserializeObject<CharacterModel>(json);
		}

    }
}
