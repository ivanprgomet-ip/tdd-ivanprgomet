using System;
using System.Text.RegularExpressions;

namespace ValidationEngine
{
    public class Validator
    {
        public bool ValidateEmailAddress(string email)
        {
            string dotString = "";
            if (!string.IsNullOrEmpty(email))
            {

                if (email.Contains("@"))
                {
                    string[] chunks = email.Split('@');

                    // check if first chunk contains a dot (which it shouldn)
                    foreach (var character in chunks[0])
                    {
                        if (character == '.')
                            throw new EmailContainingDotInFirstPartOfAddressException();
                    }

                    int indexOfDot = chunks[1].IndexOf('.'); // index of the . in the second part of the email address (after the at symbol)

                    // return false if mail contains no dotstring (eg. .com)
                    if (indexOfDot == -1)
                        throw new EmailContainsNoDotStringException();
                    dotString = chunks[1].Substring(indexOfDot); // eg. ".com" or ".se"
                }
                else // if email doesnt contain any @ symbol
                    throw new EmailContainsNoAtSymbolException();
            }

            // check if mail is an empty string or null
            if (string.IsNullOrEmpty(email))
                throw new EmailIsNullOrEmptyException();

            // return false if mail contains any digit
            for (int i = 0; i < 10; i++)
            {
                foreach (var character in email)
                {
                    if (character.ToString() == i.ToString())
                        throw new EmailContainingDigitsException();
                }
            }

            // if we come this far, email is valid
            return true;
        }
    }
}