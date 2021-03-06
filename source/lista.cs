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

        string[] item;
        int[] price;

        public List<string> currentName = new List<string>();
        public List<string> currentPrice = new List<string>();
        public List<string> currentInvoice = new List<string>();

        //initialize-------------------------------------------------------------------------------------------------

        public lista()
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(500, 700);
            this.dataGridView.Size = new System.Drawing.Size(473, 657);
            xmlHandling.xmlRead();
            item = xmlHandling.name.ToArray();
            price = xmlHandling.price.ToArray();
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
            currentTableText.Text = "Asztal: " + Convert.ToString(currentTable()) + Convert.ToString(side());
            gridCloner();
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
            if (e.ColumnIndex == 0)
            {
                xmlHandling.xmlRead();
                item = xmlHandling.name.ToArray();
                price = xmlHandling.price.ToArray();
                try
                {

                    dataGridView[1, dataGridView.Rows[e.RowIndex].Index].Value = price[Array.FindIndex(item, i => i.IndexOf(dataGridView[0, dataGridView.Rows[e.RowIndex].Index].Value.ToString(), StringComparison.InvariantCultureIgnoreCase) >= 0)];
                    dataGridView.Rows[dataGridView.Rows[e.RowIndex].Index].Cells[0].ReadOnly = true;
                    dataGridView.Rows[dataGridView.Rows[e.RowIndex].Index].Cells[1].ReadOnly = true;
                    dataGridView.Rows[dataGridView.Rows[e.RowIndex].Index].Cells[2].ReadOnly = false;
                }
                catch (Exception exception)
                {
                    if (exception is IndexOutOfRangeException)
                    {
                        publicExceptionHandling.uniqueItem();
                        dataGridView.Rows[dataGridView.Rows[e.RowIndex].Index].Cells[0].ReadOnly = true;
                        dataGridView.Rows[dataGridView.Rows[e.RowIndex].Index].Cells[1].ReadOnly = false;
                        dataGridView.Rows[dataGridView.Rows[e.RowIndex].Index].Cells[2].ReadOnly = false;
                    }
                    else if (exception is NullReferenceException)
                    {
                    }
                }
            }

            if (e.ColumnIndex == 1)
            {
                if (!int.TryParse(dataGridView[1, dataGridView.Rows[e.RowIndex].Index].Value.ToString(), out _))
                {
                    publicExceptionHandling.onlyInt();
                    dataGridView[1, dataGridView.Rows[e.RowIndex].Index].Value = "";
                }
                else
                {
                    dataGridView.Rows[dataGridView.Rows[e.RowIndex].Index].Cells[1].ReadOnly = true;
                }
            }

            if (e.ColumnIndex == 2)
            {
                string[] xmls = Directory.GetFiles("tables/", "*.xml", SearchOption.TopDirectoryOnly);

                foreach (var xml in xmls)
                {
                    foreach (var line in File.ReadAllLines(xml))
                    {
                        if (line.Contains("<invoice>" + dataGridView[2, dataGridView.Rows[e.RowIndex].Index].Value.ToString().ToUpper() + "</invoice>"))
                        {
                            string foundIn = xml;
                            if (foundIn != "tables/table" + currentTableString + ".xml")
                            {
                                publicExceptionHandling.invoiceExists(foundIn);
                                dataGridView[2, dataGridView.Rows[e.RowIndex].Index].Value = "";
                            }
                            else
                            {
                                dataGridView.Rows[dataGridView.Rows[e.RowIndex].Index].Cells[2].ReadOnly = true;
                            }
                            break;
                        }
                    }
                }
            }

        }

        //xml handling---------------------------------------------------------------------------

        void openCurrentXml()
        {
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.DtdProcessing = DtdProcessing.Parse;
                settings.MaxCharactersFromEntities = 1024;

                XElement xmlNodes = XElement.Load("tables/table" + currentTableString + ".xml");

                using (XmlReader reader = XmlReader.Create("tables/table" + currentTableString + ".xml", settings))
                {
                    while (reader.Read())
                    {
                        if (reader.IsStartElement())
                        {
                            switch (reader.Name.ToString())
                            {
                                case "name":
                                    currentName.Add(reader.ReadString());
                                    break;
                                case "price":
                                    currentPrice.Add(reader.ReadString());
                                    break;
                                case "invoice":
                                    currentInvoice.Add(reader.ReadString());
                                    break;
                            }
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                publicExceptionHandling.saveThenExit(2);
            }
        }

        public void gridCloner()
        {
            openCurrentXml();

            for (int i = 0; i < currentName.Count; i++)
            {
                dataGridView.Rows.Add(currentName[i], currentPrice[i], currentInvoice[i]);
            }
        }

        void saveXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("tables/table" + currentTableString + ".xml");
                XmlNode root = doc.SelectNodes("/table")[0];
                root.RemoveAll();
                doc.Save("tables/table" + currentTableString + ".xml");

                for (int i = 0; i < dataGridView.RowCount - 1; i++)
                {
                    XmlElement elem = doc.CreateElement("item");
                    elem.AppendChild(doc.CreateElement("name"));
                    elem.AppendChild(doc.CreateElement("price"));
                    elem.AppendChild(doc.CreateElement("invoice"));
                    elem.ChildNodes[0].InnerText = dataGridView.Rows[i].Cells[0].Value.ToString().ToUpper();
                    try
                    {
                        elem.ChildNodes[1].InnerText = dataGridView.Rows[i].Cells[1].Value.ToString();
                    }
                    catch (NullReferenceException)
                    {
                        elem.ChildNodes[1].InnerText = Convert.ToString(0);
                    }
                    elem.ChildNodes[2].InnerText = dataGridView.Rows[i].Cells[2].Value.ToString().ToUpper();
                    root.AppendChild(elem);
                    doc.Save("tables/table" + currentTableString + ".xml");
                }
            }
            catch (FileNotFoundException)
            {
                publicExceptionHandling.saveThenExit(2);
            }
        }

        //ATTENTION: UGLY CODE AHEAD
        private void lista_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                if (dataGridView.Rows[i].Cells[0].Value == null || dataGridView.Rows[i].Cells[0].Value.ToString() == "" || string.IsNullOrWhiteSpace(dataGridView.Rows[i].Cells[0].Value.ToString()))
                {
                    publicExceptionHandling.emptyInput();
                    e.Cancel = true;
                    break;
                }

                if (i == dataGridView.Rows.Count - 2)
                {
                    for (int j = 0; j < dataGridView.Rows.Count - 1; j++)
                    {
                        if (dataGridView.Rows[j].Cells[1].Value == null || dataGridView.Rows[j].Cells[1].Value.ToString() == "" || string.IsNullOrWhiteSpace(dataGridView.Rows[j].Cells[1].Value.ToString()))
                        {
                            publicExceptionHandling.emptyInput();
                            e.Cancel = true;
                            break;
                        }

                        if (j == dataGridView.Rows.Count - 2)
                        {
                            for (int k = 0; k < dataGridView.Rows.Count - 1; k++)
                            {
                                if (dataGridView.Rows[k].Cells[2].Value == null || dataGridView.Rows[k].Cells[2].Value.ToString() == "" || string.IsNullOrWhiteSpace(dataGridView.Rows[k].Cells[2].Value.ToString()))
                                {
                                    publicExceptionHandling.emptyInput();
                                    e.Cancel = true;
                                    break;
                                }
                                else
                                {
                                    if (k == dataGridView.Rows.Count - 2)
                                    {
                                        saveXml();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
