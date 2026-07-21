// PROTOTYPE - NOT FOR PRODUCTION
// Question: ¿Se siente como una confrontación real caminar en 3D hacia el Mohán y los NPCs, comparado con la secuencia de UI pura?
// Date: 2026-07-21
//
// Marca un NPC u objeto del mundo como "interactuable a distancia" (las 4
// pistas-NPC + la piedra del vado). El texto es copiado literal de
// prototypes/mohan-confrontacion-concept/prototype.html.

using UnityEngine;

public class Mohan3DInteractable : MonoBehaviour
{
    public string NombrePersonaje;
    [TextArea] public string Cita;
}
