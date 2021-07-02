using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRBD_Framework;
using System.ComponentModel.DataAnnotations;

namespace prbd_2021_c08.model {
    public class Note {

        [Key]
        public int Id { get; set; }

        public virtual QuizzPassed QuizzPassed { get; set; }

        public virtual User Student { get; set;  }

        

        



       


    }
}
