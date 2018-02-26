using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public abstract class Army : EntityObject
    {
        private int numberOfUnits;
        public int NumberOfUnits { get { return numberOfUnits; } set { this.numberOfUnits = (value > 0 ? value : 0); } }

        public abstract void WinBattle(int Casualties, int EnnemyCasualties);
        public abstract void LoseBattle(int Casualties, int EnnemyCasualties);
        public abstract void UnitWins(Random r);
        public abstract void UnitLoses(Random r);
        public abstract void UnitDraw(Random r);

        public abstract String Descriptor();
    }
}
