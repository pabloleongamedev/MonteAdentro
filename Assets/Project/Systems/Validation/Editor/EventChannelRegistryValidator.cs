using System.Linq;
using MonteAdentro.Systems.Validation.Data;
using UnityEditor;
using UnityEngine;

namespace MonteAdentro.Systems.Validation.Editor
{
    public static class EventChannelRegistryValidator
    {
        [MenuItem("Monte Adentro/Validation/Validar Event Channels")]
        public static void Validate()
        {
            var allChannels = AssetDatabase.FindAssets($"t:{nameof(EventChannelAsset_SO)}")
                .Select(AssetDatabase.GUIDToAssetPath)
                .Select(AssetDatabase.LoadAssetAtPath<EventChannelAsset_SO>)
                .Where(asset => asset != null)
                .ToList();

            var registries = AssetDatabase.FindAssets($"t:{nameof(EventChannelRegistry_SO)}")
                .Select(AssetDatabase.GUIDToAssetPath)
                .Select(AssetDatabase.LoadAssetAtPath<EventChannelRegistry_SO>)
                .Where(registry => registry != null)
                .ToList();

            var registered = registries.SelectMany(r => r.RegisteredChannels).Where(c => c != null).ToHashSet();

            var sinRegistrar = allChannels.Where(c => !registered.Contains(c)).ToList();
            foreach (var channel in sinRegistrar)
            {
                Debug.LogWarning(
                    $"EventChannel sin registrar en ningún EventChannelRegistry_SO: {AssetDatabase.GetAssetPath(channel)}",
                    channel);
            }

            var duplicados = allChannels.GroupBy(c => c.GetType()).Where(g => g.Count() > 1).ToList();
            foreach (var group in duplicados)
            {
                var paths = string.Join(", ", group.Select(AssetDatabase.GetAssetPath));
                Debug.LogError($"EventChannel duplicado: {group.Count()} assets del tipo {group.Key.Name} ({paths}).");
            }

            if (sinRegistrar.Count == 0 && duplicados.Count == 0)
            {
                Debug.Log("EventChannelRegistryValidator: todo en orden.");
            }
        }
    }
}
