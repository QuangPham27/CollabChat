using CollabChatClient.MVVM.Core;
using CollabChatClient.MVVM.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CollabChatClient.MVVM.ViewModel
{
    class LoginViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public string Username { set; get; }
        public string Password { set; get; }
        private string _message;


        //
        public string Message { 
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        //
        public RelayCommand loginCommand { set; get; }

        //
        public LoginViewModel()
        {
            loginCommand = new RelayCommand(Login,
                o => !String.IsNullOrEmpty(Username) && !String.IsNullOrEmpty(Password));
        }

        //
        private void Login(object parameter)
        {               
            string message = "";
            _server.ConnectToServer(Username, Password, ref message);
            _message = message;
            //throw new Exception(_message);
            if (_message == "Login Success")
            {
                HomeWindow homeWindow = new HomeWindow();
                homeWindow.Show();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
