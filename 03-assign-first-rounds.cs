#include "lib/qualifications.cs"
#include "lib/stages.cs"
#include "lib/teams-helpers.cs"
#include "lib/scramble-eligibility.cs"
#include "lib/group-assignments-helpers.cs"

# FIXME: figure out what happens if I assign staff, then try to assign competitors to compete.
# Maybe clear out assignment for qualified competitors?
# And assign N+2 judges?

# FIXME: use WCA Live in prod
#Map(QualifiedPerEvent(),
    #AddResults(RoundForEvent(1, First<Event, Array<Person>>()),
               #Second<Event, Array<Person>>(), overwrite=true))


# TODO: assign people who should compete early, ie data entry, maybe stream?

# Easy ones ;)
AssignGroups(_333fm-r1, EveryoneAssignmentSet(), attemptNumber=1, overwrite=true)
AssignGroups(_333fm-r1, EveryoneAssignmentSet(), attemptNumber=2, overwrite=true)
AssignGroups(_333fm-r1, EveryoneAssignmentSet(), attemptNumber=3, overwrite=true)

#5681 is multi submission 1
#5682 is multi submission 2
Define("PersonsCompetingInMulti", Persons(And(QualifiedMBF(), Not((WcaId() == "2013WALL03")))))
AssignMisc(5681,
           PersonsCompetingInMulti(),
           [Job("competitor", Length(PersonsCompetingInMulti()))],
           MakeArray<AssignmentScorer>())

AssignMisc(5682,
           PersonsCompetingInMulti(),
           [Job("competitor", Length(PersonsCompetingInMulti()))],
           MakeArray<AssignmentScorer>())

AssignGroups(_333mbf-r1, EveryoneAssignmentSet(), attemptNumber=1, overwrite=true)
AssignGroups(_333mbf-r1, EveryoneAssignmentSet(), attemptNumber=2, overwrite=true)
AssignGroups(_444bf-r1, EveryoneAssignmentSet(), overwrite=true)
AssignGroups(_555bf-r1, EveryoneAssignmentSet(), overwrite=true)

#5684 is 555bf submission
Define("PersonsCompetingIn5BF", Persons(Qualified5BF()))
AssignMisc(5684,
           PersonsCompetingIn5BF(),
           [Job("competitor", Length(PersonsCompetingIn5BF()))],
           MakeArray<AssignmentScorer>())


AssignGroups(_777-r1,
    Concat([AssignmentSet("FM competitors", QualifiedFM(), (GroupNumber() == 2))],
           TopCompetitors(_777, 20),
           StaffAssignmentSets(ThursdayStages(), CanScrambleEvent(_777)),
           EveryoneAssignmentSet()
          ))

Define("SpecificGroupSet", [
        AssignmentSet("Specific",
                      (WcaId() == {1, String}),
                      And(In(Stage(), ["Orange Stage"]), (GroupNumber() == {2, Number}))
                      )])

AssignGroups(_555-r1,
    Concat([AssignmentSet("FM competitors", QualifiedFM(), (GroupNumber() == 1))],
           SpecificGroupSet("2009PROV01", 1),
           SpecificGroupSet("2012CANT02", 2),
           TopCompetitors(_555, 50),
           StaffAssignmentSets(ThursdayStages(), CanScrambleEvent(_555)),
           EveryoneAssignmentSet()
          ))

# FIXME: fix the stage color when colors->team are final for Thursday
Define("DanielsBlindSets",
    [AssignmentSet("DanielW",
                   (WcaId() == "2013WALL03"),
                   And(In(Stage(), ["Red Stage"]), (GroupNumber() == {1, Number}))),
     AssignmentSet("DanielE",
                   (WcaId() == "2013EGDA01"),
                   And(In(Stage(), ["Red Stage"]), (GroupNumber() == {2, Number})))])

# For now DanielW must be in 1 to drop for multi, and he delegates 3, so DanielE
# must be in group 3.
AssignGroups(_333bf-r1,
    Concat(DanielsBlindSets(1, 3),
           [AssignmentSet("Multi competitors", QualifiedMBF(), (GroupNumber() == 1))],
           StaffSideRoomSets(ThursdayStages(), 1),
           TopCompetitors(_333bf, 30),
           StaffAssignmentSets(ThursdayStages(), CanScrambleEvent(_333)),
           EveryoneAssignmentSet()
          ))

AssignGroups(_666-r1,
    Concat([AssignmentSet("Multi competitors", QualifiedMBF(), (GroupNumber() == 3))],
           StaffSideRoomSets(ThursdayStages(), 3),
           TopCompetitors(_666, 20),
           StaffAssignmentSets(ThursdayStages(), CanScrambleEvent(_666)),
           EveryoneAssignmentSet()
          ))

AssignGroups(_minx-r1,
    Concat([AssignmentSet("Multi competitors", QualifiedMBF(), (GroupNumber() == 1))],
           StaffSideRoomSets(ThursdayStages(), 1),
           TopCompetitors(_minx, 30),
           StaffAssignmentSets(ThursdayStages(), CanScrambleEvent(_minx)),
           EveryoneAssignmentSet()
          ))

AssignGroups(_clock-r1,
    Concat([AssignmentSet("Multi competitors", QualifiedMBF(), (GroupNumber() == 4))],
           StaffSideRoomSets(ThursdayStages(), 4),
           TopCompetitors(_minx, 50),
           StaffAssignmentSets(ThursdayStages(), CanScrambleEvent(_clock)),
           EveryoneAssignmentSet()
          ))

ExportWCIF("post-assign-groups-th.json")
