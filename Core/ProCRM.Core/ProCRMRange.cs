using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCRM.Core
{
    internal class ProCRMRange
    {
        public int[] Range { get; set; }

        public static implicit operator ProCRMRange(int[] range)
        {
            return new ProCRMRange() { Range = range };
        }

        public static explicit operator int[](ProCRMRange ProCRMRange)
        {
            return ProCRMRange.Range;
        }

        public int Start() => Range.Length == 0 ? 0 : Range[0];
        public int End() => Range.Length == 0 ? 0 : Range[Range.Length - 1];
    }
}
