using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace BenchMark.BasketActions
{
    [Serializable]
    public class BasketContainer
    {
        [XmlAttribute]
        public byte[] BasketInBytes { get; set; }
    }
}
