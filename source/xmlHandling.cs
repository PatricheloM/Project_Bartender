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

    public class xmlHandling
    {
        publicExceptionHandling publicExceptionHandling = new publicExceptionHandling();
        public List<string> index = new List<string>();
        public List<string> name = new List<string>();
        public List<int> price = new List<int>();
        private int itallapCount = 0;

        string foundIn = null;

        public string getFoundXml()
        {
            return foundIn;
        }

        public int getItallapCount()
        {
            return itallapCount;
        }

        public void xmlRead()
        {
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.DtdProcessing = DtdProcessing.Parse;
                settings.MaxCharactersFromEntities = 1024;

                XElement xmlNodes = XElement.Load("resources/itallap.xml");
                IEnumerable<String> result = xmlNodes.Descendants("item").Select(id => id.Attribute("id").Value);

                index = result.ToList();
                itallapCount = index.Count();
                name.Clear();
                price.Clear();

                using (XmlReader reader = XmlReader.Create("resources/itallap.xml", settings))
                {
                    while (reader.Read())
                    {
                        if (reader.IsStartElement())
                        {
                            switch (reader.Name.ToString())
                            {
                                case "name":
                                    name.Add(reader.ReadString());
                                    break;
                                case "price":
                                    price.Add(Convert.ToInt32(reader.ReadString()));
                                    break;
                            }
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                publicExceptionHandling.saveThenExit(1);
            }
        }

        public void delete(int removeAt)
        {
            try 
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("resources/itallap.xml");

                XmlNodeList deletable = doc.SelectNodes("/drinks/item[@id='" + removeAt + "']");
                foreach (XmlNode node in deletable)
                {
                    node.ParentNode.RemoveChild(node);
                }
                doc.Save("resources/itallap.xml");

                xmlRead();

                for (int i = 0; i < itallapCount - 1; i++)
                {
                    index[i] = Convert.ToString(i);
                }

                xmlWrite();

            }
            catch (FileNotFoundException)
            {
                publicExceptionHandling.saveThenExit(1);
            }
        }

        public void xmlWrite()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("resources/itallap.xml");
                XmlNode root = doc.SelectNodes("/drinks")[0];
                root.RemoveAll();
                doc.Save("resources/itallap.xml");

                for (int i = 0; i < index.Count; i++)
                {
                    XmlElement elem = doc.CreateElement("item");
                    elem.SetAttribute("id", Convert.ToString(i + 1));
                    elem.AppendChild(doc.CreateElement("name"));
                    elem.AppendChild(doc.CreateElement("price"));
                    elem.ChildNodes[0].InnerText = name[i];
                    elem.ChildNodes[1].InnerText = Convert.ToString(price[i]);
                    root.AppendChild(elem);
                    doc.Save("resources/itallap.xml");
                }
            }
            catch (FileNotFoundException)
            {
                publicExceptionHandling.saveThenExit(1);
            }
        }

        public void xmlAdd(string indexAdd, string nameAdd, int priceAdd)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("resources/itallap.xml");
                XmlNode root = doc.SelectNodes("/drinks")[0];
                XmlElement elem = doc.CreateElement("item");
                elem.SetAttribute("id", indexAdd);
                elem.AppendChild(doc.CreateElement("name"));
                elem.AppendChild(doc.CreateElement("price"));
                elem.ChildNodes[0].InnerText = nameAdd;
                elem.ChildNodes[1].InnerText = Convert.ToString(priceAdd);
                root.AppendChild(elem);
                doc.Save("resources/itallap.xml");
                xmlRead();
            }
            catch (FileNotFoundException)
            {
                publicExceptionHandling.saveThenExit(1);
            }
        }

        public List<string> searchInvoicesB()
        {
            string[] xmlsB = Directory.GetFiles("tables/", "*B.xml", SearchOption.TopDirectoryOnly);

            List<string> invoicesB = new List<string>();

            foreach (var xml in xmlsB)
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.DtdProcessing = DtdProcessing.Parse;
                settings.MaxCharactersFromEntities = 1024;

                using (XmlReader reader = XmlReader.Create(xml, settings))
                {
                    while (reader.Read())
                    {
                        if (reader.IsStartElement())
                        {
                            switch (reader.Name.ToString())
                            {
                                case "invoice":
                                    invoicesB.Add(reader.ReadString());
                                    break;
                            }
                        }
                    }
                }
            }

            return invoicesB;
        }

        public List<string> searchInvoicesK()
        {
            string[] xmlsK = Directory.GetFiles("tables/", "*K.xml", SearchOption.TopDirectoryOnly);

            List<string> invoicesK = new List<string>();

            foreach (var xml in xmlsK)
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.DtdProcessing = DtdProcessing.Parse;
                settings.MaxCharactersFromEntities = 1024;

                using (XmlReader reader = XmlReader.Create(xml, settings))
                {
                    while (reader.Read())
                    {
                        if (reader.IsStartElement())
                        {
                            switch (reader.Name.ToString())
                            {
                                case "invoice":
                                    invoicesK.Add(reader.ReadString());
                                    break;
                            }
                        }
                    }
                }
            }

            return invoicesK;
        }

        public string[,] searchInvoiceFor(string invoice)
        {
            List<string> B = searchInvoicesB();
            List<string> K = searchInvoicesK();

            int countB = B.Count(s => invoice.Contains(s));
            int countK = K.Count(s => invoice.Contains(s));
            int count = countB + countK;

            string[,] invoiceArray = new string[count, 2];

            string[] xmls = Directory.GetFiles("tables/", "*.xml", SearchOption.TopDirectoryOnly);

            foreach (var xml in xmls)
            {
                foreach (var line in File.ReadAllLines(xml))
                {
                    if (line.Contains("<invoice>" + invoice + "</invoice>"))
                    {
                        foundIn = xml;
                        break;
                    }
                }
            }

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            settings.MaxCharactersFromEntities = 1024;

            List<string> _0 = new List<string>();
            List<string> _1 = new List<string>();
            List<string> _2 = new List<string>();


            using (XmlReader reader = XmlReader.Create(foundIn, settings))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name.ToString())
                        {
                            case "name":
                                _0.Add(reader.ReadString().ToUpper());
                                break;
                            case "price":
                                _1.Add(reader.ReadString());
                                break;
                            case "invoice":
                                _2.Add(reader.ReadString());
                                break;
                        }
                    }
                }
            }

            for (int i = 0; i < _2.Count(); i++)
            {
                if (_2[i] == invoice)
                {
                    invoiceArray[count - 1, 0] = _0[i];
                    invoiceArray[count - 1, 1] = _1[i];
                    count--;
                }
            }

            return invoiceArray;
        }

    }
}