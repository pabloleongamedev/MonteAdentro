# Systems Index: Monte Adentro

> **Status**: Approved
> **Created**: 2026-07-15
> **Last Updated**: 2026-07-15
> **Source Concept**: design/gdd/game-concept.md

---

## Overview

Monte Adentro es un juego de deducción narrativa de un solo jugador: el bucle observar → hipotetizar → buscar pruebas → preparar → confrontar exige un sistema de investigación (Sistema de Casos) alimentado por testimonios de NPCs, un motor de reglas por entidad mítica que garantice que cada mito exige un modo de razonar distinto (Pilar 3), un sistema de confrontación que ramifica según la hipótesis del jugador sin usar combate de reflejos, y una capa de persistencia que hace que las consecuencias sean permanentes y visibles entre casos (Pilar 4). El alcance mecánico es deliberadamente acotado: no hay progresión de poder, ni loot, ni combate tradicional — el peso del juego está en la investigación, el razonamiento y la memoria del mundo.

---

## Systems Enumeration

| # | System Name | Category | Priority | Status | Design Doc | Depends On |
|---|-------------|----------|----------|--------|------------|------------|
| 1 | Reloj Real | Core | Vertical Slice | Not Started | — | — |
| 2 | Sistema de Exploración del Hub | Core | Vertical Slice | Not Started | — | — |
| 3 | Sistema de Estado del Mundo + Guardado/Carga (inferred) | Persistence | Vertical Slice (versión mínima) | Not Started | — | — |
| 4 | Sistema de Entidades Míticas | Core | Vertical Slice | Not Started | — | — |
| 5 | Sistema de Testimonios / Diálogo (inferred) | Narrative | Vertical Slice | Not Started | — | Sistema de Exploración del Hub, Sistema de Estado del Mundo |
| 6 | Sistema de Casos | Gameplay | Vertical Slice | Designed (pendiente de revisión) | design/gdd/sistema-de-casos.md | Sistema de Testimonios/Diálogo, Sistema de Estado del Mundo, Sistema de Entidades Míticas, Reloj Real |
| 7 | Sistema de Confrontación de Ingenio | Gameplay | Vertical Slice | Not Started | — | Sistema de Casos, Sistema de Entidades Míticas, Reloj Real, Sistema de Exploración del Hub |
| 8 | Cuaderno del Investigador (inferred) | UI | Vertical Slice | Not Started | — | Sistema de Casos, Sistema de Estado del Mundo |
| 9 | Sistema de Consecuencias Persistentes | Gameplay | MVP | Not Started | — | Sistema de Confrontación de Ingenio, Sistema de Estado del Mundo, Sistema de Entidades Míticas |

---

## Categories

| Category | Description | Systems in this project |
|----------|-------------|--------------------------|
| **Core** | Foundation systems everything depends on | Reloj Real, Sistema de Exploración del Hub, Sistema de Entidades Míticas |
| **Gameplay** | The systems that make the game fun | Sistema de Casos, Sistema de Confrontación de Ingenio, Sistema de Consecuencias Persistentes |
| **Persistence** | Save state and continuity | Sistema de Estado del Mundo + Guardado/Carga |
| **UI** | Player-facing information displays | Cuaderno del Investigador |
| **Narrative** | Story and dialogue delivery | Sistema de Testimonios/Diálogo |

*(Progression, Economy, Audio y Meta se omiten deliberadamente — no aplican al MVP: sin niveles, sin loot, sin economía de progresión, por los anti-pilares del juego.)*

---

## Priority Tiers

| Tier | Definition | Target Milestone | Design Urgency |
|------|------------|------------------|----------------|
| **Vertical Slice** | Necesario para probar que el bucle core es divertido en 1 pueblo, 1 mito, 20-30 min | Vertical slice (`/vertical-slice`) | Diseñar PRIMERO |
| **MVP** | Necesario para el juego completo: 1 región, 5 casos, 3 entidades, consecuencias que se acumulan entre casos | MVP / lanzamiento | Diseñar SEGUNDO |

*(Este proyecto no usa los tiers Alpha/Full Vision del template estándar — el MVP definido en game-concept.md ya es prácticamente el alcance de lanzamiento; la expansión por regiones es contenido post-lanzamiento fuera de este índice.)*

---

## Dependency Map

### Foundation Layer (no dependencies)

1. **Reloj Real** — columna vertebral temporal de todo el juego (Art Bible Sección 2); gobierna cuándo el Mohán "está" y la ventana nocturna del Duende.
2. **Sistema de Exploración del Hub** — sin poder caminar el pueblo (`design/levels/pueblo-hub.md`) no hay nada que investigar.
3. **Sistema de Estado del Mundo + Guardado/Carga** — la infraestructura de persistencia que todo lo demás escribe; sin reglas propias de gameplay, solo almacena.
4. **Sistema de Entidades Míticas** — el "motor" que lee las fichas ya escritas (`design/entities/mohan.md`, `patasola.md`, `duende.md`) y expone sus reglas al resto del juego.

### Core Layer (depende de Foundation)

1. **Sistema de Testimonios/Diálogo** — depende de: Sistema de Exploración del Hub, Sistema de Estado del Mundo
2. **Sistema de Casos** — depende de: Sistema de Testimonios/Diálogo, Sistema de Estado del Mundo, Sistema de Entidades Míticas, Reloj Real

### Feature Layer (depende de Core)

1. **Sistema de Confrontación de Ingenio** — depende de: Sistema de Casos, Sistema de Entidades Míticas, Reloj Real, Sistema de Exploración del Hub
2. **Sistema de Consecuencias Persistentes** — depende de: Sistema de Confrontación de Ingenio, Sistema de Estado del Mundo, Sistema de Entidades Míticas

### Presentation Layer (depende de Features)

1. **Cuaderno del Investigador** — depende de: Sistema de Casos, Sistema de Estado del Mundo

### Polish Layer

*(Ninguno para el MVP — no hay tutoriales/analíticas/accesibilidad planeados todavía en este alcance.)*

---

## Recommended Design Order

| Order | System | Priority | Layer | Agent(s) | Est. Effort |
|-------|--------|----------|-------|----------|-------------|
| 1 | Reloj Real | Vertical Slice | Foundation | game-designer, unity-specialist | S |
| 2 | Sistema de Exploración del Hub | Vertical Slice | Foundation | game-designer, unity-specialist | M |
| 3 | Sistema de Estado del Mundo + Guardado/Carga | Vertical Slice | Foundation | game-designer, unity-specialist | M |
| 4 | Sistema de Entidades Míticas | Vertical Slice | Foundation | game-designer | M |
| 5 | Sistema de Testimonios/Diálogo | Vertical Slice | Core | game-designer, narrative-writer | M |
| 6 | **Sistema de Casos** | Vertical Slice | Core | game-designer | L |
| 7 | Sistema de Confrontación de Ingenio | Vertical Slice | Feature | game-designer | L |
| 8 | Cuaderno del Investigador | Vertical Slice | Presentation | game-designer, unity-specialist | M |
| 9 | Sistema de Consecuencias Persistentes | MVP | Feature | game-designer | M |

---

## Circular Dependencies

- Ninguna encontrada. El grafo es acíclico: Foundation → Core → Feature → Presentation.

---

## High-Risk Systems

| System | Risk Type | Risk Description | Mitigation |
|--------|-----------|-------------------|------------|
| Sistema de Casos | Design | Debe generalizar tres verbos radicalmente distintos (negociar, rechazar, tender trampa) en una sola gramática común sin aplanar lo que los hace únicos — el riesgo central que motivó diseñar este sistema antes que los 5 casos concretos. | Diseñar la "Anatomía de un Caso" como estructura abstracta primero; validar contra las 3 fichas de entidad ya escritas antes de aprobar. |
| Sistema de Confrontación de Ingenio | Design | Las tres entidades usan ejes mecánicos distintos (tiempo/Mohán, espacio/Patasola, patrón/Duende) — el sistema debe soportar los tres sin forzarlos a una interfaz única que borre sus diferencias. | Diseñar el sistema como marco de "fases de decisión" configurable por eje, no como una máquina de estados fija. |
| Sistema de Entidades Míticas | Scope | Riesgo de sobre-ingeniería: diseñar para una extensibilidad de "N regiones futuras" que no se necesita para el MVP de 1 región / 3 entidades. | Diseñar solo para las 3 entidades del MVP; documentar el patrón de extensión como nota, no como requisito de implementación. |

---

## Progress Tracker

| Metric | Count |
|--------|-------|
| Total systems identified | 9 |
| Design docs started | 1 |
| Design docs reviewed | 0 |
| Design docs approved | 0 |
| MVP systems designed | 0/9 |
| Vertical Slice systems designed | 1/8 |

---

## Next Steps

- [x] Review and approve this systems enumeration
- [ ] Design Vertical-Slice-tier systems first, empezando por **Sistema de Casos** (`/design-system sistema-de-casos`)
- [ ] Run `/design-review` on each completed GDD
- [ ] Run `/gate-check pre-production` when Vertical Slice systems are designed
- [ ] Validate with `/vertical-slice` before committing to the full MVP
