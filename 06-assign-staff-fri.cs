#include "lib/qualifications.cs"
#include "lib/stages.cs"
#include "lib/teams-helpers.cs"
#include "lib/scramble-eligibility.cs"
#include "lib/staff-assignment-helpers.cs"

# Start by assigning side room staff members, will fill up later in the script
# to reach about 30 judges!
AssignStaff(_444bf-r1, true, SideRoomStaffMembers(),
    ParametrizedJobs(CanScrambleEvent(_444), 2, 4, 2, 12),
    [JobCountScorer(-1)])

AssignStaff(_555bf-r1, true, SideRoomStaffMembers(),
    ParametrizedJobs(CanScrambleEvent(_555), 2, 4, 2, 12),
    [JobCountScorer(-1)])

# Fill up a bit
AssignStaff(_444bf-r1, true, AllStaffTeamsMembersAvailable("Fr"),
    ParametrizedJobs(CanScrambleEvent(_444), 2, 6, 2, 25),
    [JobCountScorer(-1)], fill=true)

AssignStaff(_555bf-r1, true, AllStaffTeamsMembersAvailable("Fr"),
    ParametrizedJobs(CanScrambleEvent(_555), 2, 6, 2, 30),
    [JobCountScorer(-1)], fill=true)


Map(
  FridayStages(),
  AssignStaff(
    _skewb-r1,
    And((Stage() == Second<Number, String>()), (GroupNumber() < 4)),
    StaffTeamMembers(First<Number, String>(), "Fr"),
    ParametrizedJobs(CanScrambleEvent(_skewb), 2, 3, 3, 14),
    DefaultStaffScorers(_skewb, 10s, 5)))

# Understaff a bit these groups, to free up staff for the side room!
Map(
  Concat(FridayStagesMatteo(), FridayStagesOthers()),
  AssignStaff(
    _skewb-r1,
    And((Stage() == Second<Number, String>()), (GroupNumber() > 3)),
    StaffTeamMembers(First<Number, String>(), "Fr"),
    ParametrizedJobs(CanScrambleEvent(_skewb), 2, 3, 3, 12),
    DefaultStaffScorers(_skewb, 10s, 5)))

Map(
  FridayStagesWallin(),
  AssignStaff(
    _skewb-r1,
    And((Stage() == Second<Number, String>()), (GroupNumber() > 3), (GroupNumber() < 7)),
    StaffTeamMembers(First<Number, String>(), "Fr"),
    ParametrizedJobs(CanScrambleEvent(_skewb), 2, 3, 3, 12),
    DefaultStaffScorers(_skewb, 10s, 5)))

Map(
  FridayStagesWallin(),
  AssignStaff(
    _skewb-r1,
    And((Stage() == Second<Number, String>()), (GroupNumber() == 7)),
    StaffTeamMembers(First<Number, String>(), "Fr"),
    ParametrizedJobs(CanScrambleEvent(_skewb), 1, 3, 3, 12),
    DefaultStaffScorers(_skewb, 10s, 5)))

# These groups are also a bit understaffed for the side room
Map(
  FridayStagesMatteo(),
  AssignStaff(
    _333oh-r1,
    And((Stage() == Second<Number, String>()), (GroupNumber() < 3)),
    StaffTeamMembers(First<Number, String>(), "Fr"),
    ParametrizedJobs(CanScrambleEvent(_333), 2, 3, 3, 12),
    DefaultStaffScorers(_333, 20s, 5)))
Map(
  FridayStagesMatteo(),
  AssignStaff(
    _333oh-r1,
    And((Stage() == Second<Number, String>()), (GroupNumber() > 2)),
    StaffTeamMembers(First<Number, String>(), "Fr"),
    ParametrizedJobs(CanScrambleEvent(_333), 1, 3, 3, 12),
    DefaultStaffScorers(_333, 20s, 5)))
Map(
  Concat(FridayStagesWallin(), FridayStagesOthers()),
  AssignStaff(
    _333oh-r1,
    (Stage() == Second<Number, String>()),
    StaffTeamMembers(First<Number, String>(), "Fr"),
    ParametrizedJobs(CanScrambleEvent(_333), 2, 3, 3, 12),
    DefaultStaffScorers(_333, 20s, 5)))

Map(
  FridayStages(),
  AssignStaff(
    _sq1-r1,
    (Stage() == Second<Number, String>()),
    StaffTeamMembers(First<Number, String>(), "Fr"),
    ParametrizedJobs(CanScrambleEvent(_sq1), 2, 3, 3, 14),
    DefaultStaffScorers(_sq1, 18s, 5)))

Map(
  FridayStagesWallin(),
  AssignStaff(
    _444-r1,
    And((Stage() == Second<Number, String>()), (GroupNumber() < 3)),
    StaffTeamMembers(First<Number, String>(), "Fr"),
    ParametrizedJobs(CanScrambleEvent(_444), 2, 4, 2, 14),
    DefaultStaffScorers(_444, 50s, 5)))

Map(
  FridayStagesWallin(),
  AssignStaff(
    _444-r1,
    And((Stage() == Second<Number, String>()), (GroupNumber() > 2)),
    StaffTeamMembers(First<Number, String>(), "Fr"),
    ParametrizedJobs(CanScrambleEvent(_444), 1, 4, 2, 14),
    DefaultStaffScorers(_444, 50s, 5)))

Map(
  FridayStagesMatteo(),
  AssignStaff(
    _444-r1,
    And((Stage() == Second<Number, String>()), Not((GroupNumber() == 3))),
    StaffTeamMembers(First<Number, String>(), "Fr"),
    ParametrizedJobs(CanScrambleEvent(_444), 2, 4, 2, 14),
    DefaultStaffScorers(_444, 50s, 5)))

Map(
  FridayStagesMatteo(),
  AssignStaff(
    _444-r1,
    And((Stage() == Second<Number, String>()), (GroupNumber() == 3)),
    StaffTeamMembers(First<Number, String>(), "Fr"),
    ParametrizedJobs(CanScrambleEvent(_444), 1, 4, 2, 14),
    DefaultStaffScorers(_444, 50s, 5)))

Map(
  FridayStagesOthers(),
  AssignStaff(
    _444-r1,
    (Stage() == Second<Number, String>()),
    StaffTeamMembers(First<Number, String>(), "Fr"),
    ParametrizedJobs(CanScrambleEvent(_444), 2, 4, 2, 14),
    DefaultStaffScorers(_444, 50s, 5)))

Map(
  Concat(FridayStagesMatteo(), FridayStagesOthers()),
  AssignStaff(
    _pyram-r1,
    (Stage() == Second<Number, String>()),
    StaffTeamMembers(First<Number, String>(), "Fr"),
    ParametrizedJobs(CanScrambleEvent(_pyram), 2, 3, 3, 14),
    DefaultStaffScorers(_pyram, 10s, 5)))

Map(
  FridayStagesWallin(),
  AssignStaff(
    _pyram-r1,
    And((Stage() == Second<Number, String>()), (GroupNumber() == 1)),
    StaffTeamMembers(First<Number, String>(), "Fr"),
    ParametrizedJobs(CanScrambleEvent(_pyram), 1, 3, 3, 14),
    DefaultStaffScorers(_pyram, 10s, 5)))

Map(
  FridayStagesWallin(),
  AssignStaff(
    _pyram-r1,
    And((Stage() == Second<Number, String>()), (GroupNumber() > 1)),
    StaffTeamMembers(First<Number, String>(), "Fr"),
    ParametrizedJobs(CanScrambleEvent(_pyram), 2, 3, 3, 14),
    DefaultStaffScorers(_pyram, 10s, 5)))

ExportWCIF("post-assign-staff-fr.json")
