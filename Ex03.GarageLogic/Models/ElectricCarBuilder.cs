namespace Ex03.GarageLogic.Models
{
    using Ex03.GarageLogic.Enums;

    public class ElectricCarBuilder : CarBuilder
    {
        private const float k_MaxEnergyHours = 1.8f;

        public ElectricCarBuilder()
        {
            m_VehicleType = eVehicleType.ElectricCar;
        }

        public override void InitalizeEngine(float i_EnergyAmount)
        {
            m_Engine = new ElectricEngine(i_EnergyAmount, k_MaxEnergyHours);
        }
    }
}
