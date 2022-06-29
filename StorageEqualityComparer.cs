using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace lab2dn
{
    class StorageEqualityComparer : IEqualityComparer<XElement>
    {
        public bool Equals(XElement storage1, XElement storage2)
        {
            if (storage1.Element("StorageID").Value == storage2.Element("StorageID").Value
                  && storage1.Element("CurrentWeight").Value == storage2.Element("CurrentWeight").Value
                  && storage1.Element("MaxWeight").Value == storage2.Element("MaxWeight").Value)
                return true;
            else return false;
        }
        public int GetHashCode(XElement obj)
        {
            return Int32.Parse(obj.Element("StorageID").Value);
        }
    }
}
