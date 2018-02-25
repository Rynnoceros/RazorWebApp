using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RazorWebApp.Contexts;
using RazorWebApp.Models;

namespace RazorWebApp.Pages
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _db;

        private ILogger<CreateModel> _log;

        [TempData]
        public string Message
        {
            get;
            set;
        }

        [BindProperty]
        public Customer Customer
        {
            get;
            set;
        }

        public CreateModel(AppDbContext db, ILogger<CreateModel> log)
        {
            _db = db;
            _log = log;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            _db.Customers.Add(Customer);
            await _db.SaveChangesAsync();
            Message = $"Customer {Customer.Name} added!";
            _log.LogCritical(Message);
            return RedirectToPage("/Index");
        }
    }
}
