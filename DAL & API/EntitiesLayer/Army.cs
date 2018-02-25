using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public abstract class Army : EntityObject
    {
        public int NumberOfUnits { get; set; }

        public abstract void WinBattle(int Casualties, int EnnemyCasualties);
        public abstract void LoseBattle(int Casualties, int EnnemyCasualties);

        public abstract String Descriptor();
    }
}
