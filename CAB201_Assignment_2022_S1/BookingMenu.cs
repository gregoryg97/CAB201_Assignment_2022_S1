﻿using CAB201_UserInterfaceTest;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace CAB201_Assignment_2022_S1
{
    /// <summary>
    /// Class which represents the core Booking Menu structure of the Airline Program
    /// This handles all User Interface prompts and input error handling.
    /// While interacting the with AirlineProgram registry objects for Data Access
    /// </summary>
    internal class BookingMenu : Menu
    {
        public BookingMenu(string title, params MenuItem[] menuItems) : base(title, menuItems)
        {
            MenuItem registerCustomer = new CallableItem("Register a customer", RegisterCustomer);
            Add(registerCustomer);

            MenuItem registerLightAircraft = new CallableItem("Register new light aircraft", RegisterLightAircraft);
            Add(registerLightAircraft);

            MenuItem registerHelicopter = new CallableItem("Register new helicopter", RegisterHelicopter);
            Add(registerHelicopter);

            MenuItem getExistingServices = new CallableItem("View existing flying services", ViewFlyingServices);
            Add(getExistingServices);

            MenuItem getFlyingTimes = new CallableItem("View existing times", ViewFlyingTimes);
            Add(getFlyingTimes);

            MenuItem addCustomerToService = new CallableItem("Add customer to flying service", AddCustomerToService);
            Add(addCustomerToService);

            MenuItem getFlightPassangers = new CallableItem("View flight passangers", ViewFlightPassangers);
            Add(getFlightPassangers);

            MenuItem logout = new CallableItem("Logout", Logout);
            Add(logout);
        }

        /// <summary>
        /// Exits user from menu and terminates application.
        /// </summary>
        /// <returns>-1 Int value to terminate interface</returns>
        private int Logout()
        {
            // TODO put text here and remove active employee from registry
            return -1;
        }

        /// <summary>
        /// Presents the user with a list of services and requests the user to select the service
        /// which they wish to view currently booked passangers for.
        /// 
        /// This will present a message if no services are avaiable or no passangers booked for selected service.
        /// </summary>
        private int ViewFlightPassangers()
        {
            List<BaseAircraft> services = Airline.FIGHT_REGISTRY.getAll();
            if (services.Count <= 0)
            {
                UserInterface.Message("No services to add a customer to");
                return 0;
            }

            List<String> servicesStr = new List<String>();
            foreach (BaseAircraft service in services)
            {
                servicesStr.Add(String.Format("{0} - {1} to {2} @ {3}", service.getCraftType(), service.getDepaturePlace(),
                    service.getArrivalPlace(), service.getDepatureTime()));
            }

            int selectedService = UserInterface.GetOption("Select Service:", servicesStr.ToArray());

            if (services[selectedService].getPassangerCount() <= 0)
            {
                UserInterface.Message("Service has no passangers");
                return 0;
            }

            List<Customer> passangers = services[selectedService].getPassangerList();
            foreach (Customer passanger in passangers)
            {
                Console.WriteLine(passanger.getName());
            }

            return 0;
        }

        /// <summary>
        /// Requests the user to select pre-exisiting customer & pre-exisiting service for the 
        /// customer to be booked on. If the service is full or no-services exist the UI will display 
        /// the relevant message.
        /// </summary>
        private int AddCustomerToService()
        {
            List<Customer> customerList = Airline.CUSTOMER_REGISTRY.getAll();
            List<BaseAircraft> services = Airline.FIGHT_REGISTRY.getAll();

            if (customerList.Count <= 0)
            {
                UserInterface.Message("No customers to add to services");
                return 0;
            }

            if (services.Count <= 0)
            {
                UserInterface.Message("No services to add a customer to");
                return 0;
            }

            List<String> customerStrs = new List<String>();
            foreach (Customer customer in customerList)
            {
                customerStrs.Add(String.Format("{0}", customer.getName()));
            }

            int selectedCustomer = UserInterface.GetOption("Select Customer:", customerStrs.ToArray());

            List<String> servicesStr = new List<String>();
            foreach (BaseAircraft service in services)
            {
                servicesStr.Add(String.Format("{0} - {1} to {2} @ {3}", service.getCraftType(), service.getDepaturePlace(), 
                    service.getArrivalPlace(), service.getDepatureTime()));
            }

            int selectedService = UserInterface.GetOption("Select Service:", servicesStr.ToArray());

            if (services[selectedService].getRemainingCapacity() <= 0)
            {
                UserInterface.Message(String.Format("Selected service is at maximum capacity of {0} passangers", 
                    services[selectedService].getPassangerCount()));
            }

            if (!Airline.FIGHT_REGISTRY.addPassangerToFlight(customerList[selectedCustomer], selectedService))
            {
                UserInterface.Message("Passanger failed to be added to service. Please ensure " +
                    "passanger is not booked already or service is full.");
            } else
            {
                UserInterface.Message(String.Format("Customer {0} added to service. Total cost: ${1}",
                    customerList[selectedCustomer].getName(), services[selectedService].getPassangerCost(1)));
            }

            return 0;
        }

        /// <summary>
        /// Display flight time for all services in minutes.
        /// This will show aircraft type, depature location, destination and fly time in minutes
        /// </summary>
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

        /// <summary>
        /// Display all available services and their associated travel distance
        /// </summary>
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

        /// <summary>
        /// Creates new flight services by prompting user for details and entering this into the Registry
        /// </summary>
        /// <param name="type">Int value 0 for Light Aircraft & 1 for Helicopter</param>
        /// <returns></returns>
        private bool createFlight(int type)
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
                return false;
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
                }
                catch
                {
                    distance = "";
                    UserInterface.Message("Distance must be a number value greater than 0");
                }
            }

            BaseAircraft flight;
            if(type == 0)
            {
                flight = new LightAircraft(depaturePlace, arrivalPlace, depatureTime, distInt);
            } else
            {
                flight = new Helicopter(depaturePlace, arrivalPlace, depatureTime, distInt);
            }
                
            Airline.FIGHT_REGISTRY.add(flight);

            UserInterface.Message(String.Format("{0} from {1} to {2} added", flight.getCraftType(), depaturePlace, arrivalPlace));

            return true;
        }

        /// <summary>
        /// MenuItem prompt for user to create new Helicopter Service
        /// </summary>
        private int RegisterHelicopter()
        {
            createFlight(1);
            return 0;
        }

        /// <summary>
        /// MenuItem prompt for ruser to create new Light Aircraft Service
        /// </summary>
        private int RegisterLightAircraft()
        {
            createFlight(0);
            return 0;
        }

        /// <summary>
        /// MenuItem prompt for user to enter a new customer for booking into flight services
        /// </summary>
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
