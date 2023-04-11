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
    public class EmailCheckVM : ViewModelBase
    {
        private readonly HttpRequests _httpRequests;
        IDispatcherTimer timer;
        public EmailCheckVM()
        {
            _httpRequests = new HttpRequests();

            timer = Application.Current.Dispatcher.CreateTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (s, e) => timerCallback();
            timer.Start();

            BackCommand = new Command(ToBack);
            SendAgainCommand = new Command(SendAgain);
        }

        private async void SendAgain(object obj)
        {
            try
            {
                await _httpRequests.SendCode(Preferences.Get("UserMail", "Email not exist"));

                timer = Application.Current.Dispatcher.CreateTimer();
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += (s, e) => timerCallback();
                timer.Start();

                _btnSendIsVisible = false;
                OnPropertyChanged("BtnSendIsVisible");

                _timeIsVisible = true;
                OnPropertyChanged("TimeIsVisible");
            }
            catch (Exception)
            {
                return;
            }

        }

        private void timerCallback()
        {
            _value--;
            if (Value <= 0)
            {
                timer.Stop();

                _value = 60;
                OnPropertyChanged("Value");

                _btnSendIsVisible = true;
                OnPropertyChanged("BtnSendIsVisible");

                _timeIsVisible = false;
                OnPropertyChanged("TimeIsVisible");
            }
            OnPropertyChanged("Value");
            OnPropertyChanged("TimeToNewCode");
        }

        private int _value = 60;
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                OnPropertyChanged("Value");
            }
        }
        private async void ToBack(object obj)
        {
            await AppShell.Current.GoToAsync($"//{nameof(DashboardView)}");
        }

        private string _field1;
        public string Field1
        {
            get { return _field1; }
            set { _field1 = value; OnPropertyChanged("Field1"); }
        }

        private string _field2;
        public string Field2
        {
            get { return _field2; }
            set { _field2 = value; OnPropertyChanged("Field2"); }
        }

        private string _field3;
        public string Field3
        {
            get { return _field3; }
            set { _field3 = value; OnPropertyChanged("Field3"); }
        }

        private string _field4;
        public string Field4
        {
            get { return _field4; }
            set { _field4 = value; OnPropertyChanged("Field4"); }
        }

        private string _timeToNewCode;
        public string TimeToNewCode
        {
            get
            {
                return "Отправить код повторно можно будет через " + _value + " секунд";
            }
            set
            {
                _timeToNewCode = value;
                OnPropertyChanged("TimeToNewCode");
            }
        }

        private bool _btnSendIsVisible = false;
        public bool BtnSendIsVisible
        {
            get
            {
                return _btnSendIsVisible;
            }
            set
            {
                _btnSendIsVisible = value;
                OnPropertyChanged("BtnSendIsVisible");
            }
        }

        private bool _timeIsVisible = true;
        public bool TimeIsVisible
        {
            get
            {
                return _timeIsVisible;
            }
            set
            {
                _timeIsVisible = value;
                OnPropertyChanged("TimeIsVisible");
            }
        }

        public ICommand BackCommand { get; }
        public ICommand SendAgainCommand { get; }
    }
}
