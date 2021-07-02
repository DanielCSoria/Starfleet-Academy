using prbd_2021_c08.model;
using PRBD_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace prbd_2021_c08.viewmodel {
    class SubscribeViewModel : ViewModelCommon {

        public ICommand SubscribeCommand { get; set; }

        public ICommand Unsubscribe { get; set; }

        private User user;
        public User User { get => CurrentUser; }

        private Course course;

        public Course Course { get => course; set => SetProperty(ref course, value);}

        private bool subscribed;

        private bool notsubscribed;

        public bool IsSubscribed { get => subscribed; set => SetProperty(ref subscribed, value); }

        public bool NotSubscribed { get => notsubscribed; set => SetProperty(ref notsubscribed, value); }

        public SubscribeViewModel(Course course) : base(){
            user = User;
            Course = course; 
            SubscribeCommand = new RelayCommand(() => SubscribeAction());
            Unsubscribe = new RelayCommand(() => UnsubscribeAction());
            ConfigVisibility();
        }


        public void ConfigVisibility() {
            IsSubscribed = Course.IsStudentUnactive(CurrentUser);
            NotSubscribed = !IsSubscribed;
        }
      
        public void SubscribeAction() {
            Course.AddStudentToUnactive(user);
            //Context.SaveChanges();
            IsSubscribed = true;
            NotSubscribed = false;
        }
        public void UnsubscribeAction() {
            Course.RemoveFromUnactive(user);
            //Context.SaveChanges();
            IsSubscribed = false;
            NotSubscribed = true;
        }
    }
}
