#include "../lib/qualifications.cs"
#include "../lib/stages.cs"
#include "../lib/teams-helpers.cs"
#include "../lib/scramble-eligibility.cs"
#include "../lib/group-assignments-helpers.cs"
#include "../lib/staff-assignment-helpers.cs"
#include "../lib/second-rounds.cs"


# FIXME: use WCA Live
#CreateFakeResults(_777-r2, 21)
ClearConflictingAssignments(_777-r2)

AssignGroups(_777-r2,
    Concat(TopResults(_777-r2, 10), EveryoneAssignmentSet()))

Map(
  FinalStagesSat(),
  AssignStaff(
    _777-r2,
    (Stage() == Second<Array<Number>, String>()),
    StaffDelegatesNotQualified("Sa", _777, 1),
    ParametrizedJobs(CanScrambleEvent(_777), 2, 4, 2, 10),
    DefaultStaffScorers(_777, 4:00s, 5),
    fill=true))

# FIXME: use WCA Live
#CreateFakeResults(_555-r2, 101)
ClearConflictingAssignments(_555-r2)

AssignGroups(_555-r2,
    Concat(
      Quali100Green(_555-r2),
      Quali100Red(_555-r2),
      Quali100Orange(_555-r2),
      Quali100Yellow(_555-r2),
      Quali100Blue(_555-r2),
      EveryoneAssignmentSet()
    ))

Map(
  SaturdayStages(),
  AssignStaff(
    _555-r2,
    (Stage() == Second<Number, String>()),
    StaffTeamMembersNotQualified(First<Number, String>(), "Sa", _555, 1),
    ParametrizedJobs(CanScrambleEvent(_555), 2, 4, 3, 15),
    DefaultStaffScorers(_555, 1:20s, 5),
    fill=true))
