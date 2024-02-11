ClearWCIF(true)

# FIXME: exclude staff import for now, just create some groups
# #include "staff_import.cs"

#include "groups_creation.cs"

#include "competitor_assignments.cs"



#Map(StageLeaders(HasRole("delegate")), WcaId())

#Cluster("teams", 5, StaffMembers(), StringProperty("stage-id"),
  #[LimitConstraint("Leaders", HasRole("delegate"), 2, 1)])

#Map(Rounds(), Length(Groups()))
#Map(Rounds(), Length(Groups()))
#ExportWCIF("end.json")

#Define("EveryoneAssignmentSet", [AssignmentSet("everyone", true, (GroupNumber() < 20))])

#Define("Scramblers",
  #Persons(CanScramble777()),
  #public=true)

# AssignGroups(_333-r1, EveryoneAssignmentSet())

# Map(Events(), AddResults(RoundForEvent(1), Persons(CompetingIn())))
#AddResults(_222-r1, Persons(CompetingIn(_222)))


Define(
  "PsychSheetTable",
  Table(
    {1, Array<Person>},
    ([Column("Name", Name(), WcaLink())] + Map(Events(),
         Column(EventId(), PsychSheetPosition())))
    )
)

Table(
  Persons(And(Registered(), (FirstName() == "Luke"))),
  [Column("Name", Name()),
   Column("WCA ID", WcaId(), WcaLink()),
   Column("Average", PersonalBest(_333)),
   Column("Single", PersonalBest(_333, "single")),
   Column("psych sheet ranking", PsychSheetPosition(_333))])

ExportWCIF()
