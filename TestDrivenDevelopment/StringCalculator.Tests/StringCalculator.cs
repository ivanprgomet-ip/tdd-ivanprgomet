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
                char[] tokens = new char[] { ',', '\n' };
                string[] nums = numbers.Split(tokens);

                int sum = 0;
                bool negativeFound = false;
                StringBuilder negatives = new StringBuilder();
                foreach (var n in nums)
                {
                    if (int.Parse(n) < 0)
                    {
                        negativeFound = true;
                        negatives.Append(n+" ");
                    }

                    sum += int.Parse(n);
                }


                if(negativeFound)
                    throw new NegativesNotAllowedException("negatives not allowed "+negatives);

                return sum;
            }
        }
    }
}
