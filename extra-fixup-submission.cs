#include "lib/qualifications.cs"
#include "lib/stages.cs"
#include "lib/teams-helpers.cs"
#include "lib/scramble-eligibility.cs"
#include "lib/group-assignments-helpers.cs"
#include "lib/staff-assignment-helpers.cs"

Define("AffectedGroups", Flatten(Map([_333-r1, _333bf-r1], Groups())))
ClearAssignments(Persons(true), true, true, AffectedGroups())
ClearMisc(6134)
ClearMisc(6135)

Define("PersonsCompetingInMulti", Persons(And(QualifiedMBF(), Not((WcaId() == "2013WALL03")))))
AssignMisc(5681,
           PersonsCompetingInMulti(),
           [Job("competitor", Length(PersonsCompetingInMulti()))],
           MakeArray<AssignmentScorer>())

AssignMisc(5682,
           PersonsCompetingInMulti(),
           [Job("competitor", Length(PersonsCompetingInMulti()))],
           MakeArray<AssignmentScorer>())

Define("DanielsBlindSets",
    [AssignmentSet("DanielW",
                   (WcaId() == "2013WALL03"),
                   And(In(Stage(), ["Red Stage"]), (GroupNumber() == {1, Number}))),
     AssignmentSet("DanielE",
                   (WcaId() == "2013EGDA01"),
                   And(In(Stage(), ["Red Stage"]), (GroupNumber() == {2, Number})))])

AssignGroups(_333bf-r1,
    Concat(DanielsBlindSets(1, 3),
           [AssignmentSet("Multi competitors", QualifiedMBF(), (GroupNumber() == 1))],
           StaffSideRoomSets(ThursdayStages(), 1),
           TopCompetitors(_333bf, 30),
           StaffAssignmentSets(ThursdayStages(), CanScrambleEvent(_333)),
           EveryoneAssignmentSet()
          ))

Map(
  ThursdayStages(),
  AssignStaff(
    _333bf-r1,
    (Stage() == Second<Number, String>()),
    StaffTeamMembers(First<Number, String>(), "Th"),
    ParametrizedJobs(CanScrambleEvent(_333), 2, 3, 3, 14),
    DefaultStaffScorers(_333, 30s, 5)))

ExportWCIF("postfix-th.json")
# reexecute the 3x3 stuff

#include "07-assign-groups-staff-sat-morning.cs"

ExportWCIF("postfix-all.json")
