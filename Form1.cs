using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trade_Simulator
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        Random slRand = new Random();

        List<Tuple<decimal, string>> logAxes = new List<Tuple<decimal, string>>();

        double[] positions;
        string[] labels;

        ScottPlot.Plot plot;

        public Form1()
        {
            InitializeComponent();

            if (File.Exists("State.bin"))
            {
                using (FileStream fs = new FileStream("State.bin", FileMode.Open))
                {
                    BinaryFormatter debf = new BinaryFormatter();
                    FormState state = (FormState)debf.Deserialize(fs);

                    tbAssetBasePrice.Text = state.SIMAssetPrice;
                    tbRiskPerTrade.Text = state.SIMPercentAccountPerTrade;
                    tbWinRate.Text = state.SIMWinRate;
                    tbStopLoss.Text = state.SIMStoploss;
                    tbStopLoss2.Text = state.SIMStoploss2;
                    tbRR.Text = state.SIMRR;
                    tbNumberOfTrades.Text = state.SIMTrades;
                    tbLeverage.Text = state.SIMLeverage;
                    tbFeesPerOrderEnt.Text = state.SIMEntryFee;
                    tbFeesPerOrderExit.Text = state.SIMExitFee;
                    tbOrderCap.Text = state.SIMOrderCap;
                    tbEntriesPerHour.Text = state.SIMEntriesPerHour;
                    tbHoursPerDay.Text = state.SIMTradingHoursPerDay;
                    cbLog.Checked = state.SIMLogarithmic;
                    numSimCount.Value = state.SIMIterations;

                    tbPSTablePrice.Text = state.PSTPrice;
                    tbPSTableULev.Text = state.PSTLeverage;
                    tbPSTableLoss.Text = state.PSTRisk;
                    tbPSTableFeeEntry.Text = state.PSTEntryFee;
                    tbPSTableFeeExit.Text = state.PSTExitFee;
                    nudPSTableSigX.Value = state.PSTSigX;
                    nudPSTableStepSize.Value = state.PSTXStep;
                    nudPSTableRows.Value = state.PSTRows;

                    tbPricePL.Text = state.PLPrice;
                    tbRiskPL.Text = state.PLUnits;
                    tbRRPL.Text = state.PLRR;
                    tbLevPL.Text = state.PLLeverage;
                    tbFeePLEnt.Text = state.PLEntryFee;
                    tbFeePLExit.Text = state.PLExitFee;
                    tbSLDiff.Text = state.PLStoploss;

                    tbRate.Text = state.CMPRateOfReturn;
                    tbT.Text = state.CMPNumberOfCompounds;

                    tbGBEAssetPrice.Text = state.BEPrice;
                    tbGBEFeeEntry.Text = state.BEEntryFee;
                    tbGBEFeeExit.Text = state.BEExitFee;

                    cbPlotEquityLog.Checked = state.PEQLogarithmic;
                }
            }
            

            if (!File.Exists("Trades.bin"))
            {
                using (FileStream fs = new FileStream("Trades.bin", FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, new List<Trade>());
                }
            }

            List<decimal> bPt = new List<decimal>();

            if (!File.Exists("Equity.dat"))
            {
                using (StreamWriter sw = new StreamWriter("Equity.dat"))
                {
                    sw.Write(0);
                }
            }

            using (StreamReader sr = new StreamReader("Equity.dat"))
            {
                while (!sr.EndOfStream)
                {
                    bPt.Add(decimal.Parse(sr.ReadLine()));
                }
            }

            decimal currentBalance = bPt[bPt.Count - 1];

            tbStartingBalance.Text = currentBalance.ToString();
            tbPLBalance.Text = currentBalance.ToString();
            tbPrincipal.Text = currentBalance.ToString();
            tbPSTableBalance.Text = currentBalance.ToString();

            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(1), "1"));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(2), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(3), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(4), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(5), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(6), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(7), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(8), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(9), null));

            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(10), "10"));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(20), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(30), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(40), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(50), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(60), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(70), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(80), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(90), null));

            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(100), "100"));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(200), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(300), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(400), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(500), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(600), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(700), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(800), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(900), null));

            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(1000), "1,000"));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(2000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(3000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(4000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(5000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(6000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(7000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(8000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(9000), null));

            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(10000), "10,000"));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(20000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(30000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(40000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(50000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(60000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(70000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(80000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(90000), null));

            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(100000), "100,000"));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(200000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(300000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(400000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(500000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(600000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(700000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(800000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(900000), null));

            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(1000000), "1,000,000"));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(2000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(3000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(4000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(5000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(6000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(7000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(8000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(9000000), null));

            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(10000000), "10,000,000"));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(20000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(30000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(40000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(50000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(60000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(70000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(80000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(90000000), null));

            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(100000000), "100,000,000"));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(200000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(300000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(400000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(500000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(600000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(700000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(800000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(900000000), null));

            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(1000000000), "1,000,000,000"));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(2000000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(3000000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(4000000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(5000000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(6000000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(7000000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(8000000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(9000000000), null));

            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(10000000000), "10,000,000,000"));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(20000000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(30000000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(40000000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(50000000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(60000000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(70000000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(80000000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(90000000000), null));

            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(100000000000), "100,000,000,000"));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(200000000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(300000000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(400000000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(500000000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(600000000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(700000000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(800000000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(900000000000), null));

            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(1000000000000), "1,000,000,000,000"));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(2000000000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(3000000000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(4000000000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(5000000000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(6000000000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(7000000000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(8000000000000), null));
            logAxes.Add(new Tuple<decimal, string>((decimal)Math.Log10(9000000000000), null));

            positions = logAxes.Select(i => (double)i.Item1).ToArray();
            labels = logAxes.Select(i => i.Item2).ToArray();
        }

        static string logTickLabels(double y) => Math.Pow(10, y).ToString("N0");

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                panelGraph.BackgroundImage = null;

                plot = new ScottPlot.Plot();

                decimal assetBasePrice = decimal.Parse(tbAssetBasePrice.Text);

                // TODO: Implement slippage

                decimal startingBalance = decimal.Parse(tbStartingBalance.Text);
                decimal riskPercentPerTrade = decimal.Parse(tbRiskPerTrade.Text) / 100;
                decimal winRate = decimal.Parse(tbWinRate.Text);

                decimal sLPercentMin = decimal.Parse(tbStopLoss.Text) / 100;
                decimal sLPercentMax = decimal.Parse(tbStopLoss2.Text) / 100;

                decimal rR = decimal.Parse(tbRR.Text);

                int numberOfTrades = int.Parse(tbNumberOfTrades.Text);
                int leverage = int.Parse(tbLeverage.Text);
                decimal feePerTradeEntry = decimal.Parse(tbFeesPerOrderEnt.Text) / 100;
                decimal feePerTradeExit = decimal.Parse(tbFeesPerOrderExit.Text) / 100;

                decimal entriesPerHour = decimal.Parse(tbEntriesPerHour.Text);
                decimal hoursPerDay = decimal.Parse(tbHoursPerDay.Text);
                decimal entriesPerDay = entriesPerHour * hoursPerDay;
                decimal daysToComplete = decimal.Round((decimal)numberOfTrades / entriesPerDay, 1);

                int cap = int.Parse(tbOrderCap.Text);

                decimal currentBalance = startingBalance;
                decimal totalFees = 0;
                decimal totalCurrencyWon = 0;
                decimal totalCurrencyLost = 0;
                int totalTradesWon = 0;
                int totalTradesLost = 0;

                decimal max = startingBalance;
                decimal maxDrawdown = 0;

                decimal minimumBalance = startingBalance;
                decimal maximumBalance = startingBalance;

                Random rand = new Random();

                Tuple<decimal, decimal> lastPt = new Tuple<decimal, decimal>(0, startingBalance);

                int consWins = 0;
                int maxConsWins = 0;
                int consLosses = 0;
                int maxConsLosses = 0;

                int capReachedOnTrade = 0;
                bool capReached = false;

                for (int i = 0; i < numberOfTrades; i++)
                {
                    decimal tradeAmount = currentBalance * riskPercentPerTrade;

                    if (tradeAmount > cap)
                    {
                        tradeAmount = cap;

                        if (!capReached)
                        {
                            capReached = true;
                            capReachedOnTrade = i + 1;
                        }
                    }

                    decimal leveragedAmount = tradeAmount * leverage;

                    decimal entryFee = leveragedAmount * feePerTradeEntry;
                    totalFees += entryFee;
                    currentBalance -= entryFee;

                    int chance = rand.Next(0, 100) + 1;

                    decimal slRandomized = (decimal)slRand.Next((int)(sLPercentMin * 10000), (int)(sLPercentMax * 10000 + 1)) / (decimal)10000;
                    decimal tpRandomized = slRandomized * rR;

                    if (chance <= winRate)
                    {
                        decimal assetNewValue = assetBasePrice + assetBasePrice * tpRandomized;

                        totalTradesWon += 1;
                        consWins += 1;
                        consLosses = 0;
                        if (consWins > maxConsWins)
                            maxConsWins = consWins;

                        decimal exitFee = (leveragedAmount + leveragedAmount * tpRandomized) * feePerTradeExit;
                        totalFees += exitFee;
                        currentBalance -= exitFee;

                        decimal balanceChange = (assetNewValue - assetBasePrice) * leveragedAmount;

                        currentBalance += balanceChange;
                        totalCurrencyWon += balanceChange;

                        max = currentBalance > max ? currentBalance : max;
                    }
                    else
                    {
                        decimal assetNewValue = assetBasePrice - assetBasePrice * slRandomized;

                        totalTradesLost += 1;
                        consLosses += 1;
                        consWins = 0;
                        if (consLosses > maxConsLosses)
                            maxConsLosses = consLosses;

                        decimal exitFee = (leveragedAmount - leveragedAmount * slRandomized) * feePerTradeExit;
                        totalFees += exitFee;
                        currentBalance -= exitFee;

                        decimal balanceChange = (assetBasePrice - assetNewValue) * leveragedAmount;

                        currentBalance -= balanceChange;
                        totalCurrencyLost -= balanceChange;

                        maxDrawdown = 1 - (currentBalance / max) > maxDrawdown ? 1 - (currentBalance / max) : maxDrawdown;
                    }

                    if (cbLog.Checked)
                        plot.AddLine((double)lastPt.Item1, Math.Log10((double)lastPt.Item2), i + 1, Math.Log10((double)currentBalance));
                    else
                        plot.AddLine((double)lastPt.Item1, (double)lastPt.Item2, i + 1, (double)currentBalance);

                    if (minimumBalance > currentBalance)
                        minimumBalance = currentBalance;
                    if (maximumBalance < currentBalance)
                        maximumBalance = currentBalance;

                    lastPt = new Tuple<decimal, decimal>(i + 1, currentBalance);
                }

                tbWins.Text = totalTradesWon.ToString();
                tbLosses.Text = totalTradesLost.ToString();
                tbWon.Text = "$" + decimal.Round(totalCurrencyWon, 0).ToString();
                tbLost.Text = "$" + decimal.Round(totalCurrencyLost * -1, 0).ToString();
                tbFeesPaid.Text = "$" + decimal.Round(totalFees, 0).ToString();

                if (currentBalance - startingBalance > 0)
                    tbProfitsLosses.Text = "$" + decimal.Round((currentBalance - startingBalance), 0).ToString();
                else
                    tbProfitsLosses.Text = "-$" + decimal.Round((currentBalance - startingBalance) * -1, 0).ToString();

                tbBalance.Text = "$" + decimal.Round(currentBalance, 0).ToString();
                tbMaxDrawdown.Text = (decimal.Round(maxDrawdown * 100, 2)).ToString() + "%";
                tbConsWins.Text = maxConsWins.ToString();
                tbConsLosses.Text = maxConsLosses.ToString();
                tbCapReached.Text = capReached ? "Trade # " + capReachedOnTrade.ToString() : "Not reached";
                tbDaysToComplete.Text = daysToComplete.ToString();

                int minL = decimal.Floor(minimumBalance).ToString().Count();
                int maxL = decimal.Ceiling(maximumBalance).ToString().Count() + 1;

                if (cbLog.Checked)
                {
                    plot.YAxis.ManualTickPositions(positions, labels);

                    plot.Title($"Equity Curve");
                    plot.Grid(true, Color.FromArgb(90, Color.Black), ScottPlot.LineStyle.Dash);
                    plot.XAxis.MinimumTickSpacing(1);
                    plot.XLabel("Trade #");
                    plot.YLabel("Equity");

                    plot.SetAxisLimitsY(Math.Log10(Math.Pow(10, minL - 1)), Math.Log10(Math.Pow(10, maxL - 1)));
                }
                else
                {
                    plot.Title($"Equity Curve");
                    plot.YAxis.TickDensity(3);
                    plot.XAxis.TickDensity(2);
                    plot.XAxis.MinimumTickSpacing(1);
                    plot.Grid(true, Color.FromArgb(90, Color.Black), ScottPlot.LineStyle.Dash);
                    plot.XLabel("Trade #");
                    plot.YLabel("Equity");
                    plot.AxisAuto();
                }

                panelGraph.BackgroundImage = new Bitmap(plot.Render(panelGraph.Width, panelGraph.Height));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please check the inputs.");
            }
        }

        private void btnGetBreakEvenWin_Click(object sender, EventArgs e)
        {
            try
            {
                decimal assetBasePrice = decimal.Parse(tbGBEAssetPrice.Text);
                decimal feePerTradeEntry = decimal.Parse(tbGBEFeeEntry.Text) / 100;
                decimal feePerTradeExit = decimal.Parse(tbGBEFeeExit.Text) / 100;

                decimal exitPrice = -((1 + feePerTradeEntry) * assetBasePrice) / (feePerTradeExit - 1);

                decimal diff = exitPrice - assetBasePrice;

                tbBreakEvenWinPips.Text = decimal.Round(diff, 4).ToString();

                decimal diffPercent = Math.Abs((exitPrice - assetBasePrice) / assetBasePrice) * 100;
                tbBreakEvenWinPercent.Text = Math.Round(diffPercent, 3).ToString() + "%";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Please check the inputs.");
            }
        }

        public class SimResults
        {
            public Tuple<int, decimal>[] XY;
            public int Wins;
            public int Losses;
            public decimal Won;
            public decimal Lost;
            public decimal Fees;
            public decimal ProfitsLosses;
            public decimal Balance;
            public decimal Drawdown;
            public int MaxConsWins;
            public int MaxConsLosses;
            public bool CapReached;
            public int CapReachedOn;

            public SimResults(int sz)
            {
                XY = new Tuple<int, decimal>[sz + 1];
            }
        }

        public class SuperSimResults
        {
            public Tuple<int, decimal, decimal, decimal>[] X_YMin_YAv_YMax;
            public Tuple<int, double, int> Wins_Min_Av_Max;
            public Tuple<int, double, int> Losses_Min_Av_Max;
            public Tuple<decimal, decimal, decimal> Won_Min_Av_Max;
            public Tuple<decimal, decimal, decimal> Lost_Min_Av_Max;
            public Tuple<decimal, decimal, decimal> Fees_Min_Av_Max;
            public Tuple<decimal, decimal, decimal> ProfitsLosses_Min_Av_Max;
            public Tuple<decimal, decimal, decimal> Balance_Min_Av_Max;
            public Tuple<decimal, decimal, decimal> Drawdown_Min_Av_Max;
            public Tuple<int, double, int> MaxConsWins_Min_Av_Max;
            public Tuple<int, double, int> MaxConsLosses_Min_Av_Max;

            public List<SimResults> Sims = new List<SimResults>();

            public SuperSimResults(int sz)
            {
                X_YMin_YAv_YMax = new Tuple<int, decimal, decimal, decimal>[sz + 1];
            }
        }

        Random superRand = new Random();

        private void btnSuperSim_Click(object sender, EventArgs e)
        {
            Supersim(false);
        }

        private void btnSupersimPlus_Click(object sender, EventArgs e)
        {
            Supersim(true);
        }

        public void Supersim(bool showPlus)
        {
            try
            {
                SuperSimResults superSim = new SuperSimResults(int.Parse(tbNumberOfTrades.Text));

                List<SimResults> sims = new List<SimResults>();

                for (int simCount = 0; simCount < (int)numSimCount.Value; simCount++)
                {
                    SimResults sim = new SimResults(int.Parse(tbNumberOfTrades.Text));

                    decimal assetBasePrice = decimal.Parse(tbAssetBasePrice.Text);

                    decimal startingBalance = decimal.Parse(tbStartingBalance.Text);
                    decimal riskPercentPerTrade = decimal.Parse(tbRiskPerTrade.Text) / 100;
                    decimal winRate = decimal.Parse(tbWinRate.Text);

                    decimal sLPercentMin = decimal.Parse(tbStopLoss.Text) / 100;
                    decimal sLPercentMax = decimal.Parse(tbStopLoss2.Text) / 100;

                    decimal rR = decimal.Parse(tbRR.Text);

                    int cap = int.Parse(tbOrderCap.Text);

                    int numberOfTrades = int.Parse(tbNumberOfTrades.Text);
                    int leverage = int.Parse(tbLeverage.Text);
                    decimal feePerTradeEnt = decimal.Parse(tbFeesPerOrderEnt.Text) / 100;
                    decimal feePerTradeExit = decimal.Parse(tbFeesPerOrderExit.Text) / 100;

                    decimal currentBalance = startingBalance;
                    decimal totalFees = 0;
                    decimal totalCurrencyWon = 0;
                    decimal totalCurrencyLost = 0;
                    int totalTradesWon = 0;
                    int totalTradesLost = 0;

                    decimal max = startingBalance;
                    decimal maxDrawdown = 0;

                    sim.XY[0] = new Tuple<int, decimal>(0, startingBalance);

                    Tuple<decimal, decimal> lastPt = new Tuple<decimal, decimal>(0, startingBalance);

                    int consWins = 0;
                    int maxConsWins = 0;
                    int consLosses = 0;
                    int maxConsLosses = 0;

                    int capReachedOnTrade = 0;
                    bool capReached = false;

                    for (int i = 0; i < numberOfTrades; i++)
                    {
                        if (currentBalance <= 0.01M)
                        {
                            break;
                        }

                        decimal tradeAmount = currentBalance * riskPercentPerTrade;

                        if (tradeAmount > cap)
                        {
                            tradeAmount = cap;

                            if (!capReached)
                            {
                                capReached = true;
                                capReachedOnTrade = i + 1;
                            }
                        }

                        decimal leveragedAmount = tradeAmount * leverage;

                        decimal entryFee = leveragedAmount * feePerTradeEnt;
                        totalFees += entryFee;
                        currentBalance -= entryFee;

                        int chance = superRand.Next(0, 100) + 1;

                        decimal slRandomized = (decimal)slRand.Next((int)(sLPercentMin * 10000), (int)(sLPercentMax * 10000 + 1)) / (decimal)10000;
                        decimal tpRandomized = slRandomized * rR;

                        if (chance <= winRate)
                        {
                            decimal assetNewValue = assetBasePrice + assetBasePrice * tpRandomized;

                            totalTradesWon += 1;
                            consWins += 1;
                            consLosses = 0;
                            if (consWins > maxConsWins)
                                maxConsWins = consWins;

                            decimal exitFee = (leveragedAmount + leveragedAmount * tpRandomized) * feePerTradeExit;
                            totalFees += exitFee;
                            currentBalance -= exitFee;

                            decimal balanceChange = (assetNewValue - assetBasePrice) * leveragedAmount;

                            currentBalance += balanceChange;
                            totalCurrencyWon += balanceChange;

                            max = currentBalance > max ? currentBalance : max;
                        }
                        else
                        {
                            decimal assetNewValue = assetBasePrice - assetBasePrice * slRandomized;

                            totalTradesLost += 1;
                            consLosses += 1;
                            consWins = 0;
                            if (consLosses > maxConsLosses)
                                maxConsLosses = consLosses;

                            decimal exitFee = (leveragedAmount - leveragedAmount * slRandomized) * feePerTradeExit;
                            totalFees += exitFee;
                            currentBalance -= exitFee;

                            decimal balanceChange = (assetBasePrice - assetNewValue) * leveragedAmount;

                            currentBalance -= balanceChange;
                            totalCurrencyLost -= balanceChange;

                            maxDrawdown = 1 - (currentBalance / max) > maxDrawdown ? 1 - (currentBalance / max) : maxDrawdown;
                        }

                        sim.XY[i + 1] = new Tuple<int, decimal>(i + 1, currentBalance);

                        lastPt = new Tuple<decimal, decimal>(i + 1, currentBalance);
                    }

                    sim.Wins = totalTradesWon;
                    sim.Losses = totalTradesLost;
                    sim.Won = totalCurrencyWon;
                    sim.Lost = totalCurrencyLost;
                    sim.Fees = totalFees;
                    sim.Balance = currentBalance;
                    sim.ProfitsLosses = currentBalance - startingBalance;
                    sim.Drawdown = maxDrawdown;
                    sim.MaxConsWins = maxConsWins;
                    sim.MaxConsLosses = maxConsLosses;
                    sim.CapReached = capReached;
                    sim.CapReachedOn = capReachedOnTrade;

                    sims.Add(sim);
                    superSim.Sims.Add(sim);
                }

                for (int i = 0; i <= int.Parse(tbNumberOfTrades.Text); i++)
                {
                    superSim.X_YMin_YAv_YMax[i] = new Tuple<int, decimal, decimal, decimal>(i, sims.Min(s => s.XY[i].Item2), sims.Average(s => s.XY[i].Item2), sims.Max(s => s.XY[i].Item2));
                }

                superSim.Wins_Min_Av_Max = new Tuple<int, double, int>(sims.Min(s => s.Wins), sims.Average(s => s.Wins), sims.Max(s => s.Wins));
                superSim.Losses_Min_Av_Max = new Tuple<int, double, int>(sims.Min(s => s.Losses), sims.Average(s => s.Losses), sims.Max(s => s.Losses));
                superSim.Won_Min_Av_Max = new Tuple<decimal, decimal, decimal>(sims.Min(s => s.Won), sims.Average(s => s.Won), sims.Max(s => s.Won));
                superSim.Lost_Min_Av_Max = new Tuple<decimal, decimal, decimal>(sims.Min(s => s.Lost), sims.Average(s => s.Lost), sims.Max(s => s.Lost));
                superSim.Fees_Min_Av_Max = new Tuple<decimal, decimal, decimal>(sims.Min(s => s.Fees), sims.Average(s => s.Fees), sims.Max(s => s.Fees));
                superSim.ProfitsLosses_Min_Av_Max = new Tuple<decimal, decimal, decimal>(sims.Min(s => s.ProfitsLosses), sims.Average(s => s.ProfitsLosses), sims.Max(s => s.ProfitsLosses));
                superSim.Balance_Min_Av_Max = new Tuple<decimal, decimal, decimal>(sims.Min(s => s.Balance), sims.Average(s => s.Balance), sims.Max(s => s.Balance));
                superSim.Drawdown_Min_Av_Max = new Tuple<decimal, decimal, decimal>(sims.Min(s => s.Drawdown), sims.Average(s => s.Drawdown), sims.Max(s => s.Drawdown));
                superSim.MaxConsWins_Min_Av_Max = new Tuple<int, double, int>(sims.Min(s => s.MaxConsWins), sims.Average(s => s.MaxConsWins), sims.Max(s => s.MaxConsWins));
                superSim.MaxConsLosses_Min_Av_Max = new Tuple<int, double, int>(sims.Min(s => s.MaxConsLosses), sims.Average(s => s.MaxConsLosses), sims.Max(s => s.MaxConsLosses));

                panelGraph.BackgroundImage = null;

                plot = new ScottPlot.Plot();

                List<Tuple<int, decimal>> pts = new List<Tuple<int, decimal>>();

                foreach (SimResults sim in superSim.Sims)
                {
                    foreach (Tuple<int, decimal> pt in sim.XY)
                    {
                        pts.Add(pt);
                    }
                }

                pts = pts.OrderBy(p => p.Item1).ToList();

                int numOfTrades = pts.Last().Item1;
                int numberOfSimulations = pts.Count / (numOfTrades + 1);

                List<Tuple<int, double>> p5 = new List<Tuple<int, double>>();
                List<Tuple<int, double>> p50 = new List<Tuple<int, double>>();
                List<Tuple<int, double>> p95 = new List<Tuple<int, double>>();

                double[] pq95 = new double[pts.Count / (numOfTrades + 1)];

                for (int i = 0; i < numOfTrades + 1; i++)
                {
                    IEnumerable<double> yVals = pts.Where(x => x.Item1 == i).Select(pt => (double)pt.Item2);

                    p5.Add(new Tuple<int, double>(i, MathNet.Numerics.Statistics.Statistics.Quantile(yVals, 0.05)));
                    p50.Add(new Tuple<int, double>(i, MathNet.Numerics.Statistics.Statistics.Quantile(yVals, 0.50)));
                    p95.Add(new Tuple<int, double>(i, MathNet.Numerics.Statistics.Statistics.Quantile(yVals, 0.95)));
                }

                if (cbLog.Checked)
                {
                    for (int i = 0; i < p50.Count - 1; i++)
                    {
                        plot.AddLine(p5[i].Item1, Math.Log10(p5[i].Item2), p5[i + 1].Item1, Math.Log10(p5[i + 1].Item2), Color.FromArgb(255, 0, 0));
                        plot.AddLine(p50[i].Item1, Math.Log10(p50[i].Item2), p50[i + 1].Item1, Math.Log10(p50[i + 1].Item2), Color.FromArgb(0, 0, 0));
                        plot.AddLine(p95[i].Item1, Math.Log10(p95[i].Item2), p95[i + 1].Item1, Math.Log10(p95[i + 1].Item2), Color.FromArgb(0, 255, 0));
                    }

                    for (int i = 0; i < superSim.X_YMin_YAv_YMax.Count() - 1; i++)
                    {
                        plot.AddLine(superSim.X_YMin_YAv_YMax[i].Item1, Math.Log10((double)superSim.X_YMin_YAv_YMax[i].Item2), superSim.X_YMin_YAv_YMax[i + 1].Item1, Math.Log10((double)superSim.X_YMin_YAv_YMax[i + 1].Item2));
                    }

                    for (int i = 0; i < superSim.X_YMin_YAv_YMax.Count() - 1; i++)
                    {
                        plot.AddLine(superSim.X_YMin_YAv_YMax[i].Item1, Math.Log10((double)superSim.X_YMin_YAv_YMax[i].Item4), superSim.X_YMin_YAv_YMax[i + 1].Item1, Math.Log10((double)superSim.X_YMin_YAv_YMax[i + 1].Item4));
                    }
                }
                else
                {
                    for (int i = 0; i < p50.Count - 1; i++)
                    {
                        plot.AddLine(p5[i].Item1, p5[i].Item2, p5[i + 1].Item1, p5[i + 1].Item2, Color.FromArgb(255, 0, 0));
                        plot.AddLine(p50[i].Item1, p50[i].Item2, p50[i + 1].Item1, p50[i + 1].Item2, Color.FromArgb(0, 0, 0));
                        plot.AddLine(p95[i].Item1, p95[i].Item2, p95[i + 1].Item1, p95[i + 1].Item2, Color.FromArgb(0, 255, 0));
                    }

                    for (int i = 0; i < superSim.X_YMin_YAv_YMax.Count() - 1; i++)
                    {
                        plot.AddLine(superSim.X_YMin_YAv_YMax[i].Item1, (double)superSim.X_YMin_YAv_YMax[i].Item2, superSim.X_YMin_YAv_YMax[i + 1].Item1, (double)superSim.X_YMin_YAv_YMax[i + 1].Item2);
                    }

                    for (int i = 0; i < superSim.X_YMin_YAv_YMax.Count() - 1; i++)
                    {
                        plot.AddLine(superSim.X_YMin_YAv_YMax[i].Item1, (double)superSim.X_YMin_YAv_YMax[i].Item4, superSim.X_YMin_YAv_YMax[i + 1].Item1, (double)superSim.X_YMin_YAv_YMax[i + 1].Item4);
                    }
                }

                int minL = decimal.Floor(superSim.X_YMin_YAv_YMax.Min(s => s.Item2)).ToString().Count();
                int maxL = decimal.Ceiling(superSim.X_YMin_YAv_YMax.Max(s => s.Item4)).ToString().Count() + 1;

                if (cbLog.Checked)
                {
                    plot.YAxis.ManualTickPositions(positions, labels);

                    plot.Title($"Equity Curve");
                    plot.Grid(true, Color.FromArgb(90, Color.Black), ScottPlot.LineStyle.Dash);
                    plot.XAxis.MinimumTickSpacing(1);
                    plot.XLabel("Trade #");
                    plot.YLabel("Equity");

                    plot.SetAxisLimitsY(Math.Log10(Math.Pow(10, minL - 1)), Math.Log10(Math.Pow(10, maxL - 1)));
                }

                else
                {
                    plot.Title($"Equity Curve");
                    plot.YAxis.TickDensity(3);
                    plot.XAxis.TickDensity(2);
                    plot.XAxis.MinimumTickSpacing(1);
                    plot.Grid(true, Color.FromArgb(90, Color.Black), ScottPlot.LineStyle.Dash);
                    plot.XLabel("Trade #");
                    plot.YLabel("Equity");
                    plot.AxisAuto();
                }

                panelGraph.BackgroundImage = new Bitmap(plot.Render(panelGraph.Width, panelGraph.Height));

                tbWins.Text = decimal.Round((decimal)superSim.Wins_Min_Av_Max.Item2, 1).ToString();
                tbLosses.Text = decimal.Round((decimal)superSim.Losses_Min_Av_Max.Item2, 1).ToString();
                tbWon.Text = "$" + decimal.Round(superSim.Won_Min_Av_Max.Item2, 0).ToString();
                tbLost.Text = "$" + decimal.Round(superSim.Lost_Min_Av_Max.Item2 * -1, 0).ToString();
                tbFeesPaid.Text = "$" + decimal.Round(superSim.Fees_Min_Av_Max.Item2, 0).ToString();

                if (superSim.ProfitsLosses_Min_Av_Max.Item2 > 0)
                    tbProfitsLosses.Text = "$" + decimal.Round(superSim.ProfitsLosses_Min_Av_Max.Item2, 0).ToString();
                else
                    tbProfitsLosses.Text = "-$" + decimal.Round(superSim.ProfitsLosses_Min_Av_Max.Item2 * -1, 0).ToString();

                tbBalance.Text = "$" + decimal.Round(superSim.Balance_Min_Av_Max.Item2, 0).ToString();
                tbMaxDrawdown.Text = decimal.Round(superSim.Drawdown_Min_Av_Max.Item2 * 100, 2).ToString() + "%";
                tbConsWins.Text = decimal.Round((decimal)superSim.MaxConsWins_Min_Av_Max.Item2, 1).ToString();
                tbConsLosses.Text = decimal.Round((decimal)superSim.MaxConsLosses_Min_Av_Max.Item2, 1).ToString();

                decimal entriesPerHour = decimal.Parse(tbEntriesPerHour.Text);
                decimal hoursPerDay = decimal.Parse(tbHoursPerDay.Text);
                decimal entriesPerDay = entriesPerHour * hoursPerDay;
                decimal daysToComplete = decimal.Round(decimal.Parse(tbNumberOfTrades.Text) / entriesPerDay, 1);

                tbDaysToComplete.Text = daysToComplete.ToString();

                int timesCapReached = sims.Count(s => s.CapReached);

                if (timesCapReached > 0)
                {
                    decimal tradeAverageToCap = (decimal)sims.Where(s => s.CapReached).Average(s => s.CapReachedOn);
                    tbCapReached.Text = "Sims[" + timesCapReached + "] Av[" + decimal.Round(tradeAverageToCap, 0) + "]";
                }
                else
                {
                    tbCapReached.Text = "Not reached";
                }

                if (showPlus)
                {
                    SuperSimResultsWindow ssrw = new SuperSimResultsWindow(superSim);
                    ssrw.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + " " + ex.StackTrace.ToString());
            }
        }

        private void btnProfitLossProcess_Click(object sender, EventArgs e)
        {
            try
            {
                decimal stoploss = decimal.Parse(tbSLDiff.Text);
                decimal balance = decimal.Parse(tbPLBalance.Text);
                decimal assetBasePrice = decimal.Parse(tbPricePL.Text);
                int leverage = int.Parse(tbLevPL.Text);

                decimal riskPercentPerTrade = (decimal.Parse(tbRiskPL.Text) * assetBasePrice) / (balance * leverage);

                decimal tradeAmount = balance * riskPercentPerTrade;

                decimal diffPercent = (1 - ((assetBasePrice - stoploss) / assetBasePrice));

                decimal leveragedAmount = tradeAmount * leverage;

                decimal feePerTradeEnt = decimal.Parse(tbFeePLEnt.Text) / 100;
                decimal feePerTradeExit = decimal.Parse(tbFeePLExit.Text) / 100;

                decimal entryFee = leveragedAmount * feePerTradeEnt;

                decimal rR = decimal.Parse(tbRRPL.Text);

                decimal exitFeeSL = (leveragedAmount + (leveragedAmount * diffPercent)) * feePerTradeExit;
                decimal exitFeeTP = (leveragedAmount - (leveragedAmount * diffPercent * rR)) * feePerTradeExit;

                decimal lossFees = entryFee + exitFeeSL;
                decimal winFees = entryFee + exitFeeTP;

                decimal lost = leveragedAmount * stoploss + lossFees;
                decimal won = leveragedAmount * stoploss * rR - winFees;

                decimal beWinPercent = lost / (lost + won) * 100;
                rtbProfitLossResults.SelectionAlignment = HorizontalAlignment.Center;

                string pGain = decimal.Round((won) / balance * 100, 2) + "%";
                string pLoss = decimal.Round((lost) / balance * 100, 2) + "%";

                rtbProfitLossResults.Text = "\nWon: $" + decimal.Round(won, 2) + " (" + pGain + ")" + "\nLost: $" + decimal.Round(lost, 2) + " (" + pLoss + ")" + "\nBE: " + decimal.Round(beWinPercent, 1) + "%";
            }
            catch (Exception exPL)
            {
                MessageBox.Show("Please check the inputs.");
            }
        }

        private void btnCompound_Click(object sender, EventArgs e)
        {
            try
            {
                decimal principal = decimal.Parse(tbPrincipal.Text);
                decimal rate = decimal.Parse(tbRate.Text) / 100;
                decimal t = decimal.Parse(tbT.Text);

                tbCompOut.Text = (decimal.Round((decimal)((double)principal * Math.Pow((double)(1 + rate), (double)t)), 2)).ToString();
            }
            catch (Exception exComp)
            {
                MessageBox.Show("Please check the inputs.");
            }
        }

        private void btnPlotEquity_Click(object sender, EventArgs e)
        {
            try
            {
                panelGraph.BackgroundImage = null;

                plot = new ScottPlot.Plot();

                List<decimal> bPt = new List<decimal>();

                using (StreamReader sr = new StreamReader("Equity.dat"))
                {
                    sr.ReadLine();

                    while (!sr.EndOfStream)
                    {
                        bPt.Add(decimal.Parse(sr.ReadLine()));
                    }
                }

                if (cbPlotEquityLog.Checked)
                {
                    for (int i = 0; i < bPt.Count - 1; i++)
                    {
                        plot.AddLine(i, Math.Log10((double)bPt[i]), i + 1, Math.Log10((double)bPt[i + 1]));
                    }
                }
                else
                {
                    for (int i = 0; i < bPt.Count - 1; i++)
                    {
                        plot.AddLine(i, (double)bPt[i], i + 1, (double)bPt[i + 1]);
                    }
                }

                int minL = decimal.Floor(bPt.Min()).ToString().Count();
                int maxL = decimal.Ceiling(bPt.Max()).ToString().Count() + 1;

                if (cbPlotEquityLog.Checked)
                {
                    plot.YAxis.ManualTickPositions(positions, labels);

                    plot.Title($"Equity Curve");
                    plot.Grid(true, Color.FromArgb(90, Color.Black), ScottPlot.LineStyle.Dash);
                    plot.XAxis.MinimumTickSpacing(1);
                    plot.XLabel("Trade #");
                    plot.YLabel("Equity");

                    plot.SetAxisLimitsY(Math.Log10(Math.Pow(10, minL - 1)), Math.Log10(Math.Pow(10, maxL - 1)));
                }
                else
                {
                    plot.Title($"Equity Curve");
                    plot.YAxis.TickDensity(3);
                    plot.XAxis.TickDensity(2);
                    plot.XAxis.MinimumTickSpacing(1);
                    plot.Grid(true, Color.FromArgb(90, Color.Black), ScottPlot.LineStyle.Dash);
                    plot.XLabel("Trade #");
                    plot.YLabel("Equity");
                    plot.AxisAuto();
                }

                panelGraph.BackgroundImage = new Bitmap(plot.Render(panelGraph.Width, panelGraph.Height));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please ensure that the data in Equity.dat is properly formatted.");
            }
        }

        private void btnEntry_Click(object sender, EventArgs e)
        {
            try
            {
                decimal newBalance = decimal.Parse(tbNewBalance.Text);

                ChangeBalance(newBalance);

                MessageBox.Show("Balance has been set to $" + newBalance);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please check the input.");
            }
        }

        private void btnResetBalance_Click(object sender, EventArgs e)
        {
            try
            {
                ConfirmationDialog cd = new ConfirmationDialog("Please confirm that you wish to reset your balance. You will lose all historical balance data. This does not affect trades. This process is irreversible.");

                DialogResult diagRes = cd.ShowDialog();

                if (diagRes == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter("Equity.dat", false))
                    {
                        sw.Write("0");
                    }

                    tbStartingBalance.Text = "0";
                    tbPLBalance.Text = "0";
                    tbPrincipal.Text = "0";
                    tbPSTableBalance.Text = "0";

                    MessageBox.Show("Balance history has been erased.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error erasing balance history");
            }
        }

        private void btnGenerateSizingTable_Click(object sender, EventArgs e)
        {
            try
            {
                int ulev = int.Parse(tbPSTableULev.Text);
                decimal balance = decimal.Parse(tbPSTableBalance.Text) * ulev;
                decimal price = decimal.Parse(tbPSTablePrice.Text);
                decimal lossPercent = decimal.Parse(tbPSTableLoss.Text) / 100;
                decimal entryFee = decimal.Parse(tbPSTableFeeEntry.Text) / 100;
                decimal exitFee = decimal.Parse(tbPSTableFeeExit.Text) / 100;

                int sigX = (int)nudPSTableSigX.Value;
                int stepSize = (int)nudPSTableStepSize.Value;
                int rows = (int)nudPSTableRows.Value;

                if (sigX != 0)
                {
                    PositionSizingWindow psw = new PositionSizingWindow(balance, price, lossPercent, entryFee, exitFee, sigX, stepSize, rows, ulev);

                    psw.Show(this);
                }
                else
                {
                    MessageBox.Show("Sig. X cannot equal zero.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please check the inputs.");
            }
        }

        private void btnPSTablePlot_Click(object sender, EventArgs e)
        {
            try
            {
                int ulev = int.Parse(tbPSTableULev.Text);
                decimal balance = decimal.Parse(tbPSTableBalance.Text) * ulev;
                decimal price = decimal.Parse(tbPSTablePrice.Text);
                decimal lossPercent = decimal.Parse(tbPSTableLoss.Text) / 100;
                decimal entryFee = decimal.Parse(tbPSTableFeeEntry.Text) / 100;
                decimal exitFee = decimal.Parse(tbPSTableFeeExit.Text) / 100;

                int sigX = (int)nudPSTableSigX.Value;
                int stepSize = (int)nudPSTableStepSize.Value;
                int rows = (int)nudPSTableRows.Value;

                if (sigX != 0)
                {
                    PositionSizingWindow psw = new PositionSizingWindow(balance, price, lossPercent, entryFee, exitFee, sigX, stepSize, rows, ulev);

                    List<Tuple<decimal, decimal>> sizingTuples = psw.SizingTuples;

                    psw.Dispose();

                    // plot
                    panelGraph.BackgroundImage = null;

                    plot = new ScottPlot.Plot();

                    for (int i = 0; i < sizingTuples.Count - 1; i++)
                    {
                        plot.AddLine((double)sizingTuples[i].Item1, (double)sizingTuples[i].Item2, (double)sizingTuples[i + 1].Item1, (double)sizingTuples[i + 1].Item2, Color.Black);
                    }

                    plot.Title("[ Bal: $" + balance + " ] [ ~Asset $: $" + price + " ] [ Loss: " + lossPercent * 100 + "% ] [ SIGX: " + sigX + " ] [ XSTEP: " + stepSize + " ]");
                    plot.YAxis.TickDensity(3);
                    plot.XAxis.TickDensity(2);
                    plot.Grid(true, Color.FromArgb(90, Color.Black), ScottPlot.LineStyle.Dash);
                    plot.XLabel("Stoploss");
                    plot.YLabel("Units");
                    plot.AxisAuto();

                    panelGraph.BackgroundImage = new Bitmap(plot.Render(panelGraph.Width, panelGraph.Height));
                }
                else
                {
                    MessageBox.Show("Sig. X cannot equal zero.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please check the inputs.");
            }
        }

        private void btnTradeEntry_Click(object sender, EventArgs e)
        {
            List<Trade> trades = LoadTrades();

            TradeEntryWindow tew;

            if (trades.Count > 0)
            {
                Trade last = trades.Last();

                tew = new TradeEntryWindow(last.Exchange, last.Symbol, last.Timeframe, last.Leverage, last.Risk);
            }
            else
            {
                tew = new TradeEntryWindow(String.Empty, String.Empty, String.Empty, 0, 0);
            }

            if (tew.ShowDialog() == DialogResult.OK)
            {
                InsertTrade(tew.TradeResult);

                MessageBox.Show("Trade was added successfully.");
            }
        }

        private void btnTradeViewer_Click(object sender, EventArgs e)
        {
            List<Trade> trades = LoadTrades();

            if (trades.Count > 0)
            {
                // Load trade viewer, pass trades
            }
            else
            {
                MessageBox.Show("There are no trades to load.");
            }
        }

        public List<Trade> LoadTrades()
        {
            try
            {
                List<Trade> trades;

                using (FileStream fs = new FileStream("Trades.bin", FileMode.Open))
                {
                    BinaryFormatter debf = new BinaryFormatter();
                    trades = (List<Trade>)debf.Deserialize(fs);
                }

                return trades;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error loading the trades. Empty list returned.");

                return new List<Trade>();
            }
        }

        public void InsertTrade(Trade trade)
        {
            try
            {
                List<Trade> trades = LoadTrades();

                trades.Add(trade);

                using (FileStream fs = new FileStream("Trades.bin", FileMode.Truncate))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, trades);
                }

                ChangeBalance(trade.Balance);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error inserting the trade.");
            }
        }

        public void ChangeBalance(decimal balance)
        {
            using (StreamWriter sw = new StreamWriter("Equity.dat", true))
            {
                sw.Write("\n" + balance);
            }

            tbStartingBalance.Text = balance.ToString();
            tbPLBalance.Text = balance.ToString();
            tbPrincipal.Text = balance.ToString();
            tbPSTableBalance.Text = balance.ToString();
        }

        public void RemoveTrade(Trade trade)
        {
            try
            {
                List<Trade> trades = LoadTrades();

                trades.Remove(trades.Find(t => t.Date == trade.Date & t.TimeOfEntry == trade.TimeOfEntry & t.Symbol == trade.Symbol & t.Exchange == trade.Exchange));

                using (FileStream fs = new FileStream("Trades.bin", FileMode.Truncate))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, trades);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error removing the trade.");
            }
        }

        private void btnResetTrades_Click(object sender, EventArgs e)
        {
            ConfirmationDialog cd = new ConfirmationDialog("Please confirm that you wish to purge trades. This will not affect current balance nor balance history. This process is irreversible.");

            if (cd.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream("Trades.bin", FileMode.Truncate))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, new List<Trade>());
                }

                MessageBox.Show("Trades successfully purged.");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormState state = new FormState();

            state.SIMAssetPrice = tbAssetBasePrice.Text;
            state.SIMPercentAccountPerTrade = tbRiskPerTrade.Text;
            state.SIMWinRate = tbWinRate.Text;
            state.SIMStoploss = tbStopLoss.Text;
            state.SIMStoploss2 = tbStopLoss2.Text;
            state.SIMRR = tbRR.Text;
            state.SIMTrades = tbNumberOfTrades.Text;
            state.SIMLeverage = tbLeverage.Text;
            state.SIMEntryFee = tbFeesPerOrderEnt.Text;
            state.SIMExitFee = tbFeesPerOrderExit.Text;
            state.SIMOrderCap = tbOrderCap.Text;
            state.SIMEntriesPerHour = tbEntriesPerHour.Text;
            state.SIMTradingHoursPerDay = tbHoursPerDay.Text;
            state.SIMLogarithmic = cbLog.Checked;
            state.SIMIterations = (int)numSimCount.Value;

            state.PSTPrice = tbPSTablePrice.Text;
            state.PSTLeverage = tbPSTableULev.Text;
            state.PSTRisk = tbPSTableLoss.Text;
            state.PSTEntryFee = tbPSTableFeeEntry.Text;
            state.PSTExitFee = tbPSTableFeeExit.Text;
            state.PSTSigX = (int)nudPSTableSigX.Value;
            state.PSTXStep = (int)nudPSTableStepSize.Value;
            state.PSTRows = (int)nudPSTableRows.Value;

            state.PLPrice = tbPricePL.Text;
            state.PLUnits = tbRiskPL.Text;
            state.PLRR = tbRRPL.Text;
            state.PLLeverage = tbLevPL.Text;
            state.PLEntryFee = tbFeePLEnt.Text;
            state.PLExitFee = tbFeePLExit.Text;
            state.PLStoploss = tbSLDiff.Text;

            state.CMPRateOfReturn = tbRate.Text;
            state.CMPNumberOfCompounds = tbT.Text;

            state.BEPrice = tbGBEAssetPrice.Text;
            state.BEEntryFee = tbGBEFeeEntry.Text;
            state.BEExitFee = tbGBEFeeExit.Text;

            state.PEQLogarithmic = cbPlotEquityLog.Checked;

            if (File.Exists("State.bin"))
                File.Delete("State.bin");

            using (FileStream fs = new FileStream("State.bin", FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, state);
            }
        }
    }

    [Serializable]
    public class FormState
    {
        public string SIMAssetPrice { get; set; }
        public string SIMPercentAccountPerTrade { get; set; }
        public string SIMWinRate { get; set; }
        public string SIMStoploss { get; set; }
        public string SIMStoploss2 { get; set; }
        public string SIMRR { get; set; }
        public string SIMTrades { get; set; }
        public string SIMLeverage { get; set; }
        public string SIMEntryFee { get; set; }
        public string SIMExitFee { get; set; }
        public string SIMOrderCap { get; set; }
        public string SIMEntriesPerHour { get; set; }
        public string SIMTradingHoursPerDay { get; set; }
        public bool SIMLogarithmic { get; set; }
        public int SIMIterations { get; set; }

        public string PSTPrice { get; set; }
        public string PSTLeverage { get; set; }
        public string PSTRisk { get; set; }
        public string PSTEntryFee { get; set; }
        public string PSTExitFee { get; set; }
        public int PSTSigX { get; set; }
        public int PSTXStep { get; set; }
        public int PSTRows { get; set; }

        public string PLPrice { get; set; }
        public string PLUnits { get; set; }
        public string PLRR { get; set; }
        public string PLLeverage { get; set; }
        public string PLEntryFee { get; set; }
        public string PLExitFee { get; set; }
        public string PLStoploss { get; set; }

        public string CMPRateOfReturn { get; set; }
        public string CMPNumberOfCompounds { get; set; }

        public string BEPrice { get; set; }
        public string BEEntryFee { get; set; }
        public string BEExitFee { get; set; }

        public bool PEQLogarithmic { get; set; }

        public FormState() { }
    }
}