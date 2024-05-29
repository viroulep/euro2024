#include "lib/scramble-eligibility.cs"
#include "lib/teams-helpers.cs"

Define(
  "ScramblerConstraints",
  [
   LimitConstraint("777 scramblers during FM", And(CanScrambleEvent(_777), Not(CompetingIn(_333fm))), 5, 50),
   LimitConstraint("555 scramblers", CanScrambleEvent(_555), 8, 5),
   LimitConstraint("555 scramblers during FM", And(CanScrambleEvent(_555), Not(CompetingIn(_333fm))), 8, 10),
   LimitConstraint("555 semi scramblers", And(CanScrambleEvent(_555), (PsychSheetPosition(_555) > 150)), 7, 5),
   LimitConstraint("666 scramblers", CanScrambleEvent(_666), 12, 5),
   LimitConstraint("777 scramblers", CanScrambleEvent(_777), 8, 5),
   LimitConstraint("Clock semi scramblers", And(CanScrambleEvent(_clock), (PsychSheetPosition(_clock) > 150)), 10, 5),
   LimitConstraint("Sq1 scramblers", CanScrambleEvent(_sq1), 10, 5),
   LimitConstraint("Sq1 semi scramblers", And(CanScrambleEvent(_sq1), (PsychSheetPosition(_sq1) > 175)), 6, 5),
   LimitConstraint("333oh scramblers during 5 blind", And(CanScrambleEvent(_333), Not(CompetingIn(_555bf))), 8, 5),
   LimitConstraint("Skewb scramblers during 4 blind", And(CanScrambleEvent(_skewb), Not(CompetingIn(_444bf))), 8, 5),
   LimitConstraint("444 semi scramblers", And(CanScrambleEvent(_444), (PsychSheetPosition(_444) > 150)), 10, 5),
   LimitConstraint("pyram semi scramblers", And(CanScrambleEvent(_pyram), (PsychSheetPosition(_pyram) > 150)), 10, 5),
   LimitConstraint("333 semi scramblers", And(CanScrambleEvent(_333), (PsychSheetPosition(_333) > 150)), 10, 5),
   LimitConstraint("Mega scramblers", CanScrambleEvent(_minx), 8, 5),
   LimitConstraint("Mega scramblers during multi", And(CanScrambleEvent(_minx), Not(CompetingIn(_333mbf))), 8, 10)])

# if needed, manually set "cluster-id" on the newly-added staff members

# balance unavailable staff

Cluster("staff-team-validation", 5, AllStaffTeamsMembers(), StringProperty("staff-team"),
  Concat(
    [
     LimitConstraint("Leaders", HasRole("delegate"), 3, 1),
     BalanceConstraint("Side members", (StringProperty("kind") == "Side room"), 4)
    ],
    ScramblerConstraints()
    ))
