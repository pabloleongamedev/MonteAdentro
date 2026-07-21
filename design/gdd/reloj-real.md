# Reloj Real

> **Status**: In Design
> **Author**: user + game-designer
> **Last Updated**: 2026-07-20
> **Implements Pillar**: Infraestructura que sirve a los Pilares 3, 4 y 5 indirectamente (timing como parte del razonamiento de cada mito)

## Overview

El Reloj Real es un ciclo de mundo compartido que avanza de forma continua mientras el jugador juega — con una proporción de horas de luz y de noche definida como parámetro de diseño (ver Tuning Knobs), no fijada en esta sección. Todos los casos, entidades y sistemas de Monte Adentro lo consultan como fuente única de la hora actual. No es un reloj por caso ni una progresión narrativa de fases: es infraestructura temporal de la que el mundo entero depende.

Para el jugador, gestionar el tiempo es parte de investigar, no un temporizador que lo presiona desde fuera: decide cuándo seguir explorando un caso y cuándo adelantar el tiempo mediante los mecanismos diegéticos que el mundo pone a su disposición (descansar, esperar, u otros que defina el diseño) para llegar al momento en que una entidad puede manifestarse, un testimonio existe, o el pueblo cambia de comportamiento. Ignorar un caso tiene consecuencias — el mundo no espera — pero el margen es generoso, precisamente para que un jugador que explora y conversa con calma tenga tiempo de resolverlo sin sentirse perseguido. La noche no es solo un cambio de iluminación: cambia qué hace el pueblo, quién está despierto, y qué entidades pueden aparecer.

## Player Fantasy

El tiempo convierte un mismo pueblo en lugares distintos. La plaza a mediodía y la plaza a medianoche no son la misma plaza: cambian quién está ahí, qué se dice, qué se calla, y qué se manifiesta. Elegir cuándo actuar — cuándo seguir indagando y cuándo dejar que avance la hora — significa decidir qué momento del pueblo quieres presenciar, sabiendo que los demás momentos seguirán existiendo sin que los veas.

Adelantar el tiempo nunca es huir de un peligro señalizado: es una decisión de investigación como cualquier otra, con el mismo peso que elegir a quién preguntarle o a dónde ir. El jugador rara vez conoce por completo las consecuencias de dejar pasar las horas; solo sabe que el pueblo continuó su vida sin esperar su intervención.

## Detailed Design

### Core Rules

1. **Naturaleza del reloj.** Ciclo continuo de mundo compartido: una franja de luz y una franja de noche cuya proporción exacta es un parámetro de Tuning Knobs, no una regla fija aquí. El reloj nunca se detiene por sí mismo, salvo por la Core Rule 6 (interrupción de avance rápido).

2. **Avance manual del tiempo.** El jugador puede adelantar el tiempo mediante mecanismos diegéticos que el diseño defina (descansar, esperar, u otros) — el Reloj Real expone la *capacidad* de avanzar hasta un punto elegido, pero no dicta el verbo o la interfaz exacta con que el jugador lo activa.

3. **Fases nombradas.** El reloj expone fases con nombre — mediodía, tarde, crepúsculo, noche, amanecer, heredadas del Art Bible Sección 2 — como agrupaciones de rango horario que otros sistemas consultan sin necesitar la hora exacta.

4. **Eventos de transición puntuales.** El Reloj Real únicamente **emite** eventos de transición temporal (p. ej. "comienza el amanecer"). Los sistemas que los consumen deciden qué significado tienen — el reloj nunca interpreta esos eventos ni conoce la lógica de quien los consume.

5. **Rol durante una confrontación** *(resuelve Open Question 3 de Sistema de Casos)*. El Reloj Real solo expone la Fase actual (Core Rules 3-4); es el Sistema de Entidades Míticas quien compara esa Fase contra la ventana de manifestación propia de cada mito y determina si el mito puede manifestarse antes de que la Confrontación comience — el Reloj Real nunca conoce esa ventana ni la evalúa por sí mismo (Core Rule 8). Una vez iniciada la Confrontación, el Reloj Real no tiene ningún rol dentro de sus reglas internas — cualquier comportamiento que un sistema dependiente decida cambiar "con la hora" (ver ficha del Duende como ejemplo de consumidor) es responsabilidad exclusiva de ese sistema.

6. **Interrupción de avance rápido.** Si al adelantar el tiempo el mundo alcanza un momento interactuable, el avance se detiene automáticamente ahí y el jugador recupera el control. *Se consideran momentos interactuables aquellos que abren una oportunidad de acción para el jugador — no los cambios de estado que solo producen consecuencias en segundo plano.* El objetivo no es evitar consecuencias, es evitar que una oportunidad de acción ocurra fuera de la vista del jugador.

7. **El reloj no penaliza por sí mismo.** Es el vehículo por el cual otros sistemas (Sistema de Casos, Estado del Mundo) aplican sus propias consecuencias de abandono. El Reloj Real solo garantiza que el tiempo pasa de verdad, de forma consistente, para todos los sistemas que lo consultan.

8. **Separación estricta de responsabilidad.** El Reloj Real no decide qué ocurre en una hora determinada; únicamente informa el paso del tiempo y notifica sus transiciones. Corresponde a cada sistema registrar qué debe suceder en cada fase o evento temporal — el reloj no mantiene ni conoce esa lista. Esto protege la arquitectura: agricultura, clima, economía, fauna, rutinas de NPC, o cualquier sistema futuro puede consumir el reloj sin que el reloj tenga que saber que existen.

### States and Transitions

Dos ejes de estado independientes: la **Fase** y el **Modo de Avance**. El Modo de Avance nunca modifica qué Fase está activa — solo modifica la velocidad con la que la Fase progresa. Ninguna Fase se salta ni se altera por el Modo; el ciclo mediodía → tarde → crepúsculo → noche → amanecer (Art Bible Sección 2) es el mismo de principio a fin, corra rápido o corra a paso real.

**Eje 1 — Fase** (heredado del Art Bible Sección 2, cíclico, sin fin de ciclo):

| Fase | Descripción | Entra por | Sale por |
| ---- | ---- | ---- | ---- |
| **Mediodía** | Vida cotidiana del pueblo (Art Bible 2.1) | Fin de Amanecer del ciclo anterior | Alcanza su hora de corte → **Tarde** |
| **Tarde** | Investigación y recolección de pistas (Art Bible 2.2) | Fin de Mediodía | Alcanza su hora de corte → **Crepúsculo** |
| **Crepúsculo** | Preparación del encuentro (Art Bible 2.3) | Fin de Tarde | Alcanza su hora de corte → **Noche** |
| **Noche** | Confrontación de ingenio (Art Bible 2.4) | Fin de Crepúsculo | Alcanza su hora de corte → **Amanecer** |
| **Amanecer** | Después del caso, consecuencia visible (Art Bible 2.5) | Fin de Noche | Alcanza su hora de corte → **Mediodía** (nuevo ciclo) |

Cada transición de Fase emite el evento puntual correspondiente (Core Rule 4) — p. ej. `comienza_tarde`, `comienza_crepusculo`, `comienza_noche`, `comienza_amanecer`, `comienza_mediodia`. La duración exacta de cada Fase es un Tuning Knob, no un valor fijado aquí.

**Eje 2 — Modo de Avance** (gobierna la velocidad de progresión de la Fase, nunca su contenido):

| Modo | Descripción | Entra por | Sale por |
| ---- | ---- | ---- | ---- |
| **Normal** | El tiempo pasa en tiempo real mientras el jugador juega libremente; control total del personaje | Estado por defecto / cualquier salida de **Rápido** | El jugador activa un mecanismo diegético de avance (Core Rule 2) → **Rápido** |
| **Rápido** | El tiempo avanza acelerado hacia el punto que el jugador eligió; el jugador no tiene control directo del personaje mientras dura — es una decisión que se ejecuta, no un modo que se juega | Activación de un mecanismo de avance manual | **Normal**, por cualquiera de dos causas: (a) alcanza el punto elegido sin cruzar un momento interactuable, o (b) el mundo alcanza un momento interactuable (Core Rule 6) y la aceleración se interrumpe — en ambos casos el jugador recupera el control y el tiempo sigue corriendo en tiempo real desde ese instante, sin un estado intermedio de espera |

Nota de alcance: la interrupción (b) no es un "evento de transición temporal" en el sentido de Core Rule 4 — esos eventos son exclusivamente de Fase. Si otros sistemas (UI, cámara) necesitan reaccionar a que el control volvió al jugador, eso es una señal de control/input, no una señal del Reloj Real; se resuelve en la capa de UI/input, no aquí.

### Interactions with Other Systems

Reloj Real es capa Foundation (Art Bible Sección 2, `systems-index.md`): no consume ningún otro sistema — todo lo que sigue es downstream, sistemas que leen su Fase actual y sus eventos de transición.

| Sistema | Dirección | Qué fluye |
| ---- | ---- | ---- |
| **Sistema de Entidades Míticas** | Downstream | Lee la Fase actual y sus eventos de transición para comparar contra la ventana de manifestación propia de cada mito (p. ej. crepúsculo/noche del Mohán, medianoche/madrugada del Duende) y determinar si cada mito puede manifestarse en ese momento, información que posteriormente consume el Sistema de Casos. Reloj Real nunca conoce estas ventanas — son datos propios de cada ficha de entidad (Core Rule 5, revisada). |
| **Sistema de Casos** | Downstream | Consume la Fase para dos cosas distintas: (a) qué evidencia de tipo Patrón de evento / Rastro físico está disponible en cada franja horaria (su Core Rule 4), y (b) la disponibilidad de manifestación que expone el Sistema de Entidades Míticas, para decidir si un intento de contacto se convierte en Confrontación (su Core Rule 5). Reloj Real no sabe que este uso existe — solo emite Fase y eventos, sin destinatario en mente. |
| **Sistema de Confrontación de Ingenio** | Downstream (dependencia Hard según `systems-index.md`; GDD aún no escrito) | Puede escuchar los eventos de transición de Fase durante una Confrontación activa para disparar comportamiento específico de una entidad — p. ej. la sobrecarga del Duende se resuelve cuando llega el evento `comienza_amanecer` (ver ficha del Duende §2, §5). Reloj Real no sabe que hay una Confrontación en curso ni qué significa el evento para ella; sigue emitiendo exactamente igual (Core Rule 5, Core Rule 8). |

El Modo de Avance es un detalle interno de implementación del Reloj Real. Ningún sistema externo puede consultarlo ni reaccionar a él; la única interfaz pública del sistema es la Fase actual y los eventos de transición temporal.

## Formulas

A diferencia de Sistema de Casos (una abstracción pura, donde una fórmula corrompería el diseño), el Reloj Real es una simulación genuina: incrementa un contador de tiempo en tiempo real y lo traduce en una Fase pública. Esta sección define esas dos relaciones honestas de runtime — nada más. El Reloj Real no conoce confrontaciones, duración de actividades, entidades, mitos ni reglas de gameplay; solo conoce tiempo, fases y transiciones. Todo lo demás es responsabilidad de los sistemas consumidores.

**Fórmula 1 — `avance_reloj` (avance del tiempo)**

`avance_reloj = Δt_juego = Δt_real × k_modo`

**Variables:**
| Variable | Símbolo | Tipo | Rango | Descripción |
| ---- | ---- | ---- | ---- | ---- |
| Tiempo de juego avanzado este tick | Δt_juego | float (min. de juego) | ≥ 0 | Cuánto tiempo del mundo pasa en este frame |
| Tiempo real transcurrido este tick | Δt_real | float (segundos reales) | ≥ 0 | Delta de frame que entrega el motor |
| Tasa de avance del modo actual | k_modo | float (min. juego / seg. real) | k_normal ≤ k_modo ≤ k_normal × m | k_normal en Normal; k_normal × m en Rápido (m = multiplicador de avance rápido ≥ 1) |

**Output Range:** En Normal, Δt_juego escala linealmente con el tiempo de frame; con k_normal = 1.0, un segundo real equivale a un minuto de juego. En Rápido con m = 60, un segundo real equivale a una hora de juego. En los extremos: k_modo = 0 congelaría el reloj — prohibido salvo por la interrupción de Core Rule 6, que cambia de Modo, nunca fija k_modo en 0.

**Example:** k_normal = 1.0, Δt_real de frame = 5 s → Δt_juego = 5 minutos de juego. El jugador activa Avance Rápido con m = 60 → k_modo = 60; en 5 segundos reales → Δt_juego = 300 minutos de juego = 5 horas de juego.

**Fórmula 2 — `fase_actual` (resolución de fase + emisión de eventos)**

`fase_actual = P tal que inicio(P) ≤ (t_juego mod T_ciclo) < inicio(siguiente(P))`

**Variables:**
| Variable | Símbolo | Tipo | Rango | Descripción |
| ---- | ---- | ---- | ---- | ---- |
| Tiempo de juego absoluto | t_juego | float (min. de juego) | ≥ 0, sin cota | Tiempo de mundo acumulado |
| Duración del ciclo | T_ciclo | float (min. de juego) | > 0 (Tuning Knob) | Un ciclo completo mediodía→amanecer |
| Límite de inicio de fase | inicio(P) | float (min. de juego) | 0 ≤ inicio(P) < T_ciclo | Los 5 límites ordenados que particionan [0, T_ciclo) |
| Fase resuelta | fase_actual | enum | {Mediodía, Tarde, Crepúsculo, Noche, Amanecer} | La única Fase pública |

**Output Range:** Siempre exactamente una de las 5 fases — nunca indefinida, porque los 5 límites particionan todo el ciclo sin huecos ni solapes (invariante de autoría sobre el conjunto de límites). El evento `comienza_P` se dispara en el único frame donde `(t_juego mod T_ciclo)` cruza `inicio(P)`. El avance rápido puede cruzar varios límites en un solo tick; cada límite cruzado debe emitir igual su evento, en orden — nota de implementación: no se deben saltar eventos cuando un tick de Avance Rápido pasa de largo un límite.

**Example:** T_ciclo = 1440. Límites ilustrativos (no fijados aquí, ver Tuning Knobs): Mediodía [0,300), Tarde [300,660), Crepúsculo [660,840), Noche [840,1260), Amanecer [1260,1440). En t_juego = 5000 → 5000 mod 1440 = 680 → cae en [660,840) → fase_actual = Crepúsculo. Cuando el contador cruza 840, la fase pasa a Noche y se dispara `comienza_noche`.

**Regla de encaje de fase** (regla de diseño, no fórmula): toda actividad diseñada para desarrollarse íntegramente dentro de una fase debe caber dentro de la duración mínima configurada para esa fase. Las actividades diseñadas para cruzar una transición temporal deben declararlo explícitamente en el sistema que las define — el Reloj Real no valida esto ni conoce qué actividades existen; es una responsabilidad exclusiva del sistema que diseña esa actividad.

## Edge Cases

- **Si** el jugador elige un punto de Avance Rápido que coincide con el instante actual (Δt_juego = 0 antes de empezar): **entonces** no hay transición a **Rápido** — el reloj permanece en **Normal** y no se emite ningún evento de Fase, porque no hubo avance real que cruzara ningún límite.

- **Si** un solo tick de **Rápido** cruza dos o más límites de Fase a la vez (salto largo): **entonces** cada límite cruzado emite su propio evento `comienza_P`, en el orden cronológico en que aparecen dentro del intervalo saltado — nunca se colapsan en un solo evento ni se omite ninguno, incluso si el intervalo cruza el cierre completo de un ciclo (`T_ciclo`) una o más veces.

- **Si** el mundo alcanza un momento interactuable (Core Rule 6) en el mismo instante en que también se cruza un límite de Fase: **entonces** el evento `comienza_P` se emite primero, y solo después el avance se interrumpe y el control vuelve al jugador — ningún sistema consumidor puede quedar en un estado donde la Fase ya cambió pero el evento correspondiente todavía no se disparó.

- **Si** el reloj está en Modo **Rápido**: **entonces** el mecanismo de avance manual (Core Rule 2) no está disponible para el jugador — no existe una reentrada que apile un segundo Avance Rápido sobre el primero, porque el jugador no tiene control directo mientras dura (States and Transitions).

## Dependencies

Reloj Real es capa Foundation (`systems-index.md`): **no tiene dependencias upstream** — no consume ningún otro sistema del juego.

| Sistema | Tipo | Dirección | Por qué |
| ---- | ---- | ---- | ---- |
| **Sistema de Entidades Míticas** | Hard (downstream) | Depende de Reloj Real | Necesita la Fase actual para evaluar la ventana de manifestación de cada mito (Core Rule 5). |
| **Sistema de Casos** | Hard (downstream) | Depende de Reloj Real | Su propio GDD ya lo declara Hard (Core Rule 4 y 5 de Sistema de Casos) — confirmado bidireccional. |
| **Sistema de Confrontación de Ingenio** | Hard (downstream) | Depende de Reloj Real | Declarado Hard en `systems-index.md`; GDD aún no escrito, dependencia provisional hasta que exista. |

## Tuning Knobs

| Knob | Qué controla | Si se pone muy bajo | Si se pone muy alto |
| ---- | ---- | ---- | ---- |
| **Duración de cada Fase** (5 valores: Mediodía, Tarde, Crepúsculo, Noche, Amanecer; `T_ciclo` es la suma de los 5) | Cómo se reparte el ciclo completo entre las 5 fases nombradas | Puede impedir que una actividad diseñada para desarrollarse íntegramente dentro de esa fase quepa en su duración prevista, obligando a reajustar los parámetros o a diseñarla para cruzar una transición | Diluye el ritmo del ciclo — el jugador pasa demasiado tiempo real en una sola fase y el resto se siente comprimido en comparación |
| **Tasa de avance en Modo Normal (k_normal)** | Cuántos minutos de juego pasan por segundo real durante Avance Normal | Un ciclo completo tarda demasiados minutos reales — puede romper el ritmo esperado de una sesión de juego si el jugador no llega a ver la Fase que necesita | El ciclo pasa tan rápido en tiempo real que el jugador pierde control fino sobre en qué Fase se encuentra al actuar |
| **Multiplicador de Avance Rápido (m)** | Cuánto más rápido corre el tiempo en Modo Rápido frente a Normal | Cercano a 1, Avance Rápido deja de sentirse distinto de Avance Normal — pierde su propósito como mecanismo de salto | Aumenta el riesgo de cruzar muchos límites de Fase en un solo tick sin que el jugador perciba cuánto tiempo de juego pasó realmente |

**Interacciones entre knobs**: *Duración de cada Fase* y *k_normal* deben ajustarse juntos — fases cortas combinadas con un k_normal alto comprimen el ciclo completo a segundos reales. *Multiplicador de Avance Rápido* interactúa con *Duración de cada Fase*: cuanto más cortas las fases, menor debe ser *m* para evitar cruces múltiples de límite en un solo tick.

## Visual/Audio Requirements

[To be designed]

## UI Requirements

[To be designed]

## Acceptance Criteria

**AC-01 — Ciclo continuo, nunca se detiene por sí mismo** *(Core Rule 1)*
**GIVEN** el reloj en cualquier Fase, en Modo Normal, sin Avance Rápido activo
**WHEN** el tiempo de juego avanza tick a tick
**THEN** Δt_juego es siempre > 0 en cada tick y el ciclo continúa indefinidamente sin ningún estado de "reloj detenido"

**AC-02 — Las 5 fases particionan el ciclo sin huecos ni solapes** *(Core Rule 3, Formula 2)*
**GIVEN** los 5 límites de fase configurados para un T_ciclo dado
**WHEN** se evalúa `fase_actual` para cualquier valor de `t_juego mod T_ciclo` en [0, T_ciclo)
**THEN** el resultado es exactamente una de las 5 fases — nunca ninguna, nunca más de una

**AC-03 — Modo nunca altera la secuencia de Fases, solo su velocidad** *(States and Transitions)*
**GIVEN** el reloj en una Fase X en Modo Normal
**WHEN** el jugador activa Avance Rápido y el Modo vuelve a Normal
**THEN** la secuencia de Fases atravesada es idéntica, en el mismo orden, a la que se habría atravesado en Modo Normal íntegro para el mismo intervalo

**AC-04 — Modo de Avance no es API pública ni emite eventos propios**
**GIVEN** cualquier sistema downstream, y cualquier transición entre Normal y Rápido
**WHEN** se intenta consultar el Modo actual, o se audita el conjunto de eventos públicos emitidos durante esa transición
**THEN** no existe propiedad/método público que exponga el Modo, y no se emite ningún evento de "entra/sale de Rápido" — la única interfaz pública es la Fase actual y sus eventos de transición

**AC-05 — k_modo escala Δt_juego correctamente en ambos Modos** *(Formula 1)*
**GIVEN** k_normal = 1.0 y m = 60
**WHEN** transcurre un Δt_real de 5 s en Normal, y luego en Rápido
**THEN** Δt_juego = 5 minutos de juego en Normal y 300 minutos en Rápido

**AC-06 — El evento se dispara en el tick exacto del cruce de límite** *(Formula 2)*
**GIVEN** `(t_juego mod T_ciclo)` acercándose a `inicio(P)` sin haberlo cruzado
**WHEN** el siguiente tick cruza `inicio(P)`
**THEN** se dispara exactamente un evento `comienza_P`, y `fase_actual` pasa a ser P desde ese mismo tick

**AC-07 — Cruce de múltiples límites en un tick emite todos los eventos, en orden** *(Formula 2, Edge Case 2)*
**GIVEN** un salto de Avance Rápido que abarca 3+ límites de Fase
**WHEN** se procesa ese único tick
**THEN** se emiten todos los eventos `comienza_P` correspondientes, en orden cronológico, sin colapsar ni omitir ninguno

**AC-08 — Solo se interrumpe en momentos interactuables, no en consecuencias de fondo** *(Core Rule 6)*
**GIVEN** el reloj en Modo Rápido avanzando hacia un punto elegido
**WHEN** el avance atraviesa un cambio de estado que produce solo una consecuencia en segundo plano
**THEN** el avance NO se interrumpe ahí — continúa hasta el siguiente momento interactuable o el punto elegido

**AC-09 — Interrupción devuelve control y reanuda tiempo real de inmediato, sin estado intermedio**
**GIVEN** el reloj en Modo Rápido
**WHEN** el avance alcanza un momento interactuable, o alcanza el punto elegido sin encontrar ninguno
**THEN** el Modo pasa a Normal en ese mismo tick (con devolución de control en el caso de interrupción) y el tiempo continúa en tiempo real desde ese instante, sin ningún tick de "reloj congelado" intermedio

**AC-10 — Punto de destino igual al instante actual no dispara Rápido** *(Edge Case 1)*
**GIVEN** el jugador elige un punto de Avance Rápido idéntico al t_juego actual
**WHEN** se procesa la activación
**THEN** el Modo permanece en Normal y no se emite ningún evento de Fase

**AC-11 — El evento de Fase se emite antes de que la interrupción tome efecto** *(Edge Case 3)*
**GIVEN** un cruce de límite y un momento interactuable coincidiendo en el mismo tick
**WHEN** se procesa ese tick
**THEN** `comienza_P` se dispara primero y solo después se interrumpe el avance

**AC-12 — Sin reentrada de Rápido sobre Rápido** *(Edge Case 4)*
**GIVEN** el reloj ya en Modo Rápido
**WHEN** el jugador intenta activar un segundo mecanismo de avance manual
**THEN** la activación no tiene efecto — solo está disponible en Modo Normal

**AC-13 — El reloj opera sin ningún sistema downstream presente** *(Dependencies)*
**GIVEN** una instancia del Reloj Real sin Entidades Míticas, Casos ni Confrontación de Ingenio presentes
**WHEN** el tiempo avanza en cualquier Modo
**THEN** el reloj avanza y emite eventos normalmente, sin error ni referencia a esos sistemas

**AC-14 — Actividad de fase única cabe en la duración mínima, o se declara cruzable** *(Formulas — regla de encaje de fase)*
**GIVEN** el diseño de una actividad destinada a una sola Fase
**WHEN** un revisor compara su duración estimada contra la duración mínima de esa Fase
**THEN** cabe dentro de ella, o el sistema que la define la declara explícitamente cruzable — verificación de autoría, no chequeo de runtime

## Open Questions

| # | Pregunta | Contexto | Owner | Se resuelve en |
| ---- | ---- | ---- | ---- | ---- |
| 1 | ¿Cuáles son los valores concretos de los 3 Tuning Knobs (duración de cada Fase, k_normal, multiplicador m) para el vertical slice? | Quedaron con su lógica de "muy alto/muy bajo" documentada, sin valores de referencia todavía | `game-designer` | Al construir el vertical slice (`/vertical-slice`) o al tunear el caso tutorial |
| 2 | ¿Qué criterio concreto distingue un "momento interactuable" (Core Rule 6) de una consecuencia de fondo que no debe interrumpir el Avance Rápido? | La regla está definida en principio (abre oportunidad de acción vs. solo produce consecuencia), pero sin ejemplos de contenido real todavía | `game-designer` | Al diseñar los primeros casos concretos del MVP |
| 3 | La regla de encaje de fase (AC-14) necesita la duración típica de una Confrontación para verificarse en autoría — ¿cómo se aplica mientras ese GDD no existe? | El invariante depende de un dato (D_actividad) que hoy no tiene dueño | `game-designer` | GDD de Sistema de Confrontación de Ingenio |
