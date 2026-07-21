// PROTOTYPE - NOT FOR PRODUCTION
// Question: ¿Se siente como una confrontación real caminar en 3D hacia el Mohán y los NPCs, comparado con la secuencia de UI pura?
// Date: 2026-07-21
//
// Cámara en tercera persona simple: sigue detrás y arriba del objetivo. No usa
// Cinemachine porque el paquete no está instalado en este proyecto (ver
// Packages/manifest.json) -- suficiente para un prototipo de exploración a pie.

using UnityEngine;

public class Mohan3DCameraFollow : MonoBehaviour
{
    public Transform objetivo;
    public Vector3 offset = new Vector3(0f, 3.2f, -5.5f);
    public float suavizado = 8f;

    private void LateUpdate()
    {
        if (objetivo == null) return;

        Vector3 posicionDeseada = objetivo.position + objetivo.rotation * offset;
        transform.position = Vector3.Lerp(transform.position, posicionDeseada, 1f - Mathf.Exp(-suavizado * Time.deltaTime));

        Vector3 puntoMira = objetivo.position + Vector3.up * 1.5f;
        transform.LookAt(puntoMira);
    }
}
