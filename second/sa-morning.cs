#include "../lib/qualifications.cs"
#include "../lib/stages.cs"
#include "../lib/teams-helpers.cs"
#include "../lib/scramble-eligibility.cs"
#include "../lib/group-assignments-helpers.cs"
#include "../lib/staff-assignment-helpers.cs"
#include "../lib/second-rounds.cs"


# TODO: do 3x3 with xx-3x3
# FIXME use live
#CreateFakeResults(_444-r3, 50)
ClearConflictingAssignments(_444-r3)

AssignGroups(_444-r3,
    Concat(TopResults(_444-r2, 10), EveryoneAssignmentSet()))

Map(
  FinalStagesSu(),
  AssignStaff(
    _444-r3,
    (Stage() == Second<Array<Number>, String>()),
    StaffDelegatesNotQualified("Su", _444, 1),
    ParametrizedJobs(CanScrambleEvent(_444), 2, 3, 2, 10),
    FinalsStaffScorers(_444, 40s, 5),
    fill=true))

#CreateFakeResults(_minx-r3, 50)
ClearConflictingAssignments(_minx-r3)

AssignGroups(_minx-r3,
    Concat(TopResults(_minx-r2, 10), EveryoneAssignmentSet()))

Map(
  FinalStagesSat(),
  AssignStaff(
    _minx-r3,
    (Stage() == Second<Array<Number>, String>()),
    StaffDelegatesNotQualified("Sa", _minx, 1),
    ParametrizedJobs(CanScrambleEvent(_minx), 2, 4, 2, 10),
    DefaultStaffScorers(_minx, 1:20s, 5),
    fill=true))
