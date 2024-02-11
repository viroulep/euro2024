
ClearAssignments(Persons(true), true, false)

# Easy ones ;)

# FIXME: can we do this without WCA Live?
Map(Events(), AddResults(RoundForEvent(1), Persons(CompetingIn())))

Define("EveryoneAssignmentSet", [AssignmentSet("everyone", true, true)])

AssignGroups(_333fm-r1, EveryoneAssignmentSet(), attemptNumber=1, overwrite=true)
AssignGroups(_333fm-r1, EveryoneAssignmentSet(), attemptNumber=2, overwrite=true)
AssignGroups(_333fm-r1, EveryoneAssignmentSet(), attemptNumber=3, overwrite=true)
#AssignGroups(_777-r1, EveryoneAssignmentSet())
