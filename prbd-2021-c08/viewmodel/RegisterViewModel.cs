using prbd_2021_c08.model;
using prbd_2021_c08.view;
using PRBD_Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace prbd_2021_c08.viewmodel {
    class RegisterViewModel : ViewModelCommon {

        private string mail;

        public string Mail { get => mail; set => SetProperty<string>(ref mail, value, () => Validate()); }

        private string firstname;

        public string FirstName { get => firstname; set => SetProperty<string>(ref firstname, value, () => Validate()); }

        private string lastname;

        public string LastName { get => lastname; set => SetProperty<string>(ref lastname, value, () => Validate()); }

        private string password;

        public string PassWord { get => password; set => SetProperty<string>(ref password, value, () => Validate()); }

        private string passwordconfirm;

        public string PasswordConfirm { get => passwordconfirm; set => SetProperty<string>(ref passwordconfirm, value, () => Validate()); }

        private ObservableCollection<Division> division;

        public ObservableCollection<Division> Division { get => division; set => SetProperty(ref division, value); }

        public Division SelectedDivision { get; set; }

        public Role Role = Role.Student;

        public ICommand Submit { get; set;  }

        public ICommand Cancel { get; set;  }

        public RegisterViewModel() {
            Division = new ObservableCollection<Division>(Context.Divisions);
            ConfigAction();
        }
        private void ConfigAction()
        {
            Submit = new RelayCommand(() => SubmitAction(), () => { return Mail != null && FirstName != null && LastName != null && PassWord != null && PasswordConfirm != null && !HasErrors;});
            Cancel = new RelayCommand(() => App.NavigateTo<LoginView>());
        }
        public void SubmitAction() {
            if (Validate()) {
                var div = Context.Divisions.ToList();
                var user = Context.AddUser(Mail, FirstName, LastName, PassWord, SelectedDivision, " ", Role.Student);
                Context.SaveChanges();
                Login(user);
                App.NavigateTo<MainView>();
            }
        }

        public override bool Validate() {
            ClearErrors();
            ValidateMail();
            ValidateFirstName();
            ValidateLastName();
            ValidatePassword();
            //ValidateDivision();
            RaiseErrors();
            return !HasErrors;
        }

     
        private bool ValidateMail() {
            if (string.IsNullOrEmpty(Mail) || !Mail.Contains('@'))
                AddError(nameof(Mail), "Mail can't be null and should contain an @ ");
            else if (Context.Users.Find(Mail) != null)
                AddError(nameof(Mail), "Mail \"" + Mail + "\" already exist.");
            return !HasErrors;
        }
        private bool ValidatePassword() {
            if (string.IsNullOrEmpty(PassWord) || string.IsNullOrEmpty(PasswordConfirm))
                AddError(nameof(PassWord), "required");
            else if (PassWord != PasswordConfirm)
                AddError(nameof(PasswordConfirm), "it's not matching the password");
            else if (PassWord.Length < 2)
                AddError(nameof(PassWord), "Your Password must contains more than 2 characters");
            return !HasErrors;
        }
        private bool ValidateFirstName()
        {
            if (string.IsNullOrEmpty(FirstName))
                AddError(nameof(FirstName), " required");
            else if (FirstName.Length > 15)
                AddError(nameof(FirstName), "should be under 15 characters");
            else if (FirstName.Length < 3)
                AddError(nameof(FirstName), "FirstName must be greater than 3");
            return !HasErrors;
        }
        private bool ValidateLastName()
        {
            if (string.IsNullOrEmpty(LastName))
                AddError(nameof(LastName), " required");
            else if (LastName.Length > 15)
                AddError(nameof(LastName), "should be under 15 characters");
            else if (LastName.Length < 3)
                AddError(nameof(LastName), "LastName must be greater than 3");
            return !HasErrors;
        }
        /*private bool ValidateDivision()
        {
            if(string.IsNullOrEmpty(Division))
                AddError(nameof(Division), " required");
            return !HasErrors;
        }

        protected override void OnRefreshData() {
            throw new NotImplementedException();
        }*/
    }
}
