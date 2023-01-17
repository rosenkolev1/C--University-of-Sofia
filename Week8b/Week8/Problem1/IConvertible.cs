using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public interface IConvertible
    {
        string ConvertToCSharp(string s);
        string ConvertToVB2015(string s);
    }
}
