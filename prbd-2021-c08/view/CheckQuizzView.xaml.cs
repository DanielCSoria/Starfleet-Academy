using prbd_2021_c08.model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace prbd_2021_c08.view {
    /// <summary>
    /// Logique d'interaction pour CheckQuizzView.xaml
    /// </summary>
    public partial class CheckQuizzView : UserControlBase {
        public CheckQuizzView(Quizz quizz) {
            InitializeComponent();
            DataContext = new CheckQuizzViewModel(quizz);
        }
    }
}
