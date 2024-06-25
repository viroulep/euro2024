#include "lib/teams-helpers.cs"

ReadSpreadsheet("1olBmB3nrRNUWCgjZPU_gq7FWRduoKlair302eQXO2v4")

SetProperty(AllStaffTeamsMembers(), "can-scramble", In("Scrambling", ArrayProperty("tasks")))
SetProperty(AllStaffTeamsMembers(), "can-judge", In("Judging", ArrayProperty("tasks")))
SetProperty(AllStaffTeamsMembers(), "can-run", In("Running", ArrayProperty("tasks")))
SetProperty(Persons((StringProperty("kind") == "Data")), "staff-team-others", "Data Entry")
SetProperty(Persons((StringProperty("kind") == "Registration")), "staff-team-others", "Registration")
SetProperty(Persons((StringProperty("kind") == "Stream")), "staff-team-others", "Stream")
SetProperty(Persons((StringProperty("kind") == "Orga")), "staff-team-others", "Organizers")

SetStaffUnavailable([2014IFRA01],
  [UnavailableBetween(2024-07-25T08:00, 2024-07-25T13:30),
   UnavailableBetween(2024-07-26T08:00, 2024-07-26T11:30)])
