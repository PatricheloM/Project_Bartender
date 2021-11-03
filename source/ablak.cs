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
    public partial class ablak : Form
    {

        //globally usable objects----------------------------------------------------------------------------------------

        public int ScreenWidth()
        {
            if (Environment.OSVersion.Platform == PlatformID.Unix)
            {
                int width = Screen.PrimaryScreen.Bounds.Width - 160;
                return width;
            }
            else
            {
                int width = Screen.PrimaryScreen.Bounds.Width;
                return width;
            }
        }
        public int ScreenHeight()
        {
            if (Environment.OSVersion.Platform == PlatformID.Unix)
            {
                int height = Screen.PrimaryScreen.Bounds.Height - 90;
                return height;
            }
            else 
            {
                int height = Screen.PrimaryScreen.Bounds.Height;
                return height;
            }
        }

        List<PictureBox> tablesB = new List<PictureBox>();
        List<PictureBox> tablesK = new List<PictureBox>();

        bool picutreGrabbed;
        int deltaX;
        int deltaY;
        int hoveredObject;

        publicExceptionHandling publicExceptionHandling = new publicExceptionHandling();

        //initialize-------------------------------------------------------------------------------------------------

        void checkSaveB()
        {
            string[] xmls = Directory.GetFiles("tables/", "*B.xml", SearchOption.TopDirectoryOnly);
            int[] savedB = new int[xmls.Length];
            for (int i = 0; i < xmls.Length; i++)
            {
                savedB[i] = i;
                try
                {
                    File.Copy(xmls[i], "tables/table" + i + "B.xml");
                    File.Delete(xmls[i]);
                }
                catch (Exception exception)
                {
                }
                pluszB_Click(new object(), new EventArgs());
                if (File.ReadLines("tables/_table.xml").Count() != File.ReadLines("tables/table" + hoveredObject + "B.xml").Count())
                {
                    tablesB[hoveredObject].Image = Image.FromFile("resources/foglalt.png");
                }
                else
                {
                    tablesB[hoveredObject].Image = Image.FromFile("resources/szabad.png");
                }

                XmlDocument doc = new XmlDocument();
                doc.Load("tables/table" + i + "B.xml");
                XmlElement root = doc.DocumentElement;
                int x = Convert.ToInt32(root.GetAttribute("x"));
                int y = Convert.ToInt32(root.GetAttribute("y"));
                tablesB[i].Location = new Point(x, y);
            }
        }

        void checkSaveK()
        {
            string[] xmls = Directory.GetFiles("tables/", "*K.xml", SearchOption.TopDirectoryOnly);
            int[] savedK = new int[xmls.Length];
            for (int i = 0; i < xmls.Length; i++)
            {
                savedK[i] = i;
                try
                {
                    File.Copy(xmls[i], "tables/table" + i + "K.xml");
                    File.Delete(xmls[i]);
                }
                catch (Exception exception)
                {
                }
                pluszK_Click(new object(), new EventArgs());
                if (File.ReadLines("tables/_table.xml").Count() != File.ReadLines("tables/table" + hoveredObject + "K.xml").Count())
                {
                    tablesK[hoveredObject].Image = Image.FromFile("resources/foglalt.png");
                }
                else
                {
                    tablesK[hoveredObject].Image = Image.FromFile("resources/szabad.png");
                }

                XmlDocument doc = new XmlDocument();
                doc.Load("tables/table" + i + "K.xml");
                XmlElement root = doc.DocumentElement;
                int x = Convert.ToInt32(root.GetAttribute("x"));
                int y = Convert.ToInt32(root.GetAttribute("y"));
                tablesK[i].Location = new Point(x, y);
            }
        }

        public ablak()
        {
            InitializeComponent();
            this.ClientSize = new Size(ScreenWidth(), ScreenHeight());
            this.exitButton.Location = new Point(ScreenWidth() - 55, 5);
            this.minimizeButton.Location = new Point(ScreenWidth() - 110, 5);
            this.itallapButton.Location = new Point(ScreenWidth() - 225, 5);
            this.pluszK.Location = new Point((ScreenWidth() / 3) * 2 - 5, 60);
            this.pluszB.Location = new Point(5, 60);
            this.groupBoxB.Location = new Point(10, 60);
            this.groupBoxB.Size = new Size((ScreenWidth() / 3) * 2 - 20, ScreenHeight() - 80);
            this.groupBoxK.Location = new Point((ScreenWidth() / 3) * 2, 60);
            this.groupBoxK.Size = new Size(ScreenWidth() / 3 - 10, ScreenHeight() - 80);
            this.belsoLabel.Location = new Point(55, 10);
            this.kulsoLabel.Location = new Point(55, 10);
            checkSaveB();
            checkSaveK();

        }

        //buttons on the top right------------------------------------------------------------------------------------

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Biztos be akarod zárni az ablakot?", "Bezárás", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                publicExceptionHandling.saveThenExit(0);
            }
        }

        private void itallapButton_Click(object sender, EventArgs e)
        {
            itallap itallap = new itallap();
            itallap.ShowDialog();
        }

        //dynamic table creation--------------------------------------------------------------------------------------

        private void pluszB_Click(object sender, EventArgs e)
        {
            PictureBox newPXB = new PictureBox();
            tablesB.Add(newPXB);
            this.groupBoxB.Controls.Add(newPXB);
            try
            {
                newPXB.Image = Image.FromFile("resources/szabad.png");
            }
            catch (FileNotFoundException)
            {
                publicExceptionHandling.imageNotFound();
                newPXB.Image = newPXB.ErrorImage;
            }
            newPXB.Size = new Size(100, 100);
            newPXB.Location = new Point(50, 50);
            newPXB.DoubleClick += new EventHandler(this.newPXB_DoubleClick);
            newPXB.MouseDown += new MouseEventHandler(this.newPXB_MouseDown);
            newPXB.MouseMove += new MouseEventHandler(this.newPXB_MouseMove);
            newPXB.MouseUp += new MouseEventHandler(this.newPXB_MouseUp);
            if (!File.Exists("tables/table" + (tablesB.Count - 1) + "B.xml"))
            {
                File.Copy("tables/_table.xml", "tables/table" + (tablesB.Count - 1) + "B.xml");
            }

        }

        private void pluszK_Click(object sender, EventArgs e)
        {
            PictureBox newPXK = new PictureBox();
            tablesK.Add(newPXK);
            this.groupBoxK.Controls.Add(newPXK);
            try
            {
                newPXK.Image = Image.FromFile("resources/szabad.png");
            }
            catch (FileNotFoundException)
            {
                publicExceptionHandling.imageNotFound();
                newPXK.Image = newPXK.ErrorImage;
            }
            newPXK.Size = new Size(100, 100);
            newPXK.Location = new Point(50, 50);
            newPXK.DoubleClick += new EventHandler(this.newPXK_DoubleClick);
            newPXK.MouseDown += new MouseEventHandler(this.newPXK_MouseDown);
            newPXK.MouseMove += new MouseEventHandler(this.newPXK_MouseMove);
            newPXK.MouseUp += new MouseEventHandler(this.newPXK_MouseUp);
            if (!File.Exists("tables/table" + (tablesK.Count - 1) + "K.xml"))
            {
                File.Copy("tables/_table.xml", "tables/table" + (tablesK.Count - 1) + "K.xml");
            }

        }

        //drag and drop B--------------------------------------------------------------------------------------------------

        private void newPXB_MouseMove(object sender, MouseEventArgs e)
        {
            int senderHash = sender.GetHashCode();
            int[] hashCodesK = new int[tablesB.Count()];

            for (int i = 0; i < tablesK.Count(); i++)
            {
                hashCodesK[i] = tablesB[i].GetHashCode();
                if (hashCodesK[i] == senderHash)
                {
                    hoveredObject = i;
                    break;
                }
            }

            int newX = this.tablesB[hoveredObject].Left + (e.X - deltaX);
            int newY = this.tablesB[hoveredObject].Top + (e.Y - deltaY);

            if (picutreGrabbed)
            {
                if (newX > 0 && newX < ((ScreenWidth() / 3) * 2) - 110 && newY > 0 && newY < ScreenHeight() - 180)
                {
                    this.tablesB[hoveredObject].Left = newX;
                    this.tablesB[hoveredObject].Top = newY;
                }
            }
        }

        private void newPXB_MouseUp(object sender, MouseEventArgs e)
        {
            picutreGrabbed = false;
            XmlDocument doc = new XmlDocument();
            doc.Load("tables/table" + hoveredObject + "B.xml");
            XmlElement root = doc.DocumentElement;
            root.SetAttribute("x", tablesB[hoveredObject].Location.X.ToString());
            root.SetAttribute("y", tablesB[hoveredObject].Location.Y.ToString());
            doc.Save("tables/table" + hoveredObject + "B.xml");
        }

        private void newPXB_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    deltaX = e.X;
                    deltaY = e.Y;
                    picutreGrabbed = true;
                    break;

                case MouseButtons.Right:
                    ContextMenu cm = new ContextMenu();
                    cm.MenuItems.Add("Asztal törlése", new EventHandler(PXBHide));
                    cm.MenuItems.Add("Asztal ürítése", new EventHandler(PXBFlush));
                    tablesB[hoveredObject].ContextMenu = cm;
                    break;
            }
        }

        //drag and drop K--------------------------------------------------------------------------------------------------------------

        private void newPXK_MouseMove(object sender, MouseEventArgs e)
        {
            int senderHash = sender.GetHashCode();
            int[] hashCodesK = new int[tablesK.Count()];

            for (int i = 0; i < tablesK.Count(); i++)
            {
                hashCodesK[i] = tablesK[i].GetHashCode();
                if (hashCodesK[i] == senderHash)
                {
                    hoveredObject = i;
                    break;
                }
            }

            int newX = tablesK[hoveredObject].Left + (e.X - deltaX);
            int newY = tablesK[hoveredObject].Top + (e.Y - deltaY);

            if (picutreGrabbed)
            {
                if (newX > 0 && newX < ((ScreenWidth() / 3)) - 110 && newY > 0 && newY < ScreenHeight() - 180)
                {
                    tablesK[hoveredObject].Left = newX;
                    tablesK[hoveredObject].Top = newY;
                }
            }
        }

        private void newPXK_MouseUp(object sender, MouseEventArgs e)
        {
            picutreGrabbed = false;
            XmlDocument doc = new XmlDocument();
            doc.Load("tables/table" + hoveredObject + "K.xml");
            XmlElement root = doc.DocumentElement;
            root.SetAttribute("x", tablesK[hoveredObject].Location.X.ToString());
            root.SetAttribute("y", tablesK[hoveredObject].Location.Y.ToString());
            doc.Save("tables/table" + hoveredObject + "K.xml");
        }

        private void newPXK_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    deltaX = e.X;
                    deltaY = e.Y;
                    picutreGrabbed = true;
                    break;

                case MouseButtons.Right:
                    ContextMenu cm = new ContextMenu();
                    cm.MenuItems.Add("Asztal törlése", new EventHandler(PXKHide));
                    cm.MenuItems.Add("Asztal ürítése", new EventHandler(PXKFlush));
                    tablesK[hoveredObject].ContextMenu = cm;
                    break;
            }
        }

        //table double clicks--------------------------------------------------------------------------------------

        private void newPXB_DoubleClick(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("resources/_currentTable");
            sw.Write("{0}B", hoveredObject);
            sw.Close();
            lista lista = new lista();
            lista.ShowDialog();
            if (File.ReadLines("tables/_table.xml").Count() != File.ReadLines("tables/table" + hoveredObject + "B.xml").Count())
            {
                tablesB[hoveredObject].Image = Image.FromFile("resources/foglalt.png");
            }
            else
            {
                tablesB[hoveredObject].Image = Image.FromFile("resources/szabad.png");
            }
        }

        private void newPXK_DoubleClick(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("resources/_currentTable");
            sw.Write("{0}K", hoveredObject);
            sw.Close();
            lista lista = new lista();
            lista.ShowDialog();
            if (File.ReadLines("tables/_table.xml").Count() != File.ReadLines("tables/table" + hoveredObject + "K.xml").Count())
            {
                tablesK[hoveredObject].Image = Image.FromFile("resources/foglalt.png");
            }
            else
            {
                tablesK[hoveredObject].Image = Image.FromFile("resources/szabad.png");
            }
        }

        //table content menu------------------------------------------------------------------------

        void PXBFlush(object sender, EventArgs e)
        {
            File.Delete("tables/table" + hoveredObject + "B.xml");
            File.Copy("tables/_table.xml", "tables/table" + hoveredObject + "B.xml");
            tablesB[hoveredObject].Image = Image.FromFile("resources/szabad.png");
        }
        void PXKFlush(object sender, EventArgs e)
        {
            File.Delete("tables/table" + hoveredObject + "K.xml");
            File.Copy("tables/_table.xml", "tables/table" + hoveredObject + "K.xml");
            tablesK[hoveredObject].Image = Image.FromFile("resources/szabad.png");
        }

        void PXBHide(object sender, EventArgs e)
        {
            File.Delete("tables/table" + hoveredObject + "B.xml");
            tablesB[hoveredObject].Hide();
        }

        void PXKHide(object sender, EventArgs e)
        {
            File.Delete("tables/table" + hoveredObject + "K.xml");
            tablesK[hoveredObject].Hide();
        }

    }
}
