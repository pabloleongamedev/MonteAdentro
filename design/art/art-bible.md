# Art Bible: Monte Adentro

## Document Status
- **Versión**: 0.2
- **Última actualización**: 2026-07-15
- **Propietario**: art-audio
- **Estado**: Secciones 1-4 (identidad visual core) aprobadas. Secciones 5-9 pendientes — fuera del alcance de esta sesión.
- **Art Director Sign-Off (AD-ART-BIBLE)**: omitido — modo de revisión `lean` (no es un phase-gate)

## Nota de alcance (frontera con el diseño de juego y con la implementación)

El Art Bible define **cómo se comunica visualmente el mundo**, nunca **cómo se resuelven los casos** ni **cómo se implementa en el motor**. Ninguna regla de este documento debe convertirse en una regla de gameplay (p. ej. "el agua tiene un shader azul cuando el Mohán está activo" pertenece al diseño de sistemas, no al arte) ni en una decisión técnica de implementación (p. ej. cómo se activa un sistema de highlight en código pertenece al documento de arquitectura/interacción, no aquí). El Art Bible puede definir **qué comunica el arte**, pero nunca **cómo lo implementa el motor**. El arte acompaña la deducción del jugador — nunca la delata.

---

## 1. Visual Identity Statement

### Regla visual (one-liner)

> **Lo mítico no se distingue por códigos visuales evidentes; se revela cuando el jugador aprende a interpretar el mundo.**

El arte no cambia para señalar lo sobrenatural — el jugador cambia. La primera vez que algo aparece en escena es solo un detalle del mundo. Solo tras acumular comprensión, ese mismo elemento (sin que su representación visual haya cambiado) se vuelve reconocible como parte de la lógica de una entidad mítica. Esto significa que los mitos SÍ pueden ser visualmente reconocibles — pero únicamente después de que el jugador los entendió, nunca antes por un tratamiento visual especial.

### Principios de apoyo

#### Principio 1 — El indicio se integra; nunca se anuncia
**Pilares que sirve**: Pilar 1 (el conocimiento es la única forma de progresar) y Pilar 5 (el jugador siempre decide con información incompleta)

Una pista recibe exactamente el mismo tratamiento de luz, pincelada y paleta que cualquier detalle incidental de la escena. Se resuelve con composición — encuadre, profundidad de campo, posición en el espacio — nunca con un estilo distinto que la delate.

*Test de diseño*: cuando dudes si una pista necesita brillo, contorno o color especial para que el jugador la note, la respuesta es no.

#### Principio 2 — Cada entidad posee un lenguaje visual coherente con su propia lógica
**Pilar que sirve**: Pilar 3 (cada mito rompe las reglas aprendidas anteriormente)

Cada mito tiene su propio vocabulario visual reconocible (formas, motivos, comportamiento de luz) consistente en sí mismo — no necesita "romper una convención" cada vez, pero tampoco puede compartir el vocabulario visual de otra entidad. Esto permite construir reglas de reconocimiento reales en vez de reinventar el lenguaje visual en cada mito.

*Test de diseño*: cuando diseñes la manifestación visual de un mito nuevo, si comparte vocabulario visual con una entidad ya revelada, no está listo — necesita su propia lógica reconocible.

#### Principio 3 — El fallo transforma el mundo; nunca se representa como derrota
**Pilar que sirve**: Pilar 2 (el error es contenido)

Un resultado fallido jamás se representa con iconografía de derrota o de horror gráfico (sangre, calaveras, pantallas rojas de "perdiste"). Se traduce siempre en un cambio de estado ambiental permanente y visible.

*Test de diseño*: cuando el instinto sea representar un fallo con iconografía de derrota o violencia explícita, elige en su lugar un cambio de estado ambiental que comunique transformación, no interrupción.

#### Principio 4 — Toda decisión deja una huella visible en el mundo
**Pilar que sirve**: Pilar 4 (las consecuencias son permanentes, visibles y afectan casos futuros)

El pueblo funciona como un registro visual acumulativo. Ningún caso resuelto puede ser visualmente indistinguible de uno que nunca ocurrió.

*Test de diseño*: cuando dudes si una consecuencia narrativa necesita un rastro visual permanente en el mundo, la respuesta es siempre sí.

---

## 2. Mood & Atmosphere

El mood de cada estado nace del reloj real del pueblo, no de un efecto especial que
anuncie lo sobrenatural: la progresión **mediodía → tarde → crepúsculo → noche → amanecer**
sigue el arco natural de un caso completo. El crepúsculo y la noche funcionan como el
umbral mítico tradicional del folclor andino ("la hora del monte") sin que la luz misma
cambie de reglas — sigue siendo el sol y la sombra de siempre, solo más tarde.

*Nota de alcance*: los cambios de iluminación descritos aquí son ambientales y uniformes
(afectan la escena completa por la hora del día), nunca selectivos sobre un objeto o
pista puntual — eso violaría el Principio 1. La diferencia entre "Investigación" y
"Vida cotidiana", por ejemplo, se construye con ritmo, encuadre y tiempo de permanencia
de cámara, no con un tratamiento de luz distinto para los objetos-pista.

### 2.1 Vida cotidiana del pueblo (antes de un caso)

- **Objetivo emocional primario**: arraigo cálido. El jugador debe sentir que este es
  un lugar que vale la pena proteger *antes* de saber que algo lo amenaza — es la línea
  base contra la que toda extrañeza posterior se va a medir. Si este estado no genera
  apego, el fallo del Principio 3 (transformación del mundo) pierde peso emocional más
  adelante: no puedes sentir que algo se transformó si nunca sentiste lo que era antes.
- **Carácter de iluminación**: mediodía. Luz cálida y de alto contraste direccional,
  propia de la altitud andina (aire limpio produce sombras duras y bien definidas
  incluso al mediodía). Dorados y terrosos dominantes, saturación media-alta.
- **Descriptores atmosféricos**: acogedor, terroso, laborioso, curtido, arraigado.
- **Nivel de energía**: medido. Un ritmo de vida que sigue su propio curso, ajeno a
  cualquier urgencia del jugador — nadie en el pueblo tiene prisa todavía.

### 2.2 Investigación y recolección de pistas

- **Objetivo emocional primario**: atención que no se relaja. La curiosidad domina,
  pero bordeada de una inquietud discreta — el jugador empieza a *mirar distinto* el
  mismo pueblo, aunque el pueblo no le haya dado ninguna razón visual para hacerlo.
  Esta es la sensación central del Principio 1 traducida a mood: la extrañeza vive en
  la mirada del jugador, no en la escena.
- **Carácter de iluminación**: tarde, sol descendiendo. Misma calidez del estado
  anterior, pero las sombras se alargan progresivamente a medida que avanza el caso —
  un índice narrativo del paso del tiempo, no de la naturaleza mítica del fenómeno.
  Contraste ligeramente mayor por el ángulo bajo del sol; los dorados empiezan a virar
  hacia ámbar y cobre.
- **Descriptores atmosféricos**: observadora, expectante, silenciosa, minuciosa.
- **Nivel de energía**: contemplativo, con atención sostenida. Ni urgente ni relajado —
  el jugador se detiene más tiempo del que un habitante del pueblo se detendría.

### 2.3 Preparación del encuentro

- **Objetivo emocional primario**: foco ritual con una corriente de duda. El jugador
  ejecuta pasos concretos que sí domina (reunir objetos, seguir un procedimiento
  conocido), pero nunca con certeza total de que su hipótesis es correcta — esto
  traduce directamente el Pilar 5 (información incompleta) al terreno emocional de la
  preparación. No es puro ritual sereno ni puro pánico: es competencia práctica
  ejercida bajo incertidumbre real.
- **Carácter de iluminación**: crepúsculo. Cielo en transición — violetas y naranjas
  del atardecer andino compitiendo, contraste medio, sombras largas y suaves que se
  van diluyendo. Si la preparación ocurre en interiores, luz cálida artificial (vela,
  lámpara de keroseno, fogón) contra el frío creciente del exterior — la dualidad
  cálido-adentro / frío-afuera es el motivo lumínico central de este estado.
- **Descriptores atmosféricos**: metódica, expectante, íntima, precisa, en vilo.
- **Nivel de energía**: concentrado. Más enfocado que "Investigación", pero sin picos
  de tensión todavía — esos se reservan para la confrontación misma.

### 2.4 Confrontación de ingenio

- **Objetivo emocional primario**: deliberación bajo presión, nunca reflejo bajo
  presión. Dado el anti-pilar explícito contra el combate de reflejos, este estado
  debe sentirse como ajedrez tenso, no como un quick-time event — la tensión nace de
  la irreversibilidad de la decisión, no de la velocidad para tomarla.
- **Carácter de iluminación**: noche. Fuente de luz predominantemente fría o muy
  reducida (luna, niebla, fogatas puntuales), contraste alto entre pozos de luz
  aislados y una oscuridad envolvente. La oscuridad es el territorio natural del monte
  de noche — nunca un "modo peligro" codificado, sigue siendo la misma noche andina
  que ya vimos llegar en 2.3.
- **Descriptores atmosféricos**: contenida, aguda, expuesta, irreversible.
- **Nivel de energía**: contemplativo con picos puntuales. Base de calma tensa que
  sube brevemente solo en los momentos donde el jugador se compromete con una acción
  irreversible — da forma dramática al clímax de cada caso sin traicionar que es una
  confrontación de ingenio, no de destreza motora.

### 2.5 Después del caso (consecuencia visible)

Este estado se bifurca en dos variantes obligatorias por el Principio 3: el fallo
transforma, nunca derrota. Ambas ocurren en el mismo reloj del pueblo (amanece
siempre, gane o pierda el jugador) — lo que cambia es la calidad de esa luz de
amanecer, nunca su presencia.

**2.5a — Resultado favorable**

- **Objetivo emocional primario**: alivio ganado, no euforia. El caso se cerró, pero
  el pueblo sigue siendo un lugar donde el monte puede volver a hablar — este no es
  un final triunfal, es una pausa honesta.
- **Carácter de iluminación**: amanecer limpio. Transición de azul de alba a dorado
  tenue, contraste bajo-medio, luz creciente y despejada.
- **Descriptores atmosféricos**: sereno, ganado, despejado, quieto.
- **Nivel de energía**: pausado.

**2.5b — Resultado desfavorable**

- **Objetivo emocional primario**: pérdida que se puede nombrar, no espanto. El
  jugador debe sentir el peso de una consecuencia real y permanente sin que el arte
  recurra a iconografía de derrota — es un mundo que amaneció distinto, no un mundo
  castigado visualmente.
- **Carácter de iluminación**: el mismo amanecer natural de 2.5a, pero su calidad está
  alterada por el cambio ambiental permanente que dejó el caso (niebla más densa,
  humo, luz filtrada, desaturación) — sigue siendo luz de amanecer real, nunca una
  "luz de derrota" inventada. *(La naturaleza exacta del cambio ambiental es una regla
  de gameplay/consecuencia — fuera del alcance de este documento; el Art Bible solo
  define que el amanecer debe poder portar esa alteración visualmente cuando el
  sistema de consecuencias lo indique.)*
- **Descriptores atmosféricos**: velado, alterado, silencioso, irrevocable.
- **Nivel de energía**: sombrío pero quieto — nunca frenético, nunca desesperado.

## 3. Shape Language

El lenguaje de formas de *Monte Adentro* existe para resolver una tensión específica del one-liner de la Sección 1: **la silueta debe ser legible sin ser delatora**. En la mayoría de los juegos, la forma es la primera herramienta para dirigir el ojo del jugador — "esto es importante, mira aquí". Aquí, esa herramienta está parcialmente vetada: el Principio 1 (*"el indicio se integra, nunca se anuncia"*) prohíbe usar la jerarquía de formas para señalar qué es una pista. Por eso, esta sección separa dos categorías de forma que en otros juegos suelen fusionarse sin problema — **prominencia funcional** (esto es interactuable) y **prominencia narrativa** (esto es una pista) — y establece que solo la primera puede expresarse mediante diseño de silueta.

### 3.1 Filosofía de silueta de personajes

**Regla general.** Ninguna silueta en el mundo debe ser más legible de lo que la justifica la distancia, la luz y la composición de la escena — nunca más legible porque el diseño "quiere" que el jugador la note. La legibilidad se gana por conocimiento acumulado (observar → hipotetizar), no por contraste de silueta.

**Sistema de dos niveles.** Para resolver la tensión entre "el mundo debe ser ambiguo" y "el jugador necesita herramientas claras", la silueta se trata en dos contextos con reglas distintas:

- **Nivel A — Silueta en el mundo.** Personajes humanos y entidades míticas comparten escala, proporción general y ritmo de siluetas con el entorno (otras personas, animales de carga, vegetación, mobiliario rural). Nada en la silueta bruta debe destacar por sí sola. Coherente con el one-liner: lo mítico es visualmente reconocible *solo después de aprendido*, nunca antes.
- **Nivel B — Silueta catalogada (cuaderno del investigador).** Una vez el jugador ha reunido suficiente evidencia sobre un personaje o entidad, el propio personaje-jugador documenta lo que ha entendido. Ahí, y solo ahí, la silueta puede clarificarse, simplificarse, volverse icónica — la claridad progresiva es una **huella visible de la decisión de investigar** (Principio 4).

**NPC humano vs. entidad mítica.** La proporción humana no puede ser el diferenciador, porque buena parte del folclore andino relevante es explícitamente humanoide hasta que un detalle la delata. Siluetas "raras" desde el primer instante (demasiado altas, angulares, con apéndices evidentes) romperían el Principio 1 y el one-liner en la primera escena.

En su lugar: **cada entidad posee un lenguaje formal propio y consistente** (no compartido entre entidades, por Principio 2). Ese lenguaje puede expresarse mediante silueta, ritmo, proporción, repetición, dirección, vacío o composición — no se limita a un único recurso — y debe cumplir tres condiciones:
- Es indistinguible del ruido visual normal (imperfección de tela, sombra, postura) en el primer encuentro.
- Se repite de forma reconocible cada vez que esa entidad aparece (consistencia = jugable, se puede aprender).
- Nunca se corrige, ilumina, resalta o anima de forma distinta al resto de la escena.

Esto convierte el reconocimiento de entidades míticas en una habilidad de lectura visual genuina del jugador, no en una convención de género ("los monstruos tienen cuernos"). Refuerza directamente el bucle observar → hipotetizar: la recompensa por prestar atención es literalmente ver mejor.

*Nota de proceso*: el diseño concreto del lenguaje formal por entidad depende de qué 3 entidades del folclore andino se elijan para el MVP — se define junto con `narrative-writer` y `game-designer` cuando se aborde el bestiario. Aquí solo se fija la regla del sistema, no las formas específicas.

### 3.2 Geometría de entornos

El pueblo andino colombiano ofrece una dualidad geométrica natural que ya resuena con la Sección 2 (dualidad cálido-adentro / frío-afuera del crepúsculo):

- **Núcleo del pueblo — orden geométrico humano.** Calles en trama, muros de tapia pisada y adobe, techos de teja de dos aguas, puertas y ventanas rectangulares. Domina lo **rectilíneo y ortogonal**, pero con la imperfección propia de la construcción artesanal (muros que ceden, tejas irregulares, esquinas no perfectamente escuadradas). Esta imperfección es deliberada: un orden "demasiado limpio" sería el primer error de legibilidad, porque cualquier anomalía destacaría de inmediato sobre un fondo perfecto. La imperfección artesanal es el camuflaje del Principio 1.
- **Periferia / monte — geometría orgánica.** Vegetación de bosque andino/subpáramo, terreno ondulado, rocas erosionadas, agua. Domina lo **curvilíneo, irregular, sin ejes dominantes**.
- **Zona liminal — el borde del pueblo, la linde del monte, los caminos hacia las chagras.** Es donde ambas geometrías se solapan: cercas de madera que empiezan rectas y se pierden entre matorral, un muro de piedra que la vegetación ya invadió. Es, por diseño, el **hábitat natural del indicio** — el lugar donde una forma "casi orgánica pero con un eje sospechoso" o "casi geométrica pero con una curva que no debería estar ahí" puede integrarse sin anunciarse.

Regla de composición para nivel: cuanto más cerca del centro del pueblo, más ortogonal debe ser el fondo; cuanto más cerca del monte, más orgánico — y las pistas del MVP deberían privilegiar la zona liminal, donde el vocabulario de formas ya es ambiguo por naturaleza, no por diseño de la pista.

### 3.3 Gramática de formas en la UI

Decisión: ni UI totalmente diegética/orgánica, ni HUD neutro genérico — un marco híbrido. La interfaz forma parte del mundo del investigador y evita elementos propios de interfaces abstractas de videojuegos (barras flotantes, iconografía de fantasía genérica, marcos futuristas). El marco (chrome) pertenece visualmente al mundo del investigador; el contenido (evidencia, hipótesis, candidatos) prioriza claridad y escaneabilidad, porque es información que el jugador **ya ganó** al recolectarla — la claridad vive en el cuaderno, nunca en el mundo (ver 3.1, Nivel B). La ejecución material concreta de ese "chrome" (qué texturas, motivos u ornamentos exactos) es una decisión de arte posterior, fuera de esta sección.

**Conexión con "sin reflejos bajo presión".** La UI de la confrontación nocturna (Sección 2) debe evitar formas que impliquen urgencia motriz (ruedas de cooldown, selección radial rápida) — la tensión de esa escena es cognitiva, y la gramática de formas debe reforzar eso, no simularla como un HUD de combate.

**Conexión con el Principio 3.** Un resultado desfavorable se expresa como una alteración material visible en el propio cuaderno del jugador, nunca como iconografía de fracaso (X roja, calavera, barra vacía). La naturaleza exacta de esa alteración es una decisión de ejecución artística posterior.

### 3.4 Formas protagonistas vs. formas de apoyo

> **La jerarquía de formas puede señalar QUÉ ES INTERACTUABLE. Nunca puede señalar QUÉ ES UNA PISTA.**

Son categorías distintas y deben tratarse distinto:

- **Formas que sí pueden atraer el ojo (prominencia funcional):** elementos de navegación (umbrales, puertas, caminos) guiados por composición clásica, no por resaltado; personajes en diálogo, cuya postura y gesto comunican estado emocional como lenguaje corporal.
- **Formas que deben retraerse (apoyo, deliberadamente neutras):** objetos de ambientación general, que se funden por densidad, repetición y perspectiva atmosférica, nunca por aplanamiento artificial; objetos-pista específicamente, que reciben exactamente el mismo tratamiento visual que su categoría genérica.

Esta separación es lo que permite que el juego tenga una navegación cómoda **sin sacrificar** el principio central del art bible: el mundo nunca le hace un guiño al jugador sobre dónde está la verdad. Solo el propio cuaderno del jugador — construido con su esfuerzo — se vuelve más claro con el tiempo.

### Tabla de trazabilidad (Sección 3 → Sección 1 → pilar de juego)

| Subsección | Principio de Sección 1 | Pilar de juego conectado |
| ---- | ---- | ---- |
| 3.1 Silueta de personajes | Principio 1 + Principio 2 + one-liner | Observar → Hipotetizar |
| 3.2 Geometría de entornos | Principio 1 (integración del indicio) | Buscar pruebas (zona liminal) |
| 3.3 Gramática de UI | Principio 3 + Principio 4 | Preparar / Confrontar |
| 3.4 Formas protagonistas vs. apoyo | Principio 1 | Todo el bucle — regla anti-spoiler estructural |

## 4. Color System

### 4.0 Principio rector de la sección

El color en *Monte Adentro* no clasifica el mundo — lo **habita**. Ningún color puede convertirse, por sí solo, en un código confiable de "esto importa" o "esto es mítico", porque eso violaría el Principio 1 de la Sección 1. El sistema de color existe para servir la temperatura emocional de cada estado del día (Sección 2) y la identidad de cada zona (Sección 3), no para etiquetar objetos.

### 4.1 Paleta primaria

Siete familias cromáticas-ancla, presentes en distintas proporciones a lo largo de todo el juego. No son "colores de las 5 fases" — son la identidad cromática permanente del mundo, que la luz de cada fase modula en intensidad y mezcla. *Los valores exactos (hex, materiales, postprocesado) se definen más adelante, cuando la iluminación y dirección de materiales estén validadas — aquí solo se fijan familias y roles.*

| Familia cromática | Rol | Qué significa en este mundo |
| ---- | ---- | ---- |
| **Ocre de Adobe** (terroso cálido, entre arena y arcilla) | Ancla del pueblo | El trabajo humano que persiste. Paredes, caminos, la vida que se repite cada día. Color de lo conocido y confiable. |
| **Cobre de Tarde** (cálido anaranjado, más saturado que el ocre) | Ancla de la investigación | La calidez de escuchar a alguien contar su versión. Color de la memoria compartida, del testimonio. |
| **Musgo de Monte** (verde apagado, terroso) | Ancla del monte | Lo que crece sin permiso humano. No es "peligro" — es *anterioridad*: el monte estaba antes que el pueblo y seguirá después. |
| **Violeta de Umbral** (morado grisáceo, de baja saturación) | Ancla de lo liminal | Expresa ambigüedad espacial y perceptiva; nunca debe indicar por sí solo la presencia de lo sobrenatural. |
| **Azul de Vigilia** (azul frío, oscuro) | Ancla de la noche/confrontación | Frío, reducido, deliberado. Comunica contención mental bajo presión, nunca pánico. |
| **Hueso/Ceniza** (neutro cálido claro) | Ancla neutra | El mundo como testigo sin juicio. Aparece en niebla, humo, polvo, ropa vieja — nunca dictamina si algo salió bien o mal, solo registra que pasó. |
| **Rojo Achiote** (rojo terroso, no un rojo de alarma saturado) | Acento humano deliberadamente frecuente | Intensidad: fuego, tintes rituales, pasión, ira. Debe aparecer con suficiente frecuencia en contextos cotidianos (una ruana, una olla al fuego) como para impedir que el jugador lo asocie con eventos extraordinarios — nunca puede convertirse en indicador de peligro, interacción o importancia. |

### 4.2 Uso semántico del color

- **Ocre y Cobre (cálidos-humanos):** confianza, rutina, lo dicho en voz alta. Un espacio cargado de estos tonos se siente legible por pertenecer al registro del pueblo, no del monte.
- **Musgo:** tiempo largo, memoria vegetal. Aparece tanto en jardines inocentes como en vegetación que rodea un sitio importante — da textura de antigüedad, nunca señala algo puntual.
- **Violeta de Umbral:** ambigüedad espacial y perceptiva. Aparece de forma ambiental y difusa, nunca como acento puntual sobre un objeto específico — esa distinción es la que evita que se lea como una señal.
- **Azul de Vigilia:** frío y distancia mental. Si aparece fuera de la noche, no debe leerse como "esto es la pista" sino como un extrañamiento tonal sutil — usado con moderación suficiente para que no se vuelva un patrón reconocible.
- **Hueso/Ceniza:** lo que el mundo conserva después de un evento — nunca "derrota". Aparece igual en un after-caso favorable que en uno desfavorable; el significado está en cuánto y cómo se comporta, no en el color mismo.
- **Rojo Achiote:** el más peligroso de gestionar. Su disciplina de uso — aparecer con suficiente frecuencia en contextos cotidianos como para impedir que el jugador lo asocie con eventos extraordinarios — es un criterio cualitativo de dirección de arte, no una proporción numérica fija.
- **Blanco puro** (distinto de Hueso): reservado casi exclusivamente para luz real (velas, sol de mediodía, faroles) — es luz, no símbolo.

### 4.3 Temperatura de color por zona (conexión con Sección 3)

| Zona | Sesgo de temperatura | Justificación |
| ---- | ---- | ---- |
| **Pueblo** (geometría ortogonal-imperfecta) | Sesgo cálido persistente, incluso de noche — el Azul de Vigilia nocturno se filtra sobre una base ocre/cobre, nunca la reemplaza del todo. | El pueblo es el registro humano — su calidez es su identidad, no una función del reloj. |
| **Monte** (geometría orgánica) | Sesgo frío-verde persistente, incluso a mediodía — el Ocre de Adobe casi no aparece aquí. | El monte no responde al reloj del pueblo — tiene su propio tiempo, más lento y más frío emocionalmente. |
| **Zona liminal** (umbral pueblo-monte) | Único territorio donde cálido y frío se mezclan visiblemente en la misma composición — Violeta de Umbral como color puente. | Consistente con la Sección 3: la zona liminal es el hábitat natural de las pistas. Esto describe el tono del lugar, nunca un marcador de objetos individuales dentro de él. |

### 4.4 Paleta de UI (el cuaderno del investigador)

Coherente con la Sección 3.3: la UI diverge deliberadamente de la paleta del mundo.

- **Base:** familia de papel envejecido y tinta — cálida pero desaturada, estable sin importar la fase del día o la zona en la que esté el jugador.
- **Por qué diverge:** si la UI usara los mismos colores cargados de significado que el mundo (rojo achiote, violeta de umbral), el jugador aprendería a leer la UI como diccionario del mundo, y el mundo dejaría de necesitar interpretación — matando el Principio 1 desde la interfaz. La UI no traduce el mundo; el jugador traduce el mundo.
- **Acento único:** un solo tono, versión muy desaturada de la familia Cobre, usado para foco de atención (título de página, selección activa) — nunca un color que el mundo use con carga narrativa.
- **Regla dura:** la UI nunca usa color para decir "esto es correcto/incorrecto" — esa retroalimentación es del mundo (Principio 4: toda decisión deja huella visible), no del cuaderno.

### 4.5 Legibilidad sin depender del color (filosofía, no solo accesibilidad)

Dos parejas de esta paleta son de alto riesgo perceptual: **Musgo vs. Rojo Achiote** (el riesgo más común, protanopia/deuteranopia) y **Violeta de Umbral vs. Azul de Vigilia** (riesgo menor pero real, agravado por la iluminación reducida de la fase de Confrontación).

Esto no se trata como un requisito de accesibilidad aislado, sino como principio general: **toda información importante debe poder comprenderse sin depender exclusivamente del color**. Eso beneficia a todos los jugadores, no solo a quienes tienen daltonismo. La silueta de dos niveles y la geometría por zona (Sección 3) ya cumplen buena parte de este rol de forma natural, porque pueblo/monte/liminal tienen formas distintas independientes del color. La dirección de arte debe verificar, escena por escena, que un jugador que viera todo en escala de grises seguiría pudiendo distinguir pueblo de monte, y crepúsculo de noche, solo por composición, silueta y densidad.

---

> **El color construye atmósfera; nunca comunica soluciones.**

## 5. Character Design Direction

*[Pendiente — fuera del alcance de esta sesión]*

## 6. Environment Design Language

*[Pendiente — fuera del alcance de esta sesión]*

## 7. UI/HUD Visual Direction

*[Pendiente — fuera del alcance de esta sesión]*

## 8. Asset Standards

*[Pendiente — fuera del alcance de esta sesión]*

## 9. Reference Direction

*[Pendiente — fuera del alcance de esta sesión]*
