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
        private string DepaturePlace;
        private string ArrivalPlace;
        private string DepatureTime;
        private int Distance;
        private List<Customer> Passangers;

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

        public bool addPassanger(Customer val)
        {
            // TODO add check
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

        public abstract int getFlyTime();
        public abstract float getPassangerCost(int passangerCount);

        public abstract string getCraftType();

    }
}
