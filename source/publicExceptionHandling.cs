using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Bartender_M9D47D
{
    public class publicExceptionHandling
    {
        public void imageNotFound()
        {
            MessageBox.Show("Nem található a 'resources' mappa egyik eleme! A program egy helyettesítő képpel dolgozik tovább.", "Hiba", MessageBoxButtons.OK);
        }

        public void onlyInt()
        {
            MessageBox.Show("Az 'Ár' mező csak számokat fogad el!", "Hiba", MessageBoxButtons.OK);
        }

        public void uniqueItem()
        {
            MessageBox.Show("Egyedi tétel. Árat külön kell megadni!", "Egyedi tétel", MessageBoxButtons.OK);
        }

        public void invoiceExists(string table)
        {
            MessageBox.Show("Ez a számla már egy másik asztalon létezik! (" + table.Substring(12, table.Length - 16) + ")", "Létező számla", MessageBoxButtons.OK);
        }

        public void emptyInput()
        {
            MessageBox.Show("Üresen hagyott mező!", "Üres mező", MessageBoxButtons.OK);
        }

        public void saveThenExit(int exitCode)
        {
            switch (exitCode)
            {
                case 0: 
                    break;

                case 1:
                    MessageBox.Show("Nem található a 'resources' mappa egyik eleme! Kérem indítsa újra a programot. Az asztalokon lévő számlák nem fognak elveszni.", "Kritikus hiba", MessageBoxButtons.OK);
                    break;

                case 2:
                    MessageBox.Show("Nem található a 'tables' mappa egyik eleme! Kérem indítsa újra a programot. Az asztalokon lévő számlák elvesztek.", "Kritikus hiba", MessageBoxButtons.OK);
                    break;

                case 3:
                    //TBA
                    break;

                default:
                    MessageBox.Show("Ismeretlen hiba történt. Kérem indítsa újra az alkalmazást. Az asztalokon lévő számlák nem fognak elveszni.", "Ismeretlen hiba", MessageBoxButtons.OK);
                    break;
            }

            File.Delete("resources/_currentTable");
            Application.Exit();
        }
    }
}
