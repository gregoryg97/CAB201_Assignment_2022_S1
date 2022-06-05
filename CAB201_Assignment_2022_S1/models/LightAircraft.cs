using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment_2022_S1
{
    internal class LightAircraft : BaseAircraft
    {
        private static int ADDITIONAL_MINS_PER_FLIGHT = 60;

        public LightAircraft(string depaturePlace, string arrivalPlace, string depatureTime, int distance) 
            : base(depaturePlace, arrivalPlace, depatureTime, distance)
        {
            base.MAX_CAPACITY = 6;
            base.KM_PER_HOUR = 800;
            base.COST_PER_HOUR = 250;
        }

        protected override int additionalFlyMinutes()
        {
            return ADDITIONAL_MINS_PER_FLIGHT;
        }

        public override string getCraftType()
        {
            return "Light Aircraft";
        }
    }
}
