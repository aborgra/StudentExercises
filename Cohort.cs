using System;
using System.Collections.Generic;

namespace StudentExercises {
  public class Cohort {

    public string Name { get; set; }

    public List<Student> StudentCollection { get; set; } = new List<Student> ();
    public List<Instructor> InstructorCollection { get; set; } = new List<Instructor> ();

    public void AddStudent (Student student) {
      StudentCollection.Add (student);
    }

    public void AddInstuctor (Instructor instructor) {
      InstructorCollection.Add (instructor);
    }

    public Cohort (string name) {
      Name = name;
    }
  }
}