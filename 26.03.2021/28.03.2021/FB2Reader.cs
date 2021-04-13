using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Xml.Linq;

namespace _28._03._2021
{
    class FB2Reader
    {
        private string _filename;
        private XDocument _xDocument;
        private List<Block> _blocks;

        public FB2Reader(string _filename)
        {
            string content = File.ReadAllText(_filename);
            if (content.Length == 0) { MessageBox.Show("File is empty!"); return; }
            else _xDocument = XDocument.Parse(content);
        }

        public List<Block> GetBlocks()
        {
            _blocks = new List<Block>();
            foreach (XElement xElement in _xDocument.Descendants())
            {
                if (xElement.Name == "{http://www.gribuser.ru/xml/fictionbook/2.0}p")
                _blocks.Add(new Paragraph(new Run(xElement.Value)));
            }

            return _blocks;
        }
    }
}
