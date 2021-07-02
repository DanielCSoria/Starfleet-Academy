using prbd_2021_c08.model;
using PRBD_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace prbd_2021_c08.viewmodel {
    class NewCourseViewModel  : ViewModelCommon {

        private User user;

        public ICommand AddCourse { get; set; }

        public ICommand Cancel { get; set; }

        private string name;

        public string Name { get => name; set => SetProperty<string>(ref name, value, () => Validate()); }

        private string summary;

        public string Summary { get => summary; set => SetProperty<string>(ref summary, value, () => Validate()); }

        private int capacity; 

        public int Capacity { get => capacity; set => SetProperty<int>(ref capacity, value, () => Validate());}

        public NewCourseViewModel(User user) {
            this.user = user;
            ConfigAction();
            
        }

        public void ConfigAction() {
            Cancel = new RelayCommand(() => NotifyColleagues(Messages.CLOSE_NEW_COURSE));
            AddCourse = new RelayCommand(AddCourseAction, () => {
                return name != null && summary != null && Capacity < 20 && Capacity > 0 && !HasErrors;
            });
        }
        
        public void AddCourseAction() {
            if (Validate()) {
                Context.AddCourse(Name, Summary, Capacity, CurrentUser);
                Context.SaveChanges();
                NotifyColleagues(Messages.COURSE_CHANGED);
                NotifyColleagues(Messages.CLOSE_NEW_COURSE);
            }
        }
        

        public override bool Validate() {
            ClearErrors();
            ValidateName();
            ValidateSummary();
            ValidateCapacity();
            return !HasErrors;
        }

        public bool ValidateName() {
            if (string.IsNullOrEmpty(Name)) {
                AddError(nameof(Name), "required");
            } else if (Context.Courses.Where(course => course.Name == Name).Any()) {
                AddError(nameof(Name), "course already exist");
            } else if (Name.Length < 4) {
                AddError(nameof(Name), "length < 4");
            }
            else if(Name.Length > 15) {
                AddError(nameof(Name), "length > 15");
            }
            return !HasErrors;
        }
        public bool ValidateSummary() {
            if (string.IsNullOrEmpty(Summary)) {
                AddError(nameof(Summary), "required");
            } else if (Summary.Length < 10) {
                AddError(nameof(Summary), "length > 10");
            } else if (Summary.Length > 222) {
                AddError(nameof(Summary), "too long");
            }
            return !HasErrors;
        }
        public bool ValidateCapacity() {
            if (Capacity > 20) {
                AddError(nameof(Capacity), "maximun capacity is 20");
            }
            else if(Capacity == 0) {
                AddError(nameof(Capacity), "you need at least 1 student");
            }
            return !HasErrors;
        }



    }
}
