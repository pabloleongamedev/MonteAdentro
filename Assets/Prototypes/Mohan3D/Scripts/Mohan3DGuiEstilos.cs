// PROTOTYPE - NOT FOR PRODUCTION
// Question: ¿Se siente como una confrontación real caminar en 3D hacia el Mohán y los NPCs, comparado con la secuencia de UI pura?
// Date: 2026-07-21
//
// Utilidades IMGUI (OnGUI) compartidas para mantener la paleta "cuaderno"
// (fondo oscuro cálido, acentos ámbar, texto crema -- misma paleta que
// Assets/Prototypes/MohanCuadernoUnity/UI/MohanCuaderno.uss) consistente entre
// Mohan3DInteractionZone y Mohan3DConfrontacionController. Se eligió IMGUI en
// vez de UGUI/UI Toolkit para esta parte del prototipo para minimizar riesgo:
// el proyecto tiene el nuevo Input System como único manejador activo
// (Project Settings > Active Input Handling = "Input System Package (New)"),
// y OnGUI no depende de EventSystem/InputSystemUIInputModule para funcionar.

using UnityEngine;

public static class Mohan3DGuiEstilos
{
    public static readonly Color Fondo = new Color(27f / 255f, 23f / 255f, 18f / 255f, 0.92f);
    public static readonly Color FondoCaja = new Color(42f / 255f, 36f / 255f, 25f / 255f, 0.97f);
    public static readonly Color Ambar = new Color(201f / 255f, 138f / 255f, 60f / 255f);
    public static readonly Color Crema = new Color(232f / 255f, 221f / 255f, 200f / 255f);

    private static Texture2D fondoPantallaTex;
    private static Texture2D fondoCajaTex;
    private static Texture2D botonTex;
    private static Texture2D botonHoverTex;
    private static GUIStyle tituloStyle;
    private static GUIStyle textoStyle;
    private static GUIStyle cajaStyle;
    private static GUIStyle botonStyle;
    private static GUIStyle areaTextoStyle;
    private static bool inicializado;

    private static Texture2D CrearTextura(Color color)
    {
        var tex = new Texture2D(2, 2);
        tex.SetPixels(new[] { color, color, color, color });
        tex.Apply();
        return tex;
    }

    public static void Inicializar()
    {
        if (inicializado) return;

        fondoPantallaTex = CrearTextura(Fondo);
        fondoCajaTex = CrearTextura(FondoCaja);
        botonTex = CrearTextura(new Color(46f / 255f, 42f / 255f, 32f / 255f));
        botonHoverTex = CrearTextura(new Color(58f / 255f, 52f / 255f, 38f / 255f));

        tituloStyle = new GUIStyle(GUI.skin.label)
        {
            fontSize = 20,
            fontStyle = FontStyle.Bold,
            wordWrap = true
        };
        tituloStyle.normal.textColor = Ambar;

        textoStyle = new GUIStyle(GUI.skin.label)
        {
            fontSize = 14,
            wordWrap = true
        };
        textoStyle.normal.textColor = Crema;

        cajaStyle = new GUIStyle(GUI.skin.box);
        cajaStyle.normal.background = fondoCajaTex;

        botonStyle = new GUIStyle(GUI.skin.button)
        {
            fontSize = 13,
            wordWrap = true,
            alignment = TextAnchor.MiddleLeft,
            padding = new RectOffset(12, 12, 10, 10),
            margin = new RectOffset(0, 0, 3, 3)
        };
        botonStyle.normal.background = botonTex;
        botonStyle.normal.textColor = Crema;
        botonStyle.hover.background = botonHoverTex;
        botonStyle.hover.textColor = Crema;

        areaTextoStyle = new GUIStyle(GUI.skin.textArea)
        {
            fontSize = 13,
            wordWrap = true
        };
        areaTextoStyle.normal.background = fondoCajaTex;
        areaTextoStyle.normal.textColor = Crema;
        areaTextoStyle.focused.background = fondoCajaTex;
        areaTextoStyle.focused.textColor = Crema;

        inicializado = true;
    }

    public static Texture2D FondoPantalla { get { Inicializar(); return fondoPantallaTex; } }
    public static GUIStyle Titulo { get { Inicializar(); return tituloStyle; } }
    public static GUIStyle Texto { get { Inicializar(); return textoStyle; } }
    public static GUIStyle Caja { get { Inicializar(); return cajaStyle; } }
    public static GUIStyle Boton { get { Inicializar(); return botonStyle; } }
    public static GUIStyle AreaTexto { get { Inicializar(); return areaTextoStyle; } }
}
