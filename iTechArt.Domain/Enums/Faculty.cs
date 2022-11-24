using System.Xml.Serialization;

namespace iTechArt.Domain.Enums
{
    public enum Faculty : byte
    {
        [XmlEnum("1")]
        MedStaff = 1,
        [XmlEnum("2")]
        Grocery = 2,
        [XmlEnum("3")]
        Police = 3,
        //[XmlEnum("4")]

    }
}
