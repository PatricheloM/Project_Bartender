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
    public partial class add : Form
    {
        publicExceptionHandling publicExceptionHandling = new publicExceptionHandling();
        xmlHandling xmlHandling = new xmlHandling();

        public add()
        {
            InitializeComponent();
            xmlHandling.xmlRead();
        }

        private void undo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) //enter
            {
                addButton_Click(addButton, e);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                xmlHandling.xmlAdd(Convert.ToString(xmlHandling.getItallapCount() + 1), nameBox.Text, Convert.ToInt32(price.Text));
                this.Close();
            }
            catch (FormatException)
            {
                publicExceptionHandling.onlyInt();
            }
        }
    }
}
