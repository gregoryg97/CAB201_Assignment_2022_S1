using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment_2022_S1
{
    internal abstract class BaseAircraft
    {
        protected int MAX_CAPACITY = 0;
        protected int KM_PER_HOUR = 0;
        protected int COST_PER_HOUR = 0;

        private string DepaturePlace;
        private string ArrivalPlace;
        private string DepatureTime;

        private int Distance;
        private List<Customer> Passangers = new List<Customer>();

        public BaseAircraft(string depaturePlace, string arrivalPlace, string depatureTime, int distance)
        {
            DepaturePlace = depaturePlace;
            ArrivalPlace = arrivalPlace;
            DepatureTime = depatureTime;
            Distance = distance;
        }

        public BaseAircraft(BaseAircraft flight)
        {
            DepaturePlace = flight.getDepaturePlace();
            ArrivalPlace = flight.getArrivalPlace();
            DepatureTime = flight.getDepatureTime();
            Distance = flight.getDistance();
        }

        public string getDepaturePlace()
        {
            return DepaturePlace;
        }

        public string getArrivalPlace()
        {
            return ArrivalPlace;
        }

        public string getDepatureTime()
        {
            return DepatureTime;
        }

        public int getPassangerCount()
        {
            return Passangers.Count();
        }

        public int getDistance()
        {
            return Distance;
        }

        public int getRemainingCapacity()
        {
            return MAX_CAPACITY - getPassangerCount();
        }

        public bool addPassanger(Customer val)
        {
            if (Passangers.Count() >= MAX_CAPACITY)
            {
                return false;
            }

            Passangers.Add(val);
            return true;
        }

        public List<Customer> getPassangerList()
        {
            List<Customer> list = new List<Customer>();
            list.AddRange(Passangers);
            return list;
        }

        protected virtual int additionalFlyMinutes()
        {
            return 0;
        }

        public virtual int getFlyTime()
        {
            if (getDistance() <= 0)
            {
                return 0;
            }
            float value = ((getDistance() / (float)KM_PER_HOUR) * 60);
            return (int)(value + additionalFlyMinutes());
        }
        public virtual float getPassangerCost(int passangerCount)
        {
            float costPerMinute = COST_PER_HOUR / 60;
            return costPerMinute * getFlyTime() * passangerCount;
        }

        public abstract string getCraftType();

    }
}
