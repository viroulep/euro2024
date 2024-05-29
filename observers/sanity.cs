#include "../lib/teams-helpers.cs"

#CheckForMissingGroups()

Table(
  Sort(AllStaffTeamsMembers(), NumberProperty("staff-team")),
  [
    Column("Name", Name()),
    Column("Team", NumberProperty("staff-team")),
    Column("Delegate", NumJobs("Delegate")),
    Column("judge", NumJobs("judge")),
    Column("scrambler", NumJobs("scrambler")),
    Column("runner", NumJobs("runner")),
    Column("total", NumJobs()),
    Column("pref-judge", NumberProperty("percent-judge")),
    Column("pref-scrambler", NumberProperty("percent-scrambler")),
    Column("pref-runner", NumberProperty("percent-runner"))])
