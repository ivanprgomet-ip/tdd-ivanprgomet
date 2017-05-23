using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            /// Sample error cases:
            ///     [x] Null or empty string
            ///     [x] Test.com
            ///     [x] name@test
            ///     [x] name.test@com
            ///     [x] Name2015@test.com
            ///     [x] name@test2015.com
            /// Valid email examples:
            ///     [x] mike@edument.se
            ///     [x] joe@apple.com


             Validator v = new Validator();

            Console.WriteLine("Enter Email Address to validate it!");
            string email = Console.ReadLine();
            if (v.ValidateEmailAddress(email))
                Console.WriteLine("Success");
            else
                Console.WriteLine("Validation failed");
        }
    }
}
