using System;

namespace MonteAdentro.Systems.Interaction.Contracts
{
    public interface IInteractionFocusSource
    {
        // null cuando no hay ningún IInteractable enfocado; el prompt del interactable enfocado en caso contrario.
        event Action<string> FocusChanged;
    }
}
