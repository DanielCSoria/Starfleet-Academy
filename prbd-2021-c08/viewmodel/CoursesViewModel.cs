using prbd_2021_c08.model;
using PRBD_Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace prbd_2021_c08.viewmodel
{
    class CoursesViewModel : ViewModelCommon {
        public ICommand DisplayCourse { get; set; }

        public ICommand Profile { get; set; }

        public ICommand NewCourse { get; set; }

        public ICommand GetAll { get; set;  }

        public ICommand GetRelated { get; set; }

        private ObservableCollection<Course> courses;
        public ObservableCollection<Course> Courses {
            get => courses;
            set => SetProperty<ObservableCollection<Course>>(ref courses, value);
        }

        public bool IsTeacher { get; set; }

        public bool IsStudent { get; set; }



        private bool all;
        public bool All { get => all; set => SetProperty(ref all, value); }

        private bool related;
        public bool Related { get => related; set => SetProperty(ref related, value); }

        public CoursesViewModel() : base() {
            IsTeacher = CurrentUser.Role == Role.Teacher;
            IsStudent = !IsTeacher;
            InstanceCourse();
            ConfigAction();
            

        }
        public void InstanceCourse()
        {
          
            if (!IsTeacher) {
                Courses = new ObservableCollection<Course>(App.Context.Courses);
            }
            else {
                var query = from c in Context.Courses
                            where c.Teacher.Mail == CurrentUser.Mail
                            select c;
                Courses = new ObservableCollection<Course>(query);
            }
        }
        private void ConfigAction() {
            DisplayCourse = new RelayCommand<Course>(course => {
                NotifyColleagues(Messages.COURSE_DETAIL, course);
            });

            Profile = new RelayCommand<User>(user => { NotifyColleagues(Messages.PROFILE); });

            NewCourse = new RelayCommand<User>(user => {
                NotifyColleagues(Messages.NEW_COURSE, user);
            });
            Register(this, Messages.COURSE_CHANGED, () => {
                InstanceCourse();
            });
            GetAll = new RelayCommand(() => Courses = new ObservableCollection<Course>(App.Context.Courses));

            var query = from c in Context.Courses
                        where c.ActiveStudent.Contains(CurrentUser)
                        select c;
           

            GetRelated = new RelayCommand(() => Courses = new ObservableCollection<Course>(query)); 


        }

        protected override void OnRefreshData()
        {
            throw new NotImplementedException();
        }
    }
}
