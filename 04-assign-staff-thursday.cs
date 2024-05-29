#include "lib/qualifications.cs"
#include "lib/stages.cs"
#include "lib/teams-helpers.cs"
#include "lib/scramble-eligibility.cs"
#include "lib/staff-assignment-helpers.cs"


# 6132 is staff scrambling mbf1-1
# 6133 is staff scrambling mbf1-2
# 6134 is staff scrambling mbf2-1
# 6135 is staff scrambling mbf2-2

AssignMisc(6132,
           SideRoomStaffMembers(),
           MultiScramblingJobs(),
           MakeArray<AssignmentScorer>())
AssignMisc(6133,
           SideRoomStaffMembers(),
           MultiScramblingJobs(),
           [ JobCountScorer(-1) ],
           avoidConflicts=false)

AssignStaff(_333mbf-r1, true, SideRoomStaffMembers(),
    [
      Job("judge", 10, eligibility=Not(HasRole("delegate"))),
      Job("Delegate", 2, eligibility=HasRole("delegate"))
    ],
    [JobCountScorer(-1)])

AssignStaff(_333fm-r1, true, SideRoomStaffMembers(),
    [
      Job("judge", 5, eligibility=Not(HasRole("delegate"))),
      Job("Delegate", 1, eligibility=HasRole("delegate"))
    ],
    [JobCountScorer(-1)])

Map(
  ThursdayStagesMatteo(),
  AssignStaff(
    _777-r1,
    And((Stage() == Second<Number, String>()), (GroupNumber() == 1)),
    StaffTeamMembers(First<Number, String>(), "Th"),
    ParametrizedJobs(CanScrambleEvent(_777), 1, 3, 2, 14),
    DefaultStaffScorers(_777, 4:00s, 5)))
Map(
  ThursdayStagesMatteo(),
  AssignStaff(
    _777-r1,
    And((Stage() == Second<Number, String>()), (GroupNumber() > 1)),
    StaffTeamMembers(First<Number, String>(), "Th"),
    ParametrizedJobs(CanScrambleEvent(_777), 2, 3, 2, 14),
    DefaultStaffScorers(_777, 4:00s, 5)))

Map(
  Concat(ThursdayStagesWallin(), ThursdayStagesOthers()),
  AssignStaff(
    _777-r1,
    (Stage() == Second<Number, String>()),
    StaffTeamMembers(First<Number, String>(), "Th"),
    ParametrizedJobs(CanScrambleEvent(_777), 2, 3, 2, 14),
    DefaultStaffScorers(_777, 4:00s, 5)))

Map(
  ThursdayStagesMatteo(),
  AssignStaff(
    _555-r1,
    And((Stage() == Second<Number, String>()), (GroupNumber() < 3)),
    StaffTeamMembers(First<Number, String>(), "Th"),
    ParametrizedJobs(CanScrambleEvent(_555), 1, 3, 2, 14),
    DefaultStaffScorers(_555, 1:30s, 5)))
Map(
  ThursdayStagesMatteo(),
  AssignStaff(
    _555-r1,
    And((Stage() == Second<Number, String>()), (GroupNumber() > 2)),
    StaffTeamMembers(First<Number, String>(), "Th"),
    ParametrizedJobs(CanScrambleEvent(_555), 2, 3, 2, 14),
    DefaultStaffScorers(_555, 1:30s, 5)))

Map(
  Concat(ThursdayStagesWallin(), ThursdayStagesOthers()),
  AssignStaff(
    _555-r1,
    (Stage() == Second<Number, String>()),
    StaffTeamMembers(First<Number, String>(), "Th"),
    ParametrizedJobs(CanScrambleEvent(_555), 2, 3, 2, 14),
    DefaultStaffScorers(_555, 1:30s, 5)))

Map(
  ThursdayStages(),
  AssignStaff(
    _333bf-r1,
    (Stage() == Second<Number, String>()),
    StaffTeamMembers(First<Number, String>(), "Th"),
    ParametrizedJobs(CanScrambleEvent(_333), 2, 3, 3, 14),
    DefaultStaffScorers(_333, 30s, 5)))

# 6x6x6
Map(
  ThursdayStagesMatteo(),
  AssignStaff(
    _666-r1,
    And((Stage() == Second<Number, String>()), (GroupNumber() < 3)),
    StaffTeamMembers(First<Number, String>(), "Th"),
    ParametrizedJobs(CanScrambleEvent(_666), 1, 4, 2, 14),
    DefaultStaffScorers(_666, 3:00s, 5)))
Map(
  ThursdayStagesMatteo(),
  AssignStaff(
    _666-r1,
    And((Stage() == Second<Number, String>()), (GroupNumber() == 3)),
    StaffTeamMembers(First<Number, String>(), "Th"),
    ParametrizedJobs(CanScrambleEvent(_777), 2, 4, 2, 14),
    DefaultStaffScorers(_666, 3:00s, 5)))

Map(
  Concat(ThursdayStagesWallin(), ThursdayStagesOthers()),
  AssignStaff(
    _666-r1,
    (Stage() == Second<Number, String>()),
    StaffTeamMembers(First<Number, String>(), "Th"),
    ParametrizedJobs(CanScrambleEvent(_666), 2, 4, 2, 14),
    DefaultStaffScorers(_666, 3:00s, 5)))

# FIXME: removed Wallin from Megaminx for now; could he drop either this or clock?
# Or can we simply find team leaders who don't do 10+ events?
Map(
  ThursdayStagesWallin(),
  AssignStaff(
    _minx-r1,
    And((Stage() == Second<Number, String>()), (GroupNumber() == 1)),
    StaffTeamMembers(First<Number, String>(), "Th"),
    ParametrizedJobs(CanScrambleEvent(_minx), 1, 3, 3, 14),
    DefaultStaffScorers(_minx, 1:30s, 5)))
Map(
  ThursdayStagesWallin(),
  AssignStaff(
    _minx-r1,
    And((Stage() == Second<Number, String>()), (GroupNumber() > 1)),
    StaffTeamMembers(First<Number, String>(), "Th"),
    ParametrizedJobs(CanScrambleEvent(_minx), 2, 3, 3, 14),
    DefaultStaffScorers(_minx, 1:30s, 5)))

Map(
  Concat(ThursdayStagesMatteo(), ThursdayStagesOthers()),
  AssignStaff(
    _minx-r1,
    (Stage() == Second<Number, String>()),
    StaffTeamMembers(First<Number, String>(), "Th"),
    ParametrizedJobs(CanScrambleEvent(_minx), 2, 3, 3, 14),
    DefaultStaffScorers(_minx, 1:30s, 5)))

# Same issue with clock, since Daniel competes in MBF
Map(
  ThursdayStagesWallin(),
  AssignStaff(
    _clock-r1,
    And((Stage() == Second<Number, String>()), (GroupNumber() == 1)),
    StaffTeamMembers(First<Number, String>(), "Th"),
    ParametrizedJobs(CanScrambleEvent(_clock), 1, 3, 3, 14),
    DefaultStaffScorers(_clock, 14s, 5)))
Map(
  ThursdayStagesWallin(),
  AssignStaff(
    _clock-r1,
    And((Stage() == Second<Number, String>()), (GroupNumber() > 1)),
    StaffTeamMembers(First<Number, String>(), "Th"),
    ParametrizedJobs(CanScrambleEvent(_clock), 2, 3, 3, 14),
    DefaultStaffScorers(_clock, 14s, 5)))

Map(
  Concat(ThursdayStagesMatteo(), ThursdayStagesOthers()),
  AssignStaff(
    _clock-r1,
    (Stage() == Second<Number, String>()),
    StaffTeamMembers(First<Number, String>(), "Th"),
    ParametrizedJobs(CanScrambleEvent(_clock), 2, 3, 3, 14),
    DefaultStaffScorers(_clock, 14s, 5)))

ExportWCIF("post-assign-staff.json")
