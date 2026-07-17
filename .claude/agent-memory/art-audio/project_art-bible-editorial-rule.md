---
name: art-bible-editorial-rule
description: Art Bible "what not how" rule — no engine implementation details or disguised gameplay rules in art docs
metadata:
  type: project
---

The user added a strict editorial rule for the "Monte Adentro" Art Bible (added
2026-07-15, applies from Section 4 onward, should be treated as retroactively
binding for all sections): "El Art Bible puede definir QUÉ comunica el arte,
pero NUNCA CÓMO lo implementa el motor."

Concretely, this bans from Art Bible drafts:
- Shader names, code parameters, engine-specific systems (e.g. "highlight
  system", material flags, post-process stack references).
- Gameplay rules disguised as art rules (e.g. "el color X activa la mecánica
  Y", "el objeto se vuelve interactuable cuando..."). Art docs may say what a
  color/shape *means* or *evokes*, never what it *triggers* mechanically.

**Why:** Keeps the Art Bible a pure creative/semantic reference that
`unity-specialist` later translates into implementation, and prevents art
direction from silently encoding mechanics that should live in
`game-designer` docs.

**How to apply:** When drafting or reviewing any Art Bible section (color,
lighting, typography, VFX, etc.), phrase every rule in terms of meaning/tone/
emotion, not mechanism. If a technical or mechanical detail seems necessary,
flag it as a handoff note to `unity-specialist` or `game-designer` instead of
writing it into the bible. See related content decisions in
[[monte-adentro-project-context]].
