#include "lib/qualifications.cs"
#include "lib/stages.cs"
#include "lib/teams-helpers.cs"
#include "lib/scramble-eligibility.cs"
#include "lib/group-assignments-helpers.cs"
#include "lib/staff-assignment-helpers.cs"

Define("Interval", [Tuple(1, 125), Tuple(124, 250), Tuple(249, 400), Tuple(399, 550)])


Define("Staff3x32nd",
       Persons(
         And((NumberProperty("staff-team") == {1, Number}),
             Not(In({2, String}, ArrayProperty("unavailability"))),
             Or(Not(CompetingIn(_333)),
                (PsychSheetPosition(_333) < {3, Number}),
                (PsychSheetPosition(_333) > {4, Number}),
                HasRole("delegate")))))

#Map(Interval(), Length(Staff3x32nd(1, "Su", First<Number, Number>(), Second<Number, Number>())))

Define("DelegateG1", ["2012GOOD02", "2008PIAU01", "2013EGDA01", "2009PROV01", "2013PAPA01"])
Define("DelegateG2", ["2009BONN01", "2009TISS01", "2013WALL03", "2012CANT02", "2013ROGA02"])
Define("DelegateG3", ["2008VIRO01", "2015HENN02", "2010OMUL01", "2012BRED01", "2003BRUC01"])

Map(
  SundayStages(),
  AssignStaff(
    _333-r2,
    And((Stage() == Second<Number, String>()), (GroupNumber() == 1)),
    Filter(Staff3x32nd(First<Number, String>(), "Su", 1, 125), Not(In(WcaId(), DelegateG1()))),
    ParametrizedJobs(CanScrambleEvent(_333), 2, 4, 3, 15),
    DefaultStaffScorers(_333, 40s, 5),
    fill=true))

Map(
  SundayStages(),
  AssignStaff(
    _333-r2,
    And((Stage() == Second<Number, String>()), (GroupNumber() == 2)),
    Filter(Staff3x32nd(First<Number, String>(), "Su", 126, 250), Not(In(WcaId(), DelegateG2()))),
    ParametrizedJobs(CanScrambleEvent(_333), 2, 4, 3, 15),
    DefaultStaffScorers(_333, 40s, 5),
    fill=true))

Map(
  SundayStages(),
  AssignStaff(
    _333-r2,
    And((Stage() == Second<Number, String>()), (GroupNumber() == 3)),
    Filter(Staff3x32nd(First<Number, String>(), "Su", 251, 400), Not(In(WcaId(), DelegateG3()))),
    ParametrizedJobs(CanScrambleEvent(_333), 2, 4, 3, 15),
    DefaultStaffScorers(_333, 40s, 5),
    fill=true))

Map(
  SundayStages(),
  AssignStaff(
    _333-r2,
    And((Stage() == Second<Number, String>()), (GroupNumber() == 4)),
    Staff3x32nd(First<Number, String>(), "Su", 401, 550),
    ParametrizedJobs(CanScrambleEvent(_333), 2, 4, 3, 15),
    DefaultStaffScorers(_333, 40s, 5),
    fill=true))
