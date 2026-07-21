// PROTOTYPE - NOT FOR PRODUCTION
// Question: ¿Se siente como una confrontación real caminar en 3D hacia el Mohán y los NPCs, comparado con la secuencia de UI pura?
// Date: 2026-07-21
//
// Movimiento simple vía CharacterController, leyendo el nuevo Input System
// directo por dispositivo (Keyboard.current) en vez de InputActionAsset -- el
// proyecto no tiene una clase C# generada para InputSystem_Actions.inputactions,
// así que leer el teclado directo es la opción de menor riesgo para un
// prototipo desechable. Nota: Project Settings > Active Input Handling está en
// "Input System Package (New)" únicamente, por lo que UnityEngine.Input
// (legacy) no es una opción aquí.

using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Mohan3DPlayerController : MonoBehaviour
{
    public float velocidad = 5f;
    public float velocidadRotacion = 540f;
    public float gravedad = -9.81f;

    [HideInInspector] public bool movimientoHabilitado = true;

    private CharacterController controller;
    private float velocidadVertical;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (!movimientoHabilitado)
        {
            return;
        }

        var kb = Keyboard.current;
        if (kb == null) return;

        Vector2 entrada = Vector2.zero;
        if (kb.wKey.isPressed || kb.upArrowKey.isPressed) entrada.y += 1f;
        if (kb.sKey.isPressed || kb.downArrowKey.isPressed) entrada.y -= 1f;
        if (kb.aKey.isPressed || kb.leftArrowKey.isPressed) entrada.x -= 1f;
        if (kb.dKey.isPressed || kb.rightArrowKey.isPressed) entrada.x += 1f;

        Vector3 direccion = new Vector3(entrada.x, 0f, entrada.y);
        if (direccion.sqrMagnitude > 1f)
        {
            direccion.Normalize();
        }

        if (direccion.sqrMagnitude > 0.0001f)
        {
            Quaternion rotacionObjetivo = Quaternion.LookRotation(direccion, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacionObjetivo, velocidadRotacion * Time.deltaTime);
        }

        if (controller.isGrounded && velocidadVertical < 0f)
        {
            velocidadVertical = -1f;
        }
        velocidadVertical += gravedad * Time.deltaTime;

        Vector3 movimiento = direccion * velocidad;
        movimiento.y = velocidadVertical;
        controller.Move(movimiento * Time.deltaTime);
    }
}
