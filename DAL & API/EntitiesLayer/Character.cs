using System;
using System.Collections.Generic;
using System.Text;

namespace EntitiesLayer
{
    public class Character : EntityObject
    {
        int bravoury;
        int crazyness;
        String firstName;
        String lastName;
        float pv;
        float pf;

        public int Bravoury { get => bravoury; set => bravoury = value; }
        public int Crazyness { get => crazyness; set => crazyness = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public float Pv { get => pv; set => pv = value; }
        public float Pf { get => pf; set => pf = value; }

        public Character()
        {

        }
        void AddRelatives(Character relative)
        {

        }
        public override String ToString()
        {
            return "This is " + FirstName + " " + LastName +
                    "\nHis Bravoury is " + Bravoury + "\nHis crazyness is " + Crazyness + "\nBeware!lol\n";
        }
    }
}
