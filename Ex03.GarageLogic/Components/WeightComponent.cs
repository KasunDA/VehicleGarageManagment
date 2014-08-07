namespace Ex03.GarageLogic.Components
{
    using Ex03.GarageLogic.Enums;

    public class WeightComponent : Component
    {
        private readonly float r_Weight;
        
        public WeightComponent(float i_Value)
        {
            r_Weight = i_Value;
            m_ComponentType = eComponentType.WeightComponent;
        }

        public override string ToString()
        {
            return "Maximum Weight: " + r_Weight.ToString() + "Kg";
        }

        public override eComponentType Type
        {
            get
            {
                return m_ComponentType;
            }
        }
    }
}