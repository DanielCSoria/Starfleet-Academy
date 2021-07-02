using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRBD_Framework;
using System.ComponentModel.DataAnnotations;

namespace prbd_2021_c08.model {

    public enum Role { Student, Teacher }
    public class User : EntityBase<ModelContext> {

        [Key]
        public string Mail { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }


        public string PassWord { get; set; }

        public virtual Division Division { get; set; }

        public string Profile { get; set; }

        public Role Role { get; set; }

        public static ICollection<Course> Courses { get; set; } = new HashSet<Course>();
        public virtual ICollection<QuizzPassed> Quizzes { get; set; } = new HashSet<QuizzPassed>();


        public User() { }

        public override string ToString() {
            return FirstName + " " + LastName;
        }

        public bool isSubscribedTo(Course c) {
            return c.IsStudentUnactive(this);
        }
        public bool isActive(Course c) {
            return c.IsStudentActive(this);
        }

        public ICollection<Course> getCourses() {
            return Courses;
        }

        // methods for teachers

        public void AddCourse(Course course){
            if(this.Role != Role.Teacher){
                throw new FieldAccessException("Accessible only for teachers");
            }
            else {
                Courses.Add(course);
            }
        }
        public void ActivateStudent(Course course,User student) {
            if (this.Role != Role.Teacher && student.Role != Role.Student) {
                throw new FieldAccessException("Accessible only for teachers");
            } else {
                
                course.AddStudent(student);
                 
            }
        }
        public void DeactivateStudent(Course course, User student) {
            if (this.Role != Role.Teacher && student.Role != Role.Student) {
                throw new FieldAccessException("Accessible only for teachers");
            } else {
                course.RemoveStudent(student);
               
            }
        }

        // methods for students

        public void UnsubscribeFromCourse(Course course) {
            if (this.Role != Role.Student) {
                throw new FieldAccessException("Accessible only for students");
            } else {
                Courses.Remove(course);
                //RemoveFromCourse(course, this);
            }
        }

      
    }
}
