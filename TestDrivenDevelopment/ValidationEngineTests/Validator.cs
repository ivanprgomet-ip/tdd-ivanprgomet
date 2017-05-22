using System;

namespace ValidationEngineTests
{
    internal class Validator
    {
        internal bool ValidateEmailAddress(string email)
        {
            string[] chunks = email.Split('@');

            if (string.IsNullOrEmpty(email))
                return false;
            if (!email.Contains("@"))
                return false;

            // returns dotstring that should be .com or .se
            int indexOfDot = chunks[1].IndexOf('.'); // index of the . in the second part of the email address (after the at symbol)
            string dotString = chunks[1].Substring(indexOfDot); // eg. ".com" or ".se"
            if (dotString != ".com")
                return false;
            if (dotString != ".se")
                return false;


            return true;
        }
    }
}