using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment_2022_S1
{
    /// <summary>
    /// Class which defines a Light Aircraft for the purposes of booking services
    /// </summary>
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

        /// <summary>
        /// Calculates the flight time outside of in air-time
        /// </summary>
        protected override int additionalFlyMinutes()
        {
            return ADDITIONAL_MINS_PER_FLIGHT;
        }

        /// <returns>Returns string based name of Aircraft type</returns>
        public override string getCraftType()
        {
            return "Light Aircraft";
        }
    }
}
