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
    class QuestionViewModel : ViewModelCommon {

        public ICommand Save { get; set; }

        public ICommand Reset { get; set; }

        public ICommand NewQuestion { get; set; }
        public ICommand Delete { get; set; }

        private static Course course;
        public Course Course { get => course; set => SetProperty(ref course, value); }

       
        private Question selectedquestion;
        public Question SelectedQuestion {
            get { return selectedquestion; }
            set {
                selectedquestion = value;
                RaisePropertyChanged(nameof(SelectedQuestion), nameof(HasQuestionSelected));
            }
        }

        public bool HasQuestionSelected {
            get { return selectedquestion != null; }
        }

        private ObservableCollection<Question> questions;

        public ObservableCollection<Question> Questions { get => questions; set => SetProperty(ref questions, value); }

        

        public bool IsSingle { get; set;  }

        public QuestionViewModel(Course course) {
            Course = course;
            Questions = new ObservableCollection<Question>(course.Questions);

           


            ConfigAction();
        }

        private Exception Exception(string v) {
            throw new NotImplementedException();
        }

        public void ConfigAction() {
            Save = new RelayCommand(() => SaveAction(), () => { return HasQuestionSelected && !HasErrors; });
            Delete = new RelayCommand(() => DeleteAction(), () => { return HasQuestionSelected; });
            NewQuestion = new RelayCommand(() => App.NotifyColleagues(Messages.NEW_QUESTION, Course));
            //Reset = new RelayCommand(() => ResetAction());

            Register(this, Messages.QUESTION_CHANGED, () => {
                Questions = new ObservableCollection<Question>(course.Questions); 
            });

        }
        
        private void SaveAction() {
            if(Validate()) {
                
                Context.SaveChanges();
                Questions = new ObservableCollection<Question>(Context.Questions);
            }
        }
        private void DeleteAction() {
            Context.Questions.Remove(SelectedQuestion);
            Context.SaveChanges();
            NotifyColleagues(Messages.QUESTION_CHANGED);
            
        }

        public override bool Validate() {
            ClearErrors();
            
                //ValidateTitle();
                //ValidateA1();
                //ValidateA2();
                //ValidateA3();
                //ValidateA4();
            
            return !HasErrors;

        }
        /*public bool ValidateTitle() {
            if (string.IsNullOrEmpty(SelectedQuestion.Title)) {
                AddError(nameof(SelectedQuestion.Title), "required");
            }  else if (SelectedQuestion.Title.Length < 4) {
                AddError(nameof(SelectedQuestion.Title), "length < 10");
            } else if (SelectedQuestion.Title.Length > 50) {
                AddError(nameof(SelectedQuestion.Title), "length > 15");
            }
            return !HasErrors;
        }

        // il y'avait des bugs important si je ne separait pas les meéthodes de la sorte
        public bool ValidateA1() {
            if (string.IsNullOrEmpty(SelectedQuestion.Answers[0].Body)) {
                AddError(nameof(SelectedQuestion.A1.Body), "required");
            } else if (SelectedQuestion.A1.Body.Length < 2) {
                AddError(nameof(SelectedQuestion.A1.Body), "length < 2");
            } else if (SelectedQuestion.A1.Body.Length > 77) {
                AddError(nameof(SelectedQuestion.A1.Body), "length > 77");
            }
            return !HasErrors;
        }
        public bool ValidateA2() {
            if (string.IsNullOrEmpty(SelectedQuestion.A2.Body)) {
                AddError(nameof(SelectedQuestion.A2.Body), "required");
            } else if (SelectedQuestion.A2.Body.Length < 2) {
                AddError(nameof(SelectedQuestion.A2.Body), "length < 2");
            } else if (SelectedQuestion.A2.Body.Length > 77) {
                AddError(nameof(SelectedQuestion.A2.Body), "length > 77");
            }
            return !HasErrors;
        }
        public bool ValidateA3() {
            if (string.IsNullOrEmpty(SelectedQuestion.A3.Body)) {
                AddError(nameof(SelectedQuestion.A3.Body), "required");
            } else if (SelectedQuestion.A3.Body.Length < 2) {
                AddError(nameof(SelectedQuestion.A3.Body), "length < 2");
            } else if (SelectedQuestion.A3.Body.Length > 77) {
                AddError(nameof(SelectedQuestion.A3.Body), "length > 77");
            }
            return !HasErrors;
        }
        public bool ValidateA4() {
            if (string.IsNullOrEmpty(SelectedQuestion.A4.Body)) {
                AddError(nameof(SelectedQuestion.A4.Body), "required");
            } else if (SelectedQuestion.A4.Body.Length < 2) {
                AddError(nameof(SelectedQuestion.A4.Body), "length < 2");
            } else if (SelectedQuestion.A4.Body.Length > 77) {
                AddError(nameof(SelectedQuestion.A4.Body), "length > 77");
            }
            return !HasErrors;
        }*/


    }
}
