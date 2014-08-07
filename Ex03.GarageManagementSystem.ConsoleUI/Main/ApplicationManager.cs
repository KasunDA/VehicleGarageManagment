namespace Ex03.GarageManagementSystem.ConsoleUI.Main
{
    using System;

    using Ex03.GarageLogic.Enums;
    using Ex03.GarageLogic.Exceptions;
    using Ex03.GarageLogic.Models;
    using Ex03.GarageLogic.Utils;
    using Ex03.GarageManagementSystem.ConsoleUI.Types;
    using Ex03.GarageManagementSystem.ConsoleUI.Utils;

    public class ApplicationManager
    {
        private readonly GarageContainer r_GarageContainer;
        private string m_UserVehicleID;
        private eFuelType m_UserFuelType;
        private float m_UserEnergyAmount;
        private eVehicleStatusType m_UserStatusType;
        private VehicleBuilder m_VehicleBuilder;

        public ApplicationManager()
        {
            r_GarageContainer = new GarageContainer();
        }

        public void StartApp()
        {
            while (true)
            {
                ActionType userAction = ConsoleUtils.ParseActionType();

                if (userAction == ActionType.ExitApplication)
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }

                handleUserAction(userAction);
            }
        }

        private void handleUserAction(ActionType i_Action)
        {
            switch (i_Action)
            {
                case ActionType.AddVehicle:
                    doAddVehicle();
                    break;
                case ActionType.ListVehicles:
                    doListIDsByStatus();
                    break;
                case ActionType.ChangeVehicleStatus:
                    doChangeVehicleStatus();
                    break;
                case ActionType.InflateAir:
                    doInflateAirToMax();
                    break;
                case ActionType.FuelGasolineVehicle:
                    doFillGasoline();
                    break;
                case ActionType.ChargeElectricVehicle:
                    doChargeElectric();
                    break;
                case ActionType.ShowVehicleDetails:
                    doShowVehicleDetails();
                    break;
            }
        }

        private void doAddVehicle()
        {
            Contact contact = ConsoleUtils.ParseContact();
            eVehicleType type = ConsoleUtils.ParseVehicleType();
            initVehicleBuilder(type);

            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine(m_VehicleBuilder.ToString());
                    VehicleBuildType vehicleBuildType = ConsoleUtils.ParseVehicleBuildType();
                    if (vehicleBuildType == VehicleBuildType.Done)
                    {
                        Vehicle vehicleInBuildProcess = m_VehicleBuilder.Build();
                        r_GarageContainer.AddVehicle(contact, vehicleInBuildProcess);
                        Console.WriteLine("Vehicle added.");
                        waitForKeyPress();
                        break;
                    }

                    handleBuild(vehicleBuildType);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    waitForKeyPress();
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    waitForKeyPress();
                }
            }
        }

        private void initVehicleBuilder(eVehicleType i_VehicleType)
        {
            switch (i_VehicleType)
            {
                case eVehicleType.FuelCar:
                    m_VehicleBuilder = new FuelCarBuilder();
                    break;
                case eVehicleType.ElectricCar:
                    m_VehicleBuilder = new ElectricCarBuilder();
                    break;
                case eVehicleType.FuelMotorcycle:
                    m_VehicleBuilder = new FuelMotorcycleBuilder();
                    break;
                case eVehicleType.ElectricMotorcycle:
                    m_VehicleBuilder = new ElectricMotorcycleBuilder();
                    break;
                case eVehicleType.FuelTruck:
                    m_VehicleBuilder = new TruckBuilder();
                    break;
            }
        }

        private void waitForKeyPress()
        {
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
            Console.Clear();
        }

        private void handleBuild(VehicleBuildType vehicleBuildType)
        {
            switch (vehicleBuildType)
            {
                case VehicleBuildType.VehicleModel:
                    m_VehicleBuilder.Model = ConsoleUtils.ParseModel();
                    break;
                case VehicleBuildType.VehicleID:
                    m_VehicleBuilder.ID = ConsoleUtils.ParseVehicleID();
                    break;
                case VehicleBuildType.VehicleEngine:
                    m_VehicleBuilder.InitalizeEngine(ConsoleUtils.ReadEnergyAmount());
                    break;
                case VehicleBuildType.VehicleWheels:
                    m_VehicleBuilder.Wheels = ConsoleUtils.ParseWheels(m_VehicleBuilder.MaxWheelPressure, m_VehicleBuilder.ValidWheelsCount);
                    break;
                case VehicleBuildType.VehicleColor:
                    m_VehicleBuilder.AddComponent(ConsoleUtils.ParseColor());
                    break;
                case VehicleBuildType.VehicleDoors:
                    m_VehicleBuilder.AddComponent(ConsoleUtils.ParseDoorsType());
                    break;
                case VehicleBuildType.VehicleLicence:
                    m_VehicleBuilder.AddComponent(ConsoleUtils.ParseLicenceType());
                    break;
                case VehicleBuildType.VehicleHazardous:
                    m_VehicleBuilder.AddComponent(ConsoleUtils.ParseHazardousType());
                    break;
                case VehicleBuildType.VehicleEngineCapacity:
                    m_VehicleBuilder.AddComponent(ConsoleUtils.ParseCapacity());
                    break;
                case VehicleBuildType.VehicleWeight:
                    m_VehicleBuilder.AddComponent(ConsoleUtils.ParseWeight());
                    break;
                default:
                    throw new ArgumentException("Unknown vehicle type");
            }
        }

        private void doListIDsByStatus()
        {
            m_UserStatusType = ConsoleUtils.ParseStatusType();
            Console.WriteLine("Vehicles in status: " + Converter.StringFromType(m_UserStatusType));
            Console.WriteLine();
            foreach (string idStr in r_GarageContainer.GetVehiclesIDsListByStatus(m_UserStatusType))
            {
                Console.WriteLine("ID: " + idStr);
            }

            Console.WriteLine("End of list.");
            Console.WriteLine();
        }

        private void doChangeVehicleStatus()
        {
            Console.WriteLine("Changing vehicle status:");
            
            m_UserVehicleID = ConsoleUtils.ParseVehicleID();
            
            if (existsWithID())
            {
                r_GarageContainer.GetGarageEntryByID(m_UserVehicleID).Status = ConsoleUtils.ParseStatusType();
                Console.WriteLine("Status changed.");
            }
            else
            {
                printNotFound();
            }
        }

        private void doShowVehicleDetails()
        {
            Console.WriteLine("Listing vehicle details:");
            m_UserVehicleID = ConsoleUtils.ParseVehicleID();
            
            if (existsWithID())
            {
                Console.Clear();
                Console.WriteLine("Owner info: ");
                Console.WriteLine(r_GarageContainer.GetGarageEntryByID(m_UserVehicleID).Owner);
                Console.WriteLine("Vehicle info: ");
                Console.WriteLine(getVehicleFromUserID().ToString());
            }
            else
            {
                printNotFound();
            }
        }
        
        private void doInflateAirToMax()
        {
            try
            {
                Console.WriteLine("Inflating wheels pressure to maximum:");
                m_UserVehicleID = ConsoleUtils.ParseVehicleID();
                if (existsWithID())
                {
                    getVehicleFromUserID().InflateWheelsToMax();
                    Console.WriteLine("Done.");
                    return;
                }

                printNotFound();
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                waitForKeyPress();
            }
        }
        
        private void printNotFound()
        {
            Console.WriteLine("Vehicle with ID " + m_UserVehicleID + " not found.");
        }
        
        private bool existsWithID()
        {
            bool result = r_GarageContainer.GetVehicleByID(m_UserVehicleID) != null;
            
            return result;
        }
        
        private void doChargeElectric()
        {
            try
            {
                Console.WriteLine("Charging Electric Vehicle:");
                m_UserVehicleID = ConsoleUtils.ParseVehicleID();

                if (existsWithID())
                {
                    Console.WriteLine("Enter energy amount in minutes:");
                    m_UserEnergyAmount = ConsoleUtils.ParseEnergyAmount();
                    GasStation.Instance.SetPump(m_UserEnergyAmount);
                    getVehicleFromUserID().FillEnergy();
                    Console.WriteLine("Energy filled.");
                    return;
                }

                printNotFound();
            }
            catch (EngineMismatchException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        private Vehicle getVehicleFromUserID()
        {
            return r_GarageContainer.GetVehicleByID(m_UserVehicleID);
        }

        private void doFillGasoline()
        {
            try
            {
                Console.WriteLine("Fueling gasoline vehicle:");
                m_UserVehicleID = ConsoleUtils.ParseVehicleID();
                if (existsWithID())
                {
                    Console.WriteLine("Enter fuel amount in liters: ");
                    m_UserEnergyAmount = ConsoleUtils.ParseEnergyAmount();
                    m_UserFuelType = ConsoleUtils.ParseFuelType();
                    GasStation.Instance.SetPump(m_UserFuelType, m_UserEnergyAmount);
                    getVehicleFromUserID().FillEnergy();
                    Console.WriteLine("Fuel filled.");
                    
                    return;
                }

                printNotFound();
            }
            catch (EngineMismatchException ex)
            {
                Console.WriteLine(ex.Message);
                waitForKeyPress();
            }
            catch (FuelMismatchException ex)
            {
                Console.WriteLine(ex.Message);
                waitForKeyPress();
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                waitForKeyPress();
            }
        }
    }
}