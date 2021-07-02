using prbd_2021_c08.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prbd_2021_c08.viewmodel {
    class NoteBookViewModel : ViewModelCommon {


        private Course course;
        public Course Course { get => course; set => SetProperty(ref course, value); }

        public bool IsTeacher { get; set; }

        public bool IsStudent { get; set; }

        public bool IsExisting { get; set; }


        private string name;
        public string Name { get => name; set => SetProperty(ref name, value); }

        private ObservableCollection<Note> notes;
        public ObservableCollection<Note> Notes { get => notes; set => SetProperty(ref notes, value); }

        public NoteBookViewModel(Course course) {
            Course = course;
            IsTeacher = CurrentUser.Role == Role.Teacher;
            IsStudent = !IsTeacher;
            Instancied();

            Register(this, Messages.NOTE_CHANGED, () => {
                Instancied();
            });

        }
        public void Instancied() {
            if (IsTeacher) {
                Notes = new ObservableCollection<Note>(Context.Notes);
            }
            else {
                Notes = new ObservableCollection<Note>(Context.Notes.Where(n => n.Student.Mail == CurrentUser.Mail)); ;
            }
        }

    }
}
