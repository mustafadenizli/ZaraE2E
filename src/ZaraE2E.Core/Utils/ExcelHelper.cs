using System.Data;
using System.IO;
using ExcelDataReader;

namespace ZaraE2E.Utils
{
    public static class ExcelHelper
    {
        public static string ReadCell(string filePath, int row, int col)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet();
                    var table = result.Tables[0];
                    var value = table.Rows[row][col];
                    return value?.ToString() ?? string.Empty;
                }
            }
        }
    }
}
