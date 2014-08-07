namespace Ex03.GarageLogic.Models
{
    using Ex03.GarageLogic.Enums;

    public class GarageEntry
    {
        private readonly Contact r_Contact;

        private readonly Vehicle r_Vehicle;

        private eVehicleStatusType m_Status;

        internal GarageEntry(Contact i_Contact, Vehicle i_Vehicle)
        {
            r_Contact = i_Contact;
            r_Vehicle = i_Vehicle;
            m_Status = eVehicleStatusType.Fixing;
        }

        public Contact Owner
        {
            get
            {
                return r_Contact;
            }
        }

        internal Vehicle Vehicle
        {
            get
            {
                return r_Vehicle;
            }
        }

        public eVehicleStatusType Status
        {
            get
            {
                return m_Status;
            }

            set
            {
                m_Status = value;
            }
        }
    }
}