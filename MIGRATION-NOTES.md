# Migration Notes — Unity Solo Fork

Fork of `Donchitos/Claude-Code-Game-Studios` (original: 49 agents, 3-tier
director/lead/specialist hierarchy, Godot+Unity+Unreal agent sets).

## What changed

1. **Removed non-Unity engine agents and docs**: all `godot-*`, `ue-*`, and
   `unreal-specialist` agent files, plus `docs/engine-reference/godot` and
   `docs/engine-reference/unreal`.
2. **Removed the narrative department**: `narrative-director.md`,
   `writer.md`, and the `team-narrative` skill (you indicated narrative is
   not a focus).
3. **Removed the `CCGS Skill Testing Framework/` directory**: that's tooling
   for maintaining the *upstream* project's own skills, not for using the
   studio on your game.
4. **Collapsed 37 remaining agents into 9** (see table in `CLAUDE.md`).
   Each merged agent file keeps a "From `<original-agent>`" breakdown under
   **Key Responsibilities** so you can trace scope back to the source agent
   during review, and lists all original tools/skills as a union.
5. **Rewrote ~1,200 cross-references** to the old 37 agent names throughout
   `docs/`, `skills/`, `rules/`, and the agents themselves, pointing them at
   the corresponding one of the 9 new agents.
6. **Set `production/review-mode.txt` to `solo`**: there's no separate
   director tier left to gate on, so the original `full`/`lean` distinction
   doesn't apply the same way. Override per-run with `--review lean` if you
   want phase checkpoints back.

## What still needs a manual pass (didn't auto-fix, low risk if left alone)

- **`.claude/skills/setup-engine/SKILL.md`** (716 lines): heavily branches on
  Godot/Unity/Unreal setup steps. Since `CLAUDE.md` now hardcodes `Engine:
  Unity`, the dead Godot/Unreal branches just won't be taken — but the file
  is noisy. Worth trimming by hand if you're going to run `/setup-engine`
  again on a fresh project; harmless to leave otherwise.
- **`docs/WORKFLOW-GUIDE.md`, `.claude/docs/agent-coordination-map.md`,
  `.claude/docs/agent-roster.md`, `.claude/docs/quick-start.md`,
  `UPGRADING.md`, `README.md`**: these are the upstream project's own
  meta-documentation about its 49-agent design. They now contain
  `(n/a in this config...)` placeholders wherever a removed agent used to be
  named. They're descriptive, not executable — safe to ignore or delete;
  only worth rewriting if you want the docs to read cleanly for a teammate
  later.
- **`docs/registry/architecture.yaml`**: one reference to `writer` replaced
  with a placeholder — check this doesn't break a schema you rely on if you
  use the registry tooling.

## Things I did NOT change (verify they still match your workflow)

- **Skills themselves** (`/code-review`, `/architecture-review`,
  `/sprint-plan`, etc.) were left structurally intact — only the *agent
  names* they reference were rewritten. The actual workflow logic in each
  `SKILL.md` was not reviewed line-by-line for whether it still makes sense
  with 9 agents instead of 49 (e.g. a skill that expected 3 independent
  reviewers may now expect the same agent to review its own work — worth
  spot-checking `design-review` and `code-review` before relying on them).
- **Hooks** (`.claude/hooks/*.sh`) were not touched — none of them hardcode
  agent names, only file-path patterns.

## Agent roster reference

See the table in `CLAUDE.md` for the final 10 agents and what each one
absorbed.

## Update: narrative restored (10th agent)

`narrative-writer` (fusion of `narrative-director` + `writer`) was added back
after the project turned out to need more narrative than initially expected.
All prior `(n/a in this config — no narrative agent)` placeholders throughout
`docs/`, `skills/`, and the other agent files were replaced with
`narrative-writer`. `team-narrative`, the skill deleted in the first pass,
was **not** restored — recreate it by hand if you want a dedicated narrative
workflow skill, or just invoke `@narrative-writer` directly.
