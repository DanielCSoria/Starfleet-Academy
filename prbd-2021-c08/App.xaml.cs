using PRBD_Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using prbd_2021_c08;
using prbd_2021_c08.model;

namespace prbd_2021_c08 {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : ApplicationBase {

        public static User CurrentUser { get; private set; }

        public App() {
            
        }

        public static void Login(User member) {
            CurrentUser = member;
        }

        public static void Logout() {
            CurrentUser = null;
        }

        public static bool IsLoggedIn { get => CurrentUser != null; }

        public static ModelContext Context { get => Context<ModelContext>(); }

        protected override void OnRefreshData() {
            if (CurrentUser?.Mail != null)
                CurrentUser = Context.GetByMail(CurrentUser.Mail);
        }

        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);

            Context.Seed();
        }





    }
}
