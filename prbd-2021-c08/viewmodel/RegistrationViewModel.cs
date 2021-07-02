using prbd_2021_c08.model;
using PRBD_Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace prbd_2021_c08.viewmodel {
    class RegistrationViewModel : ViewModelCommon {

        private Course course;
        public Course Course { get => course; set => SetProperty(ref course, value); }

        private ObservableCollection<User> students;

        public ObservableCollection<User> Students { get => students; set => SetProperty(ref students, value); }

        private ObservableCollection<User> active;
        public ObservableCollection<User> Active {
            get => active;
            set => SetProperty(ref active, value);
        }

        private ObservableCollection<User> unactive;
        public ObservableCollection<User> UnActive {
            get => unactive;
            set => SetProperty(ref unactive, value);
        }

       
        public User SelectedActive { get; set; }
        public User SelectedUnactive { get; set; }
       
        public bool isUnactive { get; set;  }

        public ICommand Activate { get; set; }

        public ICommand Deactivate { get; set; }

        public RegistrationViewModel(Course c) {
            course = c; ;
            ConfigAction();
            Students = new ObservableCollection<User>(this.getUnregistred(c));
            Active = new ObservableCollection<User>(c.ActiveStudent);
            UnActive= new ObservableCollection<User>(c.UnactiveStudent);

        }

     
        public bool ValidateActive() {
            return SelectedUnactive != null && Active.Count < Course.Capacity;
        }
        public bool ValidateUnactive() {
            return SelectedActive != null;
        }

        public void ConfigAction() {
            Activate = new RelayCommand(() => ActivateAction(), () => ValidateActive());
            Deactivate = new RelayCommand(() => UnActivateAction(), () => Validate());
        }

        public void ActivateAction() {
            if (ValidateActive() && Active.Count < Course.Capacity) {
                CurrentUser.ActivateStudent(Course, SelectedUnactive);
                Active = new ObservableCollection<User>(Course.ActiveStudent);
                UnActive = new ObservableCollection<User>(Course.UnactiveStudent);
                Students = new ObservableCollection<User>(this.getUnregistred(course));
                Context.SaveChanges();
                NotifyColleagues(Messages.COURSE_CHANGED);
              
               
            }
        }
        public void UnActivateAction() {
            if (ValidateUnactive()) {
                CurrentUser.DeactivateStudent(Course, SelectedActive);
                Active = new ObservableCollection<User>(Course.ActiveStudent);
                UnActive = new ObservableCollection<User>(Course.UnactiveStudent);
                Context.SaveChanges();
                NotifyColleagues(Messages.COURSE_CHANGED);
               

            }
        }

        public List<User> getUnregistred(Course course) {
            List<User> ls = new List<User>();
            List<User> users = new List<User>(Context.Users);
            for (int i = 0; i < users.Count; ++i) {
                if(users[i].Role == Role.Student && !users[i].isSubscribedTo(course) && !users[i].isActive(course)){
                    ls.Add(users[i]);
                }
            }
            return ls;
        }
        protected override void OnRefreshData() {
            
            RaisePropertyChanged();
        }
    }
}
