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
    class NewQuestionViewModel : ViewModelCommon {

        private static Course course;
        public Course Course { get => course; set => SetProperty(ref course, value); }

        private string title;

        public string Title { get => title; set => SetProperty(ref title, value, () => Validate()); }

        private string a1;

        public string A1 { get => a1; set => SetProperty(ref a1, value, () => Validate()); }

        private string a2;

        public string A2 { get => a2; set => SetProperty(ref a2, value, () => Validate()); }

        private string a3;

        public string A3 { get => a3; set => SetProperty(ref a3, value, () => Validate()); }

        private string a4;

        public string A4 { get => a4; set => SetProperty(ref a4, value, () => Validate()); }


        private int point;

        public int Point { get => point; set => SetProperty(ref point, value, () => Validate()); }

        private int pointmax;

        public int  PointMax { get => pointmax; set => SetProperty(ref pointmax, value, () => Validate()); }

        private bool isSingle;

        public bool IsSingle { get => isSingle; set => SetProperty(ref isSingle, value, () => Validate()); }

        // Questiontype boolean

        private bool isMulti;

        public bool IsMulti { get => isMulti; set => SetProperty(ref isMulti, value, () => Validate()); }

        // radiobutton boolean  

        private bool a1Radio;

        public bool A1Radio { get => a1Radio; set => SetProperty(ref a1Radio, value, () => Validate()); }

        private bool a2Radio;

        public bool A2Radio { get => a2Radio; set => SetProperty(ref a2Radio, value, () => Validate()); }

        private bool a3Radio;

        public bool A3Radio { get => a3Radio; set => SetProperty(ref a3Radio, value, () => Validate()); }

        private bool a4Radio;

        public bool A4Radio { get => a4Radio; set => SetProperty(ref a4Radio, value, () => Validate()); }



        // checbox boolean 


        private bool a1Check;

        public bool A1Check { get => a1Check; set => SetProperty(ref a1Check, value, () => Validate()); }

        private bool a2Check;

        public bool A2Check { get => a2Check; set => SetProperty(ref a2Check, value, () => Validate()); }

        private bool a3Check;

        public bool A3Check { get => a3Check; set => SetProperty(ref a3Check, value, () => Validate()); }

        private bool a4Check;

        public bool A4Check { get => a4Check; set => SetProperty(ref a4Check, value, () => Validate()); }

        private ObservableCollection<Answer> answers;

        public ObservableCollection<Answer> Answers { get => answers; set => SetProperty(ref answers, value); }


    public ICommand AddQuestion { get; set; }

        public ICommand Cancel { get; set;  }

        public NewQuestionViewModel(Course course) {
            Course = course;
            Answers = new ObservableCollection<Answer>();
            ConfigAction();
        }

        public void ConfigAction() {
            Cancel = new RelayCommand(() => NotifyColleagues(Messages.CLOSE_NEW_QUESTION, Course));
            AddQuestion = new RelayCommand(AddQuestionAction, () => {
                return title != null && a1 != null && a2 != null && a3 != null && a4 != null && point > 0 && pointmax > 10  &&!HasErrors;
            });
        }

        public void AddQuestionAction() {
            if (Validate()) {
                if (IsSingle) {
                    Answers.Add(Context.AddAnswer(A1, A1Radio));
                    Answers.Add(Context.AddAnswer(A2, A2Radio));
                    Answers.Add(Context.AddAnswer(A3, A3Radio));
                    Answers.Add(Context.AddAnswer(A4, A4Radio));
                    
                    Context.AddQuestion(Title, QuestionType.SINGLE, Point, PointMax, Course, Answers.ToList());
                    Context.SaveChanges();
                } else if (IsMulti) {
                    Answers.Add(Context.AddAnswer(A1, A1Check));
                    Answers.Add(Context.AddAnswer(A2, A2Check));
                    Answers.Add(Context.AddAnswer(A3, A3Check));
                    Answers.Add(Context.AddAnswer(A4, A4Check));
                    Context.AddQuestion(Title, QuestionType.MULTI, Point, PointMax, Course, Answers.ToList());
                    Context.SaveChanges();
                }
                NotifyColleagues(Messages.QUESTION_CHANGED);
                NotifyColleagues(Messages.CLOSE_NEW_QUESTION, Course);
            }
        }

        public override bool Validate() {
            ClearErrors();
            ValidateTitle();
            ValidateA1();
            ValidateA2();
            ValidateA3();
            ValidateA4();
            ValidatePoint();
            ValidateType();
            return !HasErrors;
        }
        public bool ValidateTitle() {
            if (string.IsNullOrEmpty(Title)) {
                AddError(nameof(Title), "required");
            } else if (Context.Questions.Where(q => q.Title == Title).Any()) {
                AddError(nameof(Title), "course already exist");
            } else if (Title.Length < 4) {
                AddError(nameof(Title), "length < 10");
            } else if (Title.Length > 50) {
                AddError(nameof(Title), "length > 15");
            }
            return !HasErrors;
        }

        public bool ValidateA1() {
            if (string.IsNullOrEmpty(A1)) {
                AddError(nameof(A1), "required");
            }
            else if (A1.Length < 2) {
                AddError(nameof(A1), "length < 2");
            }
            else if (A1.Length > 77) {
                AddError(nameof(A1), "length > 77");
            }
            return !HasErrors;
        }
        public bool ValidateA2() {
            if (string.IsNullOrEmpty(A2)) {
                AddError(nameof(A2), "required");
            }
            else if (A2.Length < 2) {
                AddError(nameof(A2), "length < 2");
            }
            else if (A2.Length > 77) {
                AddError(nameof(A2), "length > 77");
            }
            return !HasErrors;
        }
        public bool ValidateA3() {
            if (string.IsNullOrEmpty(A3)) {
                AddError(nameof(A3), "required");
            }
            else if (A3.Length < 2) {
                AddError(nameof(A3), "length < 2");
            }
            else if (A3.Length > 77) {
                AddError(nameof(A3), "length > 77");
            }
            return !HasErrors;
        }
        public bool ValidateA4() {
            if (string.IsNullOrEmpty(A4)) {
                AddError(nameof(A4), "required");
            }
            else if (A4.Length < 2) {
                AddError(nameof(A4), "length < 2");
            }
            else if (A4.Length > 77) {
                AddError(nameof(A4), "length > 77");
            }
            return !HasErrors;
        }


        // need to recheck
        public bool ValidatePoint() {
            if (point > 20 ) {
                AddError(nameof(Point), "value > 20");
            }
            else if(Point < 10) {
                AddError(nameof(Point), "value < 10");
            }
            return !HasErrors;
        }

        public bool ValidateType() {
            if (IsSingle && IsMulti) {
                AddError(nameof(IsSingle), "choose only one question type");
            }
            else if (IsSingle && !IsMulti) {
                if(!A1Radio && !A2Radio && !A3Radio && !A4Radio) {
                    AddError(nameof(IsSingle), "choose one answer");
                }
            }
            else if (IsMulti && !IsSingle) {
                if(CheckedNumber() != 2) {
                    AddError(nameof(IsMulti), "choose 2 answers");
                }
            }
            return !HasErrors;
        }

        public int CheckedNumber() {
            List<bool> checkbox = new List<bool>();
            checkbox.Add(A1Check);
            checkbox.Add(A2Check);
            checkbox.Add(A3Check);
            checkbox.Add(A4Check);
            int cpt = 0;
            for (int i = 0; i < 4; ++i) {
                if (checkbox[i])
                    ++cpt;
            }
            return cpt;
        }

     
          
            




    }
}
