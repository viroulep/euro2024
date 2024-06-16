# Saturday

#include "lib/qualifications.cs"
#include "lib/stages.cs"
#include "lib/teams-helpers.cs"
#include "lib/scramble-eligibility.cs"
#include "lib/group-assignments-helpers.cs"
#include "lib/staff-assignment-helpers.cs"

Define("G1", In(WcaId(), ["2012BRED01", "2010OMUL01"]))
Define("G2", In(WcaId(), ["2012CANT02", "2013WALL03"]))
Define("G3", In(WcaId(), ["2013EGDA01", "2009PROV01", "2012GOOD02"]))
Define("G4", In(WcaId(), ["2009BONN01"]))
Define("G5", In(WcaId(), ["2008VIRO01"]))


# 6132 is staff scrambling mbf1-1
# 6133 is staff scrambling mbf1-2
# 6134 is staff scrambling mbf2-1
# 6135 is staff scrambling mbf2-2

AssignGroups(_333-r1,
  Concat(
     [AssignmentSet("G1", G1(), (GroupNumber() == 1))],
     [AssignmentSet("G2", G2(), (GroupNumber() == 2))],
     [AssignmentSet("G3", G3(), (GroupNumber() == 3))],
     [AssignmentSet("G4", G4(), (GroupNumber() == 4))],
     [AssignmentSet("G5", G5(), (GroupNumber() == 5))],
     [AssignmentSet("SideStaff", SideRoomStaffMembersCondition(), (GroupNumber() < 7))],
     TopCompetitors(_333, 100),
     StaffAssignmentSets(SaturdayStages(), CanScrambleEvent(_333)),
     OrganizersSet(),
     EveryoneAssignmentSet()
    ))

AssignMisc(6134,
           SideRoomStaffMembers(),
           ParametrizedJobs(CanScrambleEvent(_333), 0, 5, 0, 0),
           MakeArray<AssignmentScorer>())

AssignMisc(6135,
           SideRoomStaffMembers(),
           ParametrizedJobs(CanScrambleEvent(_333), 0, 5, 0, 0),
           [ JobCountScorer(-1) ])

# Fill up with any staff up to 15 scramblers
AssignMisc(6134,
           Filter(AllStaffTeamsMembersAvailable("Sa"), Not(CompetingIn(_333mbf))),
           ParametrizedJobs(CanScrambleEvent(_333), 0, 15, 0, 0),
           [ JobCountScorer(-1) ], fill=true)

AssignMisc(6135,
           Filter(AllStaffTeamsMembersAvailable("Sa"), Not(CompetingIn(_333mbf))),
           ParametrizedJobs(CanScrambleEvent(_333), 0, 15, 0, 0),
           [ JobCountScorer(-1) ], fill=true)

Map(
  SaturdayStages(),
  AssignStaff(
    _333-r1,
    (Stage() == Second<Number, String>()),
    StaffTeamMembers(First<Number, String>(), "Sa"),
    ParametrizedJobs(CanScrambleEvent(_333), 2, 3, 3, 14),
    DefaultStaffScorers(_333, 15s, 5)))

AssignMisc(6134,
           SideRoomStaffMembers(),
           ParametrizedJobs(CanScrambleEvent(_333), 2, 0, 0, 0),
           MakeArray<AssignmentScorer>(), fill=true, avoidConflicts=false)

AssignMisc(6135,
           SideRoomStaffMembers(),
           ParametrizedJobs(CanScrambleEvent(_333), 2, 0, 0, 0),
           [ JobCountScorer(-1) ], fill=true, avoidConflicts=false)
ExportWCIF("post-assign-staff-sat-morning.json")
