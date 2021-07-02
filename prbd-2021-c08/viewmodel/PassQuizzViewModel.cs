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
    class PassQuizzViewModel : ViewModelCommon {

        public ICommand Save { get; set; }

        public ICommand Submit { get; set; }

        public User Student { get => CurrentUser;  }
        public Course Course { get => Quizz.Course; }

        private Quizz quizz;
        public Quizz Quizz { get => quizz; set => SetProperty(ref quizz, value); }

        private QuizzPassed quizzpassed;
        public QuizzPassed QuizzPassed { get => quizzpassed; set => SetProperty(ref quizzpassed, value); }

        public string Title { get => Quizz.Title;  }
      
        public DateTime Start { get => Quizz.Start; }

        public DateTime Finish { get => Quizz.Finish; }

        public int ScoreMax { get => Quizz.Score; }

        public int QuestionNumber { get => Quizz.Questions.Count; }

        private ObservableCollection<QuestionQuizz> questions;

        public ObservableCollection<QuestionQuizz> Questions { get => questions; set => SetProperty(ref questions, value); }

        public PassQuizzViewModel(Quizz quizz) {
            Quizz = quizz;
            Questions = new ObservableCollection<QuestionQuizz>(quizz.QuestionsQuizz);
            if (Questions.Count == 0) {
                quizz.ReadyForQuizz();
                Questions = new ObservableCollection<QuestionQuizz>(quizz.QuestionsQuizz);
                QuizzPassed = Context.AddQuizzPassed(quizz, quizz.Questions.ToList(), Questions.ToList(), CurrentUser, 0);
                quizz.QuizzesPassed.Add(QuizzPassed);
                Context.SaveChanges();
                
            }
            else {
                QuizzPassed = Context.GetQuizzPassed(CurrentUser, Quizz);
                Questions = new ObservableCollection<QuestionQuizz>(Quizz.QuestionsQuizz);
                
            }
            Save = new RelayCommand(() => SaveAction());
            Submit = new RelayCommand(() => SubmitAction());

        }


        public void SaveAction() {
            Context.SaveChanges();
        }

        public void SubmitAction() {

            QuizzPassed.Score = QuizzPassed.CalculSCore();
            QuizzPassed.Submited = true;
            Context.AddNote(CurrentUser, QuizzPassed);
            CurrentUser.Quizzes.Add(QuizzPassed);
            Context.SaveChanges();
            NotifyColleagues(Messages.QUIZZ_CHANGED);
            NotifyColleagues(Messages.CLOSE_PASS_QUIZZ, Quizz);
            NotifyColleagues(Messages.NOTE_CHANGED);

        }
       



    }
}
