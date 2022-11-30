using System.Xml.Serialization;

namespace iTechArt.Domain.Enums
{
    public enum Faculty : byte
    {
        [XmlEnum("1")]
        Economics = 1,
        
        [XmlEnum("2")]
        Law = 2,
        
        [XmlEnum("3")]
        Medicine = 3,

        [XmlEnum("4")]
        Psychology = 4,

        [XmlEnum("5")]
        Engineering = 5,

        [XmlEnum("6")]
        Science = 6,
    }
}
