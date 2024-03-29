﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment_2022_S1
{
    /// <summary>
    /// Class which handles the storage and validation of flights alongside passangers on each service
    /// </summary>
    internal class FlightRegistry : Registry<BaseAircraft>
    {
        public FlightRegistry()
        {
            this._registryStore = new List<BaseAircraft>();
        }

        protected override bool exists(BaseAircraft value)
        {
            BaseAircraft searchResult = this._registryStore.Find(delegate (BaseAircraft craft)
            {
                return craft.getDepaturePlace() == value.getDepaturePlace() &&
                    craft.getArrivalPlace() == value.getArrivalPlace() &&
                    craft.getDepatureTime() == value.getDepatureTime();
            });

            if (searchResult == null)
            {
                return false;
            }

            return true;
        }

        public override bool remove(BaseAircraft value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds passanger to defined service. Returning true if MAC succeeds
        /// </summary>
        /// <param name="passanger">Passanger to be added to service</param>
        /// <param name="serviceIdx">Index of service from getAll list<T> data</param>
        /// <returns>Entry success bool</returns>
        public bool addPassangerToFlight(Customer passanger, int serviceIdx)
        {
            if (serviceIdx < 0 || serviceIdx >= this._registryStore.Count())
            {
                return false;
            }

            BaseAircraft flight = this._registryStore[serviceIdx];

            Person searchResult = flight.getPassangerList().Find(delegate (Customer person)
            {
                return person.getName().Equals(passanger.getName());
            });

            if (searchResult != null)
            {
                return false;
            }

            return this._registryStore[serviceIdx].addPassanger(passanger);
        }
    }
}
