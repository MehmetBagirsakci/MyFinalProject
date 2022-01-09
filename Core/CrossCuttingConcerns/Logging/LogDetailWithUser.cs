using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Logging
{
    public class LogDetailWithUser : LogDetail
    {
        public string UserId { get; set; }
    }
}
