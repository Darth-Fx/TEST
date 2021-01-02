using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTest
{
    public class CalculateFrequencyForWordTestBase
    {
        protected Func<string, List<string>> textPrepareForFrpcessingFunction = (text) => text.ToLower().Split(new Char[] { ' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
    }
}
