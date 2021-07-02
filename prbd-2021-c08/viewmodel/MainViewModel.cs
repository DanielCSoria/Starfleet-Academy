using prbd_2021_c08.model;
using prbd_2021_c08.view;
using PRBD_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace prbd_2021_c08.viewmodel
{
    class MainViewModel : ViewModelCommon
    {

        public event Action<Course> DisplayCourse;

        public event Action Profile;

        public event Action DisplayCategories;

        public event Action<Course> NewQuizz;

        public event Action<Course> DisplaySubscribe;

        public event Action<Course> DisplayRegistration;

        public event Action<Course> DisplayQuestion;

        public event Action<Course> DisplayQuizz;

        public event Action<Course> DisplayNewQuestion;

        public event Action<Course> DisplayNoteBook;

        public event Action<Quizz> EditQuizz;

        public event Action<Quizz> PassQuizz;

        public event Action<Quizz> CheckQuizz;

        public event Action<User> NewCourse;

        public event Action<Course> CloseCourseDetail;

        public event Action<Course> CloseNewQuestion;

        public event Action<Course> CloseNewQuizz;

        public event Action<Quizz> CloseEditQuizz;

        public event Action<Quizz> ClosePassQuizz;


        public event Action CloseProfile;

        public event Action CloseNewCourse;

        public string Pseudo { get => CurrentUser.Mail;  }

        public User user { get => CurrentUser;  }

        public ICommand LogoutCommand { get; set; } 

        public ICommand ReloadDataCommand { get; set; }
        public MainViewModel() : base()
        {
            LogoutCommand = new RelayCommand(() => App.NavigateTo<LoginView>());

            Register<Course>(this, Messages.COURSE_DETAIL, course => {
                DisplayCourse?.Invoke(course);
            });
            Register(this, Messages.PROFILE, () => { 
                Profile?.Invoke();
            });
            Register<Course>(this, Messages.NEW_QUIZZ, course => {
                NewQuizz?.Invoke(course);
            });
            Register<User>(this, Messages.NEW_COURSE, user => {
                NewCourse?.Invoke(user);
            });
            Register(this, Messages.CLOSE_PROFILE, () => {

                CloseProfile?.Invoke();
            });
            Register(this, Messages.CLOSE_NEW_COURSE, () => {
                CloseNewCourse?.Invoke();
            });
            Register<Course>(this, Messages.CLOSE_COURSE_DETAIL, course => {
                CloseCourseDetail?.Invoke(course);
            });
            Register<Course>(this, Messages.SUBSCRIBE, course => {
                DisplaySubscribe?.Invoke(course);
            });
            Register<Course>(this, Messages.REGISTRATION, course => {
                DisplayRegistration?.Invoke(course);
            });
            Register<Course>(this, Messages.QUESTION, course => {
                DisplayQuestion?.Invoke(course);
            });
            Register<Course>(this, Messages.NOTEBOOK, course => {
                DisplayNoteBook?.Invoke(course);
            });

            Register(this, Messages.CATEGORY, () => {
                DisplayCategories?.Invoke();
            });
            Register<Course>(this, Messages.NEW_QUESTION, course => {
                DisplayNewQuestion?.Invoke(course);
            });
            Register<Course>(this, Messages.QUIZZ, course => {
                DisplayQuizz?.Invoke(course);
            });
            Register<Course>(this, Messages.CLOSE_NEW_QUESTION, course => {
                CloseNewQuestion?.Invoke(course);
            });
            Register<Course>(this, Messages.CLOSE_NEW_QUIZZ, course => {
                CloseNewQuizz?.Invoke(course);
            });
            
            Register<Quizz>(this, Messages.CLOSE_EDIT_QUIZZ, quizz => {
                CloseEditQuizz?.Invoke(quizz);
            });
            Register<Quizz>(this, Messages.CLOSE_PASS_QUIZZ, quizz => {
                ClosePassQuizz?.Invoke(quizz);
            });
            Register<Quizz>(this, Messages.EDIT_QUIZZ, quizz => {
                EditQuizz?.Invoke(quizz);
            });
            Register<Quizz>(this, Messages.PASS_QUIZZ, quizz => {
                PassQuizz?.Invoke(quizz);
            });
            Register<Quizz>(this, Messages.CHECK_QUIZZ, quizz => {
                CheckQuizz?.Invoke(quizz);
            });




        }

        protected override void OnRefreshData() {
            throw new NotImplementedException();
        }
    }
}
