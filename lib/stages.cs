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
  [Tuple(NumberProperty("staff-team", 2013EGDA01), "Red Stage")])
Define("ThursdayStagesMatteo",
  [Tuple(NumberProperty("staff-team", 2009PROV01), "Orange Stage")])
Define("ThursdayStagesOthers", [
  Tuple(NumberProperty("staff-team", 2008VIRO01), "Blue Stage"),
  Tuple(NumberProperty("staff-team", 2009TISS01), "Green Stage"),
  Tuple(NumberProperty("staff-team", 2003BRUC01), "Yellow Stage")])

Define(
  "ThursdayStages",
  Concat(ThursdayStagesWallin(), ThursdayStagesMatteo(), ThursdayStagesOthers()))

Define("FridayStagesMatteo",
  [Tuple(NumberProperty("staff-team", 2009PROV01), "Yellow Stage")])
Define("FridayStagesWallin",
  [Tuple(NumberProperty("staff-team", 2013EGDA01), "Green Stage")])
Define(
  "FridayStagesOthers",
  [Tuple(NumberProperty("staff-team", 2003BRUC01), "Blue Stage"),
   Tuple(NumberProperty("staff-team", 2008VIRO01), "Red Stage"),
   Tuple(NumberProperty("staff-team", 2009TISS01), "Orange Stage")])
Define(
  "FridayStages",
  Concat(FridayStagesMatteo(), FridayStagesWallin(), FridayStagesOthers()))

Define(
  "SaturdayStages",
  [Tuple(NumberProperty("staff-team", 2009PROV01), "Blue Stage"),
   Tuple(NumberProperty("staff-team", 2003BRUC01), "Red Stage"),
   Tuple(NumberProperty("staff-team", 2008VIRO01), "Green Stage"),
   Tuple(NumberProperty("staff-team", 2013EGDA01), "Orange Stage"),
   Tuple(NumberProperty("staff-team", 2009TISS01), "Yellow Stage")])

Define(
  "SundayStages",
  [Tuple(NumberProperty("staff-team", 2009TISS01), "Blue Stage"),
   Tuple(NumberProperty("staff-team", 2009PROV01), "Red Stage"),
   Tuple(NumberProperty("staff-team", 2003BRUC01), "Green Stage"),
   Tuple(NumberProperty("staff-team", 2008VIRO01), "Orange Stage"),
   Tuple(NumberProperty("staff-team", 2013EGDA01), "Yellow Stage")])

Define("FinalStagesSat",
    [Tuple([1, 2, 5], "Red Stage"), Tuple([3, 4], "Green Stage")])

Define("FinalStagesSu",
    [Tuple([1, 2, 5], "Green Stage"), Tuple([3, 4], "Red Stage")])
