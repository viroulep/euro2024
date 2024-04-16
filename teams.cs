#include "lib/scramble-eligibility.cs"

ReadSpreadsheet("1olBmB3nrRNUWCgjZPU_gq7FWRduoKlair302eQXO2v4")

Define("AllStaffTeamsMembers", Persons(Or((StringProperty("kind") == "Teams"), (StringProperty("kind") == "Side room"))))


Define(
  "ScramblerConstraints",
  [LimitConstraint("555 scramblers", CanScramble555(), 8, 5),
   LimitConstraint("555 semi scramblers", And(CanScramble555(), (PsychSheetPosition(_555) > 150)), 3, 5),
   LimitConstraint("666 scramblers", CanScramble666(), 8, 5),
   LimitConstraint("777 scramblers", CanScramble777(), 8, 10),
   LimitConstraint("Clock scramblers", CanScrambleClock(), 8, 5),
   LimitConstraint("Clock semi scramblers", And(CanScrambleClock(), (PsychSheetPosition(_clock) > 150)), 4, 5),
   LimitConstraint("Sq1 scramblers", CanScrambleSq1(), 6, 5),
   LimitConstraint("Sq1 semi scramblers", And(CanScrambleSq1(), (PsychSheetPosition(_sq1) > 175)), 3, 5),
   LimitConstraint("Mega scramblers", CanScrambleMegaminx(), 6, 5),
   LimitConstraint("Mega scramblers during multi", And(CanScrambleMegaminx(), Not(CompetingIn(_333mbf))), 5, 5)])

# if needed, manually set "cluster-id" on the newly-added staff members

Cluster("staff-team", 5, AllStaffTeamsMembers(), StringProperty("staff-team"),
  Concat(
    [
     LimitConstraint("Leaders", HasRole("delegate"), 2, 1),
     BalanceConstraint("Side members", (StringProperty("kind") == "Side room"), 4)
    ],
    ScramblerConstraints()
    ))

