using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRBD_Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prbd_2021_c08.model {
    public class Division :  EntityBase<ModelContext> {

       [Key]
        public int Id { get; set;  }

        public string Name { get; set;  }

        public string PicturePath { get; set;  }

        [NotMapped]
        public string AbsolutePicturePath {
            get { return PicturePath != null ? App.IMAGE_PATH + "\\" + PicturePath + ".png" : null; }
        }

        public override string ToString() {
            return "Divison " + Name;
        }
    }
}
