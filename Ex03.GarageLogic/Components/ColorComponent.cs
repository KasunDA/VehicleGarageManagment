namespace Ex03.GarageLogic.Components
{
    using Ex03.GarageLogic.Enums;
    using Ex03.GarageLogic.Utils;

    public class ColorComponent : Component
    {
        private readonly eColorType r_ColorType;
        
        public ColorComponent(eColorType i_Value)
        {
            r_ColorType = i_Value;
            m_ComponentType = eComponentType.ColorComponent;
        }

        public override string ToString()
        {
            return "Color:" + Converter.StringFromType(r_ColorType);
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