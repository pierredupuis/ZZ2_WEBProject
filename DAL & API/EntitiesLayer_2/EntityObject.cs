using System;
using System.Collections.Generic;
using System.Text;

namespace EntitiesLayer
{
    public class EntityObject
    {
        protected int id;
        public enum Character_t { WARRIOR, WITCH, TACTICIAN, LEADER, LOSER };
        public enum Relathionships_t { FRIENDSHIP, LOVE, HATRED, RIVALRY };
        public enum Territory_t { SEA, MOUNTAIN, LAND, DESERT };
    }
}
