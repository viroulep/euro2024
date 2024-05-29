# Friday

#include "lib/qualifications.cs"
#include "lib/stages.cs"
#include "lib/teams-helpers.cs"
#include "lib/scramble-eligibility.cs"
#include "lib/group-assignments-helpers.cs"

# 55bf and 44bf groups were already assigned by 03-assign-first-rounds.

Define("Ulrik", In(WcaId(), ["2012BRED01"]))
Define("Simone", In(WcaId(), ["2012CANT02"]))
Define("Matteo", In(WcaId(), ["2009PROV01"]))

#< 4 for skewb for 4bf staff and comps
AssignGroups(_skewb-r1,
  Concat(
     [AssignmentSet("G1", Ulrik(), (GroupNumber() == 1))],
     [AssignmentSet("G2", Simone(), (GroupNumber() == 2))],
     [AssignmentSet("G3", Matteo(), (GroupNumber() == 3))],
     [AssignmentSet("4BFCompetitors", Qualified4BF(), (GroupNumber() < 3))],
     [AssignmentSet("SideStaff", SideRoomStaffMembersCondition(), (GroupNumber() < 3))],
     TopCompetitors(_skewb, 50),
     StaffAssignmentSets(FridayStages(), CanScrambleEvent(_skewb)),
     OrganizersSet(),
     EveryoneAssignmentSet()
    ))

AssignGroups(_333oh-r1,
  Concat(
     [AssignmentSet("G1", Ulrik(), (GroupNumber() == 1))],
     [AssignmentSet("G3", Simone(), (GroupNumber() == 3))],
     [AssignmentSet("G4", Matteo(), (GroupNumber() == 4))],
     [AssignmentSet("5BFCompetitors", Qualified5BF(), (GroupNumber() == 1))],
     [AssignmentSet("SideStaff", SideRoomStaffMembersCondition(), (GroupNumber() == 1))],
     TopCompetitors(_333oh, 50),
     StaffAssignmentSets(FridayStages(), CanScrambleEvent(_333)),
     OrganizersSet(),
     EveryoneAssignmentSet()
    ))

AssignGroups(_sq1-r1,
  Concat(
     [AssignmentSet("5BFCompetitors", Qualified5BF(), (GroupNumber() > 1))],
     [AssignmentSet("SideStaff", SideRoomStaffMembersCondition(), (GroupNumber() > 1))],
     TopCompetitors(_sq1, 20),
     StaffAssignmentSets(FridayStages(), CanScrambleEvent(_sq1)),
     OrganizersSet(),
     EveryoneAssignmentSet()
    ))

# This was split into 2 scripts because it timed out
