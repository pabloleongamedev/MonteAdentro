using MonteAdentro.Systems.Validation.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MonteAdentro.Systems.PlayerController.Runtime
{
    public class FirstPersonLook : MonoBehaviour
    {
        [SerializeField, RequiredReference] private PlayerInput playerInput;
        [SerializeField, RequiredReference] private Transform cameraPivot;
        [SerializeField] private float mouseSensitivity = 0.12f;
        [SerializeField] private float minPitch = -85f;
        [SerializeField] private float maxPitch = 85f;

        private InputAction lookAction;
        private float pitch;

        private void Awake()
        {
            lookAction = playerInput.actions["Look"];
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            var delta = lookAction.ReadValue<Vector2>() * mouseSensitivity;

            transform.Rotate(Vector3.up * delta.x);

            pitch = Mathf.Clamp(pitch - delta.y, minPitch, maxPitch);
            cameraPivot.localRotation = Quaternion.Euler(pitch, 0f, 0f);
        }
    }
}
