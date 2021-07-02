using prbd_2021_c08.model;
using PRBD_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace prbd_2021_c08.viewmodel {
    class ProfileViewModel : ViewModelCommon {


        
        public User User { get => CurrentUser;  }

        public ICommand Save { get; set; }

        public ICommand Cancel { get; set; }

        public string Mail { get => CurrentUser.Mail; }

        public string FirstName { get => CurrentUser.FirstName; }

        public string LastName { get => CurrentUser.LastName;  }

        //private string picturepath;

        public string PicturePath { get => Division.AbsolutePicturePath; }

       public Division Division { get => CurrentUser.Division; }

        public Role Role { get => CurrentUser.Role;  }

        private string profile;

        public string Profile { get => profile; set => SetProperty<string>(ref profile, value, () => Validate()); }

        private string password;

        public string PassWord { get => password; set => SetProperty<string>(ref password, value, () => Validate()); }

        private string passwordconfirm;

        public string PasswordConfirm { get => passwordconfirm; set => SetProperty<string>(ref passwordconfirm, value, () => Validate()); }

        public ProfileViewModel() {
            //user = User;
            password = User.PassWord;
            profile = User.Profile;
            PasswordConfirm = User.PassWord;
            ConfigAction();
        }
        private void ConfigAction() {
            Save = new RelayCommand(() => SaveAction(),  () => { return password != null && passwordconfirm != null && !HasErrors; });
            Cancel = new RelayCommand(() => NotifyColleagues(Messages.CLOSE_PROFILE));
        }
        
        private void SaveAction() {
            if (Validate()) {
                User.PassWord = PassWord;
                User.Profile = Profile;
                Context.SaveChanges();
                NotifyColleagues(Messages.CLOSE_PROFILE);
            }
        }
        
        public override bool Validate() {
            ClearErrors();
            ValidateProfile();
            ValidatePassword();
            RaiseErrors();
            return !HasErrors;
        }
        private bool ValidateProfile() {
            if(Profile.Length > 222)
                AddError(nameof(Profile), "Profile too long");
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

    }
}
