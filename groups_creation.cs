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
Define("MainStages", [
  Tuple(1, "Blue Stage"),
  Tuple(2, "Red Stage"),
  Tuple(3, "Green Stage"),
  Tuple(4, "Orange Stage"),
  Tuple(5, "Yellow Stage")
])

Define("FinalStages", [Tuple(2, "Red Stage"), Tuple(3, "Green Stage")])
Define("Createstuff", CreateGroups({1, Round}, {2, Number}, {3, String}, 2024-07-25T10:00, 2024-07-25T11:10))

Map(MainStages(), Createstuff(_777-r1, 2, Second<Number, String>()))

Map(MainStages(), CreateGroups(_555-r1, 4, Second<Number, String>(), 2024-07-25T11:10, 2024-07-25T13:10))
Map(MainStages(), CreateGroups(_333bf-r1, 3, Second<Number, String>(), 2024-07-25T14:10, 2024-07-25T15:10))
Map(MainStages(), CreateGroups(_666-r1, 3, Second<Number, String>(), 2024-07-25T15:10, 2024-07-25T16:35))
Map(MainStages(), CreateGroups(_minx-r1, 3, Second<Number, String>(), 2024-07-25T16:35, 2024-07-25T18:00))
Map(MainStages(), CreateGroups(_clock-r1, 4, Second<Number, String>(), 2024-07-25T18:00, 2024-07-25T19:25))

CreateGroups(_333fm-r1-a1, 1, "Side Room", 2024-07-25T09:10, 2024-07-25T10:20)
CreateGroups(_333fm-r1-a2, 1, "Side Room", 2024-07-25T11:45, 2024-07-25T12:55)

CreateGroups(_333mbf-r1-a1, 2, "Side Room", 2024-07-25T16:00, 2024-07-25T18:20)

# Create groups for Friday

Map(MainStages(), CreateGroups(_skewb-r1, 7, Second<Number, String>(), 2024-07-26T09:00, 2024-07-26T11:05))
Map(MainStages(), CreateGroups(_333oh-r1, 4, Second<Number, String>(), 2024-07-26T11:05, 2024-07-26T12:35))
Map(MainStages(), CreateGroups(_sq1-r1, 3, Second<Number, String>(), 2024-07-26T12:35, 2024-07-26T13:35))
Map(MainStages(), CreateGroups(_444-r1, 5, Second<Number, String>(), 2024-07-26T15:35, 2024-07-26T17:45))
Map(MainStages(), CreateGroups(_pyram-r1, 7, Second<Number, String>(), 2024-07-26T17:45, 2024-07-26T19:50))

CreateGroups(_444bf-r1, 1, "Side Room", 2024-07-26T09:50, 2024-07-26T10:40)
CreateGroups(_555bf-r1, 1, "Side Room", 2024-07-26T11:35, 2024-07-26T12:35)
CreateGroups(_333fm-r1-a3, 1, "Side Room", 2024-07-26T16:50, 2024-07-26T18:00)

# Create groups for Saturday

Map(MainStages(), CreateGroups(_333-r1, 9, Second<Number, String>(), 2024-07-27T09:00, 2024-07-27T12:25))
Map(MainStages(), CreateGroups(_444-r2, 1, Second<Number, String>(), 2024-07-27T12:25, 2024-07-27T12:50))
Map(MainStages(), CreateGroups(_minx-r2, 1, Second<Number, String>(), 2024-07-27T12:50, 2024-07-27T13:15))
Map(MainStages(), CreateGroups(_clock-r2, 1, Second<Number, String>(), 2024-07-27T14:10, 2024-07-27T14:30))
Map(MainStages(), CreateGroups(_555-r2, 1, Second<Number, String>(), 2024-07-27T14:30, 2024-07-27T14:55))
Map(MainStages(), CreateGroups(_sq1-r2, 1, Second<Number, String>(), 2024-07-27T14:55, 2024-07-27T15:15))
Map(MainStages(), CreateGroups(_222-r1, 8, Second<Number, String>(), 2024-07-27T15:15, 2024-07-27T17:35))

Map(FinalStages(), CreateGroups(_666-r2, 1, Second<Number, String>(), 2024-07-27T17:35, 2024-07-27T17:55))
Map(FinalStages(), CreateGroups(_minx-r3, 1, Second<Number, String>(), 2024-07-27T17:55, 2024-07-27T18:15))
Map(FinalStages(), CreateGroups(_clock-r3, 1, Second<Number, String>(), 2024-07-27T18:15, 2024-07-27T18:35))
Map(FinalStages(), CreateGroups(_777-r2, 1, Second<Number, String>(), 2024-07-27T18:35, 2024-07-27T19:00))

CreateGroups(_333mbf-r1-a2, 2, "Side Room", 2024-07-27T10:00, 2024-07-27T12:20)

# Create groups for Sunday

Map(MainStages(), CreateGroups(_333-r2, 4, Second<Number, String>(), 2024-07-28T08:50, 2024-07-28T10:25))
Map(MainStages(), CreateGroups(_333bf-r2, 1, Second<Number, String>(), 2024-07-28T10:25, 2024-07-28T10:45))
Map(MainStages(), CreateGroups(_skewb-r2, 1, Second<Number, String>(), 2024-07-28T10:45, 2024-07-28T11:05))
Map(MainStages(), CreateGroups(_222-r2, 2, Second<Number, String>(), 2024-07-28T11:05, 2024-07-28T11:45))
Map(MainStages(), CreateGroups(_pyram-r2, 1, Second<Number, String>(), 2024-07-28T11:45, 2024-07-28T12:05))
Map(MainStages(), CreateGroups(_333oh-r2, 1, Second<Number, String>(), 2024-07-28T12:05, 2024-07-28T12:25))
Map(MainStages(), CreateGroups(_333-r3, 1, Second<Number, String>(), 2024-07-28T12:25, 2024-07-28T12:50))

Map(FinalStages(), CreateGroups(_333bf-r3, 1, Second<Number, String>(), 2024-07-28T13:50, 2024-07-28T14:10))
Map(FinalStages(), CreateGroups(_sq1-r3, 1, Second<Number, String>(), 2024-07-28T14:10, 2024-07-28T14:30))
Map(FinalStages(), CreateGroups(_333oh-r3, 1, Second<Number, String>(), 2024-07-28T14:30, 2024-07-28T14:50))
Map(FinalStages(), CreateGroups(_555-r3, 1, Second<Number, String>(), 2024-07-28T14:50, 2024-07-28T15:10))
Map(FinalStages(), CreateGroups(_skewb-r3, 1, Second<Number, String>(), 2024-07-28T15:10, 2024-07-28T15:30))
Map(FinalStages(), CreateGroups(_pyram-r3, 1, Second<Number, String>(), 2024-07-28T15:30, 2024-07-28T15:50))
Map(FinalStages(), CreateGroups(_444-r3, 1, Second<Number, String>(), 2024-07-28T15:50, 2024-07-28T16:10))
Map(FinalStages(), CreateGroups(_222-r3, 1, Second<Number, String>(), 2024-07-28T16:10, 2024-07-28T16:30))
CreateGroups(_333-r4, 1, "Green Stage", 2024-07-28T16:45, 2024-07-28T18:30)

#GroupsTable(Flatten(Map(Rounds(), Groups())))

