﻿using CAB201_UserInterfaceTest;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment_2022_S1
{
    internal class BookingMenu : Menu
    {
        public BookingMenu(string title, params MenuItem[] menuItems) : base(title, menuItems)
        {
            MenuItem registerCustomer = new CallableItem("Register a customer", RegisterCustomer);
            Add(registerCustomer);

            MenuItem registerLightAircraft = new CallableItem("Register new light aircraft", RegisterLightAircraft);
            Add(registerLightAircraft);

            MenuItem getExistingServices = new CallableItem("View existing flying services", ViewFlyingServices);
            Add(getExistingServices);

            MenuItem getFlyingTimes = new CallableItem("View existing times", ViewFlyingTimes);
            Add(getFlyingTimes);

            MenuItem logout = new CallableItem("Logout", Logout);
            Add(logout);
        }

        private int Logout()
        {
            // TODO put text here and remove active employee from registry
            return -1;
        }

        private int ViewFlyingTimes()
        {
            List<BaseAircraft> services = Airline.FIGHT_REGISTRY.getAll();

            foreach (BaseAircraft service in services)
            {
                Console.WriteLine(String.Format("{0} departing {1} to {2} traveling for {3} minutes",
                    service.getCraftType(), service.getDepaturePlace(), service.getArrivalPlace(), service.getFlyTime()));
            }

            if (services.Count <= 0)
            {
                UserInterface.Message("No services to view");
            }

            return 0;
        }

        private int ViewFlyingServices()
        {
            List<BaseAircraft> services = Airline.FIGHT_REGISTRY.getAll();

            foreach(BaseAircraft service in services)
            {
                Console.WriteLine(String.Format("{0} departing {1} to {2} traveling {3} kms", 
                    service.getCraftType(), service.getDepaturePlace(), service.getArrivalPlace(), service.getDistance()));
            }

            if (services.Count <= 0)
            {
                UserInterface.Message("No services to view");
            }

            return 0;
        }

        private int RegisterLightAircraft()
        {
            string depaturePlace = "";
            while (depaturePlace.Length <= 0)
            {
                depaturePlace = UserInterface.GetInput("Depature Place").Trim();
            }

            string arrivalPlace = "";
            while (arrivalPlace.Length <= 0)
            {
                arrivalPlace = UserInterface.GetInput("Arrival Place").Trim();
            }

            if (depaturePlace.ToLower() == arrivalPlace.ToLower())
            {
                UserInterface.Message("Arrival and Destination cannot be the same. Try again.");
                return 0;
            }

            string depatureTime = "";
            while (depatureTime.Length <= 0)
            {
                depatureTime = UserInterface.GetInput("Depature Time").Trim();
                if (!TimeSpan.TryParse(depatureTime, out TimeSpan t))
                {
                    UserInterface.Message("Incorrrect Depature Time entered. Must be 24 Hour time Eg. 13:00");
                    depatureTime = "";
                }
            }

            string distance = "";
            int distInt = 0;
            while (distance.Length <= 0)
            {
                distance = UserInterface.GetInput("Distance").Trim();
                try
                {
                    var formatSign = new NumberFormatInfo();
                    formatSign.NegativeSign = "−";

                    distInt = Int32.Parse(distance, formatSign);
                    if (distInt < 0)
                    {
                        throw new Exception("Incorrect Distance value entered");
                    }
                } catch {
                    distance = "";
                    UserInterface.Message("Distance must be a number value greater than 0");
                }
            }

            LightAircraft flight = new LightAircraft(depaturePlace, arrivalPlace, depatureTime, distInt);
            Airline.FIGHT_REGISTRY.add(flight);

            UserInterface.Message(String.Format("Light Aircraft from {0} to {1} added", depaturePlace, arrivalPlace));

            return 0;
        }

        private int RegisterCustomer()
        {
            Person person = Utils.promptPersonCreation();

            string address = "";
            while (address.Length <= 0)
            {
                address = UserInterface.GetInput("Address").Trim();
            }

            string mobile = "";
            while (mobile.Length <= 0)
            {
                // TODO check is real number
                mobile = UserInterface.GetInput("Mobile").Trim();
            }

            Customer newCustomer = new Customer(person, address, mobile);

            if (Airline.CUSTOMER_REGISTRY.add(newCustomer))
            {
                UserInterface.Message(String.Format("{0} registered successfully", newCustomer.getName()));
            } else
            {
                UserInterface.Message(String.Format("Customer {0} already exists", newCustomer.getName()));
            }
            return 0;
        }
    }
}