using System;

namespace HannahTheHairdresser.Tests
{
    internal class OverlappingBookingException : Exception
    {
        public DateTime? SuggestedTime { get; private set; }
        public OverlappingBookingException(DateTime? suggestedTime)
        {
            this.SuggestedTime = suggestedTime;
        }

    }
}