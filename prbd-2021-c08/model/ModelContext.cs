using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRBD_Framework;
using System.IO;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.Logging;
using System.Windows.Input;
using prbd_2021_c08;



namespace prbd_2021_c08.model {
    public class ModelContext : DbContextBase {

         private ImageHelper helper;

        public DbSet<User> Users { get; set; }

        public DbSet<Division> Divisions { get; set; }
      
        public DbSet<Course> Courses { get; set; }
        public DbSet<Quizz> Quizzes { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<QuestionQuizz> QuestionsQuizz { get; set; }

        public DbSet<QuizzPassed> QuizzesPassed { get; set; }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public DbSet<AnswerQuizz> AnswersQuizz { get; set; }

      
        public ModelContext(){
           
        }

        public void Seed() {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
            Program.SeedData(this);
        }
        public static readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder => {
            builder.AddConsole();
        });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=prbd_projet_c08")
                .EnableSensitiveDataLogging()
                .UseLoggerFactory(_loggerFactory)
                .UseLazyLoadingProxies(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            
        }

        public Division AddDivision(string name) {
            var division = Divisions.CreateProxy();
            division.Name = name;
            helper = new ImageHelper(App.IMAGE_PATH, name);
            division.PicturePath = helper.CurrentFile;
            Divisions.Add(division);
            return division;
        }

        public Course AddCourse(string name, string summary, int capacity, User teach) {
            var c = Courses.CreateProxy();
            c.Name = name;
            c.Summary = summary;
            c.Capacity = capacity;
            c.Teacher = teach;
            
            Courses.Add(c);
           
            return c;
        }

        public User AddUser(string mail, string firstname, string lastname, string pass, Division d, string profil,  Role role) {
            var u = Users.CreateProxy();
            u.Mail = mail;
            u.FirstName = firstname;
            u.LastName = lastname;
            u.PassWord = pass;
            u.Division = d;
            u.Profile = profil;
            u.Role = role;
            Users.Add(u);
            return u;
        }
        public Quizz AddQuizz(string title, Course course, int score, DateTime start, DateTime finish, List<Question> questions) {
            var q = Quizzes.CreateProxy();
            q.Title = title;
            q.Course = course;
            q.Start = start;
            q.Finish = finish;
            q.Score = score;
            q.Questions = questions;
            q.NumberQuestions = questions.Count;
          
            course.Quizzes.Add(q);
            Quizzes.Add(q);
            return q;
        }

        public QuizzPassed AddQuizzPassed(Quizz quizz, List<Question> questions ,List<QuestionQuizz> questionsquizz, User u, int score) {
            var q = QuizzesPassed.CreateProxy();
            q.Quizz = quizz;
            q.Questions = questions;
            q.QuestionsQuizz = questionsquizz;
            q.Student = u;
            q.Score = score;
            QuizzesPassed.Add(q);
            return q;
        }



        public Question AddQuestion(string title, QuestionType type, int point, int pointMax, Course course, List<Answer> answers) {
            var q = Questions.CreateProxy();
            q.Title = title;
            q.QuestionType = type;
            q.Point = point;
            q.MaxPoint = pointMax;
            q.course = course;
            q.Answers = answers;
            course.Questions.Add(q);
            Questions.Add(q);
            return q;
        }

        public QuestionQuizz AddQuestionQuizz(string title, QuestionType type, int point, int pointMax, Quizz quizz, List<AnswerQuizz> answers) {
            var q = QuestionsQuizz.CreateProxy();
            q.Title = title;
            q.QuestionType = type;
            q.Point = point;
            q.MaxPoint = pointMax;
            q.Quizz = quizz;
            
            q.Answers = answers;
            quizz.QuestionsQuizz.Add(q);
            QuestionsQuizz.Add(q);
            return q;
        }

        public Answer AddAnswer(string body, bool status) {
            var a = Answers.CreateProxy();
            a.Body = body;
            a.Status = status;
            Answers.Add(a);
            return a;
        }
        public AnswerQuizz AddAnswerQuizz(string body, bool status) {
            var a = AnswersQuizz.CreateProxy();
            a.Body = body;
            a.Status = status;
            
            AnswersQuizz.Add(a);
            return a;
        }

        public Note AddNote(User student, QuizzPassed quizzpassed) {
            var n = Notes.CreateProxy();
            n.Student = student;
            n.QuizzPassed = quizzpassed;
            Notes.Add(n);
            return n;
        }


        public  User GetByMail(string mail) {
            return Users.SingleOrDefault(m => m.Mail == mail);
        }
        public  Course GetByName(string name) {
            return Courses.SingleOrDefault(m => m.Name == name);
        }
       
        public Division GetDivision(string name)
        {
            return Divisions.SingleOrDefault(d => d.Name == name);
        }

        public QuizzPassed GetQuizzPassed(User user, Quizz quizz) {
            return QuizzesPassed.SingleOrDefault(q => q.Quizz.Id == quizz.Id && q.Student.Mail == user.Mail);
        }

        








    }
}
