using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRBD_Framework;
using System.ComponentModel.DataAnnotations;
using prbd_2021_c08;

namespace prbd_2021_c08.model {
    public class Answer {


        public Answer() {

        }

        [Key]
        public int Id { get; set; }
        public string Body { get; set;  }

        public bool Status { get; set;  }

       

        public override string ToString() {
            return " " + Body;
        }


    }
}
