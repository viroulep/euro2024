

Cluster("teams", 5, StaffMembers(), StringProperty("stage-id"),
  [LimitConstraint("Leaders", HasRole("delegate"), 2, 1)])

