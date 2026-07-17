# Claude Code Game Studios (Unity Solo Fork) -- Game Studio Agent Architecture

Indie game development managed through **9 coordinated Claude Code subagents**,
forked from the original 49-agent Claude Code Game Studios for a **solo Unity
developer** working on decoupled systems (SOLID, ScriptableObject-driven
architecture). Godot/Unreal agent sets and the narrative department were
removed; the original director/lead/specialist hierarchy was consolidated into
one agent per domain since a solo dev is the sole decision-maker across all of
those original roles.

## Technology Stack

- **Engine**: Unity
- **Language**: C#
- **Version Control**: Git with trunk-based development
- **Build System**: [SPECIFY: Unity Cloud Build / custom CI / manual]
- **Asset Pipeline**: [SPECIFY: Addressables / AssetBundles / Resources]

## Agent Roster (10 agents)

| Agent | Domain | Fusion of |
|---|---|---|
| `architect` | System architecture, SOLID, ADRs, code review | technical-director + lead-programmer |
| `game-designer` | GDD, mechanics, balance/formulas, UX flows | creative-director + game-designer + economy-designer + ux-designer + systems-designer |
| `gameplay-programmer` | Gameplay/AI/network feature implementation, prototypes | gameplay-programmer + ai-programmer + network-programmer + prototyper |
| `unity-specialist` | Unity APIs, ScriptableObjects, UI Toolkit/UGUI, Addressables, DOTS, shaders | unity-specialist + unity-addressables-specialist + unity-dots-specialist + unity-shader-specialist + unity-ui-specialist + ui-programmer + technical-artist + engine-programmer |
| `tools-devops` | Editor tooling, build/CI, analytics, security review | tools-programmer + devops-engineer + analytics-engineer + security-engineer |
| `qa-engineer` | Test strategy, bug triage, perf profiling, accessibility | qa-lead + qa-tester + performance-analyst + accessibility-specialist |
| `level-designer` | Levels, world-building, live-ops content | level-designer + world-builder + live-ops-designer |
| `producer` | Sprint planning, milestones, releases, localization scope | producer + release-manager + localization-lead + community-manager |
| `art-audio` | Art direction, sound design, third-party asset integration | art-director + audio-director + sound-designer |
| `narrative-writer` | Lore, story cohesion, puzzle-narrative integration, story pacing/delivery | narrative-director + writer |

> Removed entirely (no replacement agent): all Godot/Unreal engine specialists. References to them elsewhere in `docs/` and
> `skills/` were rewritten to point at the closest consolidated agent above;
> a few purely narrative or cross-engine passages were marked
> `(n/a in this config...)` and are safe to delete on sight.

## Engine Version Reference

@docs/engine-reference/unity/VERSION.md

## Review Mode

Set to **solo** by default (`production/review-mode.txt`) since there are no
separate director/department-lead agents to gate on. Override per-run with
`--review lean` if you want phase-level checkpoints back.

## Project Structure

@.claude/docs/directory-structure.md

## Technical Preferences

@.claude/docs/technical-preferences.md

## Coordination Rules

@.claude/docs/coordination-rules.md

## Collaboration Protocol

**User-driven collaboration, not autonomous execution.**
Every task follows: **Question -> Options -> Decision -> Draft -> Approval**

- Agents MUST ask "May I write this to [filepath]?" before using Write/Edit tools
- Agents MUST show drafts or summaries before requesting approval
- Multi-file changes require explicit approval for the full changeset
- No commits without user instruction

See `docs/COLLABORATIVE-DESIGN-PRINCIPLE.md` for full protocol and examples.

> **First session?** If the project has no engine configured and no game concept,
> run `/start` to begin the guided onboarding flow.

## Coding Standards

@.claude/docs/coding-standards.md

## Context Management

@.claude/docs/context-management.md
