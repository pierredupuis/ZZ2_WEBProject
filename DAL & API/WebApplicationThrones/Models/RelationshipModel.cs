using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationThrones.Models
{
    
    public class RelationshipModel
    {
        public CharacterModel Char { get; set; }
        public RelationshipEnum Relation { get; set; }

        public RelationshipModel()
        {

        }
    }
    
}