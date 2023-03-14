using CollabChatClient.MVVM.Core;
using CollabChatClient.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CollabChatClient.MVVM.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public string Username { set; get; }
        public string Password { set; get; }
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
        public RelayCommand loginCommand { set; get; }
        public RelayCommand registerCommand { set; get; }
        public LoginViewModel()
        {
            loginCommand = new RelayCommand(Login,
                o => !String.IsNullOrEmpty(Username) && !String.IsNullOrEmpty(Password));
            registerCommand = new RelayCommand(RegisterNavigate, o => true);
        }
        private void Login(object parameter)
        {
            string message = "";
            _server.ConnectToServer(Username, Password, ref message);
            //throw new Exception(_message);
            if (message == "Login Success")
            {
                ((MainViewModel)Application.Current.MainWindow.DataContext).CurrentViewModel = new HomeViewModel();
            }
            else
            {
                Message = message;
            }
        }
        private void RegisterNavigate(object parameter)
        {
            ((MainViewModel)Application.Current.MainWindow.DataContext).CurrentViewModel = new RegisterViewModel();
        }
    }
}
