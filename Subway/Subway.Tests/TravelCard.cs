using System;

namespace Subway.Tests
{
    internal class TravelCard
    {
        private int v;
        public decimal TravelBalance;

        public TravelCard(int v)
        {
            this.v = v;
        }

        internal void TouchIn()
        {
            throw new NotImplementedException();
        }
    }
}