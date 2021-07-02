using prbd_2021_c08.model;
using PRBD_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prbd_2021_c08.viewmodel {
    public abstract class ViewModelCommon : ViewModelBase<ModelContext> {


        public ViewModelCommon() : base() {
        }

        public static User CurrentUser {
            get => App.CurrentUser; 
        }
       

        public static void Login(User user) {
            App.Login(user);
        }

        public static void Logout() {
            App.Logout();
        }


        protected override void OnRefreshData() {
            throw new NotImplementedException();
        }
    }
}
