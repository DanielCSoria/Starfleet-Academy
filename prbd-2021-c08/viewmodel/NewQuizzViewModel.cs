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
    class NewQuizzViewModel : ViewModelCommon {


        private Course course;
        public Course Course { get => course; set => SetProperty(ref course, value); }

        private ObservableCollection<Question> questions;

        public ObservableCollection<Question> Questions { get => questions; set => SetProperty(ref questions, value); }

        private ObservableCollection<Question> questionsquizz;

        public ObservableCollection<Question> QuestionsQuizz { get => questionsquizz; set => SetProperty(ref questionsquizz, value); }

        private string title;

        public string Title { get => title; set => SetProperty(ref title, value, () => Validate()); }

        private DateTime start;

        public DateTime Start { get => start; set => SetProperty(ref start, value, () => Validate()); }

        private DateTime finish;

        public DateTime Finish { get => finish; set => SetProperty(ref finish, value, () => Validate()); }

        public ICommand Add { get; set; }

        public ICommand Eject { get; set; }

        public ICommand CreateQuizz { get; set; }

        public ICommand Cancel { get; set; }

        public Question SelectedQuestion { get; set; }

        public Question SelectedQuestionQuizz { get; set; }

        public NewQuizzViewModel(Course course) {
            Course = course;
            Questions = new ObservableCollection<Question>(course.Questions);
            QuestionsQuizz = new ObservableCollection<Question>();
            ConfigAction();

        }
        public void ConfigAction() {
            Add = new RelayCommand(() => AddAction());
            Eject = new RelayCommand(() => EjectAction());
            CreateQuizz = new RelayCommand(() => CreateNewQuizz(), () => { return title != null && QuestionsQuizz.Count > 1 && !HasErrors; });
            Cancel = new RelayCommand(() => NotifyColleagues(Messages.CLOSE_NEW_QUIZZ, Course));
        }
        private void AddAction() {
            if (SelectedQuestion != null && !QuestionsQuizz.Contains(SelectedQuestion)) {
                QuestionsQuizz.Add(SelectedQuestion);
            }
        }
        private void EjectAction() {
            QuestionsQuizz.Remove(SelectedQuestionQuizz);
        }
        private void CreateNewQuizz() {
            if (Validate()) {
                int score = getMaxScore();
                Context.AddQuizz(Title, Course, score, Start, Finish, QuestionsQuizz.ToList());
                Context.SaveChanges();
                NotifyColleagues(Messages.QUIZZ_CHANGED);
                NotifyColleagues(Messages.CLOSE_NEW_QUIZZ, Course);
            }
            
        }
        private int getMaxScore() {
            int ScoreMax = 0;
            foreach (Question q in QuestionsQuizz) {
                ScoreMax += q.MaxPoint;
            }
            return ScoreMax;
        }
        public override bool Validate() {
            ClearErrors();
            ValidateTitle();
            ValidateStart();
            ValidateFinish();
          
            return !HasErrors;
        }
        public bool ValidateTitle() {
            if (string.IsNullOrEmpty(Title)) {
                AddError(nameof(Title), "required");
            }
            else if (Context.Quizzes.Where(q => q.Title == Title).Any()) {
                AddError(nameof(Title), "course already exist");
            }
            else if (Title.Length < 4) {
                AddError(nameof(Title), "length at least 4");
            }
            else if (Title.Length > 25) {
                AddError(nameof(Title), "too long, length at most 24");
            }
            return !HasErrors;
        }
        public bool ValidateStart() {
            if(Start <= DateTime.Now) {
                AddError(nameof(Start), "the date time shoulde be > of today's date");
            }
            return !HasErrors;
        }
        public bool ValidateFinish() {
            if(Finish < Start) {
                AddError(nameof(Finish), "the date time shoulde be > of starting date");
            }
            return !HasErrors;
        }
        
       

    }
}
