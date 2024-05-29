# Friday

#include "lib/qualifications.cs"
#include "lib/stages.cs"
#include "lib/teams-helpers.cs"
#include "lib/scramble-eligibility.cs"
#include "lib/group-assignments-helpers.cs"


Define("P5", In(WcaId(), ["2012BRED01", "2003BRUC01", "2013WALL03", "2008PIAU01"]))
Define("P6", In(WcaId(), ["2012CANT02", "2013ROGA02", "2013EGDA01", "2009TISS01"]))
Define("P7", In(WcaId(), ["2009PROV01", "2013PAPA01", "2010OMUL01", "2015HENN02"]))

AssignGroups(_444-r1,
    Concat(
      [AssignmentSet("G1", P5(), (GroupNumber() == 1))],
      [AssignmentSet("G2", P6(), (GroupNumber() == 2))],
      [AssignmentSet("G3", P7(), (GroupNumber() == 3))],
      [AssignmentSet("FM competitors", QualifiedFM(), (GroupNumber() < 3))],
      TopCompetitors(_444, 50),
      StaffAssignmentSets(FridayStages(), CanScrambleEvent(_444)),
      OrganizersSet(),
      EveryoneAssignmentSet()
      ))

AssignGroups(_pyram-r1,
    Concat(
      [AssignmentSet("G5", P5(), (GroupNumber() == 5))],
      [AssignmentSet("G6", P6(), (GroupNumber() == 6))],
      [AssignmentSet("G7", P7(), (GroupNumber() == 7))],
      [AssignmentSet("FM competitors", QualifiedFM(), (GroupNumber() > 1))],
      TopCompetitors(_pyram, 50),
      StaffAssignmentSets(FridayStages(), CanScrambleEvent(_pyram)),
      OrganizersSet(),
      EveryoneAssignmentSet()
      ))

ExportWCIF("post-assign-groups-fr.json")
