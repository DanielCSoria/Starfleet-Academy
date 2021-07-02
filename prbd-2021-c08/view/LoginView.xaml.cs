﻿using prbd_2021_c08.model;
using prbd_2021_c08.viewmodel;
using PRBD_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace prbd_2021_c08.view {
    /// <summary>
    /// Logique d'interaction pour LoginView.xaml
    /// </summary>
    public partial class LoginView : WindowBase { 
        public LoginView() {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }

        public static implicit operator UserControl(LoginView v) {
            throw new NotImplementedException();
        }

        private void Signup_Click(object sender, RoutedEventArgs e) {
            App.NavigateTo<RegisterView>();
        }

       
    }
}
