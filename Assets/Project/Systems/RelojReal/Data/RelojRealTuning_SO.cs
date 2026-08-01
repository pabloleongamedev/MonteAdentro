using UnityEngine;

namespace MonteAdentro.Systems.RelojReal.Data
{
    [CreateAssetMenu(fileName = "RelojRealTuning_SO", menuName = "Monte Adentro/Reloj Real/Tuning")]
    public class RelojRealTuning_SO : ScriptableObject
    {
        [SerializeField] private float duracionMediodia = 300f;
        [SerializeField] private float duracionTarde = 360f;
        [SerializeField] private float duracionCrepusculo = 180f;
        [SerializeField] private float duracionNoche = 420f;
        [SerializeField] private float duracionAmanecer = 180f;
        [SerializeField] private float kNormal = 1f;
        [SerializeField] private float multiplicadorRapido = 60f;

        public float KNormal => kNormal;
        public float MultiplicadorRapido => multiplicadorRapido;

        public float CicloTotal =>
            duracionMediodia + duracionTarde + duracionCrepusculo + duracionNoche + duracionAmanecer;

        // Límites de inicio de cada fase, en orden: Mediodia, Tarde, Crepusculo, Noche, Amanecer.
        public float[] LimitesOrdenados()
        {
            var limiteTarde = duracionMediodia;
            var limiteCrepusculo = limiteTarde + duracionTarde;
            var limiteNoche = limiteCrepusculo + duracionCrepusculo;
            var limiteAmanecer = limiteNoche + duracionNoche;
            return new[] { 0f, limiteTarde, limiteCrepusculo, limiteNoche, limiteAmanecer };
        }
    }
}
