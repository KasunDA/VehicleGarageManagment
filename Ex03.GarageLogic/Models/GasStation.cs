namespace Ex03.GarageLogic.Models
{
    using Ex03.GarageLogic.Enums;

    public class GasStation
    {
        private static GasStation m_Instance;

        private float m_EnergyAmountToFill;

        private eFuelType? m_FuelTypeToFill;

        private GasStation()
        {
            m_FuelTypeToFill = null;
        }

        public static GasStation Instance
        {
            get
            {
                return m_Instance ?? (m_Instance = new GasStation());
            }
        }

        public eFuelType? CurrentFuelType
        {
            get
            {
                return m_FuelTypeToFill;
            }
        }

        /* Set pump to provide fuel */
        public void SetPump(eFuelType i_FuelType, float i_Liters)
        {
            m_FuelTypeToFill = i_FuelType;
            m_EnergyAmountToFill = i_Liters;
        }

        /* Set pump to provide electricity */
        public void SetPump(float i_HoursToFill)
        {
            m_FuelTypeToFill = null;
            m_EnergyAmountToFill = i_HoursToFill;
        }

        internal void ProvideFuel(Engine i_Engine)
        {
            i_Engine.Energy += m_EnergyAmountToFill;
        }

        internal void ProvideElectricity(Engine i_Engine)
        {
            i_Engine.Energy += m_EnergyAmountToFill;
        }
    }
}
