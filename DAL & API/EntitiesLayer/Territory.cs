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

        public House Owner
        {
            get
            {
                return owner;
            }

            set
            {
                owner = value;
            }
        }

        public Territory(int p_id, TerritoryType p_type, House p_owner)
        {
            owner = p_owner;
            type = p_type;

            Id = p_id;
        }
    }
}
