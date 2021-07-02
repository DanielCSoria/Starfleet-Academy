using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRBD_Framework;
using System.ComponentModel.DataAnnotations;

namespace prbd_2021_c08.model {
    public class Course : EntityBase<ModelContext>{

        [Key]
        public int Id { get; set; }

        public string Name { get; set;  }

        public string Summary { get; set;  }

        public int Capacity { get; set;  }

        public virtual User Teacher { get; set;  }

        public virtual List<User> ActiveStudent { get; set; } = new List<User>();

        public virtual List<User> UnactiveStudent { get; set; } = new List<User>();

        public virtual ICollection<Question> Questions { get; set; } = new HashSet<Question>();

        public virtual ICollection<Quizz> Quizzes { get; set; } = new HashSet<Quizz>();

        public Course() {
          
        }
        public bool IsCourseFull() {
            return ActiveStudent.Count >= Capacity;
        }
        public void AddStudent(User student) {
            ActiveStudent.Add(student);
            if (UnactiveStudent.Contains(student)) {
               UnactiveStudent.Remove(student);
                
            }
            Context.SaveChanges();
           
        }

        public void RemoveStudent(User s) {
            if (ActiveStudent.Contains(s)) {
                ActiveStudent.Remove(s);
                AddStudentToUnactive(s);
            }
            Context.SaveChanges();
        }

        public void AddStudentToUnactive(User student) {
            if (ActiveStudent.Where(user => user.Mail == student.Mail).Any() || UnactiveStudent.Where(user => user.Mail == student.Mail).Any()) {
                throw new ArgumentException("Already subscribed");
            }
            UnactiveStudent.Add(student);
            Context.SaveChanges();
        }

        public void RemoveFromUnactive(User student) {
            if (UnactiveStudent.Contains(student)) {
                UnactiveStudent.Remove(student);
            }
            Context.SaveChanges();
        }

        public bool IsStudentUnactive(User student) {
                return UnactiveStudent.Where(user => user.Mail == student.Mail).Any();
        }

        public bool IsStudentActive(User student) {
            return ActiveStudent.Where(user => user.Mail == student.Mail).Any();
        }

        public List<Quizz> GetPastQuizzes() {
            return Quizzes.Where(q => q.Finish < DateTime.Now).ToList();
        }
        public List<Quizz> GetCurrentQuizzes() {
            return Quizzes.Where(q => q.Finish > DateTime.Now).ToList();
        }
        





    }
   
}
