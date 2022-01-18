using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trade_Simulator
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        Random slRand = new Random();

        ScottPlot.Plot plot;

        public Form1()
        {
            InitializeComponent();

            List<decimal> bPt = new List<decimal>();

            using (StreamReader sr = new StreamReader(Environment.CurrentDirectory + @"\Data\Equity.dat"))
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
        }

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
                int winRate = int.Parse(tbWinRate.Text);

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

                tbSLPips.Text = decimal.Round((assetBasePrice * sLPercentMin), 4).ToString();
                tbSLPips2.Text = decimal.Round((assetBasePrice * sLPercentMax), 4).ToString();
                tbTPPips.Text = decimal.Round((assetBasePrice * sLPercentMin * rR), 4).ToString();
                tbTPPips2.Text = decimal.Round((assetBasePrice * sLPercentMax * rR), 4).ToString();

                decimal max = startingBalance;
                decimal maxDrawdown = 0;

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

                        currentBalance += leveragedAmount * tpRandomized;
                        totalCurrencyWon += leveragedAmount * tpRandomized;

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

                        currentBalance -= leveragedAmount * slRandomized;
                        totalCurrencyLost -= leveragedAmount * slRandomized;

                        maxDrawdown = 1 - (currentBalance / max) > maxDrawdown ? 1 - (currentBalance / max) : maxDrawdown;
                    }

                    plot.AddLine((double)lastPt.Item1, (double)lastPt.Item2, i + 1, (double)currentBalance);

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

                plot.Title($"Equity Curve");
                plot.YAxis.TickDensity(3);
                plot.XAxis.TickDensity(2);
                plot.Grid(true, Color.FromArgb(90, Color.Black), ScottPlot.LineStyle.Dash);
                plot.XLabel("Trade #");
                plot.YLabel("Equity");
                plot.AxisAuto();

                panelGraph.BackgroundImage = new Bitmap(plot.Render(panelGraph.Width, panelGraph.Height));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please check the inputs.");
            }
        }

        private void btnGetPercentVariance_Click(object sender, EventArgs e)
        {
            try
            {
                decimal assetBasePrice = decimal.Parse(tbAssetBasePrice.Text);
                decimal differenceInPrice = decimal.Parse(tbDiff.Text);

                decimal diffPercent = (1 - ((assetBasePrice - differenceInPrice) / assetBasePrice)) * 100;

                tbDiffPercent.Text = decimal.Round(diffPercent, 4).ToString() + "%";
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
                decimal assetBasePrice = decimal.Parse(tbAssetBasePrice.Text);
                decimal feePerTradeEntry = decimal.Parse(tbFeesPerOrderEnt.Text) / 100;
                decimal feePerTradeExit = decimal.Parse(tbFeesPerOrderExit.Text) / 100;

                // ExitPrice - ExitPrice * ExitFee = Price + Price * EntryFee
                // x - xy = z + ze
                // exitprice = -()
                // x = -((y + e) * z) / (y - 1)
                
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
                    int winRate = int.Parse(tbWinRate.Text);

                    decimal sLPercentMin = decimal.Parse(tbStopLoss.Text) / 100;
                    decimal sLPercentMax = decimal.Parse(tbStopLoss2.Text) / 100;

                    decimal rR = decimal.Parse(tbRR.Text);

                    tbSLPips.Text = decimal.Round((assetBasePrice * sLPercentMin), 4).ToString();
                    tbSLPips2.Text = decimal.Round((assetBasePrice * sLPercentMax), 4).ToString();
                    tbTPPips.Text = decimal.Round((assetBasePrice * sLPercentMin * rR), 4).ToString();
                    tbTPPips2.Text = decimal.Round((assetBasePrice * sLPercentMax * rR), 4).ToString();

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

                            currentBalance += leveragedAmount * tpRandomized;
                            totalCurrencyWon += leveragedAmount * tpRandomized;

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

                            currentBalance -= leveragedAmount * slRandomized;
                            totalCurrencyLost -= leveragedAmount * slRandomized;

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
                List<Tuple<int, double>> p10 = new List<Tuple<int, double>>();
                List<Tuple<int, double>> p50 = new List<Tuple<int, double>>();
                List<Tuple<int, double>> p90 = new List<Tuple<int, double>>();
                List<Tuple<int, double>> p95 = new List<Tuple<int, double>>();

                double[] pq95 = new double[pts.Count / (numOfTrades + 1)];

                for (int i = 0; i < numOfTrades + 1; i++)
                {
                    IEnumerable<double> yVals = pts.Where(x => x.Item1 == i).Select(pt => (double)pt.Item2);

                    p5.Add(new Tuple<int, double>(i, MathNet.Numerics.Statistics.Statistics.Quantile(yVals, 0.05)));
                    p10.Add(new Tuple<int, double>(i, MathNet.Numerics.Statistics.Statistics.Quantile(yVals, 0.1)));
                    p50.Add(new Tuple<int, double>(i, MathNet.Numerics.Statistics.Statistics.Quantile(yVals, 0.50)));
                    p90.Add(new Tuple<int, double>(i, MathNet.Numerics.Statistics.Statistics.Quantile(yVals, 0.90))); 
                    p95.Add(new Tuple<int, double>(i, MathNet.Numerics.Statistics.Statistics.Quantile(yVals, 0.95)));
                }
                
                for (int i = 0; i < p10.Count - 1; i++)
                {
                    plot.AddLine(p5[i].Item1, p5[i].Item2, p5[i + 1].Item1, p5[i + 1].Item2, Color.FromArgb(255, 0, 0));
                    plot.AddLine(p10[i].Item1, p10[i].Item2, p10[i + 1].Item1, p10[i + 1].Item2, Color.FromArgb(255, 38, 0));
                    plot.AddLine(p50[i].Item1, p50[i].Item2, p50[i + 1].Item1, p50[i + 1].Item2, Color.FromArgb(0, 0, 0));
                    plot.AddLine(p90[i].Item1, p90[i].Item2, p90[i + 1].Item1, p90[i + 1].Item2, Color.FromArgb(38, 255, 0));
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

                plot.Title($"Equity Curve");
                plot.YAxis.TickDensity(3);
                plot.XAxis.TickDensity(2);
                plot.Grid(true, Color.FromArgb(90, Color.Black), ScottPlot.LineStyle.Dash);
                plot.XLabel("Trade #");
                plot.YLabel("Equity");
                plot.AxisAuto();

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
                decimal riskPercentPerTrade = decimal.Parse(tbRiskPL.Text) / 100;
                decimal tradeAmount = balance * riskPercentPerTrade;

                decimal assetBasePrice = decimal.Parse(tbPricePL.Text);

                decimal diffPercent = (1 - ((assetBasePrice - stoploss) / assetBasePrice));

                int leverage = int.Parse(tbLevPL.Text);

                decimal leveragedAmount = tradeAmount * leverage;

                decimal feePerTradeEnt = decimal.Parse(tbFeePLEnt.Text) / 100;
                decimal feePerTradeExit = decimal.Parse(tbFeePLExit.Text) / 100;

                decimal entryFee = leveragedAmount * feePerTradeEnt;

                decimal rR = decimal.Parse(tbRRPL.Text);

                decimal exitFeeSL = (leveragedAmount + (leveragedAmount * diffPercent)) * feePerTradeExit;
                decimal exitFeeTP = (leveragedAmount - (leveragedAmount * diffPercent * rR)) * feePerTradeExit;

                decimal lossFees = entryFee + exitFeeSL;
                decimal winFees = entryFee + exitFeeTP;

                decimal lost = leveragedAmount * diffPercent + lossFees;
                decimal won = leveragedAmount * diffPercent * rR - winFees;

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

                // P (1 + r / n) ^ (nt)

                // TODO: Calculate RoC for compounding, variable period
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

                // Logic here

                List<decimal> bPt = new List<decimal>();

                using (StreamReader sr = new StreamReader(Environment.CurrentDirectory + @"\Data\Equity.dat"))
                {
                    while (!sr.EndOfStream)
                    {
                        bPt.Add(decimal.Parse(sr.ReadLine()));
                    }
                }

                for (int i = 0; i < bPt.Count - 1; i++)
                {
                    plot.AddLine(i, (double)bPt[i], i + 1, (double)bPt[i + 1]);
                }

                plot.Title($"Equity Curve");
                plot.YAxis.TickDensity(3);
                plot.XAxis.TickDensity(2);
                plot.Grid(true, Color.FromArgb(90, Color.Black), ScottPlot.LineStyle.Dash);
                plot.XLabel("Trade #");
                plot.YLabel("Equity ($)");
                plot.AxisAuto();

                panelGraph.BackgroundImage = new Bitmap(plot.Render(panelGraph.Width, panelGraph.Height));
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Please ensure that the data in bin\Data\Equity.dat is properly formatted.");
            }
        }

        private void btnEntry_Click(object sender, EventArgs e)
        {
            // logic here

            try
            {
                decimal newBalance = decimal.Parse(tbNewBalance.Text);

                using (StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + @"\Data\Equity.dat", true))
                {
                    sw.Write("\n" + newBalance);
                }

                tbStartingBalance.Text = newBalance.ToString();
                tbPLBalance.Text = newBalance.ToString();
                tbPrincipal.Text = newBalance.ToString();
                tbPSTableBalance.Text = newBalance.ToString();

                MessageBox.Show("Entry Added.");
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
                decimal newBalance = decimal.Parse(tbNewBalance.Text);

                ConfirmationDialog cd = new ConfirmationDialog();

                DialogResult diagRes = cd.ShowDialog();

                if (diagRes == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + @"\Data\Equity.dat", false))
                    {
                        sw.Write(newBalance);
                    }

                    tbStartingBalance.Text = newBalance.ToString();
                    tbPLBalance.Text = newBalance.ToString();
                    tbPrincipal.Text = newBalance.ToString();
                    tbPSTableBalance.Text = newBalance.ToString();

                    MessageBox.Show("Equity reset.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please check the input.");
            }
        }

        private void btnGenerateSizingTable_Click(object sender, EventArgs e)
        {
            try
            {
                decimal balance = decimal.Parse(tbPSTableBalance.Text);
                decimal price = decimal.Parse(tbPSTablePrice.Text);
                decimal lossPercent = decimal.Parse(tbPSTableLoss.Text) / 100;
                decimal entryFee = decimal.Parse(tbPSTableFeeEntry.Text) / 100;
                decimal exitFee = decimal.Parse(tbPSTableFeeExit.Text) / 100;
                int ulev = int.Parse(tbPSTableULev.Text);

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
                    MessageBox.Show("SigX cannot equal zero.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please check the inputs.");
            }
        }
    }
}