using System.Collections.Generic;
using System.Xml;

namespace SimPe.Data
{

    public class SemiGlobalListing : List<SemiGlobalAlias>
    {
        readonly string _flname;
        
        public SemiGlobalListing() { }

        public SemiGlobalListing(string flname)
        {
            _flname = flname;
            LoadXml();
        }

        void LoadXml()
        {
            //read XML File
            var xmlfile = new XmlDocument();
            xmlfile.Load(_flname);

            //seek Root Node
            var xmlData = xmlfile.GetElementsByTagName("semiglobals");

            //Process all Root Node Entries
            for (var i = 0; i < xmlData.Count; i++)
            {
                var node = xmlData.Item(i);
                foreach (XmlNode subnode in node.ChildNodes)
                    ProcessItem(subnode);
                
            }
        }

        void ProcessItem(XmlNode node)
        {
            var known = false;
            uint group = 0;
            var name = "";
            foreach (XmlNode subnode in node)
            {
                if (subnode.Name == "known")
                {
                    known = true;
                }
                else if (subnode.Name == "group")
                {
                    group = Helper.StringToUInt32(subnode.InnerText, 0, 16);
                }
                else if (subnode.Name == "name")
                {
                    name = subnode.InnerText.Trim();
                }
            }

            if (name!="" && group !=0)
                Add(new SemiGlobalAlias(known, group, name));
        }
    }
}
