using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRBD_Framework;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace prbd_2021_c08.model {

    public enum QuestionType { SINGLE, MULTI };

    public class Question : EntityBase<ModelContext>{

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public QuestionType QuestionType { get; set; }

        public int Point { get; set; }

        public int MaxPoint { get; set; }

        public virtual Course course { get; set;  }

    

        public virtual List<Answer> Answers { get; set; } = new List<Answer>();

        public Visibility IsSingle {
            get
            {
                if (this.QuestionType == QuestionType.MULTI) {
                    return Visibility.Collapsed;
                }
                return Visibility.Visible;
            }

        }
        public Visibility IsMulti {
            get
            {
                if (this.QuestionType == QuestionType.SINGLE) {
                    return Visibility.Collapsed;
                }
                return Visibility.Visible;
            }

        }

        // public virtual List<Answer> Answers { get; set; } = new List<Answer>();

        public Question() {
            
        }

        

       

      
    }
}
