namespace Ex03.GarageLogic.Components
{
    using Ex03.GarageLogic.Enums;
    using Ex03.GarageLogic.Utils;

    public class LicenceComponent : Component
    {
        private readonly eLicenceType r_Licence;
        
        public LicenceComponent(eLicenceType i_Value)
        {
            r_Licence = i_Value;
            m_ComponentType = eComponentType.LicenceComponent;
        }

        public override string ToString()
        {
            return "Licence Type: " + Converter.StringFromType(r_Licence);
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