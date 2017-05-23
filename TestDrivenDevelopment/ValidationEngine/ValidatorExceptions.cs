using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationEngine
{
    public class InvalidEmailException:Exception
    {

    }
    public class EmailContainingDigitsException : Exception
    {

    }
    public class EmailIsNullOrEmptyException : Exception
    {

    }

    public class EmailContainingDotInFirstPartOfAddressException : Exception
    {

    }

    public class EmailContainsNoAtSymbolException : Exception
    {

    }

    public class EmailContainsNoDotStringException : Exception
    {

    }
}
