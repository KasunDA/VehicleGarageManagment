namespace Ex03.GarageLogic.Models
{
    using Ex03.GarageLogic.Enums;

    public class FuelCarBuilder : CarBuilder
    {
        private const eFuelType k_FuelType = eFuelType.Octan95;
        private const float k_MaxFuelAmount = 48;

        public FuelCarBuilder()
        {
            m_VehicleType = eVehicleType.FuelCar;
        }

        public override void InitalizeEngine(float i_EnergyAmount)
        {
            m_Engine = new FuelEngine(k_FuelType, i_EnergyAmount, k_MaxFuelAmount);
        }
    }
}