using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorWebApp.Contexts;
using RazorWebApp.Models;

namespace RazorWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;

        public List<Customer> Customers
        {
            get;
            private set;
        }

        [TempData]
        public string Message
        {
            get;
            set;
        }

        public IndexModel(AppDbContext db)
        {
            _db = db;
        }

        public async Task OnGetAsync()
        {
            Customers = await _db.Customers.AsNoTracking().ToListAsync<Customer>();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            Customer toDelete = await _db.Customers.FindAsync(id);

            if (toDelete != null)
            {
                _db.Customers.Remove(toDelete);
                await _db.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}
