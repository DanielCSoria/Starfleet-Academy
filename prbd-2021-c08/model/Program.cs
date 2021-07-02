using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRBD_Framework;



namespace prbd_2021_c08.model {
    public class Program {

        public static void SeedData(ModelContext model) {
            Init(model);
        }

        private static void Init(ModelContext model) {
            
            if (!model.Divisions.Any()) { InitDivision(model); }

            if (!model.Users.Any()) {
                InitTeacher(model);
                InitStudent(model);
            }

            if (!model.Courses.Any()) {
                InitCourse(model);
            }

            if (!model.Answers.Any()) {
                InitAnswer(model);
            }

            if (!model.Questions.Any()) {
               InitQuestion(model);
            }
            /*if (!model.Quizzes.Any()) {
                InitQuizz(model);
            }*/
            



        }

        private static void InitDivision(ModelContext model) {

            string[] names = { "science", "command", "engineering", "medecine" };
            for (int i = 0; i < names.Length; ++i)
                model.AddDivision(names[i]);
            model.SaveChanges();
        }

        private static void InitTeacher(ModelContext model) {

            var divisions = model.Divisions.ToList();
            model.AddUser("Bruno@starfleet.io", "Bruno", "Lacroix", "bruno", divisions[1], "  ", Role.Teacher);
            model.AddUser("Boris@starfleet.io", "Boris", "Verhaegen", "boris", divisions[2], "  ", Role.Teacher);
            model.AddUser("Ben@starfleet.io", "Benoit", "Pennelle", "ben", divisions[0], "  ", Role.Teacher);
            model.AddUser("Xavier@starfleet.io", "Xavier", "Pigoelet", "789", divisions[3], "  ", Role.Teacher);
            model.SaveChanges();
        }

        // I choose random name, star trek temporality is too vast
        private static void InitStudent(ModelContext model) {
            var divisions = model.Divisions.ToList();
            model.AddUser("Daniel@starfleet.io", "Daniel", "Soria", "Daniel", divisions[2], "  ", Role.Student);
            model.AddUser("Kaido@starfleet.io", "Kaido", "Sama", "789", divisions[1], "  ", Role.Student);
            model.AddUser("Shanks@starfleet.io", "Shanks", "Akagami", "789", divisions[3], "  ", Role.Student);
            model.AddUser("Charlotte@starfleet.io", "Charlotte", "Lilin", "789", divisions[0], "  ", Role.Student);
            model.AddUser("Edward@starfleet.io", "Edward", "Teach", "789", divisions[1], "  ", Role.Student);

            model.SaveChanges();
            
        }

        private static void InitCourse(ModelContext model) {

            var teachers = model.Users.Where(t => t.Role == Role.Teacher).ToList();
           
            model.AddCourse("History ", "Birth of the federation", 7, teachers[0]);
            model.AddCourse("Xenobiology ", "Concept of synthesizing and manipulating biological devices and systems", 7, teachers[0]);
            model.AddCourse("Engineering ", "Replicators, Transporters and Holodecks", 7, teachers[1]);
            model.AddCourse("Xenology", "centering on the study of alien languages", 7, teachers[0]);
            model.AddCourse("Astronomy ", "basic concept of equations and formula for space traveling", 7, teachers[0]);
            model.AddCourse("Medecine", " First Aid and Field Medicine", 7, teachers[3]);
            model.AddCourse("Piloting ", "Runabouts and Shuttles", 7, teachers[2]);
            model.AddCourse("Administration ", "Chain of Command and General Protocol", 7, teachers[0]);
            model.AddCourse("Diplomacy ", "The art or practice of conducting international relations, as in negotiating alliances, treaties, and agreements.", 7, teachers[2]);
            model.AddCourse("Major ships", "Advanced manuevering for large-scale starships > 1,000,000 tons.", 7, teachers[2]);
            model.AddCourse("Programming ", "object oriented software design and data abstraction", 7, teachers[1]);
            model.AddCourse("Starship emergencies", "procedures for staying alive during a plethora of starship emergencies", 7, teachers[2]);

      
            
            model.SaveChanges();

        }
        private static void InitAnswer(ModelContext model) {
            model.AddAnswer("No", true); //0
            model.AddAnswer("yes", false); //0
            model.AddAnswer("Sometimes", false); //0
            model.AddAnswer("Only with the enterprise", false); //0
            model.AddAnswer("Distortion 9 ", true); //1
            model.AddAnswer("Distortion 8", false); //1
            model.AddAnswer("Distortion 7", false); //1
            model.AddAnswer("Distortion 6", false); //1
            model.AddAnswer("A borg vessel ", false); //2
            model.AddAnswer("experimental deep-space tactical vessel", true); //2
            model.AddAnswer("A multi-vector assault mode splits type of vessel", true); //2
            model.AddAnswer("A klingon merceny ship", false); //2

            model.SaveChanges();
        }
        private static void InitQuestion(ModelContext model) {
            var answers = model.Answers.ToList();
            var courses = model.Courses.ToList();
            var list1 = new List<Answer>();
            var list2 = new List<Answer>();
            var list3 = new List<Answer>();
            list1.Add(answers[0]);
            list1.Add(answers[1]);
            list1.Add(answers[2]);
            list1.Add(answers[3]);
            list2.Add(answers[4]);
            list2.Add(answers[5]);
            list2.Add(answers[6]);
            list2.Add(answers[7]);
            list3.Add(answers[8]);
            list3.Add(answers[9]);
            list3.Add(answers[10]);
            list3.Add(answers[11]);

            model.AddQuestion("Can you use the exponential speed during an asteroid rain", QuestionType.SINGLE, 5, 10, courses[6], list3);
            model.AddQuestion("What is the maximum speed of distortion possible", QuestionType.SINGLE, 5, 10, courses[6], list2);
            model.AddQuestion("What kind of ship is the prometheus", QuestionType.MULTI, 5, 10, courses[6], list1);
            model.SaveChanges();
        }
       /* private static void InitQuizz(ModelContext model) {
            var questions = model.Questions.ToList();
            var courses = model.Courses.ToList();
            var user = model.Users.ToList();
            var qlist= new List<Question>();
            qlist.Add(questions[0]);
            qlist.Add(questions[1]);
            model.AddQuizz("Pilote test 1", courses[6], 77, new DateTime(2022, 05, 27, 10, 11, 33), new DateTime(2023, 05, 28, 10, 11, 33), qlist);
            model.AddQuizz("Pilote test 2", courses[6], 77, new DateTime(2020, 05, 27, 10, 11, 33), new DateTime(2021, 05, 28, 10, 11, 33), qlist);
            model.SaveChanges();
        }*/


        
    }
    }
