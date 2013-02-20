using System.Collections.Generic;
using mips_syntax.Entities;

namespace mips_syntax.utils
{
    internal interface IMipsValidator
    {
        Response IsSyntaxValid(List<string> args);
    }
}