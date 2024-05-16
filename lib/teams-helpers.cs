Define("AllStaffTeamsMembers", Persons(Or((StringProperty("kind") == "Teams"), (StringProperty("kind") == "Side room"))))

Define("SideRoomStaffMembers", Persons((StringProperty("kind") == "Side room")))

Define("SideLeaders", [2012BRED01, 2012GOOD02])

# Staff members for the given team, available for the given day.
Define("StaffTeamMembers",
       Persons(
         And((NumberProperty("staff-team") == {1, Number}),
             Not(In({2, String}, ArrayProperty("unavailability"))))))
