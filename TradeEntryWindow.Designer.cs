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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TradeEntryWindow));
            this.panel8 = new System.Windows.Forms.Panel();
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
            this.tbTimeOfEntry = new System.Windows.Forms.TextBox();
            this.tbEntryPrice = new System.Windows.Forms.TextBox();
            this.tbTimeframe = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbLeverage = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbTimeOfExit = new System.Windows.Forms.TextBox();
            this.tbDate = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.tbRisk = new System.Windows.Forms.TextBox();
            this.tbTakeProfit = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.tbStoploss = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbDirection = new System.Windows.Forms.ComboBox();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel8.Controls.Add(this.btnCancel);
            this.panel8.Controls.Add(this.btnOK);
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
            this.panel8.Controls.Add(this.tbTimeOfEntry);
            this.panel8.Controls.Add(this.tbEntryPrice);
            this.panel8.Controls.Add(this.tbTimeframe);
            this.panel8.Controls.Add(this.label1);
            this.panel8.Controls.Add(this.tbLeverage);
            this.panel8.Controls.Add(this.label7);
            this.panel8.Controls.Add(this.label29);
            this.panel8.Controls.Add(this.label5);
            this.panel8.Controls.Add(this.tbTimeOfExit);
            this.panel8.Controls.Add(this.tbDate);
            this.panel8.Controls.Add(this.label28);
            this.panel8.Controls.Add(this.tbRisk);
            this.panel8.Controls.Add(this.tbTakeProfit);
            this.panel8.Controls.Add(this.label25);
            this.panel8.Controls.Add(this.label2);
            this.panel8.Controls.Add(this.label4);
            this.panel8.Controls.Add(this.label19);
            this.panel8.Controls.Add(this.tbStoploss);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Controls.Add(this.label3);
            this.panel8.Controls.Add(this.label9);
            this.panel8.Location = new System.Drawing.Point(12, 12);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(532, 582);
            this.panel8.TabIndex = 29;
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
            this.cbResult.Location = new System.Drawing.Point(110, 288);
            this.cbResult.Name = "cbResult";
            this.cbResult.Size = new System.Drawing.Size(388, 21);
            this.cbResult.TabIndex = 14;
            // 
            // tbExitPrice
            // 
            this.tbExitPrice.Location = new System.Drawing.Point(110, 268);
            this.tbExitPrice.Name = "tbExitPrice";
            this.tbExitPrice.Size = new System.Drawing.Size(388, 20);
            this.tbExitPrice.TabIndex = 13;
            this.tbExitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 331);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Reasoning";
            // 
            // tbReasoning
            // 
            this.tbReasoning.Location = new System.Drawing.Point(110, 329);
            this.tbReasoning.Multiline = true;
            this.tbReasoning.Name = "tbReasoning";
            this.tbReasoning.Size = new System.Drawing.Size(388, 202);
            this.tbReasoning.TabIndex = 16;
            this.tbReasoning.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 311);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "Balance";
            // 
            // tbBalance
            // 
            this.tbBalance.Location = new System.Drawing.Point(110, 309);
            this.tbBalance.Name = "tbBalance";
            this.tbBalance.Size = new System.Drawing.Size(388, 20);
            this.tbBalance.TabIndex = 15;
            this.tbBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 271);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Exit Price";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 291);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Result";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(5, 10);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(55, 13);
            this.label17.TabIndex = 2;
            this.label17.Text = "Exchange";
            // 
            // tbSymbol
            // 
            this.tbSymbol.Location = new System.Drawing.Point(110, 27);
            this.tbSymbol.Name = "tbSymbol";
            this.tbSymbol.Size = new System.Drawing.Size(388, 20);
            this.tbSymbol.TabIndex = 1;
            this.tbSymbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbExchange
            // 
            this.tbExchange.Location = new System.Drawing.Point(110, 7);
            this.tbExchange.Name = "tbExchange";
            this.tbExchange.Size = new System.Drawing.Size(388, 20);
            this.tbExchange.TabIndex = 0;
            this.tbExchange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbUnits
            // 
            this.tbUnits.Location = new System.Drawing.Point(110, 148);
            this.tbUnits.Name = "tbUnits";
            this.tbUnits.Size = new System.Drawing.Size(388, 20);
            this.tbUnits.TabIndex = 7;
            this.tbUnits.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbTimeOfEntry
            // 
            this.tbTimeOfEntry.Location = new System.Drawing.Point(110, 87);
            this.tbTimeOfEntry.Name = "tbTimeOfEntry";
            this.tbTimeOfEntry.Size = new System.Drawing.Size(388, 20);
            this.tbTimeOfEntry.TabIndex = 4;
            this.tbTimeOfEntry.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbEntryPrice
            // 
            this.tbEntryPrice.Location = new System.Drawing.Point(110, 128);
            this.tbEntryPrice.Name = "tbEntryPrice";
            this.tbEntryPrice.Size = new System.Drawing.Size(388, 20);
            this.tbEntryPrice.TabIndex = 6;
            this.tbEntryPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbTimeframe
            // 
            this.tbTimeframe.Location = new System.Drawing.Point(110, 47);
            this.tbTimeframe.Name = "tbTimeframe";
            this.tbTimeframe.Size = new System.Drawing.Size(388, 20);
            this.tbTimeframe.TabIndex = 2;
            this.tbTimeframe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Symbol";
            // 
            // tbLeverage
            // 
            this.tbLeverage.Location = new System.Drawing.Point(110, 168);
            this.tbLeverage.Name = "tbLeverage";
            this.tbLeverage.Size = new System.Drawing.Size(388, 20);
            this.tbLeverage.TabIndex = 8;
            this.tbLeverage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Units";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(5, 251);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(64, 13);
            this.label29.TabIndex = 24;
            this.label29.Text = "Time Of Exit";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Time Of Entry";
            // 
            // tbTimeOfExit
            // 
            this.tbTimeOfExit.Location = new System.Drawing.Point(110, 248);
            this.tbTimeOfExit.Name = "tbTimeOfExit";
            this.tbTimeOfExit.Size = new System.Drawing.Size(388, 20);
            this.tbTimeOfExit.TabIndex = 12;
            this.tbTimeOfExit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbDate
            // 
            this.tbDate.Location = new System.Drawing.Point(110, 67);
            this.tbDate.Name = "tbDate";
            this.tbDate.Size = new System.Drawing.Size(388, 20);
            this.tbDate.TabIndex = 3;
            this.tbDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(5, 232);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(91, 13);
            this.label28.TabIndex = 24;
            this.label28.Text = "Take Profit, Ticks";
            // 
            // tbRisk
            // 
            this.tbRisk.Location = new System.Drawing.Point(110, 188);
            this.tbRisk.Name = "tbRisk";
            this.tbRisk.Size = new System.Drawing.Size(388, 20);
            this.tbRisk.TabIndex = 9;
            this.tbRisk.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbTakeProfit
            // 
            this.tbTakeProfit.Location = new System.Drawing.Point(110, 228);
            this.tbTakeProfit.Name = "tbTakeProfit";
            this.tbTakeProfit.Size = new System.Drawing.Size(388, 20);
            this.tbTakeProfit.TabIndex = 11;
            this.tbTakeProfit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(5, 211);
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
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(5, 131);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(58, 13);
            this.label19.TabIndex = 2;
            this.label19.Text = "Entry Price";
            // 
            // tbStoploss
            // 
            this.tbStoploss.Location = new System.Drawing.Point(110, 208);
            this.tbStoploss.Name = "tbStoploss";
            this.tbStoploss.Size = new System.Drawing.Size(388, 20);
            this.tbStoploss.TabIndex = 10;
            this.tbStoploss.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 171);
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 191);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Risk %";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(423, 543);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 17;
            this.btnOK.Text = "Add";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(342, 543);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Direction";
            // 
            // cbDirection
            // 
            this.cbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDirection.FormattingEnabled = true;
            this.cbDirection.Items.AddRange(new object[] {
            "Long",
            "Short"});
            this.cbDirection.Location = new System.Drawing.Point(110, 107);
            this.cbDirection.Name = "cbDirection";
            this.cbDirection.Size = new System.Drawing.Size(388, 21);
            this.cbDirection.TabIndex = 5;
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
        private System.Windows.Forms.TextBox tbTimeOfEntry;
        private System.Windows.Forms.TextBox tbEntryPrice;
        private System.Windows.Forms.TextBox tbTimeframe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbLeverage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbTimeOfExit;
        private System.Windows.Forms.TextBox tbDate;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox tbRisk;
        private System.Windows.Forms.TextBox tbTakeProfit;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tbStoploss;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbResult;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbDirection;
        private System.Windows.Forms.Label label4;
    }
}