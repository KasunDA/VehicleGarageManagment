namespace Ex03.GarageLogic.Models
{
    using System.Text;

    using Ex03.GarageLogic.Enums;
    using Ex03.GarageLogic.Exceptions;
    using Ex03.GarageLogic.Utils;

    public class FuelEngine : Engine
    {
        private readonly eFuelType r_FuelType;

        public FuelEngine(eFuelType i_FuelType, float i_CurrentEnergy, float i_MaxEnergy)
            : base(i_CurrentEnergy, i_MaxEnergy)
        {
            if (i_CurrentEnergy > i_MaxEnergy)
            {
                throw new ValueOutOfRangeException(0, i_MaxEnergy);
            }

            m_EngineType = eEngineType.Fuel;
            r_FuelType = i_FuelType;
        }

        public override void FillEnergy()
        {
            if (GasStation.Instance.CurrentFuelType == null)
            {
                throw new EngineMismatchException();
            }
            
            if (GasStation.Instance.CurrentFuelType != r_FuelType)
            {
                throw new FuelMismatchException(r_FuelType);
            }

            GasStation.Instance.ProvideFuel(this);
        }

        public override string ToString()
        {
            return
                new StringBuilder().AppendLine(base.ToString())
                    .AppendLine("Max Fuel in Liters: " + r_MaxEnergy)
                    .AppendLine("Remaining Liters: " + m_AvailableEnergy)
                    .AppendLine("Fuel Type: " + Converter.StringFromType(r_FuelType))
                    .ToString();
        }
    }
}
