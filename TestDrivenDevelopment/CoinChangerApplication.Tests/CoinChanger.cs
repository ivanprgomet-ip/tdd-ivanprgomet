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
            // sort first
            coinTypes = coinTypes.OrderByDescending(c => c).ToList();

            // initialize result dictionary 
            Dictionary<decimal, int> myChange = InitializeWithCointypes(coinTypes);
            
            foreach (var coinType in coinTypes)
            {
                if(turnMeIntoChangeAmount % coinType != 0)
                {
                    // eg. turnmeintochangeamount = 14, cointype = 5
                    decimal rest = turnMeIntoChangeAmount % coinType;  // rest = 4
                    decimal evenSum = turnMeIntoChangeAmount - rest; // evenSum = 10
                    decimal coinTypeCount = evenSum / coinType; // coinTypeCount = 2
                    myChange[coinType] = (int)coinTypeCount; // 2 5's
                    turnMeIntoChangeAmount -= evenSum; // 14-10 = 4 (update how much is left of the turnMeIntoChangeAmount)
                }
                else
                {
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