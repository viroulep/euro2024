Define("MainStages", [
  Tuple(1, "Blue Stage"),
  Tuple(2, "Red Stage"),
  Tuple(3, "Green Stage"),
  Tuple(4, "Orange Stage"),
  Tuple(5, "Yellow Stage")
])

Define("FinalStages", [Tuple(2, "Red Stage"), Tuple(3, "Green Stage")])

# Staff team -> stage mapping
# This basically defines which team staffs on which stage on each day.

Define("ThursdayStagesWallin",
  [Tuple(NumberProperty("staff-team", 2013EGDA01), "Red")])
Define("ThursdayStagesMatteo",
  [Tuple(NumberProperty("staff-team", 2009PROV01), "Orange")])
Define("ThursdayStagesOthers", [
  Tuple(NumberProperty("staff-team", 2008VIRO01), "Blue"),
  Tuple(NumberProperty("staff-team", 2009TISS01), "Green"),
  Tuple(NumberProperty("staff-team", 2003BRUC01), "Yellow")])

Define(
  "ThursdayStages",
  Concat(ThursdayStagesWallin(), ThursdayStagesMatteo(), ThursdayStagesOthers()))

Define("FridayStagesMatteo",
  [Tuple(NumberProperty("staff-team", 2009PROV01), "Yellow")])
Define(
  "FridayStagesOthers",
  [Tuple(NumberProperty("staff-team", 2003BRUC01), "Blue"),
   Tuple(NumberProperty("staff-team", 2008VIRO01), "Red"),
   Tuple(NumberProperty("staff-team", 2013EGDA01), "Green"),
   Tuple(NumberProperty("staff-team", 2009TISS01), "Orange")])
Define(
  "FridayStages",
  Concat(FridayStagesMatteo(), FridayStagesOthers()))

Define(
  "SaturdayStages",
  [Tuple(NumberProperty("staff-team", 2009PROV01), "Blue"),
   Tuple(NumberProperty("staff-team", 2003BRUC01), "Red"),
   Tuple(NumberProperty("staff-team", 2008VIRO01), "Green"),
   Tuple(NumberProperty("staff-team", 2013EGDA01), "Orange"),
   Tuple(NumberProperty("staff-team", 2009TISS01), "Yellow")])

Define(
  "SundayStages",
  [Tuple(NumberProperty("staff-team", 2009TISS01), "Blue"),
   Tuple(NumberProperty("staff-team", 2009PROV01), "Red"),
   Tuple(NumberProperty("staff-team", 2003BRUC01), "Green"),
   Tuple(NumberProperty("staff-team", 2008VIRO01), "Orange"),
   Tuple(NumberProperty("staff-team", 2013EGDA01), "Yellow")])
