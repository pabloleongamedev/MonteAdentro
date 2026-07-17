# Agent Coordination and Delegation Map

## Organizational Hierarchy

```
                           [Human Developer]
                                 |
                 +---------------+---------------+
                 |               |               |
         game-designer  architect  producer
                 |               |               |
        +--------+--------+     |        (coordinates all)
        |        |        |     |
  game-designer art-dir  narr-dir  architect  qa-engineer  audio-dir
        |        |        |         |                |        |
     +--+--+     |     +--+--+  +--+--+--+--+--+   |        |
     |  |  |     |     |     |  |  |  |  |  |  |   |        |
    sys lvl eco  ta   wrt  wrld gp ep  ai net tl ui qa-t    snd
                                 |
                             +---+---+
                             |       |
                          perf-a   devops   analytics

  Additional Leads (report to producer/directors):
    producer         -- Release pipeline, versioning, deployment
    producer       -- i18n, string tables, translation pipeline
    gameplay-programmer              -- Rapid throwaway prototypes, concept validation
    tools-devops       -- Anti-cheat, exploits, data privacy, network security
    qa-engineer -- WCAG, colorblind, remapping, text scaling
    level-designer       -- Seasons, events, battle passes, retention, live economy
    producer       -- Patch notes, player feedback, crisis comms

  Engine Specialists (use the SET matching your engine):
    (n/a in this config — other-engine agent removed)  -- UE5 lead: Blueprint/C++, GAS overview, UE subsystems
      (n/a in this config — other-engine agent removed)         -- GAS: abilities, effects, attributes, tags, prediction
      (n/a in this config — other-engine agent removed)   -- Blueprint: BP/C++ boundary, graph standards, optimization
      (n/a in this config — other-engine agent removed) -- Networking: replication, RPCs, prediction, bandwidth
      (n/a in this config — other-engine agent removed)         -- UI: UMG, CommonUI, widget hierarchy, data binding

    unity-specialist   -- Unity lead: MonoBehaviour/DOTS, Addressables, URP/HDRP
      unity-specialist         -- DOTS/ECS: Jobs, Burst, hybrid renderer
      unity-specialist       -- Shaders: Shader Graph, VFX Graph, SRP customization
      unity-specialist -- Assets: async loading, bundles, memory, CDN
      unity-specialist           -- UI: UI Toolkit, UGUI, UXML/USS, data binding

    (n/a in this config — other-engine agent removed)   -- Godot 4 lead: GDScript, node/scene, signals, resources
      (n/a in this config — other-engine agent removed)    -- GDScript: static typing, patterns, signals, performance
      (n/a in this config — other-engine agent removed)      -- C#: .NET patterns, [Signal] delegates, async, type-safe node access
      (n/a in this config — other-engine agent removed)      -- Shaders: Godot shading language, visual shaders, VFX
      (n/a in this config — other-engine agent removed) -- Native: C++/Rust bindings, GDExtension, build systems
```

### Legend
```
sys  = game-designer       gp  = gameplay-programmer
lvl  = level-designer         ep  = unity-specialist
eco  = game-designer       ai  = gameplay-programmer
ta   = unity-specialist       net = gameplay-programmer
wrt  = narrative-writer                 tl  = tools-devops
wrld = level-designer          ui  = unity-specialist
snd  = art-audio         qa-t = qa-engineer
narr-dir = narrative-writer perf-a = qa-engineer
art-dir = art-audio
```

## Delegation Rules

### Who Can Delegate to Whom

| From | Can Delegate To |
|------|----------------|
| game-designer | game-designer, art-audio, art-audio, narrative-writer |
| architect | architect, tools-devops, qa-engineer, unity-specialist (technical decisions) |
| producer | Any agent (task assignment within their domain only) |
| game-designer | game-designer, level-designer, game-designer |
| architect | gameplay-programmer, unity-specialist, gameplay-programmer, gameplay-programmer, tools-devops, unity-specialist |
| art-audio | unity-specialist, game-designer |
| art-audio | art-audio |
| narrative-writer | narrative-writer, level-designer |
| qa-engineer | qa-engineer |
| producer | tools-devops (release builds), qa-engineer (release testing) |
| producer | narrative-writer (string review), unity-specialist (text fitting) |
| gameplay-programmer | (works independently, reports findings to producer and relevant leads) |
| tools-devops | gameplay-programmer (security review), architect (secure patterns) |
| qa-engineer | game-designer (accessible patterns), unity-specialist (implementation), qa-engineer (a11y testing) |
| [engine]-specialist | engine sub-specialists (delegates subsystem-specific work) |
| [engine] sub-specialists | (advises all programmers on engine subsystem patterns and optimization) |
| level-designer | game-designer (live economy), producer (event comms), tools-devops (engagement metrics) |
| producer | (works with producer for approval, producer for patch note timing) |

### Escalation Paths

| Situation | Escalate To |
|-----------|------------|
| Two designers disagree on a mechanic | game-designer |
| Game design vs narrative conflict | game-designer |
| Game design vs technical feasibility | producer (facilitates), then game-designer + architect |
| Art vs audio tonal conflict | game-designer |
| Code architecture disagreement | architect |
| Cross-system code conflict | architect, then architect |
| Schedule conflict between departments | producer |
| Scope exceeds capacity | producer, then game-designer for cuts |
| Quality gate disagreement | qa-engineer, then architect |
| Performance budget violation | qa-engineer flags, architect decides |

## Common Workflow Patterns

### Pattern 1: New Feature (Full Pipeline)

```
1. game-designer  -- Approves feature concept aligns with vision
2. game-designer      -- Creates design document with full spec
3. producer           -- Schedules work, identifies dependencies
4. architect    -- Designs code architecture, creates interface sketch
5. [specialist-programmer] -- Implements the feature
6. unity-specialist   -- Implements visual effects (if needed)
7. narrative-writer             -- Creates text content (if needed)
8. art-audio     -- Creates audio event list (if needed)
9. qa-engineer          -- Writes test cases
10. qa-engineer           -- Reviews and approves test coverage
11. architect   -- Code review
12. qa-engineer         -- Executes tests
13. producer          -- Marks task complete
```

### Pattern 2: Bug Fix

```
1. qa-engineer          -- Files bug report with /bug-report
2. qa-engineer            -- Triages severity and priority
3. producer           -- Assigns to sprint (if not S1)
4. architect    -- Identifies root cause, assigns to programmer
5. [specialist-programmer] -- Fixes the bug
6. architect    -- Code review
7. qa-engineer          -- Verifies fix and runs regression
8. qa-engineer            -- Closes bug
```

### Pattern 3: Balance Adjustment

```
1. tools-devops -- Identifies imbalance from data (or player reports)
2. game-designer      -- Evaluates the issue against design intent
3. game-designer   -- Models the adjustment
4. game-designer      -- Approves the new values
5. [data file update] -- Change configuration values
6. qa-engineer          -- Regression test affected systems
7. tools-devops -- Monitor post-change metrics
```

### Pattern 4: New Area/Level

```
1. narrative-writer -- Defines narrative purpose and beats for the area
2. level-designer      -- Creates lore and environmental context
3. level-designer     -- Designs layout, encounters, pacing
4. game-designer      -- Reviews mechanical design of encounters
5. art-audio       -- Defines visual direction for the area
6. art-audio     -- Defines audio direction for the area
7. [implementation by relevant programmers and artists]
8. narrative-writer             -- Creates area-specific text content
9. qa-engineer          -- Tests the complete area
```

### Pattern 5: Sprint Cycle

```
1. producer           -- Plans sprint with /sprint-plan new
2. [All agents]       -- Execute assigned tasks
3. producer           -- Daily status with /sprint-plan status
4. qa-engineer            -- Continuous testing during sprint
5. architect    -- Continuous code review during sprint
6. producer           -- Sprint retrospective with post-sprint hook
7. producer           -- Plans next sprint incorporating learnings
```

### Pattern 6: Milestone Checkpoint

```
1. producer           -- Runs /milestone-review
2. game-designer  -- Reviews creative progress
3. architect -- Reviews technical health
4. qa-engineer            -- Reviews quality metrics
5. producer           -- Facilitates go/no-go discussion
6. [All directors]    -- Agree on scope adjustments if needed
7. producer           -- Documents decisions and updates plans
```

### Pattern 7: Release Pipeline

```text
1. producer             -- Declares release candidate, confirms milestone criteria met
2. producer      -- Cuts release branch, generates /release-checklist
3. qa-engineer              -- Runs full regression, signs off on quality
4. producer    -- Verifies all strings translated, text fitting passes
5. qa-engineer  -- Confirms performance benchmarks within targets
6. tools-devops      -- Builds release artifacts, runs deployment pipeline
7. producer      -- Generates /changelog, tags release, creates release notes
8. architect   -- Final sign-off on major releases
9. producer      -- Deploys and monitors for 48 hours
10. producer            -- Marks release complete
```

### Pattern 8: Concept Prototype (early — before GDDs)

```text
1. game-designer        -- Defines the hypothesis and success criteria
2. gameplay-programmer           -- Scaffolds concept prototype with /prototype
3. gameplay-programmer           -- Builds minimal implementation (1-3 days)
4. game-designer        -- Evaluates prototype against criteria
5. gameplay-programmer           -- Documents findings in REPORT.md
6. game-designer    -- PROCEED / PIVOT / KILL decision (full mode only)
7. game-designer        -- Informs GDD writing with prototype learnings if PROCEED
```

### Pattern 8b: Vertical Slice (pre-production — after GDDs and architecture)

```text
1. game-designer        -- Confirms slice scope against GDDs
2. gameplay-programmer           -- Builds production-quality end-to-end build with /vertical-slice
3. gameplay-programmer           -- Conducts internal playtest sessions (minimum 1)
4. gameplay-programmer           -- Documents findings in REPORT.md
5. game-designer    -- Go/no-go decision on proceeding to Production (full mode)
6. producer             -- Schedules Production epics/sprints if PROCEED
```

### Pattern 9: Live Event / Season Launch

```text
1. level-designer     -- Designs event/season content, rewards, schedule
2. game-designer         -- Validates gameplay mechanics for event
3. game-designer      -- Balances event economy and reward values
4. narrative-writer    -- Provides seasonal narrative theme
5. narrative-writer                -- Creates event descriptions and lore
6. producer              -- Schedules implementation work
7. [implementation by relevant programmers]
8. qa-engineer               -- Test event flow end-to-end
9. producer     -- Drafts event announcement and patch notes
10. producer      -- Deploys event content
11. tools-devops   -- Monitors event participation and metrics
12. level-designer    -- Post-event analysis and learnings
```

## Cross-Domain Communication Protocols

### Design Change Notification

When a design document changes, the game-designer must notify:
- architect (implementation impact)
- qa-engineer (test plan update needed)
- producer (schedule impact assessment)
- Relevant specialist agents depending on the change

### Architecture Change Notification

When an ADR is created or modified, the architect must notify:
- architect (code changes needed)
- All affected specialist programmers
- qa-engineer (testing strategy may change)
- producer (schedule impact)

### Asset Standard Change Notification

When the art bible or asset standards change, the art-audio must notify:
- unity-specialist (pipeline changes)
- All content creators working with affected assets
- tools-devops (if build pipeline is affected)

## Anti-Patterns to Avoid

1. **Bypassing the hierarchy**: A specialist agent should never make decisions
   that belong to their lead without consultation.
2. **Cross-domain implementation**: An agent should never modify files outside
   their designated area without explicit delegation from the relevant owner.
3. **Shadow decisions**: All decisions must be documented. Verbal agreements
   without written records lead to contradictions.
4. **Monolithic tasks**: Every task assigned to an agent should be completable
   in 1-3 days. If it is larger, it must be broken down first.
5. **Assumption-based implementation**: If a spec is ambiguous, the implementer
   must ask the specifier rather than guessing. Wrong guesses are more expensive
   than a question.
