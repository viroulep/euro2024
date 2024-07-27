#include "lib/qualifications.cs"
#include "lib/stages.cs"
#include "lib/teams-helpers.cs"
#include "lib/scramble-eligibility.cs"
#include "lib/group-assignments-helpers.cs"
#include "lib/staff-assignment-helpers.cs"

# FIXME: use WCA Live in prod
#AddResults(_333-r2, Persons((PsychSheetPosition(_333) < 650)))

# NOTE: if assigning does not work, fill the array below with people with
# assignments during all groups, and clear assignments for g1 (and spread
# accross groups if needed).

Define("CleanupOneGroup", [2017NAJA02, 2017NORR01, 2013DIAZ07, 2022HERN16, 2017INIE02, 2023HEND11])
Define("GroupsNForRound", Filter(Groups({1, Round}), (GroupNumber() == {2, Number})))

ClearAssignments(CleanupOneGroup(), true, false, GroupsNForRound(_333-r2, 1))


Define("CompDelegateG1", ["2012GOOD02", "2008PIAU01", "2013EGDA01", "2009PROV01", "2013PAPA01"])
Define("CompDelegateG2", ["2009BONN01", "2009TISS01", "2013WALL03", "2012CANT02", "2013ROGA02"])
Define("CompDelegateG3", ["2008VIRO01", "2015HENN02", "2010OMUL01", "2012BRED01", "2003BRUC01"])

Define("StaffRankedBis",
       And(
           Or((StringProperty("kind") == "Teams"),
              (StringProperty("kind") == "Side room")),
           And((PsychSheetPosition(_333) > {1, Number}),
               (PsychSheetPosition(_333) < {2, Number})),
           Not(HasRole("delegate"))
        ))

Define("StaffG1", Or(StaffRankedBis(0, 126), In(WcaId(), CompDelegateG1())))
Define("StaffG2", Or(StaffRankedBis(125, 251), In(WcaId(), CompDelegateG2())))
Define("StaffG3", Or(StaffRankedBis(250, 401), In(WcaId(), CompDelegateG3())))
Define("StaffG4", StaffRankedBis(400, 551))

Define("StaffMembersCond", Or((StringProperty("kind") == "Teams"), (StringProperty("kind") == "Side room")))

#AssignGroups(_333-r2,
  #Concat(
     #[AssignmentSet("G1", StaffG1(), (GroupNumber() == 1))],
     #[AssignmentSet("G2", StaffG2(), (GroupNumber() == 2))],
     #[AssignmentSet("G3", StaffG3(), (GroupNumber() == 3))],
     #[AssignmentSet("G4", StaffG4(), (GroupNumber() == 4))],
     #TopCompetitors(_333, 100),
     #OrganizersSet(),
     #EveryoneAssignmentSet()
    #))

AssignGroups(_333-r2,
  Concat(
     [AssignmentSet("Staff", StaffMembersCond(), true)],
     TopResults(_333-r1, 100),
     OrganizersSet(),
     EveryoneAssignmentSet()
    ))

# Fixup staff if needed
Map(
  SundayStages(),
  AssignStaff(
    _333-r2,
    (Stage() == Second<Number, String>()),
    AllStaffTeamsMembersAvailable("Su"),
    ParametrizedJobs(CanScrambleEvent(_333), 2, 4, 3, 15),
    DefaultStaffScorers(_333, 40s, 5),
    fill=true))
