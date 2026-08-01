namespace MonteAdentro.Systems.RelojReal.Contracts
{
    // Un sistema externo declara si "ahora mismo" hay una oportunidad real de acción,
    // para que el Avance Rápido se interrumpa ahí (Regla 6 del Reloj Real). El reloj
    // no conoce ni valida qué cuenta como interactuable — eso es responsabilidad
    // exclusiva de quien implementa esta interfaz.
    public interface IInteractableMomentSource
    {
        bool HasInteractableMomentNow();
    }
}
