# Noted here in case I have another swap to make

# Start by deleting the competitor's assignments
DeleteAssignments(2022ECHE01, AssignedGroups(2022ECHE01))

Define("RealGroupName", Add(RoundId(Round({1, Group})), GroupName({1, Group})))
# All groups but Sergio's assigned groups
Define("SergiosGroups", Map(AssignedGroups(2023DIAZ45), RealGroupName(Arg<Group>())))
Define("AllGroupsSwitched", Filter(Flatten(Map(Rounds(), Groups())), Not(In(RealGroupName(Arg<Group>()), SergiosGroups()))))

SwapAssignments(2022ECHE01, 2023DIAZ45, AllGroupsSwitched())

# to remove specific competitors assignments
DeleteAssignments(2023DIAZ45, [AssignedGroup(_222-r1, 2023DIAZ45)])

# Final addition/changes if needed
# 6473 is yellow 5
CreateAssignments([2023DIAZ45], 6473, "competitor")
