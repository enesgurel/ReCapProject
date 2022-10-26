using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccesResult:Result
    {
        public SuccesResult(string Message):base(true, Message)
        {

        }

        public SuccesResult():base(true)
        {

        }
    }
}
