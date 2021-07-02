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
using System.Windows.Shapes;

namespace prbd_2021_c08.view {
    /// <summary>
    /// Logique d'interaction pour MainView.xaml
    /// </summary>
    public partial class MainView : WindowBase {
        public MainView() {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        // from display from coursesview

        private void Vm_DisplayCourse(Course course) {
            if (course != null) {
                var tab = tabControl.FindByTag(course.Name);
                if (tab == null)
                    tabControl.Add(new CourseDetailView(course), course.Name, course.Name); 
                else
                    tabControl.SetFocus(tab);
            }
        }
        private void Vm_DisplayProfile() {
                var tab = tabControl.FindByTag("Profile");
                if (tab == null)
                    tabControl.Add(new ProfileView(), "Profile", "Profile");
                else
                    tabControl.SetFocus(tab);
            
        }
        private void Vm_DisplayNewCourse(User user) {
            var tab = tabControl.FindByTag("New Course");
            if (tab == null)
                tabControl.Add(new NewCourseView(user), "New Course", "New Course");
            else
                tabControl.SetFocus(tab);
        }


        // display from coursedetail

        private void Vm_DisplaySubscribtion(Course course) {
            string tabname = course.Name + " Subscribtion";
            var tab = tabControl.FindByTag(tabname);
            if (tab == null)
                tabControl.Add(new SubscribeView(course), tabname, tabname);
            else
                tabControl.SetFocus(tab);
        }
        private void Vm_DisplayRegistration(Course course) {
            string tabname = course.Name + " Registration";
            var tab = tabControl.FindByTag(tabname);
            if (tab == null)
                tabControl.Add(new RegistrationView(course), tabname, tabname);
            else
                tabControl.SetFocus(tab);
        }
        private void Vm_DisplayQuestion(Course course) {
            string tabname = course.Name + " Question";
            var tab = tabControl.FindByTag(tabname);
            if (tab == null)
                tabControl.Add(new QuestionView(course), tabname, tabname);
            else
                tabControl.SetFocus(tab);
        }
        private void Vm_Categorie() {
            string tabname ="Categories";
            var tab = tabControl.FindByTag(tabname);
            if (tab == null)
                tabControl.Add(new CategorieView(), tabname, tabname);
            else
                tabControl.SetFocus(tab);
        }
        private void Vm_DisplayQuizz(Course course) {
            string tabname = course.Name + " quizz";
            var tab = tabControl.FindByTag(tabname);
            if (tab == null)
                tabControl.Add(new QuizzesView(course), tabname, tabname);
            else
                tabControl.SetFocus(tab);
        }

        private void Vm_DisplayNoteBook(Course course) {
            string tabname = course.Name + " Notebook";
            var tab = tabControl.FindByTag(tabname);
            if (tab == null)
                tabControl.Add(new NoteBookView(course), tabname, tabname);
            else
                tabControl.SetFocus(tab);
        }


        // from question

        private void Vm_DisplayNewQuestion(Course course) {
            string tabname = course.Name + " New question";
            var tab = tabControl.FindByTag(tabname);
            if (tab == null)
                tabControl.Add(new NewQuestionView(course), tabname, tabname);
            else
                tabControl.SetFocus(tab);
        }



        // from quizz

        private void Vm_DisplayNewQizz(Course course) {
            string tabname = course.Name + " New quizz";
            var tab = tabControl.FindByTag(tabname);
            if (tab == null)
                tabControl.Add(new NewQuizzView(course), tabname, tabname);
            else
                tabControl.SetFocus(tab);
        }

        private void Vm_DisplayeditQuizz(Quizz quizz) {
            string tabname =  " Edit" + quizz.Title;
            var tab = tabControl.FindByTag(tabname);
            if (tab == null)
                tabControl.Add(new EditQuizzView(quizz), tabname, tabname);
            else
                tabControl.SetFocus(tab);
        }

        private void Vm_DisplayPassQuizz(Quizz quizz) {
            string tabname = " Pass" + quizz.Title;
            var tab = tabControl.FindByTag(tabname);
            if (tab == null)
                tabControl.Add(new PassQuizzView(quizz), tabname, tabname);
            else
                tabControl.SetFocus(tab);
        }

        private void Vm_DisplayCheckQuizz(Quizz quizz) {
            string tabname = quizz.Title;
            var tab = tabControl.FindByTag(tabname);
            if (tab == null)
                tabControl.Add(new CheckQuizzView(quizz), tabname, tabname);
            else
                tabControl.SetFocus(tab);
        }


        private void Vm_CloseTabNewQuizz(Course course) {
            var tab = tabControl.FindByTag(course.Name + " New quizz");
            tabControl.Items.Remove(tab);
        }
        private void Vm_CloseTabEditQuizz(Quizz quizz) {
            var tab = tabControl.FindByTag(" Edit" + quizz.Title);
            tabControl.Items.Remove(tab);
        }

        private void Vm_CloseTabPassQuizz(Quizz quizz) {
            var tab = tabControl.FindByTag(" Pass" + quizz.Title);
            tabControl.Items.Remove(tab);
        }




        // closing from coursesview

        private void Vm_CloseTabProfile() {
            var tab = tabControl.FindByTag("Profile");
            tabControl.Items.Remove(tab);
        }
        private void Vm_CloseTabNewCourse() {
            var tab = tabControl.FindByTag("New Course");
            tabControl.Items.Remove(tab);
        }
        private void Vm_CloseTabDetail(Course course) {
            var tab = tabControl.FindByTag(course.Name);
            tabControl.Items.Remove(tab);
        }
        private void Vm_CloseTabNewQuestion(Course course) {
            var tab = tabControl.FindByTag(course.Name + " New question");
            tabControl.Items.Remove(tab);
        }
       

    }
}
