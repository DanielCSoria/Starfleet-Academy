using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRBD_Framework;
using System.ComponentModel.DataAnnotations;


namespace prbd_2021_c08.model {
    public class Quizz : EntityBase<ModelContext> {

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual Course Course { get; set; }

        public int Score { get; set; }

       

        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }

        public int NumberQuestions { get; set; }



        [Timestamp]
        public byte[] Timestamp { get; set; }



        public virtual ICollection<Question> Questions { get; set; } = new HashSet<Question>();

        public virtual ICollection<QuestionQuizz> QuestionsQuizz { get; set; } = new HashSet<QuestionQuizz>();

        public virtual ICollection<QuizzPassed> QuizzesPassed { get; set; } = new HashSet<QuizzPassed>();


        public void ReadyForQuizz() {
            foreach(Question q in Questions) {
                var answers = new List<AnswerQuizz>();
                foreach (Answer a in q.Answers) {
                    answers.Add(Context.AddAnswerQuizz(a.Body, false));
                }
                Context.AddQuestionQuizz(q.Title, q.QuestionType, q.Point, q.MaxPoint, this, answers);
            }
            Context.SaveChanges();
        }

     















    }
}
