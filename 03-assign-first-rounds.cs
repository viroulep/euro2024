#include "lib/qualifications.cs"
#include "lib/stages.cs"
#include "lib/scramble-eligibility.cs"

# FIXME: use WCA Live in prod
Map(QualifiedPerEvent(),
    AddResults(RoundForEvent(1, First<Event, Array<Person>>()),
               Second<Event, Array<Person>>(), overwrite=true))

Define(
  "TopCompetitors",
  [AssignmentSet("top",
                 (PsychSheetPosition({1, Event}) <= {2, Number}),
                 In(Stage(), ["Green"]),
                 featured=true)])


Define(
  "StaffAssignmentSets",
  Flatten(Map(
    {1, Array<Tuple<Number, String>>},
    [AssignmentSet(("stage-leads-" + Second<Number, String>()),
                   And(HasRole("delegate"),
                       (NumberProperty("staff-team") == First<Number, String>())),
                   (Stage() == Second<Number, String>())),
     AssignmentSet(("scramblers-" + Second<Number, String>()),
                   And({2, Boolean(Person)},
                       (NumberProperty("staff-team") == First<Number, String>())),
                   (Stage() == Second<Number, String>())),
     AssignmentSet(("staff-" + Second<Number, String>()),
                   (NumberProperty("staff-team") == First<Number, String>()),
                   (Stage() == Second<Number, String>()))])))

# TODO: assign people who should compete early, ie data entry, maybe stream?

Define("EveryoneAssignmentSet", [AssignmentSet("everyone", true, true)])

# Easy ones ;)
AssignGroups(_333fm-r1, EveryoneAssignmentSet(), attemptNumber=1, overwrite=true)
AssignGroups(_333fm-r1, EveryoneAssignmentSet(), attemptNumber=2, overwrite=true)
AssignGroups(_333fm-r1, EveryoneAssignmentSet(), attemptNumber=3, overwrite=true)


AssignGroups(_777-r1,
    Concat([AssignmentSet("FM competitors", QualifiedFM(), (GroupNumber() == 2))],
           TopCompetitors(_777, 20),
           StaffAssignmentSets(ThursdayStages(), CanScramble777()),
           EveryoneAssignmentSet()
          ))

AssignGroups(_555-r1,
    Concat([AssignmentSet("FM competitors", QualifiedFM(), (GroupNumber() == 1))],
           TopCompetitors(_555, 20),
           StaffAssignmentSets(ThursdayStages(), CanScramble555()),
           EveryoneAssignmentSet()
          ))

Define("DefaultJobs",
       [
         Job("judge", 12, assignStations=true),
         Job("scrambler", {1, Number}, eligibility={2, Boolean(Person)}),
         Job("runner", {3, Number}),
         Job("Delegate", 1, eligibility=HasRole("delegate"))
       ])

# TODO use something like that PreferenceScorer(weight=5, prefix="percent-", prior=15, allJobs=["judge", "scrambler", "runner", "Delegate"]),
Define("DefaultStaffScorers",
       [
         JobCountScorer(-1),
         SameJobScorer(60, -5, 4),
         ConsecutiveJobScorer(90, -3, 0),
         MismatchedStationScorer(-10),
         ScrambleSpeedScorer({1, Event}, {2, AttemptResult}, {3, Number}),
         FollowingGroupScorer(-50)
       ])

ClearAssignments(Persons(true), true, false)
Map(
  ThursdayStages(),
  AssignStaff(
    _777-r1,
    (Stage() == Second<Number, String>()),
    Persons((NumberProperty("staff-team") == First<Number, String>())),
    DefaultJobs(4, CanScramble777(), 2),
    DefaultStaffScorers(_777, 4:00s, 5)))
