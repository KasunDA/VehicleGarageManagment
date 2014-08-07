namespace Ex03.GarageLogic.Models
{
    using Ex03.GarageLogic.Enums;
    using Ex03.GarageLogic.Exceptions;
    using Ex03.GarageLogic.Utils;

    public abstract class Engine
    {
        protected readonly float r_MaxEnergy;
        protected float m_AvailableEnergy;
        protected eEngineType m_EngineType;

        protected Engine(float i_currentEnergy, float i_MaxEnergy)
        {
            m_AvailableEnergy = i_currentEnergy;
            r_MaxEnergy = i_MaxEnergy;
        }

        public eEngineType Type
        {
            get
            {
                return m_EngineType;
            }
        }

        public float MaxEnergy
        {
            get
            {
                return r_MaxEnergy;
            }
        }

        public float Energy
        {
            get
            {
                return m_AvailableEnergy;
            }

            set
            {
                if (m_AvailableEnergy + value <= r_MaxEnergy)
                {
                    m_AvailableEnergy += value;
                }
                else
                {
                    throw new ValueOutOfRangeException(0.0f, MaxEnergy);
                }
            }
        }

        public abstract void FillEnergy();

        public override string ToString()
        {
            return Converter.StringFromType(m_EngineType);
        }
    }
}
