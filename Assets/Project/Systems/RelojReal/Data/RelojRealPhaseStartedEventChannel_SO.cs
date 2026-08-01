using System;
using MonteAdentro.Systems.RelojReal.Contracts;
using MonteAdentro.Systems.Validation.Data;
using UnityEngine;

namespace MonteAdentro.Systems.RelojReal.Data
{
    [CreateAssetMenu(fileName = "RelojRealPhaseStartedEventChannel_SO", menuName = "Monte Adentro/Reloj Real/Phase Started Event Channel")]
    public class RelojRealPhaseStartedEventChannel_SO : EventChannelAsset_SO
    {
        public event Action<Phase> Raised;

        public void Raise(Phase phase) => Raised?.Invoke(phase);
    }
}
