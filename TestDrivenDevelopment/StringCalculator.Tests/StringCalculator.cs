﻿using System;
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
                foreach (var n in nums)
                {
                    if (int.Parse(n) < 0)
                        throw new NegativesNotAllowedException("Negatives not allowed in computation!");

                    sum += int.Parse(n);
                }

                return sum;
            }
        }
    }
}
