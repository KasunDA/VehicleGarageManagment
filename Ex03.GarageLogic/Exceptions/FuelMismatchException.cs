namespace Ex03.GarageLogic.Exceptions
{
    using System;

    using Ex03.GarageLogic.Enums;

    public class FuelMismatchException : Exception
    {
        public FuelMismatchException(eFuelType i_RequiredFuelType) :
            base("Engine required fuel of type " + i_RequiredFuelType.ToString())
        {
        }
    }
}