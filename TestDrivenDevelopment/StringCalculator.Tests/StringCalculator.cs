using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator.Tests
{
    class StringCalculator
    {
        internal int Add(string numbers)
        {
            if (numbers == string.Empty)
                return 0;
            else
            {
                char[] tokens = new char[] { ',' };
                string[] nums = numbers.Split(tokens);

                int sum = 0;
                foreach (var n in nums)
                {
                    sum += int.Parse(n);
                }

                return sum;
            }
        }
    }
}
