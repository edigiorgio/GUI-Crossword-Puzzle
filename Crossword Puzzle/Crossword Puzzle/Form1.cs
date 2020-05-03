using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Crossword_Puzzle
{
    public partial class Form1 : Form
    {
        Clues clue_window = new Clues();
        List<id_cells> idc = new List<id_cells>();
        public String puzzle_file = Application.StartupPath + "\\Puzzles\\Puzzle1.PZL";
        bool solve = false;

        public Form1()
        {
            buildWordList();
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buildWordList()
        {
            String line = "";
            using (StreamReader s = new StreamReader(puzzle_file))
            {
                line = s.ReadLine(); //ignores first line
                while ((line = s.ReadLine()) != null)
                {
                    try
                    {
                        String[] l = line.Split('|');
                        idc.Add(new id_cells(Int32.Parse(l[0]), Int32.Parse(l[1]), l[2], l[3], l[4], l[5]));
                        clue_window.clueTable.Rows.Add(new String[] { l[3], l[2], l[5] });
                    }
                    catch
                    {
                        MessageBox.Show("Error", "Your files didn't parse correctly.");
                    }
                }
            }
        }
        private void solveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            solve = true;
            foreach (id_cells i in idc)
            {
                
                int startCol = i.x;
                int startRow = i.y;
                char[] Word = i.word.ToCharArray();
                int total = i.word.Count();
                for (int j = 0; j < total; j++)
                {

                    if (i.direction.ToUpper() == "ACROSS")
                    {
                        FormatCell(startRow, startCol + j, Word[j].ToString());
                    }
                    if (i.direction.ToUpper() == "DOWN")
                    {
                        FormatCell(startRow + j, startCol, Word[j].ToString());
                    }
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Eric DiGiorgio\nVersion 1.0\nEmail Suggestions to edigi*****@bucs.fsw.edu", "Version 1.0");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeBoard();
            clue_window.SetDesktopLocation(this.Location.X + this.Width + 1, this.Location.Y);
            clue_window.StartPosition = FormStartPosition.Manual;

            clue_window.Show();
            clue_window.clueTable.AutoResizeColumn(2);
        }
        private void InitializeBoard()
        {
            board.BackgroundColor = Color.White;
            board.DefaultCellStyle.BackColor = Color.White;
            board.GridColor = Color.White;

            for (int i = 0; i < 21; i++)
            {
                board.Rows.Add();
            }

            foreach (DataGridViewColumn c in board.Columns)
            {
                c.Width = board.Width / board.Columns.Count;
            }

            foreach (DataGridViewRow r in board.Rows)
            {
                r.Height = board.Height / board.Rows.Count;
            }

            for (int row = 0; row < board.Rows.Count; row++)
            {
                for (int col = 0; col < board.Columns.Count; col++)
                {
                    board[col, row].ReadOnly = true;
                }
            }
            foreach (id_cells i in idc)
            {
                int startCol = i.x;
                int startRow = i.y;
                char[] Word = i.word.ToCharArray();

                for (int j = 0; j < Word.Length; j++)
                {
                    if (i.direction.ToUpper() == "ACROSS")
                    {
                        FormatCell(startRow, startCol + j, Word[j].ToString());
                    }
                    if (i.direction.ToUpper() == "DOWN")
                    {
                        FormatCell(startRow + j, startCol, Word[j].ToString());
                    }

                }
            }
        }
        private void FormatCell(int row, int col, string letter)
        {
            DataGridViewCell c = board[col, row];
            c.Style.BackColor = Color.Cyan;
            c.ReadOnly = false;
            c.Style.SelectionBackColor = Color.Magenta;
            c.Tag = letter;
            if (solve)
            {
                try
                {
                    c.Value = letter;
                    c.Style.BackColor = Color.CornflowerBlue;
                }
                catch
                {

                }
            }
        }

        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            clue_window.SetDesktopLocation(this.Location.X + this.Width + 1, this.Location.Y);

        }

        private void board_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                board[e.ColumnIndex, e.RowIndex].Value = board[e.ColumnIndex, e.RowIndex].Value.ToString().ToUpper();
            }
            catch
            {

            }
            try
            {
                if (board[e.ColumnIndex, e.RowIndex].Value.ToString().Length > 1)
                {
                    board[e.ColumnIndex, e.RowIndex].Value = board[e.ColumnIndex, e.RowIndex].Value.ToString().Substring(0, 1);
                }

            }
            catch
            {

            }
            try
            {
                if (board[e.ColumnIndex, e.RowIndex].Value.ToString().Equals(board[e.ColumnIndex, e.RowIndex].Tag.ToString().ToUpper()))
                {
                    board[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.DarkGreen;
                    board[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Navy;
                }
                else
                {
                    board[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.OrangeRed;
                    board[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Navy;
                }

            }
            catch
            {

            }
        }

        private void openPuzzleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Puzzle Files|*.PZL";
            if (ofd.ShowDialog().Equals(DialogResult.OK))
            {
                puzzle_file = ofd.FileName;
                board.Rows.Clear();
                clue_window.clueTable.Rows.Clear();
                idc.Clear();
                buildWordList();
                InitializeBoard();


            }
        }

        private void board_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            String number = "";
            if(idc.Any(c =>(number = c.number) != "" && c.x == e.ColumnIndex && c.y == e.RowIndex))
            {
                Rectangle r = new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width-1, e.CellBounds.Height-1);
                e.Graphics.FillRectangle(Brushes.Cyan, r);
                e.PaintBackground(r, true);
                Font f = new Font(e.CellStyle.Font.FontFamily, 7);
                e.Graphics.DrawString(number, f, Brushes.White, r);
                e.PaintContent(r);
                e.Handled = true;
            }
        }

    }
    public class id_cells
    {
        public int x;
        public int y;
        public String direction;
        public String number;
        public String word;
        public String clue;


        public id_cells(int x, int y, String d, String n, String w, String c)
        {
            this.x = x;
            this.y = y;
            this.direction = d;
            this.number = n;
            this.word = w;
            this.clue = c;
        }
    }
}
