namespace iTechArt.Api.Constants
{
    public static class FileConstants
    {
        /// <summary>
        /// Types of extensions.
        /// </summary>
        public static readonly string[] Extensions = { ".csv", ".xml",".xlsx", ".xls", ".xlsm", ".xlsb", ".xltx", ".xltm", ".xlt", ".xlam", ".xla", ".xlw" };

        /// <summary>
        /// Constant file extension strings.
        /// </summary>
        public const string csv = ".csv";
        public const string xml = ".xml";
        public const string xlsx = ".xlsx";
        public const string xls = ".xls";

        /// <summary>
        /// Content types of CSV files.
        /// </summary>
        public static readonly string[] CSV =
        {
            "text/csv"
        };

        /// <summary>
        /// Content types of XML files.
        /// </summary>
        public static readonly string[] XML =
        {
            "text/xml",
            "application/xml",
            "application/xaml+xml",
            "application/xhtml+xml"
        };

        /// <summary>
        /// Content types of EXCEL files.
        /// </summary>
        public static readonly string[] EXCEL =
        {
            "application/vnd.ms-excel",
            "application/vnd.ms-excel.sheet.macroEnabled.12",
            "application/vnd.ms-excel.addin.macroEnabled.12",
            "application/vnd.ms-excel.template.macroEnabled.12",
            "application/vnd.ms-excel.sheet.binary.macroEnabled.12",
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            "application/vnd.openxmlformats-officedocument.spreadsheetml.template"
        };

        /// <summary>
        /// Content Type for XML and XLSX.
        /// </summary>
        public const string XmlContent = "text/xml";
        public const string ExcelContent = "application/vnd.ms-excel";

        /// <summary>
        /// Constants for File Titles.
        /// </summary>
        public const string Police = "Police";
        public const string Airports = "Airports";
        public const string Groceries = "Groceries";
        public const string MedStaff = "MedStaff";
        public const string Pupils = "Pupils";
        public const string Students = "Students";
    }
}
