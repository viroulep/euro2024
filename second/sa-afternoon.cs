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



#CreateFakeResults(_222-r2, 300)
ClearConflictingAssignments(_222-r2)
AssignGroups(_222-r2,
    Concat(TopResults(_222-r2, 20), EveryoneAssignmentSet()))
Map(
  SundayStages(),
  AssignStaff(
    _222-r2,
    (Stage() == Second<Number, String>()),
    StaffTeamMembersNotQualified(First<Number, String>(), "Su", _222, 1),
    ParametrizedJobs(CanScrambleEvent(_222), 2, 4, 3, 15),
    DefaultStaffScorers(_222, 10s, 5),
    fill=true))
