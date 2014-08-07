namespace Ex03.GarageLogic.Models
{
    using System;

    using Ex03.GarageLogic.Components;
    using Ex03.GarageLogic.Enums;

    public abstract class CarBuilder : VehicleBuilder
    {
        protected CarBuilder()
        {
            m_ValidWheelsCount = 4;
            m_MaxWheelPressure = 32;
        }

        protected override void ThrowIfComponentIsNotValidForThisVehicleType(Component i_Component)
        {
            eComponentType typeToAdd = i_Component.Type;

            if (typeToAdd != eComponentType.ColorComponent && typeToAdd != eComponentType.DoorsComponent)
            {
                throw new ArgumentException("You can only add color or doors to a car");
            }
        }
    }
}