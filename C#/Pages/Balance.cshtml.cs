using FRS.Pages.Shared;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace FRS.Pages
{
    public class BalanceModel : PageModel
    {
        public void OnGet()
        {
            // string filePath = Server.MapPath("C:\\Users\\SiyuLiao\\Downloads\\test.csv"); // Adjust the path as needed
            string csv_file_path = @"C:\Users\SiyuLiao\Downloads\test.csv";
            readCSV read = new readCSV();
            List<Person> persons = read.ReadCsvFile(csv_file_path);
            ViewData["Balance"] = persons[0].Balance;

        }
    }
}
