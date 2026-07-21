---
name: project_gdd-ac-numbering-convention
description: Monte Adentro GDDs append fixed-blocker ACs with out-of-sequence numbers instead of renumbering existing ACs
metadata:
  type: project
---

When a GDD goes through `/design-review`, gets blockers, and is fixed, new or
reworked Acceptance Criteria are appended with the next free AC number and
inserted into the document near the AC they relate to, rather than renumbering
the whole sequence. Example: `design/gdd/sistema-de-casos.md` re-review
(2026-07-18) added AC-23, AC-24, AC-25 after AC-05, AC-10, AC-14 respectively,
each carrying a note pointing back at the AC/Edge Case it complements.

**Why:** Preserves stable AC references across review cycles (external
trackers, prior review notes) instead of shifting every downstream AC number
on every revision.

**How to apply:** When reviewing any Monte Adentro GDD's Acceptance Criteria
section, do not assume ACs are in strict numeric/thematic order — check for
trailing out-of-sequence numbers first and read each against the AC it names
as its complement, checking specifically for redundancy (does the new AC
retest a clause the original AC already covers?) vs. genuine new coverage.
