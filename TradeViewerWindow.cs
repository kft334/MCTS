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
    public partial class TradeViewerWindow : Form
    {
        public List<Trade> AllTrades;

        public TradeViewerWindow(List<Trade> trades)
        {
            InitializeComponent();

            AllTrades = trades;

            SourceGrid.Grid grid = new SourceGrid.Grid();

            panelMain.Controls.Add(grid);

            grid.Dock = DockStyle.Fill;
            grid.BorderStyle = BorderStyle.FixedSingle;

            grid.ColumnsCount = 18;
            grid.FixedRows = 1;
            grid.Rows.Insert(0);

            SourceGrid.Cells.Views.ColumnHeader header = new SourceGrid.Cells.Views.ColumnHeader();
            header.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            header.BackColor = Color.DarkGray;
            header.Font = new Font(grid.Font, FontStyle.Bold);

            SourceGrid.Cells.Views.Cell winCell = new SourceGrid.Cells.Views.Cell();
            winCell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            winCell.BackColor = Color.Green;
            SourceGrid.Cells.Views.Cell winPartialCell = new SourceGrid.Cells.Views.Cell();
            winPartialCell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            winPartialCell.BackColor = Color.LightGreen; 
            SourceGrid.Cells.Views.Cell lossPartialCell = new SourceGrid.Cells.Views.Cell();
            lossPartialCell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            lossPartialCell.BackColor = Color.LightPink; 
            SourceGrid.Cells.Views.Cell lossCell = new SourceGrid.Cells.Views.Cell();
            lossCell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            lossCell.BackColor = Color.Red;

            SourceGrid.Cells.Views.Cell centered = new SourceGrid.Cells.Views.Cell();
            centered.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;

            SourceGrid.Cells.Views.Cell left = new SourceGrid.Cells.Views.Cell();
            left.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;

            grid[0, 0] = new SourceGrid.Cells.ColumnHeader("#") { View = header };
            grid[0, 1] = new SourceGrid.Cells.ColumnHeader("Exchange") { View = header };
            grid[0, 2] = new SourceGrid.Cells.ColumnHeader("Symbol") { View = header };
            grid[0, 3] = new SourceGrid.Cells.ColumnHeader("Timeframe") { View = header };
            grid[0, 4] = new SourceGrid.Cells.ColumnHeader("Date") { View = header };
            grid[0, 5] = new SourceGrid.Cells.ColumnHeader("TimeOfEntry") { View = header };
            grid[0, 6] = new SourceGrid.Cells.ColumnHeader("Direction") { View = header };
            grid[0, 7] = new SourceGrid.Cells.ColumnHeader("EntryPrice") { View = header };
            grid[0, 8] = new SourceGrid.Cells.ColumnHeader("Units") { View = header };
            grid[0, 9] = new SourceGrid.Cells.ColumnHeader("Leverage") { View = header };
            grid[0, 10] = new SourceGrid.Cells.ColumnHeader("Risk%") { View = header };
            grid[0, 11] = new SourceGrid.Cells.ColumnHeader("SL") { View = header };
            grid[0, 12] = new SourceGrid.Cells.ColumnHeader("TP") { View = header };
            grid[0, 13] = new SourceGrid.Cells.ColumnHeader("TimeOfExit") { View = header };
            grid[0, 14] = new SourceGrid.Cells.ColumnHeader("ExitPrice") { View = header };
            grid[0, 15] = new SourceGrid.Cells.ColumnHeader("Result") { View = header };
            grid[0, 16] = new SourceGrid.Cells.ColumnHeader("Balance") { View = header };
            grid[0, 17] = new SourceGrid.Cells.ColumnHeader("Reasoning") { View = header };

            for (int i = 0; i < trades.Count; i++)
            {
                grid.Rows.Insert(i + 1);

                Trade trade = trades.ElementAt(i);

                grid[i + 1, 0] = new SourceGrid.Cells.Cell(i + 1);
                grid[i + 1, 0].View = centered;
                
                grid[i + 1, 1] = new SourceGrid.Cells.Cell(trade.Exchange);
                grid[i + 1, 1].View = centered;
                
                grid[i + 1, 2] = new SourceGrid.Cells.Cell(trade.Symbol);
                grid[i + 1, 2].View = centered;
                
                grid[i + 1, 3] = new SourceGrid.Cells.Cell(trade.Timeframe);
                grid[i + 1, 3].View = centered;
                
                grid[i + 1, 4] = new SourceGrid.Cells.Cell(trade.Date);
                grid[i + 1, 4].View = centered;
                
                grid[i + 1, 5] = new SourceGrid.Cells.Cell(trade.TimeOfEntry);
                grid[i + 1, 5].View = centered;
                
                grid[i + 1, 6] = new SourceGrid.Cells.Cell(trade.Direction);
                grid[i + 1, 6].View = centered;
                
                grid[i + 1, 7] = new SourceGrid.Cells.Cell(trade.EntryPrice);
                grid[i + 1, 7].View = centered;
                
                grid[i + 1, 8] = new SourceGrid.Cells.Cell(trade.Units);
                grid[i + 1, 8].View = centered;
                
                grid[i + 1, 9] = new SourceGrid.Cells.Cell(trade.Leverage);
                grid[i + 1, 9].View = centered;
                
                grid[i + 1, 10] = new SourceGrid.Cells.Cell(trade.Risk + "%");
                grid[i + 1, 10].View = centered;
                
                grid[i + 1, 11] = new SourceGrid.Cells.Cell(trade.Stoploss);
                grid[i + 1, 11].View = centered;
                
                grid[i + 1, 12] = new SourceGrid.Cells.Cell(trade.TakeProfit);
                grid[i + 1, 12].View = centered;
                
                grid[i + 1, 13] = new SourceGrid.Cells.Cell(trade.TimeOfExit);
                grid[i + 1, 13].View = centered;
                
                grid[i + 1, 14] = new SourceGrid.Cells.Cell(trade.ExitPrice);
                grid[i + 1, 14].View = centered;

                grid[i + 1, 15] = new SourceGrid.Cells.Cell(trade.Result);

                if (trade.Result == "Win")
                    grid[i + 1, 15].View = winCell;
                else if (trade.Result == "Partial Win")
                    grid[i + 1, 15].View = winPartialCell;
                else if (trade.Result == "Partial Loss")
                    grid[i + 1, 15].View = lossPartialCell;
                else if (trade.Result == "Loss")
                    grid[i + 1, 15].View =lossCell;

                grid[i + 1, 16] = new SourceGrid.Cells.Cell(trade.Balance);
                grid[i + 1, 16].View = centered;

                grid[i + 1, 17] = new SourceGrid.Cells.Cell(trade.Reasoning);
                grid[i + 1, 17].View = left;
            }

            grid.AutoSizeCells();
            grid.Columns.AutoSize(false);
        }
    }
}
