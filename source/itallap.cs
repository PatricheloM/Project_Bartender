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
using Microsoft.VisualBasic;
using System.Xml;
using System.Xml.Linq;
using System.Text.Json;

namespace Bartender_M9D47D
{
    public partial class itallap : Form
    {
        publicExceptionHandling publicExceptionHandling = new publicExceptionHandling();
        xmlHandling xmlHandling = new xmlHandling();

        string path;

        void setPath()
        {
            string json;
            using (StreamReader r = new StreamReader("resources/serverPath.json"))
            {
                json = r.ReadToEnd();
            }
            using (JsonDocument doc = JsonDocument.Parse(json))
            {
                JsonElement root = doc.RootElement;
                var pathInJson = root.EnumerateObject();
                while (pathInJson.MoveNext())
                {
                    var user = pathInJson.Current;
                    path = user.Value.ToString();
                }
            }
        }

        public void DataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            xmlHandling.delete(e.Row.Index + 1);
        }

        public itallap()
        {
            InitializeComponent();
            this.ClientSize = new Size(600, 800);
            this.dataGridView1.Size = new Size(580, 730);
            this.addItem.Size = new Size(475, 45);
            this.addItem.Location = new Point(10, 745);
            this.openInBrowser.Size = new Size(100, 45);
            this.openInBrowser.Location = new Point(490, 745);
            gridCloner();
            setPath();
        }

        private void addItem_Click(object sender, EventArgs e)
        {
            add add = new add();
            add.ShowDialog();
            gridCloner();
        }

        public void gridCloner()
        {
            xmlHandling.xmlRead();

            for (int i = 0; dataGridView1.Rows.Count > i;)
            {
                dataGridView1.Rows.RemoveAt(i);
            }

            for (int i = 0; i < xmlHandling.getItallapCount(); i++)
            {
                dataGridView1.Rows.Add(xmlHandling.name[i], xmlHandling.price[i]);
            }
        }

        private void openInBrowser_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(path);
            this.Close();
        }
    }
}
