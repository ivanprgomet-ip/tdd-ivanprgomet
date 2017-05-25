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
                    return CalculateSumWithCustomDelimiter(numbers);
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

        private int CalculateSumWithCustomDelimiter(string numbers)
        {
            // get the custom delimiter from the string
            int indexTwo = numbers.IndexOf("\n");// index of the first \n
            int customDelimiterLength = indexTwo - 2;
            string customDelimiter = numbers.Substring(2, customDelimiterLength); // 2 is the index where the custom delimiter starts

            string[] nums = numbers.Split(new string[] { customDelimiter }, StringSplitOptions.None); // splitting by a string, and not a char!

            int sum = ExtractSum(nums);

            return sum;
        }

        private int ExtractSum(string[] nums)
        {
            int sum = 0;
            foreach (var num in nums)
            {
                int n;
                bool isNumeric = int.TryParse(num, out n);

                if (isNumeric)
                    sum += n;

            }
            return sum;
        }
    }
}
