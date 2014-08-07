namespace Ex03.GarageLogic.Models
{
    using Ex03.GarageLogic.Enums;

    public class ElectricMotorcycleBuilder : MotorcycleBuilder
    {
        private const float k_MaxEnergyHours = 1.9f;

        public ElectricMotorcycleBuilder()
        {
            m_VehicleType = eVehicleType.ElectricMotorcycle;
        }

        public override void InitalizeEngine(float i_EnergyAmount)
        {
            m_Engine = new ElectricEngine(i_EnergyAmount, k_MaxEnergyHours);
        }
    }
}