using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEFCode.Utilities
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public string ValidationMessage { get; set; }

        public OperationResult()
        {
            ValidationMessage = "";
            Success = false;
        }

    }
}
