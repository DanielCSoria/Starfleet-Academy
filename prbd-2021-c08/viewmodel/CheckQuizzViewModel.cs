using prbd_2021_c08.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prbd_2021_c08.viewmodel {
    class CheckQuizzViewModel : ViewModelCommon {

        private Quizz quizz;
        public Quizz Quizz { get => quizz; set => SetProperty(ref quizz, value); }

        private QuizzPassed quizzpassed;
        public QuizzPassed QuizzPassed { get => quizzpassed; set => SetProperty(ref quizzpassed, value); }

        public string Title { get => Quizz.Title; }

        public DateTime Start { get => Quizz.Start; }

        public DateTime Finish { get => Quizz.Finish; }

        public int ScoreMax { get => Quizz.Score; }

        public int Result { get => QuizzPassed.Score;  }

        public int QuestionNumber { get => Quizz.Questions.Count; }

        private ObservableCollection<Question> questions;

        public ObservableCollection<Question> Questions { get => questions; set => SetProperty(ref questions, value); }

        private ObservableCollection<QuestionQuizz> questionsquizz;

        public ObservableCollection<QuestionQuizz> QuestionsQuizz { get => questionsquizz; set => SetProperty(ref questionsquizz, value); }


        public CheckQuizzViewModel(Quizz quizz) {
            Quizz = quizz;
            QuizzPassed = Context.GetQuizzPassed(CurrentUser, quizz);
            Questions = new ObservableCollection<Question>(Quizz.Questions);
            
            QuestionsQuizz = new ObservableCollection<QuestionQuizz>(QuizzPassed.QuestionsQuizz);
            

        }

        private Exception Exception(string v) {
            throw new NotImplementedException();
        }
    }
}
