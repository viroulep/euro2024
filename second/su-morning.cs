#include "../lib/qualifications.cs"
#include "../lib/stages.cs"
#include "../lib/teams-helpers.cs"
#include "../lib/scramble-eligibility.cs"
#include "../lib/group-assignments-helpers.cs"
#include "../lib/staff-assignment-helpers.cs"
#include "../lib/second-rounds.cs"

#CreateFakeResults(_333-r3, 126)
ClearConflictingAssignments(_333-r3)
AssignGroups(_333-r3,
    Concat(
      Quali125Green(_333-r2),
      Quali125Red(_333-r2),
      Quali125Orange(_333-r2),
      Quali125Yellow(_333-r2),
      Quali125Blue(_333-r2),
      EveryoneAssignmentSet()
    ))

Map(
  SundayStages(),
  AssignStaff(
    _333-r3,
    (Stage() == Second<Number, String>()),
    StaffTeamMembersNotQualified(First<Number, String>(), "Su", _333, 1),
    ParametrizedJobs(CanScrambleEvent(_333), 2, 4, 3, 15),
    DefaultStaffScorers(_333, 12s, 5),
    fill=true))



#CreateFakeResults(_333bf-r3, 30)
ClearConflictingAssignments(_333bf-r3)
AssignGroups(_333bf-r3,
    Concat(TopResults(_333bf-r2, 10), EveryoneAssignmentSet()))
Map(
  FinalStagesSu(),
  AssignStaff(
    _333bf-r3,
    (Stage() == Second<Array<Number>, String>()),
    StaffDelegatesNotQualified("Su", _333bf, 1),
    ParametrizedJobs(CanScrambleEvent(_333), 2, 3, 2, 10),
    FinalsStaffScorers(_333, 12s, 5),
    fill=true))


#CreateFakeResults(_skewb-r3, 30)
ClearConflictingAssignments(_skewb-r3)
AssignGroups(_skewb-r3,
    Concat(TopResults(_skewb-r2, 10), EveryoneAssignmentSet()))
Map(
  FinalStagesSu(),
  AssignStaff(
    _skewb-r3,
    (Stage() == Second<Array<Number>, String>()),
    StaffDelegatesNotQualified("Su", _skewb, 1),
    ParametrizedJobs(CanScrambleEvent(_skewb), 2, 2, 3, 10),
    FinalsStaffScorers(_skewb, 10s, 5),
    fill=true))


#CreateFakeResults(_222-r3, 30)
ClearConflictingAssignments(_222-r3)
AssignGroups(_222-r3,
    Concat(TopResults(_222-r2, 10), EveryoneAssignmentSet()))
Map(
  FinalStagesSu(),
  AssignStaff(
    _222-r3,
    (Stage() == Second<Array<Number>, String>()),
    StaffDelegatesNotQualified("Su", _222, 1),
    ParametrizedJobs(CanScrambleEvent(_222), 2, 2, 3, 10),
    FinalsStaffScorers(_222, 10s, 5),
    fill=true))


#CreateFakeResults(_pyram-r3, 30)
ClearConflictingAssignments(_pyram-r3)
AssignGroups(_pyram-r3,
    Concat(TopResults(_pyram-r2, 10), EveryoneAssignmentSet()))
Map(
  FinalStagesSu(),
  AssignStaff(
    _pyram-r3,
    (Stage() == Second<Array<Number>, String>()),
    StaffDelegatesNotQualified("Su", _pyram, 1),
    ParametrizedJobs(CanScrambleEvent(_pyram), 2, 2, 3, 10),
    FinalsStaffScorers(_pyram, 10s, 5),
    fill=true))

#CreateFakeResults(_333oh-r3, 30)
ClearConflictingAssignments(_333oh-r3)
AssignGroups(_333oh-r3,
    Concat(TopResults(_333oh-r2, 10), EveryoneAssignmentSet()))
Map(
  FinalStagesSu(),
  AssignStaff(
    _333oh-r3,
    (Stage() == Second<Array<Number>, String>()),
    StaffDelegatesNotQualified("Su", _333oh, 1),
    ParametrizedJobs(CanScrambleEvent(_333), 2, 3, 2, 10),
    FinalsStaffScorers(_333, 18s, 5),
    fill=true))


#CreateFakeResults(_333-r4, 20)
AssignGroups(_333-r4, EveryoneAssignmentSet())
