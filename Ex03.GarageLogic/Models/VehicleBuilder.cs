namespace Ex03.GarageLogic.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Ex03.GarageLogic.Components;
    using Ex03.GarageLogic.Enums;
    using Ex03.GarageLogic.Utils;

    public abstract class VehicleBuilder
    {
        protected int m_ValidWheelsCount;
        protected List<Component> m_Components;
        protected string m_VehicleID;
        protected string m_ModelName;
        protected eVehicleType m_VehicleType;
        protected Engine m_Engine;
        protected List<Wheel> m_Wheels;
        protected float m_MaxWheelPressure;

        protected VehicleBuilder()
        {
            m_VehicleID = null;
            m_ModelName = null;
            m_Engine = null;
            m_Wheels = null;
            m_Components = new List<Component>();
        }

        public Vehicle Build()
        {
            throwIfOneOfTheComponentsIsNull();

            Vehicle result = new Vehicle(
                m_VehicleType,
                m_ModelName,
                m_VehicleID,
                m_Engine,
                m_Wheels,
                m_Components);

            return result;
        }

        public string ID
        {
            get
            {
                return m_VehicleID;
            }

            set
            {
                m_VehicleID = value;
            }
        }

        public string Model
        {
            get
            {
                return m_ModelName;
            }

            set
            {
                m_ModelName = value;
            }
        }

        public abstract void InitalizeEngine(float i_EnergyAmount);

        public int ValidWheelsCount
        {
            get
            {
                return m_ValidWheelsCount;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }

            set
            {
                ThrowIfNumberOfWheelsIsNotValid(value);
                m_Wheels = value;
            }
        }

        public float MaxWheelPressure
        {
            get
            {
                return m_MaxWheelPressure;
            }
        }

        public void AddComponent(Component i_Component)
        {
            if (i_Component != null)
            {
                throwIfComponentAlreadyExists(i_Component);
                ThrowIfComponentIsNotValidForThisVehicleType(i_Component);
                m_Components.Add(i_Component);
            }
        }
        
        public override string ToString()
        {
            const string k_NotSet = "[Not Set]";
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Current Vehicle Information:");
            
            sb.Append("Vehicle Type: ");
            sb.AppendLine(Converter.StringFromType(m_VehicleType));
            
            sb.Append("ID: ");
            sb.AppendLine(m_VehicleID ?? k_NotSet);
            
            sb.Append("Model: ");
            sb.AppendLine(m_ModelName ?? k_NotSet);
            
            sb.Append("Engine: ");
            sb.AppendLine(m_Engine != null ? m_Engine.ToString() : k_NotSet);

            int numWheels = m_Wheels != null ? m_Wheels.Count : 0;

            sb.Append("Wheels [" + numWheels + "]:");
            if (m_Wheels != null)
            {
                foreach (Wheel wheel in m_Wheels)
                {
                    sb.AppendLine();
                    sb.AppendLine(wheel.ToString());
                }
            }
            else
            {
                sb.AppendLine(k_NotSet);
            }

            sb.AppendLine("Extra Details:");
            if (m_Components != null)
            {
                foreach (Component component in m_Components)
                {
                    sb.AppendLine();
                    sb.AppendLine(component.ToString());
                }
            }
            else
            {
                sb.AppendLine(k_NotSet);
            }

            sb.AppendLine("Vehicle status:");
            string readyMessage = isReady() ? "Ready to add vehicle (press 11)" : "Not enough information, provide more details";
            sb.AppendLine(readyMessage);

            return sb.ToString();
        }

        protected abstract void ThrowIfComponentIsNotValidForThisVehicleType(Component i_Component);

        protected void ThrowIfNumberOfWheelsIsNotValid(List<Wheel> i_Wheels)
        {
            int numOfWheels = i_Wheels.Count;

            if (numOfWheels != m_ValidWheelsCount)
            {
                throw new ArgumentException("Vehicle of type " + m_VehicleType + " can have exactly " + m_ValidWheelsCount + " wheels.");
            }
        }

        private bool isReady()
        {
            bool result = true;

            if (m_VehicleID == null)
            {
                result = false;
            }

            if (m_ModelName == null)
            {
                result = false;
            }

            if (m_Engine == null)
            {
                result = false;
            }

            if (m_Wheels == null)
            {
                result = false;
            }

            if (m_Components == null || m_Components.Count != 2)
            {
                result = false;
            }

            return result;
        }

        private void throwIfOneOfTheComponentsIsNull()
        {
            if (m_VehicleID == null)
            {
                throw new ArgumentException("No vehicle ID provided");
            }

            if (m_ModelName == null)
            {
                throw new ArgumentException("No model name provided");
            }

            if (m_Engine == null)
            {
                throw new ArgumentException("No engine provided");
            }

            if (m_Wheels == null)
            {
                throw new ArgumentException("No wheels provided");
            }

            if (m_Components.Count != 2)
            {
                throw new ArgumentException("Missing Vehicle components");
            }
        }

        private void throwIfComponentAlreadyExists(Component i_Component)
        {
            eComponentType typeToAdd = i_Component.Type;

            foreach (Component component in m_Components)
            {
                if (component.Type.Equals(typeToAdd))
                {
                    throw new ArgumentException("This component type already exists in this vehicle.");
                }
            }
        }
    }
}