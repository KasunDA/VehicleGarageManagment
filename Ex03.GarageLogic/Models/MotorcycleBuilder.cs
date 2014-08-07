namespace Ex03.GarageLogic.Models
{
    using System;

    using Ex03.GarageLogic.Components;
    using Ex03.GarageLogic.Enums;

    public abstract class MotorcycleBuilder : VehicleBuilder
    {
        protected MotorcycleBuilder()
        {
            m_ValidWheelsCount = 2;
            m_MaxWheelPressure = 29;
        }

        protected override void ThrowIfComponentIsNotValidForThisVehicleType(Component i_Component)
        {
            eComponentType typeToAdd = i_Component.Type;

            if (typeToAdd != eComponentType.LicenceComponent && typeToAdd != eComponentType.CapacityComponent)
            {
                throw new ArgumentException("You can only add licence and engine capacity components to a motorcycle.");
            }
        }
    }
}