using PRBD_Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prbd_2021_c08.model {
    public class AnswerQuizz : EntityBase<ModelContext>{

     

        [Key]
        public int Id { get; set; }
        public string Body { get; set; }

        public bool Status { get; set; }

        public virtual QuestionQuizz QuestionQuizz { get; set; }



        public override string ToString() {
            return " " + Body;
        }
    }
}
