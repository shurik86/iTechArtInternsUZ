using System.Xml.Serialization;

namespace iTechArt.Domain.Enums
{
    public enum CourseLanguage : byte
    {
        [XmlEnum("1")]
        Russian = 1,
        [XmlEnum("2")]
        Uzbek = 2,
        [XmlEnum("3")]
        English = 3
    }
}
