﻿using System;
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
    public partial class Form1 : Form
    {
        Random rand = new Random();
        Random slRand = new Random();

        ScottPlot.Plot plot;

        public Form1()
        {
            InitializeComponent();
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
                decimal feePerTrade = decimal.Parse(tbFeesPerOrder.Text) / 100;

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

                    decimal entryFee = leveragedAmount * feePerTrade;
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

                        decimal exitFee = (leveragedAmount + leveragedAmount * tpRandomized) * feePerTrade;
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

                        decimal exitFee = (leveragedAmount - leveragedAmount * slRandomized) * feePerTrade;
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
                decimal feePerTrade = decimal.Parse(tbFeesPerOrder.Text) / 100;

                // x - xy = z + zy
                // x = -((x + 1) * z) / (x - 1)
                decimal exitPrice = -((feePerTrade + 1) * assetBasePrice) / (feePerTrade - 1);

                decimal diff = Math.Abs(exitPrice - assetBasePrice);

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
                    decimal feePerTrade = decimal.Parse(tbFeesPerOrder.Text) / 100;

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

                        decimal entryFee = leveragedAmount * feePerTrade;
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

                            decimal exitFee = (leveragedAmount + leveragedAmount * tpRandomized) * feePerTrade;
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

                            decimal exitFee = (leveragedAmount - leveragedAmount * slRandomized) * feePerTrade;
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

                // Heatmap Start

                List<Tuple<int, decimal>> pts = new List<Tuple<int, decimal>>();

                // Add all points to pts list
                foreach (SimResults sim in superSim.Sims)
                {
                    foreach (Tuple<int, decimal> pt in sim.XY)
                    {
                        pts.Add(pt);
                    }
                }

                // All points ordered by X
                pts = pts.OrderBy(p => p.Item1).ToList();

                //int[] xs = new int[pts.Count];
                //int[] ys = new int[pts.Count];

                //// Load x and y arrays
                //for (int i = 0; i < pts.Count; i++)
                //{
                //    xs[i] = pts[i].Item1;
                //    ys[i] = (int)pts[i].Item2;
                //}

                //double[,] intensities = ScottPlot.Tools.XYToIntensities(ScottPlot.IntensityMode.Gaussian, xs, ys, superSim.Sims[0].XY.Count(), ys.Max(), 2);

                //plot.AddHeatmap(intensities, default, false);

                int numOfTrades = pts.Last().Item1;
                int numberOfSimulations = pts.Count / (numOfTrades + 1);

                List<Tuple<int, double>> p5 = new List<Tuple<int, double>>();
                List<Tuple<int, double>> p10 = new List<Tuple<int, double>>();
                //List<Tuple<int, double>> p15 = new List<Tuple<int, double>>();
                //List<Tuple<int, double>> p20 = new List<Tuple<int, double>>();
                //List<Tuple<int, double>> p25 = new List<Tuple<int, double>>();
                //List<Tuple<int, double>> p30 = new List<Tuple<int, double>>();
                //List<Tuple<int, double>> p35 = new List<Tuple<int, double>>();
                //List<Tuple<int, double>> p40 = new List<Tuple<int, double>>();
                //List<Tuple<int, double>> p45 = new List<Tuple<int, double>>();
                List<Tuple<int, double>> p50 = new List<Tuple<int, double>>();
                //List<Tuple<int, double>> p55 = new List<Tuple<int, double>>();
                //List<Tuple<int, double>> p60 = new List<Tuple<int, double>>();
                //List<Tuple<int, double>> p65 = new List<Tuple<int, double>>();
                //List<Tuple<int, double>> p70 = new List<Tuple<int, double>>();
                //List<Tuple<int, double>> p75 = new List<Tuple<int, double>>();
                //List<Tuple<int, double>> p80 = new List<Tuple<int, double>>();
                //List<Tuple<int, double>> p85 = new List<Tuple<int, double>>();
                List<Tuple<int, double>> p90 = new List<Tuple<int, double>>();
                List<Tuple<int, double>> p95 = new List<Tuple<int, double>>();

                double[] pq95 = new double[pts.Count / (numOfTrades + 1)];

                for (int i = 0; i < numOfTrades + 1; i++)
                {
                    IEnumerable<double> yVals = pts.Where(x => x.Item1 == i).Select(pt => (double)pt.Item2);

                    p5.Add(new Tuple<int, double>(i, MathNet.Numerics.Statistics.Statistics.Quantile(yVals, 0.05)));
                    p10.Add(new Tuple<int, double>(i, MathNet.Numerics.Statistics.Statistics.Quantile(yVals, 0.1)));
                    //p15.Add(new Tuple<int, double>(i, MathNet.Numerics.Statistics.Statistics.Quantile(yVals, 0.15)));
                    //p20.Add(new Tuple<int, double>(i, MathNet.Numerics.Statistics.Statistics.Quantile(yVals, 0.20)));
                    //p25.Add(new Tuple<int, double>(i, MathNet.Numerics.Statistics.Statistics.Quantile(yVals, 0.25)));
                    //p30.Add(new Tuple<int, double>(i, MathNet.Numerics.Statistics.Statistics.Quantile(yVals, 0.30)));
                    //p35.Add(new Tuple<int, double>(i, MathNet.Numerics.Statistics.Statistics.Quantile(yVals, 0.35)));
                    //p40.Add(new Tuple<int, double>(i, MathNet.Numerics.Statistics.Statistics.Quantile(yVals, 0.40)));
                    //p45.Add(new Tuple<int, double>(i, MathNet.Numerics.Statistics.Statistics.Quantile(yVals, 0.45)));
                    p50.Add(new Tuple<int, double>(i, MathNet.Numerics.Statistics.Statistics.Quantile(yVals, 0.50)));
                    //p55.Add(new Tuple<int, double>(i, MathNet.Numerics.Statistics.Statistics.Quantile(yVals, 0.55)));
                    //p60.Add(new Tuple<int, double>(i, MathNet.Numerics.Statistics.Statistics.Quantile(yVals, 0.60)));
                    //p65.Add(new Tuple<int, double>(i, MathNet.Numerics.Statistics.Statistics.Quantile(yVals, 0.65)));
                    //p70.Add(new Tuple<int, double>(i, MathNet.Numerics.Statistics.Statistics.Quantile(yVals, 0.70)));
                    //p75.Add(new Tuple<int, double>(i, MathNet.Numerics.Statistics.Statistics.Quantile(yVals, 0.75)));
                    //p80.Add(new Tuple<int, double>(i, MathNet.Numerics.Statistics.Statistics.Quantile(yVals, 0.80)));
                    //p85.Add(new Tuple<int, double>(i, MathNet.Numerics.Statistics.Statistics.Quantile(yVals, 0.85)));
                    p90.Add(new Tuple<int, double>(i, MathNet.Numerics.Statistics.Statistics.Quantile(yVals, 0.90))); 
                    p95.Add(new Tuple<int, double>(i, MathNet.Numerics.Statistics.Statistics.Quantile(yVals, 0.95)));
                }
                
                for (int i = 0; i < p10.Count - 1; i++)
                {
                    plot.AddLine(p5[i].Item1, p5[i].Item2, p5[i + 1].Item1, p5[i + 1].Item2, Color.FromArgb(255, 0, 0));
                    plot.AddLine(p10[i].Item1, p10[i].Item2, p10[i + 1].Item1, p10[i + 1].Item2, Color.FromArgb(255, 38, 0));
                    //plot.AddLine(p15[i].Item1, p15[i].Item2, p15[i + 1].Item1, p15[i + 1].Item2, Color.FromArgb(255, 76, 0));
                    //plot.AddLine(p20[i].Item1, p20[i].Item2, p20[i + 1].Item1, p20[i + 1].Item2, Color.FromArgb(255, 114, 0));
                    //plot.AddLine(p25[i].Item1, p25[i].Item2, p25[i + 1].Item1, p25[i + 1].Item2, Color.FromArgb(255, 152, 0));
                    //plot.AddLine(p30[i].Item1, p30[i].Item2, p30[i + 1].Item1, p30[i + 1].Item2, Color.FromArgb(255, 152, 0));
                    //plot.AddLine(p35[i].Item1, p35[i].Item2, p35[i + 1].Item1, p35[i + 1].Item2, Color.FromArgb(255, 152, 0));
                    //plot.AddLine(p40[i].Item1, p40[i].Item2, p40[i + 1].Item1, p40[i + 1].Item2, Color.FromArgb(255, 152, 0));
                    //plot.AddLine(p45[i].Item1, p45[i].Item2, p45[i + 1].Item1, p45[i + 1].Item2, Color.FromArgb(255, 152, 0));
                    plot.AddLine(p50[i].Item1, p50[i].Item2, p50[i + 1].Item1, p50[i + 1].Item2, Color.FromArgb(0, 0, 0));
                    //plot.AddLine(p55[i].Item1, p55[i].Item2, p55[i + 1].Item1, p55[i + 1].Item2);
                    //plot.AddLine(p60[i].Item1, p60[i].Item2, p60[i + 1].Item1, p60[i + 1].Item2);
                    //plot.AddLine(p65[i].Item1, p65[i].Item2, p65[i + 1].Item1, p65[i + 1].Item2);
                    //plot.AddLine(p70[i].Item1, p70[i].Item2, p70[i + 1].Item1, p70[i + 1].Item2);
                    //plot.AddLine(p75[i].Item1, p75[i].Item2, p75[i + 1].Item1, p75[i + 1].Item2);
                    //plot.AddLine(p80[i].Item1, p80[i].Item2, p80[i + 1].Item1, p80[i + 1].Item2);
                    //plot.AddLine(p85[i].Item1, p85[i].Item2, p85[i + 1].Item1, p85[i + 1].Item2, Color.FromArgb(38, 255, 0));
                    plot.AddLine(p90[i].Item1, p90[i].Item2, p90[i + 1].Item1, p90[i + 1].Item2, Color.FromArgb(38, 255, 0));
                    plot.AddLine(p95[i].Item1, p95[i].Item2, p95[i + 1].Item1, p95[i + 1].Item2, Color.FromArgb(0, 255, 0));
                }   

                // End Heatmap

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

                int leverage = int.Parse(tbLeverage.Text);

                decimal leveragedAmount = tradeAmount * leverage;

                decimal feePerTrade = decimal.Parse(tbFeesPerOrder.Text) / 100;

                decimal entryFee = leveragedAmount * feePerTrade;

                decimal rR = decimal.Parse(tbRRPL.Text);

                decimal exitFeeSL = (leveragedAmount + (leveragedAmount * diffPercent)) * feePerTrade;
                decimal exitFeeTP = (leveragedAmount - (leveragedAmount * diffPercent * rR)) * feePerTrade;

                decimal lossFees = entryFee + exitFeeSL;
                decimal winFees = entryFee + exitFeeTP;

                decimal lost = leveragedAmount * diffPercent + lossFees;
                decimal won = leveragedAmount * diffPercent * rR - winFees;

                rtbProfitLossResults.Text = "Won: $" + decimal.Round(won, 2) + "\nLost: $" + decimal.Round(lost, 2);
            }
            catch (Exception exPL)
            {
                MessageBox.Show("Please check the inputs.");
            }
        }
    }
}