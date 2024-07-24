Define(
  "TopCompetitors",
  [AssignmentSet("top",
                 (PsychSheetPosition({1, Event}) <= {2, Number}),
                 In(Stage(), ["Green Stage"]),
                 featured=true)])

Define(
  "TopResults",
  [AssignmentSet("top",
                 (RoundPosition({1, Round}) <= {2, Number}),
                 In(Stage(), ["Green Stage"]),
                 featured=true)])

# 444-r2,555-r2,333bf-r2,clock-r2,megaminx-r2
#- green: 1 to 20
#- red: 21 to 40
#- orange: 41 to 60
#- yellow: 61 to 80
#- blue: 81 to 100
Define(
  "Quali100Green",
  [AssignmentSet("Quali100Green",
                 And((RoundPosition({1, Round}) <= 20),
                     (RoundPosition({1, Round}) > 0)),
                 In(Stage(), ["Green Stage"]),
                 featured=true)])
Define(
  "Quali100Red",
  [AssignmentSet("Quali100Red",
                 And((RoundPosition({1, Round}) <= 40),
                     (RoundPosition({1, Round}) > 20)),
                 In(Stage(), ["Red Stage"]))])
Define(
  "Quali100Orange",
  [AssignmentSet("Quali100Orange",
                 And((RoundPosition({1, Round}) <= 60),
                     (RoundPosition({1, Round}) > 40)),
                 In(Stage(), ["Orange Stage"]))])
Define(
  "Quali100Yellow",
  [AssignmentSet("Quali100Yellow",
                 And((RoundPosition({1, Round}) <= 80),
                     (RoundPosition({1, Round}) > 60)),
                 In(Stage(), ["Yellow Stage"]))])
Define(
  "Quali100Blue",
  [AssignmentSet("Quali100Blue",
                 And((RoundPosition({1, Round}) <= 100),
                     (RoundPosition({1, Round}) > 80)),
                 In(Stage(), ["Blue Stage"]))])


#333-r3,333oh-r2,pyraminx-r2,skewb-r2,sq1-r2
  #- green: 1 to 25
  #- red: 26 to 50
  #- orange: 51 to 75
  #- yellow: 76 to 100
  #- blue: 101 to 125

Define(
  "Quali125Green",
  [AssignmentSet("Quali125Green",
                 And((RoundPosition({1, Round}) <= 25),
                     (RoundPosition({1, Round}) > 0)),
                 In(Stage(), ["Green Stage"]),
                 featured=true)])
Define(
  "Quali125Red",
  [AssignmentSet("Quali125Red",
                 And((RoundPosition({1, Round}) <= 50),
                     (RoundPosition({1, Round}) > 25)),
                 In(Stage(), ["Red Stage"]))])

Define(
  "Quali125Orange",
  [AssignmentSet("Quali125Orange",
                 And((RoundPosition({1, Round}) <= 75),
                     (RoundPosition({1, Round}) > 50)),
                 In(Stage(), ["Orange Stage"]))])

Define(
  "Quali125Yellow",
  [AssignmentSet("Quali125Yellow",
                 And((RoundPosition({1, Round}) <= 100),
                     (RoundPosition({1, Round}) > 75)),
                 In(Stage(), ["Yellow Stage"]))])
Define(
  "Quali125Blue",
  [AssignmentSet("Quali125Blue",
                 And((RoundPosition({1, Round}) <= 125),
                     (RoundPosition({1, Round}) > 100)),
                 In(Stage(), ["Blue Stage"]))])

#For rounds with 250 competitors: (222-r2)
  #group 1:
    #- green: 126 to 150
    #- red: 151 to 175
    #- orange: 176 to 200
    #- yellow: 201 to 225
    #- blue: 226 to 250
  #group 2:
    #- green: 1 to 25
    #- red: 26 to 50
    #- orange: 51 to 75
    #- yellow: 76 to 100
    #- blue: 101 to 125

Define("OrganizersSet",
    [AssignmentSet("orga", (StringProperty("kind") == "Orga"), true)])

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

