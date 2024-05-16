Define(
  "TopCompetitors",
  [AssignmentSet("top",
                 (PsychSheetPosition({1, Event}) <= {2, Number}),
                 In(Stage(), ["Green"]),
                 featured=true)])

# Take (teamId, stage), GroupNumber, and create an assignment set to put
# side room members in that group.
Define("StaffSideRoomSets",
  Flatten(Map(
    {1, Array<Tuple<Number, String>>},
    [AssignmentSet(("sideroomstaff-" + Second<Number, String>()),
                   And((NumberProperty("staff-team") == First<Number, String>()),
                       (StringProperty("kind") == "Side room")),
                   And((Stage() == Second<Number, String>()),
                       (GroupNumber() == {2, Number}))
    )])))

# For each (teamId, stage), create assignment sets for staff members so that they
# are spread over all the groups of that stage.
Define(
  "StaffAssignmentSets",
  Flatten(Map(
    {1, Array<Tuple<Number, String>>},
    [AssignmentSet(("stage-leads-" + Second<Number, String>()),
                   And(HasRole("delegate"),
                       (NumberProperty("staff-team") == First<Number, String>())),
                   (Stage() == Second<Number, String>())),
     AssignmentSet(("scramblers-" + Second<Number, String>()),
                   And({2, Boolean(Person)},
                       (NumberProperty("staff-team") == First<Number, String>())),
                   (Stage() == Second<Number, String>())),
     AssignmentSet(("staff-" + Second<Number, String>()),
                   (NumberProperty("staff-team") == First<Number, String>()),
                   (Stage() == Second<Number, String>()))])))

Define("EveryoneAssignmentSet", [AssignmentSet("everyone", true, true)])

