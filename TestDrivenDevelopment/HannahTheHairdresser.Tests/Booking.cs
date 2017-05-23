using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HannahTheHairdresser.Tests
{
    public class Booking
    {
        public string Name { get; private set; }
        public DateTime When { get; private set; }
        public TimeSpan Duration { get; private set; }
        public Booking(string name, DateTime when, TimeSpan duration)
        {
            this.Name = name;
            this.When = when;
            this.Duration = duration;
        }
    }
}
