using PRBD_Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prbd_2021_c08.model {
    public class QuizzPassed : EntityBase<ModelContext>{

        [Key]
        public int Id { get; set; }

        public virtual Quizz Quizz { get; set; }

        public virtual ICollection<Question> Questions { get; set; } = new HashSet<Question>();

        public virtual ICollection<QuestionQuizz> QuestionsQuizz{ get; set; } = new HashSet<QuestionQuizz>();

        public virtual User Student { get; set;  }

        public bool Submited { get; set; }

        public int Score { get; set; }


        public int CalculSCore() {
            List<Question> QuestionsList = Questions.ToList();
            List<QuestionQuizz> QuestionsQuizzList = QuestionsQuizz.ToList();
            int somme = 0;
            for (int i = 0; i < Questions.Count; ++i) {
                for (int j = 0; j < 4; ++j) {
                    if(QuestionsList[i].Answers[j].Status == true && QuestionsQuizzList[i].Answers[j].Status == true) {
                        somme += QuestionsList[i].Point;
                    }
                    
                }
            }
            return somme;
        }
    }
}
