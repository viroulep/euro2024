#include "../lib/qualifications.cs"
#include "../lib/stages.cs"
#include "../lib/teams-helpers.cs"
#include "../lib/scramble-eligibility.cs"
#include "../lib/group-assignments-helpers.cs"
#include "../lib/staff-assignment-helpers.cs"
#include "../lib/second-rounds.cs"


# FIXME: use live
#CreateFakeResults(_444-r2, 100)
ClearConflictingAssignments(_444-r2)

AssignGroups(_444-r2,
    Concat(
      Quali100Green(_444-r1),
      Quali100Red(_444-r1),
      Quali100Orange(_444-r1),
      Quali100Yellow(_444-r1),
      Quali100Blue(_444-r1),
      EveryoneAssignmentSet()
    ))

Map(
  SaturdayStages(),
  AssignStaff(
    _444-r2,
    (Stage() == Second<Number, String>()),
    StaffTeamMembersNotQualified(First<Number, String>(), "Sa", _444, 1),
    ParametrizedJobs(CanScrambleEvent(_444), 2, 4, 3, 15),
    DefaultStaffScorers(_444, 40s, 5),
    fill=true))


#CreateFakeResults(_pyram-r2, 125)
ClearConflictingAssignments(_pyram-r2)

AssignGroups(_pyram-r2,
    Concat(
      Quali125Green(_pyram-r1),
      Quali125Red(_pyram-r1),
      Quali125Orange(_pyram-r1),
      Quali125Yellow(_pyram-r1),
      Quali125Blue(_pyram-r1),
      EveryoneAssignmentSet()
    ))

Map(
  SundayStages(),
  AssignStaff(
    _pyram-r2,
    (Stage() == Second<Number, String>()),
    StaffTeamMembersNotQualified(First<Number, String>(), "Su", _pyram, 1),
    ParametrizedJobs(CanScrambleEvent(_pyram), 2, 4, 3, 15),
    DefaultStaffScorers(_pyram, 10s, 5),
    fill=true))
