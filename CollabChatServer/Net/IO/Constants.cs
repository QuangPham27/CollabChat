﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollabChatServer.Net.IO
{
    public class Constants
    {
        public const int loginOpCode = 1;
        public const int loginSuccessOpCode = 2;
        public const int loginFailureOpCode = 3;
        public const int registerOpCode = 4;
        public const int registerSuccessOpCode = 5;
        public const int registerFailureOpCode = 6;
    }
}
