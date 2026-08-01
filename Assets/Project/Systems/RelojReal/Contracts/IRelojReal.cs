namespace MonteAdentro.Systems.RelojReal.Contracts
{
    public interface IRelojReal
    {
        Phase CurrentPhase { get; }

        void RequestAdvanceTo(float targetGameMinutes);
    }
}
