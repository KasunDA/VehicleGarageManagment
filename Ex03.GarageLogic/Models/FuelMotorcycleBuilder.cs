namespace Ex03.GarageLogic.Models
{
    using Ex03.GarageLogic.Enums;

    public class FuelMotorcycleBuilder : MotorcycleBuilder
    {
        private const eFuelType k_FuelType = eFuelType.Octan98;
        private const float k_MaxFuelLiters = 7.5f;

        public FuelMotorcycleBuilder()
        {
            m_VehicleType = eVehicleType.FuelMotorcycle;
        }

        public override void InitalizeEngine(float i_EnergyAmount)
        {
            m_Engine = new FuelEngine(k_FuelType, i_EnergyAmount, k_MaxFuelLiters);
        }
    }
}