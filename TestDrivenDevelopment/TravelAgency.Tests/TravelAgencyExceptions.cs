using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Tests
{
    class TourAllocationException : Exception
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

    class TourWithIdenticalNameFoundException: Exception
    {
        public TourWithIdenticalNameFoundException(string msg):base(msg)
        {

        }
    }

    class InvalidSeatAmountException : Exception
    {
        public InvalidSeatAmountException(string msg) : base(msg)
        {

        }
    }
}
