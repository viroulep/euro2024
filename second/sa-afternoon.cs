#include "../lib/qualifications.cs"
#include "../lib/stages.cs"
#include "../lib/teams-helpers.cs"
#include "../lib/scramble-eligibility.cs"
#include "../lib/group-assignments-helpers.cs"
#include "../lib/staff-assignment-helpers.cs"
#include "../lib/second-rounds.cs"

#CreateFakeResults(_555-r3, 50)
ClearConflictingAssignments(_555-r3)
AssignGroups(_555-r3,
    Concat(TopResults(_555-r3, 10), EveryoneAssignmentSet()))
Map(
  FinalStagesSu(),
  AssignStaff(
    _555-r3,
    (Stage() == Second<Array<Number>, String>()),
    StaffDelegatesNotQualified("Su", _555, 30),
    ParametrizedJobs(CanScrambleEvent(_555), 2, 3, 2, 1),
    FinalsStaffScorers(_555, 1:20s, 5),
    fill=true))


#CreateFakeResults(_sq1-r3, 50)
ClearConflictingAssignments(_sq1-r3)
AssignGroups(_sq1-r3,
    Concat(TopResults(_sq1-r3, 10), EveryoneAssignmentSet()))
Map(
  FinalStagesSu(),
  AssignStaff(
    _sq1-r3,
    (Stage() == Second<Array<Number>, String>()),
    StaffDelegatesNotQualified("Su", _sq1, 1),
    ParametrizedJobs(CanScrambleEvent(_sq1), 2, 3, 1, 10),
    FinalsStaffScorers(_sq1, 18s, 5),
    fill=true))


#TODO
Define(
  "QualiGreen",
  [AssignmentSet("QualiGreen",
                 And((RoundPosition({1, Round}) <= {3, Number}),
                     (RoundPosition({1, Round}) > {2, Number})),
                 And(In(Stage(), ["Green Stage"]), (GroupNumber() == {4, Number})),
                 featured=true)])
Define(
  "QualiRed",
  [AssignmentSet("QualiRed",
                 And((RoundPosition({1, Round}) <= {3, Number}),
                     (RoundPosition({1, Round}) > {2, Number})),
                 And(In(Stage(), ["Red Stage"]), (GroupNumber() == {4, Number})))])
Define(
  "QualiOrange",
  [AssignmentSet("QualiOrange",
                 And((RoundPosition({1, Round}) <= {3, Number}),
                     (RoundPosition({1, Round}) > {2, Number})),
                 And(In(Stage(), ["Orange Stage"]), (GroupNumber() == {4, Number})))])
Define(
  "QualiYellow",
  [AssignmentSet("QualiYellow",
                 And((RoundPosition({1, Round}) <= {3, Number}),
                     (RoundPosition({1, Round}) > {2, Number})),
                 And(In(Stage(), ["Yellow Stage"]), (GroupNumber() == {4, Number})))])

Define(
  "QualiBlue",
  [AssignmentSet("QualiBlue",
                 And((RoundPosition({1, Round}) <= {3, Number}),
                     (RoundPosition({1, Round}) > {2, Number})),
                 And(In(Stage(), ["Blue Stage"]), (GroupNumber() == {4, Number})))])

#CreateFakeResults(_222-r2, 251)
ClearConflictingAssignments(_222-r2)
AssignGroups(_222-r2,
    Concat(
      QualiGreen(_222-r2, 125, 150, 1),
      QualiRed(_222-r2, 150, 175, 1),
      QualiOrange(_222-r2, 175, 200, 1),
      QualiYellow(_222-r2, 200, 225, 1),
      QualiBlue(_222-r2, 225, 250, 1),
      QualiGreen(_222-r2, 0, 25, 2),
      QualiRed(_222-r2, 25, 50, 2),
      QualiOrange(_222-r2, 50, 75, 2),
      QualiYellow(_222-r2, 75, 100, 2),
      QualiBlue(_222-r2, 100, 125, 2),
      EveryoneAssignmentSet()
    ))
Map(
  SundayStages(),
  AssignStaff(
    _222-r2,
    (Stage() == Second<Number, String>()),
    StaffTeamMembersNotQualified(First<Number, String>(), "Su", _222, 1),
    ParametrizedJobs(CanScrambleEvent(_222), 2, 4, 3, 15),
    DefaultStaffScorers(_222, 10s, 5),
    fill=true))
