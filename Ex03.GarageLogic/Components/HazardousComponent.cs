namespace Ex03.GarageLogic.Components
{
    using Ex03.GarageLogic.Enums;

    public class HazardousComponent : Component
    {
        private readonly bool r_Hazardous;
        
        public HazardousComponent(bool i_Value)
        {
            r_Hazardous = i_Value;
            m_ComponentType = eComponentType.HazardousComponent;
        }

        public override string ToString()
        {
            string yesNo = r_Hazardous ? "Yes" : "No";
            return "Hazardous Material: " + yesNo;
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