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
    /// Interaction logic for SubscribeView.xaml
    /// </summary>
    public partial class SubscribeView : UserControlBase {

        public SubscribeView(Course course) {
            InitializeComponent();
            DataContext = new SubscribeViewModel(course);
            //vm.Init(course);
        }

        public static readonly DependencyProperty CourseProperty =
            DependencyProperty.Register(
                nameof(Course),                 
                typeof(Course),                
                typeof(SubscribeView),     
                new PropertyMetadata(null)     
            );

        public Course Course {
            get { return (Course)GetValue(CourseProperty); }
            set { SetValue(CourseProperty, value); }
        }
    }
}
