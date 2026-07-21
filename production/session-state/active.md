# Active Session State

**Task**: Designing Reloj Real GDD (next system in design order after Sistema de Casos)
**Status**: Overview, Player Fantasy, and Core Rules (8 rules) written and approved. Day/night hour split deliberately NOT hardcoded — deferred to Tuning Knobs. Fast-forward auto-interrupts on "interactable moments" only (opportunities for action, not background consequences). Strict architectural decoupling locked: Reloj Real only emits time/phase/transition events, never interprets them or knows what consumes them (Core Rule 8) — this resolved Sistema de Casos' Open Question 3 (clock only gates entity presence, never modifies confrontation rules once started).
**File**: design/gdd/reloj-real.md
**Next**: Continue with States and Transitions (the 5 named phases + transitions, plus the "avance interrumpido" state), then Interactions with Other Systems, then Formulas onward

**Context carried from Sistema de Casos (already reviewed once, 3 blockers fixed)**: Reloj Real must resolve Open Question 3 — does it only gate entity manifestation/physical presence, or also modify confrontation rules once it starts? Must expose discrete transition events (not just continuous phase), because the Duende fiche's "sobrecargar" mechanic explicitly triggers ON the dawn transition (rooster call), not just "being in a phase". Must be bidirectionally consistent: Sistema de Casos already lists Reloj Real as a Hard dependency — Reloj Real's own Dependencies section must list Sistema de Casos (and Sistema de Confrontación de Ingenio) as dependents.

Sistema de Casos stays at "Designed (pendiente de revisión)" — user explicitly decided NOT to re-run `/design-review` right now. Plan: design Reloj Real, then Sistema de Confrontación de Ingenio, then build a vertical slice with one complete case (the Mohán) to prove Sistema de Casos holds up against real content. Only mark Sistema de Casos "Approved" once dependent systems exist and a real cross-review is possible.

**Prior arc reference (Sistema de Casos post-review revision, kept for history)**: `/design-review` (full mode, 8 subagents) ran, verdict NEEDS REVISION. 3 real blockers triaged and fixed (17 edits) — zero-evidence confrontation/declaration mechanism reworded, Core Rule 5 made diegetic to resolve contradiction with the Mohán fiche's off-time attempt, and the Formulas invariant renamed/redefined to "Invariante de interpretaciones defendibles". Two groups of findings (Grupo 2 — system contracts to document later; Grupo 3 — 11 recommendations) were deliberately deferred to future dependent-system GDDs per user's call, not fixed now.

## Progress so far this arc

- Game concept approved: design/gdd/game-concept.md
- Art Bible Sections 1-4 (visual identity core) approved: design/art/art-bible.md
- Village hub geography approved: design/levels/pueblo-hub.md
- 3 MVP entity fiches approved: design/entities/mohan.md, patasola.md, duende.md
- Systems index approved: design/gdd/systems-index.md (9 systems, design order set)
- Sistema de Casos GDD — all 11 sections written (previous arc)
- Sistema de Casos GDD — full `/design-review` run, 3 blockers found and fixed this session (see below)

## What changed in this revision (for the fresh reviewing session to check)

1. **Zero-evidence confrontation / declaration mechanism** — Core Rule 7, AC-14, UI Requirements §3, Flow G, and the handoff note all reworded: interpretation now emerges from actions taken *during* Confrontación, not from a prior declaration step. "Citing a Cuaderno annotation" is no longer the universal mechanic — it's deferred as one possible mechanism to the future Sistema de Confrontación de Ingenio GDD.
2. **Contradiction with the Mohán fiche (off-time attempt)** — Core Rule 5 rewritten diegetically: there is no abstract "Confrontar" action; the player goes to the location and attempts contact, and Confrontación only begins if the entity can manifest per Reloj Real. Core Rule 6 clarified to distinguish this from confronting under-prepared. States table, a new "Nota deliberada 2", a new Edge Case, new **AC-25**, and the Reloj Real rows in Interactions/Dependencies were all updated to match.
3. **Weak invariant** — Formulas' "Invariante de no-determinación única" renamed/redefined as **"Invariante de interpretaciones defendibles"** (old name kept as an explicit alias for continuity). Criterion changed from counting supporting/undermining evidence to authorial judgment: can a reasonable player both defend AND question each candidate. Also clarifies "candidatos viables" = the case's authored set, not per-player knowledge. AC-09 and Edge Case 6 updated to match.

## Deliberately NOT touched this session (user's explicit call)

- **Grupo 2 — Contratos de sistemas** (documentar antes de implementar, no bloquean el diseño): contrato de datos Casos↔Confrontación↔Estado del Mundo; reconciliar AC-20 vs AC-21; reformular AC-06 para no convertir la nota de Core Rule 2 en un gate numérico duro.
- **Grupo 3 — 11 recomendaciones** del review (perfil de sesgo por NPC, AC-05 no cubre leak narrativo, carga de autoría de 4-5 variantes por caso, arquitectura MVVM del Cuaderno, capa de datos many-to-many, disparador de auto-resolución sin especificar, riesgo de patrón acumulativo entre casos, vocabulario visual insuficiente, vacíos de cobertura en ACs, abandono por defecto castigando juego contemplativo, prohibiciones de UI no forzables) — el usuario prefiere que varias las hereden los sistemas futuros (Cuaderno, Reloj Real, Testimonios, Estado del Mundo) en vez de resolverlas prematuramente aquí.

## Open thread

Systems-index.md status for Sistema de Casos still needs updating once the fresh-session re-review lands (Approved / In Review / Designed depending on verdict). No review-log entry written yet either — first review's findings currently only live in this conversation, not in `design/gdd/reviews/`.
