namespace Ex03.GarageLogic.Components
{
    using Ex03.GarageLogic.Enums;

    public class EngineCapacityComponent : Component
    {
        private readonly int r_Capacity;
        
        public EngineCapacityComponent(int i_Value)
        {
            r_Capacity = i_Value;
            m_ComponentType = eComponentType.CapacityComponent;
        }

        public override string ToString()
        {
            return "Engine Capacity:" + r_Capacity + "Cc";
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