using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using iTechArt.Domain.Enums;

namespace iTechArt.Service.Helpers
{
    public class EnumConverterHelper<T> : EnumConverter where T : struct
    {
        public EnumConverterHelper() : base(typeof(T)) { }
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (!Enum.TryParse(text, out Gender genderType))
            {
                // This is just to make the user life simpler...
                if (text == "Male")
                {
                    return Gender.Male;
                }
                else if (text == "Female")
                {
                    return Gender.Female;
                }
                // If an invalid value is found in the CSV for the Gender column, throw an exception...
                throw new InvalidCastException($"Invalid value to EnumConverter. Type: {typeof(T)} Value: {text}");
            }
            return genderType;
        }
    }
}