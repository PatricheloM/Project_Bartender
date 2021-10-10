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

namespace Bartender_M9D47D
{
    public partial class lista : Form
    {
        string currentTableString;

        publicExceptionHandling publicExceptionHandling = new publicExceptionHandling();

        public lista()
        {
            InitializeComponent();
            try
            {
                StreamReader sr = new StreamReader("resources\\_currentTable");
                currentTableString = sr.ReadToEnd();
                sr.Close();
            }
            catch (FileNotFoundException)
            {
                publicExceptionHandling.saveThenExit(1);
            }
            currentTable.Text = currentTableString;
        }
    }
}
