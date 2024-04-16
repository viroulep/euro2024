#include "lib/qualifications.cs"
#include "lib/stages.cs"
#include "lib/teams-helpers.cs"
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
           StaffAssignmentSets(ThursdayStages(), CanScramble777()),
           EveryoneAssignmentSet()
          ))

AssignGroups(_555-r1,
    Concat([AssignmentSet("FM competitors", QualifiedFM(), (GroupNumber() == 1))],
           TopCompetitors(_555, 20),
           StaffAssignmentSets(ThursdayStages(), CanScramble555()),
           EveryoneAssignmentSet()
          ))

AssignGroups(_333bf-r1,
    Concat([AssignmentSet("Multi competitors", QualifiedMBF(), (GroupNumber() == 1))],
           StaffSideRoomSets(ThursdayStages(), 1),
           StaffAssignmentSets(ThursdayStages(), CanScramble333()),
           EveryoneAssignmentSet()
          ))

AssignGroups(_666-r1,
    Concat([AssignmentSet("Multi competitors", QualifiedMBF(), (GroupNumber() == 3))],
           StaffSideRoomSets(ThursdayStages(), 3),
           StaffAssignmentSets(ThursdayStages(), CanScramble666()),
           EveryoneAssignmentSet()
          ))

AssignGroups(_minx-r1,
    Concat([AssignmentSet("Multi competitors", QualifiedMBF(), (GroupNumber() == 1))],
           StaffSideRoomSets(ThursdayStages(), 1),
           StaffAssignmentSets(ThursdayStages(), CanScrambleMegaminx()),
           EveryoneAssignmentSet()
          ))

AssignGroups(_clock-r1,
    Concat([AssignmentSet("Multi competitors", QualifiedMBF(), (GroupNumber() == 4))],
           StaffSideRoomSets(ThursdayStages(), 4),
           StaffAssignmentSets(ThursdayStages(), CanScrambleClock()),
           EveryoneAssignmentSet()
          ))

# FIXME: find a way to always assign 2 delegates
Define("DefaultJobs",
       [
         Job("judge", 14, assignStations=true, eligibility=Not(HasRole("delegate"))),
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
    DefaultJobs(4, CanScramble777(), 2),
    DefaultStaffScorers(_777, 4:00s, 5)))

Map(
  ThursdayStages(),
  AssignStaff(
    _555-r1,
    (Stage() == Second<Number, String>()),
    Persons((NumberProperty("staff-team") == First<Number, String>())),
    DefaultJobs(3, CanScramble555(), 3),
    DefaultStaffScorers(_555, 1:30s, 5)))

# FIXME: a way to map _333mbf-r1-a1-g1 to activityId
# FIXME: a way to map other-mbf-submission (or something) to activityId
# 5806 is a1-g1
# 6023 is a2-g1
Define("RegularSideStaffMembers",
    Persons(And(
        (StringProperty("kind") == "Side room"),
        Not(HasRole("delegate")))))
CreateAssignments(SideLeaders(), 5806, "staff-Delegate")
CreateAssignments(RegularSideStaffMembers(), 5806, "staff-judge")

# FIXME: 333bf red 1 is broken, put more scramblers?
# Put Wallin is in group 1 (Egdal delegates), Egdal in group 2 (Wallin Delegates), Egdal delegates g 3
Map(
  ThursdayStages(),
  AssignStaff(
    _333bf-r1,
    (Stage() == Second<Number, String>()),
    Persons((NumberProperty("staff-team") == First<Number, String>())),
    DefaultJobs(3, CanScramble333(), 3),
    DefaultStaffScorers(_333, 30s, 5)))

Map(
  ThursdayStages(),
  AssignStaff(
    _666-r1,
    (Stage() == Second<Number, String>()),
    Persons((NumberProperty("staff-team") == First<Number, String>())),
    DefaultJobs(4, CanScramble666(), 2),
    DefaultStaffScorers(_666, 3:00s, 5)))

# FIXME: minx red 1 is broken, put more scramblers?
# I think it's because both Delegates compete in blind and minx, and one of them competes in multi
# move mbf a bit, wallin compete g1, egdal g2, egdal delegates 1,3, wallin 2
# for clock put wallin g4 (already ok), egdal g3, egdal delegate 1,2,4, wallin 3

Map(
  ThursdayStages(),
  AssignStaff(
    _minx-r1,
    (Stage() == Second<Number, String>()),
    Persons((NumberProperty("staff-team") == First<Number, String>())),
    DefaultJobs(3, CanScrambleMegaminx(), 3),
    DefaultStaffScorers(_minx, 1:30s, 5)))

Map(
  ThursdayStages(),
  AssignStaff(
    _clock-r1,
    (Stage() == Second<Number, String>()),
    Persons((NumberProperty("staff-team") == First<Number, String>())),
    DefaultJobs(4, CanScrambleClock(), 2),
    DefaultStaffScorers(_clock, 14s, 5)))

# Thursday assignment report
AssignmentReport(
  Sort(Persons((NumberProperty("staff-team") == NumberProperty("staff-team", 2008VIRO01))), NumberProperty("staff-team")),
  Filter(
    Flatten(
      Map([_777-r1, _555-r1, _333bf-r1, _666-r1, _minx-r1, _clock-r1], Groups())),
    (Stage() == "Blue")), "1/")

AssignmentReport(
  Sort(Persons((NumberProperty("staff-team") == NumberProperty("staff-team", 2013EGDA01))), NumberProperty("staff-team")),
  Filter(
    Flatten(
      Map([_777-r1, _555-r1, _333bf-r1, _666-r1, _minx-r1, _clock-r1], Groups())),
    (Stage() == "Red")), "1/")

ExportWCIF("post-assign.json")
