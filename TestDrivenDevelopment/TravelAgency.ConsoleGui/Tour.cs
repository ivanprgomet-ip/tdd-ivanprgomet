using System;

namespace TravelAgency.ConsoleGui
{
    public class Tour
    {
        public string Name { get; set; }
        public DateTime When { get; set; }
        public int AvailableSeats { get; set; }

        /// <summary>
        /// when we need to compare tour objects
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Tour other)
        {
            if (Name == other.Name && When == other.When && AvailableSeats == other.AvailableSeats)
                return true;
            else
                return false;
        }
    }
}