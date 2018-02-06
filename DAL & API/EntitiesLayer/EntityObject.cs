using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public abstract class EntityObject
    {
        protected int id;
    }

    public enum Relashionship { FRIENDSHIP, LOVE, HATRED, RIVALRY}
    public enum CharacterTypeEnum { WARRIOR, WITCH, TACTICIAN, LEADER, LOSER}
    public enum TerritoryType { SEA, MOUNTAIN, LAND, DESERT}
    public struct CharacterRelation { Character c; Relashionship rel; }

}
