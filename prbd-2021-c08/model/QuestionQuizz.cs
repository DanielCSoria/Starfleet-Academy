using PRBD_Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace prbd_2021_c08.model {
    public class QuestionQuizz : EntityBase<ModelContext>{

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public QuestionType QuestionType { get; set; }

        public int Point { get; set; }

        public int MaxPoint { get; set; }

       

        public virtual Quizz Quizz { get; set; }

       

        public virtual List<AnswerQuizz> Answers { get; set; } = new List<AnswerQuizz>();

        public Visibility IsSingle {
            get {
                if (this.QuestionType == QuestionType.MULTI) {
                    return Visibility.Collapsed;
                }
                return Visibility.Visible;
            }

        }
        public Visibility IsMulti {
            get {
                if (this.QuestionType == QuestionType.SINGLE) {
                    return Visibility.Collapsed;
                }
                return Visibility.Visible;
            }

        }

        // public virtual List<Answer> Answers { get; set; } = new List<Answer>();

      

    }
}
