#include "lib/stages.cs"

# FIXME: anyway I can do this without tuples? How to get in Map()?
Define("CreateGroupsOnAllStages",
  Map(MainStages(),
    CreateGroups({1, Round}, {2, Number}, Second<Number, String>(),
                 RoundStartTime({1, Round}), RoundEndTime({1, Round}))))

Define("CreateGroupsOnFinalStages",
  Map(FinalStages(),
    CreateGroups({1, Round}, {2, Number}, Second<Number, String>(),
                 RoundStartTime({1, Round}), RoundEndTime({1, Round}))))

Define("CreateGroupsOnSide",
    CreateGroups({1, Round}, {2, Number}, "Side Room",
                 RoundStartTime({1, Round}), RoundEndTime({1, Round})))

# Create groups for Thursday

CreateGroupsOnAllStages(_777-r1, 2)
CreateGroupsOnAllStages(_555-r1, 4)
CreateGroupsOnAllStages(_333bf-r1, 3)
CreateGroupsOnAllStages(_666-r1, 3)
CreateGroupsOnAllStages(_minx-r1, 3)
CreateGroupsOnAllStages(_clock-r1, 4)

CreateGroupsOnSide(_333fm-r1-a1, 1)
CreateGroupsOnSide(_333fm-r1-a2, 1)
CreateGroupsOnSide(_333mbf-r1-a1, 1)

# Create groups for Friday

CreateGroupsOnAllStages(_skewb-r1, 7)
CreateGroupsOnAllStages(_333oh-r1, 4)
CreateGroupsOnAllStages(_sq1-r1, 3)
CreateGroupsOnAllStages(_444-r1, 5)
CreateGroupsOnAllStages(_pyram-r1, 7)

CreateGroupsOnSide(_333fm-r1-a3, 1)
CreateGroupsOnSide(_444bf-r1, 1)
CreateGroupsOnSide(_555bf-r1, 1)

# Create groups for Saturday

CreateGroupsOnAllStages(_333-r1, 9)
CreateGroupsOnAllStages(_444-r2, 1)
CreateGroupsOnAllStages(_minx-r2, 1)
CreateGroupsOnAllStages(_clock-r2, 1)
CreateGroupsOnAllStages(_555-r2, 1)
CreateGroupsOnAllStages(_sq1-r2, 1)
CreateGroupsOnAllStages(_222-r2, 1)

CreateGroupsOnFinalStages(_666-r2, 1)
CreateGroupsOnFinalStages(_minx-r3, 1)
CreateGroupsOnFinalStages(_clock-r3, 1)
CreateGroupsOnFinalStages(_777-r2, 1)

CreateGroupsOnSide(_333mbf-r1-a2, 1)

# Create groups for Sunday

CreateGroupsOnAllStages(_333-r2, 4)
CreateGroupsOnAllStages(_333bf-r2, 1)
CreateGroupsOnAllStages(_skewb-r2, 1)
CreateGroupsOnAllStages(_222-r2, 2)
CreateGroupsOnAllStages(_pyram-r2, 1)
CreateGroupsOnAllStages(_333oh-r2, 1)
CreateGroupsOnAllStages(_333-r3, 1)

CreateGroupsOnFinalStages(_333bf-r3, 1)
CreateGroupsOnFinalStages(_sq1-r3, 1)
CreateGroupsOnFinalStages(_333oh-r3, 1)
CreateGroupsOnFinalStages(_555-r3, 1)
CreateGroupsOnFinalStages(_skewb-r3, 1)
CreateGroupsOnFinalStages(_pyram-r3, 1)
CreateGroupsOnFinalStages(_444-r3, 1)
CreateGroupsOnFinalStages(_222-r3, 1)

CreateGroups(_333-r4, 1, "Green Stage", RoundStartTime(_333-r4), RoundEndTime(_333-r4))

