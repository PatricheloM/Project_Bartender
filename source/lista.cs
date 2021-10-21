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
using System.Xml;
using System.Xml.Linq;

namespace Bartender_M9D47D
{
    public partial class lista : Form
    {
        //globally usable objects----------------------------------------------------------------------------------------

        string currentTableString;

        char side()
        {
            return Convert.ToChar(currentTableString.Substring(currentTableString.Length - 1, 1));
        }

        int currentTable()
        { 
            return Convert.ToInt32(currentTableString.Substring(0, currentTableString.Length - 1));
        }

        publicExceptionHandling publicExceptionHandling = new publicExceptionHandling();
        xmlHandling xmlHandling = new xmlHandling();

        //initialize-------------------------------------------------------------------------------------------------

        public lista()
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(500, 700);
            this.dataGridView.Size = new System.Drawing.Size(473, 657);
            xmlHandling.xmlRead();
            try
            {
                StreamReader sr = new StreamReader("resources/_currentTable");
                currentTableString = sr.ReadToEnd();
                sr.Close();
            }
            catch (FileNotFoundException)
            {
                publicExceptionHandling.saveThenExit(1);
            }
            currentTableText.Text = "Asztal: " + Convert.ToString(currentTable() + 1) + Convert.ToString(side());
        }

        //dataGrid-------------------------------------------------------------------------------------------------

        private void dataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            xmlHandling.xmlRead();
            var source = new AutoCompleteStringCollection();
            source.AddRange(xmlHandling.name.ToArray());

            if (dataGridView.CurrentCell.ColumnIndex == 0)
            {
                TextBox drinkCol = e.Control as TextBox;
                if (drinkCol != null)
                {
                    drinkCol.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    drinkCol.AutoCompleteCustomSource = source;
                    drinkCol.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
            else
            {
                TextBox drinkCol = e.Control as TextBox;
                if (drinkCol != null)
                {
                    drinkCol.AutoCompleteMode = AutoCompleteMode.None;
                }
            }
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            /*buggy code ahead, i'll probably rewrite the whole thing later
            xmlHandling.xmlRead();
            string[] item = xmlHandling.name.ToArray();
            int[] price = xmlHandling.price.ToArray();
            try
            {
                dataGridView[1, dataGridView.Rows[e.RowIndex].Index].Value = price[Array.IndexOf(item, dataGridView[0, dataGridView.Rows[e.RowIndex].Index].Value.ToString())];
                dataGridView.Rows[dataGridView.Rows[e.RowIndex].Index].Cells[1].ReadOnly = true;
                dataGridView.Rows[dataGridView.Rows[e.RowIndex].Index].Cells[2].ReadOnly = false;
                dataGridView.Rows[dataGridView.Rows[e.RowIndex].Index].Cells[0].ReadOnly = true;
            }
            catch (Exception exception)
            {
                if (exception is IndexOutOfRangeException)
                {
                    MessageBox.Show("Egyedi tétel. Árat külön kell megadni!", "Egyedi tétel", MessageBoxButtons.OK);
                    dataGridView.Rows[dataGridView.Rows[e.RowIndex].Index].Cells[1].ReadOnly = false;
                    dataGridView.Rows[dataGridView.Rows[e.RowIndex].Index].Cells[2].ReadOnly = false;
                    dataGridView.Rows[dataGridView.Rows[e.RowIndex].Index].Cells[0].ReadOnly = true;
                }
                else if (exception is NullReferenceException)
                {
                    MessageBox.Show("Először egy tételt adjon meg!", "Üres", MessageBoxButtons.OK);
                    dataGridView.Rows[dataGridView.Rows[e.RowIndex].Index].Cells[2].Value = null;
                }
            }
            */
        }
    }
}
