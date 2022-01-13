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
    public partial class PositionSizingWindow : Form
    {
        public PositionSizingWindow(decimal balance, decimal price, decimal lossPercent, decimal entryFee, decimal exitFee, int sigX, int stepSz, int rows, int ulev)
        {
            InitializeComponent();

            this.Text = "[ACC: $" + balance + ", AP: $" + price + ", L: " + lossPercent * 100 + "%]" + "   [SX: " + sigX + ", STP: " + stepSz + ", RWS: " + rows + "]";

            string formattedOutput = String.Empty;

            for (int i = 1; i <= rows; i++)
            {
                decimal tick = 0;

                switch (sigX)
                {
                    case -10:
                        tick = 0.0000000001M;
                        break;
                    case -9:
                        tick = 0.000000001M;
                        break;
                    case -8:
                        tick = 0.00000001M;
                        break;
                    case -7:
                        tick = 0.0000001M;
                        break;
                    case -6:
                        tick = 0.000001M;
                        break;
                    case -5:
                        tick = 0.00001M;
                        break;
                    case -4:
                        tick = 0.0001M;
                        break;
                    case -3:
                        tick = 0.001M;
                        break;
                    case -2:
                        tick = 0.01M;
                        break;
                    case -1:
                        tick = 0.1M;
                        break;
                    case 1:
                        tick = 1M;
                        break;
                    case 2:
                        tick = 10M;
                        break;
                    case 3:
                        tick = 100M;
                        break;
                    case 4:
                        tick = 1000M;
                        break;
                    case 5:
                        tick = 10000M;
                        break;
                    case 6:
                        tick = 100000M;
                        break;
                }

                decimal diff = tick * stepSz * i;

                // Send balance, price, losspercent, entryFee, exitFee, diff
                formattedOutput += "Stop: " + diff + ", Sz: " + GetPositionSize(balance, price, lossPercent, entryFee, exitFee, diff, ulev) + Environment.NewLine;
            }

            formattedOutput = formattedOutput.Trim();

            tbOutput.Text = formattedOutput;
        }

        public string GetPositionSize(decimal accountBalance, decimal assetPrice, decimal lossPercent, decimal entryFeePercent, decimal exitFeePercent, decimal priceDifference, int ulev)
        {
            // Solve for tradeAmount, return.

            // amountLost = entryFee + exitFee + tradeDevaluationAmount
            // amountLost = accountBalance * lossPercent
            // =>
            // accountBalance * lossPercent = entryFee + exitFee + tradeDevaluationAmount

            // entryFee = tradeAmount * entryFeePercent
            // exitFee = (tradeAmount + tradeAmount * (priceDifference / assetPrice)) * exitFeePercent
            // tradeDevaluationAmount = (tradeAmount * (priceDifference / assetPrice))
            // =>
            // accountBalance * lossPercent = tradeAmount * entryFeePercent + (tradeAmount + tradeAmount * priceDifference / assetPrice) * exitFeePercent + (tradeAmount * priceDifference / assetPrice)

            // (tradeAmount / assetPrice) * priceDifference, 

            // a = accountBalance
            // b = lossPercent
            // c = priceDifference
            // d = assetPrice
            // e = exitFeePercent
            // f = entryFeePercent
            // x = tradeAmount

            // a * b = (x * f) + ((x + x * c / d) * e) + (x * c / d)

            // Solve for x...

            // x = (a * b * d) / ((c * e) + c + (d * e) + (d * f))

            // tradeAmount = (accountBalance * lossPercent * assetPrice) / (priceDifference * exitFeePercent + priceDifference + assetPrice * exitFeePercent + assetPrice * entryFeePercent)

            decimal tradeAmount = (accountBalance * lossPercent * assetPrice) / (priceDifference * exitFeePercent + priceDifference + assetPrice * exitFeePercent + assetPrice * entryFeePercent);

            decimal positionSize = tradeAmount / ulev;

            return decimal.Round(positionSize, 0).ToString();
        }
    }
}
