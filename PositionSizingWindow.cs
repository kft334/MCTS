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

        public PositionSizingWindow(decimal balance, decimal price, decimal lossPercent, decimal entryFee, decimal exitFee, int sigX, int stepSz, int rows, int ulev, int sizingType)
        {
            InitializeComponent();

            this.Text = "Position Sizing";

            string formattedOutput = String.Empty;

            this.Text = "[Bal:$" + (balance / ulev) + "] [~Asset$:$" + price + "] [Lev:" + ulev + "] [Loss:" + lossPercent * 100 + "%]" + Environment.NewLine + Environment.NewLine;

            SourceGrid.Grid grid = new SourceGrid.Grid();

            panel1.Controls.Add(grid);
            
            grid.BorderStyle = BorderStyle.FixedSingle;

            grid.ColumnsCount = 4;
            grid.FixedRows = 1;
            grid.Rows.Insert(0);

            SourceGrid.Cells.Views.ColumnHeader header = new SourceGrid.Cells.Views.ColumnHeader();
            header.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            header.BackColor = Color.DarkGray;
            header.Font = new Font(grid.Font, FontStyle.Bold);

            SourceGrid.Cells.Views.Cell centered = new SourceGrid.Cells.Views.Cell();
            centered.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;

            grid[0, 0] = new SourceGrid.Cells.ColumnHeader("#") { View = header };
            grid[0, 1] = new SourceGrid.Cells.ColumnHeader("Stop") { View = header };
            grid[0, 2] = new SourceGrid.Cells.ColumnHeader("Units") { View = header };
            grid[0, 3] = new SourceGrid.Cells.ColumnHeader("Acc%") { View = header };

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

                if (sizingType == 1)
                    SizingTuples.Add(new Tuple<decimal, decimal>(diff, GetPositionSize(balance, price, lossPercent, entryFee, exitFee, diff, ulev)));
                if (sizingType == 2)
                    SizingTuples.Add(new Tuple<decimal, decimal>(diff, GetPositionSizeAccountPercentage(balance, price, lossPercent, entryFee, exitFee, diff, ulev)));

                grid.Rows.Insert(i);

                grid[i, 0] = new SourceGrid.Cells.Cell(i);
                grid[i, 0].View = centered;

                grid[i, 1] = new SourceGrid.Cells.Cell(diff);
                grid[i, 1].View = centered;

                grid[i, 2] = new SourceGrid.Cells.Cell(GetPositionSize(balance, price, lossPercent, entryFee, exitFee, diff, ulev));
                grid[i, 2].View = centered;

                grid[i, 3] = new SourceGrid.Cells.Cell(GetPositionSizeAccountPercentage(balance, price, lossPercent, entryFee, exitFee, diff, ulev));
                grid[i, 3].View = centered;
            }

            grid.AutoSizeCells();
            grid.Columns.AutoSize(false);

            grid.Left = 10;
            grid.Top = 10;
            grid.Height = panel1.Height - 40;
            grid.BorderStyle = BorderStyle.None;
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
