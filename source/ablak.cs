using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bartender_M9D47D
{
    public partial class ablak : Form
    {
        public int ScreenWidth()
        {
            int width = Screen.PrimaryScreen.Bounds.Width;
            return width;
        }
        public int ScreenHeight()
        {
            int height = Screen.PrimaryScreen.Bounds.Height;
            return height;
        }

        public ablak()
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(ScreenWidth(), ScreenHeight());
        }
    }
}
