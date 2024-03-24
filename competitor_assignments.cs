ClearAssignments(Persons(true), true, true)

Define(
  "TopCompetitors",
  [AssignmentSet("top",
                 (PsychSheetPosition({1, Event}) <= {2, Number}),
                 In(Stage(), ["Green"]),
                 featured=true)])


# FIXME: can we do this without WCA Live?
Map(QualifiedPerEvent(),
    AddResults(RoundForEvent(1, First<Event, Array<Person>>()),
               Second<Event, Array<Person>>()))

Define("EveryoneAssignmentSet", [AssignmentSet("everyone", true, true)])

# Easy ones ;)
AssignGroups(_333fm-r1, EveryoneAssignmentSet(), attemptNumber=1, overwrite=true)
AssignGroups(_333fm-r1, EveryoneAssignmentSet(), attemptNumber=2, overwrite=true)
AssignGroups(_333fm-r1, EveryoneAssignmentSet(), attemptNumber=3, overwrite=true)

AssignGroups(_sq1-r1, EveryoneAssignmentSet())

#AssignGroups(_777-r1,
    #Concat([AssignmentSet("FM competitors", QualifiedFM(), (GroupNumber() == 2))],
           #TopCompetitors(_777, 10),
           #EveryoneAssignmentSet()
          #))
#AssignGroups(_555-r1,
    #Concat([AssignmentSet("FM competitors", QualifiedFM(), (GroupNumber() == 1))],
           #TopCompetitors(_555, 20),
           #EveryoneAssignmentSet()
          #))
