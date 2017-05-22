using System;

namespace Subway.Tests
{
    internal class TravelCard
    {
        public int TravelBalance;
        private bool touchedIn;

        public TravelCard(int balance)
        {
            this.TravelBalance = balance;
        }

        public void TouchIn()
        {
            if (touchedIn)
                throw new AlreadyTouchedInException();
            touchedIn = true;
        }

        internal void TouchOut()
        {
            touchedIn = false;
            TravelBalance--;
        }
    }
}