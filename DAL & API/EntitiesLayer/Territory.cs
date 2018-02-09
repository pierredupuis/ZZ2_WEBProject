using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Territory : EntityObject
    {
        TerritoryType type;
        House owner;

        static int currId = 0;

        internal House Owner { get => owner; set => owner = value; }

        public Territory(TerritoryType p_type, House p_owner)
        {
            owner = p_owner;
            type = p_type;

            Id = currId;
            currId++;
        }
    }
}
