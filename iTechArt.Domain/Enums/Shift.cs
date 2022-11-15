using System.Xml.Serialization;

namespace iTechArt.Domain.Enums
{
    public enum Shift : byte
    {
        [XmlEnum("1")]
        Day = 1,
        [XmlEnum("2")]
        Night = 2
    }
}
