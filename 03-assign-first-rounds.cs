#include "lib/qualifications.cs"
#include "lib/stages.cs"
#include "lib/teams-helpers.cs"
#include "lib/scramble-eligibility.cs"

# FIXME: figure out what happens if I assign staff, then try to assign competitors to compete.
# Maybe clear out assignment for qualified competitors?
# And assign N+2 judges?

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

Define("StaffSideRoomSets",
  Flatten(Map(
    {1, Array<Tuple<Number, String>>},
    [AssignmentSet(("sideroomstaff-" + Second<Number, String>()),
                   And((NumberProperty("staff-team") == First<Number, String>()),
                       (StringProperty("kind") == "Side room")),
                   And((Stage() == Second<Number, String>()),
                       (GroupNumber() == {2, Number}))
    )])))

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
           StaffAssignmentSets(ThursdayStages(), CanScrambleEvent(_777)),
           EveryoneAssignmentSet()
          ))

AssignGroups(_555-r1,
    Concat([AssignmentSet("FM competitors", QualifiedFM(), (GroupNumber() == 1))],
           TopCompetitors(_555, 20),
           StaffAssignmentSets(ThursdayStages(), CanScrambleEvent(_555)),
           EveryoneAssignmentSet()
          ))

# FIXME: fix the stage color when colors->team are final for Thursday
Define("DanielsBlindSets",
    [AssignmentSet("DanielW",
                   (WcaId() == "2013WALL03"),
                   And(In(Stage(), ["Red"]), (GroupNumber() == {1, Number}))),
     AssignmentSet("DanielE",
                   (WcaId() == "2013EGDA01"),
                   And(In(Stage(), ["Red"]), (GroupNumber() == {2, Number})))])
# For now DanielW must be in 1 to drop for multi, and he delegates 3, so DanielE
# must be in group 3.
AssignGroups(_333bf-r1,
    Concat(DanielsBlindSets(1, 3),
           [AssignmentSet("Multi competitors", QualifiedMBF(), (GroupNumber() == 1))],
           StaffSideRoomSets(ThursdayStages(), 1),
           StaffAssignmentSets(ThursdayStages(), CanScrambleEvent(_333)),
           EveryoneAssignmentSet()
          ))

AssignGroups(_666-r1,
    Concat([AssignmentSet("Multi competitors", QualifiedMBF(), (GroupNumber() == 3))],
           StaffSideRoomSets(ThursdayStages(), 3),
           StaffAssignmentSets(ThursdayStages(), CanScrambleEvent(_666)),
           EveryoneAssignmentSet()
          ))

AssignGroups(_minx-r1,
    Concat([AssignmentSet("Multi competitors", QualifiedMBF(), (GroupNumber() == 1))],
           StaffSideRoomSets(ThursdayStages(), 1),
           StaffAssignmentSets(ThursdayStages(), CanScrambleEvent(_minx)),
           EveryoneAssignmentSet()
          ))

AssignGroups(_clock-r1,
    Concat([AssignmentSet("Multi competitors", QualifiedMBF(), (GroupNumber() == 4))],
           StaffSideRoomSets(ThursdayStages(), 4),
           StaffAssignmentSets(ThursdayStages(), CanScrambleEvent(_clock)),
           EveryoneAssignmentSet()
          ))

Define("DefaultJobs",
       [
         Job("judge", 14, eligibility=Not(HasRole("delegate"))),
         Job("scrambler", {1, Number}, eligibility=And({2, Boolean(Person)}, Not(HasRole("delegate")))),
         Job("runner", {3, Number}, eligibility=Not(HasRole("delegate"))),
         Job("Delegate", 2, eligibility=HasRole("delegate"))
       ])
Define("DefaultJobsWallin",
       [
         Job("judge", 14, eligibility=Not(HasRole("delegate"))),
         Job("scrambler", {1, Number}, eligibility=And({2, Boolean(Person)}, Not(HasRole("delegate")))),
         Job("runner", {3, Number}, eligibility=Not(HasRole("delegate"))),
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
    DefaultJobs(3, CanScrambleEvent(_777), 2),
    DefaultStaffScorers(_777, 4:00s, 5)))

Map(
  ThursdayStages(),
  AssignStaff(
    _555-r1,
    (Stage() == Second<Number, String>()),
    Persons((NumberProperty("staff-team") == First<Number, String>())),
    DefaultJobs(3, CanScrambleEvent(_555), 3),
    DefaultStaffScorers(_555, 1:30s, 5)))

# FIXME: a way to map _333mbf-r1-a1-g1 to activityId
# FIXME: a way to map other-mbf-submission (or something) to activityId
# 5806 is a1-g1
# 6023 is a2-g1
Define("RegularSideStaffMembers",
    Persons(And(
        (StringProperty("kind") == "Side room"),
        Not(HasRole("delegate")))))
#CreateAssignments(SideLeaders(), 5806, "staff-Delegate")
#CreateAssignments(RegularSideStaffMembers(), 5806, "staff-judge")

Map(
  ThursdayStages(),
  AssignStaff(
    _333bf-r1,
    (Stage() == Second<Number, String>()),
    Persons((NumberProperty("staff-team") == First<Number, String>())),
    DefaultJobs(3, CanScrambleEvent(_333), 3),
    DefaultStaffScorers(_333, 30s, 5)))

Map(
  ThursdayStages(),
  AssignStaff(
    _666-r1,
    (Stage() == Second<Number, String>()),
    Persons((NumberProperty("staff-team") == First<Number, String>())),
    DefaultJobs(4, CanScrambleEvent(_666), 2),
    DefaultStaffScorers(_666, 3:00s, 5)))

# FIXME: removed Wallin from Megaminx for now; could he drop either this or clock?
# Or can we simply find team leaders who don't do 10+ events?
Map(
  ThursdayStagesWallin(),
  AssignStaff(
    _minx-r1,
    And((Stage() == Second<Number, String>()), (GroupNumber() == 1)),
    Persons((NumberProperty("staff-team") == First<Number, String>())),
    DefaultJobsWallin(3, CanScrambleEvent(_minx), 3),
    DefaultStaffScorers(_minx, 1:30s, 5)))

Map(
  ThursdayStagesOthers(),
  AssignStaff(
    _minx-r1,
    And((Stage() == Second<Number, String>()), (GroupNumber() == 1)),
    Persons((NumberProperty("staff-team") == First<Number, String>())),
    DefaultJobs(3, CanScrambleEvent(_minx), 3),
    DefaultStaffScorers(_minx, 1:30s, 5)))

Map(
  ThursdayStages(),
  AssignStaff(
    _minx-r1,
    And((Stage() == Second<Number, String>()), (GroupNumber() > 1)),
    Persons((NumberProperty("staff-team") == First<Number, String>())),
    DefaultJobs(3, CanScrambleEvent(_minx), 3),
    DefaultStaffScorers(_minx, 1:30s, 5)))

Map(
  ThursdayStages(),
  AssignStaff(
    _clock-r1,
    (Stage() == Second<Number, String>()),
    Persons((NumberProperty("staff-team") == First<Number, String>())),
    DefaultJobs(4, CanScrambleEvent(_clock), 2),
    DefaultStaffScorers(_clock, 14s, 5)))


ExportWCIF("post-assign.json")
