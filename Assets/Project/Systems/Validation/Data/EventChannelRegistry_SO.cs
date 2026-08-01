using System.Collections.Generic;
using UnityEngine;

namespace MonteAdentro.Systems.Validation.Data
{
    [CreateAssetMenu(fileName = "EventChannelRegistry_SO", menuName = "Monte Adentro/Validation/Event Channel Registry")]
    public class EventChannelRegistry_SO : ScriptableObject
    {
        [SerializeField] private List<EventChannelAsset_SO> registeredChannels = new();

        public IReadOnlyList<EventChannelAsset_SO> RegisteredChannels => registeredChannels;
    }
}
