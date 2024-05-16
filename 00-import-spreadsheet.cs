#include "lib/teams-helpers.cs"

ReadSpreadsheet("1olBmB3nrRNUWCgjZPU_gq7FWRduoKlair302eQXO2v4")

SetProperty(AllStaffTeamsMembers(), "can-scramble", In("Scrambling", ArrayProperty("tasks")))
SetProperty(AllStaffTeamsMembers(), "can-judge", In("Judging", ArrayProperty("tasks")))
SetProperty(AllStaffTeamsMembers(), "can-run", In("Running", ArrayProperty("tasks")))

