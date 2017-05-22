using System;
using System.Text.RegularExpressions;

namespace ValidationEngineTests
{
    internal class Validator
    {
        internal bool ValidateEmailAddress(string email)
        {
            string dotString = "";
            if (email != string.Empty)
            {

                if (email.Contains("@"))
                {
                    string[] chunks = email.Split('@');
                    int indexOfDot = chunks[1].IndexOf('.'); // index of the . in the second part of the email address (after the at symbol)

                    // if theres no . (eg. .com)
                    if (indexOfDot == -1)
                        return false;
                    dotString = chunks[1].Substring(indexOfDot); // eg. ".com" or ".se"
                }
                else // if email doesnt contain any @ symbol
                    throw new EmailContainsNoAtSymbolException();
            }

            // FILTERS 

            // check if mail is an empty string or null
            if (string.IsNullOrEmpty(email))
                throw new EmailIsNullOrEmptyException();

            // return false if mail contains no dotstring
            if (string.IsNullOrEmpty(dotString))
                return false;



            // return false if mail doesnt end with .com 
            if (dotString != ".com")
                return false;


            // return false if mail contains any digit
            for (int i = 0; i < 10; i++)
            {
                foreach (var character in email)
                {
                    if (character.ToString() == i.ToString())
                        return false;
                }
            }

            // if we come this far, email is valid
            return true;
        }

        //public bool ValidateEmailAddress(string email)
        //{
        //    Regex regex = new Regex(@"^([^.\d\-]+)@([^.\d\-]+)((\.(\D){2,3})+)$");
        //    var match = regex.Match(email);
        //    if (match.Success)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        throw new InvalidEmailException();
        //    }

        //}
    }
}