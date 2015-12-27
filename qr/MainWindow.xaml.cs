using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

            fixedCells = new List<int>() {1,0,1,0,1};

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

        private List<Int32> row, column, currentRows, currentColumns;
        private List<List<Int32>> qr;

        private List<List<int>> corner;
        private List<int> fixedCells;

        private String HTMLstyle, nl;


        private void addCorners()
        {
            for (int i = 0; i < corner.Count; i++)
            {
                for (int j = 0; j < corner[i].Count; j++)
                {
                    qr[i][j] = corner[i][j];
                    if(i<7)
                        qr[i+14][j] = corner[i][j];
                
                    if(j<7)
                        qr[i][j + 14] = corner[i][j];
                }
            }
        }

        private void addFixed()
        {
            for (int i = 0; i < fixedCells.Count; i++)
            {
                    qr[6][8+i] = fixedCells[i];
                    qr[8+i][6] = fixedCells[i];
            }

            qr[13][8] = 1;
        }

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

            for (int i = 0; i < row.Count; i++)
            {
                if (currentRows[i] > row[i] || currentColumns[i]>column[i])
                    throw new Exception("Not a valid QR");
            }
        }

        private bool allFilled()
        {
            for (int i = 0; i < row.Count; i++)
            {
                if (!rowFilled(i)) return false;
                if (!columnFilled(i)) return false;
            }
            return true;
        }

        private bool rowFilled(int i)
        {
            return row[i] - currentRows[i] == 0;
        }

        private bool columnFilled(int i)
        {
            return column[i] - currentColumns[i] == 0;
        }

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

        public void setSame(int i, int j, int k, int l)
        {
            if (qr[i][j] == 1 || qr[k][l] == 1)
            {
                qr[i][j] = 1;
                qr[k][l] = 1;
            }
        }

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
                addFixed();
                updateCount();

                checkSame();
                updateCount();//****

                int previousRowCount = 0;
                int previousColumnCount = 0;

                while (!allFilled())
                {
                    Dictionary<int, List<int>> availableRowCell = new Dictionary<int, List<int>>();
                    Dictionary<int, List<int>> availableColumnCell = new Dictionary<int, List<int>>();
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

                    for (int i = 0; i < row.Count; i++)
                    {
                        if (availableRowCell.ContainsKey(i) && availableRowCell[i].Count == row[i] - currentRows[i])
                        {
                            foreach (var j in availableRowCell[i])
                            {
                                qr[i][j] = 1;

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
                    makeHTML("4");
                    if (allFilled())
                        break;

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

        public void makeHTML(String filename="test.html")
        {
            using (FileStream fs = new FileStream(filename + ".html", FileMode.Create))
            {
                using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                {
                    w.WriteLine("<!DOCTYPE HTML>\r\n<HTML>\r\n<HEAD>\r\n<TITLE>QR code</TITLE>\r\n<STYLE>\r\n" + HTMLstyle + "\r\n</STYLE>\r\n</HEAD>\r\n<BODY>\r\n<table>");
                    for (int i = 0; i < 21; i++)
                    {
                        w.Write("<tr> ");
                        for (int j = 0; j < 21; j++)
                        {
                            if (qr[i][j] == 1) w.Write("<td style='background-color:blue;'>" + " </td>");
                            else w.Write("<td>"+" </td>");
                        }
                        w.Write(" </tr>");
                        w.WriteLine("");
                    }
                    w.WriteLine("\r\n<table>\r\n</BODY>\r\n</HTML>");
                }
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            

        }
    }
}
