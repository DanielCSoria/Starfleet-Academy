using prbd_2021_c08.model;
using prbd_2021_c08.view;
using PRBD_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace prbd_2021_c08.viewmodel {
    class CourseDetailViewModel : ViewModelCommon {
      
        public ICommand Save { get; set;  }

        public ICommand Delete { get; set; }

        public ICommand Reset { get; set;  }

        private static Course course;
        public Course Course { get => course; set => SetProperty(ref course, value); }

        public bool IsTeacher { get; set; }

        public bool IsStudent { get; set;  }

        public bool IsExisting { get; set;  }

      
        private string name;
        public string Name { get => name; set => SetProperty(ref name, value); }

        private string teacher;

        public string Teacher { get => teacher; set => SetProperty(ref teacher, value); }

        private string summary;
        public string Summary { get => summary; set => SetProperty(ref summary, value, () => Validate()); }

        private int capacity;

        public int Capacity { get => capacity; set => SetProperty<int>(ref capacity, value, () => Validate()); }

        public ICommand Subscribe { get; set;  }

        public ICommand Registration { get; set; }

        public ICommand Quizz { get; set; }

        public ICommand Question { get; set; }

        public ICommand NoteBook { get; set; }

        public ICommand Categories { get; set; }

        public CourseDetailViewModel(Course course) : base(){
            IsTeacher = CurrentUser.Role == Role.Teacher;
            IsStudent = !IsTeacher;
            IsExisting = true;
           
            Course = Context.GetByName(course.Name);
            Name = Course.Name;
            Teacher = Course.Teacher.LastName;
            Summary = Course.Summary;
            Capacity = Course.Capacity;
            ConfigAction();
        }
      
        private void ConfigAction() {
            Reset = new RelayCommand(() => ResetAction());
            Save = new RelayCommand(() => SaveAction(), () => { return name != null && summary != null && Capacity < 20 && Capacity > 0 && !HasErrors; });
            Delete = new RelayCommand(() => DeleteAction());
            Question = new RelayCommand(() => NotifyColleagues(Messages.QUESTION, Course));
            Subscribe = new RelayCommand(() => NotifyColleagues(Messages.SUBSCRIBE, Course));
            Categories = new RelayCommand(() => NotifyColleagues(Messages.CATEGORY));
            Registration = new RelayCommand(() => NotifyColleagues(Messages.REGISTRATION, Course));
            QuizzAction();
            NoteBookAction();
            
        }
        private void QuizzAction() {
            if(IsTeacher || Course.IsStudentActive(CurrentUser)) {
                Quizz = new RelayCommand(() => NotifyColleagues(Messages.QUIZZ, course));
            }
        }
        private void NoteBookAction() {
            if (IsTeacher || Course.IsStudentActive(CurrentUser)) {
                NoteBook = new RelayCommand(() => NotifyColleagues(Messages.NOTEBOOK, Course));
            }
        }
        private void ResetAction() {
            Name = Course.Name;
            Teacher = Course.Teacher.LastName;
            Summary = Course.Summary;
            Capacity = Course.Capacity;
        }
     
        public override bool Validate() {
            ClearErrors();
            ValidateSummary();
            ValidateCapacity();
            RaiseErrors();
            return !HasErrors;
        }

        private void DeleteAction() {
            Context.Courses.Remove(Course);
            Context.SaveChanges();
            NotifyColleagues(Messages.COURSE_CHANGED);
            NotifyColleagues(Messages.CLOSE_COURSE_DETAIL, Course);
        }

        private void SaveAction() {
            if (Validate()) {
                Course.Summary = Summary;
                Course.Capacity = Capacity;
                Context.SaveChanges();
                NotifyColleagues(Messages.COURSE_CHANGED);
            }
        }
      
        public bool ValidateSummary() {
            if (string.IsNullOrEmpty(Summary)) {
                AddError(nameof(Summary), "required");
            } else if (Summary.Length < 10) {
                AddError(nameof(Summary), "length < 10");
            } else if (Summary.Length > 300) {
                AddError(nameof(Summary), "too long");
            }
            return !HasErrors;
        }
        public bool ValidateCapacity() {
            if (Capacity > 20) {
                AddError(nameof(Capacity), "maximun capacity is 20");
            } else if (Capacity == 0) {
                AddError(nameof(Capacity), "you need at least 1 student");
            }
            return !HasErrors;
        }








    }





}
