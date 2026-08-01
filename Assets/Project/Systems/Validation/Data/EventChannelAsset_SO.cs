using UnityEngine;

namespace MonteAdentro.Systems.Validation.Data
{
    // Clase base marcadora: todo EventChannel_SO del proyecto hereda de acá para que
    // EventChannelRegistry_SO y su validador de Editor los puedan encontrar y agrupar
    // por tipo, sin necesitar auto-discovery de reflexión sobre nombres de clase.
    public abstract class EventChannelAsset_SO : ScriptableObject
    {
    }
}
