namespace Ex03.GarageLogic.Models
{
    using System.Text;

    using Ex03.GarageLogic.Exceptions;

    public class Wheel
    {
        private readonly string r_Manufacturer;

        private readonly float r_MaxPressure;

        private float m_AirPressure;

        public string Manufecturer
        {
            get
            {
                return r_Manufacturer;
            }
        }

        public float MaxPressure
        {
            get
            {
                return r_MaxPressure;
            }
        }

        public float AirPressure
        {
            get
            {
                return m_AirPressure;
            }
        }

        public void InflateAir(float i_AirPressureToAdd)
        {
            if (m_AirPressure + i_AirPressureToAdd <= r_MaxPressure)
            {
                m_AirPressure += i_AirPressureToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(0, MaxPressure);
            }
        }

        public override string ToString()
        {
            return
                new StringBuilder().AppendLine("Maker:" + r_Manufacturer.PadLeft(15))
                    .AppendLine("Current Pressure:" + m_AirPressure.ToString().PadLeft(15))
                    .AppendLine("Maximum Pressure:" + r_MaxPressure.ToString().PadLeft(15))
                    .ToString();
        }

        public Wheel(string i_Manufacturer, float i_MaxPressure, float i_CurrentAirPressure)
        {
            r_Manufacturer = i_Manufacturer;
            r_MaxPressure = i_MaxPressure;
            m_AirPressure = i_CurrentAirPressure;
        }

        public Wheel(Wheel i_OtherWheel)
        {
            m_AirPressure = i_OtherWheel.AirPressure;
            r_Manufacturer = i_OtherWheel.Manufecturer;
            r_MaxPressure = i_OtherWheel.MaxPressure;
        }
    }
}
