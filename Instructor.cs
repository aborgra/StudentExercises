using System;
using System.Collections.Generic;

namespace StudentExercises {
  public class Instructor {

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string SlackHandle { get; set; }

    public string Cohort { get; set; }
    public string Specialty { get; set; }

    public void AssignExercise (Student student, Exercise exercise) {
      student.Exercises.Add (exercise);
    }
    public Instructor (string firstName, string lastName, string slackHandle, string cohort) {
      FirstName = firstName;
      LastName = lastName;
      SlackHandle = slackHandle;
      Cohort = cohort;
    }
  }
}