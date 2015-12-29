using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace qr
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            nl = "\r\n";
            tbcolumns.Text = "17, 7, 12, 13, 13, 4, 17, 4, 14, 12, 6, 8, 15, 7, 13, 8, 12, 13, 8, 10, 11";
            tbrows.Text = "17, 8, 13, 13, 12, 6, 17, 1, 13, 12, 9, 7, 8, 9, 16, 7, 10, 12, 11, 10, 13";
            tbqr.Text = "1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1," + nl +
                        "1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1," + nl +
	                    "1, 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1," + nl +
	                    "1, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1," + nl +
                        "1, 0, 1, 1, 1, 0, 1, 0, 0, 1, 0, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1," + nl +
                        "1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1," + nl +
                        "1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1," + nl +
                        "0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0," + nl +
                        "1, 1, 1, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0," + nl +
                        "1, 1, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0, 1, 1, 0, 1, 1, 1, 0, 0, 1," + nl +
                        "0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0," + nl +
                        "0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1," + nl +
                        "1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0," + nl +
                        "0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 0, 1," + nl +
                        "1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 1, 0," + nl +
                        "1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 1, 1, 0," + nl +
                        "1, 0, 1, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1," + nl +
                        "1, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 0, 1, 0, 1, 1, 1, 1, 0, 0, 0," + nl +
                        "1, 0, 1, 1, 1, 0, 1, 0, 0, 1, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0," + nl +
                        "1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0," + nl +
                        "1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0";

            //represents finder patterns (upper and lower left, and upper right corners)
            corner = new List<List<int>>
            {
                new List<int>() {1, 1, 1, 1, 1, 1, 1, 0},
                new List<int>() {1, 0, 0, 0, 0, 0, 1, 0},
                new List<int>() {1, 0, 1, 1, 1, 0, 1, 0},
                new List<int>() {1, 0, 1, 1, 1, 0, 1, 0},
                new List<int>() {1, 0, 1, 1, 1, 0, 1, 0},
                new List<int>() {1, 0, 0, 0, 0, 0, 1, 0},
                new List<int>() {1, 1, 1, 1, 1, 1, 1, 0},
                new List<int>() {0, 0, 0, 0, 0, 0, 0, 0}
            };

            //represents timing patterns http://www.thonky.com/qr-code-tutorial/format-version-information
            fixedCells = new List<int>() {1,0,1,0,1};

            //css for output qr codes
            HTMLstyle = @"table{
            margin: 6% 0px 0px 8%;
		    border: none;
		    border-spacing: 0px;
		    border-collapse: separate;
            }
            td{
		    height: 12px;
		    width: 12px;
            }";
        }

        //row, column - respective textbox entry; cuurentRows, curentColumns - current count of ones in rows/columns; qr - qr matrix
        private List<int> row, column, currentRows, currentColumns;
        private List<List<int>> qr;

        private readonly List<List<int>> corner;
        private readonly List<int> fixedCells;

        private readonly string HTMLstyle, nl;

        private void addCorners()
        {
            for (int i = 0; i < corner.Count; i++)
            {
                for (int j = 0; j < corner[i].Count; j++)
                {
                    qr[i][j] = corner[i][j];

                    //since 'corners' include lower row of zeros, it must not be included below the qr matrix
                    if(i<7)
                        qr[i+14][j] = corner[i][j];
                    //same, but for the right side
                    if(j<7)
                        qr[i][j + 14] = corner[i][j];
                }
            }
        }

        //adds timing patterns and dark module
        private void addFixed()
        {
            for (int i = 0; i < fixedCells.Count; i++)
            {
                    qr[6][8+i] = fixedCells[i];
                    qr[8+i][6] = fixedCells[i];
            }
            //dark module:
            qr[13][8] = 1;
        }

        //updates currentRows and currentColumns count so as to correspond with the current state
        private void updateCount()
        {
            currentRows = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            currentColumns = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            for (int i = 0; i < row.Count; i++)
            {
                for (int j = 0; j < column.Count; j++)
                {
                    currentRows[i] += qr[i][j];
                    currentColumns[j] += qr[i][j];
                }
            }
            //If any row or columns has more ones than specified 'rows'/'columns'
            for (int i = 0; i < row.Count; i++)
            {
                if (currentRows[i] > row[i] || currentColumns[i]>column[i])
                    throw new Exception("Not a valid QR");
            }
        }

        //checks if all rows and columns are filled
        private bool allFilled()
        {
            for (int i = 0; i < row.Count; i++)
            {
                if (!rowFilled(i)) return false;
                if (!columnFilled(i)) return false;
            }
            return true;
        }

        //checks if the current row is filled
        private bool rowFilled(int i)
        {
            return row[i] - currentRows[i] == 0;
        }

        //checks if the current column is filled
        private bool columnFilled(int i)
        {
            return column[i] - currentColumns[i] == 0;
        }

        //checks if cell is available (can potentially be 1)
        private bool isAvailableRow(int i, int j)
        {
            if (qr[i][j] == 1) return false;
            if (i == 6 || j == 6 || (i==13 && j==8)) return false;
            if (i < 6 && (j < 8 || j > 13)) return false;
            if (i > 13 && j < 8) return false;
            if (!columnFilled(j))
            { 
                if ((i < 6 || i>14) && j == 8) return qr[j][20-i]==0 && !columnFilled(20 - i) && !rowFilled(j);
                if (i == 8 && j < 6) return qr[20 - j][i] == 0 && !columnFilled(i) && !rowFilled(20-j);
                if ((i == 7 || i == 8 || i==14) && j == 8) return qr[j][20-i+1]==0 && !columnFilled(20 - i + 1) && !rowFilled(j);
                if (i == 8 && j > 13) return qr[20-j][8]==0 && !columnFilled(i) && !rowFilled(20-j);
            }
            return !columnFilled(j);
        }

        private bool isAvailableColumn(int i, int j)
        {
            if (qr[i][j] == 1) return false;
            if (i == 6 || j == 6 || (i == 13 && j == 8)) return false;
            if (i < 6 && (j < 8 || j > 13)) return false;
            if (i > 13 && j < 8) return false;
            if (!rowFilled(i)) { 
                if ((j < 6 || j > 14) && i == 8) return qr[20-j][i]==0 && !rowFilled(20 - j) && !columnFilled(i);
                if (j == 8 && i < 6) return  qr[j][20-i]==0 && !columnFilled(20-i) && !rowFilled(j);
                if ((j == 7 || j == 8 || j == 14) && i == 8) return qr[20-j+1][i]==0 && !columnFilled(j) && !rowFilled(20 - j + 1);
                if (j == 8 && i > 13) return qr[j][20-i]==0 && !rowFilled(j) && !columnFilled(20-i);
            }
            return !rowFilled(i);
        }

        //if any of the two is 1, both have to be 1. (i, j) - first cell, (k, l) - second cell
        public void setSame(int i, int j, int k, int l)
        {
            if (qr[i][j] == 1 || qr[k][l] == 1)
            {
                qr[i][j] = 1;
                qr[k][l] = 1;
            }
        }

        //checks the cells which must correspond to each other, found in 9th row and 9th column (blue) http://www.thonky.com/qr-code-tutorial/format-version-information
        public void checkSame()
        {
            for (int i = 0; i < 8; i++)
            {
                if (i >= 6)
                {
                    setSame(i+1, 8, 8, 20-i);
                    setSame(8, i+1, 20-i, 8);
                }
                else
                {
                    setSame(i, 8, 8, 20 - i);
                    setSame(8, i, 20 - i, 8);
                }
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                row = new List<int>();
                column = new List<int>();

                String[] rowStrings = tbrows.Text.Split(',');

                foreach (var rowString in rowStrings)
                {
                    row.Add(Int32.Parse(rowString));
                }

                String[] columnStrings = tbcolumns.Text.Split(',');

                foreach (var columnString in columnStrings)
                {
                    column.Add(Int32.Parse(columnString));
                }

                String[] qrStrings = tbqr.Text.Split(',');
                qr = new List<List<int>>();

                for (int i = 0; i < row.Count; i++)
                {
                    qr.Add(new List<int>());
                    for (int j = 0; j < column.Count; j++)
                    {
                        qr[i].Add(Int32.Parse(qrStrings[(i * 21) + j]));
                    }
                }


                addCorners();
                updateCount();
                
                //adds timing patterns:
                addFixed();
                updateCount();

                checkSame();
                updateCount();//red

                int previousRowCount = 0;
                int previousColumnCount = 0;

                while (!allFilled())
                {
                    //Dictionary: in specified row/column, these columns/rows could contain 1
                    Dictionary<int, List<int>> availableRowCell = new Dictionary<int, List<int>>();
                    Dictionary<int, List<int>> availableColumnCell = new Dictionary<int, List<int>>();


                    //iterates through all rows and checks which cell could be 1
                    for (int i = 0; i < row.Count; i++)
                    {
                        if (!rowFilled(i))
                        {
                            availableRowCell.Add(i, new List<int>());
                            for (int j = 0; j < column.Count; j++)
                            {
                                if (isAvailableRow(i, j))
                                {
                                    availableRowCell[i].Add(j);
                                }
                            }
                        }
                    }

                    // iterates through all rows... #1
                    for (int i = 0; i < row.Count; i++)
                    {
                        //if row is not filled and ALL available cells can be filled
                        if (availableRowCell.ContainsKey(i) && availableRowCell[i].Count == row[i] - currentRows[i])
                        {
                            foreach (var j in availableRowCell[i])
                            {
                                qr[i][j] = 1;

                                //checks if (i,j) has a corresponding cell, eg. checkSame
                                if (i == 8)
                                {
                                    if (j < 6 || j > 14)
                                    {
                                        setSame(i, j, 20 - j, i);
                                        availableRowCell[20 - j].Remove(i);
                                    }
                                    else if (j == 7 || j == 14)
                                    {
                                        setSame(i, j, 20 - j + 1, i);
                                        availableRowCell[20 - j + 1].Remove(i);
                                    }
                                }

                                if (j == 8)
                                {
                                    if (i < 6 || i > 14)
                                    {
                                        setSame(i, j, j, 20 - i);
                                        availableRowCell[j].Remove(i);
                                    }
                                    else if (i == 7 || i == 8 || i == 14)
                                    {
                                        setSame(i, j, i, 20 - i + 1);
                                        availableRowCell[i].Remove(20 - i + 1);
                                    }
                                }

                                updateCount();
                            }
                        }
                    }

                    updateCount();

                    if (allFilled())
                        break;

                    //same as #1, but for columns
                    for (int j = 0; j < column.Count; j++)
                    {
                        if (!columnFilled(j))
                        {
                            availableColumnCell.Add(j, new List<int>());
                            for (int i = 0; i < row.Count; i++)
                            {
                                if (isAvailableColumn(i, j))
                                {
                                    availableColumnCell[j].Add(i);
                                }
                            }
                        }
                    }

                    for (int j = 0; j < column.Count; j++)
                    {
                        if (availableColumnCell.ContainsKey(j) && availableColumnCell[j].Count == column[j] - currentColumns[j])
                        {
                            foreach (var i in availableColumnCell[j])
                            {
                                qr[i][j] = 1;

                                if (i == 8)
                                {
                                    if (j < 6 || j > 14)
                                    {
                                        setSame(i, j, 20 - j, i);
                                        availableColumnCell[i].Remove(20 - j);
                                    }
                                    else if (j == 7 || j == 14)
                                    {
                                        setSame(i, j, 20 - j + 1, i);
                                        availableRowCell[i].Remove(20 - j + 1);
                                    }
                                }

                                if (j == 8)
                                {
                                    if (i < 6 || i > 14)
                                    {
                                        setSame(i, j, j, 20 - i);
                                        availableRowCell[j].Remove(20 - i);
                                    }
                                    else if (i == 7 || i == 8 || i == 14)
                                    {
                                        setSame(i, j, i, 20 - i + 1);
                                        availableRowCell[20 - i + 1].Remove(i);
                                    }
                                }

                                updateCount();
                            }
                        }
                    }

                    updateCount();

                    //nothing's changed between iterations. Program cannot find a solution, prevented infinite looping.
                    if (previousRowCount == availableRowCell.Count && previousColumnCount == availableColumnCell.Count)
                        throw new Exception("Cannot solve QR.");
                    
                    previousRowCount = availableRowCell.Count;
                    previousColumnCount = availableColumnCell.Count;
                    
                }
                //make html

                makeHTML("qr");

                System.Diagnostics.Process.Start("qr.html");
            }
            catch (Exception exce)
            {
                MessageBox.Show(exce.Message);
            }
            
        }

        //creates HTML file that displays a QR code
        public void makeHTML(String filename="test.html")
        {
            using (FileStream fs = new FileStream(filename + ".html", FileMode.Create))
            {
                using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                {
                    w.WriteLine("<!DOCTYPE HTML>" + nl + "<HTML>" + nl + "<HEAD>" + nl + "<TITLE>QR code</TITLE>" + nl + "<STYLE>" + nl + HTMLstyle + nl + "</STYLE>" + nl + "</HEAD>" + nl + "<BODY>" + nl + "<table>");
                    for (int i = 0; i < 21; i++)
                    {
                        w.Write("<tr> ");
                        for (int j = 0; j < 21; j++)
                        {
                            if (qr[i][j] == 1) w.Write("<td style='background-color:black;'>" + " </td>");
                            else w.Write("<td>"+" </td>");
                        }
                        w.Write(" </tr>" + nl);
                    }
                    w.WriteLine(nl + "</table>" + nl + "</BODY>" + nl + "</HTML>");
                }
            }
        }

    }
}
