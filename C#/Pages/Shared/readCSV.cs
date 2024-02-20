using FRS.Pages.Shared;

namespace FRS.Pages.Shared
{
    public class readCSV
    {
        public List<Person> ReadCsvFile(string filePath)
        {
            var persons = new List<Person>();

            using (var reader = new StreamReader(filePath))
            {
                string line;
                bool isFirstLine = true; // Assuming first line is header

                while ((line = reader.ReadLine()) != null)
                {
                    if (isFirstLine)
                    {
                        isFirstLine = false;
                        continue;
                    }

                    var values = line.Split(',');
                    var person = new Person()
                    {
                        No = int.Parse(values[0]),
                        Name = values[1],
                        Balance = int.Parse(values[2]),
                    };

                    persons.Add(person);
                }
            }

            return persons;
        }

    }
}
