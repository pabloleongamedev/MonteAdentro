# Sistema de Casos

> **Status**: In Design
> **Author**: user + narrative-writer + game-designer
> **Last Updated**: 2026-07-15
> **Implements Pillar**: Los 5 pilares (es el sistema que los hace jugables en conjunto)

## Overview

El Sistema de Casos es la gramática común que estructura toda unidad de contenido investigable en Monte Adentro: un caso es una instancia de datos — un fenómeno inicial, un conjunto de hipótesis candidatas, evidencia distribuida entre testimonios y el mundo, y un estado de resolución — que el jugador atraviesa siguiendo el bucle observar → hipotetizar → buscar pruebas → preparar → confrontar. Para el jugador, un caso es la unidad narrativa y jugable completa: el momento en que se convierte en el investigador que traduce un fenómeno inexplicable en una interpretación, y donde esa interpretación — acertada o no — deja una marca permanente en el pueblo. El Sistema de Casos no define las reglas de cada mito (eso vive en el Sistema de Entidades Míticas) ni cómo se ejecuta la confrontación en sí (Sistema de Confrontación de Ingenio); define la estructura que envuelve a ambos: cómo nace un caso, cuántas hipótesis presenta, qué tipos de evidencia existen y cómo se obtienen, cuándo el jugador puede pasar de investigar a confrontar, y cómo se cierra un caso.

## Player Fantasy

Vivir un caso en Monte Adentro no es coleccionar pruebas hasta llenar una barra: es sostener varias sospechas vivas a la vez y sentir cómo un testimonio de más — una contradicción entre vecinos, un detalle que no encajaba — las reordena por completo, devolviendo a la mesa una hipótesis que ya habías descartado. La satisfacción central no es "encontrar la pista que faltaba", sino el instante en que el desorden de lo que se dice en el pueblo cuaja en una interpretación que puedes nombrar.

Pero esa interpretación no es el final: es lo que llevas contigo al actuar. La fantasía no es investigar ni hablar con la gente del pueblo — es construir una lectura del mundo con lo que tienes, y después vivir con lo que esa lectura provoca cuando actúas sobre ella, acertada o no. Cerrar un caso nunca se siente como "gané el acertijo": se siente como comprometerte con una interpretación y cargar, de ahí en adelante, con lo que hiciste creer que era verdad.

> **Nota de protección de marco**: esta fantasía — construir una interpretación y vivir con las consecuencias de actuar sobre ella — debe protegerse en el resto de este GDD. "Hipótesis" y "sospecha" en este documento se refieren siempre al proceso mental del jugador, nunca a una mecánica formal nombrada (no hay una "pizarra de sospechosos" ni un "sistema de hipótesis" como widget de UI obligatorio) — la implementación concreta de cómo se manifiesta esto en interfaz es decisión del Cuaderno del Investigador, no de esta sección.

## Detailed Design

### Core Rules

1. **Nacimiento de un caso.** Un caso nace cuando el mundo presenta un fenómeno observable sin explicación aparente — un rumor, una desaparición, un patrón de desgracia — anclado a un lugar del hub y a un momento del Reloj Real. No "empieza" con una pantalla ni un marcador de misión: nace la primera vez que el jugador entra en contacto con una de sus señales. Seguir investigando o no es decisión del jugador, pero la existencia del caso en el mundo no depende de esa decisión — el mundo no espera validación para existir. Antes de ese contacto, el caso existe como contenido latente en el mundo (una casa con un problema, un NPC con algo que contar), no como una entrada activa.

2. **El espacio de hipótesis.** Cada caso sostiene **múltiples candidatos de confusión activos al mismo tiempo** (causa natural, entidad rival de dominio compartido, agente humano, la entidad real — ver fichas de entidad). La cantidad exacta la determina el diseño de cada caso, no una regla fija de sistema — lo que el Sistema de Casos garantiza es el principio: la evidencia debe poder sostener más de una interpretación simultánea para que la Player Fantasy sea real. Un caso con una sola interpretación posible no es un caso, es una cinemática.

   *Nota de consistencia*: "candidatos de confusión" no es una lista que el sistema declare por caso — es el resultado de cruzar el conocimiento folclórico que el jugador ya tiene (de qué mitos existen en la región) con la evidencia ambigua de este caso específico. El sistema garantiza que la evidencia admite más de una lectura; no le entrega al jugador un menú de sospechosos.

3. **Tipos de evidencia.** Tres familias, nunca por tratamiento visual especial (regla heredada del Art Bible):
   - **Testimonio**: lo que dice un NPC, sesgado por quién es y qué sabe.
   - **Patrón de evento**: algo que el jugador observa por sí mismo (asimetría, regularidad, ausencia) sin que nadie se lo cuente.
   - **Rastro físico**: un detalle inspeccionable en un lugar del hub, que exige presencia física en el momento correcto del Reloj Real.

   Ninguna evidencia llega con etiqueta de "esto es importante" — la jerarquía la construye el jugador, no la interfaz.

4. **Cómo se obtiene evidencia.** Explorando el hub, hablando con NPCs, y revisitando lugares en momentos distintos del Reloj Real — varias piezas solo existen en una franja horaria específica. No hay lista de tareas: la evidencia se acumula libremente y el jugador decide cuándo "tiene suficiente".

5. **Condición para confrontar.** El jugador puede iniciar la Confrontación de Ingenio **en cualquier momento**, incluso con evidencia incompleta o nula. El juego nunca bloquea la confrontación tras un umbral de "evidencia suficiente" — eso convertiría el acto de interpretar en un trámite de checklist.

6. **Confrontar antes de tiempo.** No existe un estado de "fallo por falta de datos" distinto de una hipótesis incorrecta: presentarse con poca comprensión se trata igual que una hipótesis mal formada — el encuentro se transforma según las reglas de lo que en verdad estaba activo. No es un error especial; es arriesgarse con menos comprensión de la que se pudo tener.

7. **Comprometerse con una interpretación.** Cerrar la investigación y confrontar declara implícitamente cuál candidato el jugador cree real — pero esa declaración no es un menú aparte: ocurre a través de las decisiones tomadas durante la confrontación misma (qué prepara, cómo se aproxima, qué dice). No hay una "respuesta final" como dato separado.

8. **Cierre de un caso.** Se cierra cuando la Confrontación produce una rama de resultado terminal. El cierre siempre escribe al menos un cambio en el Estado del Mundo — nunca hay cierre neutro sin huella. Puede seguir generando evidencia y consecuencias después de cerrado, pero como semilla de un caso *distinto*, nunca como continuación del mismo.

### States and Transitions

Un caso es simple en su ciclo de vida — la complejidad vive en la evidencia y las ramas de confrontación, no en el estado del caso:

| Estado | Descripción | Entra por | Sale por |
| ---- | ---- | ---- | ---- |
| **Latente** | El fenómeno existe en el mundo (contenido diseñado: un lugar, un NPC con algo que contar) pero el jugador no lo ha tocado todavía | Definido en el diseño del caso | El jugador entra en contacto con su primera señal → **Activo** |
| **Activo** | El jugador conoce el fenómeno; puede explorar, hablar y recolectar evidencia libremente, en cualquier orden | Primer contacto (Core Rule 1) | El jugador decide iniciar la Confrontación de Ingenio, con la evidencia que tenga → **En Confrontación** |
| **En Confrontación** | El encuentro de ingenio está en curso (gobernado por el Sistema de Confrontación de Ingenio, no por este sistema) | El jugador se compromete a confrontar (Core Rule 5) | Se alcanza una rama de resultado terminal → **Resuelto** |
| **Resuelto** | El caso terminó; al menos un cambio quedó escrito en el Estado del Mundo (Core Rule 8) | Rama terminal de la Confrontación | Estado final — no hay transición de salida. Puede sembrar un caso *nuevo* (Latente), nunca reabrirse a sí mismo |

Nota deliberada: **no existe un estado de "fallo por evidencia insuficiente"**. Confrontar con poca comprensión (Core Rule 6) sigue siendo una transición normal Activo → En Confrontación; la consecuencia de haber ido mal preparado se resuelve dentro de la Confrontación misma, no como un estado distinto del caso.

### Interactions with Other Systems

Todas estas dependencias son **provisionales** — ninguno de los sistemas relacionados tiene GDD propio todavía (ver `design/gdd/systems-index.md`).

| Sistema | Dirección | Qué fluye |
| ---- | ---- | ---- |
| **Sistema de Entidades Míticas** | Upstream | Provee el conocimiento disponible sobre los mitos de la región (reglas, dominios, patrones de comportamiento, señales posibles). El Sistema de Casos usa ese conocimiento como el trasfondo de interpretaciones que el jugador *ya trae consigo* al investigar — nunca como una lista de "estas son las N hipótesis válidas de este caso". La hipótesis nace del conocimiento acumulado del jugador (por tradición oral, el Cuaderno, lo que le enseñó el pueblo) enfrentado a las pistas concretas del caso, no de una lista predefinida por el sistema. |
| **Sistema de Testimonios/Diálogo** | Upstream | Fuente primaria de evidencia tipo *Testimonio*. El Sistema de Casos no define cómo funciona una conversación — consume fragmentos ya etiquetados por NPC y por sesgo, para que el jugador pueda evaluar la fuente (Pilar 5). |
| **Reloj Real** | Upstream | Determina qué evidencia (*Patrón de evento*, *Rastro físico*) está disponible en cada franja horaria, y cuándo ciertos lugares o testimonios son accesibles. |
| **Sistema de Estado del Mundo** | Upstream y downstream | El Sistema de Casos **lee** el estado del mundo al nacer un caso (consecuencias previas que lo condicionan) y **escribe** al menos un cambio al cerrarse (Core Rule 8). |
| **Sistema de Confrontación de Ingenio** | Downstream | El Sistema de Casos entrega el estado de la investigación (evidencia recolectada, candidatos vivos) al iniciar la confrontación; recibe de vuelta una rama de resultado terminal que usa para cerrar el caso. |
| **Cuaderno del Investigador** | Downstream | Lee los datos de evidencia y candidatos activos para presentarlos al jugador. El Sistema de Casos no dicta cómo se visualiza — solo expone los datos. |

## Formulas

Este sistema no expone fórmulas numéricas de runtime por diseño — la Core Rule 5 (sin umbral de "evidencia suficiente") y la nota de protección de Player Fantasy (sin estado numérico de hipótesis) prohíben explícitamente el tipo de fórmula que normalmente vive en esta sección (daño, XP, probabilidad, puntaje de sospecha). Introducir una convertiría el proceso mental del jugador en un widget medible, exactamente lo que el diseño rechaza.

En su lugar, esta sección documenta un **invariante de diseño verificable durante la autoría de cada caso** — no una regla que el sistema valide en runtime, ni nada que el jugador perciba como número.

**Invariante de no-determinación única** (sirve a los Pilares 2 y 5): para cada candidato viable de un caso, debe existir al menos una evidencia que lo sostenga y al menos una que lo socave. Ningún candidato puede quedar con soporte total y cero contradicción (se vuelve "la respuesta obvia", violando el Pilar 5), ni con cero soporte (se vuelve descartable trivialmente, matando el "error como contenido" del Pilar 2). Esto se verifica caso por caso durante su diseño, no en el motor.

*Nota de coherencia con `/design-review`*: esta sección se considera completa, no pendiente — la ausencia de fórmulas numéricas es una decisión de diseño documentada, no un vacío. Las guías de densidad de evidencia (cuánta, de qué familias) viven en **Tuning Knobs**, no aquí, porque son parámetros ajustables por caso, no una propiedad universal del sistema.

## Edge Cases

- **Si** el jugador no interviene en un caso durante un periodo prolongado (el plazo concreto pertenece al diseño de cada caso): **entonces** el mundo continúa su curso. El conflicto alcanza una resolución sin la participación del jugador y el Estado del Mundo registra sus consecuencias permanentes. Estas consecuencias reflejan, por defecto, el peor desenlace que podía evitarse mediante la intervención del jugador, aunque un caso concreto puede definir un resultado distinto si así lo requiere su narrativa. El jugador descubre lo ocurrido a través de cambios visibles en el pueblo y de testimonios posteriores, nunca mediante una notificación de "misión fallida".

- **Si** el jugador confronta con cero evidencia recolectada: **entonces** se trata como la hipótesis menos informada posible — el encuentro procede y se transforma según cuál candidato sea realmente el activo, igual que cualquier otro intento mal informado (Core Rule 6). No existe un estado separado de "intento a ciegas".

- **Si** una misma pieza de evidencia es relevante para más de un caso Activo simultáneamente: **entonces** se registra como evidencia válida para todos los casos a los que aplica — no hay restricción de "una pista, un caso". Refuerza la coherencia del mundo: un mismo rumor puede alimentar dos sospechas distintas.

- **Si** el jugador recolecta evidencia nueva para un caso ya Resuelto: **entonces** esa evidencia no tiene efecto sobre el caso cerrado — solo puede convertirse en evidencia de un caso *nuevo* si el diseño de contenido la reutiliza explícitamente con ese propósito (Core Rule 8: un caso cerrado nunca se reabre a sí mismo).

- **Si** un caso es una reaparición de una entidad ya confrontada antes (ver notas de reaparición en las fichas de entidad): **entonces** el Sistema de Casos no reduce ni elimina candidatos de confusión por el hecho de que el jugador "ya conoce" esa entidad — el conocimiento previo puede ayudarlo o desorientarlo (por diseño), pero el sistema nunca marca automáticamente el candidato correcto como "ya sabido".

- **Si** la evidencia de un caso deja a algún candidato sin ninguna contradicción restante (violando el invariante de no-determinación única de Formulas): **entonces** esto es un fallo de autoría, no un estado válido de runtime — el caso debe rediseñarse antes de aprobarse.

## Dependencies

*Nota de alcance*: esta sección clasifica las dependencias del **sistema**, no las del contenido del MVP. Que los 3 casos actuales usen mucho testimonio es una decisión de contenido — no confundir con una restricción estructural del Sistema de Casos.

El detalle de qué datos fluyen ya vive en Detailed Design § Interactions with Other Systems; esta sección no lo repite, solo clasifica hard/soft.

| Sistema | Tipo | Por qué |
| ---- | ---- | ---- |
| Sistema de Entidades Míticas | **Hard** | Un caso necesita el conocimiento y las reglas del mito involucrado para que su evidencia y su confrontación tengan significado. |
| Reloj Real | **Hard** | Core Rule 4 ata directamente la disponibilidad de evidencia a la hora — sin reloj, la mitad de las Core Rules dejan de tener sentido. |
| Sistema de Estado del Mundo | **Hard** | Core Rule 8 exige escribir al menos un cambio al cerrar un caso — sin este sistema, el Pilar 4 (consecuencias permanentes) es imposible de cumplir. |
| Sistema de Confrontación de Ingenio | **Hard** | Un caso no puede completar su ciclo de vida (Activo → Resuelto) sin recibir una rama de resultado terminal de este sistema. |
| Sistema de Testimonios/Diálogo | **Soft** | La dependencia real del Sistema de Casos es hacia la existencia de evidencia, no hacia un tipo concreto. Los casos del MVP usan mucho testimonio por decisión de contenido, no por restricción del sistema — un caso futuro podría construirse principalmente con evidencia de observación/exploración sin este sistema. |
| Cuaderno del Investigador | **Soft** | Es presentación pura — el Sistema de Casos puede funcionar (los datos existen, un caso puede resolverse) sin ninguna interfaz que los muestre. Afecta la experiencia del jugador, no la lógica del sistema. |

## Tuning Knobs

| Knob | Qué controla | Si se pone muy bajo | Si se pone muy alto |
| ---- | ---- | ---- | ---- |
| **Cantidad de evidencia por caso** | Cuántas piezas de evidencia total tiene un caso | Imposible cumplir el invariante de no-determinación única (Formulas) — algún candidato queda sin soporte o sin contradicción | Sobrecarga cognitiva; diluye la señal real entre ruido, contradice la Player Fantasy de sostener sospechas con sentido |
| **Cobertura de familias de evidencia** | Cuántas de las 3 familias (Testimonio/Patrón/Rastro) participan en un caso | Con 1 sola familia, las otras 2 se vuelven decorativas en ese caso | No hay techo per se — forzar las 3 familias en cada pista individual es artificial; la cobertura se mide a nivel de caso |
| **Ritmo de evolución del caso** | Cuándo y cómo el mundo cambia sin esperar al jugador — tanto el tiempo hasta la resolución automática (Edge Case 1) como la velocidad con que aparecen nuevas consecuencias | Las consecuencias nunca se sienten reales a tiempo — el mundo parece estático, debilita el Pilar 4 | Se siente arbitrario y castiga al jugador que explora a su propio ritmo — cerca del anti-pilar de "¿cómo iba a adivinarlo?" |
| **Ambigüedad del caso** | Cuántas interpretaciones plausibles puede sostener el contenido diseñado — parámetro de autoría, no valor del sistema | Pocas interpretaciones plausibles → la deducción se siente obvia, débil respecto al Pilar 5 | Demasiadas interpretaciones simultáneas → sobrecarga que compite con la fantasía de sostener sospechas, no ahogarse en ellas |
| **Ventanas horarias de evidencia** | Cuánto dura la franja del Reloj Real en que una pista específica está disponible | Fuerza backtracking repetitivo que se siente como tarea, no descubrimiento | Vacía de sentido al Reloj Real como eje de diseño (Core Rule 4) |
| **Grado de contradicción entre evidencias** | Cuánto se desafían entre sí las distintas piezas de evidencia — regula la dificultad deductiva sin números visibles para el jugador | El caso se siente obvio, sin tensión interpretativa real | El jugador siente que el caso es arbitrario y que no puede construir una interpretación defendible — viola el anti-pilar de pixel-hunting/lógica arbitraria |

**Interacciones entre knobs**: *Cantidad de evidencia* y *Cobertura de familias* deben ajustarse juntos. *Ritmo de evolución* interactúa con *Ventanas horarias*: si las ventanas son angostas, el ritmo debe ser generoso. *Grado de contradicción* interactúa con *Ambigüedad del caso*: subir ambigüedad sin subir contradicción produce candidatos "flojos" fáciles de descartar por intuición, no por evidencia.

## Visual/Audio Requirements

**Principio rector de esta sección**: el Sistema de Casos no tiene lenguaje visual/sonoro propio. Toma prestado el del Art Bible (Secciones 1, 2, 3, 4) y añade dos reglas estructurales:

1. **Ningún evento de este sistema (nueva evidencia, cambio de estado, resolución) puede generar una señal exclusiva de sí mismo en el mundo.** Si una señal solo suena o aparece cuando algo "importa", ya viola el Principio 1, sin importar cuán discreta sea.
2. **El mundo nunca confirma ni desmiente una interpretación por sí mismo.** Todo cambio en el mundo debe ser consistente con múltiples lecturas hasta que el jugador decida confrontar. Incluso después de la resolución, el mundo muestra *consecuencias*, no un *veredicto*. El jugador lee el mundo; el mundo nunca lee al jugador. Esta regla protege directamente la fantasía central del juego — si el mundo empieza a "explicar" quién tenía razón mediante efectos visuales o sonoros, destruye la experiencia de interpretar.

### 1. Feedback de eventos del sistema

- **Nueva evidencia obtenida.** Cero feedback en el mundo en el momento del encuentro — ni sonido, ni animación, ni cambio de luz. El objeto/testimonio/patrón recibe exactamente el mismo tratamiento que cualquier detalle no relevante de la escena (Principio 1, Core Rule 3). La confirmación de que algo quedó registrado vive únicamente en el Cuaderno del Investigador, que el jugador consulta por decisión propia — nunca como interrupción durante la exploración (Art Bible 3.1 Nivel B, 3.3).
- **Caso Latente → Activo.** Sin anuncio, pantalla o marcador (Core Rule 1). El único rastro de esta transición es la aparición de una entrada nueva en el cuaderno, descubierta cuando el jugador lo abre.
- **Caso Resuelto (por el jugador o por abandono).** Nunca se anuncia como evento — se descubre exclusivamente por el cambio permanente que Core Rule 8 y el Principio 4 exigen dejar en el Estado del Mundo (un lugar alterado, una rutina de NPC distinta, un testimonio posterior que lo menciona). El Edge Case 1 ya establece esto para el abandono; esta sección lo extiende a **toda** resolución, no solo al abandono. Ningún resultado —favorable o desfavorable— puede usar iconografía de victoria/derrota (Principio 3): ni fanfarria, ni una "X roja", ni una pantalla de resumen triunfal.

### 2. Restricciones de estilo heredadas del Art Bible

- Ninguna pieza de evidencia recibe brillo, contorno, color especial o cambio de luz selectivo — mismo tratamiento que su categoría genérica de objeto/personaje/diálogo (Principio 1; Sección 3.4).
- Ningún evento de caso puede disparar un cambio de iluminación o ambiente propio. Los únicos cambios de luz permitidos son ambientales y uniformes, gobernados por el Reloj Real (Sección 2) — jamás selectivos sobre un objeto, NPC o lugar por ser relevante a un caso.
- Ningún evento de caso puede disparar un cambio o cue musical propio. El mood depende exclusivamente de la fase del Reloj Real en la que ocurre (Sección 2.1–2.5).
- La dirección de VO no puede diferenciar la interpretación de una línea de Testimonio relevante frente a una línea de relleno — mismo registro actoral, mismo tratamiento de mezcla.
- La resolución de un caso, favorable o desfavorable, se expresa solo como alteración material del mundo (niebla, humo, luz filtrada, desaturación, cambio de rutina) — nunca como iconografía de fracaso o éxito, y nunca como un veredicto explícito sobre si el jugador "acertó" (Principio 3; Sección 2.5b; regla estructural 2 de esta sección).
- Cualquier feedback de UI relacionado con este sistema (cuaderno, indicadores de caso) usa la paleta divergente ya fijada en 4.4 (papel envejecido/tinta, acento único desaturado de Cobre) — nunca los colores cargados de significado del mundo (Rojo Achiote, Violeta de Umbral, Azul de Vigilia).
- La UI de este sistema no usa color para decir "correcto/incorrecto" (regla dura de 4.4) — esa retroalimentación pertenece al mundo, no al cuaderno, y ni siquiera el mundo la da como veredicto explícito.

### 3. Principios del Art Bible que aplican más directamente

| Principio/Sección | Por qué aplica aquí |
| ---- | ---- |
| **Principio 1** (Sección 1) — "el indicio se integra, nunca se anuncia" | Gobierna por qué ningún evento de evidencia puede tener feedback exclusivo en el mundo. |
| **Sección 2** — luz ambiental y uniforme, nunca selectiva | Prohíbe que un cambio de estado de caso dispare iluminación propia; el Reloj Real es la única fuente de cambio lumínico. |
| **Sección 3.1 (Nivel A vs. Nivel B) y 3.3** — mundo ambiguo vs. cuaderno claro | Base estructural que permite resolver la tensión: la claridad existe, pero está confinada al espacio del cuaderno. |
| **Sección 3.4** — jerarquía de formas: interactuable sí, pista no | Refuerza que ningún objeto-evidencia puede recibir prominencia narrativa por diseño de forma. |
| **Principio 3** (Sección 1) — el fallo transforma, nunca se representa como derrota | Gobierna cómo se comunica una resolución desfavorable de caso. |
| **Principio 4** (Sección 1) — toda decisión deja huella visible | Razón por la que la resolución de caso SÍ tiene un requisito visual obligatorio (el cambio permanente en el mundo), aunque nunca como anuncio ni como veredicto. |
| **Sección 4.4** — paleta de UI divergente y regla dura anti-veredicto de color | Gobierna el vocabulario cromático permitido en el cuaderno para este sistema. |

## UI Requirements

**Principio rector**: **el Cuaderno REGISTRA y REORGANIZA, pero nunca CONCLUYE, PUNTÚA ni PRIORIZA.** La diferencia entre una herramienta que ayuda a pensar y una que piensa por el jugador no está en cuánta información muestra, sino en si *saca conclusiones*. Una "pizarra de sospechosos" es prohibida porque sintetiza (conecta evidencia→culpable, mide certeza, ordena hipótesis); un cuaderno fiel solo presenta material crudo en forma navegable y deja que la reorganización sea trabajo cognitivo del jugador — esa reorganización ES la deducción. Aplicación directa de la regla ya fijada en Visual/Audio Requirements: el Cuaderno es un espejo de lo que el jugador recogió, nunca un evaluador de lo que el jugador cree.

### 1. Qué muestra el Cuaderno de un caso activo

**Eje primario: por caso.** Cada caso es una sección con su propia firma cultural (chrome orgánico, Art Bible 3.3). Se muestra el conjunto de anotaciones recogidas, nunca un "estado de resolución".

**La unidad es la anotación atómica**: cada Testimonio, Patrón o Rastro es una entrada tal como quedó registrada, en voz descriptiva del investigador — contenido, contexto factual de adquisición (dónde, cuándo, de quién), y familia a la que pertenece (organizativo, no evaluativo).

**Tres lentes sobre la misma evidencia** (reordenamientos, nunca vistas que concluyan):
- **Cronológica** (orden en que se recogió) — vista por defecto.
- **Por familia** (Testimonio / Patrón / Rastro) — agrupación neutra.
- **Índice de menciones** — lista plana de todo nombre/lugar anotado, con enlaces a las entradas donde aparece. Es un índice de libro, no un roster de sospechosos: incluye a todos los mencionados, sin jerarquía, sin checkbox, sin marca de "descartado/sospechoso".

**Prohibiciones duras** (tan importantes como los requisitos positivos):
- Sin etiqueta de importancia/prioridad en ninguna anotación.
- Sin medidor de progreso ("3/5 pistas") — implicaría un umbral fijo, violando Core Rule 5.
- Sin estado por evidencia (resuelto/pendiente).
- Sin barra de certeza, ranking de hipótesis ni lista de sospechosos con indicadores.
- Sin "conexiones sugeridas" o conclusiones autogeneradas.
- Sin color correcto/incorrecto (Art Bible 4.4); el acento Cobre es jerárquico/estético, nunca semántico de verdad.

### 2. Cómo se accede al Cuaderno

- En cualquier momento, pausando el mundo — es un juego contemplativo sin urgencia motriz (Art Bible 3.3).
- Apertura diegética: el investigador abre físicamente su cuaderno, no un menú de sistema abstracto.
- Permanece accesible durante la Confrontación, donde cambia de rol: de archivo de lectura a herramienta de acción (ver §3).

### 3. Cómo se inicia una Confrontación

La Confrontación **no se lanza desde un botón de UI**. Cualquier botón "Confrontar" que se active al alcanzar "evidencia suficiente" viola Core Rule 5; un botón meta persistente también rompería el marco al preguntar implícitamente "¿ya lo resolviste?".

- Se inicia **diegéticamente, desde el mundo/ficción** — igual que cualquier conversación. Interactuar con un personaje relevante permite llevar el diálogo hacia la confrontación.
- La opción de tensar el diálogo hacia la confrontación está **siempre disponible** al hablar con un NPC relevante, y su disponibilidad **nunca cambia según la cantidad de evidencia** — no hay chequeo de umbral, no hay estado "gris→activo". La decisión de confrontar es juicio propio del jugador.
- La interpretación se declara **como acción, no como menú**: dentro de la confrontación, el Cuaderno se vuelve instrumento — seleccionar/citar una anotación *es* la acción que declara la lectura del jugador. No existe pantalla separada de "respuesta final".
- El resultado nunca se comunica por color/icono — el NPC reacciona en ficción; un desenlace desfavorable se expresa como alteración material del cuaderno (página arrancada, tinta corrida), per Art Bible 3.3.

### 4. Flujos de UI clave (conceptuales, no layout)

- **A. Apertura del Cuaderno** — mundo → overlay del cuaderno, pausa; transición diegética.
- **B. Navegación intra-caso** — conmutar entre las 3 lentes sobre las mismas anotaciones.
- **C. Lectura de anotación** — detalle de una entrada individual con su contexto factual.
- **D. Selector/archivo de casos** — cambiar de caso activo; casos cerrados quedan archivados sin veredicto de "acierto".
- **E. Feedback de evidencia nueva** — *requisito crítico*: idéntico para toda evidencia, sin importar su relevancia futura. Feedback uniforme = el juego nunca insinúa qué importa.
- **F. Transición a Confrontación** — desde el diálogo en el mundo, sin botón meta.
- **G. Confrontación: citar evidencia como acción** — el cuaderno como paleta de acciones; seleccionar entrada = presentarla = declarar interpretación.
- **H. Resultado de Confrontación** — expresado como alteración material del propio cuaderno, nunca iconografía de fracaso.

### Notas de handoff

- `/ux-design`: este spec define QUÉ y CÓMO se organiza; falta layout, jerarquía visual del chrome híbrido, y componentes (UI Toolkit recomendado en Unity 6.3 para runtime UI).
- `game-designer` + `narrative-writer`: el flujo G (citar evidencia como acción de diálogo en confrontación) toca mecánica de confrontación y escritura de reacciones NPC — conviene diseñarlo en conjunto con el GDD del Sistema de Confrontación de Ingenio.
- La decisión sobre una posible capa de anotación libre del jugador (ej. hilos de cordel estilo pizarra de detective) se difiere — ver Open Questions.

## Acceptance Criteria

### A. Nacimiento y cierre del caso

**AC-01 — Nacimiento por contacto, no por decisión del jugador** *(Core Rule 1)*
**GIVEN** un caso en estado Latente que el jugador aún no ha tocado
**WHEN** el jugador entra en contacto con cualquiera de sus señales iniciales (habla con el NPC asociado, entra al lugar, u observa el patrón que lo dispara) sin haber interactuado con ningún menú o confirmación de "seguir caso"
**THEN** el caso transiciona automáticamente a Activo y aparece una entrada nueva en el Cuaderno, sin popup, marcador de misión ni notificación de "nuevo objetivo"

**AC-02 — Cierre siempre escribe al Estado del Mundo** *(Core Rule 8)*
**GIVEN** un caso En Confrontación que alcanza una rama de resultado terminal
**WHEN** el caso pasa a Resuelto
**THEN** al menos un valor persistente del Estado del Mundo cambia de forma verificable comparando antes/después; un cierre sin ningún cambio en el Estado del Mundo falla esta prueba, sin excepción

**AC-03 — Abandono sin notificación de fallo** *(Edge Case 1)*
**GIVEN** un caso Activo no tocado durante el periodo definido en el diseño de ese caso
**WHEN** ese periodo expira sin intervención del jugador
**THEN** el caso se resuelve automáticamente, el Estado del Mundo registra las consecuencias, y no se muestra en ningún momento un mensaje, ícono o popup de "misión fallida"/"caso perdido"

**AC-04 — Evidencia nueva no afecta caso ya Resuelto** *(Edge Case 4)*
**GIVEN** un caso en estado Resuelto
**WHEN** el jugador obtiene una pieza de evidencia que en otro contexto sería válida para ese caso
**THEN** el caso permanece en Resuelto sin cambiar de estado ni reabrirse, y la evidencia no aparece bajo la sección archivada de ese caso salvo que el contenido la vincule explícitamente a un caso *nuevo* distinto

**AC-05 — Reaparición no marca al candidato como "ya sabido"** *(Edge Case 5)*
**GIVEN** un caso cuya entidad ya fue confrontada en un caso anterior distinto
**WHEN** el caso nuevo se activa
**THEN** ninguna anotación, ícono o etiqueta generada por el sistema distingue, revela o simplifica automáticamente la interpretación del candidato "correcto" en el índice de menciones de ese caso — el sistema nunca convierte la investigación en un ejercicio de reconocimiento ("es otra vez el Mohán") en lugar de interpretación genuina

**AC-23 — La consecuencia del abandono es visible al volver** *(Edge Case 1, complementa AC-03)*
**GIVEN** un caso que alcanzó su condición de evolución automática sin intervención del jugador
**WHEN** el jugador vuelve al lugar relacionado con ese caso
**THEN** el mundo refleja de forma observable las consecuencias de esa resolución (un NPC ausente, un lugar alterado, un testimonio que lo menciona en pasado) — sin presentar una notificación de "caso fallido" ni una pantalla de resultado

### B. Espacio de hipótesis y evidencia

**AC-06 — Múltiples candidatos, cantidad fijada por caso** *(Core Rule 2)*
**GIVEN** cualquier caso Activo del juego
**WHEN** el tester revisa el documento de autoría de ese caso específico
**THEN** existen 2 o más candidatos de confusión viables documentados; un caso con un solo candidato posible falla esta prueba y se reporta como bug de contenido

**AC-07 — Tres familias de evidencia, sin etiqueta de importancia** *(Core Rule 3)*
**GIVEN** cualquier pieza de evidencia obtenida, de cualquier familia (Testimonio, Patrón de evento, Rastro físico)
**WHEN** el tester inspecciona su entrada en el Cuaderno
**THEN** muestra contenido, contexto de adquisición y familia, y no muestra ningún indicador de prioridad (estrella, texto "clave", color distintivo) que las demás entradas de su misma familia no compartan

**AC-08 — Evidencia libre, sin lista de tareas** *(Core Rule 4)*
**GIVEN** el estado Activo de cualquier caso
**WHEN** el tester revisa toda la UI accesible durante ese caso (HUD, cuaderno, mapa, diálogos)
**THEN** no existe ningún checklist u objetivo marcado ("habla con X", "visita Y") asociado a la obtención de evidencia

**AC-09 — Invariante de no-determinación única** *(Formulas; también Edge Case 6)*
**GIVEN** el documento de autoría de un caso antes de su aprobación para implementación
**WHEN** el tester recorre cada candidato viable listado
**THEN** cada candidato tiene al menos una evidencia que lo sostiene y al menos una que lo socava; un candidato con soporte total sin contradicción, o con cero soporte, bloquea la aprobación del caso — esta verificación es de autoría, no requiere build jugable

**AC-10 — Una evidencia válida para 2+ casos simultáneos** *(Edge Case 3)*
**GIVEN** una pieza de evidencia marcada como relevante para 2+ casos Activos
**WHEN** el jugador la obtiene
**THEN** aparece íntegra en la sección de cada uno de esos casos en el Cuaderno, sin restricción de "una pista, un caso"

**AC-24 — La evidencia no indica qué interpretación favorece** *(Player Fantasy, refuerza Formulas)*
**GIVEN** una pieza de evidencia que pertenece a un caso
**WHEN** el jugador la registra en el Cuaderno
**THEN** se presenta sin indicar qué candidato favorece ni cuál contradice — esa lectura es responsabilidad exclusiva del jugador, nunca del sistema

### C. Confrontación e interpretación

**AC-11 — Sin umbral de evidencia para confrontar** *(Core Rule 5)*
**GIVEN** un caso Activo con cero evidencia recolectada
**WHEN** el jugador habla con el NPC relevante
**THEN** la opción de tensar el diálogo hacia la Confrontación está disponible y seleccionable, sin mensaje de bloqueo ni opción deshabilitada

**AC-12 — Disponibilidad de confrontar no varía con la cantidad de evidencia**
**GIVEN** el mismo caso probado con 0, evidencia parcial, y evidencia completa
**WHEN** el tester repite la interacción con el NPC relevante en cada momento
**THEN** la opción de confrontar está presente, habilitada y visualmente idéntica en los 3 casos; cualquier diferencia condicionada por la cantidad de evidencia es un fallo

**AC-13 — Confrontar con poca o cero evidencia no es un estado de fallo distinto** *(Core Rule 6; Edge Case 2)*
**GIVEN** un caso confrontado con evidencia incompleta o nula
**WHEN** la Confrontación se resuelve
**THEN** el resultado sigue una de las ramas normales de resultado documentadas para ese caso; no existe pantalla o rama exclusiva de "evidencia insuficiente"/"intento a ciegas"

**AC-14 — Interpretación declarada por acción, no por menú** *(Core Rule 7)*
**GIVEN** el jugador dentro de una Confrontación activa
**WHEN** declara su interpretación
**THEN** lo hace seleccionando/citando anotaciones del Cuaderno dentro del flujo de diálogo; no existe en ningún punto una pantalla separada de "respuesta final" o "elige tu veredicto"

### D. Prohibiciones de UI (Cuaderno)

**AC-15 — Sin medidor de progreso**
**GIVEN** cualquier caso Activo con cualquier cantidad de evidencia
**WHEN** el tester abre su sección en el Cuaderno
**THEN** no aparece medidor, barra ni fracción ("3/5") de progreso

**AC-16 — Sin estado por evidencia**
**GIVEN** cualquier anotación en el Cuaderno
**WHEN** el tester la inspecciona
**THEN** no muestra estado "resuelto/pendiente" ni marca de revisión

**AC-17 — Sin ranking de hipótesis ni lista de sospechosos con indicadores**
**GIVEN** la vista de Índice de menciones de cualquier caso
**WHEN** el tester la revisa
**THEN** los nombres/lugares aparecen sin jerarquía, sin checkbox, sin barra de certeza, sin etiqueta "descartado"/"sospechoso"

**AC-18 — Sin conexiones sugeridas automáticas**
**GIVEN** 2+ anotaciones que comparten nombre, lugar o tema
**WHEN** el tester navega las 3 lentes del Cuaderno
**THEN** no se genera ni resalta ninguna inferencia tipo "esto podría estar relacionado con..."; el único vínculo mostrado es la coincidencia factual en el índice de menciones

**AC-19 — Sin color correcto/incorrecto**
**GIVEN** cualquier momento del juego, incluido después de resolver un caso
**WHEN** el tester revisa la paleta del Cuaderno y del feedback de resultado de Confrontación
**THEN** ningún elemento usa un par cromático semántico de acierto/error; la paleta se limita a la definida en Art Bible 4.4

**AC-20 — Feedback idéntico para toda evidencia nueva** *(Flujo E)*
**GIVEN** dos piezas de evidencia distintas, una crítica para la resolución y otra irrelevante
**WHEN** el jugador las obtiene por separado
**THEN** el feedback inmediato de obtención (sonido, animación, tratamiento en Cuaderno) es exactamente idéntico entre ambas

### E. Prohibiciones Visual/Audio (mundo)

**AC-21 — Sin señal exclusiva del mundo ante eventos de sistema**
**GIVEN** obtención de evidencia o cualquier transición de estado de caso
**WHEN** el evento ocurre en el mundo de juego
**THEN** no se dispara sonido, partícula, luz o cue musical exclusivo de ese evento, no compartido con el tratamiento genérico del entorno

**AC-22 — El mundo nunca confirma ni desmiente una interpretación**
**GIVEN** un caso recién Resuelto, favorable o desfavorablemente
**WHEN** el tester recorre los lugares/NPCs afectados inmediatamente después
**THEN** los cambios observados son consistentes con múltiples lecturas posibles (alteración material, no veredicto) y no hay iconografía de victoria/derrota ni declaración explícita de "quién tenía razón"

## Open Questions

[To be designed]
