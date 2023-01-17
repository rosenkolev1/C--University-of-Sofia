using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public class ProgramConverter : IConvertible
    {
        string IConvertible.ConvertToCSharp(string s1)
        {
            return $"ProgramConverter:IConvertible.ConvertToCSharp: {s1}";
        }

        string IConvertible.ConvertToVB2015(string s1)
        {
            return $"ProgramConverter:IConvertible.ConvertToVB2015: {s1}";
        }
    }
}
