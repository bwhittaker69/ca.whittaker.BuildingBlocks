# Agent Preferences

<!-- BEGIN WHITTAKER_AGENT_PREFERENCES -->
## Brett's Coding-Agent Preferences

- Prefer direct execution for clear implementation requests; ask only when the missing answer is risky or cannot be inferred from repository context.
- Keep changes narrowly scoped to the requested behavior and preserve the existing architecture, naming, and project layout.
- Treat named workflow docs, gap reports, migration plans, and source artifacts as the source of truth for that task.
- Avoid unrelated refactors, formatting churn, generated noise, and dependency changes unless they are required to finish safely.
- Do not revert user or teammate changes. Work with the current tree and call out conflicting edits.
- Prove changes with the smallest meaningful checks: targeted tests first, then broader builds or smoke runs when behavior crosses project boundaries.
- For C# and .NET work, run the relevant `dotnet test` and `dotnet build` commands before calling the work complete.
- Follow the Whittaker testing style from `ca.whittaker`: NUnit, Arrange-Act-Assert, and test folders that mirror production folders.
- Prefer real domain types plus focused fakes or harnesses over brittle sleeps, network calls, or filesystem side effects.
- When a test exposes a small production bug, fix the production behavior and keep the regression test in the same commit.
- On Windows, prefer PowerShell and Windows-native tooling.
- Commit incrementally as work progresses with clear, behavior-focused messages.
- Keep unrelated work out of commits; stage explicit paths when practical.
- Push completed checkpoints when requested.
<!-- END WHITTAKER_AGENT_PREFERENCES -->
