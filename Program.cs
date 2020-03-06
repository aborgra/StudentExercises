using System;
using System.Collections.Generic;

namespace StudentExercises {
    class Program {
        static void Main (string[] args) {
            Exercise classPractice = new Exercise ("Class Practice", "C#");
            Exercise semicolons = new Exercise ("Semicolons", "C#");
            Exercise constructors = new Exercise ("Constructor Practice", "C#");
            Exercise functions = new Exercise ("Functions", "JS");

            Cohort cohort35 = new Cohort ("E35");
            Cohort cohort36 = new Cohort ("D36");
            Cohort cohort37 = new Cohort ("D37");

            Student james = new Student ("James", "Nitz", "agrant", "E35");
            Student kevin = new Student ("Kevin", "Penny", "kpenny", "D36");
            Student willy = new Student ("Willy", "Metcalf", "wmetcalf", "D37");
            Student audrey = new Student ("Audrey", "Borgra", "aborgra", "D37");

            cohort35.AddStudent (james);
            cohort36.AddStudent (kevin);
            cohort37.AddStudent (willy);
            cohort37.AddStudent (audrey);

            Instructor steve = new Instructor ("Steve", "Brownlee", "Chortlehoort", "D37");
            Instructor adam = new Instructor ("Adam", "Schaeffer", "aschaeffer", "D36");
            Instructor mo = new Instructor ("Mo", "Silva", "msilva", "E35");

            cohort37.AddInstuctor (steve);
            cohort36.AddInstuctor (adam);
            cohort35.AddInstuctor (mo);

            steve.AssignExercise (audrey, classPractice);
            steve.AssignExercise (audrey, semicolons);
            steve.AssignExercise (willy, classPractice);
            steve.AssignExercise (willy, semicolons);
            adam.AssignExercise (kevin, constructors);
            adam.AssignExercise (kevin, semicolons);
            mo.AssignExercise (james, functions);
            mo.AssignExercise (james, classPractice);

            List<Student> students = new List<Student> ();
            students.Add (james);
            students.Add (willy);
            students.Add (kevin);
            students.Add (audrey);

            List<Exercise> exercises = new List<Exercise> ();
            exercises.Add (classPractice);
            exercises.Add (functions);
            exercises.Add (semicolons);
            exercises.Add (constructors);

            foreach (Exercise exercise in exercises) {
                Console.WriteLine ($"{exercise.Name}:");

                foreach (Student student in students) {
                    foreach (Exercise studentExercise in student.Exercises) {
                        if (exercise.Name == studentExercise.Name) {
                            Console.WriteLine ($"{student.FirstName} {student.LastName}");

                        }

                    }

                }
                Console.WriteLine ($"--------------------");

            }

        }
    }
}