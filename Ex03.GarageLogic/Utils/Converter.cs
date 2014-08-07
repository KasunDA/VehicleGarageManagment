namespace Ex03.GarageLogic.Utils
{
    using System;

    using Ex03.GarageLogic.Enums;

    public static class Converter
    {
        public static string StringFromType(eEngineType i_EngineType)
        {
            string result;

            switch (i_EngineType)
            {
                case eEngineType.Electric:
                    result = "Electric Engine";
                    break;
                    case eEngineType.Fuel:
                    result = "Fuel Engine";
                    break;
                default:
                    throw new ArgumentException("Unknown engine type");
            }

            return result;
        }

        public static string StringFromType(eColorType i_ColorType)
        {
            string result;

            switch (i_ColorType)
            {
                case eColorType.Black:
                    result = "Black";
                    break;
                    case eColorType.Green:
                    result = "Green";
                    break;
                    case eColorType.Red:
                    result = "Red";
                    break;
                    case eColorType.Silver:
                    result = "Silver";
                    break;
                default:
                    throw new ArgumentException("Unknown color");
            }

            return result;
        }

        public static string StringFromType(eDoorsType i_DoorsType)
        {
            string result;

            switch (i_DoorsType)
            {
                case eDoorsType.Five:
                    result = "Five Doors";
                    break;
                    case eDoorsType.Four:
                    result = "Four Doors";
                    break;
                    case eDoorsType.Three:
                    result = "Three Doors";
                    break;
                    case eDoorsType.Two:
                    result = "Two Doors";
                    break;
                default:
                    throw new ArgumentException("Unknown doors type");
            }

            return result;
        }

        public static string StringFromType(eFuelType i_FuelType)
        {
            string result;

            switch (i_FuelType)
            {
                case eFuelType.Octan95:
                    result = "Octan 95";
                    break;
                    case eFuelType.Octan96:
                    result = "Octan 96";
                    break;
                    case eFuelType.Octan98:
                    result = "Octan 98";
                    break;
                    case eFuelType.Soler:
                    result = "Soler";
                    break;
                default:
                    throw new ArgumentException("Unknown fuel type");
            }

            return result;
        }

        public static string StringFromType(eLicenceType i_LicenceType)
        {
            string result;

            switch (i_LicenceType)
            {
                case eLicenceType.A1:
                    result = "A1 Licence";
                    break;
                    case eLicenceType.AA:
                    result = "AA Licence";
                    break;
                    case eLicenceType.AB:
                    result = "AB Licence";
                    break;
                    case eLicenceType.C:
                    result = "C Licence";
                    break;
                default:
                    throw new ArgumentException("Unknown licence type");
            }

            return result;
        }

        public static string StringFromType(eVehicleStatusType i_StatusType)
        {
            string result;

            switch (i_StatusType)
            {
                case eVehicleStatusType.Fixed:
                    result = "Fixed. Ready for payment.";
                    break;
                case eVehicleStatusType.Fixing:
                    result = "Fixing is still in progress.";
                    break;
                case eVehicleStatusType.Paid:
                    result = "Vehicle is fixed and paid for.";
                    break;
                default:
                    throw new ArgumentException("Unknown vehicle status type");
            }

            return result;
        }

        public static string StringFromType(eVehicleType i_VehicleType)
        {
            string result;

            switch (i_VehicleType)
            {
                case eVehicleType.FuelCar:
                    result = "Fuel Car";
                    break;
                case eVehicleType.ElectricCar:
                    result = "Electric Car";
                    break;
                case eVehicleType.FuelMotorcycle:
                    result = "Fuel Motorcycle";
                    break;
                case eVehicleType.ElectricMotorcycle:
                    result = "Electric Motorcycle";
                    break;
                case eVehicleType.FuelTruck:
                    result = "Fuel Truck";
                    break;
                default:
                    throw new ArgumentException("Unknown Vehicle Type");
            }

            return result;
        }
    }
}