using CollabChatClient.MVVM.Core;
using CollabChatClient.MVVM.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CollabChatClient.MVVM.ViewModel

{
    public class RegisterViewModel: BaseViewModel
    {
        public string Username { set; get; }
        public string Password { set; get; }
        public string Email { set; get; }
        private string _message;


        //
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

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
            //throw new Exception(_message);
            if (message == "Register Success")
            {
                ((MainViewModel)Application.Current.MainWindow.DataContext).CurrentViewModel = new LoginViewModel();
            } else
            {
                Message = message;
            }
        }

    }
}
