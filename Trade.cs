using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_Simulator
{
    [Serializable]
    public class Trade
    {
        public string Exchange { get; set; }
        public string Symbol { get; set; }
        public string Timeframe { get; set; }
        public string Date { get; set; }
        public string TimeOfEntry { get; set; }
        public decimal EntryPrice { get; set; }
        public decimal Units { get; set; }
        public int Leverage { get; set; }
        public decimal Risk { get; set; }
        public decimal Stoploss { get; set; }
        public decimal TakeProfit { get; set; }
        public string TimeOfExit { get; set; }
        public decimal ExitPrice { get; set; }
        public string Result { get; set; }
        public decimal Balance { get; set; }
        public string Reasoning { get; set; }
        public bool IsValid { get; set; }

        public Trade()
        { 
            
        }
    }
}
