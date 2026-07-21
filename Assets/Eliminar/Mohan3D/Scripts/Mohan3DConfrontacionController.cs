// PROTOTYPE - NOT FOR PRODUCTION
// Question: ¿Se siente como una confrontación real caminar en 3D hacia el Mohán y los NPCs, comparado con la secuencia de UI pura?
// Date: 2026-07-21
//
// Reutiliza el estado y las 7 ramas de resultado de
// Assets/Prototypes/MohanCuadernoUnity/Scripts/MohanCuadernoPrototypeController.cs
// (caso "El pacto del vado", texto copiado literal de
// prototypes/mohan-confrontacion-concept/prototype.html) con una capa de
// presentación distinta: IMGUI en vez de UI Toolkit, y SIN la pantalla de
// pistas/hipótesis inicial -- en este prototipo esa parte la cubre caminar y
// hablar con los NPCs en el mundo 3D (ver Mohan3DInteractionZone.cs), no una
// pantalla de texto. La lógica de branching en sí (ConfirmarOfrenda) no se
// reescribió, solo se portó de VisualElement/UXML a GUILayout.

using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Mohan3DConfrontacionController : MonoBehaviour
{
    private enum Pantalla { Inactivo, Aproximacion, Transgresion, Ofrenda, Tentacion, Prediccion, Resultado, Fin }

    [Serializable]
    private class Decision
    {
        public string paso;
        public string valor;
        public int t_ms;
    }

    public event Action OnConfrontacionTerminada;

    private Pantalla pantalla = Pantalla.Inactivo;
    private float tiempoInicio;
    private string prediccion = "";
    private string reflexion = "";
    private string reaccionLlevas = "";
    private string reaccionHaces = "";
    private string textoResultado = "";
    private Vector2 scrollPos;

    private readonly List<Decision> decisiones = new List<Decision>();
    private readonly Dictionary<string, int> cambiosDeSeleccion = new Dictionary<string, int>();
    private readonly Dictionary<string, string> seleccionesActuales = new Dictionary<string, string>();

    private static readonly Dictionary<string, Dictionary<string, string>> Reacciones =
        new Dictionary<string, Dictionary<string, string>>
        {
            ["llevas"] = new Dictionary<string, string>
            {
                ["tabaco"] = "\"Eso ya me lo esperaba de usted.\"",
                ["oro"] = "\"Muchos traen cosas brillantes cuando no saben bien qué es lo que deben.\"",
                ["rosario"] = "El agua se aquieta de golpe. \"Baje eso. Aquí no se reza, se negocia.\""
            },
            ["haces"] = new Dictionary<string, string>
            {
                ["aurelio_canal"] = "\"Ese nombre sí me suena a quien tiene cuentas conmigo.\"",
                ["corregidor_canal"] = "\"El corregidor no represó nada. ¿Por qué habla él y no quien lo hizo?\"",
                ["jugador_canal"] = "\"Usted no tiene cuentas conmigo por esa represa, que yo sepa.\"",
                ["renuncia_pesca"] = "El Mohán ladea la cabeza. \"Eso no es lo que está roto.\""
            }
        };

    public void Iniciar()
    {
        if (pantalla != Pantalla.Inactivo) return;
        tiempoInicio = Time.realtimeSinceStartup;
        pantalla = Pantalla.Aproximacion;
    }

    private int Ahora()
    {
        return Mathf.RoundToInt((Time.realtimeSinceStartup - tiempoInicio) * 1000f);
    }

    private void Elegir(string paso, string valor)
    {
        if (seleccionesActuales.TryGetValue(paso, out var anterior) && anterior != valor)
        {
            cambiosDeSeleccion[paso] = cambiosDeSeleccion.TryGetValue(paso, out var n) ? n + 1 : 1;
        }
        seleccionesActuales[paso] = valor;
        decisiones.Add(new Decision { paso = paso, valor = valor, t_ms = Ahora() });
    }

    private string ObtenerSeleccion(string paso)
    {
        return seleccionesActuales.TryGetValue(paso, out var v) ? v : "";
    }

    // ---- Las 7 ramas de resultado, idénticas a MohanCuadernoPrototypeController.ConfirmarOfrenda() ----
    private void ConfirmarOfrenda()
    {
        decisiones.Add(new Decision
        {
            paso = "prediccion_registrada",
            valor = string.IsNullOrEmpty(prediccion) ? "vacia" : "con_texto",
            t_ms = Ahora()
        });

        string llevas = ObtenerSeleccion("llevas");
        string haces = ObtenerSeleccion("haces");
        string transgresion = ObtenerSeleccion("transgresion");
        string aproximacion = ObtenerSeleccion("aproximacion");
        string tentacion = ObtenerSeleccion("tentacion");
        bool tonoDominante = aproximacion == "dominante";

        if (llevas == "rosario")
        {
            textoResultado = "Apenas lo sacas, el agua del pozo se retira como si la hubieras quemado. \"Eso no se trae aquí\", dice algo que ya no suena a negociación. "
                + "El pozo queda en silencio. Sea lo que sea que traías para ofrecer, ya no importa — te fuiste sin trato.";
        }
        else if (tentacion == "aceptar")
        {
            textoResultado = "Aceptas. Esta noche hay pescado en todas las mesas, y el pueblo te lo agradece en voz alta. "
                + "Pero el canal represado sigue igual bajo el agua quieta, y algo en el silencio del Mohán te dice que esta cuenta no está cerrada — solo aplazada.";
        }
        else if (transgresion != "represo")
        {
            textoResultado = (tonoDominante
                ? "Presentas tu exigencia. El Mohán te escucha sin interrumpir, y acepta lo que traes sin decir palabra. "
                : "Presentas tu ofrenda con convicción. El Mohán la recibe en silencio. ")
                + "El pozo vuelve a quedar en calma. Pasan los días y las redes de Efraín siguen llenas, las de los demás siguen vacías. Nada cambió realmente.";
        }
        else if (llevas == "oro")
        {
            textoResultado = "El Mohán mira las monedas con algo parecido a la curiosidad, y las toma. Pero desde ese día, cada vez que alguien cruza el vado, "
                + "algo parece esperar más plata — fijaste un precio nuevo sin darte cuenta, y ahora te lo van a cobrar siempre.";
        }
        else if (haces == "aurelio_canal")
        {
            textoResultado = "Don Aurelio abre el canal con sus propias manos, refunfuñando" + (tonoDominante ? " y mirándote con desconfianza" : "") + ". El agua vuelve a moverse por su cauce viejo. "
                + "Esa misma noche, las redes que estaban vacías amanecen llenas. El vado, dicen los viejos, se siente distinto al cruzarlo — más liviano.";
        }
        else if (haces == "corregidor_canal" || haces == "jugador_canal")
        {
            textoResultado = "El canal se abre, y el agua vuelve a moverse. \"Entendió qué se rompió\", dice el Mohán, \"pero no de la mano de quien debía repararlo.\" "
                + "No fue suficiente — pero se nota que entendiste qué había que arreglar, no solo que había que traer algo.";
        }
        else
        {
            textoResultado = "Prometes lo que ofreces, pero el canal represado sigue exactamente igual bajo el agua quieta. "
                + "El Mohán acepta tu palabra sin comprometerse a nada — no era eso lo que había que reparar.";
        }

        pantalla = Pantalla.Resultado;
    }

    private void Terminar()
    {
        decisiones.Add(new Decision
        {
            paso = "reflexion_registrada",
            valor = string.IsNullOrEmpty(reflexion) ? "vacia" : "con_texto",
            t_ms = Ahora()
        });

        var sb = new StringBuilder();
        sb.AppendLine("REGISTRO DE SESIÓN 3D (solo para análisis del diseñador -- no se le muestra al jugador durante la partida)");
        sb.AppendLine();
        sb.AppendLine($"duracion_total_seg: {Mathf.RoundToInt(Ahora() / 1000f)}");
        sb.AppendLine("orden_de_decisiones:");
        foreach (var d in decisiones)
        {
            sb.AppendLine($"  - paso: {d.paso}, valor: {d.valor}, t_ms: {d.t_ms}");
        }
        sb.AppendLine("cambios_de_seleccion_antes_de_confirmar:");
        if (cambiosDeSeleccion.Count == 0)
        {
            sb.AppendLine("  (ninguno)");
        }
        else
        {
            foreach (var kv in cambiosDeSeleccion)
            {
                sb.AppendLine($"  - {kv.Key}: {kv.Value}");
            }
        }
        sb.AppendLine($"prediccion_previa_a_confirmar: {prediccion}");
        sb.AppendLine($"reflexion_posterior_al_resultado: {reflexion}");
        sb.AppendLine("nota: Comparar transgresion elegida vs. prediccion vs. reflexion final muestra si hubo evolución real de teoría o solo aprendizaje por respuesta.");

        Debug.Log(sb.ToString());

        pantalla = Pantalla.Fin;
        OnConfrontacionTerminada?.Invoke();
    }

    private void OnGUI()
    {
        if (pantalla == Pantalla.Inactivo) return;

        Mohan3DGuiEstilos.Inicializar();

        if (pantalla == Pantalla.Fin)
        {
            DibujarBannerFin();
            return;
        }

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Mohan3DGuiEstilos.FondoPantalla);

        float ancho = Mathf.Min(720, Screen.width - 80);
        float alto = Mathf.Min(560, Screen.height - 80);
        float x = (Screen.width - ancho) / 2f;
        float y = (Screen.height - alto) / 2f;

        GUI.Box(new Rect(x, y, ancho, alto), GUIContent.none, Mohan3DGuiEstilos.Caja);
        GUILayout.BeginArea(new Rect(x + 24, y + 20, ancho - 48, alto - 40));
        scrollPos = GUILayout.BeginScrollView(scrollPos);
        DibujarPantallaActual();
        GUILayout.EndScrollView();
        GUILayout.EndArea();
    }

    private void DibujarPantallaActual()
    {
        switch (pantalla)
        {
            case Pantalla.Aproximacion: DibujarAproximacion(); break;
            case Pantalla.Transgresion: DibujarTransgresion(); break;
            case Pantalla.Ofrenda: DibujarOfrenda(); break;
            case Pantalla.Tentacion: DibujarTentacion(); break;
            case Pantalla.Prediccion: DibujarPrediccion(); break;
            case Pantalla.Resultado: DibujarResultado(); break;
        }
    }

    private void DibujarAproximacion()
    {
        GUILayout.Label("La aproximación", Mohan3DGuiEstilos.Titulo);
        GUILayout.Label("Paso 1 de 3", Mohan3DGuiEstilos.Texto);
        GUILayout.Label("El agua del pozo se encrespa sin viento. Algo te mira desde el fondo. ¿Cómo te presentas?", Mohan3DGuiEstilos.Texto);

        if (GUILayout.Button("\"Vengo a exigir que sueltes el río de una vez.\"", Mohan3DGuiEstilos.Boton))
        { Elegir("aproximacion", "dominante"); pantalla = Pantalla.Transgresion; }
        if (GUILayout.Button("\"Vengo a entender qué fue lo que se rompió.\"", Mohan3DGuiEstilos.Boton))
        { Elegir("aproximacion", "negociadora"); pantalla = Pantalla.Transgresion; }
        if (GUILayout.Button("\"Traigo algo conmigo, porque sé que aquí se debe algo.\"", Mohan3DGuiEstilos.Boton))
        { Elegir("aproximacion", "ritual"); pantalla = Pantalla.Transgresion; }
    }

    private void DibujarTransgresion()
    {
        GUILayout.Label("Nombrar la transgresión", Mohan3DGuiEstilos.Titulo);
        GUILayout.Label("Paso 2 de 3", Mohan3DGuiEstilos.Texto);
        GUILayout.Label("El Mohán se acomoda en la piedra, sin prisa. \"Vienes a pedirme que arregle algo. Pero todavía no me has dicho qué fue lo que se rompió.\"", Mohan3DGuiEstilos.Texto);
        GUILayout.Label("¿Cómo respondes?", Mohan3DGuiEstilos.Texto);

        if (GUILayout.Button("\"El río no está enfermo. Alguien le cambió el camino.\"", Mohan3DGuiEstilos.Boton))
        { Elegir("transgresion", "represo"); pantalla = Pantalla.Ofrenda; }
        if (GUILayout.Button("\"Alguien sacó del agua más de lo que le tocaba.\"", Mohan3DGuiEstilos.Boton))
        { Elegir("transgresion", "pesco"); pantalla = Pantalla.Ofrenda; }
        if (GUILayout.Button("\"No hay deuda aquí. Solo mala suerte del clima.\"", Mohan3DGuiEstilos.Boton))
        { Elegir("transgresion", "creciente"); pantalla = Pantalla.Ofrenda; }
        if (GUILayout.Button("\"Esto no es cosa suya. Es envidia de la gente, no del río.\"", Mohan3DGuiEstilos.Boton))
        { Elegir("transgresion", "envidia"); pantalla = Pantalla.Ofrenda; }
    }

    private void DibujarOfrenda()
    {
        GUILayout.Label("Preparar el encuentro", Mohan3DGuiEstilos.Titulo);
        GUILayout.Label("Paso 3 de 3", Mohan3DGuiEstilos.Texto);
        GUILayout.Label("\"Bien\", dice el Mohán. \"Entonces muéstreme qué trae, y qué piensa hacer con lo que me debe.\"", Mohan3DGuiEstilos.Texto);

        GUILayout.Space(8);
        GUILayout.Label("¿Qué llevas contigo?", Mohan3DGuiEstilos.Texto);
        if (GUILayout.Button("Tabaco mascado y un chorro de aguardiente, reunidos en el pueblo", Mohan3DGuiEstilos.Boton))
        { Elegir("llevas", "tabaco"); reaccionLlevas = Reacciones["llevas"]["tabaco"]; }
        if (GUILayout.Button("Unas monedas de plata, por si hay que pagar bien", Mohan3DGuiEstilos.Boton))
        { Elegir("llevas", "oro"); reaccionLlevas = Reacciones["llevas"]["oro"]; }
        if (GUILayout.Button("Un rosario bendecido, por si hay que protegerte", Mohan3DGuiEstilos.Boton))
        { Elegir("llevas", "rosario"); reaccionLlevas = Reacciones["llevas"]["rosario"]; }
        if (!string.IsNullOrEmpty(reaccionLlevas))
        {
            GUILayout.Label(reaccionLlevas, Mohan3DGuiEstilos.Texto);
        }

        GUILayout.Space(14);
        GUILayout.Label("¿Qué haces con el problema del río?", Mohan3DGuiEstilos.Texto);
        if (GUILayout.Button("Vas con don Aurelio hasta el canal y lo convences de abrirlo con sus propias manos", Mohan3DGuiEstilos.Boton))
        { Elegir("haces", "aurelio_canal"); reaccionHaces = Reacciones["haces"]["aurelio_canal"]; }
        if (GUILayout.Button("Le pides al corregidor que ordene abrir el canal por decreto", Mohan3DGuiEstilos.Boton))
        { Elegir("haces", "corregidor_canal"); reaccionHaces = Reacciones["haces"]["corregidor_canal"]; }
        if (GUILayout.Button("Abres tú mismo una brecha en la represa esa misma noche", Mohan3DGuiEstilos.Boton))
        { Elegir("haces", "jugador_canal"); reaccionHaces = Reacciones["haces"]["jugador_canal"]; }
        if (GUILayout.Button("Prometes que nadie volverá a pescar en el pozo hondo", Mohan3DGuiEstilos.Boton))
        { Elegir("haces", "renuncia_pesca"); reaccionHaces = Reacciones["haces"]["renuncia_pesca"]; }
        if (!string.IsNullOrEmpty(reaccionHaces))
        {
            GUILayout.Label(reaccionHaces, Mohan3DGuiEstilos.Texto);
        }

        GUILayout.Space(14);
        bool listo = seleccionesActuales.ContainsKey("llevas") && seleccionesActuales.ContainsKey("haces");
        GUI.enabled = listo;
        if (GUILayout.Button(listo ? "Continuar" : "Continuar (elige las dos cosas primero)", Mohan3DGuiEstilos.Boton))
        {
            pantalla = Pantalla.Tentacion;
        }
        GUI.enabled = true;
    }

    private void DibujarTentacion()
    {
        GUILayout.Label("El contra-ofrecimiento", Mohan3DGuiEstilos.Titulo);
        GUILayout.Label("\"Espera\", dice el Mohán antes de sellar nada. \"Puedo darte algo ahora mismo, sin tanto trámite.\"", Mohan3DGuiEstilos.Texto);
        GUILayout.Label("\"Los pescadores tendrán comida hoy. El río seguirá represado, pero nadie pasará hambre esta semana.\"", Mohan3DGuiEstilos.Texto);

        if (GUILayout.Button("Aceptar — que coman esta semana", Mohan3DGuiEstilos.Boton))
        { Elegir("tentacion", "aceptar"); pantalla = Pantalla.Prediccion; }
        if (GUILayout.Button("Rechazar — sostener la reparación completa", Mohan3DGuiEstilos.Boton))
        { Elegir("tentacion", "rechazar"); pantalla = Pantalla.Prediccion; }
    }

    private void DibujarPrediccion()
    {
        GUILayout.Label("Antes de sellar", Mohan3DGuiEstilos.Titulo);
        GUILayout.Label("Con todo ya decidido, una última duda te detiene un momento.", Mohan3DGuiEstilos.Texto);
        GUILayout.Label("¿Crees que esto va a funcionar? ¿Por qué?", Mohan3DGuiEstilos.Texto);
        prediccion = GUILayout.TextArea(prediccion, Mohan3DGuiEstilos.AreaTexto, GUILayout.Height(80));

        if (GUILayout.Button("Presentar la ofrenda", Mohan3DGuiEstilos.Boton))
        {
            ConfirmarOfrenda();
        }
    }

    private void DibujarResultado()
    {
        GUILayout.Label("El río responde", Mohan3DGuiEstilos.Titulo);
        GUILayout.Label(textoResultado, Mohan3DGuiEstilos.Texto);

        GUILayout.Space(10);
        GUILayout.Label("Explica qué crees que quería realmente el Mohán y qué parte de tu interpretación pudo estar equivocada.", Mohan3DGuiEstilos.Texto);
        reflexion = GUILayout.TextArea(reflexion, Mohan3DGuiEstilos.AreaTexto, GUILayout.Height(80));

        if (GUILayout.Button("Terminar", Mohan3DGuiEstilos.Boton))
        {
            Terminar();
        }
    }

    private void DibujarBannerFin()
    {
        const string mensaje = "Fin del prototipo -- la confrontación terminó. Podés seguir explorando el resto del mapa.";
        var tamano = Mohan3DGuiEstilos.Texto.CalcSize(new GUIContent(mensaje));
        float ancho = Mathf.Min(tamano.x + 32, Screen.width - 40);
        float x = (Screen.width - ancho) / 2f;
        GUI.Box(new Rect(x, 16, ancho, 36), GUIContent.none, Mohan3DGuiEstilos.Caja);
        GUI.Label(new Rect(x + 16, 24, ancho - 32, 24), mensaje, Mohan3DGuiEstilos.Texto);
    }
}
