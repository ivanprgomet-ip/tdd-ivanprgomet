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
            if (numbers.Contains("[") && numbers.Contains("]"))
            {
                List<string> delims = ExtractFromString(numbers, numbers.IndexOf("[").ToString(), numbers.IndexOf("]").ToString());

                // we know the custom delimiter contains more chars
                int startIndex = numbers.IndexOf("[")+1;
                int endIndex = numbers.IndexOf("]");
                int customDelimiterLength = endIndex - startIndex;

                string customDelimiter = numbers.Substring(startIndex, customDelimiterLength);

                string[] nums = numbers.Split(new string[] { customDelimiter }, StringSplitOptions.None); // splitting by a string, and not a char!

                // remove ] to make it work
                for (int i = 0; i < nums.Length; i++)
                    nums[i] = nums[i].Replace("]", string.Empty);

                int sum = ExtractSum(nums);

                return sum;
            }
            else
            {

                // get the custom delimiter from the string
                int indexTwo = numbers.IndexOf("\n");// index of the first \n
                int customDelimiterLength = indexTwo - 2;
                string customDelimiter = numbers.Substring(2, customDelimiterLength); // 2 is the index where the custom delimiter starts

                string[] nums = numbers.Split(new string[] { customDelimiter }, StringSplitOptions.None); // splitting by a string, and not a char!

                int sum = ExtractSum(nums);

                return sum;
            }
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


        private static List<string> ExtractFromString(string text, string startString, string endString)
        {
            List<string> matched = new List<string>();
            int indexStart = 0, indexEnd = 0;
            bool exit = false;
            while (!exit)
            {
                indexStart = text.IndexOf(startString);
                indexEnd = text.IndexOf(endString);
                if (indexStart != -1 && indexEnd != -1)
                {
                    matched.Add(text.Substring(indexStart + startString.Length,
                        indexEnd - indexStart - startString.Length));
                    text = text.Substring(indexEnd + endString.Length);
                }
                else
                    exit = true;
            }
            return matched;
        }
    }
}
