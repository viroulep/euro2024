
# Do not use in prod
Define("CreateFakeResults", AddResults({1, Round}, Persons((PsychSheetPosition(EventForRound({1, Round})) < {2, Number}))))

Define("ClearConflictingAssignments",
    ClearAssignments(
      Filter(AllStaffTeamsMembers(), CompetingInRound({1, Round})),
      true, false, Groups({1, Round})))

