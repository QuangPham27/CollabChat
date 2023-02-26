using System;
using System.Collections.Generic;

namespace Database.DataAccess
{
    public partial class File
    {
        public int FileId { get; set; }
        public int MessageId { get; set; }
        public string MessageUrl { get; set; }

        public virtual Message Message { get; set; }
    }
}
