using System;
using MonteAdentro.Systems.Interaction.Contracts;
using MonteAdentro.Systems.Validation.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MonteAdentro.Systems.Interaction.Runtime
{
    public class InteractionRaycaster : MonoBehaviour, IInteractionFocusSource
    {
        [SerializeField, RequiredReference] private Transform rayOrigin;
        [SerializeField, RequiredReference] private PlayerInput playerInput;
        [SerializeField] private float range = 3f;

        public event Action<string> FocusChanged;

        private InputAction interactAction;
        private IInteractable current;

        private void Awake()
        {
            interactAction = playerInput.actions["Interact"];
        }

        private void Update()
        {
            UpdateFocus();

            if (current != null && interactAction.WasPerformedThisFrame())
            {
                current.Interact();
                FocusChanged?.Invoke(current.InteractionPrompt);
            }
        }

        private void UpdateFocus()
        {
            IInteractable hit = null;

            if (Physics.Raycast(rayOrigin.position, rayOrigin.forward, out var hitInfo, range))
            {
                hit = hitInfo.collider.GetComponentInParent<IInteractable>();
            }

            if (!ReferenceEquals(hit, current))
            {
                current = hit;
                FocusChanged?.Invoke(current?.InteractionPrompt);
            }
        }
    }
}
