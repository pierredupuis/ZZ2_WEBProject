using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Character : EntityObject
    {

        int bravoury;
        int crazyness;
        string firstName;
        string lastName;
        int pv;
        CharacterRelation[] relationships;
        static int currentId = 0;

        public int Bravoury
        {
            get
            {
                return bravoury;
            }

            set
            {
                bravoury = value;
            }
        }

        public int Crazyness
        {
            get
            {
                return crazyness;
            }

            set
            {
                crazyness = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }

        public int Pv
        {
            get
            {
                return pv;
            }

            set
            {
                pv = value;
            }
        }

        public CharacterRelation[] Relationships
        {
            get
            {
                return relationships;
            }

            set
            {
                relationships = value;
            }
        }

        public Character(int p_bravoury = 0, int p_crazyness = 0, string p_firstName="Undefined", string p_lastName="Undefined", int p_pv=0)
        {
            Id = currentId;
            currentId++;

            bravoury = p_bravoury;
            crazyness = p_crazyness;
            firstName = p_firstName;
            lastName = p_lastName;
            pv = p_pv;
        }
        public void AddRelatives(CharacterRelation rel) { } 
        public override string ToString()
        {
            return "Character : " + firstName + lastName + " (Crazyness : " + crazyness + ", Bravoury : " + Bravoury + ", Pv : " + pv + " )";
        }

    }
}
