using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public class ProgramHelper :  ProgramConverter, IConvertible, ICodeChecker
    {
        #region ICodeChecker methods
        bool ICodeChecker.CodeCheckSyntax(string s1, string s2)
        {
            return s1.Equals(s2);
        }

        #endregion

        #region IConvertible methods

        string IConvertible.ConvertToCSharp(string s1)
        {
            return $"ProgramHelper:IConvertible.ConvertToCSharp: {s1}";
        }

        string IConvertible.ConvertToVB2015(string s1)
        {
            return $"ProgramHelper:IConvertible.ConvertToVB2015: {s1}";
        } 
        #endregion
    }
}
