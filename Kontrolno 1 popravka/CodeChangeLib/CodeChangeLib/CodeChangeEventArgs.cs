using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace CodeChangeLib
{
    public class CodeChangeEventArgs : EventArgs
    {
        public List<string> Code { get; }

        public CodeChangeEventArgs(List<string> code)
        {
            this.Code = code;
        }
    }
}
