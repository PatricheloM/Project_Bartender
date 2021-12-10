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
    public partial class kifizetes : Form
    {
        publicExceptionHandling publicExceptionHandling = new publicExceptionHandling();
        xmlHandling xmlHandling = new xmlHandling();

        List<Label> itemLabels = new List<Label>();

        int sum = 0;

        public kifizetes()
        {
            InitializeComponent();
            this.ClientSize = new Size(480, 480);
            foreach (var invoice in xmlHandling.searchInvoicesB().Distinct().ToList())
            {
                comboBox.Items.Add(invoice);
            }
            foreach (var invoice in xmlHandling.searchInvoicesK().Distinct().ToList())
            {
                comboBox.Items.Add(invoice);
            }
        }

        void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < itemLabels.Count(); i++)
            {
                itemLabels[i].Hide();
            }
            itemLabels.Clear();
            string selected = comboBox.SelectedItem.ToString();
            if (comboBox.SelectedItem != null)
            {
                List<string> items = new List<string>();
                List<string> prices = new List<string>();

                List<int> dupesI = new List<int>();
                List<int> dupesN = new List<int>();

                for (int i = 0; i < xmlHandling.searchInvoiceFor(selected).GetLength(0); i++)
                {
                    if (!items.Contains(xmlHandling.searchInvoiceFor(selected)[i, 0]))
                    {
                        items.Add(xmlHandling.searchInvoiceFor(selected)[i, 0]);
                        prices.Add(xmlHandling.searchInvoiceFor(selected)[i, 1]);
                        dupesI.Add(i);
                        dupesN.Add(1);
                    }
                    else 
                    {
                        prices[items.FindIndex(item => item.Contains(xmlHandling.searchInvoiceFor(selected)[i, 0]))] = Convert.ToString(Convert.ToInt32(prices[items.FindIndex(item => item.Contains(xmlHandling.searchInvoiceFor(selected)[i, 0]))]) + Convert.ToInt32(xmlHandling.searchInvoiceFor(selected)[i, 1]));
                        dupesN[items.FindIndex(item => item.Contains(xmlHandling.searchInvoiceFor(selected)[i, 0]))] += 1;
                    }
                }

                for (int i = 0; i < items.Count; i++)
                {
                    Label newLB = new Label();
                    itemLabels.Add(newLB);
                    panel.Controls.Add(newLB);
                    newLB.Text = items[i];
                    newLB.BackColor = Color.Transparent;
                    newLB.Font = new Font("Arial", 12, FontStyle.Bold);
                    newLB.Location = new Point(10, 20 + (30 * i));
                    newLB.Size = new Size(240, 20);

                    Label newLB2 = new Label();
                    itemLabels.Add(newLB2);
                    panel.Controls.Add(newLB2);
                    newLB2.Text ="(" + dupesN[i] + " db)    " + prices[i] + " Ft";
                    newLB2.BackColor = Color.Transparent;
                    newLB2.Font = new Font("Arial", 12, FontStyle.Bold);
                    newLB2.Location = new Point(250, 20 + (30 * i));
                    newLB2.Size = new Size(180, 20);
                    newLB2.TextAlign = ContentAlignment.MiddleRight;
                }
            }

            for (int i = 0; i < xmlHandling.searchInvoiceFor(selected).GetLength(0); i++)
            {
                sum += Convert.ToInt32(xmlHandling.searchInvoiceFor(selected)[i, 1]);
            }

            payButton.Text = "Kifizetve: " + sum + " Ft";
        }

        private void payButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Biztos ki lett fizetve a számla? (" + sum + " Ft)", "Kifizetés", MessageBoxButtons.OKCancel) == DialogResult.OK && comboBox.SelectedItem != null)
            {
                XDocument doc = XDocument.Load(xmlHandling.getFoundXml());

                List<XElement> deletable = doc.Descendants().Where(x => (string)x == comboBox.SelectedItem.ToString()).ToList();

                for (int i = deletable.Count - 1; i >= 0; i--)
                {
                    deletable[i].Parent.Remove();
                }

                doc.Save(xmlHandling.getFoundXml());
                this.Close();
            }
        }
    }
}
