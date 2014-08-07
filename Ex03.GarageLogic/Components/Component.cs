namespace Ex03.GarageLogic.Components
{
    using Ex03.GarageLogic.Enums;

    public abstract class Component
    {
        protected eComponentType m_ComponentType;

        public abstract eComponentType Type { get; }
    }
}