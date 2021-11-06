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

namespace Bartender_M9D47D
{
    public partial class itallap : Form
    {
        publicExceptionHandling publicExceptionHandling = new publicExceptionHandling();
        xmlHandling xmlHandling = new xmlHandling();
        jsonHandling jsonHandling = new jsonHandling();

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

        void xmlToJs()
        {
            string xml = File.ReadAllText("resources/itallap.xml");
            xml = xml.Replace("\"", "\'");
            xml = String.Concat(xml.Where(c => !Char.IsWhiteSpace(c)));
            xml = xml.Replace("itemid=", "item id=");
            xml = xml.Replace("><", ">\" + \n \"<");
            xml = xml.Replace("\"</drinks>", "\"</drinks>\"");
            xml = xml.Replace("<?xmlversion=", "\"<?xmlversion=");
            string str = xml;
            string[] lines = str
                .Split(Environment.NewLine.ToCharArray())
                .Skip(3)
                .ToArray();
            xml = string.Join(Environment.NewLine, lines);
            StreamReader sr = new StreamReader("resources/script.js");
            string line;
            List<string> script = new List<string>();
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                if (line.Contains("var text = "))
                {
                    break;
                }
                script.Add(line + "\n");
            }
            sr.Close();
            script.Add("var text = " + xml + ";");
            StreamWriter sw = new StreamWriter("resources/script.js");
            foreach (var item in script)
            {
                sw.Write(item);
                Console.WriteLine(item);
            }
            sw.Write("\n var nextID = " + (xmlHandling.getItallapCount() + 1) + ";");
            sw.Close();
        }

        private void openInBrowser_Click(object sender, EventArgs e)
        {
            xmlToJs();
            System.Diagnostics.Process.Start(jsonHandling.setPath());
            this.Close();
        }
    }
}
