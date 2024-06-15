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

Define("AllStaffDelegates", [2022DULL01, 2013SING12, 2015NICH04, 2010THOM03, 2015KUCA01, 2014LAFO02, 2008VARG01, 2017CAST48, 2016SINN01, 2014PRID01, 2015WANF02, 2012CAPP01, 2017MONE01, 2008MORE02, 2016PERE44, 2018BRUU01, 2013ZIRN01, 2013GARC08, 2010DESJ01, 2019TIMM01, 2021COOK03, 2018FOLD01, 2019KUCA01, 2016BEAU03, 2019PASQ01, 2019LEFE02, 2015JRAG01, 2011MASS01, 2016WHEA01, 2014VIKS01, 2019KLEV01, 2018AZEV03, 2018DAIN02, 2021HUGO01, 2018CAST11, 2023CASE06, 2014IFRA01, 2017OTOO03, 2011TRON02, 2017KELL08, 2014GRIG01, 2017NORR01, 2014RAPO01, 2012GOOD02, 2009BONN01, 2008VIRO01, 2008PIAU01, 2009TISS01, 2015HENN02, 2013EGDA01, 2013WALL03, 2010OMUL01, 2009PROV01, 2012CANT02, 2012BRED01, 2013PAPA01, 2013ROGA02, 2003BRUC01])

Define("StaffDelegatesNotQualified",
    Filter(AllStaffDelegates(),
      And(
        Not(In({1, String}, ArrayProperty("unavailability"))),
        Or(Not(CompetingIn({2, Event})), (PsychSheetPosition({2, Event}) > {3, Number}), HasRole("delegate"))
        )))
