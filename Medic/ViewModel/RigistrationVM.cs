using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Medic.View;

namespace Medic.ViewModel
{
    public class RigistrationVM : ViewModelBase
    {
        public RigistrationVM()
        {
            SkipCommand = new Command(BtnSkip);
            NextCommand = new Command(GoToNextPage);
        }

        private async void GoToNextPage(object obj)
        {
            Preferences.Set("UserName", UserName);
            Preferences.Set("UserLastName", UserLastName);
            Preferences.Set("UserMiddleName", UserMiddleName);
            Preferences.Set("Birthday", Birthday);
            Preferences.Set("Gender", Gender);
            await AppShell.Current.GoToAsync($"//{nameof(AnalyzesView)}");
        }

        private async void BtnSkip(object obj)
        {
            await AppShell.Current.GoToAsync($"//{nameof(AnalyzesView)}");
        }

        public ICommand SkipCommand { get; set; }
        public ICommand NextCommand { get; set; }

        private string _userName = string.Empty;
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; OnPropertyChanged(); OnPropertyChanged("NextBtnIsEnabled"); }
        }

        private string _userMiddleName = string.Empty;
        public string UserMiddleName
        {
            get { return _userMiddleName; }
            set { _userMiddleName = value; OnPropertyChanged(); OnPropertyChanged("NextBtnIsEnabled"); }
        }

        private string _userLastName = string.Empty;
        public string UserLastName
        {
            get { return _userLastName; }
            set { _userLastName = value; OnPropertyChanged(); OnPropertyChanged("NextBtnIsEnabled"); }
        }

        private string _birthday = string.Empty;
        public string Birthday
        {
            get { return _birthday; }
            set { _birthday = value; OnPropertyChanged(); OnPropertyChanged("NextBtnIsEnabled"); }
        }

        private string _gender = string.Empty;
        public string Gender
        {
            get { return _gender; }
            set { _gender = value; OnPropertyChanged(); OnPropertyChanged("NextBtnIsEnabled"); }
        }

        private bool _nextBtnIsEnabled = false;
        public bool NextBtnIsEnabled
        {
            get
            {
                return _userName.Trim() == string.Empty || _userName == null
                    || _userLastName.Trim() == string.Empty || _userLastName == null
                    || _userMiddleName.Trim() == string.Empty || _userMiddleName == null
                    || _birthday.Trim() == string.Empty || _birthday == null
                    || _gender.Trim() == string.Empty || _gender == null
                    ? false : true;
            }
            set { _nextBtnIsEnabled = value; OnPropertyChanged(); }
        }
    }
}
