# Helper to show a bit what's going on without going to something sophisticated
# like competitiongroups.
Define(
  "GroupsTable",
  Table(
    {1, Array<Group>},
    [Column("Event", Event()),
    Column("Name", GroupName()),
    Column("Starts", StartTime()),
    Column("Ends", EndTime())]
  )
)

GroupsTable(Sort(Flatten(Map(Rounds(), Groups())), StartTime()))

