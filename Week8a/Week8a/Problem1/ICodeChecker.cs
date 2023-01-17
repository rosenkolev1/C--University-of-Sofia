using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public interface ICodeChecker:IConvertible
    {
        bool CodeCheckSyntax(string s1, string s2);
 
    }
}
