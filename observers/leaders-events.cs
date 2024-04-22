#include "../lib/teams-helpers.cs"
Define(
  "LeadersTable",
  Table(
    {1, Array<Person>},
    [Column("Name", Name()),
    Column("Events", RegisteredEvents())]
  )
)
LeadersTable(Filter(AllStaffTeamsMembers(), HasRole("delegate")))
