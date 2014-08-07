namespace Ex03.GarageLogic.Models
{
    using System.Collections.Generic;
    using System.Text;

    using Ex03.GarageLogic.Components;
    using Ex03.GarageLogic.Enums;
    using Ex03.GarageLogic.Utils;

    public class Vehicle
    {
        private readonly eVehicleType r_VehicleType;
        private readonly string r_ModelName;
        private readonly string r_ID;
        private readonly Engine r_Engine;
        private readonly List<Wheel> r_Wheels;
        private readonly List<Component> r_Components; 

        public string ID
        {
            get
            {
                return r_ID;
            }
        }

        public Vehicle(
            eVehicleType i_VehicleType,
            string i_ModelName,
            string i_ID,
            Engine i_Engine,
            List<Wheel> i_Wheels,
            List<Component> i_Components)
        {
            r_VehicleType = i_VehicleType;
            r_ModelName = i_ModelName;
            r_ID = i_ID;
            r_Engine = i_Engine;
            r_Wheels = i_Wheels;
            r_Components = i_Components;
        }

        public void InflateWheelsToMax()
        {
            foreach (Wheel wheel in r_Wheels)
            {
                wheel.InflateAir(wheel.MaxPressure - wheel.AirPressure);
            }
        }

        public void FillEnergy()
        {
            r_Engine.FillEnergy();
        }

        public override string ToString()
        {
            StringBuilder sb =
                new StringBuilder()
                .AppendLine("Vehicle Details:")
                    .AppendLine("Type: " + Converter.StringFromType(r_VehicleType))
                    .AppendLine("Model Name: " + r_ModelName)
                    .AppendLine("ID: " + r_ID)
                    .AppendLine("Engine Info:")
                    .AppendLine(r_Engine.ToString());

            sb.AppendLine("Wheels Details:");
            foreach (Wheel wheel in r_Wheels)
            {
                sb.AppendLine(wheel.ToString());
            }
            
            if (r_Components != null)
            {
                sb.AppendLine("Extra Details:");
                foreach (Component component in r_Components)
                {
                    sb.AppendLine(component.ToString());
                }
            }

            return sb.ToString();
        }
    }
}
