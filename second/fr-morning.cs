#include "../lib/qualifications.cs"
#include "../lib/stages.cs"
#include "../lib/teams-helpers.cs"
#include "../lib/scramble-eligibility.cs"
#include "../lib/group-assignments-helpers.cs"
#include "../lib/staff-assignment-helpers.cs"
#include "../lib/second-rounds.cs"


# FIXME: use live
#CreateFakeResults(_skewb-r2, 125)
ClearConflictingAssignments(_skewb-r2)

AssignGroups(_skewb-r2,
    Concat(
      Quali125Green(_skewb-r1),
      Quali125Red(_skewb-r1),
      Quali125Orange(_skewb-r1),
      Quali125Yellow(_skewb-r1),
      Quali125Blue(_skewb-r1),
      EveryoneAssignmentSet()
    ))

Map(
  SundayStages(),
  AssignStaff(
    _skewb-r2,
    (Stage() == Second<Number, String>()),
    StaffTeamMembersNotQualified(First<Number, String>(), "Su", _skewb, 1),
    ParametrizedJobs(CanScrambleEvent(_skewb), 2, 4, 3, 15),
    DefaultStaffScorers(_skewb, 10s, 5),
    fill=true))


#CreateFakeResults(_333oh-r2, 125)
ClearConflictingAssignments(_333oh-r2)

AssignGroups(_333oh-r2,
    Concat(
      Quali125Green(_333oh-r1),
      Quali125Red(_333oh-r1),
      Quali125Orange(_333oh-r1),
      Quali125Yellow(_333oh-r1),
      Quali125Blue(_333oh-r1),
      EveryoneAssignmentSet()
    ))


Map(
  SundayStages(),
  AssignStaff(
    _333oh-r2,
    (Stage() == Second<Number, String>()),
    StaffTeamMembersNotQualified(First<Number, String>(), "Su", _333oh, 1),
    ParametrizedJobs(CanScrambleEvent(_333), 2, 4, 3, 15),
    DefaultStaffScorers(_333, 12s, 5),
    fill=true))

#CreateFakeResults(_sq1-r2, 125)
ClearConflictingAssignments(_sq1-r2)

AssignGroups(_sq1-r2,
    Concat(
      Quali125Green(_sq1-r1),
      Quali125Red(_sq1-r1),
      Quali125Orange(_sq1-r1),
      Quali125Yellow(_sq1-r1),
      Quali125Blue(_sq1-r1),
      EveryoneAssignmentSet()
    ))

Map(
  SaturdayStages(),
  AssignStaff(
    _sq1-r2,
    (Stage() == Second<Number, String>()),
    StaffTeamMembersNotQualified(First<Number, String>(), "Sa", _sq1, 1),
    ParametrizedJobs(CanScrambleEvent(_sq1), 2, 4, 3, 15),
    DefaultStaffScorers(_sq1, 18s, 5),
    fill=true))
