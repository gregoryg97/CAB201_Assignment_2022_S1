using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment_2022_S1
{
    internal class LightAircraft : BaseAircraft
    {
        private static int KM_PER_HOUR = 800;
        private static int ADDITIONAL_MINS_PER_FLIGHT = 60;
        private static int COST_PER_HOUR = 250;

        public LightAircraft(string depaturePlace, string arrivalPlace, string depatureTime, int distance) 
            : base(depaturePlace, arrivalPlace, depatureTime, distance)
        {
            base.MAX_CAPACITY = 6;
        }

        public override int getFlyTime()
        {
            if (getDistance() <= 0)
            {
                return 0;
            }
            float value = ((getDistance() / (float)KM_PER_HOUR) * 60);
            return (int)(value + ADDITIONAL_MINS_PER_FLIGHT);
        }

        public override float getPassangerCost(int passangerCount)
        {
            float costPerMinute = COST_PER_HOUR / 60;
            return costPerMinute * getFlyTime() * passangerCount;
        }

        public override string getCraftType()
        {
            return "Light Aircraft";
        }
    }
}
