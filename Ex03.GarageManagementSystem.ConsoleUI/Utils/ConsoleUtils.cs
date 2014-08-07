namespace Ex03.GarageManagementSystem.ConsoleUI.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    using Ex03.GarageLogic.Components;
    using Ex03.GarageLogic.Enums;
    using Ex03.GarageLogic.Models;
    using Ex03.GarageManagementSystem.ConsoleUI.Types;

    internal static class ConsoleUtils
    {
        internal static ActionType ParseActionType()
        {
            Console.WriteLine("Garage Menu");
            Console.WriteLine("1. Add a new Vehicle");
            Console.WriteLine("2. Show a list of vehicles IDs by status"); // can filter by status
            Console.WriteLine("3. Change vehicle state"); // get by id
            Console.WriteLine("4. Inflate wheels to maximum pressure"); // get by id
            Console.WriteLine("5. Fuel gasoline vehicle"); // get by id, provide fuel type + fuel amount
            Console.WriteLine("6. Charge electric vehicle"); // get by id, provide minutes to charge
            Console.WriteLine("7. Show full vehicle status"); // get by id
            Console.WriteLine("8. Exit application");

            int userChoice = ParseIntWithinRange(1, 8);
            return (ActionType)userChoice;
        }
       
        internal static int ParseIntWithinRange(int i_MinValue, int i_MaxValue)
        {
            int result;

            while (true)
            {
                Console.WriteLine("Please enter you choice: (Valid values: [" + i_MinValue + "-" + i_MaxValue + "])");
                bool isValidNumber = int.TryParse(Console.ReadLine(), out result);

                if (isValidNumber)
                {
                    if (result >= i_MinValue && result <= i_MaxValue)
                    {
                        break;
                    }

                    Console.WriteLine("Your number is out of range.");
                }
                else
                {
                    Console.WriteLine("Please enter a valid integer");
                }
            }

            return result;
        }

        internal static string ParseVehicleID()
        {
            string result;
            Regex alphaNumericRegex = new Regex("^[a-zA-Z0-9]*$");
            
            Console.WriteLine("Please enter vehicle ID: (alpahnumeric only)");
            while (true)
            {
                result = Console.ReadLine();
                if (!string.IsNullOrEmpty(result) && alphaNumericRegex.IsMatch(result))
                {
                    break;
                }
                
                Console.WriteLine("Illegal ID number. Please try again: ");
            }

            return result;
        }

        internal static eFuelType ParseFuelType()
        {
            Console.WriteLine("Please choose a fuel type:");
            Console.WriteLine("1. Octan 95");
            Console.WriteLine("2. Octan 96");
            Console.WriteLine("3. Octan 98");
            Console.WriteLine("4. Soler");

            int choiceValue = ParseIntWithinRange(1, 4);
            return (eFuelType)choiceValue;
        }

        internal static float ParseEnergyAmount()
        {
            float result;

            while (true)
            {
                string userInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(userInput))
                {
                    result = float.Parse(userInput);
                    if (result > 0)
                    {
                        break;
                    }

                    Console.WriteLine("Value must be positive. Please try again.");
                }
                else
                {
                    Console.WriteLine("Value can not be empty. Please try again.");
                }
            }

            return result;
        }

        internal static eVehicleStatusType ParseStatusType()
        {
            Console.WriteLine("Choose vehicle status:");
            Console.WriteLine("1. Fixed");
            Console.WriteLine("2. Fixing");
            Console.WriteLine("3. Paid");

            int userChoice = ParseIntWithinRange(1, 3);
            return (eVehicleStatusType)userChoice;
        }

        internal static Contact ParseContact()
        {
            string name;
            string phone;

            Console.WriteLine("Creating New Contact:");
            Console.Write("Enter contact name: ");
            while (true)
            {
                name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name))
                {
                    break;
                }

                Console.WriteLine("Name can not be empty. Please try again.");
            }
            
            Console.Write("Enter contact phone: ");
            Regex numericRegex = new Regex("^[0-9]*$");
            while (true)
            {
                phone = Console.ReadLine();
                if (!string.IsNullOrEmpty(phone) && numericRegex.IsMatch(phone))
                {
                    break;
                }

                Console.WriteLine("Phone must contain only digits. Please try again.");
            }

            return new Contact(name, phone);
        }

        internal static List<Wheel> ParseWheels(float i_MaxPressure, int i_WheelCount)
        {
            List<Wheel> result = new List<Wheel>();
            bool yesNoAnswer;
            int numWheels = i_WheelCount;

            Console.WriteLine("Would you like to enter the same values to all of the wheels? (yes/y/no/n)");
            while (true)
            {
                string userString = Console.ReadLine();
                
                if (userString != null && (userString.ToLower().Equals("yes") || userString.ToLower().Equals("y")))
                {
                    yesNoAnswer = true;
                    break;
                }
                
                if (userString != null && (userString.ToLower().Equals("no") || userString.ToLower().Equals("n")))
                {
                    yesNoAnswer = false;
                    break;
                }

                Console.WriteLine("Wrong input. Try again.");
            }

            Wheel firstWheel = ConsoleUtils.ParseWheel(i_MaxPressure);
            result.Add(firstWheel);
            for (int i = 0; i < numWheels - 1; ++i)
            {
                Wheel wheelToAdd = yesNoAnswer ? new Wheel(firstWheel) : ConsoleUtils.ParseWheel(i_MaxPressure); 
                result.Add(wheelToAdd);
            }

            return result;
        }

        internal static Wheel ParseWheel(float i_MaxPressure)
        {
            string maker;
            float currentPressure;

            while (true)
            {
                Console.WriteLine("Enter wheel maker name: ");
                maker = Console.ReadLine();
                Console.WriteLine("Enter current pressure: ");
                bool isValidCurrentPressure = float.TryParse(Console.ReadLine(), out currentPressure);

                if (!string.IsNullOrEmpty(maker) && isValidCurrentPressure && currentPressure <= i_MaxPressure)
                {
                    break;
                }

                Console.WriteLine("Invalid input. Pressure must be less or equal to " + i_MaxPressure);
            }

            return new Wheel(maker, i_MaxPressure, currentPressure);
        }

        public static VehicleBuildType ParseVehicleBuildType()
        {
            Console.WriteLine("Choose component to set:");
            Console.WriteLine("1. ID");
            Console.WriteLine("2. Model");
            Console.WriteLine("3. Engine");
            Console.WriteLine("4. Wheels");
            Console.WriteLine("5. Color");
            Console.WriteLine("6. Doors");
            Console.WriteLine("7. Engine Capacity");
            Console.WriteLine("8. Hazardous Property");
            Console.WriteLine("9. Licence Type");
            Console.WriteLine("10. Maximum Weight");
            Console.WriteLine("11. Add car with current settings");

            int result = ParseIntWithinRange(1, 11);
            return (VehicleBuildType)result;
        }

        public static eVehicleType ParseVehicleType()
        {
            Console.WriteLine("Choose Vehicle Type:");
            Console.WriteLine("1. Fuel Car");
            Console.WriteLine("2. Electric Car");
            Console.WriteLine("3. Fuel Motorcycle");
            Console.WriteLine("4. Electric Motorcycle");
            Console.WriteLine("5. Fuel Truck");

            int result = ParseIntWithinRange(1, 5);
            return (eVehicleType)result;
        }

        public static string ParseModel()
        {
            string result;
            
            Console.WriteLine("Enter Vehicle Model:");
            while (true)
            {
                result = Console.ReadLine();
                if (!string.IsNullOrEmpty(result))
                {
                    break;
                }

                Console.WriteLine("Name can't be empty");
            }

            return result;
        }

        public static Engine ParseEngine(eEngineType i_EngineType, float i_FuelAmount)
        {
            Engine result;

            result = i_EngineType == eEngineType.Electric ? ParseElectricEngine() : ParseFuelEngine();

            return result;
        }

        public static Component ParseColor()
        {
            Console.WriteLine("Choose a color: ");
            Console.WriteLine("1. Green");
            Console.WriteLine("2. Black");
            Console.WriteLine("3. Red");
            Console.WriteLine("4. Silver");

            int result = ParseIntWithinRange(1, 4);
            eColorType color = (eColorType)result;
            
            return new ColorComponent(color);
        }

        public static Component ParseDoorsType()
        {
            Console.WriteLine("Choose doors type: ");
            Console.WriteLine("1. Two Doors");
            Console.WriteLine("2. Three Doors");
            Console.WriteLine("3. Four Doors");
            Console.WriteLine("4. Five Doors");

            int result = ParseIntWithinRange(1, 4);
            eDoorsType type = (eDoorsType)result;
            
            return new DoorsComponent(type);
        }

        public static Component ParseLicenceType()
        {
            Console.WriteLine("Choose licence type: ");
            Console.WriteLine("1. A1");
            Console.WriteLine("2. AA");
            Console.WriteLine("3. AB");
            Console.WriteLine("4. C");

            int result = ParseIntWithinRange(1, 4);
            eLicenceType licType = (eLicenceType)result;
            
            return new LicenceComponent(licType);
        }

        public static Component ParseHazardousType()
        {
            Console.WriteLine("Choose hazardous type value: ");
            Console.WriteLine("1. True");
            Console.WriteLine("2. False");

            int result = ParseIntWithinRange(1, 2);
            bool value = result == 1;
            
            return new HazardousComponent(value);
        }

        public static Component ParseCapacity()
        {
            Console.WriteLine("Choose engine capacity value: (positive integer)");
            int capacity = readPositiveInteger();

            return new EngineCapacityComponent(capacity);
        }

        public static Component ParseWeight()
        {
            Console.WriteLine("Enter vehicle maximum weight:");
            float maxWeight = ReadPositiveFloat();

            return new WeightComponent(maxWeight);
        }

        public static float ReadPositiveFloat()
        {
            float result;

            while (true)
            {
                bool isValidInput = float.TryParse(Console.ReadLine(), out result);
                bool isValidValue = result > 0.0f;

                if (isValidInput && isValidValue)
                {
                    break;
                }

                Console.WriteLine("Illegal value. Try again.");
            }

            return result;
        }

        public static float ReadEnergyAmount()
        {
            Console.WriteLine("Enter enrgy amount:");
            return ReadPositiveFloat();
        }

        private static int readPositiveInteger()
        {
            int result;

            while (true)
            {
                bool isValidInput = int.TryParse(Console.ReadLine(), out result);
                bool isValidValue = result > 0;

                if (isValidInput && isValidValue)
                {
                    break;
                }

                Console.WriteLine("Illegal value. Try again.");
            }

            return result;
        }

        private static Engine ParseFuelEngine()
        {
            float maxLiters;
            float currentLiters;
            eFuelType fuelType;
            while (true)
            {
                fuelType = ParseFuelType();
                Console.WriteLine("Enter max liters:");
                bool isValidMaxSize = float.TryParse(Console.ReadLine(), out maxLiters) && maxLiters > 0f;
                Console.WriteLine("Enter current liters in tank:");
                bool isValidCurrentSize = float.TryParse(Console.ReadLine(), out currentLiters) && currentLiters > 0f;
                if (isValidCurrentSize && isValidMaxSize)
                {
                    break;
                }

                Console.WriteLine("Bad input. Try again.");
            }

            return new FuelEngine(fuelType, currentLiters, maxLiters);
        }

        private static Engine ParseElectricEngine()
        {
            float maxHours;
            float currentHours;
            while (true)
            {
                Console.WriteLine("Enter max hours: ");
                bool isValidMaxSize = float.TryParse(Console.ReadLine(), out maxHours) && maxHours > 0f;
                Console.WriteLine("Enter current remaining hours: ");
                bool isValidCurrentSize = float.TryParse(Console.ReadLine(), out currentHours) && currentHours > 0f;
                if (isValidCurrentSize && isValidMaxSize)
                {
                    break;
                }

                Console.WriteLine("Bad input. Try again.");
            }

            return new ElectricEngine(currentHours, maxHours);
        }

        private static eEngineType ParseEngineType()
        {
            Console.WriteLine("Choose engine type:");
            Console.WriteLine("1. Fuel engine");
            Console.WriteLine("2. Electric engine");

            int result = ParseIntWithinRange(1, 2);
            return (eEngineType)result;
        }
    }
}
