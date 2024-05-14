# Permitted Scramblers

# Exclude leaders from scrambling eligibility
Define("CanScrambleEvent", And(In(EventId({1, Event}), ArrayProperty("scramble-events")), Not(HasRole("delegate"))))

Define("CanScramble333", And((PersonalBest(_333) < 30s), In("333", ArrayProperty("scramble-events"))))
Define("CanScramble222", And((PersonalBest(_222) < 12s), In("222", ArrayProperty("scramble-events"))))
Define("CanScramble444", And((PersonalBest(_444) < 1:30s), In("444", ArrayProperty("scramble-events"))))
Define("CanScramble555", And((PersonalBest(_555) < 2:00s), In("555", ArrayProperty("scramble-events"))))
Define("CanScramble666", And((PersonalBest(_666) < 5:00s), In("666", ArrayProperty("scramble-events"))))
Define("CanScramble777", And((PersonalBest(_777) < 6:00s), In("777", ArrayProperty("scramble-events"))))
Define("CanScramble777Relaxed", In("777", ArrayProperty("scramble-events")))
Define("CanScrambleSq1", And((PersonalBest(_sq1) < 30s), In("sq1", ArrayProperty("scramble-events"))))
Define("CanScrambleClock", And((PersonalBest(_clock) < 12s), In("clock", ArrayProperty("scramble-events"))))
Define("CanScramblePyraminx", And((PersonalBest(_pyram) < 12s), In("pyram", ArrayProperty("scramble-events"))))
Define("CanScrambleMegaminx", And((PersonalBest(_minx) < 1:30s), In("minx", ArrayProperty("scramble-events"))))
Define("CanScrambleSkewb", And((PersonalBest(_skewb) < 12s), In("skewb", ArrayProperty("scramble-events"))))
