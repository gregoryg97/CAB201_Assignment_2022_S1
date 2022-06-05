using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment_2022_S1
{
    internal class Helicopter : BaseAircraft
    {
        public Helicopter(string depaturePlace, string arrivalPlace, string depatureTime, int distance)
            : base(depaturePlace, arrivalPlace, depatureTime, distance)
        {
            base.MAX_CAPACITY = 2;
            base.KM_PER_HOUR = 120;
            base.COST_PER_HOUR = 600;
        }

        protected override int additionalFlyMinutes()
        {
            return 10 + (getPassangerCount() * 5);
        }

        public override string getCraftType()
        {
            return "Helicopter";
        }
    }
}
