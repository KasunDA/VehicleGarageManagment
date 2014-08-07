namespace Ex03.GarageLogic.Models
{
    using System;

    using Ex03.GarageLogic.Components;
    using Ex03.GarageLogic.Enums;

    public class TruckBuilder : VehicleBuilder
    {
        private const eFuelType k_FuelType = eFuelType.Soler;
        private const float k_MaxFuelLiters = 190f;

        public TruckBuilder()
        {
            m_VehicleType = eVehicleType.FuelTruck;
            m_ValidWheelsCount = 10;
            m_MaxWheelPressure = 31;
        }

        public override void InitalizeEngine(float i_EnergyAmount)
        {
            m_Engine = new FuelEngine(k_FuelType, i_EnergyAmount, k_MaxFuelLiters);
        }

        protected override void ThrowIfComponentIsNotValidForThisVehicleType(Component i_Component)
        {
            eComponentType typeToAdd = i_Component.Type;

            if (typeToAdd != eComponentType.WeightComponent && typeToAdd != eComponentType.HazardousComponent)
            {
                throw new ArgumentException("You can only add weight and hazardous components to a truck.");
            }
        }
    }
}