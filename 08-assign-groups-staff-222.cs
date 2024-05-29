#include "lib/qualifications.cs"
#include "lib/stages.cs"
#include "lib/teams-helpers.cs"
#include "lib/scramble-eligibility.cs"
#include "lib/group-assignments-helpers.cs"
#include "lib/staff-assignment-helpers.cs"

AssignGroups(_222-r1,
  Concat(
     TopCompetitors(_222, 100),
     StaffAssignmentSets(SaturdayStages(), CanScrambleEvent(_222)),
     OrganizersSet(),
     EveryoneAssignmentSet()
    ))

Map(
  SaturdayStages(),
  AssignStaff(
    _222-r1,
    (Stage() == Second<Number, String>()),
    StaffTeamMembers(First<Number, String>(), "Sa"),
    ParametrizedJobs(CanScrambleEvent(_222), 2, 4, 3, 14),
    DefaultStaffScorers(_222, 10s, 5)))

ExportWCIF("post-assign-groups-staff-222.json")
