# Agent Roster

The following agents are available. Each has a dedicated definition file in
`.claude/agents/`. Use the agent best suited to the task at hand. When a task
spans multiple domains, the coordinating agent (usually `producer` or the
domain lead) should delegate to specialists.

## Tier 1 -- Leadership Agents (Opus)
| Agent | Domain | When to Use |
|-------|--------|-------------|
| `game-designer` | High-level vision | Major creative decisions, pillar conflicts, tone/direction |
| `architect` | Technical vision | Architecture decisions, tech stack choices, performance strategy |
| `producer` | Production management | Sprint planning, milestone tracking, risk management, coordination |

## Tier 2 -- Department Lead Agents (Sonnet)
| Agent | Domain | When to Use |
|-------|--------|-------------|
| `game-designer` | Game design | Mechanics, systems, progression, economy, balancing |
| `architect` | Code architecture | System design, code review, API design, refactoring |
| `art-audio` | Visual direction | Style guides, art bible, asset standards, UI/UX direction |
| `art-audio` | Audio direction | Music direction, sound palette, audio implementation strategy |
| `narrative-writer` | Story and writing | Story arcs, world-building, character design, dialogue strategy |
| `qa-engineer` | Quality assurance | Test strategy, bug triage, release readiness, regression planning |
| `producer` | Release pipeline | Build management, versioning, changelogs, deployment, rollbacks |
| `producer` | Internationalization | String externalization, translation pipeline, locale testing |

## Tier 3 -- Specialist Agents (Sonnet or Haiku)
| Agent | Domain | Model | When to Use |
|-------|--------|-------|-------------|
| `game-designer` | Systems design | Sonnet | Specific mechanic implementation, formula design, loops |
| `level-designer` | Level design | Sonnet | Level layouts, pacing, encounter design, flow |
| `game-designer` | Economy/balance | Sonnet | Resource economies, loot tables, progression curves |
| `gameplay-programmer` | Gameplay code | Sonnet | Feature implementation, gameplay systems code |
| `unity-specialist` | Engine systems | Sonnet | Core engine, rendering, physics, memory management |
| `gameplay-programmer` | AI systems | Sonnet | Behavior trees, pathfinding, NPC logic, state machines |
| `gameplay-programmer` | Networking | Sonnet | Netcode, replication, lag compensation, matchmaking |
| `tools-devops` | Dev tools | Sonnet | Editor extensions, pipeline tools, debug utilities |
| `unity-specialist` | UI implementation | Sonnet | UI framework, screens, widgets, data binding |
| `unity-specialist` | Tech art | Sonnet | Shaders, VFX, optimization, art pipeline tools |
| `art-audio` | Sound design | Sonnet | SFX design docs, audio event lists, mixing notes |
| `narrative-writer` | Dialogue/lore | Sonnet | Dialogue writing, lore entries, item descriptions |
| `level-designer` | World/lore design | Sonnet | World rules, faction design, history, geography |
| `qa-engineer` | Test execution | Haiku | Writing test cases, bug reports, test checklists |
| `qa-engineer` | Performance | Sonnet | Profiling, optimization recs, memory analysis |
| `tools-devops` | Build/deploy | Haiku | CI/CD, build scripts, version control workflow |
| `tools-devops` | Telemetry | Sonnet | Event tracking, dashboards, A/B test design |
| `game-designer` | UX flows | Sonnet | User flows, wireframes, accessibility, input handling |
| `gameplay-programmer` | Rapid prototyping | Sonnet | Throwaway prototypes, mechanic testing, feasibility validation |
| `tools-devops` | Security | Sonnet | Anti-cheat, exploit prevention, save encryption, network security |
| `qa-engineer` | Accessibility | Haiku | WCAG compliance, colorblind modes, remapping, text scaling |
| `level-designer` | Live operations | Sonnet | Seasons, events, battle passes, retention, live economy |
| `producer` | Community | Haiku | Patch notes, player feedback, crisis comms, community health |

## Engine-Specific Agents (use the set matching your engine)

### Engine Leads

| Agent | Engine | Model | When to Use |
| ---- | ---- | ---- | ---- |
| `(n/a in this config — other-engine agent removed)` | Unreal Engine 5 | Sonnet | Blueprint vs C++, GAS overview, UE subsystems, Unreal optimization |
| `unity-specialist` | Unity | Sonnet | MonoBehaviour vs DOTS, Addressables, URP/HDRP, Unity optimization |
| `(n/a in this config — other-engine agent removed)` | Godot 4 | Sonnet | GDScript patterns, node/scene architecture, signals, Godot optimization |

### Unreal Engine Sub-Specialists

| Agent | Subsystem | Model | When to Use |
| ---- | ---- | ---- | ---- |
| `(n/a in this config — other-engine agent removed)` | Gameplay Ability System | Sonnet | Abilities, gameplay effects, attribute sets, tags, prediction |
| `(n/a in this config — other-engine agent removed)` | Blueprint Architecture | Sonnet | BP/C++ boundary, graph standards, naming, BP optimization |
| `(n/a in this config — other-engine agent removed)` | Networking/Replication | Sonnet | Property replication, RPCs, prediction, relevancy, bandwidth |
| `(n/a in this config — other-engine agent removed)` | UMG/CommonUI | Sonnet | Widget hierarchy, data binding, CommonUI input, UI performance |

### Unity Sub-Specialists

| Agent | Subsystem | Model | When to Use |
| ---- | ---- | ---- | ---- |
| `unity-specialist` | DOTS/ECS | Sonnet | Entity Component System, Jobs, Burst compiler, hybrid renderer |
| `unity-specialist` | Shaders/VFX | Sonnet | Shader Graph, VFX Graph, URP/HDRP customization, post-processing |
| `unity-specialist` | Asset Management | Sonnet | Addressable groups, async loading, memory, content delivery |
| `unity-specialist` | UI Toolkit/UGUI | Sonnet | UI Toolkit, UXML/USS, UGUI Canvas, data binding, cross-platform input |

### Godot Sub-Specialists

| Agent | Subsystem | Model | When to Use |
| ---- | ---- | ---- | ---- |
| `(n/a in this config — other-engine agent removed)` | GDScript | Sonnet | Static typing, design patterns, signals, coroutines, GDScript performance |
| `(n/a in this config — other-engine agent removed)` | C# / .NET | Sonnet | .NET patterns, [Signal] delegates, async, nullable types, type-safe node access |
| `(n/a in this config — other-engine agent removed)` | Shaders/Rendering | Sonnet | Godot shading language, visual shaders, particles, post-processing |
| `(n/a in this config — other-engine agent removed)` | GDExtension | Sonnet | C++/Rust bindings, native performance, custom nodes, build systems |
