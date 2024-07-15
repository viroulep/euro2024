#include "../lib/qualifications.cs"
#include "../lib/stages.cs"
#include "../lib/teams-helpers.cs"
#include "../lib/scramble-eligibility.cs"
#include "../lib/group-assignments-helpers.cs"
#include "../lib/staff-assignment-helpers.cs"
#include "../lib/second-rounds.cs"

# FIXME: use live
#CreateFakeResults(_333bf-r2, 160)
ClearConflictingAssignments(_333bf-r2)

AssignGroups(_333bf-r2,
    Concat(TopResults(_333bf-r2, 20), EveryoneAssignmentSet()))

Map(
  SundayStages(),
  AssignStaff(
    _333bf-r2,
    (Stage() == Second<Number, String>()),
    StaffTeamMembersNotQualified(First<Number, String>(), "Su", _333bf, 1),
    ParametrizedJobs(CanScrambleEvent(_333), 2, 4, 3, 15),
    DefaultStaffScorers(_333, 12s, 5),
    fill=true))

# FIXME: use live
#CreateFakeResults(_666-r2, 20)
ClearConflictingAssignments(_666-r2)

AssignGroups(_666-r2,
    Concat(TopResults(_666-r2, 10), EveryoneAssignmentSet()))

Map(
  FinalStagesSat(),
  AssignStaff(
    _666-r2,
    (Stage() == Second<Array<Number>, String>()),
    StaffDelegatesNotQualified("Sa", _666, 1),
    ParametrizedJobs(CanScrambleEvent(_666), 2, 4, 2, 10),
    DefaultStaffScorers(_666, 3:20s, 5),
    fill=true))

# FIXME: use live
#CreateFakeResults(_minx-r2, 100)
ClearConflictingAssignments(_minx-r2)

AssignGroups(_minx-r2,
    Concat(TopResults(_minx-r2, 20), EveryoneAssignmentSet()))

# FIXME: if failure, just set the number of delegates to 1
Map(
  SaturdayStages(),
  AssignStaff(
    _minx-r2,
    (Stage() == Second<Number, String>()),
    StaffTeamMembersNotQualified(First<Number, String>(), "Sa", _minx, 1),
    ParametrizedJobs(CanScrambleEvent(_minx), 2, 4, 3, 15),
    DefaultStaffScorers(_minx, 1:20s, 5),
    fill=true))

# FIXME: use live
#CreateFakeResults(_clock-r2, 160)
ClearConflictingAssignments(_clock-r2)

AssignGroups(_clock-r2,
    Concat(TopResults(_clock-r2, 20), EveryoneAssignmentSet()))

Map(
  SaturdayStages(),
  AssignStaff(
    _clock-r2,
    (Stage() == Second<Number, String>()),
    StaffTeamMembersNotQualified(First<Number, String>(), "Sa", _clock, 1),
    ParametrizedJobs(CanScrambleEvent(_clock), 2, 4, 3, 15),
    DefaultStaffScorers(_clock, 20s, 5),
    fill=true))
