// PROTOTYPE - NOT FOR PRODUCTION
// Question: ¿Se siente como una confrontación real caminar en 3D hacia el Mohán y los NPCs, comparado con la secuencia de UI pura?
// Date: 2026-07-21
//
// Arma TODA la escena por código en Awake() -- terreno, vado, NPCs, jugador,
// cámara, luz y el controlador de confrontación -- y conecta las referencias
// entre scripts directamente en C# (nunca vía Inspector/serialización de
// escena). Esto es deliberado: en el prototipo anterior
// (Assets/Prototypes/MohanCuadernoUnity) se descubrió que una referencia
// (UIDocument.panelSettings) asignada justo después de crear un asset en un
// script de Editor en modo batch no persistió al guardar la escena (ver
// memoria de unity-specialist, "project_unity-batch-mode-scene-setup.md").
// Construir todo en tiempo de ejecución evita ese riesgo por completo: la
// escena guardada en disco solo contiene este único GameObject con este único
// componente, sin referencias a assets ni a otros objetos que serializar.

using UnityEngine;

public class Mohan3DSceneBootstrap : MonoBehaviour
{
    private bool construido;

    private void Awake()
    {
        ConstruirEscena();
    }

    public void ConstruirEscena()
    {
        if (construido) return;
        construido = true;

        CrearLuz();
        CrearSuelo();
        CrearVadoYPozo();
        var confrontacion = CrearConfrontacion();
        var jugador = CrearJugador(out var zonaInteraccion);
        CrearCamara(jugador.transform);
        CrearNpcsDePistas();
        CrearMohan(confrontacion, jugador, zonaInteraccion);
    }

    private static Material CrearMaterial(Color color)
    {
        Shader shader = Shader.Find("Universal Render Pipeline/Lit");
        if (shader == null) shader = Shader.Find("Standard");
        if (shader == null) shader = Shader.Find("Diffuse");
        var mat = new Material(shader);
        if (mat.HasProperty("_BaseColor")) mat.SetColor("_BaseColor", color);
        if (mat.HasProperty("_Color")) mat.SetColor("_Color", color);
        return mat;
    }

    private void CrearLuz()
    {
        var luzGo = new GameObject("Luz Direccional");
        var luz = luzGo.AddComponent<Light>();
        luz.type = LightType.Directional;
        luz.color = new Color(1f, 0.95f, 0.85f);
        luz.intensity = 1.1f;
        luzGo.transform.rotation = Quaternion.Euler(50f, -30f, 0f);
    }

    private void CrearSuelo()
    {
        var suelo = GameObject.CreatePrimitive(PrimitiveType.Plane);
        suelo.name = "Suelo";
        suelo.transform.position = new Vector3(0f, 0f, -2f);
        suelo.transform.localScale = new Vector3(5f, 1f, 6f);
        suelo.GetComponent<Renderer>().sharedMaterial = CrearMaterial(new Color(0.29f, 0.24f, 0.14f));
    }

    private void CrearVadoYPozo()
    {
        var vado = GameObject.CreatePrimitive(PrimitiveType.Cube);
        vado.name = "Vado (franja azul)";
        vado.transform.position = new Vector3(0f, 0.03f, -8f);
        vado.transform.localScale = new Vector3(6f, 0.06f, 7f);
        vado.GetComponent<Renderer>().sharedMaterial = CrearMaterial(new Color(0.24f, 0.45f, 0.62f));
        Object.Destroy(vado.GetComponent<Collider>());

        var pozo = GameObject.CreatePrimitive(PrimitiveType.Plane);
        pozo.name = "Pozo del Mohan";
        pozo.transform.position = new Vector3(-2.5f, 0.03f, -19f);
        pozo.transform.localScale = new Vector3(0.45f, 1f, 0.45f);
        pozo.GetComponent<Renderer>().sharedMaterial = CrearMaterial(new Color(0.16f, 0.34f, 0.48f));
    }

    private Mohan3DConfrontacionController CrearConfrontacion()
    {
        var go = new GameObject("Mohan3DConfrontacion");
        return go.AddComponent<Mohan3DConfrontacionController>();
    }

    private Mohan3DPlayerController CrearJugador(out Mohan3DInteractionZone zonaInteraccion)
    {
        var go = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        go.name = "Jugador";
        go.transform.position = new Vector3(0f, 1f, 15f);
        go.GetComponent<Renderer>().sharedMaterial = CrearMaterial(new Color(0.9f, 0.9f, 0.88f));

        // El CapsuleCollider que trae el primitivo por defecto estorba con
        // CharacterController (que ya actúa como el collider de movimiento).
        Object.Destroy(go.GetComponent<CapsuleCollider>());

        var controller = go.AddComponent<CharacterController>();
        controller.center = new Vector3(0f, 1f, 0f);
        controller.height = 2f;
        controller.radius = 0.5f;

        // Rigidbody cinemático solo para garantizar que los eventos de trigger
        // (tanto los que detecta el jugador como los que lo detectan a él)
        // se disparen de forma confiable.
        var rb = go.AddComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;

        var zonaGo = new GameObject("ZonaInteraccion");
        zonaGo.transform.SetParent(go.transform, false);
        var esfera = zonaGo.AddComponent<SphereCollider>();
        esfera.isTrigger = true;
        esfera.radius = 3f;
        zonaInteraccion = zonaGo.AddComponent<Mohan3DInteractionZone>();

        var jugador = go.AddComponent<Mohan3DPlayerController>();
        return jugador;
    }

    private void CrearCamara(Transform jugador)
    {
        var camGo = new GameObject("Main Camera");
        camGo.tag = "MainCamera";
        var cam = camGo.AddComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
        cam.backgroundColor = new Color(0.6f, 0.75f, 0.85f);
        camGo.AddComponent<AudioListener>();
        var seguir = camGo.AddComponent<Mohan3DCameraFollow>();
        seguir.objetivo = jugador;
        camGo.transform.position = jugador.position + new Vector3(0f, 3.2f, -5.5f);
    }

    private void CrearNpcsDePistas()
    {
        CrearNpcPista("Tomas (pescador viejo)", new Vector3(-7f, 1f, 12f), new Color(0.42f, 0.28f, 0.16f),
            "Tomás, pescador viejo",
            "Desde hace dos semanas las redes vuelven vacías — pero no todas. La de mi compadre Efraín sigue llena, día tras día. Si fuera el río bajando parejo, nos tocaría igual a todos.");

        CrearNpcPista("Corregidor", new Vector3(7f, 1f, 12f), new Color(0.38f, 0.44f, 0.5f),
            "El corregidor",
            "Aguas abajo bajó el caudal justo cuando arriba represaron para el trapiche. Es física simple: menos agua entra, menos agua sale. No hace falta buscarle más explicación.");

        CrearNpcPista("Rosa (lavandera)", new Vector3(-7f, 1f, 5f), new Color(0.62f, 0.82f, 0.9f),
            "Rosa, lavandera",
            "El trapiche de don Aurelio represó el brazo del río hace un mes. Desde entonces el agua baja distinta más abajo del vado.");

        CrearNpcPista("Curandera", new Vector3(7f, 1f, 5f), new Color(0.5f, 0.32f, 0.58f),
            "Curandera del pueblo",
            "A la familia de Efraín le tienen envidia desde que él heredó el mejor tramo de pesca del río, el que nadie más puede tocar. La envidia también pesca redes vacías, m'hijo — no todo es cosa del agua.");

        var piedra = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        piedra.name = "Piedra del vado";
        piedra.transform.position = new Vector3(2.5f, 0.4f, -8f);
        piedra.transform.localScale = new Vector3(0.8f, 0.4f, 0.8f);
        piedra.GetComponent<Renderer>().sharedMaterial = CrearMaterial(new Color(0.45f, 0.43f, 0.4f));
        AgregarInteractable(piedra, 2f, "La piedra del vado",
            "sigue alimentada — tabaco y aguardiente frescos. Alguien en el pueblo todavía cumple la costumbre con el dueño del río.");
    }

    private void CrearNpcPista(string nombreObjeto, Vector3 posicion, Color color, string nombrePersonaje, string cita)
    {
        var go = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        go.name = nombreObjeto;
        go.transform.position = posicion;
        go.GetComponent<Renderer>().sharedMaterial = CrearMaterial(color);
        AgregarInteractable(go, 2.5f, nombrePersonaje, cita);
    }

    private void AgregarInteractable(GameObject go, float radio, string nombre, string cita)
    {
        var esfera = go.AddComponent<SphereCollider>();
        esfera.isTrigger = true;
        esfera.radius = radio;
        var interactable = go.AddComponent<Mohan3DInteractable>();
        interactable.NombrePersonaje = nombre;
        interactable.Cita = cita;
    }

    private void CrearMohan(Mohan3DConfrontacionController confrontacion, Mohan3DPlayerController jugador, Mohan3DInteractionZone zonaInteraccion)
    {
        var go = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        go.name = "El Mohan";
        go.transform.position = new Vector3(0f, 1f, -19f);
        go.GetComponent<Renderer>().sharedMaterial = CrearMaterial(new Color(0.11f, 0.32f, 0.29f));

        var esfera = go.AddComponent<SphereCollider>();
        esfera.isTrigger = true;
        esfera.radius = 4.5f;

        var trigger = go.AddComponent<Mohan3DMohanTrigger>();
        trigger.confrontacion = confrontacion;
        trigger.jugador = jugador;
        trigger.zonaInteraccion = zonaInteraccion;
    }
}
