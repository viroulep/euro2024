Define("AllStaffTeamsMembers", Persons(Or((StringProperty("kind") == "Teams"), (StringProperty("kind") == "Side room"))))

Define("SideRoomStaffMembersCondition", (StringProperty("kind") == "Side room"))
Define("SideRoomStaffMembers", Persons(SideRoomStaffMembersCondition()))
Define("RegularSideStaffMembers",
    Persons(And(
        (StringProperty("kind") == "Side room"),
        Not(HasRole("delegate")))))

Define("SideLeaders", [2012BRED01, 2012GOOD02])

# Staff members for the given team, available for the given day.
Define("StaffTeamMembers",
       Persons(
         And((NumberProperty("staff-team") == {1, Number}),
             Not(In({2, String}, ArrayProperty("unavailability"))))))

# Staff members for the given team, available for the given day,
# and ranked over N in the given event.
Define("StaffTeamMembersNotQualified",
       Persons(
         And((NumberProperty("staff-team") == {1, Number}),
             Not(In({2, String}, ArrayProperty("unavailability"))),
             Or(Not(CompetingIn({3, Event})), (PsychSheetPosition({3, Event}) > {4, Number}), HasRole("delegate"))
             )))

Define("StaffTeamsMembersNotQualified",
       Persons(
         And(In(NumberProperty("staff-team"), {1, Array<Number>}),
             Not(In({2, String}, ArrayProperty("unavailability"))),
             Or(Not(CompetingIn({3, Event})), (PsychSheetPosition({3, Event}) > {4, Number}), HasRole("delegate"))
             )))

Define("AllStaffTeamsMembersAvailable",
    Filter(AllStaffTeamsMembers(),
      Not(In({1, String}, ArrayProperty("unavailability")))))
