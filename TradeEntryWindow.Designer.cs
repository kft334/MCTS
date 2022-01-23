namespace Trade_Simulator
{
    partial class TradeEntryWindow
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
            this.components = new System.ComponentModel.Container();
            gTimePickerControl.TimeColors timeColors1 = new gTimePickerControl.TimeColors();
            gTimePickerControl.TimeColors timeColors2 = new gTimePickerControl.TimeColors();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TradeEntryWindow));
            this.panel8 = new System.Windows.Forms.Panel();
            this.tbTimeOfExit = new gTimePickerControl.gTimePicker();
            this.tbTimeOfEntry = new gTimePickerControl.gTimePicker();
            this.tbDate = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.cbTimeframe = new System.Windows.Forms.ComboBox();
            this.cbDirection = new System.Windows.Forms.ComboBox();
            this.cbResult = new System.Windows.Forms.ComboBox();
            this.tbExitPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbReasoning = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbBalance = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tbSymbol = new System.Windows.Forms.TextBox();
            this.tbExchange = new System.Windows.Forms.TextBox();
            this.tbUnits = new System.Windows.Forms.TextBox();
            this.tbEntryPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbLeverage = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.tbTakeProfit = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.tbStoploss = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel8.Controls.Add(this.tbTimeOfExit);
            this.panel8.Controls.Add(this.tbTimeOfEntry);
            this.panel8.Controls.Add(this.tbDate);
            this.panel8.Controls.Add(this.btnCancel);
            this.panel8.Controls.Add(this.btnOK);
            this.panel8.Controls.Add(this.cbTimeframe);
            this.panel8.Controls.Add(this.cbDirection);
            this.panel8.Controls.Add(this.cbResult);
            this.panel8.Controls.Add(this.tbExitPrice);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Controls.Add(this.tbReasoning);
            this.panel8.Controls.Add(this.label10);
            this.panel8.Controls.Add(this.tbBalance);
            this.panel8.Controls.Add(this.label11);
            this.panel8.Controls.Add(this.label12);
            this.panel8.Controls.Add(this.label17);
            this.panel8.Controls.Add(this.tbSymbol);
            this.panel8.Controls.Add(this.tbExchange);
            this.panel8.Controls.Add(this.tbUnits);
            this.panel8.Controls.Add(this.tbEntryPrice);
            this.panel8.Controls.Add(this.label1);
            this.panel8.Controls.Add(this.tbLeverage);
            this.panel8.Controls.Add(this.label7);
            this.panel8.Controls.Add(this.label29);
            this.panel8.Controls.Add(this.label5);
            this.panel8.Controls.Add(this.label28);
            this.panel8.Controls.Add(this.tbTakeProfit);
            this.panel8.Controls.Add(this.label25);
            this.panel8.Controls.Add(this.label2);
            this.panel8.Controls.Add(this.label4);
            this.panel8.Controls.Add(this.label19);
            this.panel8.Controls.Add(this.tbStoploss);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Controls.Add(this.label3);
            this.panel8.Location = new System.Drawing.Point(12, 12);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(532, 582);
            this.panel8.TabIndex = 29;
            // 
            // tbTimeOfExit
            // 
            this.tbTimeOfExit.ButtonForeColor = System.Drawing.Color.DarkSlateBlue;
            this.tbTimeOfExit.Hr24 = true;
            this.tbTimeOfExit.Location = new System.Drawing.Point(110, 221);
            this.tbTimeOfExit.Name = "tbTimeOfExit";
            this.tbTimeOfExit.NullColorA = System.Drawing.Color.LightSteelBlue;
            this.tbTimeOfExit.NullColorB = System.Drawing.Color.White;
            this.tbTimeOfExit.NullHatchStyle = System.Drawing.Drawing2D.HatchStyle.WideDownwardDiagonal;
            this.tbTimeOfExit.NullTextColor = System.Drawing.Color.Black;
            this.tbTimeOfExit.NullTextInFront = false;
            this.tbTimeOfExit.ShowMidMins = true;
            this.tbTimeOfExit.Size = new System.Drawing.Size(388, 23);
            this.tbTimeOfExit.TabIndex = 36;
            this.tbTimeOfExit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbTimeOfExit.TextBackColor = System.Drawing.Color.White;
            this.tbTimeOfExit.TextFont = new System.Drawing.Font("Arial", 10F);
            this.tbTimeOfExit.TextForeColor = System.Drawing.Color.Black;
            this.tbTimeOfExit.Time = "07:00";
            this.tbTimeOfExit.TimeAMPM = gTimePickerControl.gTimePickerCntrl.eTimeAMPM.AM;
            timeColors1.BackGround = System.Drawing.Color.White;
            timeColors1.Box = System.Drawing.Color.White;
            timeColors1.DisplayTime = System.Drawing.Color.Red;
            timeColors1.FaceInner = System.Drawing.Color.White;
            timeColors1.FaceOuter = System.Drawing.Color.LightGoldenrodYellow;
            timeColors1.FrameInner = System.Drawing.Color.AliceBlue;
            timeColors1.FrameOuter = System.Drawing.Color.CornflowerBlue;
            timeColors1.Hour = System.Drawing.Color.DarkBlue;
            timeColors1.HourHand = System.Drawing.Color.DarkBlue;
            timeColors1.Minute = System.Drawing.Color.Blue;
            timeColors1.MinuteHand = System.Drawing.Color.OrangeRed;
            timeColors1.MinutePlus = System.Drawing.Color.LightSlateGray;
            timeColors1.TimeAMPM_OFF = System.Drawing.Color.LightSteelBlue;
            timeColors1.TimeAMPM_ON = System.Drawing.Color.MediumBlue;
            this.tbTimeOfExit.TimeColors = timeColors1;
            this.tbTimeOfExit.TrueHour = true;
            // 
            // tbTimeOfEntry
            // 
            this.tbTimeOfEntry.ButtonForeColor = System.Drawing.Color.DarkSlateBlue;
            this.tbTimeOfEntry.Hr24 = true;
            this.tbTimeOfEntry.Location = new System.Drawing.Point(110, 85);
            this.tbTimeOfEntry.Name = "tbTimeOfEntry";
            this.tbTimeOfEntry.NullColorA = System.Drawing.Color.LightSteelBlue;
            this.tbTimeOfEntry.NullColorB = System.Drawing.Color.White;
            this.tbTimeOfEntry.NullHatchStyle = System.Drawing.Drawing2D.HatchStyle.WideDownwardDiagonal;
            this.tbTimeOfEntry.NullTextColor = System.Drawing.Color.Black;
            this.tbTimeOfEntry.NullTextInFront = false;
            this.tbTimeOfEntry.ShowMidMins = true;
            this.tbTimeOfEntry.Size = new System.Drawing.Size(388, 23);
            this.tbTimeOfEntry.TabIndex = 36;
            this.tbTimeOfEntry.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbTimeOfEntry.TextBackColor = System.Drawing.Color.White;
            this.tbTimeOfEntry.TextFont = new System.Drawing.Font("Arial", 10F);
            this.tbTimeOfEntry.TextForeColor = System.Drawing.Color.Black;
            this.tbTimeOfEntry.Time = "09:00";
            this.tbTimeOfEntry.TimeAMPM = gTimePickerControl.gTimePickerCntrl.eTimeAMPM.AM;
            timeColors2.BackGround = System.Drawing.Color.White;
            timeColors2.Box = System.Drawing.Color.White;
            timeColors2.DisplayTime = System.Drawing.Color.Red;
            timeColors2.FaceInner = System.Drawing.Color.White;
            timeColors2.FaceOuter = System.Drawing.Color.LightGoldenrodYellow;
            timeColors2.FrameInner = System.Drawing.Color.AliceBlue;
            timeColors2.FrameOuter = System.Drawing.Color.CornflowerBlue;
            timeColors2.Hour = System.Drawing.Color.DarkBlue;
            timeColors2.HourHand = System.Drawing.Color.DarkBlue;
            timeColors2.Minute = System.Drawing.Color.Blue;
            timeColors2.MinuteHand = System.Drawing.Color.OrangeRed;
            timeColors2.MinutePlus = System.Drawing.Color.LightSlateGray;
            timeColors2.TimeAMPM_OFF = System.Drawing.Color.LightSteelBlue;
            timeColors2.TimeAMPM_ON = System.Drawing.Color.MediumBlue;
            this.tbTimeOfEntry.TimeColors = timeColors2;
            this.tbTimeOfEntry.TrueHour = true;
            // 
            // tbDate
            // 
            this.tbDate.Location = new System.Drawing.Point(110, 66);
            this.tbDate.Name = "tbDate";
            this.tbDate.Size = new System.Drawing.Size(388, 20);
            this.tbDate.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(342, 518);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(423, 518);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 17;
            this.btnOK.Text = "Add";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cbTimeframe
            // 
            this.cbTimeframe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTimeframe.FormattingEnabled = true;
            this.cbTimeframe.Items.AddRange(new object[] {
            "1 Min",
            "2 Mins",
            "3 Mins",
            "5 Mins",
            "10 Mins",
            "15 Mins",
            "30 Mins",
            "1 Hour",
            "2 Hours",
            "4 Hours",
            "8 Hours",
            "12 Hours",
            "1 Day",
            "3 Days",
            "1 Week",
            "1 Month"});
            this.cbTimeframe.Location = new System.Drawing.Point(110, 47);
            this.cbTimeframe.Name = "cbTimeframe";
            this.cbTimeframe.Size = new System.Drawing.Size(388, 21);
            this.cbTimeframe.TabIndex = 5;
            // 
            // cbDirection
            // 
            this.cbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDirection.FormattingEnabled = true;
            this.cbDirection.Items.AddRange(new object[] {
            "Long",
            "Short"});
            this.cbDirection.Location = new System.Drawing.Point(110, 106);
            this.cbDirection.Name = "cbDirection";
            this.cbDirection.Size = new System.Drawing.Size(388, 21);
            this.cbDirection.TabIndex = 5;
            // 
            // cbResult
            // 
            this.cbResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbResult.FormattingEnabled = true;
            this.cbResult.Items.AddRange(new object[] {
            "Win",
            "Partial Win",
            "Partial Loss",
            "Loss"});
            this.cbResult.Location = new System.Drawing.Point(110, 263);
            this.cbResult.Name = "cbResult";
            this.cbResult.Size = new System.Drawing.Size(388, 21);
            this.cbResult.TabIndex = 14;
            // 
            // tbExitPrice
            // 
            this.tbExitPrice.Location = new System.Drawing.Point(110, 243);
            this.tbExitPrice.Name = "tbExitPrice";
            this.tbExitPrice.Size = new System.Drawing.Size(388, 20);
            this.tbExitPrice.TabIndex = 13;
            this.tbExitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 307);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Reasoning";
            // 
            // tbReasoning
            // 
            this.tbReasoning.Location = new System.Drawing.Point(110, 303);
            this.tbReasoning.Multiline = true;
            this.tbReasoning.Name = "tbReasoning";
            this.tbReasoning.Size = new System.Drawing.Size(388, 202);
            this.tbReasoning.TabIndex = 16;
            this.tbReasoning.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 288);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "Balance";
            // 
            // tbBalance
            // 
            this.tbBalance.Location = new System.Drawing.Point(110, 284);
            this.tbBalance.Name = "tbBalance";
            this.tbBalance.Size = new System.Drawing.Size(388, 20);
            this.tbBalance.TabIndex = 15;
            this.tbBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 247);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Exit Price";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 267);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Result";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(5, 12);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(55, 13);
            this.label17.TabIndex = 2;
            this.label17.Text = "Exchange";
            // 
            // tbSymbol
            // 
            this.tbSymbol.Location = new System.Drawing.Point(110, 28);
            this.tbSymbol.Name = "tbSymbol";
            this.tbSymbol.Size = new System.Drawing.Size(388, 20);
            this.tbSymbol.TabIndex = 1;
            this.tbSymbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbExchange
            // 
            this.tbExchange.Location = new System.Drawing.Point(110, 9);
            this.tbExchange.Name = "tbExchange";
            this.tbExchange.Size = new System.Drawing.Size(388, 20);
            this.tbExchange.TabIndex = 0;
            this.tbExchange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbUnits
            // 
            this.tbUnits.Location = new System.Drawing.Point(110, 145);
            this.tbUnits.Name = "tbUnits";
            this.tbUnits.Size = new System.Drawing.Size(388, 20);
            this.tbUnits.TabIndex = 7;
            this.tbUnits.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbEntryPrice
            // 
            this.tbEntryPrice.Location = new System.Drawing.Point(110, 126);
            this.tbEntryPrice.Name = "tbEntryPrice";
            this.tbEntryPrice.Size = new System.Drawing.Size(388, 20);
            this.tbEntryPrice.TabIndex = 6;
            this.tbEntryPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Symbol";
            // 
            // tbLeverage
            // 
            this.tbLeverage.Location = new System.Drawing.Point(110, 164);
            this.tbLeverage.Name = "tbLeverage";
            this.tbLeverage.Size = new System.Drawing.Size(388, 20);
            this.tbLeverage.TabIndex = 8;
            this.tbLeverage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Units";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(5, 226);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(64, 13);
            this.label29.TabIndex = 24;
            this.label29.Text = "Time Of Exit";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Time Of Entry";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(5, 206);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(91, 13);
            this.label28.TabIndex = 24;
            this.label28.Text = "Take Profit, Ticks";
            // 
            // tbTakeProfit
            // 
            this.tbTakeProfit.Location = new System.Drawing.Point(110, 202);
            this.tbTakeProfit.Name = "tbTakeProfit";
            this.tbTakeProfit.Size = new System.Drawing.Size(388, 20);
            this.tbTakeProfit.TabIndex = 11;
            this.tbTakeProfit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(5, 187);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(86, 13);
            this.label25.TabIndex = 24;
            this.label25.Text = "Stop Loss, Ticks";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Timeframe";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Direction";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(5, 129);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(58, 13);
            this.label19.TabIndex = 2;
            this.label19.Text = "Entry Price";
            // 
            // tbStoploss
            // 
            this.tbStoploss.Location = new System.Drawing.Point(110, 183);
            this.tbStoploss.Name = "tbStoploss";
            this.tbStoploss.Size = new System.Drawing.Size(388, 20);
            this.tbStoploss.TabIndex = 10;
            this.tbStoploss.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Leverage";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Date";
            // 
            // TradeEntryWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 602);
            this.Controls.Add(this.panel8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TradeEntryWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trade Entry";
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox tbExitPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbReasoning;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbBalance;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbSymbol;
        private System.Windows.Forms.TextBox tbExchange;
        private System.Windows.Forms.TextBox tbUnits;
        private System.Windows.Forms.TextBox tbEntryPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbLeverage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox tbTakeProfit;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tbStoploss;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbResult;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbDirection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker tbDate;
        private gTimePickerControl.gTimePicker tbTimeOfEntry;
        private gTimePickerControl.gTimePicker tbTimeOfExit;
        private System.Windows.Forms.ComboBox cbTimeframe;
    }
}