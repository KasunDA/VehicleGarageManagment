namespace Ex03.GarageLogic.Models
{
    using System;
    using System.Collections.Generic;

    using Ex03.GarageLogic.Enums;

    public class GarageContainer
    {
        private readonly Dictionary<string, GarageEntry> r_Entries;

        public GarageContainer()
        {
            r_Entries = new Dictionary<string, GarageEntry>();
        }

        public void AddVehicle(Contact i_Contact, Vehicle i_Vehicle)
        {
            if (r_Entries.ContainsKey(i_Vehicle.ID))
            {
                throw new ArgumentException("Vehicle with ID " + i_Vehicle.ID + "already exists");
            }

            GarageEntry entryToAdd = new GarageEntry(i_Contact, i_Vehicle);
            r_Entries.Add(i_Vehicle.ID, entryToAdd);
        }

        public Vehicle GetVehicleByID(string i_ID)
        {
            Vehicle result = null;

            if (r_Entries.ContainsKey(i_ID))
            {
                result = r_Entries[i_ID].Vehicle;
            }

            return result;
        }

        public GarageEntry GetGarageEntryByID(string i_ID)
        {
            GarageEntry result = null;

            if (r_Entries.ContainsKey(i_ID))
            {
                result = r_Entries[i_ID];
            }

            return result;
        }

        public List<string> GetVehiclesIDsListByStatus(eVehicleStatusType i_Status)
        {
            List<string> result = new List<string>();

            foreach (GarageEntry garageEntry in r_Entries.Values)
            {
                if (garageEntry.Status == i_Status)
                {
                    result.Add(garageEntry.Vehicle.ID);
                }
            }

            return result;
        }

        public List<string> GetAllVehiclesIDs()
        {
            List<string> result = new List<string>();

            foreach (GarageEntry garageEntry in r_Entries.Values)
            {
                result.Add(garageEntry.Vehicle.ID);
            }

            return result;
        }
    }
}