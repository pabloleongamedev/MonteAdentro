// PROTOTYPE - NOT FOR PRODUCTION
// Question: ¿Se siente como una confrontación real caminar en 3D hacia el Mohán y los NPCs, comparado con la secuencia de UI pura?
// Date: 2026-07-21
//
// Al entrar en este trigger (radio grande) se activa automáticamente la
// confrontación -- no requiere presionar E, coherente con "cruzar el vado"
// como punto de no retorno hacia la secuencia de decisiones. Al terminar la
// confrontación, devuelve el control de movimiento e interacción al jugador.

using UnityEngine;

public class Mohan3DMohanTrigger : MonoBehaviour
{
    public Mohan3DConfrontacionController confrontacion;
    public Mohan3DPlayerController jugador;
    public Mohan3DInteractionZone zonaInteraccion;

    private bool activado;

    private void Start()
    {
        if (confrontacion != null)
        {
            confrontacion.OnConfrontacionTerminada += ManejarFinConfrontacion;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (activado) return;
        if (other.GetComponent<Mohan3DPlayerController>() == null) return;

        activado = true;
        if (jugador != null) jugador.movimientoHabilitado = false;
        if (zonaInteraccion != null) zonaInteraccion.BloqueadoPorConfrontacion = true;
        if (confrontacion != null) confrontacion.Iniciar();
    }

    private void ManejarFinConfrontacion()
    {
        if (jugador != null) jugador.movimientoHabilitado = true;
        if (zonaInteraccion != null) zonaInteraccion.BloqueadoPorConfrontacion = false;
    }
}
