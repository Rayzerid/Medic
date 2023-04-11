using Org.Apache.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Medic.Model;
using Medic.View;

namespace Medic.ViewModel
{
    public class DashboardVM:ViewModelBase
    {
        private readonly HttpRequests _httpRequests;
        public DashboardVM()
        {
            _httpRequests = new HttpRequests();
            NextCommand = new Command<string>(ToEmailCheckView);
        }
        public ICommand NextCommand { get; }

        private async void ToEmailCheckView(object obj)
        {
            try
            {
                string response = await _httpRequests.SendCode(UserMail);
                Preferences.Set("UserMail", UserMail);
                await AppShell.Current.GoToAsync($"//{nameof(EmailCheckView)}");
            }
            catch (Exception)
            {
                return;
            }

        }

        private string _userMail;
        public string UserMail
        {
            get
            {
                return _userMail;
            }
            set
            {
                _userMail = value;
                OnPropertyChanged("UserMail");
                OnPropertyChanged("NextBtnIsEnabled");
            }
        }

        private bool _nextBtnIsEnabled;
        public bool NextBtnIsEnabled
        {
            get
            {
                return _userMail == null || _userMail.Trim() == string.Empty ? false : true;
            }
            set
            {
                _nextBtnIsEnabled = value;
                OnPropertyChanged("NextBtnIsEnabled");
            }
        }
    }
}
