namespace Ex03.GarageLogic.Exceptions
{
    using System;

    public class EngineMismatchException : Exception
    {
        public EngineMismatchException()
            : base("Energy source not compatible to the specific engine")
        {
        }
    }
}