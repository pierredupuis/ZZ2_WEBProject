using System;
using System.Collections.Generic;
using System.Text;

namespace EntitiesLayer
{
    public class Territory : EntityObject
    {
        Character owner;
        Territory_t type;
        internal Character Owner { get => owner; set => owner = value; }
        public Territory()
        {

        }

        public override String ToString()
        {
            return "This territory is owned by " + Owner.FirstName + " " + Owner.LastName + ".\n";
        }
    }
}
