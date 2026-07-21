// PROTOTYPE - NOT FOR PRODUCTION
// Question: ¿Se siente como una confrontación real caminar en 3D hacia el Mohán y los NPCs, comparado con la secuencia de UI pura?
// Date: 2026-07-21
//
// Vive en un hijo del jugador con un SphereCollider(isTrigger). Detecta
// Mohan3DInteractable cercanos y dibuja el prompt "Presiona E para hablar" +
// el panel de cita con IMGUI (sin Canvas/UGUI ni UI Toolkit para esta parte,
// ver Mohan3DGuiEstilos.cs para la justificación de esa decisión).

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mohan3DInteractionZone : MonoBehaviour
{
    public bool BloqueadoPorConfrontacion;

    private readonly List<Mohan3DInteractable> enRango = new List<Mohan3DInteractable>();
    private bool mostrandoCita;
    private string citaNombre = "";
    private string citaTexto = "";

    private void OnTriggerEnter(Collider other)
    {
        var interactable = other.GetComponent<Mohan3DInteractable>();
        if (interactable != null && !enRango.Contains(interactable))
        {
            enRango.Add(interactable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var interactable = other.GetComponent<Mohan3DInteractable>();
        if (interactable != null)
        {
            enRango.Remove(interactable);
        }
    }

    private void Update()
    {
        enRango.RemoveAll(i => i == null);

        if (BloqueadoPorConfrontacion)
        {
            return;
        }

        var kb = Keyboard.current;
        if (kb == null) return;

        if (mostrandoCita)
        {
            if (kb.eKey.wasPressedThisFrame || kb.escapeKey.wasPressedThisFrame)
            {
                mostrandoCita = false;
            }
            return;
        }

        if (enRango.Count == 0) return;

        if (kb.eKey.wasPressedThisFrame)
        {
            var masCercano = ObtenerMasCercano();
            citaNombre = masCercano.NombrePersonaje;
            citaTexto = masCercano.Cita;
            mostrandoCita = true;
        }
    }

    private Mohan3DInteractable ObtenerMasCercano()
    {
        var mejor = enRango[0];
        var mejorDist = Vector3.Distance(transform.position, mejor.transform.position);
        for (int i = 1; i < enRango.Count; i++)
        {
            var d = Vector3.Distance(transform.position, enRango[i].transform.position);
            if (d < mejorDist)
            {
                mejor = enRango[i];
                mejorDist = d;
            }
        }
        return mejor;
    }

    private void OnGUI()
    {
        if (BloqueadoPorConfrontacion) return;
        Mohan3DGuiEstilos.Inicializar();

        if (mostrandoCita)
        {
            float ancho = Mathf.Min(560, Screen.width - 80);
            float alto = 170;
            float x = (Screen.width - ancho) / 2f;
            float y = Screen.height - alto - 40;

            GUI.Box(new Rect(x, y, ancho, alto), GUIContent.none, Mohan3DGuiEstilos.Caja);
            GUILayout.BeginArea(new Rect(x + 16, y + 12, ancho - 32, alto - 24));
            GUILayout.Label(citaNombre, Mohan3DGuiEstilos.Titulo);
            GUILayout.Label(citaTexto, Mohan3DGuiEstilos.Texto);
            GUILayout.Label("(E o Esc para cerrar)", Mohan3DGuiEstilos.Texto);
            GUILayout.EndArea();
        }
        else if (enRango.Count > 0)
        {
            const string contenido = "Presiona E para hablar";
            var tamano = Mohan3DGuiEstilos.Texto.CalcSize(new GUIContent(contenido));
            float x = (Screen.width - tamano.x) / 2f - 16;
            float y = Screen.height - 90;
            GUI.Box(new Rect(x, y, tamano.x + 32, 34), GUIContent.none, Mohan3DGuiEstilos.Caja);
            GUI.Label(new Rect(x + 16, y + 7, tamano.x + 16, 24), contenido, Mohan3DGuiEstilos.Texto);
        }
    }
}
