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
    class QuizzesViewModel : ViewModelCommon {

        public ICommand NewQuizz { get; set;  }

        public ICommand EditQuizz { get; set;  }

        public ICommand PassQuizz { get; set; }

        public ICommand CheckQuizz { get; set; }

        public Quizz SelectedQuizz { get; set; }

        public Quizz SelectedPastQuizz { get; set; }

        private static Course course;
        public Course Course { get => course; set => SetProperty(ref course, value); }

        private ObservableCollection<Quizz> quizzes;

        public ObservableCollection<Quizz> Quizzes { get => quizzes; set => SetProperty(ref quizzes, value); }

        private ObservableCollection<Quizz> pastquizzes;

        public ObservableCollection<Quizz> PastQuizzes { get => pastquizzes; set => SetProperty(ref pastquizzes, value); }

        public bool IsTeacher { get; set; }

        public bool IsStudent { get; set; }



        public QuizzesViewModel(Course course) {
            Course = course;
            IsTeacher = CurrentUser.Role == Role.Teacher;
            IsStudent = !IsTeacher;
            Quizzes = new ObservableCollection<Quizz>(course.GetCurrentQuizzes());
            PastQuizzes = new ObservableCollection<Quizz>(course.GetPastQuizzes());
            ConfigAction();
        }

        public void ConfigAction()
        {
            NewQuizz = new RelayCommand(() => NotifyColleagues(Messages.NEW_QUIZZ, course));
            EditQuizz = new RelayCommand(() => EditQuizzAction());
            PassQuizz = new RelayCommand(() => PassQuizzAction());
            CheckQuizz = new RelayCommand(() => CheckQuizzAction());

            Register(this, Messages.QUIZZ_CHANGED, () => {
                Quizzes = new ObservableCollection<Quizz>(course.GetCurrentQuizzes());
                PastQuizzes = new ObservableCollection<Quizz>(course.GetPastQuizzes());
            });
        }
        public void EditQuizzAction() {
            if(SelectedQuizz != null && SelectedQuizz.Start > DateTime.Now) {
                NotifyColleagues(Messages.EDIT_QUIZZ, SelectedQuizz);
            }
        }
        public void PassQuizzAction() {
            if (SelectedQuizz != null && SelectedQuizz.Start > DateTime.Now && SelectedQuizz.Finish > DateTime.Now) {
                NotifyColleagues(Messages.PASS_QUIZZ, SelectedQuizz);
            }
        }

        public void CheckQuizzAction() {
            if (SelectedPastQuizz != null && SelectedPastQuizz.Finish < DateTime.Now && IsCheckValid()) {
                NotifyColleagues(Messages.CHECK_QUIZZ, SelectedPastQuizz);
            }
        }

        public bool IsCheckValid() {
            var quizzpassed = Context.GetQuizzPassed(CurrentUser, SelectedPastQuizz);
            return CurrentUser.Quizzes.Contains(quizzpassed);
        }





    }
}
