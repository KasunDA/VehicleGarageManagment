namespace Ex03.GarageLogic.Components
{
    using Ex03.GarageLogic.Enums;
    using Ex03.GarageLogic.Utils;

    public class DoorsComponent : Component
    {
        private readonly eDoorsType r_DoorsType;
        
        public DoorsComponent(eDoorsType i_Value)
        {
            r_DoorsType = i_Value;
            m_ComponentType = eComponentType.DoorsComponent;
        }

        public override string ToString()
        {
            return "Doors:" + Converter.StringFromType(r_DoorsType);
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