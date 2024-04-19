using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;

namespace Etiqueta;

public class CSVService : ICSVService
{
    public IEnumerable<T> ReadCSV<T>(Stream file)
    {
        var reader = new StreamReader(file);
        var config = new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = ";", Encoding = Encoding.UTF8 };
        var csv = new CsvReader(reader, config);       

        var records = csv.GetRecords<T>();
        return records;
    }
}