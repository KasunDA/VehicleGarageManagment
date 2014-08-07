namespace Ex03.GarageLogic.Models
{
    using System.Text;

    public class Contact
    {
        private readonly string r_Name;

        private readonly string r_PhoneNumber;

        public Contact(string i_Name, string i_PhoneNumber)
        {
            r_Name = i_Name;
            r_PhoneNumber = i_PhoneNumber;
        }

        public string Name
        {
            get
            {
                return r_Name;
            }
        }

        public override string ToString()
        {
            return
                new StringBuilder().Append("Name: ")
                    .AppendLine(r_Name)
                    .Append("Phone: ")
                    .AppendLine(r_PhoneNumber)
                    .ToString();
        }

        public string Phone
        {
            get
            {
                return r_PhoneNumber;
            }
        }
    }
}