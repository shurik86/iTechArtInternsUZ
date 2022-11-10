﻿using System.Globalization;
using System.Text.Json;

namespace iTechArt.Domain.Helpers
{
    public sealed class DateOnlyJsonConverter : System.Text.Json.Serialization.JsonConverter<DateOnly>
    {
        private const string Format = "yyyy-MM-dd";

        /// <summary>
        /// Reads and serializes DateOnly
        /// </summary>
        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateOnly.ParseExact(reader.GetString(), Format, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Writes DateOnly
        /// </summary>
        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(Format, CultureInfo.InvariantCulture));
        }
    }
}
