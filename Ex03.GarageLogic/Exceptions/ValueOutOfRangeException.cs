namespace Ex03.GarageLogic.Exceptions
{
    using System;

    public class ValueOutOfRangeException : Exception
    {
        private readonly float r_MinValue;

        private readonly float r_MaxValue;

        public ValueOutOfRangeException(float iRMinValue, float iRMaxValue)
            : base("Value must be between " + iRMinValue + " and " + iRMaxValue)
        {
            r_MinValue = iRMinValue;
            r_MaxValue = iRMaxValue;
        }

        public float RMinValue
        {
            get
            {
                return r_MinValue;
            }
        }

        public float RMaxValue
        {
            get
            {
                return r_MaxValue;
            }
        }
    }
}