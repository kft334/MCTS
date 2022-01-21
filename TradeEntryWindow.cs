using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trade_Simulator
{
    public partial class TradeEntryWindow : Form
    {
        public Trade TradeResult { get; set; }

        public TradeEntryWindow(string exchange, string symbol, string timeframe, int leverage, decimal risk)
        {
            InitializeComponent();

            tbExchange.Text = exchange;
            tbSymbol.Text = symbol;
            tbTimeframe.Text = timeframe;
            
            if (leverage != 0)
                tbLeverage.Text = leverage.ToString();
            if (risk != 0)
                tbRisk.Text = risk.ToString();

            tbDate.Value = DateTime.Now;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            TradeResult = new Trade();

            try
            {
                TradeResult.Exchange = tbExchange.Text;
                TradeResult.Symbol = tbSymbol.Text;
                TradeResult.Timeframe = tbTimeframe.Text;
                TradeResult.Date = tbDate.Text;
                TradeResult.TimeOfEntry = tbTimeOfEntry.Text;
                TradeResult.Direction = cbDirection.Text;
                TradeResult.EntryPrice = decimal.Parse(tbEntryPrice.Text);
                TradeResult.Units = decimal.Parse(tbUnits.Text);
                TradeResult.Leverage = int.Parse(tbLeverage.Text);
                TradeResult.Risk = decimal.Parse(tbRisk.Text);
                TradeResult.Stoploss = decimal.Parse(tbStoploss.Text);
                TradeResult.TakeProfit = decimal.Parse(tbTakeProfit.Text);
                TradeResult.TimeOfExit = tbTimeOfExit.Text;
                if (cbResult.Text != String.Empty)
                    TradeResult.Result = cbResult.Text;
                else
                    throw new Exception();
                TradeResult.Balance = decimal.Parse(tbBalance.Text);
                TradeResult.Reasoning = tbReasoning.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please check the inputs.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            TradeResult = null;
            this.Close();
        }
    }
}
