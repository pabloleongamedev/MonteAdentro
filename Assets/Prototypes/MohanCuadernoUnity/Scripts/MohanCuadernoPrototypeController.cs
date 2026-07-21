// PROTOTYPE - NOT FOR PRODUCTION
// Question: ¿Puede UI Toolkit presentar pistas + hipótesis + constructor de ofrenda de forma clara para el futuro Cuaderno del Investigador?
// Date: 2026-07-20
//
// Controlador monolítico a propósito (estándar de prototipo relajado, ver
// .claude/rules/prototype-code.md). Todo el texto de este archivo está
// copiado literal desde prototypes/mohan-confrontacion-concept/prototype.html
// (caso "El pacto del vado") — no se inventó contenido nuevo, solo se portó
// la lógica y las 7 ramas de confirmarOfrenda() de JS a C#.

using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class MohanCuadernoPrototypeController : MonoBehaviour
{
    [Serializable]
    private class Decision
    {
        public string paso;
        public string valor;
        public int t_ms;
    }

    // ---- Estado de sesión (para el log final -- análisis de diseño, no para el jugador) ----
    private float tiempoInicio;
    private string hipotesisInicial = "";
    private string prediccion = "";
    private string reflexion = "";
    private int finMs;
    private readonly List<Decision> decisiones = new List<Decision>();
    private readonly Dictionary<string, int> cambiosDeSeleccion = new Dictionary<string, int>();
    private readonly Dictionary<string, string> seleccionesActuales = new Dictionary<string, string>();

    // ---- Referencias UI ----
    private VisualElement root;
    private ScrollView scrollRoot;
    private readonly Dictionary<string, VisualElement> pantallas = new Dictionary<string, VisualElement>();

    private TextField campoHipotesis;
    private TextField campoPrediccion;
    private TextField campoReflexion;
    private TextField campoLog;

    private Label reaccionLlevas;
    private Label reaccionHaces;
    private Button btnContinuarOfrenda;
    private Label labelTextoResultado;

    // Reacciones diegéticas del Mohán -- feedback de personaje, nunca "correcto/incorrecto"
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

    // Placeholder manual: UI Toolkit TextField no tiene hint-text nativo.
    private readonly Dictionary<TextField, string> placeholders = new Dictionary<TextField, string>();
    private readonly HashSet<TextField> mostrandoPlaceholder = new HashSet<TextField>();

    private void OnEnable()
    {
        tiempoInicio = Time.realtimeSinceStartup;

        var uiDocument = GetComponent<UIDocument>();
        root = uiDocument.rootVisualElement;
        scrollRoot = root.Q<ScrollView>("scroll-root");

        CachearPantallas();
        PoblarCabecera();
        PoblarPantallaPistas();
        PoblarPantallaAproximacion();
        PoblarPantallaTransgresion();
        PoblarPantallaOfrenda();
        PoblarPantallaTentacion();
        PoblarPantallaPrediccion();
        PoblarPantallaResultado();
        PoblarPantallaFin();

        MostrarPantalla("pistas");
    }

    private int Ahora()
    {
        return Mathf.RoundToInt((Time.realtimeSinceStartup - tiempoInicio) * 1000f);
    }

    private void CachearPantallas()
    {
        string[] ids = { "pistas", "aproximacion", "transgresion", "ofrenda", "tentacion", "prediccion", "resultado", "fin" };
        foreach (var id in ids)
        {
            pantallas[id] = root.Q<VisualElement>("pantalla-" + id);
        }
    }

    private void MostrarPantalla(string id)
    {
        foreach (var kv in pantallas)
        {
            kv.Value.style.display = kv.Key == id ? DisplayStyle.Flex : DisplayStyle.None;
        }
        if (scrollRoot != null)
        {
            scrollRoot.scrollOffset = Vector2.zero;
        }
    }

    // ---- Poblado de contenido (todo el texto vive aquí, copiado del HTML) ----

    private void PoblarCabecera()
    {
        root.Q<Label>("label-titulo-caso").text = "El pacto del vado";
        root.Q<Label>("label-subtitulo-caso").text =
            "Prototipo desechable — Sistema de Confrontación de Ingenio, instancia del Mohán.";
    }

    private void PoblarPantallaPistas()
    {
        root.Q<Label>("label-pistas-titulo").text = "Lo que sabes";

        var contenedor = root.Q<VisualElement>("container-pistas");
        var pistas = new (string autor, string texto)[]
        {
            ("Tomás, pescador viejo:", "Desde hace dos semanas las redes vuelven vacías — pero no todas. La de mi compadre Efraín sigue llena, día tras día. Si fuera el río bajando parejo, nos tocaría igual a todos."),
            ("El corregidor:", "Aguas abajo bajó el caudal justo cuando arriba represaron para el trapiche. Es física simple: menos agua entra, menos agua sale. No hace falta buscarle más explicación."),
            ("Rosa, lavandera:", "El trapiche de don Aurelio represó el brazo del río hace un mes. Desde entonces el agua baja distinta más abajo del vado."),
            ("Curandera del pueblo:", "A la familia de Efraín le tienen envidia desde que él heredó el mejor tramo de pesca del río, el que nadie más puede tocar. La envidia también pesca redes vacías, m'hijo — no todo es cosa del agua."),
            ("La piedra del vado:", "sigue alimentada — tabaco y aguardiente frescos. Alguien en el pueblo todavía cumple la costumbre con el dueño del río.")
        };
        foreach (var (autor, texto) in pistas)
        {
            var label = new Label($"<b>{autor}</b> {texto}") { enableRichText = true };
            label.AddToClassList("pista");
            contenedor.Add(label);
        }

        root.Q<Label>("label-pistas-intro").text =
            "Es el crepúsculo. Antes de cruzar el vado, te detienes un momento a pensar en lo que ya sabes.";
        root.Q<Label>("label-pistas-pregunta").text =
            "¿Qué crees que está pasando, en una frase? (no hay respuesta incorrecta todavía — es solo tu primera impresión)";

        campoHipotesis = root.Q<TextField>("campo-hipotesis");
        ConfigurarPlaceholder(campoHipotesis, "Escribe tu primera impresión...");

        var btn = root.Q<Button>("btn-cruzar-vado");
        btn.text = "Cruzar el vado";
        btn.clicked += RegistrarHipotesisInicial;
    }

    private void PoblarPantallaAproximacion()
    {
        root.Q<Label>("label-aprox-titulo").text = "La aproximación";
        root.Q<Label>("label-aprox-paso").text = "Paso 1 de 3";
        root.Q<Label>("label-aprox-texto").text =
            "El agua del pozo se encrespa sin viento. Algo te mira desde el fondo. ¿Cómo te presentas?";

        var contenedor = root.Q<VisualElement>("container-aproximacion");
        var opciones = new (string id, string texto)[]
        {
            ("dominante", "\"Vengo a exigir que sueltes el río de una vez.\""),
            ("negociadora", "\"Vengo a entender qué fue lo que se rompió.\""),
            ("ritual", "\"Traigo algo conmigo, porque sé que aquí se debe algo.\"")
        };
        foreach (var (id, texto) in opciones)
        {
            CrearBotonOpcion(contenedor, texto, "aproximacion", id);
        }
    }

    private void PoblarPantallaTransgresion()
    {
        root.Q<Label>("label-trans-titulo").text = "Nombrar la transgresión";
        root.Q<Label>("label-trans-paso").text = "Paso 2 de 3";
        root.Q<Label>("label-trans-dialogo").text =
            "El Mohán se acomoda en la piedra, sin prisa. \"Vienes a pedirme que arregle algo. Pero todavía no me has dicho qué fue lo que se rompió.\"";
        root.Q<Label>("label-trans-pregunta").text = "¿Cómo respondes?";

        var contenedor = root.Q<VisualElement>("container-transgresion");
        var opciones = new (string id, string texto)[]
        {
            ("represo", "\"El río no está enfermo. Alguien le cambió el camino.\""),
            ("pesco", "\"Alguien sacó del agua más de lo que le tocaba.\""),
            ("creciente", "\"No hay deuda aquí. Solo mala suerte del clima.\""),
            ("envidia", "\"Esto no es cosa suya. Es envidia de la gente, no del río.\"")
        };
        foreach (var (id, texto) in opciones)
        {
            CrearBotonOpcion(contenedor, texto, "transgresion", id);
        }
    }

    private void PoblarPantallaOfrenda()
    {
        root.Q<Label>("label-ofrenda-titulo").text = "Preparar el encuentro";
        root.Q<Label>("label-ofrenda-paso").text = "Paso 3 de 3";
        root.Q<Label>("label-ofrenda-dialogo").text =
            "\"Bien\", dice el Mohán. \"Entonces muéstreme qué trae, y qué piensa hacer con lo que me debe.\"";

        root.Q<Label>("label-llevas-pregunta").text = "¿Qué llevas contigo?";
        var contenedorLlevas = root.Q<VisualElement>("container-llevas");
        var opcionesLlevas = new (string id, string texto)[]
        {
            ("tabaco", "Tabaco mascado y un chorro de aguardiente, reunidos en el pueblo"),
            ("oro", "Unas monedas de plata, por si hay que pagar bien"),
            ("rosario", "Un rosario bendecido, por si hay que protegerte")
        };
        foreach (var (id, texto) in opcionesLlevas)
        {
            CrearBotonOpcion(contenedorLlevas, texto, "llevas", id);
        }
        reaccionLlevas = root.Q<Label>("label-reaccion-llevas");

        root.Q<Label>("label-haces-pregunta").text = "¿Qué haces con el problema del río?";
        var contenedorHaces = root.Q<VisualElement>("container-haces");
        var opcionesHaces = new (string id, string texto)[]
        {
            ("aurelio_canal", "Vas con don Aurelio hasta el canal y lo convences de abrirlo con sus propias manos"),
            ("corregidor_canal", "Le pides al corregidor que ordene abrir el canal por decreto"),
            ("jugador_canal", "Abres tú mismo una brecha en la represa esa misma noche"),
            ("renuncia_pesca", "Prometes que nadie volverá a pescar en el pozo hondo")
        };
        foreach (var (id, texto) in opcionesHaces)
        {
            CrearBotonOpcion(contenedorHaces, texto, "haces", id);
        }
        reaccionHaces = root.Q<Label>("label-reaccion-haces");

        btnContinuarOfrenda = root.Q<Button>("btn-continuar-ofrenda");
        btnContinuarOfrenda.text = "Continuar (elige las dos cosas primero)";
        btnContinuarOfrenda.SetEnabled(false);
        btnContinuarOfrenda.clicked += () => MostrarPantalla("tentacion");
    }

    private void PoblarPantallaTentacion()
    {
        root.Q<Label>("label-tent-titulo").text = "El contra-ofrecimiento";
        root.Q<Label>("label-tent-dialogo").text =
            "\"Espera\", dice el Mohán antes de sellar nada. \"Puedo darte algo ahora mismo, sin tanto trámite.\"";
        root.Q<Label>("label-tent-oferta").text =
            "\"Los pescadores tendrán comida hoy. El río seguirá represado, pero nadie pasará hambre esta semana.\"";

        var contenedor = root.Q<VisualElement>("container-tentacion");
        CrearBotonOpcion(contenedor, "Aceptar — que coman esta semana", "tentacion", "aceptar");
        CrearBotonOpcion(contenedor, "Rechazar — sostener la reparación completa", "tentacion", "rechazar");
    }

    private void PoblarPantallaPrediccion()
    {
        root.Q<Label>("label-pred-titulo").text = "Antes de sellar";
        root.Q<Label>("label-pred-intro").text = "Con todo ya decidido, una última duda te detiene un momento.";
        root.Q<Label>("label-pred-pregunta").text = "¿Crees que esto va a funcionar? ¿Por qué?";

        campoPrediccion = root.Q<TextField>("campo-prediccion");
        ConfigurarPlaceholder(campoPrediccion, "Escribe tu respuesta antes de continuar...");

        var btn = root.Q<Button>("btn-presentar-ofrenda");
        btn.text = "Presentar la ofrenda";
        btn.clicked += ConfirmarOfrenda;
    }

    private void PoblarPantallaResultado()
    {
        root.Q<Label>("label-result-titulo").text = "El río responde";
        labelTextoResultado = root.Q<Label>("label-texto-resultado");
        root.Q<Label>("label-reflexion-pregunta").text =
            "Explica qué crees que quería realmente el Mohán y qué parte de tu interpretación pudo estar equivocada.";

        campoReflexion = root.Q<TextField>("campo-reflexion");
        ConfigurarPlaceholder(campoReflexion, "Escribe tu respuesta...");

        var btn = root.Q<Button>("btn-terminar");
        btn.text = "Terminar";
        btn.clicked += TerminarSesion;
    }

    private void PoblarPantallaFin()
    {
        root.Q<Label>("label-fin-titulo").text = "Fin del prototipo";
        root.Q<Label>("label-fin-texto").text =
            "Gracias por jugar. Esto es todo lo que hay — no hay más casos, no hay más mitos todavía.";

        campoLog = root.Q<TextField>("campo-log");
        campoLog.isReadOnly = true;
    }

    // ---- Placeholder manual para TextField ----

    private void ConfigurarPlaceholder(TextField campo, string textoPlaceholder)
    {
        placeholders[campo] = textoPlaceholder;
        campo.SetValueWithoutNotify(textoPlaceholder);
        campo.AddToClassList("placeholder-activo");
        mostrandoPlaceholder.Add(campo);

        campo.RegisterCallback<FocusInEvent>(_ =>
        {
            if (mostrandoPlaceholder.Contains(campo))
            {
                campo.SetValueWithoutNotify("");
                campo.RemoveFromClassList("placeholder-activo");
                mostrandoPlaceholder.Remove(campo);
            }
        });
        campo.RegisterCallback<FocusOutEvent>(_ =>
        {
            if (string.IsNullOrEmpty(campo.value))
            {
                campo.SetValueWithoutNotify(placeholders[campo]);
                campo.AddToClassList("placeholder-activo");
                mostrandoPlaceholder.Add(campo);
            }
        });
    }

    private string ObtenerValorReal(TextField campo)
    {
        if (campo == null) return "";
        return mostrandoPlaceholder.Contains(campo) ? "" : campo.value;
    }

    // ---- Lógica de opciones (equivalente a elegir() en el HTML) ----

    private Button CrearBotonOpcion(VisualElement contenedor, string texto, string paso, string valor)
    {
        var boton = new Button { text = texto };
        boton.AddToClassList("opcion-boton");
        boton.clicked += () => Elegir(paso, valor, boton, contenedor);
        contenedor.Add(boton);
        return boton;
    }

    private void Elegir(string paso, string valor, Button boton, VisualElement grupo)
    {
        if (seleccionesActuales.TryGetValue(paso, out var anterior) && anterior != valor)
        {
            cambiosDeSeleccion[paso] = cambiosDeSeleccion.TryGetValue(paso, out var n) ? n + 1 : 1;
        }
        seleccionesActuales[paso] = valor;
        decisiones.Add(new Decision { paso = paso, valor = valor, t_ms = Ahora() });

        if (grupo != null)
        {
            foreach (var hijo in grupo.Children())
            {
                hijo.RemoveFromClassList("seleccionado");
            }
            boton?.AddToClassList("seleccionado");
        }

        switch (paso)
        {
            case "aproximacion":
                MostrarPantalla("transgresion");
                break;
            case "transgresion":
                MostrarPantalla("ofrenda");
                break;
            case "llevas":
            case "haces":
                MostrarReaccion(paso, valor);
                ActualizarBotonContinuarOfrenda();
                break;
            case "tentacion":
                MostrarPantalla("prediccion");
                break;
        }
    }

    private void MostrarReaccion(string paso, string valor)
    {
        var label = paso == "llevas" ? reaccionLlevas : reaccionHaces;
        if (label == null) return;
        if (Reacciones.TryGetValue(paso, out var dict) && dict.TryGetValue(valor, out var texto))
        {
            label.text = texto;
            label.RemoveFromClassList("oculto");
        }
    }

    private void ActualizarBotonContinuarOfrenda()
    {
        bool listo = seleccionesActuales.ContainsKey("llevas") && seleccionesActuales.ContainsKey("haces");
        btnContinuarOfrenda.SetEnabled(listo);
        btnContinuarOfrenda.text = listo ? "Continuar" : "Continuar (elige las dos cosas primero)";
    }

    private string ObtenerSeleccion(string paso)
    {
        return seleccionesActuales.TryGetValue(paso, out var v) ? v : "";
    }

    // ---- Confirmación y las 7 ramas de resultado (portadas 1:1 desde confirmarOfrenda() del HTML) ----

    private void ConfirmarOfrenda()
    {
        prediccion = ObtenerValorReal(campoPrediccion);
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

        string resultado;

        // Rama 1: rosario -- ofrenda ofensiva, se termina la negociación de inmediato
        if (llevas == "rosario")
        {
            resultado = "Apenas lo sacas, el agua del pozo se retira como si la hubieras quemado. \"Eso no se trae aquí\", dice algo que ya no suena a negociación. "
                + "El pozo queda en silencio. Sea lo que sea que traías para ofrecer, ya no importa — te fuiste sin trato.";
        }
        // Rama 2: aceptaste la tentación -- salida fácil, deuda aplazada
        else if (tentacion == "aceptar")
        {
            resultado = "Aceptas. Esta noche hay pescado en todas las mesas, y el pueblo te lo agradece en voz alta. "
                + "Pero el canal represado sigue igual bajo el agua quieta, y algo en el silencio del Mohán te dice que esta cuenta no está cerrada — solo aplazada.";
        }
        // Rama 3: no identificaste la transgresión correcta (represo) -- nada cambia realmente
        else if (transgresion != "represo")
        {
            resultado = (tonoDominante
                ? "Presentas tu exigencia. El Mohán te escucha sin interrumpir, y acepta lo que traes sin decir palabra. "
                : "Presentas tu ofrenda con convicción. El Mohán la recibe en silencio. ")
                + "El pozo vuelve a quedar en calma. Pasan los días y las redes de Efraín siguen llenas, las de los demás siguen vacías. Nada cambió realmente.";
        }
        // Rama 4: tributo equivocado (oro) -- fija un precio nuevo sin darse cuenta
        else if (llevas == "oro")
        {
            resultado = "El Mohán mira las monedas con algo parecido a la curiosidad, y las toma. Pero desde ese día, cada vez que alguien cruza el vado, "
                + "algo parece esperar más plata — fijaste un precio nuevo sin darte cuenta, y ahora te lo van a cobrar siempre.";
        }
        // Rama 5: restitución correcta + portador correcto -- mejor final posible
        else if (haces == "aurelio_canal")
        {
            resultado = "Don Aurelio abre el canal con sus propias manos, refunfuñando" + (tonoDominante ? " y mirándote con desconfianza" : "") + ". El agua vuelve a moverse por su cauce viejo. "
                + "Esa misma noche, las redes que estaban vacías amanecen llenas. El vado, dicen los viejos, se siente distinto al cruzarlo — más liviano.";
        }
        // Rama 6: restitución correcta pero portador equivocado -- parcial
        else if (haces == "corregidor_canal" || haces == "jugador_canal")
        {
            resultado = "El canal se abre, y el agua vuelve a moverse. \"Entendió qué se rompió\", dice el Mohán, \"pero no de la mano de quien debía repararlo.\" "
                + "No fue suficiente — pero se nota que entendiste qué había que arreglar, no solo que había que traer algo.";
        }
        // Rama 7: restitución equivocada (renuncia_pesca) -- promesa vacía
        else
        {
            resultado = "Prometes lo que ofreces, pero el canal represado sigue exactamente igual bajo el agua quieta. "
                + "El Mohán acepta tu palabra sin comprometerse a nada — no era eso lo que había que reparar.";
        }

        labelTextoResultado.text = resultado;
        MostrarPantalla("resultado");
    }

    // ---- Cierre de sesión y log para el diseñador ----

    private void TerminarSesion()
    {
        reflexion = ObtenerValorReal(campoReflexion);
        finMs = Ahora();

        var sb = new StringBuilder();
        sb.AppendLine("REGISTRO DE SESIÓN (solo para análisis del diseñador -- no se le muestra al jugador durante la partida)");
        sb.AppendLine();
        sb.AppendLine($"duracion_total_seg: {Mathf.RoundToInt(finMs / 1000f)}");
        sb.AppendLine($"hipotesis_inicial: {hipotesisInicial}");
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
        sb.AppendLine("nota: Comparar hipotesis_inicial vs. transgresion elegida vs. prediccion vs. reflexion final muestra si hubo evolución real de teoría o solo aprendizaje por respuesta.");

        string log = sb.ToString();
        Debug.Log(log);

        if (campoLog != null)
        {
            campoLog.isReadOnly = false;
            campoLog.SetValueWithoutNotify(log);
            campoLog.isReadOnly = true;
        }

        MostrarPantalla("fin");
    }

    private void RegistrarHipotesisInicial()
    {
        hipotesisInicial = ObtenerValorReal(campoHipotesis);
        decisiones.Add(new Decision
        {
            paso = "hipotesis_inicial_registrada",
            valor = string.IsNullOrEmpty(hipotesisInicial) ? "vacia" : "con_texto",
            t_ms = Ahora()
        });
        MostrarPantalla("aproximacion");
    }
}
