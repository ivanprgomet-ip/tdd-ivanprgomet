using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.ConsoleGui
{
    public class TourAllocationException : Exception
    {
        public DateTime? _suggestedTime { get; set; }

        public TourAllocationException()
        {

        }
        public TourAllocationException(DateTime? suggestedTime)
        {
            this._suggestedTime = suggestedTime;
        }
    }

    public class TourWithIdenticalNameFoundException: Exception
    {
        public TourWithIdenticalNameFoundException(string msg):base(msg)
        {

        }
    }

    public class InvalidSeatAmountException : Exception
    {
        public InvalidSeatAmountException(string msg) : base(msg)
        {

        }
    }

    public class NoToursFoundForDateException : Exception
    {
        public NoToursFoundForDateException(string msg) : base(msg)
        {

        }
    }
    public class TourDoesntExistException:Exception
    {

    }
}
