using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace Razor4602.Pages
{
public class ZodiacModel : PageModel
    {
        [BindProperty]
        public string? SelectedYear { get; set; }
        public string? Zodiac { get; set; }
        public string? ZodiacImage { get; set; }
        public string? ErrorMessage { get; set; }
        public int CurrentYear { get; } = DateTime.Now.Year;

        public void OnGet()
        {
            // This method is called when the page is initially loaded.
            // You can perform any initial setup here if needed.
        }

        public IActionResult OnPostGetZodiacInfo()
        {
            if (!int.TryParse(SelectedYear, out int year))
            {
                ErrorMessage = "Invalid year format.";
                Zodiac = "";
                ZodiacImage = "";
                return Page();
            }
            else if ((year < 1900 || year > CurrentYear) && year != 0)
            {
                ErrorMessage = $"Year must be between 1900 and {CurrentYear}.";
                Zodiac = "";
                ZodiacImage = "";
                return Page();
            }
            else if (year == 0)
            {
                ErrorMessage = "";
                Zodiac = "";
                ZodiacImage = "";
                return Page();
            }
            else
            {
                ErrorMessage = "";
                Zodiac = GetZodiac(year);
                ZodiacImage = $"/images/{Zodiac.ToLower()}.png"; // Assuming lowercase image names
                return Page();
            }
        }

        private string GetZodiac(int year)
        {
            string[] zodiac = new string[12];
            zodiac[0] = "Monkey";
            zodiac[1] = "Rooster";
            zodiac[2] = "Dog";
            zodiac[3] = "Pig";
            zodiac[4] = "Rat";
            zodiac[5] = "Ox";
            zodiac[6] = "Tiger";
            zodiac[7] = "Rabbit";
            zodiac[8] = "Dragon";
            zodiac[9] = "Snake";
            zodiac[10] = "Horse";
            zodiac[11] = "Goat";

            int remainder = year % 12;
            return zodiac[remainder];
        }
    }
}
