using System;

namespace ValidationEngineTests
{
    internal class Validator
    {
        internal bool ValidateEmailAddress(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;
            if (!email.Contains("@"))
                return false;
            return true;
        }
    }
}