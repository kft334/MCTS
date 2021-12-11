
namespace Trade_Simulator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbStartingBalance = new System.Windows.Forms.TextBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRiskPerTrade = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbWinRate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbStopLoss = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbNumberOfTrades = new System.Windows.Forms.TextBox();
            this.tbLeverage = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbFeesPerOrder = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbWon = new System.Windows.Forms.TextBox();
            this.tbWins = new System.Windows.Forms.TextBox();
            this.tbLost = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbLosses = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbFeesPaid = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tbProfitsLosses = new System.Windows.Forms.TextBox();
            this.tbBalance = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tbAssetBasePrice = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tbSLPips = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tbTPPips = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tbDiffPercent = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDiff = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.btnGetPercentVariance = new System.Windows.Forms.Button();
            this.tbBreakEvenWinPercent = new System.Windows.Forms.TextBox();
            this.btnGetBreakEvenWin = new System.Windows.Forms.Button();
            this.tbBreakEvenWinPips = new System.Windows.Forms.TextBox();
            this.panelGraph = new System.Windows.Forms.Panel();
            this.tbMaxDrawdown = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSuperSim = new System.Windows.Forms.Button();
            this.numSimCount = new System.Windows.Forms.NumericUpDown();
            this.tbStopLoss2 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tbRR = new System.Windows.Forms.TextBox();
            this.tbSLPips2 = new System.Windows.Forms.TextBox();
            this.tbTPPips2 = new System.Windows.Forms.TextBox();
            this.btnSupersimPlus = new System.Windows.Forms.Button();
            this.tbConsWins = new System.Windows.Forms.TextBox();
            this.tbConsLosses = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.tbOrderCap = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.tbCapReached = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.tbEntriesPerHour = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.tbHoursPerDay = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.tbDaysToComplete = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numSimCount)).BeginInit();
            this.SuspendLayout();
            // 
            // tbStartingBalance
            // 
            this.tbStartingBalance.Location = new System.Drawing.Point(140, 34);
            this.tbStartingBalance.Name = "tbStartingBalance";
            this.tbStartingBalance.Size = new System.Drawing.Size(100, 20);
            this.tbStartingBalance.TabIndex = 1;
            this.tbStartingBalance.Text = "100";
            this.tbStartingBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnProcess
            // 
            this.btnProcess.BackColor = System.Drawing.Color.Black;
            this.btnProcess.ForeColor = System.Drawing.Color.White;
            this.btnProcess.Location = new System.Drawing.Point(15, 304);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(225, 23);
            this.btnProcess.TabIndex = 13;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = false;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Account Balance $";
            // 
            // tbRiskPerTrade
            // 
            this.tbRiskPerTrade.Location = new System.Drawing.Point(140, 57);
            this.tbRiskPerTrade.Name = "tbRiskPerTrade";
            this.tbRiskPerTrade.Size = new System.Drawing.Size(100, 20);
            this.tbRiskPerTrade.TabIndex = 2;
            this.tbRiskPerTrade.Text = "10";
            this.tbRiskPerTrade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "% Account / Trade (Int)";
            // 
            // tbWinRate
            // 
            this.tbWinRate.Location = new System.Drawing.Point(140, 80);
            this.tbWinRate.Name = "tbWinRate";
            this.tbWinRate.Size = new System.Drawing.Size(100, 20);
            this.tbWinRate.TabIndex = 3;
            this.tbWinRate.Text = "55";
            this.tbWinRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "% Win Rate (Int)";
            // 
            // tbStopLoss
            // 
            this.tbStopLoss.Location = new System.Drawing.Point(140, 106);
            this.tbStopLoss.Name = "tbStopLoss";
            this.tbStopLoss.Size = new System.Drawing.Size(47, 20);
            this.tbStopLoss.TabIndex = 4;
            this.tbStopLoss.Text = "0.3";
            this.tbStopLoss.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Stop Loss %";
            // 
            // tbNumberOfTrades
            // 
            this.tbNumberOfTrades.Location = new System.Drawing.Point(140, 157);
            this.tbNumberOfTrades.Name = "tbNumberOfTrades";
            this.tbNumberOfTrades.Size = new System.Drawing.Size(100, 20);
            this.tbNumberOfTrades.TabIndex = 7;
            this.tbNumberOfTrades.Text = "100";
            this.tbNumberOfTrades.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbLeverage
            // 
            this.tbLeverage.Location = new System.Drawing.Point(140, 180);
            this.tbLeverage.Name = "tbLeverage";
            this.tbLeverage.Size = new System.Drawing.Size(100, 20);
            this.tbLeverage.TabIndex = 8;
            this.tbLeverage.Text = "75";
            this.tbLeverage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "# Trades";
            // 
            // tbFeesPerOrder
            // 
            this.tbFeesPerOrder.Location = new System.Drawing.Point(140, 203);
            this.tbFeesPerOrder.Name = "tbFeesPerOrder";
            this.tbFeesPerOrder.Size = new System.Drawing.Size(100, 20);
            this.tbFeesPerOrder.TabIndex = 9;
            this.tbFeesPerOrder.Text = "0.04";
            this.tbFeesPerOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 183);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Leverage";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 206);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "% Fee / Order";
            // 
            // tbWon
            // 
            this.tbWon.BackColor = System.Drawing.Color.Black;
            this.tbWon.ForeColor = System.Drawing.Color.White;
            this.tbWon.Location = new System.Drawing.Point(140, 485);
            this.tbWon.Name = "tbWon";
            this.tbWon.ReadOnly = true;
            this.tbWon.Size = new System.Drawing.Size(100, 20);
            this.tbWon.TabIndex = 0;
            this.tbWon.TabStop = false;
            this.tbWon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbWins
            // 
            this.tbWins.BackColor = System.Drawing.Color.Black;
            this.tbWins.ForeColor = System.Drawing.Color.White;
            this.tbWins.Location = new System.Drawing.Point(140, 388);
            this.tbWins.Name = "tbWins";
            this.tbWins.ReadOnly = true;
            this.tbWins.Size = new System.Drawing.Size(100, 20);
            this.tbWins.TabIndex = 0;
            this.tbWins.TabStop = false;
            this.tbWins.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbLost
            // 
            this.tbLost.BackColor = System.Drawing.Color.Black;
            this.tbLost.ForeColor = System.Drawing.Color.White;
            this.tbLost.Location = new System.Drawing.Point(140, 508);
            this.tbLost.Name = "tbLost";
            this.tbLost.ReadOnly = true;
            this.tbLost.Size = new System.Drawing.Size(100, 20);
            this.tbLost.TabIndex = 0;
            this.tbLost.TabStop = false;
            this.tbLost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 488);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Won";
            // 
            // tbLosses
            // 
            this.tbLosses.BackColor = System.Drawing.Color.Black;
            this.tbLosses.ForeColor = System.Drawing.Color.White;
            this.tbLosses.Location = new System.Drawing.Point(140, 411);
            this.tbLosses.Name = "tbLosses";
            this.tbLosses.ReadOnly = true;
            this.tbLosses.Size = new System.Drawing.Size(100, 20);
            this.tbLosses.TabIndex = 0;
            this.tbLosses.TabStop = false;
            this.tbLosses.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 391);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Wins";
            // 
            // tbFeesPaid
            // 
            this.tbFeesPaid.BackColor = System.Drawing.Color.Black;
            this.tbFeesPaid.ForeColor = System.Drawing.Color.White;
            this.tbFeesPaid.Location = new System.Drawing.Point(140, 531);
            this.tbFeesPaid.Name = "tbFeesPaid";
            this.tbFeesPaid.ReadOnly = true;
            this.tbFeesPaid.Size = new System.Drawing.Size(100, 20);
            this.tbFeesPaid.TabIndex = 0;
            this.tbFeesPaid.TabStop = false;
            this.tbFeesPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 511);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Lost";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 414);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Losses";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 534);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(30, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "Fees";
            // 
            // tbProfitsLosses
            // 
            this.tbProfitsLosses.BackColor = System.Drawing.Color.Black;
            this.tbProfitsLosses.ForeColor = System.Drawing.Color.White;
            this.tbProfitsLosses.Location = new System.Drawing.Point(140, 554);
            this.tbProfitsLosses.Name = "tbProfitsLosses";
            this.tbProfitsLosses.ReadOnly = true;
            this.tbProfitsLosses.Size = new System.Drawing.Size(100, 20);
            this.tbProfitsLosses.TabIndex = 0;
            this.tbProfitsLosses.TabStop = false;
            this.tbProfitsLosses.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbBalance
            // 
            this.tbBalance.BackColor = System.Drawing.Color.Black;
            this.tbBalance.ForeColor = System.Drawing.Color.White;
            this.tbBalance.Location = new System.Drawing.Point(140, 577);
            this.tbBalance.Name = "tbBalance";
            this.tbBalance.ReadOnly = true;
            this.tbBalance.Size = new System.Drawing.Size(100, 20);
            this.tbBalance.TabIndex = 0;
            this.tbBalance.TabStop = false;
            this.tbBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 557);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 13);
            this.label15.TabIndex = 2;
            this.label15.Text = "Profits / Losses";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 580);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "Balance";
            // 
            // tbAssetBasePrice
            // 
            this.tbAssetBasePrice.Location = new System.Drawing.Point(140, 8);
            this.tbAssetBasePrice.Name = "tbAssetBasePrice";
            this.tbAssetBasePrice.Size = new System.Drawing.Size(100, 20);
            this.tbAssetBasePrice.TabIndex = 0;
            this.tbAssetBasePrice.Text = "5";
            this.tbAssetBasePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 11);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(69, 13);
            this.label17.TabIndex = 2;
            this.label17.Text = "Asset Base $";
            // 
            // tbSLPips
            // 
            this.tbSLPips.BackColor = System.Drawing.Color.Black;
            this.tbSLPips.ForeColor = System.Drawing.Color.White;
            this.tbSLPips.Location = new System.Drawing.Point(310, 35);
            this.tbSLPips.Name = "tbSLPips";
            this.tbSLPips.Size = new System.Drawing.Size(64, 20);
            this.tbSLPips.TabIndex = 12;
            this.tbSLPips.TabStop = false;
            this.tbSLPips.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(269, 38);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(20, 13);
            this.label20.TabIndex = 13;
            this.label20.Text = "SL";
            // 
            // tbTPPips
            // 
            this.tbTPPips.BackColor = System.Drawing.Color.Black;
            this.tbTPPips.ForeColor = System.Drawing.Color.White;
            this.tbTPPips.Location = new System.Drawing.Point(310, 61);
            this.tbTPPips.Name = "tbTPPips";
            this.tbTPPips.Size = new System.Drawing.Size(64, 20);
            this.tbTPPips.TabIndex = 12;
            this.tbTPPips.TabStop = false;
            this.tbTPPips.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(269, 64);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(21, 13);
            this.label21.TabIndex = 13;
            this.label21.Text = "TP";
            // 
            // tbDiffPercent
            // 
            this.tbDiffPercent.BackColor = System.Drawing.Color.Black;
            this.tbDiffPercent.ForeColor = System.Drawing.Color.White;
            this.tbDiffPercent.Location = new System.Drawing.Point(609, 61);
            this.tbDiffPercent.Name = "tbDiffPercent";
            this.tbDiffPercent.ReadOnly = true;
            this.tbDiffPercent.Size = new System.Drawing.Size(100, 20);
            this.tbDiffPercent.TabIndex = 12;
            this.tbDiffPercent.TabStop = false;
            this.tbDiffPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(535, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "% Difference";
            // 
            // tbDiff
            // 
            this.tbDiff.Location = new System.Drawing.Point(609, 8);
            this.tbDiff.Name = "tbDiff";
            this.tbDiff.Size = new System.Drawing.Size(100, 20);
            this.tbDiff.TabIndex = 17;
            this.tbDiff.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(499, 11);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(106, 13);
            this.label22.TabIndex = 13;
            this.label22.Text = "Price Difference to %";
            // 
            // btnGetPercentVariance
            // 
            this.btnGetPercentVariance.BackColor = System.Drawing.Color.Black;
            this.btnGetPercentVariance.ForeColor = System.Drawing.Color.White;
            this.btnGetPercentVariance.Location = new System.Drawing.Point(609, 34);
            this.btnGetPercentVariance.Name = "btnGetPercentVariance";
            this.btnGetPercentVariance.Size = new System.Drawing.Size(100, 23);
            this.btnGetPercentVariance.TabIndex = 18;
            this.btnGetPercentVariance.Text = "Get % Difference";
            this.btnGetPercentVariance.UseVisualStyleBackColor = false;
            this.btnGetPercentVariance.Click += new System.EventHandler(this.btnGetPercentVariance_Click);
            // 
            // tbBreakEvenWinPercent
            // 
            this.tbBreakEvenWinPercent.BackColor = System.Drawing.Color.Black;
            this.tbBreakEvenWinPercent.ForeColor = System.Drawing.Color.White;
            this.tbBreakEvenWinPercent.Location = new System.Drawing.Point(758, 33);
            this.tbBreakEvenWinPercent.Name = "tbBreakEvenWinPercent";
            this.tbBreakEvenWinPercent.ReadOnly = true;
            this.tbBreakEvenWinPercent.Size = new System.Drawing.Size(100, 20);
            this.tbBreakEvenWinPercent.TabIndex = 12;
            this.tbBreakEvenWinPercent.TabStop = false;
            this.tbBreakEvenWinPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnGetBreakEvenWin
            // 
            this.btnGetBreakEvenWin.BackColor = System.Drawing.Color.Black;
            this.btnGetBreakEvenWin.ForeColor = System.Drawing.Color.White;
            this.btnGetBreakEvenWin.Location = new System.Drawing.Point(758, 6);
            this.btnGetBreakEvenWin.Name = "btnGetBreakEvenWin";
            this.btnGetBreakEvenWin.Size = new System.Drawing.Size(100, 23);
            this.btnGetBreakEvenWin.TabIndex = 19;
            this.btnGetBreakEvenWin.Text = "Get Break Even";
            this.btnGetBreakEvenWin.UseVisualStyleBackColor = false;
            this.btnGetBreakEvenWin.Click += new System.EventHandler(this.btnGetBreakEvenWin_Click);
            // 
            // tbBreakEvenWinPips
            // 
            this.tbBreakEvenWinPips.BackColor = System.Drawing.Color.Black;
            this.tbBreakEvenWinPips.ForeColor = System.Drawing.Color.White;
            this.tbBreakEvenWinPips.Location = new System.Drawing.Point(758, 59);
            this.tbBreakEvenWinPips.Name = "tbBreakEvenWinPips";
            this.tbBreakEvenWinPips.ReadOnly = true;
            this.tbBreakEvenWinPips.Size = new System.Drawing.Size(100, 20);
            this.tbBreakEvenWinPips.TabIndex = 12;
            this.tbBreakEvenWinPips.TabStop = false;
            this.tbBreakEvenWinPips.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panelGraph
            // 
            this.panelGraph.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelGraph.Location = new System.Drawing.Point(255, 96);
            this.panelGraph.Name = "panelGraph";
            this.panelGraph.Size = new System.Drawing.Size(692, 551);
            this.panelGraph.TabIndex = 15;
            // 
            // tbMaxDrawdown
            // 
            this.tbMaxDrawdown.BackColor = System.Drawing.Color.Black;
            this.tbMaxDrawdown.ForeColor = System.Drawing.Color.White;
            this.tbMaxDrawdown.Location = new System.Drawing.Point(140, 602);
            this.tbMaxDrawdown.Name = "tbMaxDrawdown";
            this.tbMaxDrawdown.ReadOnly = true;
            this.tbMaxDrawdown.Size = new System.Drawing.Size(100, 20);
            this.tbMaxDrawdown.TabIndex = 0;
            this.tbMaxDrawdown.TabStop = false;
            this.tbMaxDrawdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(12, 605);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(81, 13);
            this.label23.TabIndex = 2;
            this.label23.Text = "Max Drawdown";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(281, 8);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(159, 20);
            this.label18.TabIndex = 18;
            this.label18.Text = "Difference In Price";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(481, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 84);
            this.panel1.TabIndex = 19;
            // 
            // btnSuperSim
            // 
            this.btnSuperSim.BackColor = System.Drawing.Color.Black;
            this.btnSuperSim.ForeColor = System.Drawing.Color.White;
            this.btnSuperSim.Location = new System.Drawing.Point(140, 332);
            this.btnSuperSim.Name = "btnSuperSim";
            this.btnSuperSim.Size = new System.Drawing.Size(69, 22);
            this.btnSuperSim.TabIndex = 15;
            this.btnSuperSim.Text = "SuperSim";
            this.btnSuperSim.UseVisualStyleBackColor = false;
            this.btnSuperSim.Click += new System.EventHandler(this.btnSuperSim_Click);
            // 
            // numSimCount
            // 
            this.numSimCount.Location = new System.Drawing.Point(70, 333);
            this.numSimCount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numSimCount.Name = "numSimCount";
            this.numSimCount.Size = new System.Drawing.Size(60, 20);
            this.numSimCount.TabIndex = 14;
            this.numSimCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numSimCount.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // tbStopLoss2
            // 
            this.tbStopLoss2.Location = new System.Drawing.Point(193, 106);
            this.tbStopLoss2.Name = "tbStopLoss2";
            this.tbStopLoss2.Size = new System.Drawing.Size(47, 20);
            this.tbStopLoss2.TabIndex = 5;
            this.tbStopLoss2.Text = "0.3";
            this.tbStopLoss2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 134);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(28, 13);
            this.label19.TabIndex = 2;
            this.label19.Text = "R/R";
            // 
            // tbRR
            // 
            this.tbRR.Location = new System.Drawing.Point(140, 131);
            this.tbRR.Name = "tbRR";
            this.tbRR.Size = new System.Drawing.Size(47, 20);
            this.tbRR.TabIndex = 6;
            this.tbRR.Text = "2";
            this.tbRR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbSLPips2
            // 
            this.tbSLPips2.BackColor = System.Drawing.Color.Black;
            this.tbSLPips2.ForeColor = System.Drawing.Color.White;
            this.tbSLPips2.Location = new System.Drawing.Point(380, 35);
            this.tbSLPips2.Name = "tbSLPips2";
            this.tbSLPips2.Size = new System.Drawing.Size(64, 20);
            this.tbSLPips2.TabIndex = 12;
            this.tbSLPips2.TabStop = false;
            this.tbSLPips2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbTPPips2
            // 
            this.tbTPPips2.BackColor = System.Drawing.Color.Black;
            this.tbTPPips2.ForeColor = System.Drawing.Color.White;
            this.tbTPPips2.Location = new System.Drawing.Point(380, 61);
            this.tbTPPips2.Name = "tbTPPips2";
            this.tbTPPips2.Size = new System.Drawing.Size(64, 20);
            this.tbTPPips2.TabIndex = 12;
            this.tbTPPips2.TabStop = false;
            this.tbTPPips2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSupersimPlus
            // 
            this.btnSupersimPlus.BackColor = System.Drawing.Color.Black;
            this.btnSupersimPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupersimPlus.ForeColor = System.Drawing.Color.White;
            this.btnSupersimPlus.Location = new System.Drawing.Point(215, 332);
            this.btnSupersimPlus.Margin = new System.Windows.Forms.Padding(0);
            this.btnSupersimPlus.Name = "btnSupersimPlus";
            this.btnSupersimPlus.Size = new System.Drawing.Size(25, 22);
            this.btnSupersimPlus.TabIndex = 16;
            this.btnSupersimPlus.Text = "+";
            this.btnSupersimPlus.UseVisualStyleBackColor = false;
            this.btnSupersimPlus.Click += new System.EventHandler(this.btnSupersimPlus_Click);
            // 
            // tbConsWins
            // 
            this.tbConsWins.BackColor = System.Drawing.Color.Black;
            this.tbConsWins.ForeColor = System.Drawing.Color.White;
            this.tbConsWins.Location = new System.Drawing.Point(140, 436);
            this.tbConsWins.Name = "tbConsWins";
            this.tbConsWins.ReadOnly = true;
            this.tbConsWins.Size = new System.Drawing.Size(100, 20);
            this.tbConsWins.TabIndex = 0;
            this.tbConsWins.TabStop = false;
            this.tbConsWins.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbConsLosses
            // 
            this.tbConsLosses.BackColor = System.Drawing.Color.Black;
            this.tbConsLosses.ForeColor = System.Drawing.Color.White;
            this.tbConsLosses.Location = new System.Drawing.Point(140, 459);
            this.tbConsLosses.Name = "tbConsLosses";
            this.tbConsLosses.ReadOnly = true;
            this.tbConsLosses.Size = new System.Drawing.Size(100, 20);
            this.tbConsLosses.TabIndex = 0;
            this.tbConsLosses.TabStop = false;
            this.tbConsLosses.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 439);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Max Cons. Wins";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(12, 462);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(93, 13);
            this.label24.TabIndex = 2;
            this.label24.Text = "Max Cons. Losses";
            // 
            // tbOrderCap
            // 
            this.tbOrderCap.Location = new System.Drawing.Point(140, 229);
            this.tbOrderCap.Name = "tbOrderCap";
            this.tbOrderCap.Size = new System.Drawing.Size(100, 20);
            this.tbOrderCap.TabIndex = 10;
            this.tbOrderCap.Text = "5000";
            this.tbOrderCap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(12, 232);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(64, 13);
            this.label25.TabIndex = 24;
            this.label25.Text = "Order Cap $";
            // 
            // tbCapReached
            // 
            this.tbCapReached.BackColor = System.Drawing.Color.Black;
            this.tbCapReached.ForeColor = System.Drawing.Color.White;
            this.tbCapReached.Location = new System.Drawing.Point(140, 626);
            this.tbCapReached.Name = "tbCapReached";
            this.tbCapReached.ReadOnly = true;
            this.tbCapReached.Size = new System.Drawing.Size(100, 20);
            this.tbCapReached.TabIndex = 0;
            this.tbCapReached.TabStop = false;
            this.tbCapReached.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(12, 629);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(79, 13);
            this.label26.TabIndex = 2;
            this.label26.Text = "Cap Reached?";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(14, 336);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(50, 13);
            this.label27.TabIndex = 25;
            this.label27.Text = "Iterations";
            // 
            // tbEntriesPerHour
            // 
            this.tbEntriesPerHour.Location = new System.Drawing.Point(140, 254);
            this.tbEntriesPerHour.Name = "tbEntriesPerHour";
            this.tbEntriesPerHour.Size = new System.Drawing.Size(100, 20);
            this.tbEntriesPerHour.TabIndex = 11;
            this.tbEntriesPerHour.Text = "10";
            this.tbEntriesPerHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(12, 257);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(78, 13);
            this.label28.TabIndex = 24;
            this.label28.Text = "Entries / Hours";
            // 
            // tbHoursPerDay
            // 
            this.tbHoursPerDay.Location = new System.Drawing.Point(140, 279);
            this.tbHoursPerDay.Name = "tbHoursPerDay";
            this.tbHoursPerDay.Size = new System.Drawing.Size(100, 20);
            this.tbHoursPerDay.TabIndex = 12;
            this.tbHoursPerDay.Text = "8";
            this.tbHoursPerDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(12, 282);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(104, 13);
            this.label29.TabIndex = 24;
            this.label29.Text = "Trading Hours / Day";
            // 
            // tbDaysToComplete
            // 
            this.tbDaysToComplete.BackColor = System.Drawing.Color.Black;
            this.tbDaysToComplete.ForeColor = System.Drawing.Color.White;
            this.tbDaysToComplete.Location = new System.Drawing.Point(140, 364);
            this.tbDaysToComplete.Name = "tbDaysToComplete";
            this.tbDaysToComplete.ReadOnly = true;
            this.tbDaysToComplete.Size = new System.Drawing.Size(100, 20);
            this.tbDaysToComplete.TabIndex = 0;
            this.tbDaysToComplete.TabStop = false;
            this.tbDaysToComplete.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(12, 367);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(84, 13);
            this.label30.TabIndex = 2;
            this.label30.Text = "Average # Days";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(959, 659);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.tbHoursPerDay);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.tbEntriesPerHour);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.tbOrderCap);
            this.Controls.Add(this.numSimCount);
            this.Controls.Add(this.btnSupersimPlus);
            this.Controls.Add(this.btnSuperSim);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.panelGraph);
            this.Controls.Add(this.btnGetPercentVariance);
            this.Controls.Add(this.btnGetBreakEvenWin);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.tbDiff);
            this.Controls.Add(this.tbTPPips2);
            this.Controls.Add(this.tbTPPips);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.tbDiffPercent);
            this.Controls.Add(this.tbBreakEvenWinPips);
            this.Controls.Add(this.tbBreakEvenWinPercent);
            this.Controls.Add(this.tbSLPips2);
            this.Controls.Add(this.tbSLPips);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tbCapReached);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbMaxDrawdown);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbBalance);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbFeesPaid);
            this.Controls.Add(this.tbFeesPerOrder);
            this.Controls.Add(this.tbWinRate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbConsLosses);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbLosses);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbProfitsLosses);
            this.Controls.Add(this.tbLost);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbLeverage);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.tbConsWins);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDaysToComplete);
            this.Controls.Add(this.tbWins);
            this.Controls.Add(this.tbRiskPerTrade);
            this.Controls.Add(this.tbWon);
            this.Controls.Add(this.tbStopLoss2);
            this.Controls.Add(this.tbRR);
            this.Controls.Add(this.tbStopLoss);
            this.Controls.Add(this.tbNumberOfTrades);
            this.Controls.Add(this.tbAssetBasePrice);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.tbStartingBalance);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monte Carlo Trade Simulator";
            ((System.ComponentModel.ISupportInitialize)(this.numSimCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbStartingBalance;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbRiskPerTrade;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbWinRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbStopLoss;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbNumberOfTrades;
        private System.Windows.Forms.TextBox tbLeverage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbFeesPerOrder;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbWon;
        private System.Windows.Forms.TextBox tbWins;
        private System.Windows.Forms.TextBox tbLost;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbLosses;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbFeesPaid;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbProfitsLosses;
        private System.Windows.Forms.TextBox tbBalance;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbAssetBasePrice;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbSLPips;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tbTPPips;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox tbDiffPercent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDiff;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnGetPercentVariance;
        private System.Windows.Forms.TextBox tbBreakEvenWinPercent;
        private System.Windows.Forms.Button btnGetBreakEvenWin;
        private System.Windows.Forms.TextBox tbBreakEvenWinPips;
        private System.Windows.Forms.Panel panelGraph;
        private System.Windows.Forms.TextBox tbMaxDrawdown;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSuperSim;
        private System.Windows.Forms.NumericUpDown numSimCount;
        private System.Windows.Forms.TextBox tbStopLoss2;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tbRR;
        private System.Windows.Forms.TextBox tbSLPips2;
        private System.Windows.Forms.TextBox tbTPPips2;
        private System.Windows.Forms.Button btnSupersimPlus;
        private System.Windows.Forms.TextBox tbConsWins;
        private System.Windows.Forms.TextBox tbConsLosses;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox tbOrderCap;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox tbCapReached;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox tbEntriesPerHour;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox tbHoursPerDay;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox tbDaysToComplete;
        private System.Windows.Forms.Label label30;
    }
}

