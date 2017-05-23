using System;
using System.Collections.Generic;
using System.Linq;

namespace CoinChangerApplication.Tests
{
    internal class CoinChanger
    {
        private List<decimal> coinTypes;

        public CoinChanger(List<decimal> coinTypes)
        {
            this.coinTypes = coinTypes;
        }

        internal Dictionary<decimal, int> MakeChange(decimal turnMeIntoChangeAmount)
        {
            coinTypes = coinTypes.OrderByDescending(c => c).ToList();

            Dictionary<decimal, int> myChange = InitializeWithCointypes(coinTypes);

            foreach (var coinType in coinTypes)
            {
                if (turnMeIntoChangeAmount % coinType != 0)
                {
                    decimal rest = turnMeIntoChangeAmount % coinType;
                    decimal evenSum = turnMeIntoChangeAmount - rest;
                    decimal coinTypeCount = evenSum / coinType;
                    myChange[coinType] = (int)coinTypeCount;
                    turnMeIntoChangeAmount -= evenSum;
                }
                else
                {
                    if (turnMeIntoChangeAmount < 1)
                        myChange[coinType] = 1;
                    else
                        myChange[coinType] = (int)turnMeIntoChangeAmount;
                }
            }
            return myChange;
        }

        private Dictionary<decimal, int> InitializeWithCointypes(List<decimal> coinTypes)
        {
            Dictionary<decimal, int> myChange = new Dictionary<decimal, int>();

            foreach (var cointype in coinTypes)
            {
                myChange.Add(cointype, 0);
            }

            return myChange;

        }
    }
}