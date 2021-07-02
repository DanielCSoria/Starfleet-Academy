using prbd_2021_c08.model;
using prbd_2021_c08.view;
using PRBD_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace prbd_2021_c08.viewmodel {
    class LoginViewModel : ViewModelCommon {

        public ICommand SignUpCommand { get; set; }

        public ICommand LoginCommand { get; set; }

        public ICommand LoginStudentCommand { get; set;  }

        private string mail = "Bruno@starfleet.io";
        public string Mail { get => mail; set => SetProperty<string>(ref mail, value, () => Validate()); }

        private string password = "bruno";
        public string PassWord { get => password; set => SetProperty<string>(ref password, value, () => Validate()); }

        public LoginViewModel() : base() {
            ConfigAction();
        }

        private void ConfigAction()
        {
            LoginCommand = new RelayCommand(
                LoginAction,
                () => { return mail != null && password != null && !HasErrors; }
            );
            SignUpCommand = new RelayCommand(() => App.NavigateTo<RegisterView>());

            LoginStudentCommand = new RelayCommand(() => LoginStudentAction());


        }

        private void LoginAction() 
        {
            if (Validate()) {
                var user = Context.Users.Find(Mail);
                Login(user);
                App.NavigateTo<MainView>();

            }
        }
        private void LoginStudentAction() {
            var user = Context.Users.Find("Daniel@starfleet.io");
            Login(user);
            App.NavigateTo<MainView>();
        }

        public override bool Validate() {
            ClearErrors();
            var user = Context.Users.Find(Mail);
            if (string.IsNullOrEmpty(mail)) {
                AddError(nameof(Mail), "required");
            } else if (user == null) {
                AddError(nameof(Mail), "user doesn't exist in this galaxy");
            } else {
                if (string.IsNullOrEmpty(PassWord)) {
                    AddError(nameof(PassWord), "required");
                } else if (user != null && user.PassWord != PassWord) {
                    AddError(nameof(PassWord), "wrong password");
                }
            }
            RaiseErrors();
            return !HasErrors;
        }
        protected override void OnRefreshData() {
            throw new NotImplementedException();
        }
    }
}
