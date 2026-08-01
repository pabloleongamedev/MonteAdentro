using MonteAdentro.Systems.Validation.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MonteAdentro.Systems.PlayerController.Runtime
{
    [RequireComponent(typeof(CharacterController))]
    public class FirstPersonMotor : MonoBehaviour
    {
        [SerializeField, RequiredReference] private PlayerInput playerInput;
        [SerializeField] private float walkSpeed = 3.5f;
        [SerializeField] private float sprintSpeed = 6f;
        [SerializeField] private float jumpHeight = 1.2f;
        [SerializeField] private float gravity = -9.81f;

        private CharacterController controller;
        private InputAction moveAction;
        private InputAction sprintAction;
        private InputAction jumpAction;
        private Vector3 verticalVelocity;
        private bool jumpRequested;

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
            moveAction = playerInput.actions["Move"];
            sprintAction = playerInput.actions["Sprint"];
            jumpAction = playerInput.actions["Jump"];
        }

        private void OnEnable()
        {
            jumpAction.performed += OnJumpPerformed;
        }

        private void OnDisable()
        {
            jumpAction.performed -= OnJumpPerformed;
        }

        private void OnJumpPerformed(InputAction.CallbackContext context)
        {
            jumpRequested = true;
        }

        private void Update()
        {
            var input = moveAction.ReadValue<Vector2>();
            var speed = sprintAction.IsPressed() ? sprintSpeed : walkSpeed;
            var move = (transform.right * input.x + transform.forward * input.y) * speed;

            if (controller.isGrounded)
            {
                verticalVelocity.y = -1f;

                if (jumpRequested)
                {
                    verticalVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                }
            }

            jumpRequested = false;

            verticalVelocity.y += gravity * Time.deltaTime;

            controller.Move((move + verticalVelocity) * Time.deltaTime);
        }
    }
}
