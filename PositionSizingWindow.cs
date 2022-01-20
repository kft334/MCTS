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
        public List<Tuple<decimal, decimal>> SizingTuples = new List<Tuple<decimal, decimal>>();

        public PositionSizingWindow(decimal balance, decimal price, decimal lossPercent, decimal entryFee, decimal exitFee, int sigX, int stepSz, int rows, int ulev)
        {
            InitializeComponent();

            this.Text = "Position Sizing";

            string formattedOutput = String.Empty;

            formattedOutput += "[ Bal: $" + (balance / ulev) + " ] [ ~Asset $: $" + price + " ] [ Loss: " + lossPercent * 100 + "% ] [ SIGX: " + sigX + " ] [ XSTEP: " + stepSz + " ]" + Environment.NewLine + Environment.NewLine;

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

                SizingTuples.Add(new Tuple<decimal, decimal>(diff, GetPositionSize(balance, price, lossPercent, entryFee, exitFee, diff, ulev)));

                formattedOutput += "Stop: " + diff + ", Units: " + GetPositionSize(balance, price, lossPercent, entryFee, exitFee, diff, ulev) + ", ACC%: " + GetPositionSizeAccountPercentage(balance, price, lossPercent, entryFee, exitFee, diff, ulev) + Environment.NewLine;
            }

            formattedOutput = formattedOutput.Trim();

            tbOutput.Text = formattedOutput;
        }

        public decimal GetPositionSize(decimal accountBalance, decimal assetPrice, decimal lossPercent, decimal entryFeePercent, decimal exitFeePercent, decimal priceDifference, int ulev)
        {
            decimal tradeAmount = (accountBalance * lossPercent - exitFeePercent * priceDifference * ulev) / (ulev * (entryFeePercent + exitFeePercent + priceDifference));

            return decimal.Round(tradeAmount / assetPrice, 2);
        }

        public decimal GetPositionSizeAccountPercentage(decimal accountBalance, decimal assetPrice, decimal lossPercent, decimal entryFeePercent, decimal exitFeePercent, decimal priceDifference, int ulev)
        {
            decimal tradeAmount = (accountBalance * lossPercent - exitFeePercent * priceDifference * ulev) / (ulev * (entryFeePercent + exitFeePercent + priceDifference));

            return decimal.Round((tradeAmount / accountBalance * 100), 2);
        }
    }
}
