#include "../lib/qualifications.cs"
#include "../lib/stages.cs"
#include "../lib/teams-helpers.cs"
#include "../lib/scramble-eligibility.cs"
#include "../lib/group-assignments-helpers.cs"
#include "../lib/staff-assignment-helpers.cs"
#include "../lib/second-rounds.cs"

#CreateFakeResults(_clock-r3, 50)

ClearConflictingAssignments(_clock-r3)

AssignGroups(_clock-r3,
    Concat(TopResults(_clock-r2, 10), EveryoneAssignmentSet()))

Map(
  FinalStagesSat(),
  AssignStaff(
    _clock-r3,
    (Stage() == Second<Array<Number>, String>()),
    StaffDelegatesNotQualified("Sa", _clock, 1),
    ParametrizedJobs(CanScrambleEvent(_clock), 2, 4, 2, 10),
    DefaultStaffScorers(_clock, 10s, 5),
    fill=true))
