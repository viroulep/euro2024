#include "lib/qualifications.cs"
#include "lib/stages.cs"
#include "lib/teams-helpers.cs"
#include "lib/scramble-eligibility.cs"
#include "lib/group-assignments-helpers.cs"
#include "lib/staff-assignment-helpers.cs"

# FIXME: use WCA Live in prod
#AddResults(_333-r2, Persons((PsychSheetPosition(_333) < 550)))


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

AssignGroups(_333-r2,
  Concat(
     [AssignmentSet("G1", StaffG1(), (GroupNumber() == 1))],
     [AssignmentSet("G2", StaffG2(), (GroupNumber() == 2))],
     [AssignmentSet("G3", StaffG3(), (GroupNumber() == 3))],
     [AssignmentSet("G4", StaffG4(), (GroupNumber() == 4))],
     TopCompetitors(_333, 100),
     OrganizersSet(),
     EveryoneAssignmentSet()
    ))
