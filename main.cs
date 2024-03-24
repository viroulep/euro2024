# FIXME: since we print stuff, I'll likely need to not clear this to make
# sure group/staff assignments stay the same.
# And maybe create a separate "second_round" entry point for creating second
# rounds groups and so on?
ClearWCIF(true)

#include "import_non_competing.cs"

#include "qualifications.cs"

#include "staff_import.cs"

# FIXME: do not create if exists!
# #include "groups_creation.cs"


# #include "competitor_assignments.cs"



Define(
  "PsychSheetTable",
  Table(
    {1, Array<Person>},
    ([Column("Name", Name(), WcaLink())] + Map(Events(),
         Column(EventId(), PsychSheetPosition())))
    )
)

#Table(
  #Sort(Persons((FirstName() == "Philippe")), PersonalBest(_333, "average")),
  #[Column("Name", Name()),
   #Column("WCA ID", WcaId(), WcaLink()),
   #Column("Average", PersonalBest(_333)),
   #Column("Single", PersonalBest(_333, "single")),
   #Column("psych sheet ranking", PsychSheetPosition(_333))])


#AssignmentReport(
  #Sort(Persons(BooleanProperty("stage-staff")), Name()),
  #Flatten(Map([_777-r1, _555-r1, _333bf-r1], Groups())), "1/")

AssignmentReport(
  Sort(Persons(BooleanProperty("stage-staff")), Name()),
  Filter(Flatten(Map([_777-r1, _555-r1, _333bf-r1], Groups())), (Stage() == "Red")), "1/")


ExportWCIF()
