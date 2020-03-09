using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentExercises {
    class Program {
        static void Main (string[] args) {
            Exercise classPractice = new Exercise ("Class Practice", "C#");
            Exercise semicolons = new Exercise ("Semicolons", "JS");
            Exercise constructors = new Exercise ("Constructor Practice", "C#");
            Exercise functions = new Exercise ("Functions", "JS");

            Cohort cohort35 = new Cohort ("E35");
            Cohort cohort36 = new Cohort ("D36");
            Cohort cohort37 = new Cohort ("D37");

            Student james = new Student ("James", "Nitz", "agrant", "E35");
            Student kevin = new Student ("Kevin", "Penny", "kpenny", "D36");
            Student willy = new Student ("Willy", "Metcalf", "wmetcalf", "D37");
            Student audrey = new Student ("Audrey", "Borgra", "aborgra", "D37");
            Student slacker = new Student ("Slacker", "McGee", "slacker", "D37");

            cohort35.AddStudent (james);
            cohort36.AddStudent (kevin);
            cohort37.AddStudent (willy);
            cohort37.AddStudent (audrey);
            cohort37.AddStudent (slacker);

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
            mo.AssignExercise (james, semicolons);
            mo.AssignExercise (james, constructors);
            steve.AssignExercise (audrey, functions);

            List<Student> students = new List<Student> ();
            students.Add (james);
            students.Add (willy);
            students.Add (kevin);
            students.Add (audrey);
            students.Add (slacker);

            List<Exercise> exercises = new List<Exercise> ();
            exercises.Add (classPractice);
            exercises.Add (functions);
            exercises.Add (semicolons);
            exercises.Add (constructors);

            List<Instructor> instructors = new List<Instructor> {
                steve,
                adam,
                mo
            };

            List<Cohort> cohorts = new List<Cohort> {
                cohort35,
                cohort36,
                cohort37
            };

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

            var filteredJSExercises = exercises.Where (exercise => exercise.Language == "JS");
            Console.WriteLine ($"JavaScript exercises:");

            foreach (var exercise in filteredJSExercises) {
                Console.WriteLine ($"{exercise.Name}");

            }
            Console.WriteLine ($"________________________");

            var cohort37Students = students.Where (student => student.Cohort == "D37");
            Console.WriteLine ($"Students in cohort 37:");

            foreach (var student in cohort37Students) {
                Console.WriteLine ($"{student.FirstName} {student.LastName}");

            }
            Console.WriteLine ($"________________________");

            var cohort37Instructors = instructors.Where (instructor => instructor.Cohort == "D37");
            Console.WriteLine ($"Instructors in cohort 37:");

            foreach (var instructor in cohort37Instructors) {
                Console.WriteLine ($"{instructor.FirstName} {instructor.LastName}");

            }
            Console.WriteLine ($"________________________");

            var sortedStudentNames = students.OrderBy (student => student.LastName);
            Console.WriteLine ($"Students sorted by last name:");

            foreach (var student in sortedStudentNames) {
                Console.WriteLine ($"{student.FirstName} {student.LastName}");
            }
            Console.WriteLine ($"________________________");

            var studentsWithoutExercises = students.Where (student => { return student.Exercises.Count == 0 || student.Exercises == null; });
            Console.WriteLine ($"Students without exercises:");

            foreach (var student in studentsWithoutExercises) {
                Console.WriteLine ($"{student.FirstName} {student.LastName}");
            }
            Console.WriteLine ($"________________________");

            var orderedStudentsByExercisesCount = students.OrderByDescending (student => {
                return student.Exercises.Count ();
            }).FirstOrDefault ();
            Console.WriteLine ($"Student with the most exercises:");

            Console.WriteLine ($"{orderedStudentsByExercisesCount.FirstName} {orderedStudentsByExercisesCount.LastName}");
            Console.WriteLine ($"________________________");

            var studentsPerCohort = students.GroupBy (student => student.Cohort).Select (group => {
                return new CohortReport {
                StudentCount = group.Count (),
                Name = group.Key
                };
            });
            Console.WriteLine ("Students in each cohort:");
            foreach (var group in studentsPerCohort) {
                Console.WriteLine ($"{group.Name} has {group.StudentCount}");
            }
        }
    }
    public class CohortReport {
        public int StudentCount { get; set; }
        public string Name { get; set; }
    }
}