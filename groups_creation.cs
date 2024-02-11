# Helper to show a bit what's going on without going to something sophisticated
# like competitiongroups.
Define(
  "GroupsTable",
  Table(
    {1, Array<Group>},
    [Column("Event", Event()),
    Column("N", GroupNumber()),
    Column("Startsat", StartTime())]
  )
)

# FIXME: any way to get the start/end time of the whole _777-r1?
CreateGroups(_777-r1, 3, "Main Room", 2024-07-25T09:30, 2024-07-25T11:00)
CreateGroups(_555-r1, 7, "Main Room", 2024-07-25T11:00, 2024-07-25T13:10)

GroupsTable(Concat(Groups(_777-r1), Groups(_555-r1)))

