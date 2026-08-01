using System.Collections.Generic;
using System.Linq;
using MonteAdentro.Systems.RelojReal.Contracts;
using MonteAdentro.Systems.RelojReal.Data;
using MonteAdentro.Systems.Validation.Runtime;
using UnityEngine;

namespace MonteAdentro.Systems.RelojReal.Runtime
{
    public class RelojRealService : MonoBehaviour, IRelojReal
    {
        private static readonly Phase[] PhaseOrder =
        {
            Phase.Mediodia, Phase.Tarde, Phase.Crepusculo, Phase.Noche, Phase.Amanecer
        };

        [SerializeField, RequiredReference] private RelojRealTuning_SO tuning;
        [SerializeField, RequiredReference] private RelojRealPhaseStartedEventChannel_SO phaseStartedChannel;
        [SerializeField] private List<MonoBehaviour> interactableMomentSourceBehaviours = new(); // deben implementar IInteractableMomentSource

        private readonly List<IInteractableMomentSource> interactableSources = new();
        private float tiempoJuego;
        private bool avanceRapidoActivo;
        private float destinoAvanceRapido;

        public Phase CurrentPhase { get; private set; }

        private void Awake()
        {
            interactableSources.AddRange(interactableMomentSourceBehaviours.OfType<IInteractableMomentSource>());
            CurrentPhase = CalcularFase(tiempoJuego);
        }

        public void RequestAdvanceTo(float targetGameMinutes)
        {
            if (avanceRapidoActivo) return; // AC-12: no hay reentrada de Avance Rápido
            if (targetGameMinutes <= tiempoJuego) return; // AC-10: destino = instante actual no activa Rápido

            destinoAvanceRapido = targetGameMinutes;
            avanceRapidoActivo = true;
        }

        private void Update()
        {
            var kModo = avanceRapidoActivo ? tuning.KNormal * tuning.MultiplicadorRapido : tuning.KNormal;
            var deltaJuego = Time.deltaTime * kModo;

            if (avanceRapidoActivo)
            {
                var restante = destinoAvanceRapido - tiempoJuego;
                deltaJuego = Mathf.Min(deltaJuego, restante);
            }

            AvanzarTiempo(deltaJuego);

            if (!avanceRapidoActivo) return;

            if (HayMomentoInteractuableAhora() || tiempoJuego >= destinoAvanceRapido)
            {
                avanceRapidoActivo = false; // AC-08 / AC-09: se interrumpe solo en momento interactuable o al llegar al destino
            }
        }

        private void AvanzarTiempo(float deltaJuego)
        {
            if (deltaJuego <= 0f) return; // AC-01 nunca avanza en negativo; delta 0 no dispara nada (ver AC-10)

            var anterior = tiempoJuego;
            tiempoJuego += deltaJuego;

            foreach (var fase in FasesCruzadas(anterior, tiempoJuego))
            {
                CurrentPhase = fase; // AC-11: la fase cambia y el evento se dispara antes de evaluar la interrupción

                if (phaseStartedChannel == null)
                {
                    Debug.LogWarning($"{nameof(RelojRealService)}: falta el Event Channel de transición de fase.", this);
                    continue;
                }

                phaseStartedChannel.Raise(fase);
            }
        }

        // Recorre, en orden cronológico, cada límite de fase cruzado entre "desde" y "hasta" —
        // incluye el caso de un salto que cruza varios límites o ciclos completos (AC-07).
        private IEnumerable<Phase> FasesCruzadas(float desde, float hasta)
        {
            var limites = tuning.LimitesOrdenados();
            var cicloTotal = tuning.CicloTotal;

            var cicloInicio = Mathf.FloorToInt(desde / cicloTotal);
            var cicloFin = Mathf.FloorToInt(hasta / cicloTotal);

            for (var ciclo = cicloInicio; ciclo <= cicloFin; ciclo++)
            {
                for (var i = 0; i < limites.Length; i++)
                {
                    var limiteAbsoluto = ciclo * cicloTotal + limites[i];
                    if (limiteAbsoluto > desde && limiteAbsoluto <= hasta)
                    {
                        yield return PhaseOrder[i];
                    }
                }
            }
        }

        private Phase CalcularFase(float tiempoAbsoluto)
        {
            var cicloTotal = tuning.CicloTotal;
            var posicionEnCiclo = tiempoAbsoluto % cicloTotal;
            if (posicionEnCiclo < 0f) posicionEnCiclo += cicloTotal;

            var limites = tuning.LimitesOrdenados();
            for (var i = limites.Length - 1; i >= 0; i--)
            {
                if (posicionEnCiclo >= limites[i]) return PhaseOrder[i];
            }

            return PhaseOrder[0]; // AC-02: siempre exactamente una fase, nunca queda indefinida
        }

        private bool HayMomentoInteractuableAhora()
        {
            for (var i = 0; i < interactableSources.Count; i++)
            {
                if (interactableSources[i].HasInteractableMomentNow()) return true;
            }

            return false; // AC-13: sin fuentes registradas, nunca interrumpe — el reloj sigue funcionando solo
        }
    }
}
