ClearAssignments(Persons(true), true, false)


# FIXME: can we do this without WCA Live?
#Map(Events(), AddResults(RoundForEvent(1), Persons(CompetingIn())))
#Map([_777, _555, _333fm, _333bf, _sq1], AddResults(RoundForEvent(1), Persons(CompetingIn())))
Map([_sq1], AddResults(RoundForEvent(1), Persons(CompetingIn())))

Define("EveryoneAssignmentSet", [AssignmentSet("everyone", true, true)])

# Easy ones ;)
#AssignGroups(_333fm-r1, EveryoneAssignmentSet(), attemptNumber=1, overwrite=true)
#AssignGroups(_333fm-r1, EveryoneAssignmentSet(), attemptNumber=2, overwrite=true)
#AssignGroups(_333fm-r1, EveryoneAssignmentSet(), attemptNumber=3, overwrite=true)

AssignGroups(_sq1-r1, EveryoneAssignmentSet(), overwrite=true)

# FIXME: just assigning everything doesn't work
# maybe because of parallel fm ?
#AssignGroups(_777-r1, EveryoneAssignmentSet(), overwrite=true)
#AssignGroups(_555-r1, EveryoneAssignmentSet(), overwrite=true)
