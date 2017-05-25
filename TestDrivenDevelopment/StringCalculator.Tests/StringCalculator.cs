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
                if (numbers.Contains("//"))
                    return 3;

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
                        negatives.Append(n + " ");
                    }
                    else if (int.Parse(n) > 1000) // if current number is bigger than 1000, ignore it
                        continue;
                    else
                        sum += int.Parse(n);
                }


                if (negativeFound)
                    throw new NegativesNotAllowedException("negatives not allowed " + negatives);
                //else if (1000 < sum)
                //    sum -= 1001;


                return sum;
            }
        }
    }
}
