#include "../lib/qualifications.cs"
#include "../lib/stages.cs"
#include "../lib/teams-helpers.cs"
#include "../lib/scramble-eligibility.cs"
#include "../lib/group-assignments-helpers.cs"
#include "../lib/staff-assignment-helpers.cs"
#include "../lib/second-rounds.cs"


# FIXME: use live
#CreateFakeResults(_skewb-r2, 160)
ClearConflictingAssignments(_skewb-r2)

AssignGroups(_skewb-r2,
    Concat(TopResults(_skewb-r2, 20), EveryoneAssignmentSet()))

Map(
  SundayStages(),
  AssignStaff(
    _skewb-r2,
    (Stage() == Second<Number, String>()),
    StaffTeamMembersNotQualified(First<Number, String>(), "Su", _skewb, 1),
    ParametrizedJobs(CanScrambleEvent(_skewb), 2, 4, 3, 15),
    DefaultStaffScorers(_skewb, 10s, 5),
    fill=true))


#CreateFakeResults(_333oh-r2, 160)
ClearConflictingAssignments(_333oh-r2)

AssignGroups(_333oh-r2,
    Concat(TopResults(_333oh-r2, 20), EveryoneAssignmentSet()))

Map(
  SundayStages(),
  AssignStaff(
    _333oh-r2,
    (Stage() == Second<Number, String>()),
    StaffTeamMembersNotQualified(First<Number, String>(), "Su", _333oh, 1),
    ParametrizedJobs(CanScrambleEvent(_333), 2, 4, 3, 15),
    DefaultStaffScorers(_333, 12s, 5),
    fill=true))

#CreateFakeResults(_sq1-r2, 160)
ClearConflictingAssignments(_sq1-r2)

AssignGroups(_sq1-r2,
    Concat(TopResults(_sq1-r2, 20), EveryoneAssignmentSet()))

Map(
  SaturdayStages(),
  AssignStaff(
    _sq1-r2,
    (Stage() == Second<Number, String>()),
    StaffTeamMembersNotQualified(First<Number, String>(), "Sa", _sq1, 1),
    ParametrizedJobs(CanScrambleEvent(_sq1), 2, 4, 3, 15),
    DefaultStaffScorers(_sq1, 18s, 5),
    fill=true))
