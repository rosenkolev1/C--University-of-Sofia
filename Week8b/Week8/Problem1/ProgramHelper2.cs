using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public class ProgramHelper2:ProgramConverter, ICodeChecker
    {

        #region Implementation of inteface IConvertible
        bool ICodeChecker.CodeCheckSyntax(string s1, string s2)
        {
            return s1.Equals(s2);
        }
        string IConvertible.ConvertToCSharp(string s)
        {
            return $"ProgramHelper2:IConvertible.ConvertToCSharp=>{s}";
        }
        string IConvertible.ConvertToVB2015(string s)
        {
            return $"ProgramHelper2:IConvertible.ConvertToVB2015=>{s}";
        }
        #endregion
    }
}
