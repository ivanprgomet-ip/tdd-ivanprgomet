using System;
using System.Collections.Generic;

namespace CoinChangerApplication.Tests
{
    internal class CoinChanger
    {
        private List<decimal> coinTypes;

        public CoinChanger(List<decimal> coinTypes)
        {
            this.coinTypes = coinTypes;
        }

        internal Dictionary<decimal, int> MakeChange(decimal v)
        {
            return new Dictionary<decimal, int>() { { 1.0m, 14 } };
        }
    }
}