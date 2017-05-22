using System;

namespace ValidationEngineTests
{
    internal class Validator
    {
        internal bool ValidateEmailAddress(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;
            return true;
        }
    }
}