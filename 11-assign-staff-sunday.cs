#include "lib/qualifications.cs"
#include "lib/stages.cs"
#include "lib/teams-helpers.cs"
#include "lib/scramble-eligibility.cs"
#include "lib/group-assignments-helpers.cs"
#include "lib/staff-assignment-helpers.cs"

Map(
  SundayStages(),
  AssignStaff(
    _333bf-r2,
    (Stage() == Second<Number, String>()),
    StaffTeamMembersNotQualified(First<Number, String>(), "Su", _333bf, 125),
    ParametrizedJobs(CanScrambleEvent(_333), 2, 4, 3, 15),
    DefaultStaffScorers(_333, 12s, 5),
    fill=true))

Map(
  SundayStages(),
  AssignStaff(
    _skewb-r2,
    (Stage() == Second<Number, String>()),
    StaffTeamMembersNotQualified(First<Number, String>(), "Su", _skewb, 150),
    ParametrizedJobs(CanScrambleEvent(_skewb), 2, 4, 3, 15),
    DefaultStaffScorers(_skewb, 10s, 5),
    fill=true))

Map(
  SundayStages(),
  AssignStaff(
    _222-r2,
    (Stage() == Second<Number, String>()),
    StaffTeamMembersNotQualified(First<Number, String>(), "Su", _222, 300),
    ParametrizedJobs(CanScrambleEvent(_222), 2, 4, 3, 15),
    DefaultStaffScorers(_222, 10s, 5),
    fill=true))

Map(
  SundayStages(),
  AssignStaff(
    _pyram-r2,
    (Stage() == Second<Number, String>()),
    StaffTeamMembersNotQualified(First<Number, String>(), "Su", _pyram, 150),
    ParametrizedJobs(CanScrambleEvent(_pyram), 2, 4, 3, 15),
    DefaultStaffScorers(_pyram, 10s, 5),
    fill=true))

Map(
  SundayStages(),
  AssignStaff(
    _333oh-r2,
    (Stage() == Second<Number, String>()),
    StaffTeamMembersNotQualified(First<Number, String>(), "Su", _333oh, 150),
    ParametrizedJobs(CanScrambleEvent(_333), 2, 4, 3, 15),
    DefaultStaffScorers(_333, 12s, 5),
    fill=true))

Map(
  SundayStages(),
  AssignStaff(
    _333-r3,
    (Stage() == Second<Number, String>()),
    StaffTeamMembersNotQualified(First<Number, String>(), "Su", _333, 150),
    ParametrizedJobs(CanScrambleEvent(_333), 2, 4, 3, 15),
    DefaultStaffScorers(_333, 12s, 5),
    fill=true))

# finals: _333bf-r3, _sq1-r3, _333oh-r3, _555-r3, _skewb-r3, _pyram-r3, _444-r3, _222-r3
# Afternoon
Define("FinalStagesSu",
    [Tuple([1, 2, 5], "Green Stage"), Tuple([3, 4], "Red Stage")])

Map(
  FinalStagesSu(),
  AssignStaff(
    _333bf-r3,
    (Stage() == Second<Array<Number>, String>()),
    StaffDelegatesNotQualified("Su", _333bf, 30),
    ParametrizedJobs(CanScrambleEvent(_333), 2, 3, 2, 10),
    FinalsStaffScorers(_333, 12s, 5),
    fill=true))

Map(
  FinalStagesSu(),
  AssignStaff(
    _sq1-r3,
    (Stage() == Second<Array<Number>, String>()),
    StaffDelegatesNotQualified("Su", _sq1, 30),
    ParametrizedJobs(CanScrambleEvent(_sq1), 2, 3, 1, 10),
    FinalsStaffScorers(_sq1, 18s, 5),
    fill=true))

Map(
  FinalStagesSu(),
  AssignStaff(
    _333oh-r3,
    (Stage() == Second<Array<Number>, String>()),
    StaffDelegatesNotQualified("Su", _333oh, 30),
    ParametrizedJobs(CanScrambleEvent(_333), 2, 3, 2, 10),
    FinalsStaffScorers(_333, 18s, 5),
    fill=true))

Map(
  FinalStagesSu(),
  AssignStaff(
    _555-r3,
    (Stage() == Second<Array<Number>, String>()),
    StaffDelegatesNotQualified("Su", _555, 30),
    ParametrizedJobs(CanScrambleEvent(_555), 2, 3, 2, 10),
    FinalsStaffScorers(_555, 1:20s, 5),
    fill=true))

Map(
  FinalStagesSu(),
  AssignStaff(
    _skewb-r3,
    (Stage() == Second<Array<Number>, String>()),
    StaffDelegatesNotQualified("Su", _skewb, 30),
    ParametrizedJobs(CanScrambleEvent(_skewb), 2, 2, 3, 10),
    FinalsStaffScorers(_skewb, 10s, 5),
    fill=true))

Map(
  FinalStagesSu(),
  AssignStaff(
    _pyram-r3,
    (Stage() == Second<Array<Number>, String>()),
    StaffDelegatesNotQualified("Su", _pyram, 30),
    ParametrizedJobs(CanScrambleEvent(_pyram), 2, 2, 3, 10),
    FinalsStaffScorers(_pyram, 10s, 5),
    fill=true))

Map(
  FinalStagesSu(),
  AssignStaff(
    _444-r3,
    (Stage() == Second<Array<Number>, String>()),
    StaffDelegatesNotQualified("Su", _444, 30),
    ParametrizedJobs(CanScrambleEvent(_444), 2, 3, 2, 10),
    FinalsStaffScorers(_444, 40s, 5),
    fill=true))

Map(
  FinalStagesSu(),
  AssignStaff(
    _222-r3,
    (Stage() == Second<Array<Number>, String>()),
    StaffDelegatesNotQualified("Su", _222, 30),
    ParametrizedJobs(CanScrambleEvent(_222), 2, 2, 3, 10),
    FinalsStaffScorers(_222, 10s, 5),
    fill=true))

ExportWCIF("post-assign-staff-all.json")
#TODO: assign 3x3 finals?
