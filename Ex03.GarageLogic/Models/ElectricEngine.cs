namespace Ex03.GarageLogic.Models
{
    using System.Text;

    using Ex03.GarageLogic.Enums;
    using Ex03.GarageLogic.Exceptions;

    public class ElectricEngine : Engine
    {
        public ElectricEngine(float i_CurrentEnergy, float i_MaxEnergy)
            : base(i_CurrentEnergy, i_MaxEnergy)
        {
            m_EngineType = eEngineType.Electric;
        }

        public override void FillEnergy()
        {
            if (GasStation.Instance.CurrentFuelType != null)
            {
                throw new EngineMismatchException();
            }

            GasStation.Instance.ProvideElectricity(this);
        }

        public override string ToString()
        {
            return
                new StringBuilder().AppendLine(base.ToString())
                    .AppendLine("Max Energy Hours: " + r_MaxEnergy)
                    .AppendLine("Remaining Energy Hours: " + m_AvailableEnergy)
                    .ToString();
        }
    }
}