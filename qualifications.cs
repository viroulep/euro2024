# FIXME: ideally we cleanup registrations, and this boils down to "CompetingIn"

Define("QualifiedForAvg", And(CompetingIn({1, Event}), (PersonalBest({1, Event}) < {2, AttemptResult})))
Define("QualifiedForRanking", And(CompetingIn({1, Event}), (PsychSheetPosition({1, Event}) <= {2, Number})))

Define("Qualified2", CompetingIn(_222))
Define("Qualified3", CompetingIn(_333))
Define("QualifiedSkewb", CompetingIn(_skewb))
Define("QualifiedPyra", CompetingIn(_pyram))
Define("Qualified4", QualifiedForAvg(_444, 55s))
Define("Qualified5", QualifiedForAvg(_555, 1:30s))
Define("Qualified6", QualifiedForAvg(_666, 2:45s))
Define("Qualified7", QualifiedForAvg(_777, 4:00s))
Define("QualifiedBF", QualifiedForAvg(_333bf, 2:00s))
Define("QualifiedOH", QualifiedForAvg(_333oh, 25s))
Define("QualifiedClock", QualifiedForAvg(_clock, 12s))
Define("QualifiedMega", QualifiedForAvg(_minx, 1:20s))
Define("QualifiedSQ1", QualifiedForAvg(_sq1, 25s))
Define("QualifiedFM", QualifiedForRanking(_333fm, 100))
Define("QualifiedMBF", QualifiedForRanking(_333mbf, 40))
Define("Qualified4BF", QualifiedForRanking(_444bf, 40))
Define("Qualified5BF", QualifiedForRanking(_555bf, 40))

Define("QualifiedPerEvent",
    [
    Tuple(_222, Persons(Qualified2())),
    Tuple(_333, Persons(Qualified3())),
    Tuple(_skewb, Persons(QualifiedSkewb())),
    Tuple(_pyram, Persons(QualifiedPyra())),
    Tuple(_444, Persons(Qualified4())),
    Tuple(_555, Persons(Qualified5())),
    Tuple(_666, Persons(Qualified6())),
    Tuple(_777, Persons(Qualified7())),
    Tuple(_333bf, Persons(QualifiedBF())),
    Tuple(_333oh, Persons(QualifiedOH())),
    Tuple(_clock, Persons(QualifiedClock())),
    Tuple(_minx, Persons(QualifiedMega())),
    Tuple(_sq1, Persons(QualifiedSQ1())),
    Tuple(_333fm, Persons(QualifiedFM())),
    Tuple(_333mbf, Persons(QualifiedMBF())),
    Tuple(_444bf, Persons(Qualified4BF())),
    Tuple(_555bf, Persons(Qualified5BF()))
    ])
