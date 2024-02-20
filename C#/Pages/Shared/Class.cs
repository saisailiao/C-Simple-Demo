using System.Text;

namespace FRS.Pages.Shared
{
    public class WriteCSV
    {
        public string ConvertToCsvFormat(IEnumerable<Person> persons)
        {
            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("No,Name,Balance"); // Header

            foreach (var person in persons)
            {
                var line = $"{person.No},{person.Name},{person.Balance}";
                csvBuilder.AppendLine(line);
            }

            return csvBuilder.ToString();
        }

        public void WriteCsvFile(string filePath, string csvContent)
        {
            File.WriteAllText(filePath, csvContent);
        }


    }
}
