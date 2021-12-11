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
    public partial class SuperSimResultsWindow : Form
    {
        public SuperSimResultsWindow(Form1.SuperSimResults simResults)
        {
            InitializeComponent();

            tbWinsMin.Text = simResults.Wins_Min_Av_Max.Item1.ToString();
            tbWinsAve.Text = decimal.Round((decimal)simResults.Wins_Min_Av_Max.Item2, 1).ToString();
            tbWinsMax.Text = simResults.Wins_Min_Av_Max.Item3.ToString();
            tbLossesMin.Text = simResults.Losses_Min_Av_Max.Item1.ToString();
            tbLossesAve.Text = decimal.Round((decimal)simResults.Losses_Min_Av_Max.Item2, 1).ToString();
            tbLossesMax.Text = simResults.Losses_Min_Av_Max.Item3.ToString();
            tbWonMin.Text = "$" + decimal.Round(simResults.Won_Min_Av_Max.Item1, 0).ToString();
            tbWonAve.Text = "$" + decimal.Round(simResults.Won_Min_Av_Max.Item2, 0).ToString();
            tbWonMax.Text = "$" + decimal.Round(simResults.Won_Min_Av_Max.Item3, 0).ToString();
            tbLostMin.Text = "$" + decimal.Round(simResults.Lost_Min_Av_Max.Item1 * -1, 0).ToString();
            tbLostAve.Text = "$" + decimal.Round(simResults.Lost_Min_Av_Max.Item2 * -1, 0).ToString();
            tbLostMax.Text = "$" + decimal.Round(simResults.Lost_Min_Av_Max.Item3 * -1, 0).ToString();
            tbFeesPaidMin.Text = "$" + decimal.Round(simResults.Fees_Min_Av_Max.Item1, 0).ToString();
            tbFeesPaidAve.Text = "$" + decimal.Round(simResults.Fees_Min_Av_Max.Item2, 0).ToString();
            tbFeesPaidMax.Text = "$" + decimal.Round(simResults.Fees_Min_Av_Max.Item3, 0).ToString();
            
            if (simResults.ProfitsLosses_Min_Av_Max.Item1 > 0)
                tbProfitsLossesMin.Text = "$" + decimal.Round(simResults.ProfitsLosses_Min_Av_Max.Item1, 0).ToString();
            else
                tbProfitsLossesMin.Text = "-$" + decimal.Round(simResults.ProfitsLosses_Min_Av_Max.Item1 * -1, 0).ToString();

            if (simResults.ProfitsLosses_Min_Av_Max.Item2 > 0)
                tbProfitsLossesAve.Text = "$" + decimal.Round(simResults.ProfitsLosses_Min_Av_Max.Item2, 0).ToString();
            else
                tbProfitsLossesAve.Text = "-$" + decimal.Round(simResults.ProfitsLosses_Min_Av_Max.Item2 * -1, 0).ToString();

            if (simResults.ProfitsLosses_Min_Av_Max.Item2 > 0)
                tbProfitsLossesMax.Text = "$" + decimal.Round(simResults.ProfitsLosses_Min_Av_Max.Item3, 0).ToString();
            else
                tbProfitsLossesMax.Text = "-$" + decimal.Round(simResults.ProfitsLosses_Min_Av_Max.Item3 * -1, 0).ToString();

            tbBalanceMin.Text = "$" + decimal.Round(simResults.Balance_Min_Av_Max.Item1, 0).ToString();
            tbBalanceAve.Text = "$" + decimal.Round(simResults.Balance_Min_Av_Max.Item2, 0).ToString();
            tbBalanceMax.Text = "$" + decimal.Round(simResults.Balance_Min_Av_Max.Item3, 0).ToString();
            tbMaxDrawdownMin.Text = (decimal.Round(simResults.Drawdown_Min_Av_Max.Item1 * 100, 2)).ToString() + "%";
            tbMaxDrawdownAve.Text = (decimal.Round(simResults.Drawdown_Min_Av_Max.Item2 * 100, 2)).ToString() + "%";
            tbMaxDrawdownMax.Text = (decimal.Round(simResults.Drawdown_Min_Av_Max.Item3 * 100, 2)).ToString() + "%";
            tbMinConsWins.Text = simResults.MaxConsWins_Min_Av_Max.Item1.ToString();
            tbAvConsWins.Text = decimal.Round((decimal)simResults.MaxConsWins_Min_Av_Max.Item2, 1).ToString();
            tbMaxConsWins.Text = simResults.MaxConsWins_Min_Av_Max.Item3.ToString();
            tbMinConsLosses.Text = simResults.MaxConsLosses_Min_Av_Max.Item1.ToString();
            tbAvConsLosses.Text = decimal.Round((decimal)simResults.MaxConsLosses_Min_Av_Max.Item2, 1).ToString();
            tbMaxConsLosses.Text = simResults.MaxConsLosses_Min_Av_Max.Item3.ToString();
        }
    }
}