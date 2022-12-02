using System.Xml.Serialization;

namespace iTechArt.Domain.Enums
{
    public enum Gender : byte
    {
        [XmlEnum("1")]
        Male = 1,
        
        [XmlEnum("2")]
        Female = 2
    }
}
