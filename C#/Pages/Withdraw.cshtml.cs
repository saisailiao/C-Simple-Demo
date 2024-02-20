using FRS.Pages.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace FRS.Pages
{
    public class WithdrawModel : PageModel
    {
        private readonly ILogger<WithdrawModel> _logger;

        public WithdrawModel(ILogger<WithdrawModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        [BindProperty]
        [Required]
        [Range(0.01, 10000.00, ErrorMessage = "Please enter a valid amount between 0.01 and 10,000")]
        public decimal WithdrawAmount { get; set; }
        public string Message { get; set; } = "";
        public bool ShowMessage { get; set; } = false;



        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();

            }


            string csv_file_path = @"C:\Users\SiyuLiao\Downloads\test.csv";
            readCSV read = new readCSV();
            List<Person> persons = read.ReadCsvFile(csv_file_path);

            int newBalance = persons[0].Balance - (int)WithdrawAmount;

            persons[0].Balance = newBalance;

            WriteCSV writeCSV = new WriteCSV();
            string csvContent = writeCSV.ConvertToCsvFormat(persons);

            writeCSV.WriteCsvFile(csv_file_path, csvContent);

            // TODO: SET THE DEPOSIT TO THE BALANCE

            // Set the message and the flag
            Message = $"You have withdrawed {WithdrawAmount}.";
            ShowMessage = true;

            return Page();
        }
    }
}
