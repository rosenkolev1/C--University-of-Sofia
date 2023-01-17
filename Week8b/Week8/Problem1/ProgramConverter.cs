using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public class ProgramConverter : IConvertible

    {
        #region Implementation of inteface IConvertible
 
        string IConvertible.ConvertToCSharp(string s)
        {
            return $"ProgramConverter:IConvertible.ConvertToCSharp=>{s}";
        }

        string IConvertible.ConvertToVB2015(string s)
        {
            return $"ProgramConverter:IConvertible.ConvertToVB2015=>{s}";
        }
        #endregion
 
    }
}
