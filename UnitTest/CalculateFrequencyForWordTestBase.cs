using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class CalculateFrequencyForWordTestBase
    {
        protected Func<string, List<string>> textPrepareForFrpcessingFunction = (text) => text.ToLower().Split(new Char[] { ' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
    }
}
