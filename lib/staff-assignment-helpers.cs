# Event,NDelegates,NScramblers,NRunners,NJudges
Define("ParametrizedJobs",
       [
         Job("judge",
             {5, Number},
             eligibility=And(BooleanProperty("can-judge"), Not(HasRole("delegate")))),
         Job("scrambler",
             {3, Number},
             eligibility=And(BooleanProperty("can-scramble"),
                             {1, Boolean(Person)},
                             Not(HasRole("delegate")))),
         Job("runner",
             {4, Number},
             eligibility=And(BooleanProperty("can-run"), Not(HasRole("delegate")))),
         Job("Delegate", {2, Number}, eligibility=HasRole("delegate"))
       ])

Define("MultiScramblingJobs", [
      Job("scrambler", 10, eligibility=Not(HasRole("delegate"))),
      Job("Delegate", 2, eligibility=HasRole("delegate"))
    ])

# TODO use something like that PreferenceScorer(weight=5, prefix="percent-", prior=15, allJobs=["judge", "scrambler", "runner", "Delegate"]),
Define("DefaultStaffScorers",
       [
         JobCountScorer(-1),
         SameJobScorer(60, -5, 4),
         ConsecutiveJobScorer(60, -3, 0),
         ConsecutiveJobScorer(120, -1000, 0),
         MismatchedStationScorer(-10),
         ScrambleSpeedScorer({1, Event}, {2, AttemptResult}, {3, Number}),
         FollowingGroupScorer(-50)
       ])

Define("FinalsStaffScorers",
       [
         JobCountScorer(-1),
         SameJobScorer(60, -5, 4),
         ConsecutiveJobScorer(15, -5, 0),
         MismatchedStationScorer(-10),
         ScrambleSpeedScorer({1, Event}, {2, AttemptResult}, {3, Number}),
         FollowingGroupScorer(-50)
       ])

