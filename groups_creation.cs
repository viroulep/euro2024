# Helper to show a bit what's going on without going to something sophisticated
# like competitiongroups.
Define(
  "GroupsTable",
  Table(
    {1, Array<Group>},
    [Column("Event", Event()),
    Column("Name", GroupName()),
    Column("Startsat", StartTime())]
  )
)

# FIXME: anyway I can do this without tuples? How to get in Map()?
Define("Stages", [
  Tuple(1, "Blue Stage"),
  Tuple(2, "Red Stage"),
  Tuple(3, "Green Stage"),
  Tuple(4, "Orange Stage"),
  Tuple(5, "Yellow Stage")
])

# FIXME: any way to get the start/end time of the whole _777-r1?
# Create groups for Thursday
Map(Stages(), CreateGroups(_777-r1, 2, Second<Number, String>(), 2024-07-25T10:00, 2024-07-25T11:10))
Map(Stages(), CreateGroups(_555-r1, 4, Second<Number, String>(), 2024-07-25T11:10, 2024-07-25T13:10))
Map(Stages(), CreateGroups(_333bf-r1, 3, Second<Number, String>(), 2024-07-25T14:10, 2024-07-25T15:10))
Map(Stages(), CreateGroups(_666-r1, 3, Second<Number, String>(), 2024-07-25T15:10, 2024-07-25T16:35))
Map(Stages(), CreateGroups(_minx-r1, 3, Second<Number, String>(), 2024-07-25T16:35, 2024-07-25T18:00))
Map(Stages(), CreateGroups(_clock-r1, 4, Second<Number, String>(), 2024-07-25T18:00, 2024-07-25T19:25))

CreateGroups(_333fm-r1-a1, 1, "Side Room", 2024-07-25T09:10, 2024-07-25T10:20)
CreateGroups(_333fm-r1-a2, 1, "Side Room", 2024-07-25T11:45, 2024-07-25T12:55)
CreateGroups(_333fm-r1-a3, 1, "Side Room", 2024-07-26T16:50, 2024-07-26T18:00)

#GroupsTable(Concat(Groups(_777-r1), Groups(_555-r1)))

