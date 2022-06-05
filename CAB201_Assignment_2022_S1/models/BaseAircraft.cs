using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment_2022_S1
{

    /// <summary>
    /// Class to define the base details of any Aircraft Service within the booking system
    /// This class defines cost, distance, travel time, depature place, arrival place and booked customers
    /// </summary>
    internal abstract class BaseAircraft
    {
        /// <summary>
        /// Maximum capacity of the service
        /// </summary>
        protected int MAX_CAPACITY = 0;
        /// <summary>
        /// Total kilometers travelled per hour by service
        /// </summary>
        protected int KM_PER_HOUR = 0;
        /// <summary>
        /// Total cost of service per hour of operation
        /// </summary>
        protected int COST_PER_HOUR = 0;

        /// <summary>
        /// Location of service depature
        /// </summary>
        private string DepaturePlace;
        /// <summary>
        /// Location of service arrival
        /// </summary>
        private string ArrivalPlace;
        /// <summary>
        /// 24-Hour time of service depature
        /// </summary>
        private string DepatureTime;

        /// <summary>
        /// Total fly-time distance of service
        /// </summary>
        private int Distance;

        /// <summary>
        /// Booked customers of service
        /// </summary>
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

        /// <returns>Point of depature for service</returns>
        public string getDepaturePlace()
        {
            return DepaturePlace;
        }

        /// <returns>Point of arrival for service</returns>
        public string getArrivalPlace()
        {
            return ArrivalPlace;
        }

        /// <returns>24-Hour depature time of service</returns>
        public string getDepatureTime()
        {
            return DepatureTime;
        }

        /// <returns>Total number of booked customers</returns>
        public int getPassangerCount()
        {
            return Passangers.Count();
        }

        /// <returns>Total fly-time distance of service</returns>
        public int getDistance()
        {
            return Distance;
        }

        /// <returns>Remaining seats for service</returns>
        public int getRemainingCapacity()
        {
            return MAX_CAPACITY - getPassangerCount();
        }

        /// <summary>
        /// Adds Customer to service and returns false if MAX_CAP reached for service
        /// </summary>
        /// <param name="val">Customer to add to service</param>
        /// <returns>Bool of add success</returns>
        public bool addPassanger(Customer val)
        {
            if (Passangers.Count() >= MAX_CAPACITY)
            {
                return false;
            }

            Passangers.Add(val);
            return true;
        }

        /// <returns>Returns list of all Customers on service</returns>
        public List<Customer> getPassangerList()
        {
            List<Customer> list = new List<Customer>();
            list.AddRange(Passangers);
            return list;
        }

        /// <summary>
        /// Calculates the flight time outside of in air-time
        /// </summary>
        protected virtual int additionalFlyMinutes()
        {
            return 0;
        }

        /// <summary>
        /// Calculates total fly-time including additional time outside of in-air
        /// </summary>
        public virtual int getFlyTime()
        {
            if (getDistance() <= 0)
            {
                return 0;
            }
            float value = ((getDistance() / (float)KM_PER_HOUR) * 60);
            return (int)(value + additionalFlyMinutes());
        }

        /// <summary>
        /// Calculates the cost to passanger based on number of passangers.
        /// This calculation assumes that in-flight time and additonal flight time are all billable
        /// </summary>
        /// <param name="passangerCount"></param>
        /// <returns>Float dollar value of service</returns>
        public virtual float getPassangerCost(int passangerCount)
        {
            float costPerMinute = COST_PER_HOUR / 60;
            return costPerMinute * getFlyTime() * passangerCount;
        }

        /// <returns>Returns string based name of Aircraft type</returns>
        public abstract string getCraftType();

    }
}
