using MonteAdentro.Systems.Interaction.Contracts;
using MonteAdentro.Systems.Validation.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace MonteAdentro.Systems.Interaction.UI
{
    public class InteractionPromptPresenter : MonoBehaviour
    {
        [SerializeField, RequiredReference] private MonoBehaviour focusSourceBehaviour; // debe implementar IInteractionFocusSource
        [SerializeField, RequiredReference] private Text promptText;

        private IInteractionFocusSource focusSource;

        private void Awake()
        {
            focusSource = focusSourceBehaviour as IInteractionFocusSource;
        }

        private void OnEnable()
        {
            if (focusSource == null)
            {
                Debug.LogWarning($"{nameof(InteractionPromptPresenter)}: focusSource no implementa IInteractionFocusSource.", this);
                return;
            }

            focusSource.FocusChanged += HandleFocusChanged;
            HandleFocusChanged(null);
        }

        private void OnDisable()
        {
            if (focusSource == null) return;
            focusSource.FocusChanged -= HandleFocusChanged;
        }

        private void HandleFocusChanged(string prompt)
        {
            var hasPrompt = !string.IsNullOrEmpty(prompt);
            promptText.gameObject.SetActive(hasPrompt);
            promptText.text = prompt;
        }
    }
}
