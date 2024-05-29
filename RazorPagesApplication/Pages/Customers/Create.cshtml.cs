using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesApplication.Pages.Customers
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Customer? Customer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            using var conn = new System.Data.SqlClient.SqlConnection("");

            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Users WHERE Name = '" + Customer?.Name + "'";

            var result = cmd.ExecuteScalar();

            return RedirectToPage("./Index");
        }
    }
}
