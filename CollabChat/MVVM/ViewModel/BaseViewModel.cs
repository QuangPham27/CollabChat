using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollabChatClient.MVVM.ViewModel
{
    class BaseViewModel
    {
        protected Server _server;
        public BaseViewModel()
        {
            _server = new Server();
        }
    }
}
