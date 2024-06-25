#include "lib/qualifications.cs"
#include "lib/stages.cs"
#include "lib/teams-helpers.cs"
#include "lib/scramble-eligibility.cs"
#include "lib/group-assignments-helpers.cs"
#include "lib/staff-assignment-helpers.cs"

Map(
  SaturdayStages(),
  AssignStaff(
    _444-r2,
    (Stage() == Second<Number, String>()),
    StaffTeamMembersNotQualified(First<Number, String>(), "Sa", _444, 125),
    ParametrizedJobs(CanScrambleEvent(_444), 2, 4, 3, 15),
    DefaultStaffScorers(_444, 40s, 5),
    fill=true))

Map(
  SaturdayStages(),
  AssignStaff(
    _minx-r2,
    (Stage() == Second<Number, String>()),
    StaffTeamMembersNotQualified(First<Number, String>(), "Sa", _minx, 125),
    ParametrizedJobs(CanScrambleEvent(_minx), 2, 4, 3, 15),
    DefaultStaffScorers(_minx, 1:20s, 5),
    fill=true))

Map(
  SaturdayStages(),
  AssignStaff(
    _clock-r2,
    (Stage() == Second<Number, String>()),
    StaffTeamMembersNotQualified(First<Number, String>(), "Sa", _clock, 125),
    ParametrizedJobs(CanScrambleEvent(_clock), 2, 4, 3, 15),
    DefaultStaffScorers(_clock, 20s, 5),
    fill=true))

Map(
  SaturdayStages(),
  AssignStaff(
    _555-r2,
    (Stage() == Second<Number, String>()),
    StaffTeamMembersNotQualified(First<Number, String>(), "Sa", _555, 125),
    ParametrizedJobs(CanScrambleEvent(_555), 2, 4, 3, 15),
    DefaultStaffScorers(_555, 1:20s, 5),
    fill=true))

Map(
  SaturdayStages(),
  AssignStaff(
    _sq1-r2,
    (Stage() == Second<Number, String>()),
    StaffTeamMembersNotQualified(First<Number, String>(), "Sa", _sq1, 125),
    ParametrizedJobs(CanScrambleEvent(_sq1), 2, 4, 3, 15),
    DefaultStaffScorers(_sq1, 18s, 5),
    fill=true))

# finals: _666-r2, _minx-r3, _clock-r3, _777-r2
Define("FinalStagesSat",
    [Tuple([1, 2, 5], "Red Stage"), Tuple([3, 4], "Green Stage")])

Map(
  FinalStagesSat(),
  AssignStaff(
    _666-r2,
    (Stage() == Second<Array<Number>, String>()),
    StaffDelegatesNotQualified("Sa", _666, 30),
    ParametrizedJobs(CanScrambleEvent(_666), 2, 4, 2, 10),
    DefaultStaffScorers(_666, 3:20s, 5),
    fill=true))
Map(
  FinalStagesSat(),
  AssignStaff(
    _minx-r3,
    (Stage() == Second<Array<Number>, String>()),
    StaffDelegatesNotQualified("Sa", _minx, 30),
    ParametrizedJobs(CanScrambleEvent(_minx), 2, 4, 2, 10),
    DefaultStaffScorers(_minx, 1:20s, 5),
    fill=true))
Map(
  FinalStagesSat(),
  AssignStaff(
    _clock-r3,
    (Stage() == Second<Array<Number>, String>()),
    StaffDelegatesNotQualified("Sa", _clock, 30),
    ParametrizedJobs(CanScrambleEvent(_clock), 2, 4, 2, 10),
    DefaultStaffScorers(_clock, 10s, 5),
    fill=true))
Map(
  FinalStagesSat(),
  AssignStaff(
    _777-r2,
    (Stage() == Second<Array<Number>, String>()),
    StaffDelegatesNotQualified("Sa", _777, 30),
    ParametrizedJobs(CanScrambleEvent(_777), 2, 4, 2, 10),
    DefaultStaffScorers(_777, 4:00s, 5),
    fill=true))
