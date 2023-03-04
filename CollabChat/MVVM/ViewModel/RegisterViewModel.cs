using CollabChatClient.MVVM.Core;
using CollabChatClient.MVVM.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollabChatClient.MVVM.ViewModel

{
    class RegisterViewModel: BaseViewModel, INotifyPropertyChanged
    {
        public string Username { set; get; }
        public string Password { set; get; }
        public string Email { set; get; }
        private string _message;

        public RelayCommand registerCommand { set; get; }

        //
        public RegisterViewModel()
        {
            registerCommand = new RelayCommand(Register,
                o => !String.IsNullOrEmpty(Username) && !String.IsNullOrEmpty(Password) && !String.IsNullOrEmpty(Email));
            
        }

        private void Register(object parameter)
        {
            string message = "";
            _server.Register(Username, Password, Email, ref message);
            _message = message;
            //throw new Exception(_message);
            if (_message == "Register Success")
            {
                LoginWindow loginwindow = new LoginWindow();
                loginwindow.Show();
            }
        }

        

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
