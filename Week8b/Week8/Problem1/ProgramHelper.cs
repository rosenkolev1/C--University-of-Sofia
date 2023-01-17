using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public class ProgramHelper : IConvertible, ICodeChecker
    {

        #region Implementation of ICodeChecker
        bool ICodeChecker.CodeCheckSyntax(string s1, string s2)
        {
            return s1.Equals(s2);
        } 
        #endregion

        #region Implementation of inteface IConvertible
        public string ConvertToCSharp(string str)
        {
            return $"ProgramHelper:ConvertToCSharp=>{str}"; ;
        }


        string IConvertible.ConvertToCSharp(string s)
        {
            return $"ProgramHelper:IConvertible.ConvertToCSharp=>{s}";
        }

        string IConvertible.ConvertToVB2015(string s)
        {
            return $"ProgramHelper:IConvertible.ConvertToVB2015=>{s}";
        } 
        #endregion
    }
}
