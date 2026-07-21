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

5. **Rol durante una confrontación** *(resuelve Open Question 3 de Sistema de Casos)*. El Reloj Real determina únicamente si una entidad puede manifestarse (presencia binaria) antes de que la Confrontación comience, usando el mismo mecanismo de fases/eventos de las Core Rules 3-4. Una vez iniciada la Confrontación, el Reloj Real no tiene ningún rol dentro de sus reglas internas — cualquier comportamiento que un sistema dependiente decida cambiar "con la hora" (ver ficha del Duende como ejemplo de consumidor) es responsabilidad exclusiva de ese sistema.

6. **Interrupción de avance rápido.** Si al adelantar el tiempo el mundo alcanza un momento interactuable, el avance se detiene automáticamente ahí y el jugador recupera el control. *Se consideran momentos interactuables aquellos que abren una oportunidad de acción para el jugador — no los cambios de estado que solo producen consecuencias en segundo plano.* El objetivo no es evitar consecuencias, es evitar que una oportunidad de acción ocurra fuera de la vista del jugador.

7. **El reloj no penaliza por sí mismo.** Es el vehículo por el cual otros sistemas (Sistema de Casos, Estado del Mundo) aplican sus propias consecuencias de abandono. El Reloj Real solo garantiza que el tiempo pasa de verdad, de forma consistente, para todos los sistemas que lo consultan.

8. **Separación estricta de responsabilidad.** El Reloj Real no decide qué ocurre en una hora determinada; únicamente informa el paso del tiempo y notifica sus transiciones. Corresponde a cada sistema registrar qué debe suceder en cada fase o evento temporal — el reloj no mantiene ni conoce esa lista. Esto protege la arquitectura: agricultura, clima, economía, fauna, rutinas de NPC, o cualquier sistema futuro puede consumir el reloj sin que el reloj tenga que saber que existen.

### States and Transitions

[To be designed]

### Interactions with Other Systems

[To be designed]

## Formulas

[To be designed]

## Edge Cases

[To be designed]

## Dependencies

[To be designed]

## Tuning Knobs

[To be designed]

## Visual/Audio Requirements

[To be designed]

## UI Requirements

[To be designed]

## Acceptance Criteria

[To be designed]

## Open Questions

[To be designed]
